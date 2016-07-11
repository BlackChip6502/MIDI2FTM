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
        /// <summary>ノートの音量</summary>
        byte noteVolume;
        /// <summary>コントロールチェンジの音量</summary>
        byte ccVolume;

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
            noteVolume = 0xF;
            ccVolume = 0xF;
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

                // 行に書き出し用変数を用意
                string outputRowText = null;

                // 現在の行の対象のノートオンイベントを取得
                EventData noteON = getNote(currentMeasure, currentTick);
                // ノートオン情報
                if (noteON.EventID == 0x90)
                {
                    outputRowText = NoteNumber.NumberToNoteName(noteON.Number) + " ";
                }
                else
                {
                    outputRowText = "... ";
                }

                // 音色番号情報
                if (noteON.EventID == 0x90)
                {
                    outputRowText += ChannelConfigState.InstrumentNum.ToString("X2") + " ";
                }
                else
                {
                    outputRowText += ".. ";
                }
                
                // 有効にする音量情報を取得する
                EventData CCvoCCex = new EventData();
                // ノートオン以外のボリュームを有効にするなら CCVolume
                if (ChannelConfigState.EnableCCVolume && ChannelConfigState.CCVolumeToVolume)
                {
                    // コントロールチェンジを取得
                    CCvoCCex = getControlChange(currentMeasure, currentTick, 7);
                }
                // ノートオン以外のボリュームを有効にするなら CCExpression
                else if (ChannelConfigState.EnableCCVolume && ChannelConfigState.CCExpressionToVolume)
                {
                    // コントロールチェンジを取得
                    CCvoCCex = getControlChange(currentMeasure, currentTick, 11);
                }


                string outputVolume;
                // ノートオンがある ノートボリューム有効 CCボリューム無効
                if (noteON.EventID != 0 && ChannelConfigState.EnableNoteVolume && !ChannelConfigState.EnableCCVolume)
                {
                    noteVolume = (byte)Math.Round(noteON.Value / (127f / 15f));
                    outputVolume = noteVolume.ToString("X1");
                }
                // ノートボリューム有効 CCボリューム有効
                else if (ChannelConfigState.EnableNoteVolume && ChannelConfigState.EnableCCVolume)
                {
                    // ノートオンがある
                    if (noteON.EventID == 0x90)
                    {
                        noteVolume = (byte)Math.Round(noteON.Value / (127f / 15f));
                        outputVolume = noteVolume.ToString("X1");
                    }
                    // ノートオンがない
                    else
                    {
                        outputVolume = ".";
                    }

                    // CCVolumeかCCExpressionを取得していれば、直前のノートオンの音量から割り引く
                    if (CCvoCCex.EventID == 0xB0)
                    {
                        ccVolume = (byte)CCvoCCex.Value;
                        outputVolume = Math.Round(CCvoCCex.Value / (127f / (float)noteVolume)).ToString("X1");
                    }
                }
                // ノートボリューム無効 CCボリューム有効
                else if (!ChannelConfigState.EnableNoteVolume && ChannelConfigState.EnableCCVolume)
                {
                    // CCVolumeかCCExpressionを取得していれば
                    if (CCvoCCex.EventID == 0xB0)
                    {
                        outputVolume = Math.Round(CCvoCCex.Value / (127f / 15f)).ToString("X1");
                    }
                    // 取得していなければ
                    else
                    {
                        outputVolume = ".";
                    }
                }
                else
                {
                    outputVolume = ".";
                }
                
                // 音量出力
                outputRowText += outputVolume + " ";

                // エフェクト情報
                if (false)
                {

                }
                else
                {
                    outputRowText += "...";
                }

                // 行に書き出し
                _trackerList.Items[i].SubItems[outputChannel].Text = outputRowText;

                // 次の音価へ
                currentTick += (int)BasicConfigState.TicksPerLine;
            }

            // 再描画
            _trackerList.EndUpdate();
        }


        private string getRowDataNote()
        {
            // 現在の行の対象のノートオンイベントを取得
            EventData noteON = getNote(currentMeasure, currentTick);



            return "... .. . ...";
        }
        
        
    }
}
