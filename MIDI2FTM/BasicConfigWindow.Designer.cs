namespace MIDI2FTM
{
    partial class BasicConfigWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label_MaxRows = new System.Windows.Forms.Label();
            this.Label_MaxTimeSignature = new System.Windows.Forms.Label();
            this.CheckBox_UnusedChannelOrderZeroFill = new System.Windows.Forms.CheckBox();
            this.CheckBox_DisablePatternZero = new System.Windows.Forms.CheckBox();
            this.NumericUpDown_Speed = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_OneFrameMeasureCount = new System.Windows.Forms.NumericUpDown();
            this.Label_1Frameの小節数 = new System.Windows.Forms.Label();
            this.Label_最小音価 = new System.Windows.Forms.Label();
            this.ComboBox_MinNote = new System.Windows.Forms.ComboBox();
            this.Label_Speed = new System.Windows.Forms.Label();
            this.CheckBox_ChangedFrame = new System.Windows.Forms.CheckBox();
            this.Button_DoneConfig = new System.Windows.Forms.Button();
            this.Label_RowsWarning = new System.Windows.Forms.Label();
            this.Label_MinTick = new System.Windows.Forms.Label();
            this.Label_TickWarning = new System.Windows.Forms.Label();
            this.NumericUpDown_StartMeasure = new System.Windows.Forms.NumericUpDown();
            this.Label_最初の小節 = new System.Windows.Forms.Label();
            this.GroupBox_拡張音源 = new System.Windows.Forms.GroupBox();
            this.NumericUpDown_ChannelCount = new System.Windows.Forms.NumericUpDown();
            this.Label_チャンネル数 = new System.Windows.Forms.Label();
            this.ComboBox_ExpansionSoundList = new System.Windows.Forms.ComboBox();
            this.Label_MinNoteWarning = new System.Windows.Forms.Label();
            this.Label_MinTempo = new System.Windows.Forms.Label();
            this.Label_MaxTempo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_OneFrameMeasureCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_StartMeasure)).BeginInit();
            this.GroupBox_拡張音源.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_ChannelCount)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_MaxRows
            // 
            this.Label_MaxRows.AutoSize = true;
            this.Label_MaxRows.Location = new System.Drawing.Point(22, 370);
            this.Label_MaxRows.Name = "Label_MaxRows";
            this.Label_MaxRows.Size = new System.Drawing.Size(110, 16);
            this.Label_MaxRows.TabIndex = 12;
            this.Label_MaxRows.Text = "最大Rows : null";
            // 
            // Label_MaxTimeSignature
            // 
            this.Label_MaxTimeSignature.AutoSize = true;
            this.Label_MaxTimeSignature.Location = new System.Drawing.Point(22, 340);
            this.Label_MaxTimeSignature.Name = "Label_MaxTimeSignature";
            this.Label_MaxTimeSignature.Size = new System.Drawing.Size(107, 16);
            this.Label_MaxTimeSignature.TabIndex = 11;
            this.Label_MaxTimeSignature.Text = "最大拍子 : null";
            // 
            // CheckBox_UnusedChannelOrderZeroFill
            // 
            this.CheckBox_UnusedChannelOrderZeroFill.AutoSize = true;
            this.CheckBox_UnusedChannelOrderZeroFill.Location = new System.Drawing.Point(12, 91);
            this.CheckBox_UnusedChannelOrderZeroFill.Name = "CheckBox_UnusedChannelOrderZeroFill";
            this.CheckBox_UnusedChannelOrderZeroFill.Size = new System.Drawing.Size(231, 20);
            this.CheckBox_UnusedChannelOrderZeroFill.TabIndex = 10;
            this.CheckBox_UnusedChannelOrderZeroFill.Text = "未使用ChのOrderを00で埋める";
            this.CheckBox_UnusedChannelOrderZeroFill.UseVisualStyleBackColor = true;
            this.CheckBox_UnusedChannelOrderZeroFill.CheckedChanged += new System.EventHandler(this.CheckBox_UnusedChannelOrderZeroFill_CheckedChanged);
            // 
            // CheckBox_DisablePatternZero
            // 
            this.CheckBox_DisablePatternZero.AutoSize = true;
            this.CheckBox_DisablePatternZero.Location = new System.Drawing.Point(12, 64);
            this.CheckBox_DisablePatternZero.Name = "CheckBox_DisablePatternZero";
            this.CheckBox_DisablePatternZero.Size = new System.Drawing.Size(196, 20);
            this.CheckBox_DisablePatternZero.TabIndex = 9;
            this.CheckBox_DisablePatternZero.Text = "PATTERN00を使用しない";
            this.CheckBox_DisablePatternZero.UseVisualStyleBackColor = true;
            this.CheckBox_DisablePatternZero.CheckedChanged += new System.EventHandler(this.CheckBox_DisablePatternZero_CheckedChanged);
            // 
            // NumericUpDown_Speed
            // 
            this.NumericUpDown_Speed.Location = new System.Drawing.Point(152, 145);
            this.NumericUpDown_Speed.Name = "NumericUpDown_Speed";
            this.NumericUpDown_Speed.Size = new System.Drawing.Size(62, 23);
            this.NumericUpDown_Speed.TabIndex = 7;
            this.NumericUpDown_Speed.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.NumericUpDown_Speed.ValueChanged += new System.EventHandler(this.NumericUpDown_Speed_ValueChanged);
            // 
            // NumericUpDown_OneFrameMeasureCount
            // 
            this.NumericUpDown_OneFrameMeasureCount.Location = new System.Drawing.Point(152, 175);
            this.NumericUpDown_OneFrameMeasureCount.Name = "NumericUpDown_OneFrameMeasureCount";
            this.NumericUpDown_OneFrameMeasureCount.Size = new System.Drawing.Size(62, 23);
            this.NumericUpDown_OneFrameMeasureCount.TabIndex = 6;
            this.NumericUpDown_OneFrameMeasureCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericUpDown_OneFrameMeasureCount.ValueChanged += new System.EventHandler(this.NumericUpDown_OneFrameMeasureCount_ValueChanged);
            // 
            // Label_1Frameの小節数
            // 
            this.Label_1Frameの小節数.AutoSize = true;
            this.Label_1Frameの小節数.Location = new System.Drawing.Point(9, 177);
            this.Label_1Frameの小節数.Name = "Label_1Frameの小節数";
            this.Label_1Frameの小節数.Size = new System.Drawing.Size(120, 16);
            this.Label_1Frameの小節数.TabIndex = 5;
            this.Label_1Frameの小節数.Text = "1Frameの小節数";
            // 
            // Label_最小音価
            // 
            this.Label_最小音価.AutoSize = true;
            this.Label_最小音価.Location = new System.Drawing.Point(9, 118);
            this.Label_最小音価.Name = "Label_最小音価";
            this.Label_最小音価.Size = new System.Drawing.Size(72, 16);
            this.Label_最小音価.TabIndex = 4;
            this.Label_最小音価.Text = "最小音価";
            // 
            // ComboBox_MinNote
            // 
            this.ComboBox_MinNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_MinNote.FormattingEnabled = true;
            this.ComboBox_MinNote.Items.AddRange(new object[] {
            "全音符",
            "2分音符",
            "4分音符",
            "8分音符",
            "16分音符",
            "32分音符",
            "64分音符",
            "128分音符",
            "256分音符",
            "512分音符"});
            this.ComboBox_MinNote.Location = new System.Drawing.Point(152, 115);
            this.ComboBox_MinNote.Name = "ComboBox_MinNote";
            this.ComboBox_MinNote.Size = new System.Drawing.Size(114, 24);
            this.ComboBox_MinNote.TabIndex = 3;
            this.ComboBox_MinNote.SelectedIndexChanged += new System.EventHandler(this.comboBox_MinNote_SelectedIndexChanged);
            // 
            // Label_Speed
            // 
            this.Label_Speed.AutoSize = true;
            this.Label_Speed.Location = new System.Drawing.Point(12, 147);
            this.Label_Speed.Name = "Label_Speed";
            this.Label_Speed.Size = new System.Drawing.Size(50, 16);
            this.Label_Speed.TabIndex = 2;
            this.Label_Speed.Text = "Speed";
            // 
            // CheckBox_ChangedFrame
            // 
            this.CheckBox_ChangedFrame.AutoSize = true;
            this.CheckBox_ChangedFrame.Location = new System.Drawing.Point(12, 12);
            this.CheckBox_ChangedFrame.Name = "CheckBox_ChangedFrame";
            this.CheckBox_ChangedFrame.Size = new System.Drawing.Size(233, 20);
            this.CheckBox_ChangedFrame.TabIndex = 0;
            this.CheckBox_ChangedFrame.Text = "拍子の変化でFrameを移行する";
            this.CheckBox_ChangedFrame.UseVisualStyleBackColor = true;
            this.CheckBox_ChangedFrame.CheckedChanged += new System.EventHandler(this.CheckBox_ChangedFrame_CheckedChanged);
            // 
            // Button_DoneConfig
            // 
            this.Button_DoneConfig.Location = new System.Drawing.Point(200, 571);
            this.Button_DoneConfig.Name = "Button_DoneConfig";
            this.Button_DoneConfig.Size = new System.Drawing.Size(86, 23);
            this.Button_DoneConfig.TabIndex = 13;
            this.Button_DoneConfig.Text = "決定";
            this.Button_DoneConfig.UseVisualStyleBackColor = true;
            this.Button_DoneConfig.Click += new System.EventHandler(this.DoneConfig_Click);
            // 
            // Label_RowsWarning
            // 
            this.Label_RowsWarning.AutoSize = true;
            this.Label_RowsWarning.Font = new System.Drawing.Font("MS UI Gothic", 8.861538F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_RowsWarning.ForeColor = System.Drawing.Color.Red;
            this.Label_RowsWarning.Location = new System.Drawing.Point(22, 490);
            this.Label_RowsWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_RowsWarning.Name = "Label_RowsWarning";
            this.Label_RowsWarning.Size = new System.Drawing.Size(30, 16);
            this.Label_RowsWarning.TabIndex = 14;
            this.Label_RowsWarning.Text = "null";
            // 
            // Label_MinTick
            // 
            this.Label_MinTick.AutoSize = true;
            this.Label_MinTick.Location = new System.Drawing.Point(22, 400);
            this.Label_MinTick.Name = "Label_MinTick";
            this.Label_MinTick.Size = new System.Drawing.Size(102, 16);
            this.Label_MinTick.TabIndex = 15;
            this.Label_MinTick.Text = "最小Tick : null";
            // 
            // Label_TickWarning
            // 
            this.Label_TickWarning.AutoSize = true;
            this.Label_TickWarning.Font = new System.Drawing.Font("MS UI Gothic", 8.861538F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_TickWarning.ForeColor = System.Drawing.Color.Red;
            this.Label_TickWarning.Location = new System.Drawing.Point(22, 520);
            this.Label_TickWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_TickWarning.Name = "Label_TickWarning";
            this.Label_TickWarning.Size = new System.Drawing.Size(30, 16);
            this.Label_TickWarning.TabIndex = 17;
            this.Label_TickWarning.Text = "null";
            // 
            // NumericUpDown_StartMeasure
            // 
            this.NumericUpDown_StartMeasure.Location = new System.Drawing.Point(152, 204);
            this.NumericUpDown_StartMeasure.Name = "NumericUpDown_StartMeasure";
            this.NumericUpDown_StartMeasure.Size = new System.Drawing.Size(62, 23);
            this.NumericUpDown_StartMeasure.TabIndex = 20;
            this.NumericUpDown_StartMeasure.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericUpDown_StartMeasure.ValueChanged += new System.EventHandler(this.NumericUpDown_StartMeasure_ValueChanged);
            // 
            // Label_最初の小節
            // 
            this.Label_最初の小節.AutoSize = true;
            this.Label_最初の小節.Location = new System.Drawing.Point(9, 206);
            this.Label_最初の小節.Name = "Label_最初の小節";
            this.Label_最初の小節.Size = new System.Drawing.Size(85, 16);
            this.Label_最初の小節.TabIndex = 19;
            this.Label_最初の小節.Text = "最初の小節";
            // 
            // GroupBox_拡張音源
            // 
            this.GroupBox_拡張音源.Controls.Add(this.NumericUpDown_ChannelCount);
            this.GroupBox_拡張音源.Controls.Add(this.Label_チャンネル数);
            this.GroupBox_拡張音源.Controls.Add(this.ComboBox_ExpansionSoundList);
            this.GroupBox_拡張音源.Location = new System.Drawing.Point(12, 233);
            this.GroupBox_拡張音源.Name = "GroupBox_拡張音源";
            this.GroupBox_拡張音源.Size = new System.Drawing.Size(274, 89);
            this.GroupBox_拡張音源.TabIndex = 21;
            this.GroupBox_拡張音源.TabStop = false;
            this.GroupBox_拡張音源.Text = "拡張音源";
            // 
            // NumericUpDown_ChannelCount
            // 
            this.NumericUpDown_ChannelCount.Enabled = false;
            this.NumericUpDown_ChannelCount.Location = new System.Drawing.Point(192, 52);
            this.NumericUpDown_ChannelCount.Name = "NumericUpDown_ChannelCount";
            this.NumericUpDown_ChannelCount.Size = new System.Drawing.Size(62, 23);
            this.NumericUpDown_ChannelCount.TabIndex = 22;
            this.NumericUpDown_ChannelCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_ChannelCount.ValueChanged += new System.EventHandler(this.NumericUpDown_ChannelCount_ValueChanged);
            // 
            // Label_チャンネル数
            // 
            this.Label_チャンネル数.AutoSize = true;
            this.Label_チャンネル数.Location = new System.Drawing.Point(100, 54);
            this.Label_チャンネル数.Name = "Label_チャンネル数";
            this.Label_チャンネル数.Size = new System.Drawing.Size(86, 16);
            this.Label_チャンネル数.TabIndex = 22;
            this.Label_チャンネル数.Text = "チャンネル数";
            // 
            // ComboBox_ExpansionSoundList
            // 
            this.ComboBox_ExpansionSoundList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_ExpansionSoundList.FormattingEnabled = true;
            this.ComboBox_ExpansionSoundList.Items.AddRange(new object[] {
            "NES channels only",
            "Konami VRC6",
            "Konami VRC7",
            "Nintendo FDS sound",
            "Nintendo MMC5",
            "Namco 163"});
            this.ComboBox_ExpansionSoundList.Location = new System.Drawing.Point(6, 22);
            this.ComboBox_ExpansionSoundList.Name = "ComboBox_ExpansionSoundList";
            this.ComboBox_ExpansionSoundList.Size = new System.Drawing.Size(248, 24);
            this.ComboBox_ExpansionSoundList.TabIndex = 22;
            this.ComboBox_ExpansionSoundList.SelectedIndexChanged += new System.EventHandler(this.ComboBox_ExpansionSoundList_SelectedIndexChanged);
            // 
            // Label_MinNoteWarning
            // 
            this.Label_MinNoteWarning.AutoSize = true;
            this.Label_MinNoteWarning.Font = new System.Drawing.Font("MS UI Gothic", 8.861538F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_MinNoteWarning.ForeColor = System.Drawing.Color.Red;
            this.Label_MinNoteWarning.Location = new System.Drawing.Point(22, 550);
            this.Label_MinNoteWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_MinNoteWarning.Name = "Label_MinNoteWarning";
            this.Label_MinNoteWarning.Size = new System.Drawing.Size(30, 16);
            this.Label_MinNoteWarning.TabIndex = 22;
            this.Label_MinNoteWarning.Text = "null";
            // 
            // Label_MinTempo
            // 
            this.Label_MinTempo.AutoSize = true;
            this.Label_MinTempo.Location = new System.Drawing.Point(22, 430);
            this.Label_MinTempo.Name = "Label_MinTempo";
            this.Label_MinTempo.Size = new System.Drawing.Size(120, 16);
            this.Label_MinTempo.TabIndex = 23;
            this.Label_MinTempo.Text = "最小Tempo : null";
            // 
            // Label_MaxTempo
            // 
            this.Label_MaxTempo.AutoSize = true;
            this.Label_MaxTempo.Location = new System.Drawing.Point(22, 460);
            this.Label_MaxTempo.Name = "Label_MaxTempo";
            this.Label_MaxTempo.Size = new System.Drawing.Size(120, 16);
            this.Label_MaxTempo.TabIndex = 24;
            this.Label_MaxTempo.Text = "最大Tempo : null";
            // 
            // BasicConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 606);
            this.ControlBox = false;
            this.Controls.Add(this.Label_MaxTempo);
            this.Controls.Add(this.Label_MinTempo);
            this.Controls.Add(this.Label_MinNoteWarning);
            this.Controls.Add(this.GroupBox_拡張音源);
            this.Controls.Add(this.NumericUpDown_StartMeasure);
            this.Controls.Add(this.Label_最初の小節);
            this.Controls.Add(this.Label_TickWarning);
            this.Controls.Add(this.Label_MinTick);
            this.Controls.Add(this.Label_RowsWarning);
            this.Controls.Add(this.Button_DoneConfig);
            this.Controls.Add(this.Label_MaxRows);
            this.Controls.Add(this.Label_MaxTimeSignature);
            this.Controls.Add(this.CheckBox_UnusedChannelOrderZeroFill);
            this.Controls.Add(this.CheckBox_ChangedFrame);
            this.Controls.Add(this.CheckBox_DisablePatternZero);
            this.Controls.Add(this.Label_Speed);
            this.Controls.Add(this.ComboBox_MinNote);
            this.Controls.Add(this.NumericUpDown_Speed);
            this.Controls.Add(this.Label_最小音価);
            this.Controls.Add(this.NumericUpDown_OneFrameMeasureCount);
            this.Controls.Add(this.Label_1Frameの小節数);
            this.Name = "BasicConfigWindow";
            this.Text = "基本設定";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_OneFrameMeasureCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_StartMeasure)).EndInit();
            this.GroupBox_拡張音源.ResumeLayout(false);
            this.GroupBox_拡張音源.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_ChannelCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Label_MaxRows;
        private System.Windows.Forms.Label Label_MaxTimeSignature;
        private System.Windows.Forms.CheckBox CheckBox_UnusedChannelOrderZeroFill;
        private System.Windows.Forms.CheckBox CheckBox_DisablePatternZero;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Speed;
        private System.Windows.Forms.NumericUpDown NumericUpDown_OneFrameMeasureCount;
        private System.Windows.Forms.Label Label_1Frameの小節数;
        private System.Windows.Forms.Label Label_最小音価;
        private System.Windows.Forms.ComboBox ComboBox_MinNote;
        private System.Windows.Forms.Label Label_Speed;
        private System.Windows.Forms.CheckBox CheckBox_ChangedFrame;
        private System.Windows.Forms.Button Button_DoneConfig;
        private System.Windows.Forms.Label Label_RowsWarning;
        private System.Windows.Forms.Label Label_MinTick;
        private System.Windows.Forms.Label Label_TickWarning;
        private System.Windows.Forms.NumericUpDown NumericUpDown_StartMeasure;
        private System.Windows.Forms.Label Label_最初の小節;
        private System.Windows.Forms.GroupBox GroupBox_拡張音源;
        private System.Windows.Forms.NumericUpDown NumericUpDown_ChannelCount;
        private System.Windows.Forms.Label Label_チャンネル数;
        private System.Windows.Forms.ComboBox ComboBox_ExpansionSoundList;
        private System.Windows.Forms.Label Label_MinNoteWarning;
        private System.Windows.Forms.Label Label_MinTempo;
        private System.Windows.Forms.Label Label_MaxTempo;
    }
}