namespace HighwayODAnalysis
{
    partial class Frm_DataView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DataView));
            this.Dgv_DataView = new System.Windows.Forms.DataGridView();
            this.CMS_dgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tsml_Ascending = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsml_Descending = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsml_HideCurrentRow = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsml_HideCurrentCol = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsml_DeleteSelectedRow = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsml_DeleteSelectedCol = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tssl_MatrixSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Tsddb_File = new System.Windows.Forms.ToolStripDropDownButton();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分组ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.频率统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.修改表结构ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsb_Open = new System.Windows.Forms.ToolStripButton();
            this.Tsb_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Tscb_DataSets = new System.Windows.Forms.ToolStripComboBox();
            this.Tsb_Contents = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Tsb_DeleteRows = new System.Windows.Forms.ToolStripButton();
            this.Tsb_Find = new System.Windows.Forms.ToolStripButton();
            this.Tsb_StatisticData = new System.Windows.Forms.ToolStripButton();
            this.Tsb_CreateChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.Tsb_Help = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_DataView)).BeginInit();
            this.CMS_dgv.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Dgv_DataView
            // 
            this.Dgv_DataView.AllowUserToAddRows = false;
            this.Dgv_DataView.AllowUserToDeleteRows = false;
            this.Dgv_DataView.AllowUserToResizeRows = false;
            this.Dgv_DataView.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_DataView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv_DataView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.Dgv_DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_DataView.ContextMenuStrip = this.CMS_dgv;
            this.Dgv_DataView.Location = new System.Drawing.Point(0, 25);
            this.Dgv_DataView.Margin = new System.Windows.Forms.Padding(0);
            this.Dgv_DataView.Name = "Dgv_DataView";
            this.Dgv_DataView.RowTemplate.Height = 23;
            this.Dgv_DataView.Size = new System.Drawing.Size(793, 423);
            this.Dgv_DataView.TabIndex = 0;
            this.Dgv_DataView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_DataView_ColumnHeaderMouseClick);
            this.Dgv_DataView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Dgv_DataView_RowHeaderMouseClick);
            // 
            // CMS_dgv
            // 
            this.CMS_dgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsml_Ascending,
            this.Tsml_Descending,
            this.Tsml_HideCurrentRow,
            this.Tsml_HideCurrentCol,
            this.Tsml_DeleteSelectedRow,
            this.Tsml_DeleteSelectedCol});
            this.CMS_dgv.Name = "菜单栏";
            this.CMS_dgv.Size = new System.Drawing.Size(137, 136);
            this.CMS_dgv.Text = "菜单栏";
            // 
            // Tsml_Ascending
            // 
            this.Tsml_Ascending.Name = "Tsml_Ascending";
            this.Tsml_Ascending.Size = new System.Drawing.Size(136, 22);
            this.Tsml_Ascending.Text = "升序排列";
            this.Tsml_Ascending.Click += new System.EventHandler(this.Tsml_Ascending_Click);
            // 
            // Tsml_Descending
            // 
            this.Tsml_Descending.Name = "Tsml_Descending";
            this.Tsml_Descending.Size = new System.Drawing.Size(136, 22);
            this.Tsml_Descending.Text = "降序排列";
            this.Tsml_Descending.Click += new System.EventHandler(this.Tsml_Descending_Click);
            // 
            // Tsml_HideCurrentRow
            // 
            this.Tsml_HideCurrentRow.Name = "Tsml_HideCurrentRow";
            this.Tsml_HideCurrentRow.Size = new System.Drawing.Size(136, 22);
            this.Tsml_HideCurrentRow.Text = "隐藏当前行";
            this.Tsml_HideCurrentRow.Click += new System.EventHandler(this.Tsml_HideCurrentRow_Click);
            // 
            // Tsml_HideCurrentCol
            // 
            this.Tsml_HideCurrentCol.Name = "Tsml_HideCurrentCol";
            this.Tsml_HideCurrentCol.Size = new System.Drawing.Size(136, 22);
            this.Tsml_HideCurrentCol.Text = "隐藏当前列";
            this.Tsml_HideCurrentCol.Click += new System.EventHandler(this.Tsml_HideCurrentCol_Click);
            // 
            // Tsml_DeleteSelectedRow
            // 
            this.Tsml_DeleteSelectedRow.Name = "Tsml_DeleteSelectedRow";
            this.Tsml_DeleteSelectedRow.Size = new System.Drawing.Size(136, 22);
            this.Tsml_DeleteSelectedRow.Text = "删除选中行";
            this.Tsml_DeleteSelectedRow.Click += new System.EventHandler(this.Tsml_DeleteSelectedRow_Click);
            // 
            // Tsml_DeleteSelectedCol
            // 
            this.Tsml_DeleteSelectedCol.Name = "Tsml_DeleteSelectedCol";
            this.Tsml_DeleteSelectedCol.Size = new System.Drawing.Size(136, 22);
            this.Tsml_DeleteSelectedCol.Text = "删除选中列";
            this.Tsml_DeleteSelectedCol.Click += new System.EventHandler(this.Tsml_DeleteSelectedCol_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.Tssl_MatrixSize,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(793, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "行列值：";
            // 
            // Tssl_MatrixSize
            // 
            this.Tssl_MatrixSize.Name = "Tssl_MatrixSize";
            this.Tssl_MatrixSize.Size = new System.Drawing.Size(27, 17);
            this.Tssl_MatrixSize.Text = "0*0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(224, 17);
            this.toolStripStatusLabel2.Text = "总计：平均值：最大值：最小值：大小：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsddb_File,
            this.Tsb_Open,
            this.Tsb_Save,
            this.toolStripSeparator1,
            this.Tscb_DataSets,
            this.Tsb_Contents,
            this.toolStripSeparator2,
            this.Tsb_DeleteRows,
            this.Tsb_Find,
            this.Tsb_StatisticData,
            this.Tsb_CreateChart,
            this.toolStripSeparator,
            this.Tsb_Help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(793, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Tsddb_File
            // 
            this.Tsddb_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.toolStripSeparator5,
            this.更新ToolStripMenuItem,
            this.导入ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.toolStripSeparator6,
            this.统计ToolStripMenuItem,
            this.分组ToolStripMenuItem,
            this.频率统计ToolStripMenuItem,
            this.toolStripSeparator4,
            this.修改表结构ToolStripMenuItem});
            this.Tsddb_File.Image = ((System.Drawing.Image)(resources.GetObject("Tsddb_File.Image")));
            this.Tsddb_File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsddb_File.Name = "Tsddb_File";
            this.Tsddb_File.Size = new System.Drawing.Size(61, 22);
            this.Tsddb_File.Text = "文件";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("复制ToolStripMenuItem.Image")));
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(133, 6);
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("更新ToolStripMenuItem.Image")));
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.更新ToolStripMenuItem.Text = "更新";
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("导入ToolStripMenuItem.Image")));
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.导入ToolStripMenuItem.Text = "导入";
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("导出ToolStripMenuItem.Image")));
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(133, 6);
            // 
            // 统计ToolStripMenuItem
            // 
            this.统计ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("统计ToolStripMenuItem.Image")));
            this.统计ToolStripMenuItem.Name = "统计ToolStripMenuItem";
            this.统计ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.统计ToolStripMenuItem.Text = "统计";
            // 
            // 分组ToolStripMenuItem
            // 
            this.分组ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("分组ToolStripMenuItem.Image")));
            this.分组ToolStripMenuItem.Name = "分组ToolStripMenuItem";
            this.分组ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.分组ToolStripMenuItem.Text = "分组";
            // 
            // 频率统计ToolStripMenuItem
            // 
            this.频率统计ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("频率统计ToolStripMenuItem.Image")));
            this.频率统计ToolStripMenuItem.Name = "频率统计ToolStripMenuItem";
            this.频率统计ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.频率统计ToolStripMenuItem.Text = "频率统计";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // 修改表结构ToolStripMenuItem
            // 
            this.修改表结构ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("修改表结构ToolStripMenuItem.Image")));
            this.修改表结构ToolStripMenuItem.Name = "修改表结构ToolStripMenuItem";
            this.修改表结构ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.修改表结构ToolStripMenuItem.Text = "修改表结构";
            this.修改表结构ToolStripMenuItem.Click += new System.EventHandler(this.修改表结构ToolStripMenuItem_Click);
            // 
            // Tsb_Open
            // 
            this.Tsb_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_Open.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Open.Image")));
            this.Tsb_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Open.Name = "Tsb_Open";
            this.Tsb_Open.Size = new System.Drawing.Size(23, 22);
            this.Tsb_Open.Text = "打开(&O)";
            // 
            // Tsb_Save
            // 
            this.Tsb_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_Save.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Save.Image")));
            this.Tsb_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Save.Name = "Tsb_Save";
            this.Tsb_Save.Size = new System.Drawing.Size(23, 22);
            this.Tsb_Save.Text = "保存(&S)";
            this.Tsb_Save.Click += new System.EventHandler(this.Tsb_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Tscb_DataSets
            // 
            this.Tscb_DataSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Tscb_DataSets.Name = "Tscb_DataSets";
            this.Tscb_DataSets.Size = new System.Drawing.Size(121, 25);
            // 
            // Tsb_Contents
            // 
            this.Tsb_Contents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_Contents.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Contents.Image")));
            this.Tsb_Contents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Contents.Name = "Tsb_Contents";
            this.Tsb_Contents.Size = new System.Drawing.Size(23, 22);
            this.Tsb_Contents.Text = "图层";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Tsb_DeleteRows
            // 
            this.Tsb_DeleteRows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_DeleteRows.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_DeleteRows.Image")));
            this.Tsb_DeleteRows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_DeleteRows.Name = "Tsb_DeleteRows";
            this.Tsb_DeleteRows.Size = new System.Drawing.Size(23, 22);
            this.Tsb_DeleteRows.Text = "删除行";
            this.Tsb_DeleteRows.Click += new System.EventHandler(this.Tsb_DeleteRows_Click);
            // 
            // Tsb_Find
            // 
            this.Tsb_Find.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_Find.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Find.Image")));
            this.Tsb_Find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Find.Name = "Tsb_Find";
            this.Tsb_Find.Size = new System.Drawing.Size(23, 22);
            this.Tsb_Find.Text = "查找";
            // 
            // Tsb_StatisticData
            // 
            this.Tsb_StatisticData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_StatisticData.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_StatisticData.Image")));
            this.Tsb_StatisticData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_StatisticData.Name = "Tsb_StatisticData";
            this.Tsb_StatisticData.Size = new System.Drawing.Size(23, 22);
            this.Tsb_StatisticData.Text = "快速统计";
            this.Tsb_StatisticData.Click += new System.EventHandler(this.Tsb_StatisticData_Click);
            // 
            // Tsb_CreateChart
            // 
            this.Tsb_CreateChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_CreateChart.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_CreateChart.Image")));
            this.Tsb_CreateChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_CreateChart.Name = "Tsb_CreateChart";
            this.Tsb_CreateChart.Size = new System.Drawing.Size(23, 22);
            this.Tsb_CreateChart.Text = "生成图表";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // Tsb_Help
            // 
            this.Tsb_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tsb_Help.Image = ((System.Drawing.Image)(resources.GetObject("Tsb_Help.Image")));
            this.Tsb_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tsb_Help.Name = "Tsb_Help";
            this.Tsb_Help.Size = new System.Drawing.Size(23, 22);
            this.Tsb_Help.Text = "帮助(&L)";
            // 
            // Frm_DataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 470);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Dgv_DataView);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_DataView";
            this.Text = "DataView";
            this.Load += new System.EventHandler(this.Frm_DataView_Load);
            this.Resize += new System.EventHandler(this.Frm_DataView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_DataView)).EndInit();
            this.CMS_dgv.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Dgv_DataView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton Tsddb_File;
        private System.Windows.Forms.ToolStripComboBox Tscb_DataSets;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Tsb_StatisticData;
        private System.Windows.Forms.ToolStripButton Tsb_CreateChart;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel Tssl_MatrixSize;
        private System.Windows.Forms.ToolStripMenuItem 统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分组ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 频率统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton Tsb_Open;
        private System.Windows.Forms.ToolStripButton Tsb_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton Tsb_Help;
        private System.Windows.Forms.ToolStripButton Tsb_Contents;
        private System.Windows.Forms.ToolStripButton Tsb_Find;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 修改表结构ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton Tsb_DeleteRows;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ContextMenuStrip CMS_dgv;
        private System.Windows.Forms.ToolStripMenuItem Tsml_Ascending;
        private System.Windows.Forms.ToolStripMenuItem Tsml_Descending;
        private System.Windows.Forms.ToolStripMenuItem Tsml_HideCurrentRow;
        private System.Windows.Forms.ToolStripMenuItem Tsml_HideCurrentCol;
        private System.Windows.Forms.ToolStripMenuItem Tsml_DeleteSelectedRow;
        private System.Windows.Forms.ToolStripMenuItem Tsml_DeleteSelectedCol;
    }
}