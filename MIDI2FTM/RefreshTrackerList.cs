using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// トラッカーリスト（リストビュー）を初期化するクラス
    /// </summary>----------------------------------------------------------------------------------------------------
    class RefreshTrackerList
    {
        /// <summary>
        /// コンストラクタ♪
        /// </summary>----------------------------------------------------------------------------------------------------
        public RefreshTrackerList()
        {

        }

        /// <summary>
        /// トラッカーリストを初期化する
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerList">トラッカーリスト</param>
        public void InitializeList(ref ListView _trackerList)
        {
            // 列の数を取得
            int columnsCount = _trackerList.Columns.Count;

            // 処理中は描画しない
            _trackerList.BeginUpdate();
            // 拡張音源が追加されている場合
            if (columnsCount > 6)
            {
                // 拡張音源を削除
                for (int i = 6; i < columnsCount; i++)
                {
                    _trackerList.Columns.RemoveAt(6);
                }
            }
            // 再描画
            _trackerList.EndUpdate();
        }

        /// <summary>
        /// トラッカーリストに拡張音源の列を追加する
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerList">トラッカーリスト</param>
        public void AddExpansionSoundColumns(ref ListView _trackerList)
        {
            // 処理中は描画しない
            _trackerList.BeginUpdate();
            // 拡張音源の追加
            switch (BasicConfigState.ExpansionSoundIndex)
            {
                case BasicConfigState.ExpansionSound.NESchannelsOnly:
                    break;
                case BasicConfigState.ExpansionSound.KonamiVRC6:
                    _trackerList.Columns.Add("VRC6 Pulse 1");
                    _trackerList.Columns.Add("VRC6 Pulse 2");
                    _trackerList.Columns.Add("VRC6 Sawtooth");
                    break;
                case BasicConfigState.ExpansionSound.KonamiVRC7:
                    _trackerList.Columns.Add("VRC7 FM 1");
                    _trackerList.Columns.Add("VRC7 FM 2");
                    _trackerList.Columns.Add("VRC7 FM 3");
                    _trackerList.Columns.Add("VRC7 FM 4");
                    _trackerList.Columns.Add("VRC7 FM 5");
                    _trackerList.Columns.Add("VRC7 FM 6");
                    break;
                case BasicConfigState.ExpansionSound.NintendoFDSsound:
                    _trackerList.Columns.Add("FDS");
                    break;
                case BasicConfigState.ExpansionSound.NintendoMMC5:
                    _trackerList.Columns.Add("MMC5 Pulse 1");
                    _trackerList.Columns.Add("MMC5 Pulse 2");
                    break;
                case BasicConfigState.ExpansionSound.Namco163:
                    for (int i = 1; i <= BasicConfigState.Namco163channelCount; i++)
                    {
                        _trackerList.Columns.Add("Namco " + i);
                    }
                    break;
            }
            // 再描画
            _trackerList.EndUpdate();
        }
    }
}
