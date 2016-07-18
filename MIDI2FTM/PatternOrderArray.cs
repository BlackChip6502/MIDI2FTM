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

        /// <summary>
        /// オーダーを初期化
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_frameCount">フレーム数</param>
        /// <param name="_trackerChannelCount">チャンネル数</param>
        public static void Initialize(int _frameCount, int _trackerChannelCount)
        {
            Order = new int[_frameCount, _trackerChannelCount];
        }

        /// <summary>
        /// オーダーに引数のチャンネルの連番を入れる
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerChannelNum">トラッカーのチャンネル</param>
        public static void serialNumbers(int _trackerChannelNum)
        {
            for (int i = 0; i < Order.GetLength(0); i++)
            {
                // PATTERN 00 を使わない場合
                if (BasicConfigState.DisablePatternZero)
                {
                    Order[i, _trackerChannelNum] = i + 1;
                }
                else
                {
                    Order[i, _trackerChannelNum] = i;
                }
            }
        }

        /// <summary>
        /// チャンネルのオーダーをすべて0で埋める
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerChannelNum">トラッカーのチャンネル</param>
        public static void resetChannnelNum(int _trackerChannelNum)
        {
            for (int i = 0; i < Order.GetLength(0); i++)
            {
                Order[i, _trackerChannelNum] = 0;
            }
        }
    }
}
