using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI2FTM
{
    /// <summary>
    /// チャンネル設定の状態 
    /// </summary>----------------------------------------------------------------------------------------------------
    public static class ChannelConfigState
    {
        /// <summary>ノートオンのボリュームを有効</summary>
        public static bool EnableNoteVolume = false;
        /// <summary>連符をGxxで表現する</summary>
        public static bool EnableEffectGxx = false;
        /// <summary>PitchBendをPxxで表現する</summary>
        public static bool EnableEffectPxx = false;
        /// <summary>CCModulationを4xxで表現する</summary>
        public static bool EnableEffect4xx = false;
        /// <summary>ノート以外のボリュームを有効</summary>
        public static bool EnableCCVolume = false;
        /// <summary>ノート以外のボリュームを有効 → CCVolumeを適用</summary>
        public static bool CCVolumeToVolume = true;
        /// <summary>ノート以外のボリュームを有効 → CCExpressionを適用</summary>
        public static bool CCExpressionToVolume = false;
        /// <summary>一番高い音を優先</summary>
        public static bool HighNotePriority = true;
        /// <summary>一番低い音を優先</summary>
        public static bool LowNotePriority = false;
        /// <summary>同一Rowで先のノートを優先</summary>
        public static bool LeadNotePriority = true;
        /// <summary>同一Rowで後のノートを優先</summary>
        public static bool BehindNotePriority = false;
        /// <summary>音色番号</summary>
        public static byte InstrumentNum = 0;
    }
}
