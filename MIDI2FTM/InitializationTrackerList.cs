using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// トラッカーリストを初期化
    /// </summary>----------------------------------------------------------------------------------------------------
    class InitializationTrackerList : ConvertCommon
    {
        /// <summary>
        /// コンストラクタ♪ トラッカーリストを初期化
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerList">リストビューのトラッカーリスト</param>
        /// <param name="_progressBar">ステータスバーのプログレスバー</param>
        public InitializationTrackerList(ref ListView _trackerList, ref ToolStripProgressBar _progressBar)
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
            for (int i = 1; i < BasicConfigState.MaxMeasure; i++)
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

            // オーダー配列を確保
            PatternOrderRewriting por = new PatternOrderRewriting();
            por.Initialize(currentFrameNum - 1, _trackerList.Columns.Count - 1);
        }
    }
}
