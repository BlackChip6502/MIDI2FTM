using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    class AddFinalizeFxxEffect : ConvertCommon
    {
        /// <summary>フレーム内の小節数</summary>
        private int m_frameInMeasure;
        /// <summary>最初の小節の長さを取得</summary>
        private int m_oneMeasureTick;
        /// <summary>フレーム移行フラグ</summary>
        private bool m_nextFrame;
        /// <summary>Fxxを追加したか</summary>
        private bool m_addedFxxEffect;

        /// <summary>
        /// コンストラクタ♪  コンバートするときは必ず引数を渡してください
        /// </summary>----------------------------------------------------------------------------------------------------
        public AddFinalizeFxxEffect(int _outputChannel)
        {
            // ConvertCommonのメンバーに代入
            m_OutputChannel = _outputChannel;

            // メンバー変数を初期化
            m_frameInMeasure = 1;
            m_CurrentMeasure = BasicConfigState.StartMeasure;
            m_CurrentTick = 0;
            m_oneMeasureTick = getMeasureLength(m_CurrentMeasure);
            m_nextFrame = false;
        }

        /// <summary>
        /// コンバートの開始
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerList">リストビューのトラッカーリスト</param>
        /// <param name="_progressBar">ステータスバーのプログレスバー</param>
        public void StartConvert(ref string[,] _trackerList, ref ToolStripProgressBar _progressBar)
        {
            // プログレスバーを初期化
            _progressBar.Maximum = _trackerList.GetLength(0);
            _progressBar.Value = 0;

            for (int i = 0; i < _trackerList.GetLength(0); i++)
            {
                // プログレスバーにインクリメントする
                _progressBar.PerformStep();

                // 小節を跨いだら
                if (m_CurrentTick >= m_oneMeasureTick)
                {
                    // 小節をすすめる
                    m_CurrentMeasure++;
                    // 小節の頭にする
                    m_CurrentTick = 0;
                    // 次の小節へ
                    m_frameInMeasure++;
                    // 次の小節の長さを取得
                    int tmp = getMeasureLength(m_CurrentMeasure);
                    // 拍子の変化でフレームを移行する場合
                    if (BasicConfigState.ChangedFrame && m_oneMeasureTick != tmp)
                    {
                        m_frameInMeasure = 1;
                        m_nextFrame = true;
                    }
                    m_oneMeasureTick = tmp;
                }

                // フレームを移行する
                if (m_frameInMeasure > BasicConfigState.OneFrameMeasureCount)
                {
                    m_frameInMeasure = 1;
                    m_nextFrame = true;
                }

                // データ行以外はなにもしない PATTERN名行の次は必ずフレームの最初だからフラグを折る
                if (_trackerList[i, m_OutputChannel].Contains("PATTERN") || _trackerList[i, m_OutputChannel] == "")
                {
                    m_nextFrame = false;
                    continue;
                }

                // フレーム移行中はなにもしない
                if (m_nextFrame)
                {
                    continue;
                }

                // 行に書き出し
                _trackerList[i, m_OutputChannel] += getRowData();

                // 次の音価へ
                m_CurrentTick += (int)BasicConfigState.TicksPerLine;
            }

            // とりあえずデータの文字数を取得しておく
            System.Globalization.StringInfo si = new System.Globalization.StringInfo(_trackerList[1, m_OutputChannel]);
            int dataStringLength = si.LengthInTextElements;

            for (int i = 0; i < _trackerList.GetLength(0); i++)
            {
                // データ行以外はなにもしない
                if (_trackerList[i, m_OutputChannel].Contains("PATTERN") || _trackerList[i, m_OutputChannel] == "")
                {
                    continue;
                }

                // 余計なエフェクト列を削除する
                if (!m_addedFxxEffect)
                {
                    _trackerList[i, m_OutputChannel] = _trackerList[i, m_OutputChannel].Substring(0, dataStringLength - 4);
                }
            }

            // オーダーに連番を入れる
            PatternOrderRewriting por = new PatternOrderRewriting();
            por.serialNumbers(m_OutputChannel - 1);
        }

        /// <summary>
        /// 行のデータを文字列で取得する
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <returns>行のデータ文字列</returns>
        private string getRowData()
        {
            // 行に書き出し用変数を用意
            string outputRowText = null;

            // テンポチェンジを取得
            EventData tempoChange = getCurrentRangeMetaEvents(0x51);

            // テンポチェンジを取得していたら
            if (tempoChange.Number == 0x51)
            {
                // 計算する todo

                return " Fxx";
            }

            return " ...";
        }
    }
}
