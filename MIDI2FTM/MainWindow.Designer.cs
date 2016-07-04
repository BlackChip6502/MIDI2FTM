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
            this.ファイル_新規作成 = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイル_開く = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイル_上書き保存 = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイル_名前を付けて保存 = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorA = new System.Windows.Forms.ToolStripSeparator();
            this.ファイル_MIDIインポート = new System.Windows.Forms.ToolStripMenuItem();
            this.ファイル_FTMエクスポート = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorB = new System.Windows.Forms.ToolStripSeparator();
            this.ファイル_終了 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBar編集 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBar表示 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBarヘルプ = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TrackerList = new System.Windows.Forms.ListView();
            this.Rows = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pulse1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pulse2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Triangle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Noise = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DPCM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TrackList = new System.Windows.Forms.ComboBox();
            this.チャンネル設定 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton_ボリュームで表現する = new System.Windows.Forms.RadioButton();
            this.radioButton_NoteCutで表現する = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_CCVolumeを適用 = new System.Windows.Forms.RadioButton();
            this.radioButton_CCExpressionを適用 = new System.Windows.Forms.RadioButton();
            this.groupBox_同一Tickのノート優先度 = new System.Windows.Forms.GroupBox();
            this.radioButton_一番低いノート = new System.Windows.Forms.RadioButton();
            this.radioButton_一番高いノート = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_先のノート = new System.Windows.Forms.RadioButton();
            this.radioButton_後のノート = new System.Windows.Forms.RadioButton();
            this.checkBox_テンポチェンジをFxxで表現する = new System.Windows.Forms.CheckBox();
            this.checkBox_CCModulationを4xx7xxで表現する = new System.Windows.Forms.CheckBox();
            this.checkBox_PitchBendを1xx2xxで表現する = new System.Windows.Forms.CheckBox();
            this.checkBox_ノート以外のボリュームを有効 = new System.Windows.Forms.CheckBox();
            this.checkBox_ノートオフを有効 = new System.Windows.Forms.CheckBox();
            this.checkBox_ノートオンのボリュームを有効 = new System.Windows.Forms.CheckBox();
            this.EventsList = new System.Windows.Forms.ListView();
            this.Mea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tick = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Event = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.TrackerChannelList = new System.Windows.Forms.ComboBox();
            this.Button_Convert = new System.Windows.Forms.Button();
            this.menuBar.SuspendLayout();
            this.チャンネル設定.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.menuBar表示,
            this.menuBarヘルプ});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1029, 29);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menuStrip2";
            // 
            // menuBarファイル
            // 
            this.menuBarファイル.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイル_新規作成,
            this.ファイル_開く,
            this.ファイル_上書き保存,
            this.ファイル_名前を付けて保存,
            this.separatorA,
            this.ファイル_MIDIインポート,
            this.ファイル_FTMエクスポート,
            this.separatorB,
            this.ファイル_終了});
            this.menuBarファイル.Name = "menuBarファイル";
            this.menuBarファイル.Size = new System.Drawing.Size(84, 25);
            this.menuBarファイル.Text = "ファイル(&F)";
            // 
            // ファイル_新規作成
            // 
            this.ファイル_新規作成.Name = "ファイル_新規作成";
            this.ファイル_新規作成.Size = new System.Drawing.Size(235, 28);
            this.ファイル_新規作成.Text = "新規作成(&N)";
            this.ファイル_新規作成.Click += new System.EventHandler(this.ファイル_新規作成_Click);
            // 
            // ファイル_開く
            // 
            this.ファイル_開く.Name = "ファイル_開く";
            this.ファイル_開く.Size = new System.Drawing.Size(235, 28);
            this.ファイル_開く.Text = "開く(&O)...";
            this.ファイル_開く.Click += new System.EventHandler(this.ファイル_開く_Click);
            // 
            // ファイル_上書き保存
            // 
            this.ファイル_上書き保存.Name = "ファイル_上書き保存";
            this.ファイル_上書き保存.Size = new System.Drawing.Size(235, 28);
            this.ファイル_上書き保存.Text = "上書き保存(&S)";
            this.ファイル_上書き保存.Click += new System.EventHandler(this.ファイル_上書き保存_Click);
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
            this.ファイル_MIDIインポート.Text = "MIDIインポート(&M)...";
            this.ファイル_MIDIインポート.Click += new System.EventHandler(this.ファイル_MIDIインポート_Click);
            // 
            // ファイル_FTMエクスポート
            // 
            this.ファイル_FTMエクスポート.Name = "ファイル_FTMエクスポート";
            this.ファイル_FTMエクスポート.Size = new System.Drawing.Size(235, 28);
            this.ファイル_FTMエクスポート.Text = "FTMエクスポート(&F)";
            this.ファイル_FTMエクスポート.Click += new System.EventHandler(this.ファイル_FTMエクスポート_Click);
            // 
            // separatorB
            // 
            this.separatorB.Name = "separatorB";
            this.separatorB.Size = new System.Drawing.Size(232, 6);
            // 
            // ファイル_終了
            // 
            this.ファイル_終了.Name = "ファイル_終了";
            this.ファイル_終了.Size = new System.Drawing.Size(235, 28);
            this.ファイル_終了.Text = "終了(&X)";
            this.ファイル_終了.Click += new System.EventHandler(this.ファイル_終了_Click);
            // 
            // menuBar編集
            // 
            this.menuBar編集.Name = "menuBar編集";
            this.menuBar編集.Size = new System.Drawing.Size(72, 25);
            this.menuBar編集.Text = "編集(&E)";
            // 
            // menuBar表示
            // 
            this.menuBar表示.Name = "menuBar表示";
            this.menuBar表示.Size = new System.Drawing.Size(74, 25);
            this.menuBar表示.Text = "表示(&V)";
            // 
            // menuBarヘルプ
            // 
            this.menuBarヘルプ.Name = "menuBarヘルプ";
            this.menuBarヘルプ.Size = new System.Drawing.Size(81, 25);
            this.menuBarヘルプ.Text = "ヘルプ(&H)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.statusStrip1.Location = new System.Drawing.Point(0, 816);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1029, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
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
            this.TrackerList.Size = new System.Drawing.Size(392, 781);
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
            this.チャンネル設定.Controls.Add(this.groupBox3);
            this.チャンネル設定.Controls.Add(this.groupBox2);
            this.チャンネル設定.Controls.Add(this.groupBox_同一Tickのノート優先度);
            this.チャンネル設定.Controls.Add(this.groupBox1);
            this.チャンネル設定.Controls.Add(this.checkBox_テンポチェンジをFxxで表現する);
            this.チャンネル設定.Controls.Add(this.checkBox_CCModulationを4xx7xxで表現する);
            this.チャンネル設定.Controls.Add(this.checkBox_PitchBendを1xx2xxで表現する);
            this.チャンネル設定.Controls.Add(this.checkBox_ノート以外のボリュームを有効);
            this.チャンネル設定.Controls.Add(this.checkBox_ノートオフを有効);
            this.チャンネル設定.Controls.Add(this.checkBox_ノートオンのボリュームを有効);
            this.チャンネル設定.Location = new System.Drawing.Point(3, 33);
            this.チャンネル設定.Name = "チャンネル設定";
            this.チャンネル設定.Size = new System.Drawing.Size(294, 655);
            this.チャンネル設定.TabIndex = 2;
            this.チャンネル設定.TabStop = false;
            this.チャンネル設定.Text = "チャンネル設定";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton_ボリュームで表現する);
            this.groupBox3.Controls.Add(this.radioButton_NoteCutで表現する);
            this.groupBox3.Location = new System.Drawing.Point(6, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 80);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "表現方法";
            // 
            // radioButton_ボリュームで表現する
            // 
            this.radioButton_ボリュームで表現する.AutoSize = true;
            this.radioButton_ボリュームで表現する.Location = new System.Drawing.Point(6, 22);
            this.radioButton_ボリュームで表現する.Name = "radioButton_ボリュームで表現する";
            this.radioButton_ボリュームで表現する.Size = new System.Drawing.Size(159, 20);
            this.radioButton_ボリュームで表現する.TabIndex = 2;
            this.radioButton_ボリュームで表現する.TabStop = true;
            this.radioButton_ボリュームで表現する.Text = "ボリュームで表現する";
            this.radioButton_ボリュームで表現する.UseVisualStyleBackColor = true;
            // 
            // radioButton_NoteCutで表現する
            // 
            this.radioButton_NoteCutで表現する.AutoSize = true;
            this.radioButton_NoteCutで表現する.Location = new System.Drawing.Point(6, 48);
            this.radioButton_NoteCutで表現する.Name = "radioButton_NoteCutで表現する";
            this.radioButton_NoteCutで表現する.Size = new System.Drawing.Size(157, 20);
            this.radioButton_NoteCutで表現する.TabIndex = 3;
            this.radioButton_NoteCutで表現する.TabStop = true;
            this.radioButton_NoteCutで表現する.Text = "NoteCutで表現する";
            this.radioButton_NoteCutで表現する.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_CCVolumeを適用);
            this.groupBox2.Controls.Add(this.radioButton_CCExpressionを適用);
            this.groupBox2.Location = new System.Drawing.Point(6, 342);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 80);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "適用するコントールチェンジ";
            // 
            // radioButton_CCVolumeを適用
            // 
            this.radioButton_CCVolumeを適用.AutoSize = true;
            this.radioButton_CCVolumeを適用.Location = new System.Drawing.Point(6, 22);
            this.radioButton_CCVolumeを適用.Name = "radioButton_CCVolumeを適用";
            this.radioButton_CCVolumeを適用.Size = new System.Drawing.Size(144, 20);
            this.radioButton_CCVolumeを適用.TabIndex = 6;
            this.radioButton_CCVolumeを適用.TabStop = true;
            this.radioButton_CCVolumeを適用.Text = "CCVolumeを適用";
            this.radioButton_CCVolumeを適用.UseVisualStyleBackColor = true;
            // 
            // radioButton_CCExpressionを適用
            // 
            this.radioButton_CCExpressionを適用.AutoSize = true;
            this.radioButton_CCExpressionを適用.Location = new System.Drawing.Point(6, 48);
            this.radioButton_CCExpressionを適用.Name = "radioButton_CCExpressionを適用";
            this.radioButton_CCExpressionを適用.Size = new System.Drawing.Size(166, 20);
            this.radioButton_CCExpressionを適用.TabIndex = 7;
            this.radioButton_CCExpressionを適用.TabStop = true;
            this.radioButton_CCExpressionを適用.Text = "CCExpressionを適用";
            this.radioButton_CCExpressionを適用.UseVisualStyleBackColor = true;
            // 
            // groupBox_同一Tickのノート優先度
            // 
            this.groupBox_同一Tickのノート優先度.Controls.Add(this.radioButton_一番低いノート);
            this.groupBox_同一Tickのノート優先度.Controls.Add(this.radioButton_一番高いノート);
            this.groupBox_同一Tickのノート優先度.Location = new System.Drawing.Point(3, 454);
            this.groupBox_同一Tickのノート優先度.Name = "groupBox_同一Tickのノート優先度";
            this.groupBox_同一Tickのノート優先度.Size = new System.Drawing.Size(281, 80);
            this.groupBox_同一Tickのノート優先度.TabIndex = 18;
            this.groupBox_同一Tickのノート優先度.TabStop = false;
            this.groupBox_同一Tickのノート優先度.Text = "同一Tickのノート優先度";
            // 
            // radioButton_一番低いノート
            // 
            this.radioButton_一番低いノート.AutoSize = true;
            this.radioButton_一番低いノート.Location = new System.Drawing.Point(6, 22);
            this.radioButton_一番低いノート.Name = "radioButton_一番低いノート";
            this.radioButton_一番低いノート.Size = new System.Drawing.Size(125, 20);
            this.radioButton_一番低いノート.TabIndex = 15;
            this.radioButton_一番低いノート.TabStop = true;
            this.radioButton_一番低いノート.Text = "一番低いノート";
            this.radioButton_一番低いノート.UseVisualStyleBackColor = true;
            // 
            // radioButton_一番高いノート
            // 
            this.radioButton_一番高いノート.AutoSize = true;
            this.radioButton_一番高いノート.Location = new System.Drawing.Point(6, 48);
            this.radioButton_一番高いノート.Name = "radioButton_一番高いノート";
            this.radioButton_一番高いノート.Size = new System.Drawing.Size(125, 20);
            this.radioButton_一番高いノート.TabIndex = 16;
            this.radioButton_一番高いノート.TabStop = true;
            this.radioButton_一番高いノート.Text = "一番高いノート";
            this.radioButton_一番高いノート.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_先のノート);
            this.groupBox1.Controls.Add(this.radioButton_後のノート);
            this.groupBox1.Location = new System.Drawing.Point(3, 566);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 80);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "丸め込みによる同一Rowのノート優先度";
            // 
            // radioButton_先のノート
            // 
            this.radioButton_先のノート.AutoSize = true;
            this.radioButton_先のノート.Location = new System.Drawing.Point(6, 22);
            this.radioButton_先のノート.Name = "radioButton_先のノート";
            this.radioButton_先のノート.Size = new System.Drawing.Size(93, 20);
            this.radioButton_先のノート.TabIndex = 15;
            this.radioButton_先のノート.TabStop = true;
            this.radioButton_先のノート.Text = "先のノート";
            this.radioButton_先のノート.UseVisualStyleBackColor = true;
            // 
            // radioButton_後のノート
            // 
            this.radioButton_後のノート.AutoSize = true;
            this.radioButton_後のノート.Location = new System.Drawing.Point(6, 48);
            this.radioButton_後のノート.Name = "radioButton_後のノート";
            this.radioButton_後のノート.Size = new System.Drawing.Size(93, 20);
            this.radioButton_後のノート.TabIndex = 16;
            this.radioButton_後のノート.TabStop = true;
            this.radioButton_後のノート.Text = "後のノート";
            this.radioButton_後のノート.UseVisualStyleBackColor = true;
            // 
            // checkBox_テンポチェンジをFxxで表現する
            // 
            this.checkBox_テンポチェンジをFxxで表現する.AutoSize = true;
            this.checkBox_テンポチェンジをFxxで表現する.Location = new System.Drawing.Point(3, 264);
            this.checkBox_テンポチェンジをFxxで表現する.Name = "checkBox_テンポチェンジをFxxで表現する";
            this.checkBox_テンポチェンジをFxxで表現する.Size = new System.Drawing.Size(221, 20);
            this.checkBox_テンポチェンジをFxxで表現する.TabIndex = 10;
            this.checkBox_テンポチェンジをFxxで表現する.Text = "テンポチェンジをFxxで表現する";
            this.checkBox_テンポチェンジをFxxで表現する.UseVisualStyleBackColor = true;
            // 
            // checkBox_CCModulationを4xx7xxで表現する
            // 
            this.checkBox_CCModulationを4xx7xxで表現する.AutoSize = true;
            this.checkBox_CCModulationを4xx7xxで表現する.Location = new System.Drawing.Point(3, 238);
            this.checkBox_CCModulationを4xx7xxで表現する.Name = "checkBox_CCModulationを4xx7xxで表現する";
            this.checkBox_CCModulationを4xx7xxで表現する.Size = new System.Drawing.Size(256, 20);
            this.checkBox_CCModulationを4xx7xxで表現する.TabIndex = 9;
            this.checkBox_CCModulationを4xx7xxで表現する.Text = "CCModulationを4xx 7xxで表現する";
            this.checkBox_CCModulationを4xx7xxで表現する.UseVisualStyleBackColor = true;
            // 
            // checkBox_PitchBendを1xx2xxで表現する
            // 
            this.checkBox_PitchBendを1xx2xxで表現する.AutoSize = true;
            this.checkBox_PitchBendを1xx2xxで表現する.Location = new System.Drawing.Point(3, 212);
            this.checkBox_PitchBendを1xx2xxで表現する.Name = "checkBox_PitchBendを1xx2xxで表現する";
            this.checkBox_PitchBendを1xx2xxで表現する.Size = new System.Drawing.Size(231, 20);
            this.checkBox_PitchBendを1xx2xxで表現する.TabIndex = 8;
            this.checkBox_PitchBendを1xx2xxで表現する.Text = "PitchBendを1xx 2xxで表現する";
            this.checkBox_PitchBendを1xx2xxで表現する.UseVisualStyleBackColor = true;
            // 
            // checkBox_ノート以外のボリュームを有効
            // 
            this.checkBox_ノート以外のボリュームを有効.AutoSize = true;
            this.checkBox_ノート以外のボリュームを有効.Location = new System.Drawing.Point(3, 316);
            this.checkBox_ノート以外のボリュームを有効.Name = "checkBox_ノート以外のボリュームを有効";
            this.checkBox_ノート以外のボリュームを有効.Size = new System.Drawing.Size(213, 20);
            this.checkBox_ノート以外のボリュームを有効.TabIndex = 5;
            this.checkBox_ノート以外のボリュームを有効.Text = "ノート以外のボリュームを有効";
            this.checkBox_ノート以外のボリュームを有効.UseVisualStyleBackColor = true;
            // 
            // checkBox_ノートオフを有効
            // 
            this.checkBox_ノートオフを有効.AutoSize = true;
            this.checkBox_ノートオフを有効.Location = new System.Drawing.Point(3, 74);
            this.checkBox_ノートオフを有効.Name = "checkBox_ノートオフを有効";
            this.checkBox_ノートオフを有効.Size = new System.Drawing.Size(132, 20);
            this.checkBox_ノートオフを有効.TabIndex = 1;
            this.checkBox_ノートオフを有効.Text = "ノートオフを有効";
            this.checkBox_ノートオフを有効.UseVisualStyleBackColor = true;
            // 
            // checkBox_ノートオンのボリュームを有効
            // 
            this.checkBox_ノートオンのボリュームを有効.AutoSize = true;
            this.checkBox_ノートオンのボリュームを有効.Location = new System.Drawing.Point(3, 22);
            this.checkBox_ノートオンのボリュームを有効.Name = "checkBox_ノートオンのボリュームを有効";
            this.checkBox_ノートオンのボリュームを有効.Size = new System.Drawing.Size(205, 20);
            this.checkBox_ノートオンのボリュームを有効.TabIndex = 0;
            this.checkBox_ノートオンのボリュームを有効.Text = "ノートオンのボリュームを有効";
            this.checkBox_ノートオンのボリュームを有効.UseVisualStyleBackColor = true;
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
            this.EventsList.Size = new System.Drawing.Size(325, 754);
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
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 787);
            this.panel1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(328, 29);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 787);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.TrackerChannelList);
            this.panel2.Controls.Add(this.Button_Convert);
            this.panel2.Controls.Add(this.チャンネル設定);
            this.panel2.Controls.Add(this.TrackerList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(331, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(698, 787);
            this.panel2.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 694);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "リセット";
            this.button2.UseVisualStyleBackColor = true;
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
            this.Button_Convert.Location = new System.Drawing.Point(194, 694);
            this.Button_Convert.Name = "Button_Convert";
            this.Button_Convert.Size = new System.Drawing.Size(103, 23);
            this.Button_Convert.TabIndex = 3;
            this.Button_Convert.Text = "コンバート";
            this.Button_Convert.UseVisualStyleBackColor = true;
            this.Button_Convert.Click += new System.EventHandler(this.Button_Convert_Click);
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(1029, 838);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "MainWindow";
            this.Text = "MIDI2FTM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.チャンネル設定.ResumeLayout(false);
            this.チャンネル設定.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem ファイル_新規作成;
        private System.Windows.Forms.ToolStripMenuItem ファイル_開く;
        private System.Windows.Forms.ToolStripMenuItem ファイル_上書き保存;
        private System.Windows.Forms.ToolStripMenuItem ファイル_名前を付けて保存;
        private System.Windows.Forms.ToolStripSeparator separatorA;
        private System.Windows.Forms.ToolStripMenuItem ファイル_MIDIインポート;
        private System.Windows.Forms.ToolStripMenuItem ファイル_FTMエクスポート;
        private System.Windows.Forms.ToolStripSeparator separatorB;
        private System.Windows.Forms.ToolStripMenuItem ファイル_終了;

        private System.Windows.Forms.ToolStripMenuItem menuBar表示;
        private System.Windows.Forms.ToolStripMenuItem menuBarヘルプ;
        private System.Windows.Forms.ToolStripMenuItem menuBarファイル;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView TrackerList;
        private System.Windows.Forms.ColumnHeader Pulse1;
        private System.Windows.Forms.ColumnHeader Pulse2;
        private System.Windows.Forms.ColumnHeader Triangle;
        private System.Windows.Forms.ColumnHeader DPCM;
        private System.Windows.Forms.ComboBox TrackList;
        private System.Windows.Forms.GroupBox チャンネル設定;
        private System.Windows.Forms.CheckBox checkBox_ノートオンのボリュームを有効;
        private System.Windows.Forms.ListView EventsList;
        private System.Windows.Forms.ColumnHeader Mea;
        private System.Windows.Forms.ColumnHeader Tick;
        private System.Windows.Forms.ColumnHeader Event;
        private System.Windows.Forms.ColumnHeader Gate;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton_後のノート;
        private System.Windows.Forms.RadioButton radioButton_先のノート;
        private System.Windows.Forms.CheckBox checkBox_テンポチェンジをFxxで表現する;
        private System.Windows.Forms.CheckBox checkBox_CCModulationを4xx7xxで表現する;
        private System.Windows.Forms.CheckBox checkBox_PitchBendを1xx2xxで表現する;
        private System.Windows.Forms.RadioButton radioButton_CCExpressionを適用;
        private System.Windows.Forms.RadioButton radioButton_CCVolumeを適用;
        private System.Windows.Forms.CheckBox checkBox_ノート以外のボリュームを有効;
        private System.Windows.Forms.RadioButton radioButton_NoteCutで表現する;
        private System.Windows.Forms.RadioButton radioButton_ボリュームで表現する;
        private System.Windows.Forms.CheckBox checkBox_ノートオフを有効;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox_同一Tickのノート優先度;
        private System.Windows.Forms.RadioButton radioButton_一番低いノート;
        private System.Windows.Forms.RadioButton radioButton_一番高いノート;
        private System.Windows.Forms.ComboBox TrackerChannelList;
        private System.Windows.Forms.Button Button_Convert;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader Rows;
        private System.Windows.Forms.ColumnHeader Noise;
    }
}

