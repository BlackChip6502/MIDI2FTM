/*****************************************************************************************************
 解析したSMFを詰め込んだ配列
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI2FTM
{
    //----------------------------------------------------------------------------------------------------
    // SMFヘッダー情報
    //----------------------------------------------------------------------------------------------------
    public static class SMFHeader
    {
        public static Data Data;
    }
    public struct Data
    {
        public ushort Tracks;          // トラック数
        public ushort Division;        // 分解能 （四分音符の長さ）
    }

    //----------------------------------------------------------------------------------------------------
    // トラックのイベントとその値
    //      
    //      EventID         0x8n ノートオフ            128 ～ 143
    //                      0x9n ノートオン            144 ～ 159
    //                      0xBn コントロールチェンジ  176 ～ 191
    //                      0xEn ピッチベンド          224 ～ 239
    //                      0xFF メタイベント          255
    //
    //      Measure         小節番号
    //
    //      Tick            小節の頭からの時間
    //      
    //      DeltaTime       直前のイベントから待つ時間
    //      
    //      Gate            ノートオフから遡り直近の同一ノートのノートオンまでのデルタタイムの差分
    //                      ノートオン以外は未使用
    //                         
    //      Number          ノートオンは NoteNumber.NumberToNoteName(byte _value) で音階名に変換で使用する
    //                      1  コントロールチェンジ Modulation
    //                      7  コントロールチェンジ Volume
    //                      11 コントロールチェンジ Expression
    //                      47 メタイベント         End of Track
    //                      81 メタイベント         Tempo
    //                      88 メタイベント         Time Signature
    //                      ピッチベンドでは未使用
    //                      
    //      Value           ノートオン           0 ～ 127
    //                      コントロールチェンジ 0 ～ 127
    //                      テンポ               3.5762789 ～ 60,000,000 (6.205815 ～ 512.0022) 正確な使用可能範囲は不明
    //                      拍子                 分母
    //                      ピッチベンド         -8192 ～ 8191
    //
    //      Value2          拍子                 分子
    //
    //      Text            汎用文字列
    //----------------------------------------------------------------------------------------------------
    public static class SMFData
    {
        public static List<Tracks> Tracks;
        public static List<string> Name;
    }
    public class Tracks
    {
        public List<EventData> Event;
    }
    public struct EventData
    {
        public byte EventID;        // イベントID
        public uint DeltaTime;      // 待ち時間
        public uint Measure;        // 小節数
        public uint Tick;           // 小節の頭からのデルタタイム
        public uint Gate;           // ノートの長さ
        public byte Number;         // ノートナンバー / コントロールチェンジ番号
        public float Value;         // ノートのベロシティ / コントロールの値 / ピッチベンドの値 / 拍子 分母
        public float Value2;        // 拍子 分子
        public string Text;         // メタイベントでのテキスト等
    }
}
