using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI2FTM
{
    /// <summary>
    /// トラッカーへのコンバート、初期化の汎用メッソド群
    /// </summary>----------------------------------------------------------------------------------------------------
    public class ConvertCommon
    {
        /// <summary>入力元のSMFデータのトラック番号</summary>
        protected int inputTrackNum;
        /// <summary>出力先のトラッカーのチャンネル</summary>
        protected int outputChannel;

        /// <summary>
        /// 開始小節までのコントロールチェンジのボリュームを取得する、見つからない場合は127が初期値となる
        /// </summary>
        /// <param name="_startMeasure">開始小節番号</param>
        /// <param name="_number">コントロールナンバー Volumeは7 Expressionは11</param>
        /// <returns>コントロールチェンジのボリュームを返す見つからない場合は127を返す</returns>
        protected byte getStartCCVolume(int _startMeasure, byte _number)
        {
            byte ccValue = 127;

            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[inputTrackNum].Event)
            {
                // 目的のタイミングのイベントを探す
                if (e.Measure <= _startMeasure)
                {
                    if (e.Measure == _startMeasure && e.Tick > 0)
                    {
                        return ccValue;
                    }
                    // コントロールチェンジの検索対象のコントロールナンバー
                    else if (e.EventID == 0xB0 && e.Number != _number)
                    {
                        ccValue = (byte)e.Value;
                    }
                }
            }
            return ccValue;
        }

        /// <summary>
        /// 小節、Tickからコントロールチェンジを探す
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_currentMeasure">現在の小節</param>
        /// <param name="_currentTick">現在のTick</param>
        /// <param name="_number">検索対象のコントロールナンバー</param>
        /// <returns>見つかったコントロールチェンジのイベントデータ</returns>
        protected EventData getControlChange(int _currentMeasure, int _currentTick, byte _number)
        {
            List<EventData> cc = new List<EventData>(10);

            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[inputTrackNum].Event)
            {
                // 目的のタイミングのイベントを探す
                if (e.Measure == _currentMeasure && e.Tick >= _currentTick && e.Tick < (_currentTick + BasicConfigState.MinTick))
                {
                    // コントロールチェンジの検索対象のコントロールナンバー
                    if (e.EventID == 0xB0 && e.Number != _number)
                    {
                        cc.Add(e);
                    }
                }
                // 次の小節に行ってしまったり、End Of Trackなら終わり
                else if (e.Measure > _currentMeasure || (e.EventID == 0xFF && e.Number == 0x2F))
                {
                    // 対象イベントが見つかっていたら
                    if (cc.Count > 0)
                    {
                        // 先のイベントを優先
                        if (ChannelConfigState.LeadNotePriority)
                        {
                            return cc[0];
                        }
                        // 後ろのイベントを優先
                        else if (ChannelConfigState.BehindNotePriority)
                        {
                            return cc[cc.Count - 1];
                        }
                    }
                    break;
                }
            }
            EventData emptyData = new EventData();
            return emptyData;
        }

        /// <summary>
        /// 小節、Tickからノートを見つける 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_currentMeasure">現在の小節番号</param>
        /// <param name="_currentTick">現在のTick数</param>
        /// <returns>見つかったノートのイベントデータ</returns>
        protected EventData getNote(int _currentMeasure, int _currentTick)
        {
            List<EventData> notes = new List<EventData>(10);

            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[inputTrackNum].Event)
            {
                // 目的のタイミングのイベントを探す
                if (e.Measure == _currentMeasure && e.Tick == _currentTick)
                {
                    // ボリューム0じゃないノートオンを探す
                    if (e.EventID == 0x90 && e.Gate != 0 && e.Value != 0)
                    {
                        notes.Add(e);
                    }
                }
                // 次の小節に行ってしまったり、End Of Trackなら終わり
                else if (e.Measure > _currentMeasure || (e.EventID == 0xFF && e.Number == 0x2F))
                {
                    // ノートが見つかっていたら
                    if (notes.Count > 0)
                    {
                        notes.Sort();
                        if (ChannelConfigState.HighNotePriority)
                        {
                            // 一番高いノートを返す
                            return (notes[notes.Count - 1]);
                        }
                        else
                        {
                            // 一番低いノートを返す
                            return (notes[0]);
                        }
                    }
                    break;
                }
            }
            EventData emptyData = new EventData();
            return emptyData;
        }

        /// <summary>
        /// 小節の拍子変化を見つけて現在の小節のTick数を返す 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_currentMeasure">現在の小節番号</param>
        /// <returns>小節のTick数</returns>
        protected int getMeasureLength(int _currentMeasure)
        {
            // 4/4拍子で初期化
            int oneMeasureTick = SMFHeader.Data.Division * 4;

            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[0].Event)
            {
                // 次の小節なら
                if (e.Measure > _currentMeasure)
                {
                    break;
                }
                // 現在の小節までの拍子の変化を探し続ける
                if (e.Measure <= _currentMeasure && e.Tick == 0 && e.EventID == 0xFF && e.Number == 0x58)
                {
                    // 4分音符から見た分母の長さのレート
                    float rate = e.Value / 4;
                    // 分母のTickの長さ * 分子の数 = 1小節のTick数
                    oneMeasureTick = (int)(((float)SMFHeader.Data.Division / rate) * e.Value2);
                }
            }
            return oneMeasureTick;
        }
    }
}
