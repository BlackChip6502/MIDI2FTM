﻿using System;
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
                // ステータスバーのテキスト更新
                ToolStripStatusLabel.Text = "MIDIファイルを解析しています。";

                // 開いたファイルを解析
                SMFAnalyzer sa = new SMFAnalyzer();

                // 解析が成功したら
                if (sa.AnalyzingSMF(ref lmf.ByteStream))
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

                    // キャンセルボタンを押したなら何もしない
                    if (bcw.IsCancel)
                    {
                        // ステータスバーのテキスト更新
                        ToolStripStatusLabel.Text = "キャンセルしました。";
                        return;
                    }

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
                    Convert c = new Convert();
                    c.InitializationTrackerList(ref TrackerList, ref ToolStripProgressBar);

                    // ステータスバーの中身を片づける
                    cleanUpStatusBar("トラッカーの初期化が完了しました。");

                    // チャンネル設定の有効、無効
                    Button_Convert.Enabled = true;
                    Button_Reset.Enabled = true;
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
