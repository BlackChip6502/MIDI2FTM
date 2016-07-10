using System;
using System.Collections.Generic;

namespace MIDI2FTM
{
    /// <summary>
    /// SMFヘッダー情報
    /// </summary>----------------------------------------------------------------------------------------------------
    public static class SMFHeader
    {
        /// <summary>
        /// ヘッダー情報
        /// </summary>
        public static Data Data;
    }
    /// <summary>
    /// SMFヘッダー情報構造体
    /// </summary>
    public struct Data
    {
        /// <summary>
        /// トラック数
        /// </summary>
        public ushort Tracks;
        /// <summary>
        /// 分解能 （四分音符の長さ）
        /// </summary>
        public ushort Division;
    }
    
    /// <summary>
    /// SMFのデータ
    /// </summary>
    public static class SMFData
    {
        /// <summary>
        /// トラック配列
        /// </summary>
        public static List<Tracks> Tracks;
        /// <summary>
        /// トラック名
        /// </summary>
        public static List<string> Name;
    }
    /// <summary>
    /// トラックデータ
    /// </summary>
    public class Tracks
    {
        /// <summary>
        /// イベントデータ
        /// </summary>
        public List<EventData> Event;
    }
    /// <summary>
    /// SMFイベントデータ構造体
    /// </summary>
    public struct EventData : IComparable<EventData>
    {
        /// <summary>
        /// イベントID
        /// <para>0x8n ノートオフ 128 ～ 143</para>
        /// <para>0x9n ノートオン 144 ～ 159</para>
        /// <para>0xBn コントロールチェンジ 176 ～ 191</para>
        /// <para>0xEn ピッチベンド 224 ～ 239</para>
        /// <para>0xFF メタイベント 255</para>
        /// </summary>
        public byte EventID;
        /// <summary>
        /// 直前のイベントから待つ時間
        /// </summary>
        public uint DeltaTime;
        /// <summary>
        /// 小節番号
        /// </summary>
        public uint Measure;
        /// <summary>
        /// 小節の頭からの時間
        /// </summary>
        public uint Tick;
        /// <summary>
        /// ノートの長さ
        /// <para>ノートオン以外では未使用</para>
        /// </summary>
        public uint Gate;
        /// <summary>
        /// ノートオンは NoteNumber.NumberToNoteName(byte _value) で音階名に変換で使用する
        /// <para>1  コントロールチェンジ Modulation</para>
        /// <para>7  コントロールチェンジ Volume</para>
        /// <para>11 コントロールチェンジ Expression</para>
        /// <para>47 メタイベント End of Track</para>
        /// <para>81 メタイベント Tempo</para>
        /// <para>88 メタイベント Time Signature</para>
        /// <para>ピッチベンドでは未使用</para>
        /// </summary>
        public byte Number;
        /// <summary>
        /// <para>ノートオン 0 ～ 127</para>
        /// <para>コントロールチェンジ 0 ～ 127</para>
        /// <para>テンポ 3.5762789 ～ 60,000,000 (6.205815 ～ 512.0022) 正確な使用可能範囲は不明</para>
        /// <para>拍子 分母</para>
        /// <para>ピッチベンド -8192 ～ 8191</para>
        /// </summary>
        public float Value;
        /// <summary>
        /// 拍子 分子
        /// <para>他のイベントでは未使用</para>
        /// </summary>
        public float Value2;
        /// <summary>
        /// メタイベントでのテキスト等
        /// </summary>
        public string Text;
        /// <summary>
        /// ソートするために必要なやつ
        /// </summary>
        /// <param name="e">よくわかってないやつ</param>
        /// <returns>よくわかってないやつ</returns>
        public int CompareTo(EventData e)
        {
            return Number - e.Number;
        }
    }
}
