using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDI2FTM
{
    /// <summary>
    /// メインウィンドウ
    /// </summary>----------------------------------------------------------------------------------------------------
    public partial class MainWindow : Form
    {
        /// <summary>
        /// コンストラクタ♪ 
        /// </summary>----------------------------------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

            // 諸々初期化
            CheckBox_EnableNoteVolume.Checked = ChannelConfigState.EnableNoteVolume;

            //CheckBox_EnableNoteOFF.Checked = ChannelConfigState.EnableNoteOFF;
            //RadioButton_NoteOFFtoVolume.Checked = ChannelConfigState.NoteOFFtoVolume;
            //RadioButton_NoteOFFtoNoteCut.Checked = ChannelConfigState.NoteOFFtoNoteCut;

            CheckBox_EnableEffectGxx.Checked = ChannelConfigState.EnableEffectGxx;
            CheckBox_EnableEffectPxx.Checked = ChannelConfigState.EnableEffectPxx;
            CheckBox_EnableEffect4xx.Checked = ChannelConfigState.EnableEffect4xx;
            CheckBox_LeftAlignedEffect.Checked = ChannelConfigState.LeftAlignedEffect;

            CheckBox_EnableCCVolume.Checked = ChannelConfigState.EnableCCVolume;
            RadioButton_CCVolumeToVolume.Checked = ChannelConfigState.CCVolumeToVolume;
            RadioButton_CCExpressionToVolume.Checked = ChannelConfigState.CCExpressionToVolume;

            RadioButton_HighNotePriority.Checked = ChannelConfigState.HighNotePriority;
            RadioButton_LowNotePriority.Checked = ChannelConfigState.LowNotePriority;

            RadioButton_LeadNotePriority.Checked = ChannelConfigState.LeadNotePriority;
            RadioButton_BehindNotePriority.Checked = ChannelConfigState.BehindNotePriority;

            NumericUpDown_InstrumentNum.Value = ChannelConfigState.InstrumentNum;

            // コンバート、リセットボタンを無効
            Button_Convert.Enabled = false;
            Button_Reset.Enabled = false;

            // ステータスバーの中身を片づける
            cleanUpStatusBar();
            
            // カラムヘッダの自動調整
            foreach (ColumnHeader ch in TrackerList.Columns)
            {
                ch.Width = -2;
            }
        }
        
        /// <summary>
        /// 閉じるボタンの処理 
        /// </summary>----------------------------------------------------------------------------------------------------
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
        
        /// <summary>
        /// SMFデータのトラックリストのコンボボックスを選択したとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void TrackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ステータスバーを初期化
            initializeStatusBar("イベントリストを更新しています。");

            // イベントリストを更新
            RefreshEventsList rel = new RefreshEventsList(ref EventsList, TrackList.SelectedIndex, ref ToolStripProgressBar);
            
            // ステータスバーの中身を片づける
            cleanUpStatusBar("イベントリストの更新が完了しました。");
        }
        
        /// <summary>
        /// コンバートボタンをクリックしたとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void Button_Convert_Click(object sender, EventArgs e)
        {
            // ステータスバーを初期化
            initializeStatusBar("イベントリストから" + TrackerChannelList.SelectedItem + "チャンネルにコンバートしています。");

            Convert c = new Convert(TrackList.SelectedIndex, TrackerChannelList.SelectedIndex + 1);
            // 選択されているMIDIトラックを選択されているトラッカーチャンネルにコンバートする
            c.StartConvert(ref TrackerList, ref ToolStripProgressBar);

            // ステータスバーの中身を片づける
            cleanUpStatusBar(TrackerChannelList.SelectedItem + "チャンネルへのコンバートが完了しました。");
        }

        /// <summary>
        /// リセットボタンをクリックしたとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void Button_Reset_Click(object sender, EventArgs e)
        {
            // ステータスバーを初期化
            initializeStatusBar(TrackerChannelList.SelectedItem + "チャンネルをリセットしています。");

            // 選択されているチャンネルをリセットする
            ChannelReset cr = new ChannelReset(ref TrackerList, TrackerChannelList.SelectedIndex + 1);

            // ステータスバーの中身を片づける
            cleanUpStatusBar(TrackerChannelList.SelectedItem + "チャンネルのリセットが完了しました。");
        }

        /// <summary>
        /// ノートオンのボリューム有効 チェックボックスに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void CheckBox_EnableNoteVolume_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.EnableNoteVolume = CheckBox_EnableNoteVolume.Checked;
        }
        /// <summary>
        /// 連符をGxxで表現する チェックボックスに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void CheckBox_EnableEffectGxx_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.EnableEffectGxx = CheckBox_EnableEffectGxx.Checked;
        }
        /// <summary>
        /// PitchBendをPxxで表現する ラジオボタンに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void CheckBox_EnableEffectPxx_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.EnableEffectPxx = CheckBox_EnableEffectPxx.Checked;
        }
        /// <summary>
        /// CCModulationを4xxで表現する チェックボックスに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void CheckBox_EnableEffect4xx_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.EnableEffect4xx = CheckBox_EnableEffect4xx.Checked;
        }
        /// <summary>
        /// エフェクトを左詰めにする チェックボックスに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void CheckBox_LeftAlignedEffect_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.LeftAlignedEffect = CheckBox_LeftAlignedEffect.Checked;
        }
        /// <summary>
        /// ノート以外のボリュームを有効 チェックボックスに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
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
        /// <summary>
        /// ノート以外のボリュームを有効 → CCVolumeを適用 ラジオボタンに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void RadioButton_CCVolumeToVolume_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.CCVolumeToVolume = RadioButton_CCVolumeToVolume.Checked;
        }
        /// <summary>
        /// ノート以外のボリュームを有効 → CCExpressionを適用 ラジオボタンに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void RadioButton_CCExpressionToVolume_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.CCExpressionToVolume = RadioButton_CCExpressionToVolume.Checked;
        }
        /// <summary>
        /// 一番高い音を優先 ラジオボタンに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void RadioButton_HighNotePriority_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.HighNotePriority = RadioButton_HighNotePriority.Checked;
        }
        /// <summary>
        /// 一番低い音を優先 ラジオボタンに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void RadioButton_LowNotePriority_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.LowNotePriority = RadioButton_LowNotePriority.Checked;
        }
        
        /// <summary>
        /// 同一Rowで先のノートを優先 ラジオボタンに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void RadioButton_LeadNotePriority_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.LeadNotePriority = RadioButton_LeadNotePriority.Checked;
        }
        /// <summary>
        /// 同一Rowで後のノートを優先 ラジオボタンに変更があったとき 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void RadioButton_BehindNotePriority_CheckedChanged(object sender, EventArgs e)
        {
            ChannelConfigState.BehindNotePriority = RadioButton_BehindNotePriority.Checked;
        }
        
        /// <summary>
        /// 音色番号 ナンバリックアップダウンの値が変わった
        /// </summary>----------------------------------------------------------------------------------------------------
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

            ChannelConfigState.InstrumentNum = (byte)NumericUpDown_InstrumentNum.Value;
        }

        /// <summary>
        /// ステータスバーのプログレスバーを初期化する、テキストを消すか引数があれば表示する
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_startMessage">表示したいテキスト</param>
        private void initializeStatusBar(string _startMessage = "")
        {
            ToolStripStatusLabel.Text = _startMessage;
            ToolStripProgressBar.Visible = true;
            ToolStripProgressBar.Value = 0;
            StatusStrip.Refresh();
        }

        /// <summary>
        /// ステータスバーのプログレスバーを片づける、テキストを消すか引数があれば表示して数秒後に消える
        /// </summary>----------------------------------------------------------------------------------------------------
        /// <param name="_endMessage">捨て台詞</param>
        private async void cleanUpStatusBar(string _endMessage = "")
        {
            ToolStripStatusLabel.Text = _endMessage;
            await Task.Delay(1 * 1000);
            ToolStripProgressBar.Visible = false;
            ToolStripProgressBar.Value = 0;
            ToolStripStatusLabel.Text = "";
        }

        /// <summary>
        /// 保存ボタンをクリックしたとき
        /// </summary>----------------------------------------------------------------------------------------------------
        private void Button_Save_Click(object sender, EventArgs e)
        {
            // チャンネル名の配列をコピー
            string[] channelList = new string[TrackerChannelList.Items.Count];
            for(int i = 0; i < TrackerChannelList.Items.Count; i++)
            {
                channelList[i] = TrackerChannelList.Items[i].ToString();
            }

            // トラッカーリストの配列をコピー
            string[,] trackerList = new string[TrackerList.Items.Count - 1, TrackerList.Columns.Count];
            for (int i = 0; i < TrackerList.Items.Count - 1; i++)
            {
                for (int j = 0; j < TrackerList.Columns.Count; j++)
                {
                    trackerList[i, j] = TrackerList.Items[i].SubItems[j].Text;
                }
            }

            // 各チャンネルの使用エフェクト数を取得
            byte[] channeEffectCount = new byte[TrackerList.Columns.Count - 1];
            for (int i = 0; i < TrackerList.Columns.Count - 1; i++)
            {
                StringInfo si = new StringInfo(TrackerList.Items[1].SubItems[i + 1].Text);
                channeEffectCount[i] = (byte)((si.LengthInTextElements - 8) / 4);
            }

            // EffectDxxを追加する ウィンドウをモーダルで開く
            AddEffectDxxWindow aedw = new AddEffectDxxWindow(ref channelList, ref channeEffectCount);
            aedw.ShowDialog(this);
            aedw.Dispose();

            // Dxxを追加する 255は対象外扱い
            if (ChannelConfigState.OutPutEffectDxxChannel != 255)
            {
                // チャンネルの使用エフェクト数を増やす
                channeEffectCount[ChannelConfigState.OutPutEffectDxxChannel]++;
                // Dxx追加処理 todo ConvertCommonを継承したクラスをつくろうか
            }

            // EffectFxxを追加する ウィンドウをモーダルで開く
            AddEffectFxxWindow aefw = new AddEffectFxxWindow(ref channelList, ref channeEffectCount);
            aefw.ShowDialog(this);
            aefw.Dispose();

            // Fxxを追加する 255は対象外扱い
            if (ChannelConfigState.OutPutEffectFxxChannel != 255)
            {
                // Fxx追加処理 todo
            }

            // 名前を付けて保存 todo テキストで。
        }
    }
}
