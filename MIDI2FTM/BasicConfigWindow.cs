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
    /// 基本設定のウィンドウ
    /// </summary>----------------------------------------------------------------------------------------------------
    public partial class BasicConfigWindow : Form
    {
        /// <summary>
        /// キャンセルボタンを押したか
        /// </summary>
        public bool IsCancel = false;

        /// <summary>
        /// コンストラクタ♪
        /// </summary>----------------------------------------------------------------------------------------------------
        public BasicConfigWindow()
        {
            InitializeComponent();

            // 初期化
            InitializedSettings();
            CheckBox_ChangedFrame.Checked = BasicConfigState.ChangedFrame;
            CheckBox_EnableEffectG.Checked = BasicConfigState.EnableEffectG;
            CheckBox_DisablePatternZero.Checked = BasicConfigState.DisablePatternZero;
            CheckBox_UnusedChannelOrderZeroFill.Checked = BasicConfigState.UnusedChannelOrderZeroFill;
            ComboBox_MinNote.SelectedIndex = BasicConfigState.MinNoteIndex;
            NumericUpDown_Speed.Value = BasicConfigState.Speed;
            NumericUpDown_OneFrameMeasureCount.Value = BasicConfigState.OneFrameMeasureCount;
            NumericUpDown_StartMeasure.Value = BasicConfigState.StartMeasure;
            ComboBox_ExpansionSoundList.SelectedIndex = (int)BasicConfigState.ExpansionSoundIndex;
            NumericUpDown_ChannelCount.Value = BasicConfigState.Namco163channelCount;
            
            // 拍子の初期化 デフォルトで4/4拍子
            float timeSignature = 1;
            // 0トラック目をループ 最大拍子を探しに行く
            foreach (EventData e0 in SMFData.Tracks[0].Event)
            {
                // 拍子イベントを見つける
                if (e0.EventID == 0xFF && e0.Number == 0x58)
                {
                    float tmp = e0.Value2 / e0.Value;
                    if (tmp >= timeSignature)
                    {
                        // 分母
                        BasicConfigState.MaxTimeSignatureDenom = (byte)e0.Value;
                        // 分子
                        BasicConfigState.MaxTimeSignatureNumer = (byte)e0.Value2;
                    }
                }
            }
            Label_MaxTimeSignature.Text = "最大拍子 : " + BasicConfigState.MaxTimeSignatureNumer + "/" + BasicConfigState.MaxTimeSignatureDenom;

            // 最大Rows更新
            refreshMaxRows();
            // 最小Tickの更新
            refreshMinTick();
        }

        /// <summary>
        /// 設定を初期化する
        /// </summary>
        private void InitializedSettings()
        {
            BasicConfigState.ChangedFrame = true;
            BasicConfigState.EnableEffectG = true;
            BasicConfigState.DisablePatternZero = true;
            BasicConfigState.UnusedChannelOrderZeroFill = true;
            BasicConfigState.MinNoteIndex = 4;
            BasicConfigState.Speed = 6;
            BasicConfigState.OneFrameMeasureCount = 4;
            BasicConfigState.StartMeasure = 2;
            BasicConfigState.MaxTimeSignatureNumer = 4;
            BasicConfigState.MaxTimeSignatureDenom = 4;
            BasicConfigState.MaxRows = 64;
            BasicConfigState.MaxMeasure = 0;
            BasicConfigState.ExpansionSoundIndex = BasicConfigState.ExpansionSound.NESchannelsOnly;
            BasicConfigState.Namco163channelCount = 1;
        }

        /// <summary>
        /// 拍子の変化でFrameを移行する チェックボックスの状態が変わった
        /// </summary>----------------------------------------------------------------------------------------------------
        private void CheckBox_ChangedFrame_CheckedChanged(object sender, EventArgs e)
        {
            // 拍子の変化でFrameを移行する 
            BasicConfigState.ChangedFrame = CheckBox_ChangedFrame.Checked;
        }
        /// <summary>
        /// 連符をGxxで表現する チェックボックスの状態が変わった
        /// </summary>----------------------------------------------------------------------------------------------------
        private void CheckBox_EnableEffectG_CheckedChanged(object sender, EventArgs e)
        {
            // 連符をGxxで表現する
            BasicConfigState.EnableEffectG = CheckBox_EnableEffectG.Checked;
        }
        /// <summary>
        /// PATTERN00を使用しない チェックボックスの状態が変わった
        /// </summary>----------------------------------------------------------------------------------------------------
        private void CheckBox_DisablePatternZero_CheckedChanged(object sender, EventArgs e)
        {
            // PATTERN00を使用しない
            BasicConfigState.DisablePatternZero = CheckBox_DisablePatternZero.Checked;
        }
        /// <summary>
        /// 未使用ChのOrderを00で埋める チェックボックスの状態が変わった
        /// </summary>----------------------------------------------------------------------------------------------------
        private void CheckBox_UnusedChannelOrderZeroFill_CheckedChanged(object sender, EventArgs e)
        {
            // 未使用ChのOrderを00で埋める
            BasicConfigState.UnusedChannelOrderZeroFill = CheckBox_UnusedChannelOrderZeroFill.Checked;
        }
        
        /// <summary>
        /// 最小音価 コンボボックスのインデックスが変わった
        /// </summary>----------------------------------------------------------------------------------------------------
        private void comboBox_MinNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 最小音価
            BasicConfigState.MinNoteIndex = ComboBox_MinNote.SelectedIndex;
            // 最大Rowsの更新
            refreshMaxRows();
            // 最小Tickの更新
            refreshMinTick();   
        }
        /// <summary>
        /// 拡張音源 コンボボックスのインデックスが変わった
        /// </summary>----------------------------------------------------------------------------------------------------
        private void ComboBox_ExpansionSoundList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 拡張音源の選択状態を保存
            BasicConfigState.ExpansionSoundIndex = (BasicConfigState.ExpansionSound)ComboBox_ExpansionSoundList.SelectedIndex;

            // Namco163だったら
            if (BasicConfigState.ExpansionSoundIndex == BasicConfigState.ExpansionSound.Namco163)
            {
                NumericUpDown_ChannelCount.Enabled = true;
            }
            else
            {
                NumericUpDown_ChannelCount.Enabled = false;
            }
        }
        
        /// <summary>
        /// Speed ナンバリックアップダウンの値が変わった
        /// </summary>----------------------------------------------------------------------------------------------------
        private void NumericUpDown_Speed_ValueChanged(object sender, EventArgs e)
        {
            // Speed 1 ～ 31 になるようにする
            if (NumericUpDown_Speed.Value < 1)
            {
                NumericUpDown_Speed.Value = 1;
            } 
            else if (NumericUpDown_Speed.Value > 31)
            {
                NumericUpDown_Speed.Value = 31;
            }
            // Speedの値を保存
            BasicConfigState.Speed = (byte)NumericUpDown_Speed.Value;
        }
        /// <summary>
        /// 最大Rows ナンバリックアップダウンの値が変わった
        /// </summary>----------------------------------------------------------------------------------------------------
        private void NumericUpDown_OneFrameMeasureCount_ValueChanged(object sender, EventArgs e)
        {
            // 0にはしない
            if (NumericUpDown_OneFrameMeasureCount.Value < 1)
            {
                NumericUpDown_OneFrameMeasureCount.Value = 1;
            }
            // 1Frameの小節数を保存
            BasicConfigState.OneFrameMeasureCount = (byte)NumericUpDown_OneFrameMeasureCount.Value;
            // 最大Rowsの更新
            refreshMaxRows();
        }
        /// <summary>
        /// 最初の小節番号 ナンバリックアップダウンの値が変わった
        /// </summary>----------------------------------------------------------------------------------------------------
        private void NumericUpDown_StartMeasure_ValueChanged(object sender, EventArgs e)
        {
            // 0にはしない
            if (NumericUpDown_StartMeasure.Value < 1)
            {
                NumericUpDown_StartMeasure.Value = 1;
            }
            // 最初の小節番号を保存
            BasicConfigState.StartMeasure = (int)NumericUpDown_StartMeasure.Value;
        }
        /// <summary>
        /// Namco163のチャンネル数 ナンバリックアップダウンの値が変わった
        /// </summary>----------------------------------------------------------------------------------------------------
        private void NumericUpDown_ChannelCount_ValueChanged(object sender, EventArgs e)
        {
            // 1 ～ 8 になるようにする
            if (NumericUpDown_ChannelCount.Value < 1)
            {
                NumericUpDown_ChannelCount.Value = 1;
            }
            else if (NumericUpDown_ChannelCount.Value > 8)
            {
                NumericUpDown_ChannelCount.Value = 8;
            }
            // チャンネル数の値を保存
            BasicConfigState.Namco163channelCount = (byte)NumericUpDown_ChannelCount.Value;
        }

        /// <summary>
        /// 決定ボタンを押した
        /// </summary>----------------------------------------------------------------------------------------------------
        private void DoneConfig_Click(object sender, EventArgs e)
        {
            // 閉じる
            Close();
        }
        /// <summary>
        /// キャンセルボタンを押した
        /// </summary>----------------------------------------------------------------------------------------------------
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            IsCancel = true;
            // 閉じる
            Close();
        }

        /// <summary>
        /// 最大Rowsのラベルを更新、基本設定の最大Rowsの更新
        /// </summary>----------------------------------------------------------------------------------------------------
        private void refreshMaxRows()
        {
            // 最小音価 / 分母 （このキャストは必要だ）
            float rate = (float)BasicConfigState.MinNote / (float)BasicConfigState.MaxTimeSignatureDenom;
            // 分子にrateを掛けて1小節のRowsを求める
            int oneMeasure = (int)(rate * BasicConfigState.MaxTimeSignatureNumer);
            // 最大Rows = 1小節の長さ * 小節数
            BasicConfigState.MaxRows = (short)(oneMeasure * NumericUpDown_OneFrameMeasureCount.Value);
            // ラベルを更新
            Label_MaxRows.Text = "最大Rows : " + BasicConfigState.MaxRows;

            // 最大Rowsが256を超えた場合
            if (BasicConfigState.MaxRows > 256)
            {
                // ラベルで警告する
                Label_RowsWarning.Text = "最大Rowsが256を超えています";
                Button_DoneConfig.Enabled = false;
            }
            else
            {
                Label_RowsWarning.Text = null;
                Button_DoneConfig.Enabled = true;
            }
        }
        
        /// <summary>
        /// 最小Tickのラベルを更新 
        /// </summary>----------------------------------------------------------------------------------------------------
        private void refreshMinTick()
        {
            Label_MinTick.Text = "最小Tick : " + BasicConfigState.TicksPerLine;

            // 最小Tickに小数点が含まれていた場合
            if (Math.Floor(BasicConfigState.TicksPerLine) != BasicConfigState.TicksPerLine)
            {
                // ラベルで警告する
                Label_TickWarning.Text = "最小Tickに小数点が含まれています";
                Button_DoneConfig.Enabled = false;
            }
            else
            {
                Label_TickWarning.Text = null;
                Button_DoneConfig.Enabled = true;
            }
        }
    }
}
