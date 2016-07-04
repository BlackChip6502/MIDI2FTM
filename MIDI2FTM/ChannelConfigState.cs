/*****************************************************************************************************
 チャンネル設定の状態を保持するクラス
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI2FTM
{
    //----------------------------------------------------------------------------------------------------
    // チャンネル設定の状態
    //----------------------------------------------------------------------------------------------------
    public static class ChannelConfigState
    {
        public static bool EnableNoteVolume = false;        // ノートオンのボリュームを有効

        public static bool EnableNoteOFF = false;           // ノートオフを有効
        public static bool NoteOFFtoVolume = true;         // ボリュームで表現する
        public static bool NoteOFFtoNoteCut = false;        // NoteCutで表現する

        public static bool EnableEffect1and2 = false;       // PitchBendを1xx,2xxxで表現する
        public static bool EnableEffect4and7 = false;       // CCModulationを4xx,7xxで表現する
        public static bool EnableEffectF = false;           // テンポチェンジをFxxで表現する

        public static bool EnableCCVolume = false;          // ノート以外のボリュームを有効
        public static bool CCVolumeToVolume = true;         // CCVolumeを適用
        public static bool CCExpressionToVolume = false;    // CCExpressionを適用

        public static bool HighNotePriority = true;         // 一番高い音を優先
        public static bool LowNotePriority = false;         // 一番低い音を優先

        public static bool LeadNotePriority = true;         // 同一Rowで先のノートを優先
        public static bool BehindNotePriority = false;      // 同一Rowで後のノートを優先

        public static byte InstrumentNum = 0;               // 音色番号
    }
}
