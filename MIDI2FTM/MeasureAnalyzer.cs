using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI2FTM
{
    /// <summary>
    /// 拍子イベントを探しDeltaTimeから小節数を算出するクラス
    /// </summary>----------------------------------------------------------------------------------------------------
    public class MeasureAnalyzer
    {
        /// <summary>
        /// コンストラクタ♪
        /// </summary>----------------------------------------------------------------------------------------------------
        public MeasureAnalyzer()
        {
            
        }
        
        /// <summary>
        /// 拍子イベントを探しDeltaTimeから小節数を算出する
        /// </summary>----------------------------------------------------------------------------------------------------
        public void Analyzing()
        {
            // トラックをループ
            for (int i = 0; i < SMFData.Tracks.Count; i++)
            {
                ulong totalDeltaTime = 0;       // 累計デルタタム
                // iトラック目をループ
                for (int j = 0; j < SMFData.Tracks[i].Event.Count; j++)
                {
                    // 解析対象イベントのデルタタイムを加算
                    totalDeltaTime += SMFData.Tracks[i].Event[j].DeltaTime;

                    // 初期の1小節の長さを算出 4/4
                    int measureLength = (4 / 4) * SMFHeader.Data.Division * 4;

                    uint measure = 1;                        // 小節数
                    ulong tick = 0;                          // 小節の頭からのデルタタイム
                    ulong tmpTotalTime = totalDeltaTime;     // 解析対象イベントのデルタタイム
                    ulong currentDeltaTime = 0;              // 0トラックのループ内現在のデルタタイム
                    
                    // トラック目をループ 小節の長さの読み取り
                    foreach (EventData e0 in SMFData.Tracks[0].Event)
                    {
                        // 0トラックのループ内の現在のデルタタイムを加算
                        currentDeltaTime += e0.DeltaTime;

                        // 1小節目の最初にTime Signatureがあれば
                        if (e0.EventID == 0xFF && e0.Number == 0x58 && currentDeltaTime == 0)
                        {
                            // 1小節の長さを更新
                            measureLength = (int)((4 / e0.Value) * SMFHeader.Data.Division * e0.Value2);
                        }
                        // トラックの終わりなら
                        else if (e0.EventID == 0xFF && e0.Number == 0x2F)
                        {
                            // 進んだ小節数を計算
                            uint tmp = (uint)Math.Floor(tmpTotalTime / (decimal)measureLength);

                            // 進んだ小節数を加算
                            measure += tmp;

                            // 残りの時間を計算
                            tick = (uint)(tmpTotalTime - (tmp * (ulong)measureLength));

                            break;
                        }
                        // Time Signatureを探す 小節の頭に必ずあることが前提（おそらくすべてのシーケンサで作られたデータはそうなっているはず）
                        else if (e0.EventID == 0xFF && e0.Number == 0x58)
                        {


                            // 解析対象のイベントの時間がこのTime Signatureよりも先の時間なら
                            if (tmpTotalTime > currentDeltaTime)
                            {
                                // 進んだ小節数を計算
                                uint tmp = (uint)Math.Floor(currentDeltaTime / (decimal)measureLength);

                                // 進んだ小節数を加算
                                measure += tmp;

                                // 0トラックのループ内現在のデルタタイムをリセット 次の拍子に備える
                                tmpTotalTime -= currentDeltaTime;
                                currentDeltaTime = 0;

                            }
                            else
                            {
                                // 進んだ小節数を計算
                                uint tmp = (uint)Math.Floor(tmpTotalTime / (decimal)measureLength);

                                // 進んだ小節数を加算
                                measure += tmp;

                                // 累計デルタタイムの余りを計算
                                tick = (tmpTotalTime % (ulong)measureLength);

                                break;
                            }

                            // 1小節の長さを更新
                            measureLength = (int)((4 / e0.Value) * SMFHeader.Data.Division * e0.Value2);
                        }
                    }
                    // 解析した Measure Tick を代入
                    EventData e = SMFData.Tracks[i].Event[j];
                    e.Measure = measure;
                    e.Tick = (uint)tick;
                    SMFData.Tracks[i].Event[j] = e;
                }
            }
        }
    }
}
