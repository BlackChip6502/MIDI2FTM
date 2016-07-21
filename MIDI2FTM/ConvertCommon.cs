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
        /// <summary>現在の小節</summary>
        protected int m_CurrentMeasure;
        /// <summary>現在のTick</summary>
        protected int m_CurrentTick;
        /// <summary>入力元のSMFデータのトラック番号</summary>
        protected int m_InputTrackNum;
        /// <summary>出力先のトラッカーのチャンネル</summary>
        protected int m_OutputChannel;
        /// <summary>直前に出力したの音量</summary>
        protected byte m_BeforeVolume;
        /// <summary>ノートの音量</summary>
        protected byte m_NoteVolume;
        /// <summary>コントロールチェンジの音量</summary>
        protected byte m_CCVolume;
        /// <summary>エフェクトGxxのTick数</summary>
        protected int m_EffectGxxTick;
        /// <summary>エフェクト4xxの値</summary>
        protected int m_Effect4xxValue;
        /// <summary>直前の4xxの値</summary>
        protected int m_Before4xxValue;
        /// <summary>エフェクトPxxの値</summary>
        protected int m_EffectPxxValue;
        /// <summary>直前のPxxの値</summary>
        protected int m_BeforePxxValue;
        /// <summary>エフェクトの数</summary>
        protected byte m_EffectCount;

        /// <summary>
        /// エフェクトG,4,Pを追加する
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <returns>追加したエフェクト文字列を返す</returns>
        protected string addEffects()
        {
            // 戻り値の文字列
            string outputText = "";

            // Gxx 連符
            if (m_EffectGxxTick > 0 && ChannelConfigState.EnableEffectGxx)
            {
                outputText += " G" + m_EffectGxxTick.ToString("X2");
            }
            else if (m_EffectGxxTick == 0 && ChannelConfigState.EnableEffectGxx)
            {
                outputText += " ...";
            }
            // 4xx モジュレーション
            setEffect4xxValue();
            if (m_Effect4xxValue > 0 && ChannelConfigState.EnableEffect4xx)
            {
                outputText += " 4" + m_Effect4xxValue.ToString("X2");
            }
            else if (m_Effect4xxValue == 0 && ChannelConfigState.EnableEffect4xx)
            {
                outputText += " ...";
            }
            // Pxx ピッチベンド
            setEffectPxxValue();
            if (m_EffectPxxValue > 0 && ChannelConfigState.EnableEffectPxx)
            {
                outputText += " P" + m_EffectPxxValue.ToString("X2");
            }
            else if (m_EffectPxxValue == 0 && ChannelConfigState.EnableEffectPxx)
            {
                outputText += " ...";
            }
            
            return outputText;
        }

        /// <summary>
        /// エフェクトG,4,Pを左詰めで追加する
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <returns>追加したエフェクト文字列を返す</returns>
        protected string addLeftAlignedEffects()
        {
            // 戻り値の文字列
            string outputText = "";
            // 追加するエフェクトの数をカウント
            byte tmpCount = 0;

            // Gxx 連符
            if (m_EffectGxxTick > 0 && ChannelConfigState.EnableEffectGxx)
            {
                outputText += " G" + m_EffectGxxTick.ToString("X2");
                tmpCount++;
            }
            // 4xx モジュレーション
            setEffect4xxValue();
            if (m_Effect4xxValue > 0 && ChannelConfigState.EnableEffect4xx)
            {
                outputText += " 4" + m_Effect4xxValue.ToString("X2");
                tmpCount++;
            }
            // Pxx ピッチベンド
            setEffectPxxValue();
            if (m_EffectPxxValue > 0 && ChannelConfigState.EnableEffectPxx)
            {
                outputText += " P" + m_EffectPxxValue.ToString("X2");
                tmpCount++;
            }
            // エフェクトの数の更新チェック
            if (m_EffectCount < tmpCount)
            {
                // 使用しているエフェクトの数を更新
                m_EffectCount = tmpCount;
            }

            if (m_EffectGxxTick == 0)
            {
                outputText += " ...";
            }
            if (m_Effect4xxValue == 0)
            {
                outputText += " ...";
            }
            if (m_EffectPxxValue == 0)
            {
                outputText += " ...";
            }

            return outputText;
        }

        /// <summary>
        /// 現在の小節、現在Tickから次の音価未満のTickのCCモジュレーションを見つけてEffect4xxValueを更新する
        /// </summary>----------------------------------------------------------------------------------------------------
        private void setEffect4xxValue()
        {
            // 一旦初期化
            m_Effect4xxValue = 0;

            EventData modulationData = new EventData();
            if (ChannelConfigState.EnableEffect4xx)
            {
                // CCモジュレーションを取得
                modulationData = getCurrentRangeControlChange(1);
            }

            // CCモジュレーションを見つけていたら
            if (modulationData.EventID == 0xB0 && modulationData.Number == 1)
            {
                // 計算できない変換だから適当にビブラートさせる
                if (modulationData.Value > 96)
                {
                    m_Effect4xxValue = 0x64;
                }
                else if (modulationData.Value > 64)
                {
                    m_Effect4xxValue = 0x63;
                }
                else if (modulationData.Value > 32)
                {
                    m_Effect4xxValue = 0x62;
                }
                else if (modulationData.Value > 0)
                {
                    m_Effect4xxValue = 0x61;
                }

                // 直前の値と同じならエフェクトを適用しない
                if (m_Before4xxValue == m_Effect4xxValue)
                {
                    m_Effect4xxValue = 0;
                }
                // 違うなら直前の値として記録する
                else
                {
                    m_Before4xxValue = m_Effect4xxValue;
                }
            }
        }

        /// <summary>
        /// 現在の小節、現在Tickから次の音価未満のTickのピッチベンドを見つけてEffectPxxValueを更新する
        /// </summary>----------------------------------------------------------------------------------------------------
        private void setEffectPxxValue()
        {
            // 一旦初期化
            m_EffectPxxValue = 0;

            EventData pitchBendData = new EventData();
            // ピッチベンドを取得
            if (ChannelConfigState.EnableEffectPxx)
            {
                pitchBendData = getCurrentRangePitchBend();
            }

            // ピッチベンドを見つけていたら
            if (pitchBendData.EventID == 0xE0)
            {
                // ピッチベンドの値を最小値0で整える
                float pitchBendValue = pitchBendData.Value + 8192;

                // 計算して代入 精度はゴミクソレベル
                m_EffectPxxValue = (int)Math.Ceiling(pitchBendValue * (255f / 16383f));

                // 直前の値と同じならエフェクトを適用しない
                if (m_BeforePxxValue == m_EffectPxxValue)
                {
                    m_EffectPxxValue = 0;
                }
                // 違うなら直前の値として記録する
                else
                {
                    m_BeforePxxValue = m_EffectPxxValue;
                }
            }
        }

        /// <summary>
        /// ボリュームを取得する。ノートオン、コントロールチェンジの有効無効を判定して文字列を返す
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_noteOnEvent">ノートオンイベント</param>
        /// <param name="_ccVolumeEvent">CCVolume,CCExpressionイベント</param>
        /// <returns>16進ボリューム文字列、出力対象外では " ." を返す</returns>
        protected string getVolume(EventData _noteOnEvent, EventData _ccVolumeEvent)
        {
            // ノートボリュームが有効なら
            if (_noteOnEvent.EventID == 0x90 && ChannelConfigState.EnableNoteVolume)
            {
                // ノートボリュームを更新
                m_NoteVolume = (byte)_noteOnEvent.Value;
            }
            // CCボリュームが有効なら
            if (_ccVolumeEvent.EventID == 0xB0 && ChannelConfigState.EnableCCVolume)
            {
                // CCボリュームを更新
                m_CCVolume = (byte)_ccVolumeEvent.Value;
            }

            // 適用するボリュームを計算
            byte tmpVolume = (byte)Math.Round(m_NoteVolume / (127f / 15f));
            tmpVolume = (byte)Math.Round(m_CCVolume / (127f / (float)tmpVolume));
            
            // 直前のボリュームと違うなら
            if (m_BeforeVolume != tmpVolume)
            {
                m_BeforeVolume = tmpVolume;
                return " " + tmpVolume.ToString("X1");
            }
            return " .";
        }

        /// <summary>
        /// コントロールチェンジの音量情報を取得する
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <returns>見つけたコントロールチェンジの音量情報のイベントデータ</returns>
        protected EventData getCurrentCCVolume()
        {
            // ノートオン以外のボリュームを有効にするなら CCVolume
            if (ChannelConfigState.EnableCCVolume && ChannelConfigState.CCVolumeToVolume)
            {
                // コントロールチェンジを取得
                return getCurrentRangeControlChange(7);
            }
            // ノートオン以外のボリュームを有効にするなら CCExpression
            else if (ChannelConfigState.EnableCCVolume && ChannelConfigState.CCExpressionToVolume)
            {
                // コントロールチェンジを取得
                return getCurrentRangeControlChange(11);
            }
            
            return new EventData();
        }

        /// <summary>
        /// 開始小節までのコントロールチェンジのボリュームを取得する、見つからない場合やCCを適用しない場合は127が初期値となる
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_startMeasure">開始小節番号</param>
        /// <returns>コントロールチェンジのボリュームを返す見つからない場合やCCを適用しない場合は127を返す</returns>
        protected byte getStartCCVolume(int _startMeasure)
        {
            byte ccValue = 127;

            byte number;
            if (ChannelConfigState.EnableCCVolume && ChannelConfigState.CCVolumeToVolume)
            {
                number = 7;
            }
            else if (ChannelConfigState.EnableCCVolume && ChannelConfigState.CCExpressionToVolume)
            {
                number = 11;
            }
            else
            {
                return ccValue;
            }

            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[m_InputTrackNum].Event)
            {
                // 目的のタイミングのイベントを探す
                if (e.Measure <= _startMeasure)
                {
                    if (e.Measure == _startMeasure && e.Tick > 0)
                    {
                        return ccValue;
                    }
                    // コントロールチェンジの検索対象のコントロールナンバー
                    else if (e.EventID == 0xB0 && e.Number != number)
                    {
                        ccValue = (byte)e.Value;
                    }
                }
            }
            return ccValue;
        }

        /// <summary>
        /// 現在の小節、現在Tickから次の音価未満のTickのコントロールチェンジを探す 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_number">検索対象のコントロールナンバー</param>
        /// <returns>見つかったコントロールチェンジのイベントデータ</returns>
        private EventData getCurrentRangeControlChange(byte _number)
        {
            List<EventData> cc = new List<EventData>(10);

            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[m_InputTrackNum].Event)
            {
                // 目的のタイミングのイベントを探す
                if (e.Measure == m_CurrentMeasure && e.Tick >= m_CurrentTick && e.Tick < (m_CurrentTick + BasicConfigState.TicksPerLine))
                {
                    // コントロールチェンジの検索対象のコントロールナンバー
                    if (e.EventID == 0xB0 && e.Number == _number)
                    {
                        cc.Add(e);
                    }
                }
                // 次の小節に行ってしまったり、End Of Trackなら終わり
                else if (e.Measure > m_CurrentMeasure || (e.EventID == 0xFF && e.Number == 0x2F))
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
            
            return new EventData();
        }

        /// <summary>
        /// 現在の小節、現在Tickから次の音価未満のTickのピッチベンドを探す 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <returns>見つかったピッチベンドのイベントデータ</returns>
        private EventData getCurrentRangePitchBend()
        {
            List<EventData> pb = new List<EventData>(10);

            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[m_InputTrackNum].Event)
            {
                // 目的のタイミングのイベントを探す
                if (e.Measure == m_CurrentMeasure && e.Tick >= m_CurrentTick && e.Tick < (m_CurrentTick + BasicConfigState.TicksPerLine))
                {
                    // コントロールチェンジの検索対象のコントロールナンバー
                    if (e.EventID == 0xE0)
                    {
                        pb.Add(e);
                    }
                }
                // 次の小節に行ってしまったり、End Of Trackなら終わり
                else if (e.Measure > m_CurrentMeasure || (e.EventID == 0xFF && e.Number == 0x2F))
                {
                    // 対象イベントが見つかっていたら
                    if (pb.Count > 0)
                    {
                        // 先のイベントを優先
                        if (ChannelConfigState.LeadNotePriority)
                        {
                            return pb[0];
                        }
                        // 後ろのイベントを優先
                        else if (ChannelConfigState.BehindNotePriority)
                        {
                            return pb[pb.Count - 1];
                        }
                    }
                    break;
                }
            }
            
            return new EventData();
        }

        /// <summary>
        /// 現在の小節、現在Tickから次の音価未満のTickのメタイベントを探す
        /// </summary>----------------------------------------------------------------------------------------------------
        /// /// <param name="_number">メタイベントのイベントタイプ</param>
        /// <returns>見つかったメタイベントのイベントデータ</returns>
        protected EventData getCurrentRangeMetaEvents(byte _number)
        {
            List<EventData> me = new List<EventData>(10);

            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[m_InputTrackNum].Event)
            {
                // 目的のタイミングのイベントを探す
                if (e.Measure == m_CurrentMeasure && e.Tick >= m_CurrentTick && e.Tick < (m_CurrentTick + BasicConfigState.TicksPerLine))
                {
                    // メタイベントの検索対象のコントロールナンバー
                    if (e.EventID == 0xFF && e.Number == _number)
                    {
                        me.Add(e);
                    }
                }
                // 次の小節に行ってしまったり、End Of Trackなら終わり
                else if (e.Measure > m_CurrentMeasure || (e.EventID == 0xFF && e.Number == 0x2F))
                {
                    // 対象イベントが見つかっていたら
                    if (me.Count > 0)
                    {
                        // 先のイベントを優先
                        if (ChannelConfigState.LeadNotePriority)
                        {
                            return me[0];
                        }
                        // 後ろのイベントを優先
                        else if (ChannelConfigState.BehindNotePriority)
                        {
                            return me[me.Count - 1];
                        }
                    }
                    break;
                }
            }

            return new EventData();
        }

        /// <summary>
        /// ノートオンと音色番号の文字列を取得する。ノートオンが無い場合は "... .." を返す
        /// </summary>
        /// <param name="_noteOnEvent">ノートオンイベント</param>
        /// <returns>ノートオンと音色番号の文字列を返す、ノートオンが無い場合は "... .." を返す</returns>
        protected string getNote(EventData _noteOnEvent)
        {
            // ノートオンがある場合
            if (_noteOnEvent.EventID == 0x90)
            {
                // ノイズチャンネルならば
                if (m_OutputChannel == 4)
                {
                    return NoteNumber.NumberToNoiseName(_noteOnEvent.Number) + " " + ChannelConfigState.InstrumentNum.ToString("X2");
                }
                else
                {
                    return NoteNumber.NumberToNoteName(_noteOnEvent.Number) + " " + ChannelConfigState.InstrumentNum.ToString("X2");
                }
            }
            // ノートオンがない場合
            else
            {
                return "... ..";
            }
        }

        /// <summary>
        /// 現在小節、現在Tickから次の音価未満のTickのノートを見つける 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <returns>見つかったノートのイベントデータ</returns>
        protected EventData getCurrentRangeNote()
        {
            List<EventData> notes = new List<EventData>(10);

            m_EffectGxxTick = 0;

            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[m_InputTrackNum].Event)
            {
                // 目的のタイミングのイベントを探す
                if (e.Measure == m_CurrentMeasure && e.Tick >= m_CurrentTick && e.Tick < (m_CurrentTick + BasicConfigState.TicksPerLine))
                {
                    // ボリューム0じゃないノートオンを探す
                    if (e.EventID == 0x90 && e.Gate != 0 && e.Value != 0)
                    {
                        notes.Add(e);
                    }
                }
                // 次の小節に行ってしまったり、End Of Trackなら終わり
                else if (e.Measure > m_CurrentMeasure || (e.EventID == 0xFF && e.Number == 0x2F))
                {
                    // ノートが見つかっていたら
                    if (notes.Count > 0)
                    {
                        uint outputTick;
                        // 先のノート、後のノートのTickを取得する
                        if (ChannelConfigState.LeadNotePriority)
                        {
                            outputTick = notes[0].Tick;
                        }
                        else
                        {
                            outputTick = notes[notes.Count - 1].Tick;
                        }

                        // エフェクトGのTick数を計算
                        m_EffectGxxTick = (int)Math.Floor((float)(outputTick - m_CurrentTick) / BasicConfigState.MinTick);

                        // 先のノート、後のノートを絞り込む
                        for(int i = notes.Count - 1; i >= 0; i--)
                        {
                            // 対象のTick以外を排除
                            if (notes[i].Tick != outputTick)
                            {
                                // 削除
                                notes.Remove(notes[i]);
                            }
                        }

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

            return new EventData();
        }

        /// <summary>
        /// 現在小節、現在Tickからノートを見つける 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <returns>見つかったノートのイベントデータ</returns>
        protected EventData getCurrentNote()
        {
            List<EventData> notes = new List<EventData>(10);

            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[m_InputTrackNum].Event)
            {
                // 目的のタイミングのイベントを探す
                if (e.Measure == m_CurrentMeasure && e.Tick == m_CurrentTick)
                {
                    // ボリューム0じゃないノートオンを探す
                    if (e.EventID == 0x90 && e.Gate != 0 && e.Value != 0)
                    {
                        notes.Add(e);
                    }
                }
                // 次の小節に行ってしまったり、End Of Trackなら終わり
                else if (e.Measure > m_CurrentMeasure || (e.EventID == 0xFF && e.Number == 0x2F))
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
            
            return new EventData();
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
