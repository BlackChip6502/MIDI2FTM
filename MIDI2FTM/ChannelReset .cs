using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// トラッカーリストのチャンネルをリセットする
    /// </summary>----------------------------------------------------------------------------------------------------
    public class ChannelReset
    {
        /// <summary>
        /// トラッカーリストのチャンネルをリセットする
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerList">トラッカーリスト</param>
        /// <param name="_ChannelNum">チャンネル番号</param>
        public ChannelReset(ref ListView _trackerList, int _ChannelNum)
        {
            // 処理中は描画しない
            _trackerList.BeginUpdate();
            foreach (ListViewItem lvi in _trackerList.Items)
            {
                // データ行以外はなにもしない
                if (lvi.Text.Contains("PATTERN") || lvi.Text == "")
                {
                    continue;
                }

                // データなしの状態にする
                lvi.SubItems[_ChannelNum].Text = "... .. . ...";
            }

            // カラムヘッダの自動調整
            foreach (ColumnHeader ch in _trackerList.Columns)
            {
                ch.Width = -2;
            }

            // 再描画
            _trackerList.EndUpdate();

            // このチャンネルのオーダーを0で埋める
            PatternOrderRewriting por = new PatternOrderRewriting();
            por.resetChannnelNum(_ChannelNum - 1);
        }
    }
}
