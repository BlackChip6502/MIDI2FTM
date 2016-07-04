/*****************************************************************************************************
 メインウィンドウ
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
    public partial class MainWindow : Form
    {
        //----------------------------------------------------------------------------------------------------
        // コンストラクタ♪
        //----------------------------------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

            // カラムヘッダの自動調整
            foreach (ColumnHeader ch in TrackerList.Columns)
            {
                ch.Width = -2;
            }
        }

        //----------------------------------------------------------------------------------------------------
        // 閉じるボタンの処理
        //----------------------------------------------------------------------------------------------------
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            if (DialogResult.No == MessageBox.Show(
                    "終了しますか？", "終了確認", MessageBoxButtons.YesNo))
            {
                e.Cancel = true;
            }
            */
        }

        //----------------------------------------------------------------------------------------------------
        // コンボボックスを選択したとき
        //----------------------------------------------------------------------------------------------------
        private void TrackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // イベントリストを更新
            RefreshEventsList rel = new RefreshEventsList(ref EventsList, TrackList.SelectedIndex);
        }

        //----------------------------------------------------------------------------------------------------
        // コンバートボタンをクリックしたとき
        //----------------------------------------------------------------------------------------------------
        private void Button_Convert_Click(object sender, EventArgs e)
        {
            Convert c = new Convert();
            c.TestConvert(ref TrackerList, 1, 1);
        }
    }
}
