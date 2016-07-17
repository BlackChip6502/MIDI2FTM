namespace MIDI2FTM
{
    partial class MainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.menuBarファイル = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイル_名前を付けて保存 = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorA = new System.Windows.Forms.ToolStripSeparator();
            this.ファイル_MIDIインポート = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイル_終了 = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorB = new System.Windows.Forms.ToolStripSeparator();
            this.menuBar編集 = new System.Windows.Forms.ToolStripMenuItem();
            this.編集_基本設定からやり直す = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBarヘルプ = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.TrackerList = new System.Windows.Forms.ListView();
            this.Rows = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pulse1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pulse2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Triangle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Noise = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DPCM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrackList = new System.Windows.Forms.ComboBox();
            this.チャンネル設定 = new System.Windows.Forms.GroupBox();
            this.CheckBox_LeftAlignedEffect = new System.Windows.Forms.CheckBox();
            this.CheckBox_EnableEffectGxx = new System.Windows.Forms.CheckBox();
            this.Label_音色番号 = new System.Windows.Forms.Label();
            this.NumericUpDown_InstrumentNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioButton_CCVolumeToVolume = new System.Windows.Forms.RadioButton();
            this.RadioButton_CCExpressionToVolume = new System.Windows.Forms.RadioButton();
            this.groupBox_同一Tickのノート優先度 = new System.Windows.Forms.GroupBox();
            this.RadioButton_LowNotePriority = new System.Windows.Forms.RadioButton();
            this.RadioButton_HighNotePriority = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioButton_LeadNotePriority = new System.Windows.Forms.RadioButton();
            this.RadioButton_BehindNotePriority = new System.Windows.Forms.RadioButton();
            this.CheckBox_EnableEffect4xx = new System.Windows.Forms.CheckBox();
            this.CheckBox_EnableEffectPxx = new System.Windows.Forms.CheckBox();
            this.CheckBox_EnableCCVolume = new System.Windows.Forms.CheckBox();
            this.CheckBox_EnableNoteVolume = new System.Windows.Forms.CheckBox();
            this.EventsList = new System.Windows.Forms.ListView();
            this.Mea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tick = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Event = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Button_Reset = new System.Windows.Forms.Button();
            this.TrackerChannelList = new System.Windows.Forms.ComboBox();
            this.Button_Convert = new System.Windows.Forms.Button();
            this.menuBar.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.チャンネル設定.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_InstrumentNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox_同一Tickのノート優先度.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBarファイル,
            this.menuBar編集,
            this.menuBarヘルプ});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1089, 30);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menuStrip2";
            // 
            // menuBarファイル
            // 
            this.menuBarファイル.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイル_名前を付けて保存,
            this.separatorA,
            this.ファイル_MIDIインポート,
            this.ファイル_終了,
            this.separatorB});
            this.menuBarファイル.Name = "menuBarファイル";
            this.menuBarファイル.Size = new System.Drawing.Size(84, 26);
            this.menuBarファイル.Text = "ファイル(&F)";
            // 
            // ファイル_名前を付けて保存
            // 
            this.ファイル_名前を付けて保存.Name = "ファイル_名前を付けて保存";
            this.ファイル_名前を付けて保存.Size = new System.Drawing.Size(235, 28);
            this.ファイル_名前を付けて保存.Text = "名前を付けて保存(&A)...";
            this.ファイル_名前を付けて保存.Click += new System.EventHandler(this.ファイル_名前を付けて保存_Click);
            // 
            // separatorA
            // 
            this.separatorA.Name = "separatorA";
            this.separatorA.Size = new System.Drawing.Size(232, 6);
            // 
            // ファイル_MIDIインポート
            // 
            this.ファイル_MIDIインポート.Name = "ファイル_MIDIインポート";
            this.ファイル_MIDIインポート.Size = new System.Drawing.Size(235, 28);
            this.ファイル_MIDIインポート.Text = "MIDIを開く(&M)...";
            this.ファイル_MIDIインポート.Click += new System.EventHandler(this.ファイル_MIDIを開く_Click);
            // 
            // ファイル_終了
            // 
            this.ファイル_終了.Name = "ファイル_終了";
            this.ファイル_終了.Size = new System.Drawing.Size(235, 28);
            this.ファイル_終了.Text = "終了(&X)";
            this.ファイル_終了.Click += new System.EventHandler(this.ファイル_終了_Click);
            // 
            // separatorB
            // 
            this.separatorB.Name = "separatorB";
            this.separatorB.Size = new System.Drawing.Size(232, 6);
            // 
            // menuBar編集
            // 
            this.menuBar編集.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.編集_基本設定からやり直す});
            this.menuBar編集.Name = "menuBar編集";
            this.menuBar編集.Size = new System.Drawing.Size(72, 26);
            this.menuBar編集.Text = "編集(&E)";
            // 
            // 編集_基本設定からやり直す
            // 
            this.編集_基本設定からやり直す.Enabled = false;
            this.編集_基本設定からやり直す.Name = "編集_基本設定からやり直す";
            this.編集_基本設定からやり直す.Size = new System.Drawing.Size(251, 28);
            this.編集_基本設定からやり直す.Text = "基本設定からやり直す(&R)";
            this.編集_基本設定からやり直す.Click += new System.EventHandler(this.編集_基本設定からやり直す_Click);
            // 
            // menuBarヘルプ
            // 
            this.menuBarヘルプ.Name = "menuBarヘルプ";
            this.menuBarヘルプ.Size = new System.Drawing.Size(81, 26);
            this.menuBarヘルプ.Text = "ヘルプ(&H)";
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel,
            this.ToolStripProgressBar});
            this.StatusStrip.Location = new System.Drawing.Point(0, 892);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1089, 23);
            this.StatusStrip.TabIndex = 4;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.AutoSize = false;
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(635, 18);
            this.ToolStripStatusLabel.Text = "null";
            this.ToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToolStripProgressBar
            // 
            this.ToolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripProgressBar.Name = "ToolStripProgressBar";
            this.ToolStripProgressBar.Size = new System.Drawing.Size(100, 17);
            this.ToolStripProgressBar.Step = 1;
            this.ToolStripProgressBar.Visible = false;
            // 
            // TrackerList
            // 
            this.TrackerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackerList.BackColor = System.Drawing.Color.Black;
            this.TrackerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Rows,
            this.Pulse1,
            this.Pulse2,
            this.Triangle,
            this.Noise,
            this.DPCM});
            this.TrackerList.Font = new System.Drawing.Font("ＭＳ ゴシック", 8.861538F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TrackerList.ForeColor = System.Drawing.Color.Lime;
            this.TrackerList.FullRowSelect = true;
            this.TrackerList.Location = new System.Drawing.Point(303, 3);
            this.TrackerList.MultiSelect = false;
            this.TrackerList.Name = "TrackerList";
            this.TrackerList.Size = new System.Drawing.Size(452, 856);
            this.TrackerList.TabIndex = 0;
            this.TrackerList.UseCompatibleStateImageBehavior = false;
            this.TrackerList.View = System.Windows.Forms.View.Details;
            // 
            // Rows
            // 
            this.Rows.Text = "Rows";
            this.Rows.Width = 80;
            // 
            // Pulse1
            // 
            this.Pulse1.Text = "Pulse 1";
            // 
            // Pulse2
            // 
            this.Pulse2.Text = "Pulse 2";
            // 
            // Triangle
            // 
            this.Triangle.Text = "Triangle";
            // 
            // Noise
            // 
            this.Noise.Text = "Noise";
            // 
            // DPCM
            // 
            this.DPCM.Text = "DPCM";
            // 
            // TrackList
            // 
            this.TrackList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrackList.FormattingEnabled = true;
            this.TrackList.Location = new System.Drawing.Point(3, 3);
            this.TrackList.Name = "TrackList";
            this.TrackList.Size = new System.Drawing.Size(325, 24);
            this.TrackList.TabIndex = 1;
            this.TrackList.SelectedIndexChanged += new System.EventHandler(this.TrackList_SelectedIndexChanged);
            // 
            // チャンネル設定
            // 
            this.チャンネル設定.Controls.Add(this.CheckBox_LeftAlignedEffect);
            this.チャンネル設定.Controls.Add(this.CheckBox_EnableEffectGxx);
            this.チャンネル設定.Controls.Add(this.Label_音色番号);
            this.チャンネル設定.Controls.Add(this.NumericUpDown_InstrumentNum);
            this.チャンネル設定.Controls.Add(this.groupBox2);
            this.チャンネル設定.Controls.Add(this.groupBox_同一Tickのノート優先度);
            this.チャンネル設定.Controls.Add(this.groupBox1);
            this.チャンネル設定.Controls.Add(this.CheckBox_EnableEffect4xx);
            this.チャンネル設定.Controls.Add(this.CheckBox_EnableEffectPxx);
            this.チャンネル設定.Controls.Add(this.CheckBox_EnableCCVolume);
            this.チャンネル設定.Controls.Add(this.CheckBox_EnableNoteVolume);
            this.チャンネル設定.Location = new System.Drawing.Point(3, 33);
            this.チャンネル設定.Name = "チャンネル設定";
            this.チャンネル設定.Size = new System.Drawing.Size(294, 551);
            this.チャンネル設定.TabIndex = 2;
            this.チャンネル設定.TabStop = false;
            this.チャンネル設定.Text = "チャンネル設定";
            // 
            // CheckBox_LeftAlignedEffect
            // 
            this.CheckBox_LeftAlignedEffect.AutoSize = true;
            this.CheckBox_LeftAlignedEffect.Location = new System.Drawing.Point(6, 270);
            this.CheckBox_LeftAlignedEffect.Name = "CheckBox_LeftAlignedEffect";
            this.CheckBox_LeftAlignedEffect.Size = new System.Drawing.Size(181, 20);
            this.CheckBox_LeftAlignedEffect.TabIndex = 23;
            this.CheckBox_LeftAlignedEffect.Text = "エフェクトを左詰めにする";
            this.CheckBox_LeftAlignedEffect.UseVisualStyleBackColor = true;
            this.CheckBox_LeftAlignedEffect.CheckedChanged += new System.EventHandler(this.CheckBox_LeftAlignedEffect_CheckedChanged);
            // 
            // CheckBox_EnableEffectGxx
            // 
            this.CheckBox_EnableEffectGxx.AutoSize = true;
            this.CheckBox_EnableEffectGxx.Location = new System.Drawing.Point(6, 192);
            this.CheckBox_EnableEffectGxx.Name = "CheckBox_EnableEffectGxx";
            this.CheckBox_EnableEffectGxx.Size = new System.Drawing.Size(211, 20);
            this.CheckBox_EnableEffectGxx.TabIndex = 22;
            this.CheckBox_EnableEffectGxx.Text = "連符をEffectGxxで表現する";
            this.CheckBox_EnableEffectGxx.UseVisualStyleBackColor = true;
            this.CheckBox_EnableEffectGxx.CheckedChanged += new System.EventHandler(this.CheckBox_EnableEffectGxx_CheckedChanged);
            // 
            // Label_音色番号
            // 
            this.Label_音色番号.AutoSize = true;
            this.Label_音色番号.Location = new System.Drawing.Point(9, 513);
            this.Label_音色番号.Name = "Label_音色番号";
            this.Label_音色番号.Size = new System.Drawing.Size(81, 16);
            this.Label_音色番号.TabIndex = 21;
            this.Label_音色番号.Text = "Instrument";
            // 
            // NumericUpDown_InstrumentNum
            // 
            this.NumericUpDown_InstrumentNum.Hexadecimal = true;
            this.NumericUpDown_InstrumentNum.Location = new System.Drawing.Point(98, 511);
            this.NumericUpDown_InstrumentNum.Name = "NumericUpDown_InstrumentNum";
            this.NumericUpDown_InstrumentNum.Size = new System.Drawing.Size(68, 23);
            this.NumericUpDown_InstrumentNum.TabIndex = 6;
            this.NumericUpDown_InstrumentNum.ValueChanged += new System.EventHandler(this.NumericUpDown_InstrumentNum_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadioButton_CCVolumeToVolume);
            this.groupBox2.Controls.Add(this.RadioButton_CCExpressionToVolume);
            this.groupBox2.Location = new System.Drawing.Point(6, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 80);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "適用するコントールチェンジ";
            // 
            // RadioButton_CCVolumeToVolume
            // 
            this.RadioButton_CCVolumeToVolume.AutoSize = true;
            this.RadioButton_CCVolumeToVolume.Enabled = false;
            this.RadioButton_CCVolumeToVolume.Location = new System.Drawing.Point(6, 22);
            this.RadioButton_CCVolumeToVolume.Name = "RadioButton_CCVolumeToVolume";
            this.RadioButton_CCVolumeToVolume.Size = new System.Drawing.Size(122, 20);
            this.RadioButton_CCVolumeToVolume.TabIndex = 6;
            this.RadioButton_CCVolumeToVolume.TabStop = true;
            this.RadioButton_CCVolumeToVolume.Text = "Volumeを適用";
            this.RadioButton_CCVolumeToVolume.UseVisualStyleBackColor = true;
            this.RadioButton_CCVolumeToVolume.CheckedChanged += new System.EventHandler(this.RadioButton_CCVolumeToVolume_CheckedChanged);
            // 
            // RadioButton_CCExpressionToVolume
            // 
            this.RadioButton_CCExpressionToVolume.AutoSize = true;
            this.RadioButton_CCExpressionToVolume.Enabled = false;
            this.RadioButton_CCExpressionToVolume.Location = new System.Drawing.Point(6, 48);
            this.RadioButton_CCExpressionToVolume.Name = "RadioButton_CCExpressionToVolume";
            this.RadioButton_CCExpressionToVolume.Size = new System.Drawing.Size(144, 20);
            this.RadioButton_CCExpressionToVolume.TabIndex = 7;
            this.RadioButton_CCExpressionToVolume.TabStop = true;
            this.RadioButton_CCExpressionToVolume.Text = "Expressionを適用";
            this.RadioButton_CCExpressionToVolume.UseVisualStyleBackColor = true;
            this.RadioButton_CCExpressionToVolume.CheckedChanged += new System.EventHandler(this.RadioButton_CCExpressionToVolume_CheckedChanged);
            // 
            // groupBox_同一Tickのノート優先度
            // 
            this.groupBox_同一Tickのノート優先度.Controls.Add(this.RadioButton_LowNotePriority);
            this.groupBox_同一Tickのノート優先度.Controls.Add(this.RadioButton_HighNotePriority);
            this.groupBox_同一Tickのノート優先度.Location = new System.Drawing.Point(6, 312);
            this.groupBox_同一Tickのノート優先度.Name = "groupBox_同一Tickのノート優先度";
            this.groupBox_同一Tickのノート優先度.Size = new System.Drawing.Size(281, 80);
            this.groupBox_同一Tickのノート優先度.TabIndex = 18;
            this.groupBox_同一Tickのノート優先度.TabStop = false;
            this.groupBox_同一Tickのノート優先度.Text = "同一Tickのノート優先度";
            // 
            // RadioButton_LowNotePriority
            // 
            this.RadioButton_LowNotePriority.AutoSize = true;
            this.RadioButton_LowNotePriority.Location = new System.Drawing.Point(6, 48);
            this.RadioButton_LowNotePriority.Name = "RadioButton_LowNotePriority";
            this.RadioButton_LowNotePriority.Size = new System.Drawing.Size(154, 20);
            this.RadioButton_LowNotePriority.TabIndex = 15;
            this.RadioButton_LowNotePriority.TabStop = true;
            this.RadioButton_LowNotePriority.Text = "一番低い音のノート";
            this.RadioButton_LowNotePriority.UseVisualStyleBackColor = true;
            this.RadioButton_LowNotePriority.CheckedChanged += new System.EventHandler(this.RadioButton_LowNotePriority_CheckedChanged);
            // 
            // RadioButton_HighNotePriority
            // 
            this.RadioButton_HighNotePriority.AutoSize = true;
            this.RadioButton_HighNotePriority.Location = new System.Drawing.Point(6, 22);
            this.RadioButton_HighNotePriority.Name = "RadioButton_HighNotePriority";
            this.RadioButton_HighNotePriority.Size = new System.Drawing.Size(154, 20);
            this.RadioButton_HighNotePriority.TabIndex = 16;
            this.RadioButton_HighNotePriority.TabStop = true;
            this.RadioButton_HighNotePriority.Text = "一番高い音のノート";
            this.RadioButton_HighNotePriority.UseVisualStyleBackColor = true;
            this.RadioButton_HighNotePriority.CheckedChanged += new System.EventHandler(this.RadioButton_HighNotePriority_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioButton_LeadNotePriority);
            this.groupBox1.Controls.Add(this.RadioButton_BehindNotePriority);
            this.groupBox1.Location = new System.Drawing.Point(6, 414);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 80);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "同一Rowのイベント優先度";
            // 
            // RadioButton_LeadNotePriority
            // 
            this.RadioButton_LeadNotePriority.AutoSize = true;
            this.RadioButton_LeadNotePriority.Location = new System.Drawing.Point(6, 22);
            this.RadioButton_LeadNotePriority.Name = "RadioButton_LeadNotePriority";
            this.RadioButton_LeadNotePriority.Size = new System.Drawing.Size(106, 20);
            this.RadioButton_LeadNotePriority.TabIndex = 15;
            this.RadioButton_LeadNotePriority.TabStop = true;
            this.RadioButton_LeadNotePriority.Text = "先のイベント";
            this.RadioButton_LeadNotePriority.UseVisualStyleBackColor = true;
            this.RadioButton_LeadNotePriority.CheckedChanged += new System.EventHandler(this.RadioButton_LeadNotePriority_CheckedChanged);
            // 
            // RadioButton_BehindNotePriority
            // 
            this.RadioButton_BehindNotePriority.AutoSize = true;
            this.RadioButton_BehindNotePriority.Location = new System.Drawing.Point(6, 48);
            this.RadioButton_BehindNotePriority.Name = "RadioButton_BehindNotePriority";
            this.RadioButton_BehindNotePriority.Size = new System.Drawing.Size(106, 20);
            this.RadioButton_BehindNotePriority.TabIndex = 16;
            this.RadioButton_BehindNotePriority.TabStop = true;
            this.RadioButton_BehindNotePriority.Text = "後のイベント";
            this.RadioButton_BehindNotePriority.UseVisualStyleBackColor = true;
            this.RadioButton_BehindNotePriority.CheckedChanged += new System.EventHandler(this.RadioButton_BehindNotePriority_CheckedChanged);
            // 
            // CheckBox_EnableEffect4xx
            // 
            this.CheckBox_EnableEffect4xx.AutoSize = true;
            this.CheckBox_EnableEffect4xx.Location = new System.Drawing.Point(6, 218);
            this.CheckBox_EnableEffect4xx.Name = "CheckBox_EnableEffect4xx";
            this.CheckBox_EnableEffect4xx.Size = new System.Drawing.Size(248, 20);
            this.CheckBox_EnableEffect4xx.TabIndex = 9;
            this.CheckBox_EnableEffect4xx.Text = "ModulationをEffect4xxで表現する";
            this.CheckBox_EnableEffect4xx.UseVisualStyleBackColor = true;
            this.CheckBox_EnableEffect4xx.CheckedChanged += new System.EventHandler(this.CheckBox_EnableEffect4xx_CheckedChanged);
            // 
            // CheckBox_EnableEffectPxx
            // 
            this.CheckBox_EnableEffectPxx.AutoSize = true;
            this.CheckBox_EnableEffectPxx.Location = new System.Drawing.Point(6, 244);
            this.CheckBox_EnableEffectPxx.Name = "CheckBox_EnableEffectPxx";
            this.CheckBox_EnableEffectPxx.Size = new System.Drawing.Size(247, 20);
            this.CheckBox_EnableEffectPxx.TabIndex = 8;
            this.CheckBox_EnableEffectPxx.Text = "PitchBendをEffectPxxで表現する";
            this.CheckBox_EnableEffectPxx.UseVisualStyleBackColor = true;
            this.CheckBox_EnableEffectPxx.CheckedChanged += new System.EventHandler(this.CheckBox_EnableEffectPxx_CheckedChanged);
            // 
            // CheckBox_EnableCCVolume
            // 
            this.CheckBox_EnableCCVolume.AutoSize = true;
            this.CheckBox_EnableCCVolume.Location = new System.Drawing.Point(6, 64);
            this.CheckBox_EnableCCVolume.Name = "CheckBox_EnableCCVolume";
            this.CheckBox_EnableCCVolume.Size = new System.Drawing.Size(186, 20);
            this.CheckBox_EnableCCVolume.TabIndex = 5;
            this.CheckBox_EnableCCVolume.Text = "ノート以外の音量を有効";
            this.CheckBox_EnableCCVolume.UseVisualStyleBackColor = true;
            this.CheckBox_EnableCCVolume.CheckedChanged += new System.EventHandler(this.CheckBox_EnableCCVolume_CheckedChanged);
            // 
            // CheckBox_EnableNoteVolume
            // 
            this.CheckBox_EnableNoteVolume.AutoSize = true;
            this.CheckBox_EnableNoteVolume.Location = new System.Drawing.Point(6, 22);
            this.CheckBox_EnableNoteVolume.Name = "CheckBox_EnableNoteVolume";
            this.CheckBox_EnableNoteVolume.Size = new System.Drawing.Size(205, 20);
            this.CheckBox_EnableNoteVolume.TabIndex = 0;
            this.CheckBox_EnableNoteVolume.Text = "ノートオンのベロシティを有効";
            this.CheckBox_EnableNoteVolume.UseVisualStyleBackColor = true;
            this.CheckBox_EnableNoteVolume.CheckedChanged += new System.EventHandler(this.CheckBox_EnableNoteVolume_CheckedChanged);
            // 
            // EventsList
            // 
            this.EventsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EventsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Mea,
            this.Tick,
            this.Event,
            this.Gate,
            this.Value});
            this.EventsList.Font = new System.Drawing.Font("ＭＳ ゴシック", 8.861538F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EventsList.FullRowSelect = true;
            this.EventsList.Location = new System.Drawing.Point(3, 30);
            this.EventsList.MultiSelect = false;
            this.EventsList.Name = "EventsList";
            this.EventsList.Size = new System.Drawing.Size(325, 829);
            this.EventsList.TabIndex = 3;
            this.EventsList.UseCompatibleStateImageBehavior = false;
            this.EventsList.View = System.Windows.Forms.View.Details;
            // 
            // Mea
            // 
            this.Mea.Text = "Mea";
            this.Mea.Width = 50;
            // 
            // Tick
            // 
            this.Tick.Text = "Tick";
            this.Tick.Width = 50;
            // 
            // Event
            // 
            this.Event.Text = "Event";
            this.Event.Width = 90;
            // 
            // Gate
            // 
            this.Gate.Text = "Gate";
            this.Gate.Width = 50;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TrackList);
            this.panel1.Controls.Add(this.EventsList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 862);
            this.panel1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(328, 30);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 862);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Button_Reset);
            this.panel2.Controls.Add(this.TrackerChannelList);
            this.panel2.Controls.Add(this.Button_Convert);
            this.panel2.Controls.Add(this.チャンネル設定);
            this.panel2.Controls.Add(this.TrackerList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(331, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 862);
            this.panel2.TabIndex = 7;
            // 
            // Button_Reset
            // 
            this.Button_Reset.Enabled = false;
            this.Button_Reset.Location = new System.Drawing.Point(9, 590);
            this.Button_Reset.Name = "Button_Reset";
            this.Button_Reset.Size = new System.Drawing.Size(103, 23);
            this.Button_Reset.TabIndex = 5;
            this.Button_Reset.Text = "リセット";
            this.Button_Reset.UseVisualStyleBackColor = true;
            this.Button_Reset.Click += new System.EventHandler(this.Button_Reset_Click);
            // 
            // TrackerChannelList
            // 
            this.TrackerChannelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrackerChannelList.FormattingEnabled = true;
            this.TrackerChannelList.Location = new System.Drawing.Point(0, 3);
            this.TrackerChannelList.Name = "TrackerChannelList";
            this.TrackerChannelList.Size = new System.Drawing.Size(297, 24);
            this.TrackerChannelList.TabIndex = 4;
            // 
            // Button_Convert
            // 
            this.Button_Convert.Enabled = false;
            this.Button_Convert.Location = new System.Drawing.Point(187, 590);
            this.Button_Convert.Name = "Button_Convert";
            this.Button_Convert.Size = new System.Drawing.Size(103, 23);
            this.Button_Convert.TabIndex = 3;
            this.Button_Convert.Text = "コンバート";
            this.Button_Convert.UseVisualStyleBackColor = true;
            this.Button_Convert.Click += new System.EventHandler(this.Button_Convert_Click);
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(1089, 915);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "MainWindow";
            this.Text = "MIDI2FTM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.チャンネル設定.ResumeLayout(false);
            this.チャンネル設定.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_InstrumentNum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_同一Tickのノート優先度.ResumeLayout(false);
            this.groupBox_同一Tickのノート優先度.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;

        private System.Windows.Forms.ToolStripMenuItem menuBar編集;
        private System.Windows.Forms.ToolStripMenuItem ファイル_名前を付けて保存;
        private System.Windows.Forms.ToolStripSeparator separatorA;
        private System.Windows.Forms.ToolStripMenuItem ファイル_MIDIインポート;
        private System.Windows.Forms.ToolStripSeparator separatorB;
        private System.Windows.Forms.ToolStripMenuItem ファイル_終了;
        private System.Windows.Forms.ToolStripMenuItem menuBarヘルプ;
        private System.Windows.Forms.ToolStripMenuItem menuBarファイル;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ListView TrackerList;
        private System.Windows.Forms.ColumnHeader Pulse1;
        private System.Windows.Forms.ColumnHeader Pulse2;
        private System.Windows.Forms.ColumnHeader Triangle;
        private System.Windows.Forms.ColumnHeader DPCM;
        private System.Windows.Forms.ComboBox TrackList;
        private System.Windows.Forms.GroupBox チャンネル設定;
        private System.Windows.Forms.CheckBox CheckBox_EnableNoteVolume;
        private System.Windows.Forms.ListView EventsList;
        private System.Windows.Forms.ColumnHeader Mea;
        private System.Windows.Forms.ColumnHeader Tick;
        private System.Windows.Forms.ColumnHeader Event;
        private System.Windows.Forms.ColumnHeader Gate;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton RadioButton_BehindNotePriority;
        private System.Windows.Forms.RadioButton RadioButton_LeadNotePriority;
        private System.Windows.Forms.CheckBox CheckBox_EnableEffect4xx;
        private System.Windows.Forms.CheckBox CheckBox_EnableEffectPxx;
        private System.Windows.Forms.RadioButton RadioButton_CCExpressionToVolume;
        private System.Windows.Forms.RadioButton RadioButton_CCVolumeToVolume;
        private System.Windows.Forms.CheckBox CheckBox_EnableCCVolume;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox_同一Tickのノート優先度;
        private System.Windows.Forms.RadioButton RadioButton_LowNotePriority;
        private System.Windows.Forms.RadioButton RadioButton_HighNotePriority;
        private System.Windows.Forms.ComboBox TrackerChannelList;
        private System.Windows.Forms.Button Button_Convert;
        private System.Windows.Forms.Button Button_Reset;
        private System.Windows.Forms.ColumnHeader Rows;
        private System.Windows.Forms.ColumnHeader Noise;
        private System.Windows.Forms.Label Label_音色番号;
        private System.Windows.Forms.NumericUpDown NumericUpDown_InstrumentNum;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
        private System.Windows.Forms.CheckBox CheckBox_EnableEffectGxx;
        private System.Windows.Forms.CheckBox CheckBox_LeftAlignedEffect;
        private System.Windows.Forms.ToolStripMenuItem 編集_基本設定からやり直す;
    }
}

