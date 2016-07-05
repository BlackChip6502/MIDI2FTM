using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// イベントリスト（リストビュー）を初期化するクラス
    /// </summary>----------------------------------------------------------------------------------------------------
    public class RefreshEventsList
    {
        /// <summary>
        /// コンストラクタ♪ 
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_eventsList">SMFのイベントリスト</param>
        /// <param name="_trackNum">トラック番号</param>
        public RefreshEventsList(ref ListView _eventsList, int _trackNum)
        {
            _eventsList.Items.Clear();
            string[] data = new string[5];

            // 処理中は描画しない
            _eventsList.BeginUpdate();
            foreach (EventData e in SMFData.Tracks[_trackNum].Event)
            {
                data[0] = e.Measure.ToString();
                data[1] = e.Tick.ToString();

                // ノートオンでもボリュームが0の場合はノートオフ扱い
                if (e.EventID == 0x90 && e.Value == 0)
                {
                    continue;
                }
                // ノートオン
                else if (e.EventID == 0x90)
                {
                    data[2] = NoteNumber.NumberToNoteName(e.Number);
                    data[3] = e.Gate.ToString();
                    data[4] = e.Value.ToString();
                }
                // モジュレーション
                else if (e.EventID == 0xB0 && e.Number == 1)
                {
                    data[2] = "Modulation";
                    data[3] = null;
                    data[4] = e.Value.ToString();
                }
                // ボリューム
                else if (e.EventID == 0xB0 && e.Number == 7)
                {
                    data[2] = "Volume";
                    data[3] = null;
                    data[4] = e.Value.ToString();
                }
                // エクスプレッション
                else if (e.EventID == 0xB0 && e.Number == 11)
                {
                    data[2] = "Expression";
                    data[3] = null;
                    data[4] = e.Value.ToString();
                }
                // ピッチベンド
                else if (e.EventID == 0xE0)
                {
                    data[2] = "Pitch Bend";
                    data[3] = null;
                    data[4] = e.Value.ToString();
                }
                // トラックの終わり
                else if (e.EventID == 0xFF && e.Number == 47)
                {
                    data[2] = "End of Track";
                    data[3] = null;
                    data[4] = null;
                }
                // テンポ
                else if (e.EventID == 0xFF && e.Number == 81)
                {
                    data[2] = "Tempo";
                    data[3] = null;
                    data[4] = e.Value.ToString();
                }
                // 拍子
                else if (e.EventID == 0xFF && e.Number == 88)
                {
                    data[2] = "拍子 : " + e.Value2 + "/" + e.Value;
                    data[3] = null;
                    data[4] = null;
                }
                // 対象外のイベントはスルー
                else
                {
                    continue;
                }
                
                // 追加する
                _eventsList.Items.Add(new ListViewItem(data));
            }

            // 再描画
            _eventsList.EndUpdate();
        }
    }
}
