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
        /// <summary>
        /// メニューバー"ファイル"のドロップダウンメニューの名前を付けて保存をクリックしたとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void ファイル_名前を付けて保存_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// メニューバー"ファイル"のドロップダウンメニューのMIDIを開くをクリックしたとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void ファイル_MIDIを開く_Click(object sender, EventArgs e)
        {
        // ダイアログを開いてファイルをロードする
        LoadMIDIFile lmf = new LoadMIDIFile();
            lmf.GetMIDIFile();

            // ファイルを開いたか
            if (lmf.m_IsOpen)
            {
                // ステータスバーのテキスト更新
                ToolStripStatusLabel.Text = "MIDIファイルを解析しています。";

                // 開いたファイルを解析
                SMFAnalyzer sa = new SMFAnalyzer();

                // 解析が成功したら
                if (sa.AnalyzingSMF(ref lmf.m_ByteStream))
                {
                    // Measure Tick を解析
                    MeasureAnalyzer ma = new MeasureAnalyzer();
                    ma.Analyzing();

                    // ステータスバーのテキスト更新
                    ToolStripStatusLabel.Text = "MIDIファイルを解析しました。";

                    // 基本設定ウィンドウをモーダルで開く
                    BasicConfigWindow bcw = new BasicConfigWindow();
                    bcw.ShowDialog(this);
                    bcw.Dispose();
                    
                    // コンボボックスにトラックを追加
                    TrackList.DataSource = SMFData.Name;

                    // 最大小節番号を取得
                    foreach (Tracks t in SMFData.Tracks)
                    {
                        // 最大小節番号の更新があれば
                        if (BasicConfigState.MaxMeasure < t.Event[t.Event.Count - 2].Measure)
                        {
                            BasicConfigState.MaxMeasure = t.Event[t.Event.Count - 2].Measure;
                        }
                    }

                    RefreshTrackerList rtl = new RefreshTrackerList();
                    // トラッカーリストを初期化
                    rtl.InitializeList(ref TrackerList);
                    // 拡張音源列を追加
                    rtl.AddExpansionSoundColumns(ref TrackerList);

                    // コンボボックスにトラッカーのチャンネル名の配列を作る
                    TrackerChannelList.Items.Clear();
                    for (int i = 1; TrackerList.Columns.Count > i; i++)
                    {
                        TrackerChannelList.Items.Add(TrackerList.Columns[i].Text);
                    }
                    TrackerChannelList.SelectedIndex = 0;

                    // ステータスバーを初期化
                    initializeStatusBar("トラッカーを初期化しています。");

                    // トラッカーのリストを初期化
                    InitializationTrackerList itl = new InitializationTrackerList(ref TrackerList, ref ToolStripProgressBar);

                    // ステータスバーの中身を片づける
                    cleanUpStatusBar("トラッカーの初期化が完了しました。");

                    // チャンネル設定の有効、無効
                    Button_Convert.Enabled = true;
                    Button_Reset.Enabled = true;
                }
                // SMF解析に失敗した
                else
                {
                    ToolStripStatusLabel.Text = "MIDIファイルの解析に失敗しました。";
                }
            }
            // ファイルを開かなかった
            else
            {
                ToolStripStatusLabel.Text = "ファイルを開きませんでした。";
            }

            // ステータスバーの中身を片づける
            cleanUpStatusBar();
        }
        
        /// <summary>
        /// メニューバー"ファイル"のドロップダウンメニューの終了をクリックしたとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void ファイル_終了_Click(object sender, EventArgs e)
        {
            // FormClosingイベントを発生させる
            Application.Exit();
        }

        /// <summary>
        /// メニューバー"編集"のドロップダウンメニューの基本設定からやり直すをクリックしたとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void 編集_基本設定からやり直す_Click(object sender, EventArgs e)
        {

        }
    }
}
