using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// SMFのトラックをトラッカーのチャンネルにコンバートする
    /// </summary>----------------------------------------------------------------------------------------------------
    public class Convert : ConvertCommon
    {
        /// <summary>フレーム内の小節数</summary>
        private int m_frameInMeasure;
        /// <summary>最初の小節の長さを取得</summary>
        private int m_oneMeasureTick;
        /// <summary>フレーム移行フラグ</summary>
        private bool m_nextFrame;
        
        /// <summary>
        /// コンストラクタ♪  コンバートするときは必ず引数を渡してください
        /// </summary>----------------------------------------------------------------------------------------------------
        public Convert(int _inputTrackNum, int _outputChannel)
        {
            // ConvertCommonのメンバーに代入
            m_InputTrackNum = _inputTrackNum;
            m_OutputChannel = _outputChannel;

            // メンバー変数を初期化
            m_frameInMeasure = 1;
            m_CurrentMeasure = BasicConfigState.StartMeasure;
            m_CurrentTick = 0;
            m_oneMeasureTick = getMeasureLength(m_CurrentMeasure);
            m_nextFrame = false;
            m_BeforeVolume = 0xF;
            m_NoteVolume = 127;
            m_CCVolume = getStartCCVolume(BasicConfigState.StartMeasure);
        }
        
        /// <summary>
        /// コンバートの開始
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_trackerList">リストビューのトラッカーリスト</param>
        /// <param name="_progressBar">ステータスバーのプログレスバー</param>
        public void StartConvert(ref ListView _trackerList, ref ToolStripProgressBar _progressBar)
        {
            // 処理中は描画しない
            _trackerList.BeginUpdate();

            // プログレスバーを初期化
            _progressBar.Maximum = _trackerList.Items.Count;
            _progressBar.Value = 0;

            foreach (ListViewItem lvi in _trackerList.Items)
            {
                // データ行以外はなにもしない
                if (lvi.Text.Contains("PATTERN") || lvi.Text == "")
                {
                    continue;
                }
                // 初期化
                lvi.SubItems[m_OutputChannel].Text = "... .. . ... ... ...";
            }

            foreach (ListViewItem lvi in _trackerList.Items)
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
                if (lvi.Text.Contains("PATTERN") || lvi.Text == "")
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
                lvi.SubItems[m_OutputChannel].Text = getRowData();

                // 次の音価へ
                m_CurrentTick += (int)BasicConfigState.TicksPerLine;
            }
            
            foreach (ListViewItem lvi in _trackerList.Items)
            {
                // データ行以外はなにもしない
                if (lvi.Text.Contains("PATTERN") || lvi.Text == "")
                {
                    continue;
                }

                // 余計なエフェクト列を削除する
                switch (m_EffectCount)
                {
                    case 3:
                        break;
                    case 2:
                        lvi.SubItems[m_OutputChannel].Text = lvi.SubItems[m_OutputChannel].Text.Substring(0, 16); 
                        break;
                    default:
                        lvi.SubItems[m_OutputChannel].Text = lvi.SubItems[m_OutputChannel].Text.Substring(0, 12);
                        break;
                }
            }

            // カラムヘッダの自動調整
            foreach (ColumnHeader ch in _trackerList.Columns)
            {
                ch.Width = -2;
            }

            // 再描画
            _trackerList.EndUpdate();
        }

        /// <summary>
        /// 行のデータを文字列で取得する
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <returns>行のデータ文字列</returns>
        private string getRowData()
        {
            // 行に書き出し用変数を用意
            string outputRowText = null;
            
            EventData noteOnEvent = new EventData();

            // 現在の行の対象のノートオンイベントを取得
            if (ChannelConfigState.EnableEffectGxx)
            {
                noteOnEvent = getCurrentRangeNote();
            }
            else
            {
                noteOnEvent = getCurrentNote();
            }

            // 有効にする音量情報を取得する
            EventData ccVolumeEvent = getCurrentCCVolume();

            // ノートオン、音色番号の文字列を追加
            outputRowText = getNote(noteOnEvent);

            // ボリュームの文字列を追加
            outputRowText += getVolume(noteOnEvent, ccVolumeEvent);

            // エフェクトを追加
            outputRowText += addEffects();
            
            return outputRowText;
        }
    }
}
