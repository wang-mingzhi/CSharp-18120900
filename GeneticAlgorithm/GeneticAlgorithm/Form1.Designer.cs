namespace GeneticAlgorithm
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Begin = new System.Windows.Forms.Button();
            this.Rtb_result = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_GenesLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_BitsLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_pc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Txt_coe2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Txt_coe1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Dgv_coefficient = new System.Windows.Forms.DataGridView();
            this.Txt_pm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_chromosomeLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_loopTimes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Pgb_Progress = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.Txt_logFilePath = new System.Windows.Forms.TextBox();
            this.Cmb_recordType = new System.Windows.Forms.ComboBox();
            this.Chk_ClearText = new System.Windows.Forms.CheckBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_coefficient)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Begin
            // 
            this.Btn_Begin.Location = new System.Drawing.Point(371, 28);
            this.Btn_Begin.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Begin.Name = "Btn_Begin";
            this.Btn_Begin.Size = new System.Drawing.Size(68, 36);
            this.Btn_Begin.TabIndex = 0;
            this.Btn_Begin.Text = "开始";
            this.Btn_Begin.UseVisualStyleBackColor = true;
            this.Btn_Begin.Click += new System.EventHandler(this.Btn_Begin_Click);
            // 
            // Rtb_result
            // 
            this.Rtb_result.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Rtb_result.Location = new System.Drawing.Point(360, 148);
            this.Rtb_result.Name = "Rtb_result";
            this.Rtb_result.Size = new System.Drawing.Size(330, 226);
            this.Rtb_result.TabIndex = 1;
            this.Rtb_result.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_GenesLength);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Txt_BitsLength);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Txt_pc);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Txt_coe2);
            this.groupBox1.Controls.Add(this.Dgv_coefficient);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Txt_coe1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Txt_pm);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Txt_chromosomeLength);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Txt_loopTimes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(350, 367);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置";
            // 
            // Txt_GenesLength
            // 
            this.Txt_GenesLength.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_GenesLength.Location = new System.Drawing.Point(273, 81);
            this.Txt_GenesLength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_GenesLength.Name = "Txt_GenesLength";
            this.Txt_GenesLength.Size = new System.Drawing.Size(55, 26);
            this.Txt_GenesLength.TabIndex = 25;
            this.Txt_GenesLength.Text = "8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(192, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "基因长度：";
            // 
            // Txt_BitsLength
            // 
            this.Txt_BitsLength.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_BitsLength.Location = new System.Drawing.Point(273, 111);
            this.Txt_BitsLength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_BitsLength.Name = "Txt_BitsLength";
            this.Txt_BitsLength.Size = new System.Drawing.Size(55, 26);
            this.Txt_BitsLength.TabIndex = 23;
            this.Txt_BitsLength.Text = "8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(192, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "编码长度：";
            // 
            // Txt_pc
            // 
            this.Txt_pc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_pc.Location = new System.Drawing.Point(273, 51);
            this.Txt_pc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_pc.Name = "Txt_pc";
            this.Txt_pc.Size = new System.Drawing.Size(55, 26);
            this.Txt_pc.TabIndex = 21;
            this.Txt_pc.Text = "0.6";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(192, 54);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "交叉概率：";
            // 
            // Txt_coe2
            // 
            this.Txt_coe2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_coe2.Location = new System.Drawing.Point(97, 111);
            this.Txt_coe2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_coe2.Name = "Txt_coe2";
            this.Txt_coe2.Size = new System.Drawing.Size(63, 26);
            this.Txt_coe2.TabIndex = 15;
            this.Txt_coe2.Text = "4278.75";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(44, 114);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "系数2：";
            // 
            // Txt_coe1
            // 
            this.Txt_coe1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_coe1.Location = new System.Drawing.Point(97, 81);
            this.Txt_coe1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_coe1.Name = "Txt_coe1";
            this.Txt_coe1.Size = new System.Drawing.Size(63, 26);
            this.Txt_coe1.TabIndex = 13;
            this.Txt_coe1.Text = "0.666";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(44, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "系数1：";
            // 
            // Dgv_coefficient
            // 
            this.Dgv_coefficient.AllowUserToAddRows = false;
            this.Dgv_coefficient.AllowUserToDeleteRows = false;
            this.Dgv_coefficient.AllowUserToResizeRows = false;
            this.Dgv_coefficient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv_coefficient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_coefficient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.Dgv_coefficient.Location = new System.Drawing.Point(5, 141);
            this.Dgv_coefficient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dgv_coefficient.Name = "Dgv_coefficient";
            this.Dgv_coefficient.RowHeadersVisible = false;
            this.Dgv_coefficient.RowTemplate.Height = 23;
            this.Dgv_coefficient.Size = new System.Drawing.Size(341, 222);
            this.Dgv_coefficient.TabIndex = 11;
            // 
            // Txt_pm
            // 
            this.Txt_pm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_pm.Location = new System.Drawing.Point(97, 51);
            this.Txt_pm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_pm.Name = "Txt_pm";
            this.Txt_pm.Size = new System.Drawing.Size(63, 26);
            this.Txt_pm.TabIndex = 8;
            this.Txt_pm.Text = "0.02";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(20, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "变异概率：";
            // 
            // Txt_chromosomeLength
            // 
            this.Txt_chromosomeLength.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_chromosomeLength.Location = new System.Drawing.Point(273, 21);
            this.Txt_chromosomeLength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_chromosomeLength.Name = "Txt_chromosomeLength";
            this.Txt_chromosomeLength.Size = new System.Drawing.Size(55, 26);
            this.Txt_chromosomeLength.TabIndex = 6;
            this.Txt_chromosomeLength.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(176, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "染色体长度：";
            // 
            // Txt_loopTimes
            // 
            this.Txt_loopTimes.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_loopTimes.Location = new System.Drawing.Point(97, 21);
            this.Txt_loopTimes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Txt_loopTimes.Name = "Txt_loopTimes";
            this.Txt_loopTimes.Size = new System.Drawing.Size(63, 26);
            this.Txt_loopTimes.TabIndex = 2;
            this.Txt_loopTimes.Text = "200";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "迭代次数：";
            // 
            // Pgb_Progress
            // 
            this.Pgb_Progress.Location = new System.Drawing.Point(484, 39);
            this.Pgb_Progress.Name = "Pgb_Progress";
            this.Pgb_Progress.Size = new System.Drawing.Size(206, 25);
            this.Pgb_Progress.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(368, 98);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "LogFilePath：";
            // 
            // Txt_logFilePath
            // 
            this.Txt_logFilePath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Txt_logFilePath.Location = new System.Drawing.Point(371, 118);
            this.Txt_logFilePath.Name = "Txt_logFilePath";
            this.Txt_logFilePath.Size = new System.Drawing.Size(319, 26);
            this.Txt_logFilePath.TabIndex = 14;
            this.Txt_logFilePath.Text = "F:\\18120900\\桌面\\log.txt";
            // 
            // Cmb_recordType
            // 
            this.Cmb_recordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_recordType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cmb_recordType.FormattingEnabled = true;
            this.Cmb_recordType.Items.AddRange(new object[] {
            "简要记录",
            "完全记录",
            "不记录"});
            this.Cmb_recordType.Location = new System.Drawing.Point(484, 70);
            this.Cmb_recordType.Name = "Cmb_recordType";
            this.Cmb_recordType.Size = new System.Drawing.Size(206, 24);
            this.Cmb_recordType.TabIndex = 15;
            // 
            // Chk_ClearText
            // 
            this.Chk_ClearText.AutoSize = true;
            this.Chk_ClearText.Checked = true;
            this.Chk_ClearText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_ClearText.Location = new System.Drawing.Point(371, 72);
            this.Chk_ClearText.Name = "Chk_ClearText";
            this.Chk_ClearText.Size = new System.Drawing.Size(107, 20);
            this.Chk_ClearText.TabIndex = 16;
            this.Chk_ClearText.Text = "清空旧记录";
            this.Chk_ClearText.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "A0";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "A1";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "A2";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "A3";
            this.Column4.Name = "Column4";
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "下限";
            this.Column5.Name = "Column5";
            this.Column5.Width = 65;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "上限";
            this.Column6.Name = "Column6";
            this.Column6.Width = 65;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 378);
            this.Controls.Add(this.Chk_ClearText);
            this.Controls.Add(this.Cmb_recordType);
            this.Controls.Add(this.Txt_logFilePath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Rtb_result);
            this.Controls.Add(this.Pgb_Progress);
            this.Controls.Add(this.Btn_Begin);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "多约束遗传算法";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_coefficient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Begin;
        private System.Windows.Forms.RichTextBox Rtb_result;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txt_loopTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_chromosomeLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_pm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar Pgb_Progress;
        private System.Windows.Forms.DataGridView Dgv_coefficient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txt_coe2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Txt_coe1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Txt_logFilePath;
        private System.Windows.Forms.TextBox Txt_pc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Cmb_recordType;
        private System.Windows.Forms.TextBox Txt_BitsLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_GenesLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox Chk_ClearText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}

