namespace LabVideoTest
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.msiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btSelect = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.LbH = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.lbW = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbShowCurrFrame = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btPlay = new System.Windows.Forms.Button();
            this.pbShowFrameDiff = new System.Windows.Forms.PictureBox();
            this.lbxGrayChange = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.bt_bkgChange = new System.Windows.Forms.Button();
            this.gbScene = new System.Windows.Forms.GroupBox();
            this.bt_checkScene = new System.Windows.Forms.Button();
            this.tb_JG = new System.Windows.Forms.TextBox();
            this.tb_MS = new System.Windows.Forms.TextBox();
            this.tb_DD = new System.Windows.Forms.TextBox();
            this.tb_SJ = new System.Windows.Forms.TextBox();
            this.tb_SID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bt_addScene = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_count = new System.Windows.Forms.DataGridView();
            this.btDelete = new System.Windows.Forms.Button();
            this.panelZoneName = new System.Windows.Forms.Panel();
            this.timerZone = new System.Windows.Forms.Timer(this.components);
            this.gb_sceneD = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_ONAME = new System.Windows.Forms.TextBox();
            this.bt_markInfo = new System.Windows.Forms.Button();
            this.bt_addZone = new System.Windows.Forms.Button();
            this.tb_AID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowFrameDiff)).BeginInit();
            this.gbScene.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_count)).BeginInit();
            this.gb_sceneD.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1924, 25);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // msiFile
            // 
            this.msiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenFile});
            this.msiFile.Name = "msiFile";
            this.msiFile.Size = new System.Drawing.Size(44, 21);
            this.msiFile.Text = "文件";
            // 
            // miOpenFile
            // 
            this.miOpenFile.Name = "miOpenFile";
            this.miOpenFile.Size = new System.Drawing.Size(100, 22);
            this.miOpenFile.Text = "打开";
            this.miOpenFile.Click += new System.EventHandler(this.miOpenFile_Click);
            // 
            // btSelect
            // 
            this.btSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSelect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btSelect.Location = new System.Drawing.Point(187, 210);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(80, 40);
            this.btSelect.TabIndex = 2;
            this.btSelect.Text = "保存";
            this.btSelect.UseVisualStyleBackColor = false;
            this.btSelect.Click += new System.EventHandler(this.btSave_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox.Location = new System.Drawing.Point(0, 33);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(960, 540);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(0, 579);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(960, 45);
            this.trackBar.TabIndex = 4;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // LbH
            // 
            this.LbH.AutoSize = true;
            this.LbH.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbH.Location = new System.Drawing.Point(812, 653);
            this.LbH.Name = "LbH";
            this.LbH.Size = new System.Drawing.Size(82, 24);
            this.LbH.TabIndex = 5;
            this.LbH.Text = "高度：";
            this.LbH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelHeight.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelHeight.Location = new System.Drawing.Point(914, 653);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(22, 24);
            this.labelHeight.TabIndex = 6;
            this.labelHeight.Text = "0";
            // 
            // lbW
            // 
            this.lbW.AutoSize = true;
            this.lbW.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbW.Location = new System.Drawing.Point(812, 694);
            this.lbW.Name = "lbW";
            this.lbW.Size = new System.Drawing.Size(70, 24);
            this.lbW.TabIndex = 7;
            this.lbW.Text = "宽度:";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelWidth.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelWidth.Location = new System.Drawing.Point(914, 694);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(22, 24);
            this.labelWidth.TabIndex = 8;
            this.labelWidth.Text = "0";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lbShowCurrFrame);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPrev);
            this.panel1.Controls.Add(this.btPlay);
            this.panel1.Location = new System.Drawing.Point(11, 820);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 34);
            this.panel1.TabIndex = 9;
            // 
            // lbShowCurrFrame
            // 
            this.lbShowCurrFrame.AutoSize = true;
            this.lbShowCurrFrame.Location = new System.Drawing.Point(405, 9);
            this.lbShowCurrFrame.Name = "lbShowCurrFrame";
            this.lbShowCurrFrame.Size = new System.Drawing.Size(14, 14);
            this.lbShowCurrFrame.TabIndex = 10;
            this.lbShowCurrFrame.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "当前帧数：";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(621, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(87, 27);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一帧";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(493, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(87, 27);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "上一帧";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btPlay
            // 
            this.btPlay.Location = new System.Drawing.Point(3, 3);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(115, 27);
            this.btPlay.TabIndex = 0;
            this.btPlay.Text = "播放";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // pbShowFrameDiff
            // 
            this.pbShowFrameDiff.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbShowFrameDiff.Location = new System.Drawing.Point(10, 630);
            this.pbShowFrameDiff.Name = "pbShowFrameDiff";
            this.pbShowFrameDiff.Size = new System.Drawing.Size(699, 100);
            this.pbShowFrameDiff.TabIndex = 10;
            this.pbShowFrameDiff.TabStop = false;
            // 
            // lbxGrayChange
            // 
            this.lbxGrayChange.FormattingEnabled = true;
            this.lbxGrayChange.ItemHeight = 14;
            this.lbxGrayChange.Items.AddRange(new object[] {
            "各个区域人停留时间统计"});
            this.lbxGrayChange.Location = new System.Drawing.Point(980, 33);
            this.lbxGrayChange.MultiColumn = true;
            this.lbxGrayChange.Name = "lbxGrayChange";
            this.lbxGrayChange.Size = new System.Drawing.Size(283, 256);
            this.lbxGrayChange.TabIndex = 13;
            this.lbxGrayChange.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbxGrayChange_MouseClick);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar.Location = new System.Drawing.Point(980, 295);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(283, 27);
            this.progressBar.TabIndex = 14;
            // 
            // bt_bkgChange
            // 
            this.bt_bkgChange.BackColor = System.Drawing.Color.CadetBlue;
            this.bt_bkgChange.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.bt_bkgChange.ForeColor = System.Drawing.Color.Lime;
            this.bt_bkgChange.Location = new System.Drawing.Point(1019, 328);
            this.bt_bkgChange.Name = "bt_bkgChange";
            this.bt_bkgChange.Size = new System.Drawing.Size(203, 36);
            this.bt_bkgChange.TabIndex = 23;
            this.bt_bkgChange.Text = "背景帧改变";
            this.bt_bkgChange.UseVisualStyleBackColor = false;
            this.bt_bkgChange.Click += new System.EventHandler(this.bt_bkgChange_Click);
            // 
            // gbScene
            // 
            this.gbScene.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbScene.Controls.Add(this.bt_checkScene);
            this.gbScene.Controls.Add(this.tb_JG);
            this.gbScene.Controls.Add(this.tb_MS);
            this.gbScene.Controls.Add(this.tb_DD);
            this.gbScene.Controls.Add(this.tb_SJ);
            this.gbScene.Controls.Add(this.tb_SID);
            this.gbScene.Controls.Add(this.label9);
            this.gbScene.Controls.Add(this.bt_addScene);
            this.gbScene.Controls.Add(this.label7);
            this.gbScene.Controls.Add(this.label6);
            this.gbScene.Controls.Add(this.label5);
            this.gbScene.Controls.Add(this.label1);
            this.gbScene.Location = new System.Drawing.Point(1486, 33);
            this.gbScene.Name = "gbScene";
            this.gbScene.Size = new System.Drawing.Size(370, 306);
            this.gbScene.TabIndex = 24;
            this.gbScene.TabStop = false;
            this.gbScene.Text = "场景信息";
            // 
            // bt_checkScene
            // 
            this.bt_checkScene.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_checkScene.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_checkScene.Location = new System.Drawing.Point(277, 239);
            this.bt_checkScene.Name = "bt_checkScene";
            this.bt_checkScene.Size = new System.Drawing.Size(87, 27);
            this.bt_checkScene.TabIndex = 14;
            this.bt_checkScene.Text = "查看场景";
            this.bt_checkScene.UseVisualStyleBackColor = false;
            this.bt_checkScene.Click += new System.EventHandler(this.bt_checkScene_Click);
            // 
            // tb_JG
            // 
            this.tb_JG.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_JG.Location = new System.Drawing.Point(180, 163);
            this.tb_JG.Name = "tb_JG";
            this.tb_JG.Size = new System.Drawing.Size(186, 23);
            this.tb_JG.TabIndex = 13;
            // 
            // tb_MS
            // 
            this.tb_MS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_MS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tb_MS.Location = new System.Drawing.Point(180, 128);
            this.tb_MS.Name = "tb_MS";
            this.tb_MS.Size = new System.Drawing.Size(186, 23);
            this.tb_MS.TabIndex = 12;
            // 
            // tb_DD
            // 
            this.tb_DD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_DD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tb_DD.Location = new System.Drawing.Point(180, 93);
            this.tb_DD.Name = "tb_DD";
            this.tb_DD.Size = new System.Drawing.Size(186, 23);
            this.tb_DD.TabIndex = 11;
            // 
            // tb_SJ
            // 
            this.tb_SJ.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SJ.ForeColor = System.Drawing.Color.Black;
            this.tb_SJ.Location = new System.Drawing.Point(180, 58);
            this.tb_SJ.Name = "tb_SJ";
            this.tb_SJ.Size = new System.Drawing.Size(186, 23);
            this.tb_SJ.TabIndex = 10;
            // 
            // tb_SID
            // 
            this.tb_SID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_SID.Location = new System.Drawing.Point(180, 23);
            this.tb_SID.Name = "tb_SID";
            this.tb_SID.Size = new System.Drawing.Size(186, 23);
            this.tb_SID.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(58, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "监控场景序号：";
            // 
            // bt_addScene
            // 
            this.bt_addScene.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_addScene.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_addScene.Location = new System.Drawing.Point(10, 239);
            this.bt_addScene.Name = "bt_addScene";
            this.bt_addScene.Size = new System.Drawing.Size(87, 27);
            this.bt_addScene.TabIndex = 4;
            this.bt_addScene.Text = "新建场景";
            this.bt_addScene.UseVisualStyleBackColor = false;
            this.bt_addScene.Click += new System.EventHandler(this.bt_addScene_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(9, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "人流量统计时间间隔：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(91, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 2;
            this.label6.Text = "场景描述：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(124, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "地点：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(124, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "时间：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.dgv_count);
            this.groupBox1.Location = new System.Drawing.Point(1486, 366);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 427);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "监控计数";
            // 
            // dgv_count
            // 
            this.dgv_count.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_count.Location = new System.Drawing.Point(3, 19);
            this.dgv_count.Name = "dgv_count";
            this.dgv_count.RowTemplate.Height = 23;
            this.dgv_count.Size = new System.Drawing.Size(321, 405);
            this.dgv_count.TabIndex = 0;
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.CadetBlue;
            this.btDelete.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDelete.ForeColor = System.Drawing.Color.Black;
            this.btDelete.Location = new System.Drawing.Point(990, 667);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(87, 36);
            this.btDelete.TabIndex = 28;
            this.btDelete.Text = "删除区域";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // panelZoneName
            // 
            this.panelZoneName.Location = new System.Drawing.Point(10, 736);
            this.panelZoneName.Name = "panelZoneName";
            this.panelZoneName.Size = new System.Drawing.Size(697, 47);
            this.panelZoneName.TabIndex = 29;
            // 
            // timerZone
            // 
            this.timerZone.Enabled = true;
            this.timerZone.Interval = 1000;
            this.timerZone.Tick += new System.EventHandler(this.timerZone_Tick);
            // 
            // gb_sceneD
            // 
            this.gb_sceneD.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gb_sceneD.Controls.Add(this.label8);
            this.gb_sceneD.Controls.Add(this.tb_ONAME);
            this.gb_sceneD.Controls.Add(this.bt_markInfo);
            this.gb_sceneD.Controls.Add(this.bt_addZone);
            this.gb_sceneD.Controls.Add(this.tb_AID);
            this.gb_sceneD.Controls.Add(this.label3);
            this.gb_sceneD.Controls.Add(this.btSelect);
            this.gb_sceneD.Location = new System.Drawing.Point(980, 370);
            this.gb_sceneD.Name = "gb_sceneD";
            this.gb_sceneD.Size = new System.Drawing.Size(283, 276);
            this.gb_sceneD.TabIndex = 30;
            this.gb_sceneD.TabStop = false;
            this.gb_sceneD.Text = "监控场景标定表";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 14);
            this.label8.TabIndex = 37;
            this.label8.Text = "区域类型名称：";
            // 
            // tb_ONAME
            // 
            this.tb_ONAME.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_ONAME.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tb_ONAME.Location = new System.Drawing.Point(135, 99);
            this.tb_ONAME.Name = "tb_ONAME";
            this.tb_ONAME.Size = new System.Drawing.Size(132, 23);
            this.tb_ONAME.TabIndex = 36;
            // 
            // bt_markInfo
            // 
            this.bt_markInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_markInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_markInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bt_markInfo.Location = new System.Drawing.Point(96, 210);
            this.bt_markInfo.Name = "bt_markInfo";
            this.bt_markInfo.Size = new System.Drawing.Size(80, 40);
            this.bt_markInfo.TabIndex = 34;
            this.bt_markInfo.Text = "查看标定";
            this.bt_markInfo.UseVisualStyleBackColor = false;
            this.bt_markInfo.Click += new System.EventHandler(this.bt_markInfo_Click);
            // 
            // bt_addZone
            // 
            this.bt_addZone.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_addZone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_addZone.ForeColor = System.Drawing.Color.Black;
            this.bt_addZone.Location = new System.Drawing.Point(10, 209);
            this.bt_addZone.Name = "bt_addZone";
            this.bt_addZone.Size = new System.Drawing.Size(80, 40);
            this.bt_addZone.TabIndex = 31;
            this.bt_addZone.Text = "添加区域";
            this.bt_addZone.UseVisualStyleBackColor = false;
            this.bt_addZone.Click += new System.EventHandler(this.bt_addZone_Click);
            // 
            // tb_AID
            // 
            this.tb_AID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_AID.Location = new System.Drawing.Point(135, 46);
            this.tb_AID.Name = "tb_AID";
            this.tb_AID.Size = new System.Drawing.Size(132, 23);
            this.tb_AID.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "监控区域序号：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1062);
            this.Controls.Add(this.gb_sceneD);
            this.Controls.Add(this.panelZoneName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbScene);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.bt_bkgChange);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbxGrayChange);
            this.Controls.Add(this.pbShowFrameDiff);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.lbW);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.LbH);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "实验室视频打卡机测试系统";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowFrameDiff)).EndInit();
            this.gbScene.ResumeLayout(false);
            this.gbScene.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_count)).EndInit();
            this.gb_sceneD.ResumeLayout(false);
            this.gb_sceneD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem msiFile;
        private System.Windows.Forms.ToolStripMenuItem miOpenFile;
        private System.Windows.Forms.Button btSelect;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label LbH;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label lbW;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.Label lbShowCurrFrame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbShowFrameDiff;
        private System.Windows.Forms.ListBox lbxGrayChange;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button bt_bkgChange;
        private System.Windows.Forms.GroupBox gbScene;
        private System.Windows.Forms.Button bt_addScene;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_count;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Panel panelZoneName;
        public System.Windows.Forms.Timer timerZone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_JG;
        private System.Windows.Forms.TextBox tb_MS;
        private System.Windows.Forms.TextBox tb_DD;
        private System.Windows.Forms.TextBox tb_SJ;
        private System.Windows.Forms.TextBox tb_SID;
        private System.Windows.Forms.GroupBox gb_sceneD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_addZone;
        private System.Windows.Forms.TextBox tb_AID;
        private System.Windows.Forms.Button bt_checkScene;
        private System.Windows.Forms.Button bt_markInfo;
        private System.Windows.Forms.TextBox tb_ONAME;
        private System.Windows.Forms.Label label8;
    }
}

