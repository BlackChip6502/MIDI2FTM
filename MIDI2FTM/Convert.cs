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
    public class Convert
    {
        /// <summary>
        /// コンストラクタ♪ 
        /// </summary>----------------------------------------------------------------------------------------------------
        public Convert()
        {
            
        }

        /// <summary>
        /// 基本コンバート 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerList">リストビューのトラッカーリスト</param>
        /// <param name="_inputTrackNum">入力元のSMFデータのトラック番号</param>
        /// <param name="_outputChannel">出力先のトラッカーのチャンネル</param>
        /// <param name="_progressBar">ステータスバーのプログレスバー</param>
        public void TestConvert(ref ListView _trackerList, int _inputTrackNum, int _outputChannel, ref ToolStripProgressBar _progressBar)
        {
            // フレーム内の小節数
            int frameInMeasure = 1;
            // 現在の小節
            int currentMeasure = BasicConfigState.StartMeasure;
            // 現在のTick
            int currentTick = 0;
            // 最初の小節の長さを取得
            int oneMeasureTick = getMeasureLength(currentMeasure);
            // フレーム以降フラグ
            bool nextFrame = false;

            // プログレスバーを初期化
            _progressBar.Maximum = (int)BasicConfigState.MaxMeasure;
            _progressBar.Value = 0;

            // 処理中は描画しない
            _trackerList.BeginUpdate();
            foreach (ListViewItem lvi in _trackerList.Items)
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
                    // 拍子の変化でフレームを以降する場合
                    if (BasicConfigState.ChangedFrame && oneMeasureTick != tmp)
                    {
                        frameInMeasure = 1;
                        nextFrame = true;
                    }
                    oneMeasureTick = tmp;
                }

                // フレームを以降する
                if (frameInMeasure > BasicConfigState.OneFrameMeasureCount)
                {
                    frameInMeasure = 1;
                    nextFrame = true;
                }

                // データ行以外はなにもしない PATTERN名行の次は必ずフレームの最初だからフラグを折る
                if (lvi .Text.Contains("PATTERN") || lvi.Text == "")
                {
                    nextFrame = false;
                    continue;
                }
                
                // フレーム以降中はなにもしない
                if (nextFrame)
                {
                    continue;
                }

                // 行に書き出し用変数を用意
                string outputRowText = null;

                // 現在の行の対象のノートオンイベントを取得
                EventData e = getNote(currentMeasure, currentTick, _inputTrackNum);

                // ノートオン情報
                if (e.EventID != 0)
                {
                    outputRowText = NoteNumber.NumberToNoteName(e.Number) + " ";
                }
                else
                {
                    outputRowText = "... ";
                }

                // 音色番号情報
                if (e.EventID != 0)
                {
                    outputRowText += ChannelConfigState.InstrumentNum.ToString("X2") + " ";
                }
                else
                {
                    outputRowText += ".. ";
                }

                // ノートオンのボリューム情報
                if (e.EventID != 0 && ChannelConfigState.EnableNoteVolume)
                {
                    byte volume = (byte)Math.Round(e.Value / (127f / 15f));
                    outputRowText += volume.ToString("X1") + " ";
                }
                else
                {
                    outputRowText += ". ";
                }

                // エフェクト情報
                if (false)
                {

                }
                else
                {
                    outputRowText += "...";
                }

                // 行に書き出し
                lvi.SubItems[_outputChannel].Text = outputRowText;

                // 次の音価へ
                currentTick += (int)BasicConfigState.TicksPerLine;
            }

            // 再描画
            _trackerList.EndUpdate();
        }

        /// <summary>
        /// トラッカーリストを初期化
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerList">リストビューのトラッカーリスト</param>
        /// <param name="_progressBar">ステータスバーのプログレスバー</param>
        public void InitializationTrackerList(ref ListView _trackerList, ref ToolStripProgressBar _progressBar)
        {
            // 初期化
            _trackerList.Items.Clear();
            // フレーム内の小節数
            int frameInMeasure = 0;
            // 最初の小節の長さを取得
            int oneMeasureTick = getMeasureLength(1);
            // 現在のフレーム番号
            int currentFrameNum = 0;
            if (BasicConfigState.DisablePatternZero)
            {
                currentFrameNum = 1;
            }

            // プログレスバーを初期化
            _progressBar.Maximum = (int)BasicConfigState.MaxMeasure;
            _progressBar.Value = 0;

            // 処理中は描画しない
            _trackerList.BeginUpdate();
            // 最大小節の数だけループする
            for (int i = 1; i <= BasicConfigState.MaxMeasure; i++)
            {
                // プログレスバーにインクリメントする
                _progressBar.PerformStep();

                // 拍子の変化でフレームを移行するフラグが立っていて、直前の小節の長さ（拍子）と現在の小節の長さが違ったら
                if (BasicConfigState.ChangedFrame && oneMeasureTick != getMeasureLength(i))
                {
                    // 現在の小節の長さを取得
                    oneMeasureTick = getMeasureLength(i);
                    // 次のフレームへ
                    frameInMeasure = 0;
                }

                // フレーム内の小節が最初ならフレームを移行する
                if (frameInMeasure == 0)
                {
                    // フレームを作成
                    string[] data = new string[_trackerList.Columns.Count];

                    // パターン番号の行を追加
                    data[0] = "PATTERN " + currentFrameNum.ToString("X2");
                    for (int d = 1; d < data.Length; d++)
                    {
                        data[d] = "";
                    }
                    // 追加
                    _trackerList.Items.Add(new ListViewItem(data));
                    // 文字に色を付ける
                    _trackerList.Items[_trackerList.Items.Count - 1].ForeColor = System.Drawing.Color.FromArgb(200, 200, 255);

                    // 空のデータを入れる
                    for (int j = 0; j < BasicConfigState.MaxRows; j++)
                    {
                        data[0] = "ROW " + j.ToString("X2");
                        for (int d = 1; d < data.Length; d++)
                        {
                            data[d] = "... .. . ...";
                        }
                        // 追加
                        _trackerList.Items.Add(new ListViewItem(data));

                        // 分母の拍子ごとに色を付ける (Row Highlight)
                        if (j % (BasicConfigState.MinNote / BasicConfigState.MaxTimeSignatureDenom) == 0)
                        {
                            // 文字を薄い黄色にする
                            _trackerList.Items[_trackerList.Items.Count - 1].ForeColor = System.Drawing.Color.FromArgb(200, 200, 0);
                        }

                        // 1小節単位で色を付ける (2nd Highlight)
                        if (j % ((BasicConfigState.MinNote / BasicConfigState.MaxTimeSignatureDenom) * BasicConfigState.MaxTimeSignatureNumer) == 0)
                        {
                            // 文字を黄色にする
                            _trackerList.Items[_trackerList.Items.Count - 1].ForeColor = System.Drawing.Color.FromArgb(255, 255, 0);
                        }
                    }

                    for (int d = 0; d < data.Length; d++)
                    {
                        data[d] = "";
                    }
                    // 空白を追加
                    _trackerList.Items.Add(new ListViewItem(data));

                    // フレーム番号を加算
                    currentFrameNum++;

                    // 1フレーム中の小節数を代入
                    frameInMeasure = BasicConfigState.OneFrameMeasureCount;
                }
                
                frameInMeasure--;
            }

            // カラムヘッダの自動調整
            foreach (ColumnHeader ch in _trackerList.Columns)
            {
                ch.Width = -2;
            }

            // 再描画
            _trackerList.EndUpdate();
        }
        
        /// <summary>
        /// 小節、Tickからノートを見つける 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_currentMeasure">現在の小節番号</param>
        /// <param name="_currentTick">現在のTick数</param>
        /// <param name="_trackNum">入力元のトラック番号</param>
        /// <returns></returns>
        private EventData getNote(int _currentMeasure, int _currentTick, int _trackNum)
        {
            //List<byte> notes = new List<byte>(10);
            List<EventData> notes = new List<EventData>(10);
            
            // 現在の小節数から次の小節の拍子の変化を探す
            foreach (EventData e in SMFData.Tracks[_trackNum].Event)
            {
                // 目的のタイミングのイベントを探す
                if (e.Measure == _currentMeasure && e.Tick == _currentTick )
                {
                    // ボリューム0じゃないノートオンを探す
                    if(e.EventID == 0x90 && e.Gate != 0 && e.Value != 0)
                    {
                        notes.Add(e);
                    }
                }
                // 次の小節に行ってしまったら終わり
                else if(e.Measure > _currentMeasure)
                {
                    // ノートが見つかっていたら
                    if(notes.Count > 0)
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
            EventData returnNote = new EventData();
            return returnNote;
        }

        /// <summary>
        /// 小節の拍子変化を見つけて現在の小節のTick数を返す 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_currentMeasure">現在の小節番号</param>
        /// <returns>小節のTick数</returns>
        private int getMeasureLength(int _currentMeasure)
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
