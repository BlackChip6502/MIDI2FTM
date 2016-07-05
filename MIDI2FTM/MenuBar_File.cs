/*****************************************************************************************************
 メインウィンドウのメニューバー関連のパーシャルクラス
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// メインウィンドウのメニューバー関連のパーシャルクラス
    /// </summary>----------------------------------------------------------------------------------------------------
    public partial class MainWindow : Form
    {
        private void ファイル_新規作成_Click(object sender, EventArgs e)
        {

        }
        private void ファイル_開く_Click(object sender, EventArgs e)
        {

        }
        private void ファイル_上書き保存_Click(object sender, EventArgs e)
        {

        }
        private void ファイル_名前を付けて保存_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// メニューバー"ファイル"のドロップダウンメニューのMIDIインポートをクリックしたとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void ファイル_MIDIインポート_Click(object sender, EventArgs e)
        {
            // ダイアログを開いてファイルをロードする
            LoadMIDIFile lmf = new LoadMIDIFile();
            lmf.GetMIDIFile();

            // ファイルを開いたか
            if (lmf.IsOpen)
            {
                // 開いたファイルを解析
                SMFAnalyzer sa = new SMFAnalyzer();
                // 解析が成功したら
                if (sa.AnalyzingSMF(ref lmf.ByteStream))
                {
                    // Measure Tick を解析
                    MeasureAnalyzer ma = new MeasureAnalyzer();
                    ma.Analyzing();

                    // 読み込み完了のお知らせ
                    // MessageBox.Show("MIDIファイルの読み込みが完了しました。", "おしらせ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // コンボボックスにトラックを追加
                    TrackList.DataSource = SMFData.Name;

                    // 基本設定ウィンドウをモーダルで開く
                    BasicConfigWindow bcw = new BasicConfigWindow();
                    bcw.ShowDialog(this);
                    bcw.Dispose();

                    // 最大小節番号を取得
                    foreach (Tracks t in SMFData.Tracks)
                    {
                        // 最大小節番号の更新があれば
                        if (BasicConfigState.MaxMeasure < t.Event[t.Event.Count - 1].Measure)
                        {
                            BasicConfigState.MaxMeasure = t.Event[t.Event.Count - 1].Measure;
                        }
                    }

                    // 拡張音源の追加
                    switch (BasicConfigState.ExpansionSoundIndex)
                    {
                        case BasicConfigState.ExpansionSound.NESchannelsOnly:
                            break;
                        case BasicConfigState.ExpansionSound.KonamiVRC6:
                            TrackerList.Columns.Add("VRC6 Pulse 1");
                            TrackerList.Columns.Add("VRC6 Pulse 2");
                            TrackerList.Columns.Add("VRC6 Sawtooth");
                            break;
                        case BasicConfigState.ExpansionSound.KonamiVRC7:
                            TrackerList.Columns.Add("VRC7 FM 1");
                            TrackerList.Columns.Add("VRC7 FM 2");
                            TrackerList.Columns.Add("VRC7 FM 3");
                            TrackerList.Columns.Add("VRC7 FM 4");
                            TrackerList.Columns.Add("VRC7 FM 5");
                            TrackerList.Columns.Add("VRC7 FM 6");
                            break;
                        case BasicConfigState.ExpansionSound.NintendoFDSsound:
                            TrackerList.Columns.Add("FDS");
                            break;
                        case BasicConfigState.ExpansionSound.NintendoMMC5:
                            TrackerList.Columns.Add("MMC5 Pulse 1");
                            TrackerList.Columns.Add("MMC5 Pulse 2");
                            break;
                        case BasicConfigState.ExpansionSound.Namco163:
                            for (int i = 1; i <= BasicConfigState.Namco163channelCount; i++)
                            {
                                TrackerList.Columns.Add("Namco " + i);
                            }
                            break;
                    }

                    // コンボボックスにトラッカーのチャンネル名の配列を作る
                    for (int i = 1; TrackerList.Columns.Count > i; i++)
                    {
                        TrackerChannelList.Items.Add(TrackerList.Columns[i].Text);
                    }
                    TrackerChannelList.SelectedIndex = 0;

                    // トラッカーのリストを初期化
                    Convert c = new Convert();
                    c.InitializationTrackerList(ref TrackerList);

                    // チャンネル設定の有効、無効
                    Button_Convert.Enabled = true;
                    if (BasicConfigState.EnableEffectG)
                    {
                        RadioButton_LeadNotePriority.Enabled = true;
                        RadioButton_BehindNotePriority.Enabled = true;
                    }
                    else
                    {
                        RadioButton_LeadNotePriority.Enabled = false;
                        RadioButton_BehindNotePriority.Enabled = false;
                    }
                }
            }
        }

        private void ファイル_FTMエクスポート_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// メニューバー"ファイル"のドロップダウンメニューの終了をクリックしたとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void ファイル_終了_Click(object sender, EventArgs e)
        {
            // FormClosingイベントを発生させる
            Application.Exit();
        }
    }
}
