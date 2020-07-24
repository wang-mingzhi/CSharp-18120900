namespace 高德地图截图工具
{
    partial class frmScreenshot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScreenshot));
            this.cmbZoom = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumberOfCol = new System.Windows.Forms.TextBox();
            this.txtNumberOfRow = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSizeOfHeight = new System.Windows.Forms.TextBox();
            this.cmbRoadCondition = new System.Windows.Forms.ComboBox();
            this.cmbDefinition = new System.Windows.Forms.ComboBox();
            this.txtAPI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSizeOfWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMainPoint = new System.Windows.Forms.TextBox();
            this.txtReferPoint = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscb_Map = new System.Windows.Forms.ToolStripComboBox();
            this.TscbHistory = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsbResult = new System.Windows.Forms.ToolStripButton();
            this.TsbOption = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslLoginTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_lat2Pixel = new System.Windows.Forms.TextBox();
            this.txt_ZoomLevel = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cmb_ProjectionMathed = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_layerOfMarkers = new System.Windows.Forms.ComboBox();
            this.cmb_layersOfBaseMap = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Txt_Url = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbZoom
            // 
            this.cmbZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbZoom.FormattingEnabled = true;
            this.cmbZoom.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.cmbZoom.Location = new System.Drawing.Point(173, 254);
            this.cmbZoom.Name = "cmbZoom";
            this.cmbZoom.Size = new System.Drawing.Size(99, 25);
            this.cmbZoom.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(203, 168);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(214, 197);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "X";
            // 
            // txtNumberOfCol
            // 
            this.txtNumberOfCol.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNumberOfCol.Location = new System.Drawing.Point(236, 194);
            this.txtNumberOfCol.Name = "txtNumberOfCol";
            this.txtNumberOfCol.Size = new System.Drawing.Size(36, 23);
            this.txtNumberOfCol.TabIndex = 27;
            this.txtNumberOfCol.Text = "1";
            this.txtNumberOfCol.Leave += new System.EventHandler(this.txtNumberOfCol_Leave);
            // 
            // txtNumberOfRow
            // 
            this.txtNumberOfRow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNumberOfRow.Location = new System.Drawing.Point(173, 194);
            this.txtNumberOfRow.Name = "txtNumberOfRow";
            this.txtNumberOfRow.Size = new System.Drawing.Size(36, 23);
            this.txtNumberOfRow.TabIndex = 26;
            this.txtNumberOfRow.Text = "1";
            this.txtNumberOfRow.Leave += new System.EventHandler(this.txtNumberOfRow_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(16, 195);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "数量  Row * Col";
            // 
            // txtSizeOfHeight
            // 
            this.txtSizeOfHeight.Enabled = false;
            this.txtSizeOfHeight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSizeOfHeight.Location = new System.Drawing.Point(147, 165);
            this.txtSizeOfHeight.Name = "txtSizeOfHeight";
            this.txtSizeOfHeight.Size = new System.Drawing.Size(50, 23);
            this.txtSizeOfHeight.TabIndex = 2;
            this.txtSizeOfHeight.Text = "1024";
            this.txtSizeOfHeight.Leave += new System.EventHandler(this.txtSizeOfHeight_Leave);
            // 
            // cmbRoadCondition
            // 
            this.cmbRoadCondition.AutoCompleteCustomSource.AddRange(new string[] {
            "是",
            "否"});
            this.cmbRoadCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoadCondition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbRoadCondition.FormattingEnabled = true;
            this.cmbRoadCondition.Items.AddRange(new object[] {
            "不显示路况",
            "显示路况"});
            this.cmbRoadCondition.Location = new System.Drawing.Point(173, 285);
            this.cmbRoadCondition.Name = "cmbRoadCondition";
            this.cmbRoadCondition.Size = new System.Drawing.Size(99, 25);
            this.cmbRoadCondition.TabIndex = 21;
            // 
            // cmbDefinition
            // 
            this.cmbDefinition.AutoCompleteCustomSource.AddRange(new string[] {
            "普通图",
            "高清图"});
            this.cmbDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefinition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbDefinition.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDefinition.FormattingEnabled = true;
            this.cmbDefinition.Items.AddRange(new object[] {
            "普通图",
            "高清图"});
            this.cmbDefinition.Location = new System.Drawing.Point(173, 223);
            this.cmbDefinition.Name = "cmbDefinition";
            this.cmbDefinition.Size = new System.Drawing.Size(99, 25);
            this.cmbDefinition.TabIndex = 20;
            this.cmbDefinition.SelectedIndexChanged += new System.EventHandler(this.cmbDefinition_SelectedIndexChanged);
            // 
            // txtAPI
            // 
            this.txtAPI.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAPI.Location = new System.Drawing.Point(82, 316);
            this.txtAPI.Name = "txtAPI";
            this.txtAPI.PasswordChar = '*';
            this.txtAPI.Size = new System.Drawing.Size(190, 23);
            this.txtAPI.TabIndex = 19;
            this.txtAPI.Text = "eff48ee434d763609e59839fa946b9e1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(16, 317);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "API秘钥";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(16, 287);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "是否显示路况";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(16, 225);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "清晰度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 256);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "缩放级别[1:16]";
            // 
            // txtSizeOfWidth
            // 
            this.txtSizeOfWidth.Enabled = false;
            this.txtSizeOfWidth.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSizeOfWidth.Location = new System.Drawing.Point(222, 165);
            this.txtSizeOfWidth.Name = "txtSizeOfWidth";
            this.txtSizeOfWidth.Size = new System.Drawing.Size(50, 23);
            this.txtSizeOfWidth.TabIndex = 3;
            this.txtSizeOfWidth.Text = "1024";
            this.txtSizeOfWidth.Leave += new System.EventHandler(this.txtSizeOfWight_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "大小  H * W";
            // 
            // txtMainPoint
            // 
            this.txtMainPoint.BackColor = System.Drawing.SystemColors.Info;
            this.txtMainPoint.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMainPoint.Location = new System.Drawing.Point(18, 66);
            this.txtMainPoint.Name = "txtMainPoint";
            this.txtMainPoint.Size = new System.Drawing.Size(173, 26);
            this.txtMainPoint.TabIndex = 1;
            this.txtMainPoint.Text = "116.309658,39.961721";
            this.txtMainPoint.Leave += new System.EventHandler(this.txtMainPoint_Leave);
            // 
            // txtReferPoint
            // 
            this.txtReferPoint.BackColor = System.Drawing.SystemColors.Info;
            this.txtReferPoint.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReferPoint.Location = new System.Drawing.Point(18, 124);
            this.txtReferPoint.Name = "txtReferPoint";
            this.txtReferPoint.Size = new System.Drawing.Size(173, 26);
            this.txtReferPoint.TabIndex = 24;
            this.txtReferPoint.Text = "116.354290,39.941324";
            this.txtReferPoint.Leave += new System.EventHandler(this.txtReferPoint_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(14, 38);
            this.label14.Margin = new System.Windows.Forms.Padding(5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(164, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "左上角 (经度,纬度) | 必选";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(15, 98);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(164, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "右下角 (经度,纬度) | 可选";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(200, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscb_Map,
            this.TscbHistory,
            this.toolStripSeparator1,
            this.TsbResult,
            this.TsbOption});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(581, 33);
            this.toolStrip1.TabIndex = 37;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(30, 30);
            // 
            // tscb_Map
            // 
            this.tscb_Map.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscb_Map.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscb_Map.Items.AddRange(new object[] {
            "高德地图",
            "天地图"});
            this.tscb_Map.Name = "tscb_Map";
            this.tscb_Map.Size = new System.Drawing.Size(121, 33);
            // 
            // TscbHistory
            // 
            this.TscbHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TscbHistory.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.TscbHistory.Items.AddRange(new object[] {
            "两点截图",
            "单点截图"});
            this.TscbHistory.Name = "TscbHistory";
            this.TscbHistory.Size = new System.Drawing.Size(121, 33);
            this.TscbHistory.SelectedIndexChanged += new System.EventHandler(this.TscbHistory_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // TsbResult
            // 
            this.TsbResult.AutoSize = false;
            this.TsbResult.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbResult.Image = ((System.Drawing.Image)(resources.GetObject("TsbResult.Image")));
            this.TsbResult.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbResult.Name = "TsbResult";
            this.TsbResult.Size = new System.Drawing.Size(30, 30);
            this.TsbResult.Text = "生成图片";
            this.TsbResult.Click += new System.EventHandler(this.TsbResult_Click);
            // 
            // TsbOption
            // 
            this.TsbOption.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TsbOption.AutoSize = false;
            this.TsbOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbOption.Image = ((System.Drawing.Image)(resources.GetObject("TsbOption.Image")));
            this.TsbOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbOption.Name = "TsbOption";
            this.TsbOption.Size = new System.Drawing.Size(30, 30);
            this.TsbOption.Text = "设置";
            this.TsbOption.Click += new System.EventHandler(this.TsbOption_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(16, 158);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 1);
            this.label1.TabIndex = 38;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslLoginTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 347);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(581, 30);
            this.statusStrip1.TabIndex = 39;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 25);
            this.toolStripStatusLabel1.Text = "登录时间:";
            // 
            // tsslLoginTime
            // 
            this.tsslLoginTime.BackColor = System.Drawing.Color.Transparent;
            this.tsslLoginTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsslLoginTime.Name = "tsslLoginTime";
            this.tsslLoginTime.Size = new System.Drawing.Size(116, 25);
            this.tsslLoginTime.Text = "2019/7/12 16:14";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txt_lat2Pixel);
            this.groupBox1.Controls.Add(this.txt_ZoomLevel);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.cmb_ProjectionMathed);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmb_layerOfMarkers);
            this.groupBox1.Controls.Add(this.cmb_layersOfBaseMap);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.Txt_Url);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(278, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 306);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(192, 14);
            this.label16.Margin = new System.Windows.Forms.Padding(5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 67);
            this.label16.TabIndex = 41;
            this.label16.Text = "该缩放级别下1纬度对应像素点数";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_lat2Pixel
            // 
            this.txt_lat2Pixel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_lat2Pixel.Location = new System.Drawing.Point(192, 118);
            this.txt_lat2Pixel.Name = "txt_lat2Pixel";
            this.txt_lat2Pixel.Size = new System.Drawing.Size(93, 23);
            this.txt_lat2Pixel.TabIndex = 40;
            this.txt_lat2Pixel.Text = "186500";
            // 
            // txt_ZoomLevel
            // 
            this.txt_ZoomLevel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ZoomLevel.Location = new System.Drawing.Point(192, 89);
            this.txt_ZoomLevel.Name = "txt_ZoomLevel";
            this.txt_ZoomLevel.Size = new System.Drawing.Size(93, 23);
            this.txt_ZoomLevel.TabIndex = 39;
            this.txt_ZoomLevel.Text = "16";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 147);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(279, 152);
            this.richTextBox1.TabIndex = 38;
            this.richTextBox1.Text = "高德地图URL：\nhttp://restapi.amap.com/v3/staticmap?\n天地图URL：\nhttp://api.tianditu.gov.cn" +
    "/staticimage?\n高德地图Key：\neff48ee434d763609e59839fa946b9e1\n天地图Key：\n624781e780851289" +
    "7dbf86d42d449919";
            // 
            // cmb_ProjectionMathed
            // 
            this.cmb_ProjectionMathed.AutoCompleteCustomSource.AddRange(new string[] {
            "普通图",
            "高清图"});
            this.cmb_ProjectionMathed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ProjectionMathed.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_ProjectionMathed.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_ProjectionMathed.FormattingEnabled = true;
            this.cmb_ProjectionMathed.Items.AddRange(new object[] {
            "墨卡托投影"});
            this.cmb_ProjectionMathed.Location = new System.Drawing.Point(81, 116);
            this.cmb_ProjectionMathed.Name = "cmb_ProjectionMathed";
            this.cmb_ProjectionMathed.Size = new System.Drawing.Size(99, 25);
            this.cmb_ProjectionMathed.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(8, 118);
            this.label13.Margin = new System.Windows.Forms.Padding(5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 20);
            this.label13.TabIndex = 36;
            this.label13.Text = "投影方式";
            // 
            // cmb_layerOfMarkers
            // 
            this.cmb_layerOfMarkers.AutoCompleteCustomSource.AddRange(new string[] {
            "普通图",
            "高清图"});
            this.cmb_layerOfMarkers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_layerOfMarkers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_layerOfMarkers.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_layerOfMarkers.FormattingEnabled = true;
            this.cmb_layerOfMarkers.Items.AddRange(new object[] {
            "中文标注：cva_c",
            "英文标注：eva_c",
            "地形标注：cta_c"});
            this.cmb_layerOfMarkers.Location = new System.Drawing.Point(53, 85);
            this.cmb_layerOfMarkers.Name = "cmb_layerOfMarkers";
            this.cmb_layerOfMarkers.Size = new System.Drawing.Size(127, 25);
            this.cmb_layerOfMarkers.TabIndex = 35;
            // 
            // cmb_layersOfBaseMap
            // 
            this.cmb_layersOfBaseMap.AutoCompleteCustomSource.AddRange(new string[] {
            "普通图",
            "高清图"});
            this.cmb_layersOfBaseMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_layersOfBaseMap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_layersOfBaseMap.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_layersOfBaseMap.FormattingEnabled = true;
            this.cmb_layersOfBaseMap.Items.AddRange(new object[] {
            "影像图：img_c",
            "矢量图：vec_c",
            "地形图：ter_c"});
            this.cmb_layersOfBaseMap.Location = new System.Drawing.Point(53, 54);
            this.cmb_layersOfBaseMap.Name = "cmb_layersOfBaseMap";
            this.cmb_layersOfBaseMap.Size = new System.Drawing.Size(127, 25);
            this.cmb_layersOfBaseMap.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(8, 85);
            this.label12.Margin = new System.Windows.Forms.Padding(5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "标注";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(8, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 20);
            this.label11.TabIndex = 32;
            this.label11.Text = "图层";
            // 
            // Txt_Url
            // 
            this.Txt_Url.BackColor = System.Drawing.SystemColors.Info;
            this.Txt_Url.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_Url.Location = new System.Drawing.Point(40, 22);
            this.Txt_Url.Name = "Txt_Url";
            this.Txt_Url.Size = new System.Drawing.Size(140, 26);
            this.Txt_Url.TabIndex = 31;
            this.Txt_Url.Text = "http://restapi.amap.com/v3/staticmap?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(8, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "Url";
            // 
            // frmScreenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(581, 377);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbZoom);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtNumberOfCol);
            this.Controls.Add(this.txtReferPoint);
            this.Controls.Add(this.txtNumberOfRow);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSizeOfHeight);
            this.Controls.Add(this.txtMainPoint);
            this.Controls.Add(this.cmbRoadCondition);
            this.Controls.Add(this.cmbDefinition);
            this.Controls.Add(this.txtAPI);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSizeOfWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmScreenshot";
            this.Text = "高德地图";
            this.Load += new System.EventHandler(this.frmScreenshot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumberOfCol;
        private System.Windows.Forms.TextBox txtNumberOfRow;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbRoadCondition;
        private System.Windows.Forms.ComboBox cmbDefinition;
        private System.Windows.Forms.TextBox txtAPI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSizeOfWidth;
        private System.Windows.Forms.TextBox txtSizeOfHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbZoom;
        private System.Windows.Forms.TextBox txtMainPoint;
        private System.Windows.Forms.TextBox txtReferPoint;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox TscbHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TsbOption;
        private System.Windows.Forms.ToolStripButton TsbResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslLoginTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txt_Url;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripComboBox tscb_Map;
        private System.Windows.Forms.ComboBox cmb_layerOfMarkers;
        private System.Windows.Forms.ComboBox cmb_layersOfBaseMap;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_ProjectionMathed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txt_ZoomLevel;
        private System.Windows.Forms.TextBox txt_lat2Pixel;
        private System.Windows.Forms.Label label16;
    }
}