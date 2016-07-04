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

            // 諸々初期化
            CheckBox_EnableNoteVolume.Checked = ChannelConfigState.EnableNoteVolume;

            CheckBox_EnableNoteOFF.Checked = ChannelConfigState.EnableNoteOFF;
            RadioButton_NoteOFFtoVolume.Checked = ChannelConfigState.NoteOFFtoVolume;
            RadioButton_NoteOFFtoNoteCut.Checked = ChannelConfigState.NoteOFFtoNoteCut;

            CheckBox_EnableEffect1and2.Checked = ChannelConfigState.EnableEffect1and2;
            CheckBox_EnableEffect4and7.Checked = ChannelConfigState.EnableEffect4and7;
            CheckBox_EnableEffectF.Checked = ChannelConfigState.EnableEffectF;

            CheckBox_EnableCCVolume.Checked = ChannelConfigState.EnableCCVolume;
            RadioButton_CCVolumeToVolume.Checked = ChannelConfigState.CCVolumeToVolume;
            RadioButton_CCExpressionToVolume.Checked = ChannelConfigState.CCExpressionToVolume;

            RadioButton_HighNotePriority.Checked = ChannelConfigState.HighNotePriority;
            RadioButton_LowNotePriority.Checked = ChannelConfigState.LowNotePriority;

            RadioButton_LeadNotePriority.Checked = ChannelConfigState.LeadNotePriority;
            RadioButton_BehindNotePriority.Checked = ChannelConfigState.BehindNotePriority;

            NumericUpDown_InstrumentNum.Value = ChannelConfigState.InstrumentNum;

            // コンバートボタンを無効
            Button_Convert.Enabled = false;


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
            c.TestConvert(ref TrackerList, TrackList.SelectedIndex, TrackerChannelList.SelectedIndex + 1);
        }

        //----------------------------------------------------------------------------------------------------
        // チェックボックス、ラジオボタンに変更があったとき
        //----------------------------------------------------------------------------------------------------
        private void CheckBox_EnableNoteVolume_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.EnableNoteVolume = CheckBox_EnableNoteVolume.Checked;
        }
        private void CheckBox_EnableNoteOFF_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.EnableNoteOFF = CheckBox_EnableNoteOFF.Checked;
            // ラジオボタン有効、無効
            if (ChannelConfigState.EnableNoteOFF)
            {
                RadioButton_NoteOFFtoVolume.Enabled = true;
                RadioButton_NoteOFFtoNoteCut.Enabled = true;
            }
            else
            {
                RadioButton_NoteOFFtoVolume.Enabled = false;
                RadioButton_NoteOFFtoNoteCut.Enabled = false;
            }
        }
        private void RadioButton_NoteOFFtoVolume_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.NoteOFFtoVolume = RadioButton_NoteOFFtoVolume.Checked;
        }
        private void RadioButton_NoteOFFtoNoteCut_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.NoteOFFtoNoteCut = RadioButton_NoteOFFtoNoteCut.Checked;
        }
        private void CheckBox_EnableEffect1and2_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.EnableEffect1and2 = CheckBox_EnableEffect1and2.Checked;
        }
        private void CheckBox_EnableEffect4and7_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.EnableEffect4and7 = CheckBox_EnableEffect4and7.Checked;
        }
        private void CheckBox_EnableEffectF_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.EnableEffectF = CheckBox_EnableEffectF.Checked;
        }
        private void CheckBox_EnableCCVolume_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.EnableCCVolume = CheckBox_EnableCCVolume.Checked;
            // ラジオボタン有効、無効
            if (ChannelConfigState.EnableCCVolume)
            {
                RadioButton_CCVolumeToVolume.Enabled = true;
                RadioButton_CCExpressionToVolume.Enabled = true;
            }
            else
            {
                RadioButton_CCVolumeToVolume.Enabled = false;
                RadioButton_CCExpressionToVolume.Enabled = false;
            }
        }
        private void RadioButton_CCVolumeToVolume_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.CCVolumeToVolume = RadioButton_CCVolumeToVolume.Checked;
        }
        private void RadioButton_CCExpressionToVolume_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.CCExpressionToVolume = RadioButton_CCExpressionToVolume.Checked;
        }
        private void RadioButton_HighNotePriority_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.HighNotePriority = RadioButton_HighNotePriority.Checked;
        }
        private void RadioButton_LowNotePriority_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.LowNotePriority = RadioButton_LowNotePriority.Checked;
        }
        private void RadioButton_LeadNotePriority_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.LeadNotePriority = RadioButton_LeadNotePriority.Checked;
        }
        private void RadioButton_BehindNotePriority_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.BehindNotePriority = RadioButton_BehindNotePriority.Checked;
        }

        //----------------------------------------------------------------------------------------------------
        // ナンバリックアップダウンの値が変わった
        //----------------------------------------------------------------------------------------------------
        private void NumericUpDown_InstrumentNum_ValueChanged(object sender, EventArgs e)
        {
            if (NumericUpDown_InstrumentNum.Value < 0)
            {
                NumericUpDown_InstrumentNum.Value = 0;
            }
            else if (NumericUpDown_InstrumentNum.Value > 0x3F)
            {
                NumericUpDown_InstrumentNum.Value = 0x3F;
            }
        }
    }
}
