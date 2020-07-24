using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HighwayODAnalysis
{
    public partial class Frm_DataView : Form
    {
        readonly FileOperate fileOperate = new FileOperate();
        readonly SaveFile SaveFile = new SaveFile();

        public Frm_DataView()
        {
            InitializeComponent();
            Text = DateTime.Now.ToString();
        }

        private void Frm_DataView_Resize(object sender, EventArgs e)
        {
            Dgv_DataView.Location = new Point(0, toolStrip1.Height);
            Dgv_DataView.Width = ClientRectangle.Width;
            Dgv_DataView.Height = ClientRectangle.Height - toolStrip1.Height - statusStrip1.Height;
        }

        public void FillDataGridview(PublicVariable.StatisticResultStruce matrix)
        {

            DataTable dt = new DataTable("Matrix");
            string[] tempStr = matrix.Title.Split(PublicVariable.CharSplitor);
            for (int i = 0; i < tempStr.Length; i++)
            {
                dt.Columns.Add(tempStr[i]);
            }

            foreach (string key in matrix.Matrix.Keys)
            {
                DataRow dataRow = dt.NewRow();
                string[] tempkey = key.Split(PublicVariable.CharSplitor);
                for (int i = 0; i < tempkey.Length; i++)
                {
                    dataRow[i] = tempkey[i];
                }
                for (int i = 0; i < matrix.Matrix[key].Count; i++)
                {
                    dataRow[i + tempkey.Length] = matrix.Matrix[key][i];
                }
                dt.Rows.Add(dataRow);
            }

            Dgv_DataView.DataSource = dt;

            for (int i = 0; i < Dgv_DataView.ColumnCount; i++)
            {
                Dgv_DataView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            Tssl_MatrixSize.Text = Dgv_DataView.Rows.Count + "*" + Dgv_DataView.Columns.Count;
        }

        private void Tsb_DeleteRows_Click(object sender, EventArgs e)
        {
            Dgv_DataView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

            if (Dgv_DataView != null)
            {
                for (int i = Dgv_DataView.SelectedRows.Count; i > 0; i--) 
                {
                    Dgv_DataView.Rows.RemoveAt(Dgv_DataView.SelectedRows[i - 1].Index);
                }
            }

            if (Dgv_DataView.CurrentCell != null) 
            {
                Dgv_DataView.Rows[Dgv_DataView.CurrentCell.RowIndex].Selected = true;
            }

            Tssl_MatrixSize.Text = Dgv_DataView.Rows.Count + "*" + Dgv_DataView.Columns.Count;
        }

        readonly Frm_ModifyTable frm_ModifyTable = null;
        private void 修改表结构ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileOperate.ShowForm<Frm_ModifyTable>(frm_ModifyTable);
        }

        private void Dgv_DataView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            dataGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView.Rows[e.RowIndex].Selected = true;
        }

        private void Dgv_DataView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            dataGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            dataGridView.Rows[e.ColumnIndex].Selected = true;
        }

        private void Tsb_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Text文件(*.txt)|*.txt|CSV文件(*.csv)|*.csv|Excel表格(*.xls)|*.xls|Excel表格(*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                switch (sfd.FilterIndex)
                {
                    case 1:
                        {
                            SaveFile.OutputAsTxtFile(sfd.FileName, Dgv_DataView);
                            break;
                        }
                    case 2:
                        {
                            SaveFile.OutputAsTxtFile(sfd.FileName, Dgv_DataView);
                            break;
                        }
                    case 3:
                        {
                            SaveFile.OutputAsExcelFile(sfd.FileName, Dgv_DataView);
                            break;
                        }
                    case 4:
                        {
                            SaveFile.OutputAsExcelFile(sfd.FileName, Dgv_DataView);
                            break;
                        }
                    default:
                        break;
                }
                
            }
        }

        private void Tsb_StatisticData_Click(object sender, EventArgs e)
        {

        }

        private void Tsml_Ascending_Click(object sender, EventArgs e)
        {    
            if (Dgv_DataView != null && Dgv_DataView.CurrentCell.ColumnIndex >= 0)
            {
                Dgv_DataView.Sort(Dgv_DataView.Columns[Dgv_DataView.CurrentCell.ColumnIndex], System.ComponentModel.ListSortDirection.Ascending);
            }
        }

        private void Tsml_Descending_Click(object sender, EventArgs e)
        {
            if (Dgv_DataView != null && Dgv_DataView.CurrentCell.ColumnIndex >= 0)
            {
                Dgv_DataView.Sort(Dgv_DataView.Columns[Dgv_DataView.CurrentCell.ColumnIndex], System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void Tsml_HideCurrentRow_Click(object sender, EventArgs e)
        {
            if (Dgv_DataView != null && Dgv_DataView.CurrentCell.RowIndex >= 0)
            {
                for (int i = Dgv_DataView.SelectedRows.Count; i > 0; i--)
                {
                    Dgv_DataView.Rows[Dgv_DataView.SelectedRows[i - 1].Index].Visible = false;
                }
            }
        }

        private void Tsml_HideCurrentCol_Click(object sender, EventArgs e)
        {
            if (Dgv_DataView != null && Dgv_DataView.CurrentCell.ColumnIndex >= 0)
            {
                for (int i = Dgv_DataView.SelectedColumns.Count; i > 0; i--)
                {
                    Dgv_DataView.Columns[Dgv_DataView.SelectedColumns[i - 1].Index].Visible = false;
                }
            }
        }

        private void Tsml_DeleteSelectedRow_Click(object sender, EventArgs e)
        {
            Tsb_DeleteRows_Click(this, e);
        }

        private void Tsml_DeleteSelectedCol_Click(object sender, EventArgs e)
        {
            Dgv_DataView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

            if (Dgv_DataView != null)
            {
                for (int i = Dgv_DataView.SelectedColumns.Count; i > 0; i--)
                {
                    Dgv_DataView.Columns.RemoveAt(Dgv_DataView.SelectedColumns[i - 1].Index);
                }
            }

            if (Dgv_DataView.CurrentCell != null)
            {
                Dgv_DataView.Columns[Dgv_DataView.CurrentCell.ColumnIndex].Selected = true;
            }

            Tssl_MatrixSize.Text = Dgv_DataView.Rows.Count + "*" + Dgv_DataView.Columns.Count;
        }

        private void Frm_DataView_Load(object sender, EventArgs e)
        {

        }
    }
}
