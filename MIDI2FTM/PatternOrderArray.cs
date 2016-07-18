using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDI2FTM
{
    /// <summary>
    /// パターンオーダー配列
    /// </summary>----------------------------------------------------------------------------------------------------
    public static class PatternOrderArray
    {
        /// <summary>オーダーの2次元配列</summary>
        public static int[,] Order;
    }

    /// <summary>
    /// パターンオーダー配列を書き換える
    /// </summary>
    public class PatternOrderRewriting
    {
        /// <summary>
        /// オーダーを初期化
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_frameCount">フレーム数</param>
        /// <param name="_trackerChannelCount">チャンネル数</param>
        public void Initialize(int _frameCount, int _trackerChannelCount)
        {
            PatternOrderArray.Order = new int[_frameCount, _trackerChannelCount];
        }

        /// <summary>
        /// オーダーに引数のチャンネルの連番を入れる
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerChannelNum">トラッカーのチャンネル</param>
        public void serialNumbers(int _trackerChannelNum)
        {
            for (int i = 0; i < PatternOrderArray.Order.GetLength(0); i++)
            {
                // PATTERN 00 を使わない場合
                if (BasicConfigState.DisablePatternZero)
                {
                    PatternOrderArray.Order[i, _trackerChannelNum] = i + 1;
                }
                else
                {
                    PatternOrderArray.Order[i, _trackerChannelNum] = i;
                }
            }
        }

        /// <summary>
        /// チャンネルのオーダーをすべて0で埋める
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerChannelNum">トラッカーのチャンネル</param>
        public void resetChannnelNum(int _trackerChannelNum)
        {
            for (int i = 0; i < PatternOrderArray.Order.GetLength(0); i++)
            {
                PatternOrderArray.Order[i, _trackerChannelNum] = 0;
            }
        }
    }
}
