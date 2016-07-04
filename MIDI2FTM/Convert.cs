/*****************************************************************************************************
 SMFのトラックをSMFのトラックにコンバートする
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    public class Convert
    {
        //----------------------------------------------------------------------------------------------------
        // コンストラクタ♪
        //----------------------------------------------------------------------------------------------------
        public Convert()
        {

        }

        //----------------------------------------------------------------------------------------------------
        // 基本コンバート
        //----------------------------------------------------------------------------------------------------
        public void TestConvert(ref ListView _trackerList, int _inputTrackNum, int _outputChannel)
        {
            // フレーム内の小節数
            int frameInMeasure = 1;
            // 現在の小節
            int currentMeasure = 1;
            // 現在のTick
            int currentTick = 0;
            // 最初の小節の長さを取得
            int oneMeasureTick = measureLength(currentMeasure);
            // フレーム以降フラグ
            bool nextFrame = false;

            foreach (ListViewItem lvi in _trackerList.Items)
            {
                // 小節を跨いだら
                if (currentTick >= oneMeasureTick)
                {
                    // 小節をすすめる
                    currentMeasure++;
                    // 小節の頭にする
                    currentTick = 0;
                    // 次の小節へ
                    frameInMeasure++;
                }

                // フレームを以降する
                if (frameInMeasure > BasicConfigState.OneFrameMeasureCount)
                {
                    frameInMeasure = 1;
                    nextFrame = true;
                }

                // データ行以外はなにもしない
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
                
                // テスト
                lvi.SubItems[_outputChannel].Text = currentMeasure + "小節 : " + currentTick + "Tick";

                // 次の音価へ
                currentTick += (int)BasicConfigState.MinTick;
            }
            
        }

        //----------------------------------------------------------------------------------------------------
        // トラッカーリストを初期化
        //----------------------------------------------------------------------------------------------------
        public void InitializationTrackerList(ref ListView _trackerList)
        {
            // フレーム内の小節数
            int frameInMeasure = 0;
            // 最初の小節の長さを取得
            int oneMeasureTick = measureLength(1);
            // 現在のフレーム番号
            int currentFrameNum = 0;
            if (BasicConfigState.DisablePatternZero)
            {
                currentFrameNum = 1;
            }

            // 最大小節の数だけループする
            for (int i = 1; i <= BasicConfigState.MaxMeasure; i++)
            {
                // 拍子の変化でフレームを移行するフラグが立っていて、直前の小節の長さ（拍子）と現在の小節の長さが違ったら
                if (BasicConfigState.ChangedFrame && oneMeasureTick != measureLength(i))
                {
                    // 現在の小節の長さを取得
                    oneMeasureTick = measureLength(i);
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
                    // 文字を白色にする
                    _trackerList.Items[_trackerList.Items.Count - 1].ForeColor = System.Drawing.Color.White;

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

                        // 4の倍数なら
                        if (j % 4 == 0)
                        {
                            // 文字を黄色にする
                            _trackerList.Items[_trackerList.Items.Count - 1].ForeColor = System.Drawing.Color.Yellow;
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
        }

        //----------------------------------------------------------------------------------------------------
        // 小節の拍子変化を見つけて現在の小節のTick数を返す
        //----------------------------------------------------------------------------------------------------
        private int measureLength(int _currentMeasure)
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
