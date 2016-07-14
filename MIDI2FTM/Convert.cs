using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// SMFのトラックをトラッカーのチャンネルにコンバートする
    /// </summary>----------------------------------------------------------------------------------------------------
    public class Convert : ConvertCommon
    {
        /// <summary>フレーム内の小節数</summary>
        int frameInMeasure;
        /// <summary>現在の小節</summary>
        int currentMeasure;
        /// <summary>現在のTick</summary>
        int currentTick;
        /// <summary>最初の小節の長さを取得</summary>
        int oneMeasureTick;
        /// <summary>フレーム移行フラグ</summary>
        bool nextFrame;
        
        /// <summary>
        /// コンストラクタ♪  コンバートするときは必ず引数を渡してください
        /// </summary>----------------------------------------------------------------------------------------------------
        public Convert(int _inputTrackNum, int _outputChannel)
        {
            // ConvertCommonのメンバーに代入
            inputTrackNum = _inputTrackNum;
            outputChannel = _outputChannel;

            // メンバー変数を初期化
            frameInMeasure = 1;
            currentMeasure = BasicConfigState.StartMeasure;
            currentTick = 0;
            oneMeasureTick = getMeasureLength(currentMeasure);
            nextFrame = false;
            beforeVolume = 0xF;
            noteVolume = 127;
            ccVolume = getStartCCVolume(BasicConfigState.StartMeasure);
        }
        
        /// <summary>
        /// コンバートの開始
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerList">リストビューのトラッカーリスト</param>
        /// <param name="_progressBar">ステータスバーのプログレスバー</param>
        public void StartConvert(ref ListView _trackerList, ref ToolStripProgressBar _progressBar)
        {
            // プログレスバーを初期化
            _progressBar.Maximum = (int)BasicConfigState.MaxMeasure;
            _progressBar.Value = 0;

            // 処理中は描画しない
            _trackerList.BeginUpdate();
            foreach (ListViewItem lvi in _trackerList.Items)
            {
                // データ行以外はなにもしない
                if (lvi.Text.Contains("PATTERN") || lvi.Text == "")
                {
                    continue;
                }

                // 行に書き出し
                lvi.SubItems[outputChannel].Text = "... .. . ...";
            }
            
            for (int i = 0; i < _trackerList.Items.Count; i++)
            {
                // プログレスバーにインクリメントする
                _progressBar.PerformStep();

                // 小節を跨いだら
                if (currentTick >= oneMeasureTick)
                {
                    // 小節をすすめる
                    currentMeasure++;
                    // 小節の頭にする
                    currentTick = 0;
                    // 次の小節へ
                    frameInMeasure++;
                    // 次の小節の長さを取得
                    int tmp = getMeasureLength(currentMeasure);
                    // 拍子の変化でフレームを移行する場合
                    if (BasicConfigState.ChangedFrame && oneMeasureTick != tmp)
                    {
                        frameInMeasure = 1;
                        nextFrame = true;
                    }
                    oneMeasureTick = tmp;
                }

                // フレームを移行する
                if (frameInMeasure > BasicConfigState.OneFrameMeasureCount)
                {
                    frameInMeasure = 1;
                    nextFrame = true;
                }

                // データ行以外はなにもしない PATTERN名行の次は必ずフレームの最初だからフラグを折る
                if (_trackerList.Items[i].Text.Contains("PATTERN") || _trackerList.Items[i].Text == "")
                {
                    nextFrame = false;
                    continue;
                }
                
                // フレーム移行中はなにもしない
                if (nextFrame)
                {
                    continue;
                }
                
                // 行に書き出し
                _trackerList.Items[i].SubItems[outputChannel].Text = getRowData();

                // 次の音価へ
                currentTick += (int)BasicConfigState.TicksPerLine;
            }
            // 再描画
            _trackerList.EndUpdate();
        }

        /// <summary>
        /// 行のデータを文字列で取得する
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <returns>行のデータ文字列</returns>
        private string getRowData()
        {
            // 行に書き出し用変数を用意
            string outputRowText = null;

            EventData noteOnEvent = new EventData();
            // 現在の行の対象のノートオンイベントを取得
            if (ChannelConfigState.EnableEffectGxx)
            {
                noteOnEvent = getCurrentRangeNote(currentMeasure, currentTick);
            }
            else
            {
                noteOnEvent = getCurrentNote(currentMeasure, currentTick);
            }
            // 有効にする音量情報を取得する
            EventData ccVolumeEvent = getCurrentCCVolume(currentMeasure, currentTick);

            // ノートオン、音色番号の文字列を追加
            outputRowText = getNote(noteOnEvent);

            // ボリュームの文字列を追加
            outputRowText += getVolume(noteOnEvent, ccVolumeEvent);
            
            // エフェクト情報
            
            // Gxx 連符 nTickずらす
            if (EffectGTick > 0 && ChannelConfigState.EnableEffectGxx)
            {
                outputRowText += " G" + EffectGTick.ToString("00");
            }
            // 4xx モジュレーション

            // Pxx ピッチベンド オミットするかも

            else
            {
                outputRowText += " ...";
            }

            return outputRowText;
        }
    }
}
