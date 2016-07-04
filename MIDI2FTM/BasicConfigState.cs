/*****************************************************************************************************
 基本設定の状態を保持するクラス
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI2FTM
{
    //----------------------------------------------------------------------------------------------------
    // 基本設定の状態
    //----------------------------------------------------------------------------------------------------
    public static class BasicConfigState
    {
        public static bool ChangedFrame = true;                 // 拍子の変化でFrameを移行する
        public static bool EnableEffectG = true;                // 連符をGxxで表現する
        public static bool DisablePatternZero = true;           // PATTERN00を使用しない
        public static bool UnusedChannelOrderZeroFill = true;   // 未使用ChのOrderを00で埋める
        public static int MinNoteIndex = 4;                     // 最小音価のコンボボックス上でのインデックス
        public static int MinNote                               // 最小音価
        {
            get { return (int)Math.Pow(2, MinNoteIndex); }      
        }
        public static float MinTick                             // 最小Tick
        {
            get { return SMFHeader.Data.Division / ((float)MinNote / 4); }
        }
        public static byte Speed = 6;                           // Speed
        public static byte OneFrameMeasureCount = 4;            // 1Frameの小節数
        public static int StartMeasure = 2;                     // 最初小節
        public static byte MaxTimeSignatureNumer = 4;           // 最大拍子 分子
        public static byte MaxTimeSignatureDenom = 4;           // 最大拍子 分母
        public static short MaxRows = 64;                       // 最大Rows
        public static uint MaxMeasure = 0;                      // 最後の小節番号
        
        // 拡張音源
        public enum ExpansionSound
        {
            NESchannelsOnly,
            KonamiVRC6,
            KonamiVRC7,
            NintendoFDSsound,
            NintendoMMC5,
            Namco163,
        }
        public static ExpansionSound ExpansionSoundIndex = ExpansionSound.NESchannelsOnly;
        public static byte Namco163channelCount = 1;
    }
}
