namespace MIDI2FTM
{
    partial class AddEffectFxxWindow
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
            this.TrackerChannelList = new System.Windows.Forms.ComboBox();
            this.Label_Guide = new System.Windows.Forms.Label();
            this.Button_NotApply = new System.Windows.Forms.Button();
            this.Button_Apply = new System.Windows.Forms.Button();
            this.Label_Warning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TrackerChannelList
            // 
            this.TrackerChannelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrackerChannelList.FormattingEnabled = true;
            this.TrackerChannelList.Location = new System.Drawing.Point(12, 80);
            this.TrackerChannelList.Name = "TrackerChannelList";
            this.TrackerChannelList.Size = new System.Drawing.Size(297, 24);
            this.TrackerChannelList.TabIndex = 5;
            this.TrackerChannelList.SelectedIndexChanged += new System.EventHandler(this.TrackerChannelList_SelectedIndexChanged);
            // 
            // Label_Guide
            // 
            this.Label_Guide.AutoSize = true;
            this.Label_Guide.Location = new System.Drawing.Point(9, 40);
            this.Label_Guide.Name = "Label_Guide";
            this.Label_Guide.Size = new System.Drawing.Size(430, 16);
            this.Label_Guide.TabIndex = 6;
            this.Label_Guide.Text = "EffectFxx（テンポチェンジ）を適用するチャンネルを選択してください。";
            // 
            // Button_NotApply
            // 
            this.Button_NotApply.Location = new System.Drawing.Point(215, 176);
            this.Button_NotApply.Name = "Button_NotApply";
            this.Button_NotApply.Size = new System.Drawing.Size(115, 23);
            this.Button_NotApply.TabIndex = 7;
            this.Button_NotApply.Text = "適用しない";
            this.Button_NotApply.UseVisualStyleBackColor = true;
            this.Button_NotApply.Click += new System.EventHandler(this.Button_NotApply_Click);
            // 
            // Button_Apply
            // 
            this.Button_Apply.Location = new System.Drawing.Point(336, 176);
            this.Button_Apply.Name = "Button_Apply";
            this.Button_Apply.Size = new System.Drawing.Size(115, 23);
            this.Button_Apply.TabIndex = 8;
            this.Button_Apply.Text = "適用する";
            this.Button_Apply.UseVisualStyleBackColor = true;
            this.Button_Apply.Click += new System.EventHandler(this.Button_Apply_Click);
            // 
            // Label_Warning
            // 
            this.Label_Warning.AutoSize = true;
            this.Label_Warning.ForeColor = System.Drawing.Color.Red;
            this.Label_Warning.Location = new System.Drawing.Point(12, 126);
            this.Label_Warning.Name = "Label_Warning";
            this.Label_Warning.Size = new System.Drawing.Size(30, 16);
            this.Label_Warning.TabIndex = 9;
            this.Label_Warning.Text = "null";
            // 
            // AddEffectFxxWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 211);
            this.ControlBox = false;
            this.Controls.Add(this.Label_Warning);
            this.Controls.Add(this.Button_Apply);
            this.Controls.Add(this.Button_NotApply);
            this.Controls.Add(this.Label_Guide);
            this.Controls.Add(this.TrackerChannelList);
            this.Name = "AddEffectFxxWindow";
            this.Text = "EffectFxxを追加する";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TrackerChannelList;
        private System.Windows.Forms.Label Label_Guide;
        private System.Windows.Forms.Button Button_NotApply;
        private System.Windows.Forms.Button Button_Apply;
        private System.Windows.Forms.Label Label_Warning;
    }
}