using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI2FTM
{
    /// <summary>
    /// 基本設定の状態 
    /// </summary>----------------------------------------------------------------------------------------------------
    public static class BasicConfigState
    {
        /// <summary>
        /// 拍子の変化でFrameを移行する
        /// </summary>
        public static bool ChangedFrame = true;
        /// <summary>
        /// PATTERN00を使用しない
        /// </summary>
        public static bool DisablePatternZero = true;
        /// <summary>
        /// 未使用ChのOrderを00で埋める
        /// </summary>
        public static bool UnusedChannelOrderZeroFill = true;
        /// <summary>
        /// 最小音価のコンボボックス上でのインデックス
        /// </summary>
        public static int MinNoteIndex = 4;
        /// <summary>
        /// 最小音価
        /// </summary>
        public static int MinNote
        {
            get { return (int)Math.Pow(2, MinNoteIndex); }      
        }
        /// <summary>
        /// 1ライン(Row)中のTick数
        /// </summary>
        public static float TicksPerLine
        {
            get { return SMFHeader.Data.Division / ((float)MinNote / 4); }
        }
        /// <summary>
        /// Tracker上でのSpeed
        /// </summary>
        public static byte Speed = 6;
        /// <summary>
        /// 1ライン(Row)をSpeedで割った値、エフェクトGで表現できる最小単位
        /// </summary>
        public static float MinTick
        {
            get { return TicksPerLine / Speed; }
        }
        /// <summary>
        /// 1Frameの小節数
        /// </summary>
        public static byte OneFrameMeasureCount = 4;
        /// <summary>
        /// 最初小節
        /// </summary>
        public static int StartMeasure = 2;
        /// <summary>
        /// 最大拍子 分子
        /// </summary>
        public static byte MaxTimeSignatureNumer = 4;
        /// <summary>
        /// 最大拍子 分母
        /// </summary>
        public static byte MaxTimeSignatureDenom = 4;
        /// <summary>
        /// 最大Rows
        /// </summary>
        public static short MaxRows = 64;
        /// <summary>
        /// 最後の小節番号
        /// </summary>
        public static uint MaxMeasure = 0;
        /// <summary>
        /// 拡張音源 
        /// </summary>
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
        /// <summary>
        /// Namco163のチャンネル数
        /// </summary>
        public static byte Namco163channelCount = 1;
    }
}
