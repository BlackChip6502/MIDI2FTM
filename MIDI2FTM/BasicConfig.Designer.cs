namespace MIDI2FTM
{
    partial class BasicConfig
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
            this.MaxRows = new System.Windows.Forms.Label();
            this.MaxTimeSignature = new System.Windows.Forms.Label();
            this.checkBox_未使用ChのOrderを00で埋める = new System.Windows.Forms.CheckBox();
            this.checkBox_PATTERN00を使用しない = new System.Windows.Forms.CheckBox();
            this.checkBox_連符をGxxで表現する = new System.Windows.Forms.CheckBox();
            this.SpeedValue = new System.Windows.Forms.NumericUpDown();
            this.FramePerMeasure = new System.Windows.Forms.NumericUpDown();
            this.Label_FramePerMeasure = new System.Windows.Forms.Label();
            this.最小音価 = new System.Windows.Forms.Label();
            this.MinimumNote = new System.Windows.Forms.ComboBox();
            this.Speed = new System.Windows.Forms.Label();
            this.checkBox_拍子の変化でFrameを移行する = new System.Windows.Forms.CheckBox();
            this.DoneSettings = new System.Windows.Forms.Button();
            this.SaveSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FramePerMeasure)).BeginInit();
            this.SuspendLayout();
            // 
            // MaxRows
            // 
            this.MaxRows.AutoSize = true;
            this.MaxRows.Location = new System.Drawing.Point(12, 235);
            this.MaxRows.Name = "MaxRows";
            this.MaxRows.Size = new System.Drawing.Size(78, 16);
            this.MaxRows.TabIndex = 12;
            this.MaxRows.Text = "Rows : null";
            // 
            // MaxTimeSignature
            // 
            this.MaxTimeSignature.AutoSize = true;
            this.MaxTimeSignature.Location = new System.Drawing.Point(12, 206);
            this.MaxTimeSignature.Name = "MaxTimeSignature";
            this.MaxTimeSignature.Size = new System.Drawing.Size(107, 16);
            this.MaxTimeSignature.TabIndex = 11;
            this.MaxTimeSignature.Text = "最大拍子 : null";
            // 
            // checkBox_未使用ChのOrderを00で埋める
            // 
            this.checkBox_未使用ChのOrderを00で埋める.AutoSize = true;
            this.checkBox_未使用ChのOrderを00で埋める.Location = new System.Drawing.Point(12, 90);
            this.checkBox_未使用ChのOrderを00で埋める.Name = "checkBox_未使用ChのOrderを00で埋める";
            this.checkBox_未使用ChのOrderを00で埋める.Size = new System.Drawing.Size(231, 20);
            this.checkBox_未使用ChのOrderを00で埋める.TabIndex = 10;
            this.checkBox_未使用ChのOrderを00で埋める.Text = "未使用ChのOrderを00で埋める";
            this.checkBox_未使用ChのOrderを00で埋める.UseVisualStyleBackColor = true;
            // 
            // checkBox_PATTERN00を使用しない
            // 
            this.checkBox_PATTERN00を使用しない.AutoSize = true;
            this.checkBox_PATTERN00を使用しない.Location = new System.Drawing.Point(12, 64);
            this.checkBox_PATTERN00を使用しない.Name = "checkBox_PATTERN00を使用しない";
            this.checkBox_PATTERN00を使用しない.Size = new System.Drawing.Size(196, 20);
            this.checkBox_PATTERN00を使用しない.TabIndex = 9;
            this.checkBox_PATTERN00を使用しない.Text = "PATTERN00を使用しない";
            this.checkBox_PATTERN00を使用しない.UseVisualStyleBackColor = true;
            // 
            // checkBox_連符をGxxで表現する
            // 
            this.checkBox_連符をGxxで表現する.AutoSize = true;
            this.checkBox_連符をGxxで表現する.Location = new System.Drawing.Point(12, 38);
            this.checkBox_連符をGxxで表現する.Name = "checkBox_連符をGxxで表現する";
            this.checkBox_連符をGxxで表現する.Size = new System.Drawing.Size(170, 20);
            this.checkBox_連符をGxxで表現する.TabIndex = 8;
            this.checkBox_連符をGxxで表現する.Text = "連符をGxxで表現する";
            this.checkBox_連符をGxxで表現する.UseVisualStyleBackColor = true;
            // 
            // SpeedValue
            // 
            this.SpeedValue.Location = new System.Drawing.Point(138, 146);
            this.SpeedValue.Name = "SpeedValue";
            this.SpeedValue.Size = new System.Drawing.Size(61, 23);
            this.SpeedValue.TabIndex = 7;
            this.SpeedValue.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // FramePerMeasure
            // 
            this.FramePerMeasure.Location = new System.Drawing.Point(138, 175);
            this.FramePerMeasure.Name = "FramePerMeasure";
            this.FramePerMeasure.Size = new System.Drawing.Size(61, 23);
            this.FramePerMeasure.TabIndex = 6;
            this.FramePerMeasure.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Label_FramePerMeasure
            // 
            this.Label_FramePerMeasure.AutoSize = true;
            this.Label_FramePerMeasure.Location = new System.Drawing.Point(12, 177);
            this.Label_FramePerMeasure.Name = "Label_FramePerMeasure";
            this.Label_FramePerMeasure.Size = new System.Drawing.Size(120, 16);
            this.Label_FramePerMeasure.TabIndex = 5;
            this.Label_FramePerMeasure.Text = "1Frameの小節数";
            // 
            // 最小音価
            // 
            this.最小音価.AutoSize = true;
            this.最小音価.Location = new System.Drawing.Point(12, 119);
            this.最小音価.Name = "最小音価";
            this.最小音価.Size = new System.Drawing.Size(72, 16);
            this.最小音価.TabIndex = 4;
            this.最小音価.Text = "最小音価";
            // 
            // MinimumNote
            // 
            this.MinimumNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinimumNote.FormattingEnabled = true;
            this.MinimumNote.Items.AddRange(new object[] {
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
            this.MinimumNote.Location = new System.Drawing.Point(138, 116);
            this.MinimumNote.Name = "MinimumNote";
            this.MinimumNote.Size = new System.Drawing.Size(114, 24);
            this.MinimumNote.TabIndex = 3;
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Location = new System.Drawing.Point(12, 148);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(50, 16);
            this.Speed.TabIndex = 2;
            this.Speed.Text = "Speed";
            // 
            // checkBox_拍子の変化でFrameを移行する
            // 
            this.checkBox_拍子の変化でFrameを移行する.AutoSize = true;
            this.checkBox_拍子の変化でFrameを移行する.Location = new System.Drawing.Point(12, 12);
            this.checkBox_拍子の変化でFrameを移行する.Name = "checkBox_拍子の変化でFrameを移行する";
            this.checkBox_拍子の変化でFrameを移行する.Size = new System.Drawing.Size(233, 20);
            this.checkBox_拍子の変化でFrameを移行する.TabIndex = 0;
            this.checkBox_拍子の変化でFrameを移行する.Text = "拍子の変化でFrameを移行する";
            this.checkBox_拍子の変化でFrameを移行する.UseVisualStyleBackColor = true;
            // 
            // DoneSettings
            // 
            this.DoneSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneSettings.Location = new System.Drawing.Point(201, 275);
            this.DoneSettings.Name = "DoneSettings";
            this.DoneSettings.Size = new System.Drawing.Size(75, 23);
            this.DoneSettings.TabIndex = 13;
            this.DoneSettings.Text = "決定";
            this.DoneSettings.UseVisualStyleBackColor = true;
            // 
            // SaveSettings
            // 
            this.SaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveSettings.Location = new System.Drawing.Point(10, 275);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(109, 23);
            this.SaveSettings.TabIndex = 14;
            this.SaveSettings.Text = "設定を保存";
            this.SaveSettings.UseVisualStyleBackColor = true;
            // 
            // BasicConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 310);
            this.Controls.Add(this.SaveSettings);
            this.Controls.Add(this.DoneSettings);
            this.Controls.Add(this.MaxRows);
            this.Controls.Add(this.MaxTimeSignature);
            this.Controls.Add(this.checkBox_未使用ChのOrderを00で埋める);
            this.Controls.Add(this.checkBox_拍子の変化でFrameを移行する);
            this.Controls.Add(this.checkBox_PATTERN00を使用しない);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.checkBox_連符をGxxで表現する);
            this.Controls.Add(this.MinimumNote);
            this.Controls.Add(this.SpeedValue);
            this.Controls.Add(this.最小音価);
            this.Controls.Add(this.FramePerMeasure);
            this.Controls.Add(this.Label_FramePerMeasure);
            this.Name = "BasicConfig";
            this.Text = "基本設定";
            ((System.ComponentModel.ISupportInitialize)(this.SpeedValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FramePerMeasure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label MaxRows;
        private System.Windows.Forms.Label MaxTimeSignature;
        private System.Windows.Forms.CheckBox checkBox_未使用ChのOrderを00で埋める;
        private System.Windows.Forms.CheckBox checkBox_PATTERN00を使用しない;
        private System.Windows.Forms.CheckBox checkBox_連符をGxxで表現する;
        private System.Windows.Forms.NumericUpDown SpeedValue;
        private System.Windows.Forms.NumericUpDown FramePerMeasure;
        private System.Windows.Forms.Label Label_FramePerMeasure;
        private System.Windows.Forms.Label 最小音価;
        private System.Windows.Forms.ComboBox MinimumNote;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.CheckBox checkBox_拍子の変化でFrameを移行する;
        private System.Windows.Forms.Button DoneSettings;
        private System.Windows.Forms.Button SaveSettings;
    }
}