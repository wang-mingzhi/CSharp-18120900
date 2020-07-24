using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HighwayODAnalysis
{
    public partial class Frm_DataAnalysis : Form
    {

        public delegate void SendContentsHandler(PublicVariable.StatisticResultStruce statisticResult);
        public event SendContentsHandler SendContentsEvent;

        readonly FileOperate FileOperate = new FileOperate();
        private PublicVariable.StatisticResultStruce MatrixStruce = new PublicVariable.StatisticResultStruce();
        int selectedNum = 0;

        public Frm_DataAnalysis()
        {
            InitializeComponent();
        }

        private void Frm_DataAnalysis_Load(object sender, EventArgs e)
        {
            PublicVariable.DbPath = Directory.GetCurrentDirectory();
            Chk_NameFileByDate_CheckedChanged(this, e);
            cmb_FileOpenWay.SelectedIndex = 0;
            this.tabControl1.SelectedIndex = 2;

            PublicVariable.DGVStruck.SerialNumber = Dgv_StatisticSetting.Columns[0].HeaderText;
            PublicVariable.DGVStruck.SerialNumberIndex = 0;
            PublicVariable.DGVStruck.ID = Dgv_StatisticSetting.Columns[1].HeaderText;
            PublicVariable.DGVStruck.IDIndex = 1;
            PublicVariable.DGVStruck.ColumnHeading = Dgv_StatisticSetting.Columns[2].HeaderText;
            PublicVariable.DGVStruck.ColumnHeadingIndex = 2;
            PublicVariable.DGVStruck.DataType = Dgv_StatisticSetting.Columns[3].HeaderText;
            PublicVariable.DGVStruck.DataTypeIndex = 3;
            PublicVariable.DGVStruck.Sum = Dgv_StatisticSetting.Columns[4].HeaderText;
            PublicVariable.DGVStruck.SumIndex = 4;

            ReadSystemSetting();
            Grp_Separator_Leave(this, e);
        }

        private void Tsb_OK_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Text)
            {
                case "文件预览":
                    {
                        break;
                    }
                case "文件拆分":
                    {
                        if (lbl_OriginFilePath.Text != "初始文件路径")
                        {
                            for (int i = 0; i < PublicVariable.SplitedFilePath.Count; i++)
                            {
                                Tssl_ProgressInfo.Text = i + 1 + "/" + PublicVariable.SplitedFilePath.Count;
                                FileOperate.LoadSplitedFile(PublicVariable.SplitedFilePath[i], Rtb_SplitedFileInfo, Tssl_ProgressInfo, Tssl_FileSize);
                            }
                        }
                        else
                        {
                            Btn_OpenOriginFile.Focus();
                        }
                        break;
                    }
                case "数据分析":
                    {
                        break;
                    }
                case "OD数据提取":
                    {
                        break;
                    }
                case "筛选条件设置":
                    {
                        break;
                    }
                case "其他选项":
                    {
                        break;
                    }
                default:
                    {
                        MessageBox.Show("不存在该选项卡！", "未知错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void Tsb_OpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "请选择一个文件夹",
                SelectedPath = Properties.Settings.Default.folderPath
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FileOperate.PaintTreeView(tvw_Folder, folderBrowserDialog.SelectedPath);
                PublicVariable.FolderPath = folderBrowserDialog.SelectedPath;
            }

            Properties.Settings.Default.folderPath = PublicVariable.FolderPath;
            Properties.Settings.Default.Save();
        }

        private void Btn_OpenOriginFile_Click(object sender, EventArgs e)
        {
            PublicVariable.SplitingFilePath = FileOperate.OpenFile();
            if (PublicVariable.SplitingFilePath != "")
            {
                FileOperate.LoadSplitingFile(PublicVariable.SplitingFilePath, Rtb_SplitedFileInfo, Tssl_ProgressInfo, Tssl_FileSize);
                lbl_OriginFilePath.Text = PublicVariable.SplitingFilePath;
                Btn_SpliteFileSetting.Enabled = true;
            }
        }

        //读取双击的文件内容到相应的文本框
        private void Tvw_Folder_DoubleClick(object sender, EventArgs e)
        {
            if (tvw_Folder != null && tvw_Folder.SelectedNode != null)
                switch (tabControl1.SelectedIndex)
                {                   
                    case 0: //文件预览窗体
                        {
                            FileOperate.ReadFile(Rtb_RawFileContents, PublicVariable.FolderPath + "\\" + tvw_Folder.SelectedNode.FullPath, readWay: cmb_FileOpenWay.SelectedIndex,isRemoveSpace:chk_RemoveSpace.Checked);
                            break;
                        }
                    case 2: //OD数据提取窗体
                        {
                            Dgv_StatisticSetting.Rows.Clear();
                            FileOperate.LoadFileInfoToDgv(Dgv_StatisticSetting, PublicVariable.FolderPath + "\\" + tvw_Folder.SelectedNode.FullPath);
                            break;
                        }
                }
        }

        private void Tslb_Statistics_Click(object sender, EventArgs e)
        {
            Dictionary<string, double[,]> statisticResult = new Dictionary<string, double[,]>();
            for (int i = 0; i < PublicVariable.SplitedFilePath.Count; i++)
            {
                Tssl_ProgressInfo.Text = i + 1 + "/" + PublicVariable.SplitedFilePath.Count;
                FileOperate.StatisticData(PublicVariable.SplitedFilePath[i], statisticResult, Rtb_SplitedFileInfo, tssl_Progress, Tssl_FileSize);
            }

            StreamWriter sw = new StreamWriter(@"F:\18120900\桌面\chaifen.csv", false, Encoding.Default);

            foreach (string key in statisticResult.Keys)
            {              
                for(int i = 0; i < statisticResult[key].GetLength(0); i++)
                {
                    string tempLine = key;
                    for (int k = 0; k < statisticResult[key].GetLength(1); k++)
                    {
                        tempLine += "," + statisticResult[key][i, k];
                    }
                    sw.WriteLine(tempLine);
                }
            }

            sw.Flush();
            sw.Close();
        }

        private void Tvw_Folder_AfterCheck(object sender, TreeViewEventArgs e)
        {
            string temp_path = PublicVariable.FolderPath + "\\" + e.Node.FullPath;

            if (e.Node.Checked)
            {
                if (!PublicVariable.SplitedFilePath.Contains(temp_path))
                {
                    PublicVariable.SplitedFilePath.Add(temp_path);
                    selectedNum += 1;
                }
            }
            else
            {
                if (PublicVariable.SplitedFilePath.Contains(temp_path))
                {
                    PublicVariable.SplitedFilePath.Remove(temp_path);
                    selectedNum -= 1;
                }
            }

            lbl_FolderInfo.Text = "文件夹目录 (" + selectedNum + ")";
        }

        private void Btn_TrcukOD_Click(object sender, EventArgs e)
        {
            Btn_TrcukOD.Enabled = false;
            if (PublicVariable.SplitedFilePath.Count > 0)
            {

                Dgv_StatisticSetting_CellLeave(this, null);

                //添加要生成的文件的标题行信息
                MatrixStruce = new PublicVariable.StatisticResultStruce();
                string title = "";
                foreach(PublicVariable.StatisticSetting v in PublicVariable.statisticSettings)
                {
                    title += v.FieldName + PublicVariable.StrConnector;
                }
                MatrixStruce.Title = title + "计数";
                MatrixStruce.Matrix = new Dictionary<string, List<double>>();

                for (int i = 0; i < PublicVariable.SplitedFilePath.Count; i++)
                {
                    Tssl_ProgressInfo.Text = i + 1 + "/" + PublicVariable.SplitedFilePath.Count;
                    FileOperate.StatisticODData(PublicVariable.SplitedFilePath[i], MatrixStruce, tssl_Progress, Tssl_FileSize);
                }

                Frm_DataView frm_DataView = new Frm_DataView();
                frm_DataView.Show();
                SendContentsEvent+= frm_DataView.FillDataGridview;

                if (MatrixStruce.Matrix.Count >= 10000)
                {
                    string message = string.Format("共有{0}行数据，数据导入较慢，是否继续导入！\r\n 是\t继续导入 \r\n否\t直接导出为文件",MatrixStruce.Matrix.Count);
                    string dialogResult = MessageBox.Show(message, "导入提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).ToString();
                    if (dialogResult == "Yes") 
                    {
                        SendContentsEvent?.Invoke(MatrixStruce);
                    }
                }
                else
                {
                    SendContentsEvent?.Invoke(MatrixStruce);
                }

                SendContentsEvent -= frm_DataView.FillDataGridview;

            }
            else
                MessageBox.Show("请在右侧列表框中选中要统计的文件！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            Btn_TrcukOD.Enabled = true;
        }

        private void Cmb_FileOpenWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tvw_Folder_DoubleClick(this, e);
        }

        private void Chk_NameFileByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_NameFileByDate.Checked)
            {
                Txt_FileName.Enabled = false;
            }
            else
            {
                Txt_FileName.Enabled = true;
            }
        }

        private void ReadSystemSetting()
        {
            chk_CommaSeparated.Checked = Properties.Settings.Default.chk_CommaSeparated;
            chk_TabSeparated.Checked = Properties.Settings.Default.chk_TabSeparated;
            chk_SemicolonSeparated.Checked = Properties.Settings.Default.chk_SemicolonSeparated;
            chk_SpaceSeparated.Checked = Properties.Settings.Default.chk_SpaceSeparated;
            chk_OtherSeparated.Checked = Properties.Settings.Default.chk_OtherSeparated;
            txt_OtherSeparator.Text = Properties.Settings.Default.txt_OtherSeparator;
        }

        private void Grp_Separator_Leave(object sender, EventArgs e)
        {
            char[] separator = new char[5];
            if (chk_TabSeparated.Checked)
                separator[0] = '\t';
            if (chk_SemicolonSeparated.Checked)
                separator[1] = ';';
            if (chk_CommaSeparated.Checked)
                separator[2] = ',';
            if (chk_SpaceSeparated.Checked)
                separator[3] = ' ';
            if (chk_OtherSeparated.Checked && txt_OtherSeparator.Text != "")
                    separator[4] = txt_OtherSeparator.Text.ToCharArray()[0];
            PublicVariable.Separator = separator;

            Properties.Settings.Default.chk_TabSeparated = chk_TabSeparated.Checked;
            Properties.Settings.Default.chk_SemicolonSeparated = chk_SemicolonSeparated.Checked;
            Properties.Settings.Default.chk_CommaSeparated = chk_CommaSeparated.Checked;
            Properties.Settings.Default.chk_SpaceSeparated = chk_SpaceSeparated.Checked;
            Properties.Settings.Default.chk_OtherSeparated = chk_OtherSeparated.Checked;
            Properties.Settings.Default.txt_OtherSeparator = txt_OtherSeparator.Text;
            Properties.Settings.Default.Save();
        }

        readonly Dictionary<string, PublicVariable.RateProgram> DicRateProgram = new Dictionary<string, PublicVariable.RateProgram>();
        private void Btn_ReadRateProgramFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName, Encoding.Default);
                
                //读取费率方案
                string line;
                string[] lineCols;

                string ID;
                while ((line = sr.ReadLine()) != null)
                {
                    lineCols = line.Split(new char[] { ',' });
                    ID = !Chk_ISContainENStation.Checked ? lineCols[1] + lineCols[5] : lineCols[0] + lineCols[1] + lineCols[5];

                    if (!DicRateProgram.ContainsKey(ID))
                    {
                        PublicVariable.RateProgram rateProgram = new PublicVariable.RateProgram
                        {
                            ENStationName = lineCols[0],
                            EXStationName = lineCols[1],
                            RoadName = lineCols[2],
                            RoadType = lineCols[3],
                            RateType = lineCols[4],
                            LanCode = lineCols[5],
                            LineDirection = lineCols[6],
                            RealStationName = lineCols[7],
                            Rate = new double[] { Convert.ToDouble(lineCols[8]), Convert.ToDouble(lineCols[9]), Convert.ToDouble(lineCols[10]),
                                Convert.ToDouble(lineCols[11]), Convert.ToDouble(lineCols[12]), Convert.ToDouble(lineCols[13]) }
                        };
                        DicRateProgram.Add(ID, rateProgram);
                    }
                }

                label6.Text = "读取完成！请进行下一步操作";
            }
        }

        private void Btn_RateProgramTest_Click(object sender, EventArgs e)
        {
            string path;
            if (Chk_NameFileByDate.Checked)
                path = Txt_FilePath.Text + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".csv";
            else
                path = Txt_FilePath.Text + Txt_FileName.Text;

            string SaveAsFilePath = path;
            StreamWriter sw = new StreamWriter(SaveAsFilePath, false, Encoding.Default);
            sw.WriteLine("出口站,车道,车型,轴数,限重,总重,应收金额,实收金额,里程,行驶里程,新费率下收费额,实际轴型,道路,道路类型,费率,车道方向,收费站名");

            //开始计算
            int temp_n = 0;
            int temp_k = 0;
            for (int i = 0; i < PublicVariable.SplitedFilePath.Count; i++)
            {

                int n = 0;
                int k = 0;
                Tssl_ProgressInfo.Text = i + 1 + "/" + PublicVariable.SplitedFilePath.Count;

                StreamReader sr2 = new StreamReader(PublicVariable.SplitedFilePath[i], Encoding.Default);

                string temp_line;
                string line;
                string[] lineCols;
                string ID;

                while ((line = sr2.ReadLine()) != null)
                {
                    n += 1;
                    try
                    {
                        lineCols = Regex.Replace(line, @"\s", "").Split(PublicVariable.Separator);
                        //EXStationName+EXLANE
                        if(!Chk_ISContainENStation.Checked)
                            ID = lineCols[6] + lineCols[7];
                        else
                            ID = lineCols[1] + lineCols[6] + lineCols[7];

                        temp_line = lineCols[6] + "," + lineCols[7] + "," + lineCols[9] + "," + lineCols[14] + "," + lineCols[15] + "," + lineCols[16] + "," +
                            lineCols[17] + "," + lineCols[18] + "," + lineCols[19] + "," + lineCols[20] + ",";
                        
                        if (lineCols[11] != "0") 
                        {
                            k += 1;

                            if (Convert.ToDouble(lineCols[14]) >= 2 && Convert.ToDouble(lineCols[14]) <= 6) 
                            {
                                if (DicRateProgram.ContainsKey(ID)) 
                                {
                                    if (DicRateProgram[ID].RoadType == "封闭式")
                                    {
                                        if (lineCols[14] == "2")
                                        {
                                            if (Convert.ToInt32(lineCols[16]) <= 4500)
                                                temp_line += DicRateProgram[ID].Rate[0] * Convert.ToInt32(lineCols[20]) / 1000 + ",1";
                                            else
                                                temp_line += DicRateProgram[ID].Rate[1] * Convert.ToInt32(lineCols[20]) / 1000 + ",2";
                                        }
                                        else
                                        {
                                            temp_line += DicRateProgram[ID].Rate[Convert.ToInt32(lineCols[14]) - 1] * Convert.ToInt32(lineCols[20]) / 1000 + "," + lineCols[14];
                                        }
                                    }
                                    else if (DicRateProgram[ID].RoadType == "开放式") 
                                    {
                                        if (lineCols[14] == "2")
                                        {
                                            if (Convert.ToInt32(lineCols[16]) <= 4500)
                                                temp_line += DicRateProgram[ID].Rate[0] + ",1";
                                            else
                                                temp_line += DicRateProgram[ID].Rate[1] + ",2";
                                        }
                                        else
                                        {
                                            temp_line += DicRateProgram[ID].Rate[Convert.ToInt32(lineCols[14]) - 1] + "," + lineCols[14];
                                        }
                                    }
                                    
                                }
                                else if (DicRateProgram.ContainsKey(lineCols[1] + lineCols[6])) 
                                {
                                    ID = lineCols[1] + lineCols[6];
                                    if (lineCols[14] == "2")
                                    {
                                        if (Convert.ToInt32(lineCols[16]) <= 4500)
                                            temp_line += DicRateProgram[ID].Rate[0] + ",1";
                                        else
                                            temp_line += DicRateProgram[ID].Rate[1] + ",2";
                                    }
                                    else
                                    {
                                        temp_line += DicRateProgram[ID].Rate[Convert.ToInt32(lineCols[14]) - 1] + "," + lineCols[14];
                                    }
                                }

                                temp_line += "," + DicRateProgram[ID].RoadName + "," + DicRateProgram[ID].RoadType + "," + DicRateProgram[ID].RateType + "," + DicRateProgram[ID].LineDirection + "," + DicRateProgram[ID].RealStationName;
                            }
                            
                            sw.WriteLine(temp_line);
                        }

                        if (n % 10000 == 0)
                        {
                            tssl_Progress.Text = n.ToString();
                            Application.DoEvents();
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                temp_n += n;
                temp_k += k;
            }

            label6.Text = "总共有：" + temp_n + "行数据\r\n已提取：" + temp_k + "行数据";
            sw.Flush();
            sw.Close();
        }

        private void Dgv_StatisticSetting_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            PublicVariable.statisticSettings = new List<PublicVariable.StatisticSetting>();
            PublicVariable.StatisticSetting statisticSetting;
            Loop(PublicVariable.DGVStruck.IDIndex);
            Loop(PublicVariable.DGVStruck.SumIndex);

            Txt_FieldSettingPreview.Clear();
            for (int i = 0; i < PublicVariable.statisticSettings.Count; i++) 
            {
                Txt_FieldSettingPreview.Text += PublicVariable.statisticSettings[i].FieldSettingMethod + ":" +
                   PublicVariable.statisticSettings[i].FieldName + "\r\n";
            }
            
            //DicFieldSetting中可能存在key相同的情况，如某个字段既是IDField又是SettingField
            void Loop(int index)
            {
                int Virtualindex = 0;
                for (int i = 0; i < Dgv_StatisticSetting.Rows.Count; i++)
                {
                    if ((bool)Dgv_StatisticSetting.Rows[i].Cells[index].EditedFormattedValue)
                    {
                        statisticSetting = new PublicVariable.StatisticSetting
                        {
                            VirtualIndex = Virtualindex,
                            RealIndex = Convert.ToInt32(Dgv_StatisticSetting.Rows[i].Cells[PublicVariable.DGVStruck.SerialNumberIndex].Value) - 1,
                            FieldSettingMethod = Dgv_StatisticSetting.Columns[index].HeaderText,
                            FieldName = Dgv_StatisticSetting.Rows[i].Cells[PublicVariable.DGVStruck.ColumnHeadingIndex].Value.ToString()
                        };
                        PublicVariable.statisticSettings.Add(statisticSetting);
                        Virtualindex += 1;
                    }
                }
            }
        }

        private void Btn_CalculateWeight_Click(object sender, EventArgs e)
        {
           
        }

        private void Btn_ReadStationInfo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName, Encoding.Default);

                //读取路段信息
                string line;
                string[] lineCols;

                string ID;
                while ((line = sr.ReadLine()) != null)
                {
                    lineCols = line.Split(new char[] { ',' });
                    ID = lineCols[0] + lineCols[5];

                    if (!DicRateProgram.ContainsKey(ID))
                    {
                        PublicVariable.RateProgram rateProgram = new PublicVariable.RateProgram
                        {
                            ENStationName = lineCols[0],
                            EXStationName = lineCols[1],
                            RoadName = lineCols[2],
                            RoadType = lineCols[3],
                            RateType = lineCols[4],
                            LanCode = lineCols[5],
                            LineDirection = lineCols[6],
                            RealStationName = lineCols[7],
                            Distance = lineCols[8],
                            Rate = new double[] { Convert.ToDouble(lineCols[9]), Convert.ToDouble(lineCols[10]), Convert.ToDouble(lineCols[11]),
                                Convert.ToDouble(lineCols[12]), Convert.ToDouble(lineCols[13]), Convert.ToDouble(lineCols[14]) }
                        };
                        DicRateProgram.Add(ID, rateProgram);
                    }
                }

                label6.Text = "读取完成！请进行下一步操作";
            }
        }

        private void Btn_DealFile_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PublicVariable.SplitedFilePath.Count; i++)
            {
                Tssl_ProgressInfo.Text = i + 1 + "/" + PublicVariable.SplitedFilePath.Count;
                StreamReader sr = new StreamReader(PublicVariable.SplitedFilePath[i], Encoding.Default);
                StreamWriter sw = new StreamWriter(@"F:\18120900\桌面\temp_File.csv", false, Encoding.Default);

                string line;
                string writline;
                string[] lineCols;
                int n = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    line = Regex.Replace(line, @"\s", "").Replace(";", ",");
                    lineCols = line.Split(new char[] { ',' });

                    //仅提取货车数据，客车的数据进行省略
                    if (lineCols[6] == "1" || lineCols[6] == "2") 
                    {
                        //根据出口收费站编码以及车道编码作为keys
                        string ID1 = lineCols[1];
                        string ID2 = lineCols[1] + lineCols[3];

                        if (DicRateProgram.ContainsKey(ID1) && DicRateProgram[ID1].RoadType == "封闭式")
                        {
                            writline = line + "," + lineCols[12] + "," + DicRateProgram[ID1].RoadName + "," + DicRateProgram[ID1].RoadType + "," + DicRateProgram[ID1].RealStationName;
                        }
                        else if (DicRateProgram.ContainsKey(ID2) && DicRateProgram[ID2].RoadType == "开放式")
                        {
                            writline = line + "," + DicRateProgram[ID2].Distance + "," + DicRateProgram[ID2].RoadName + "," + DicRateProgram[ID2].RoadType + "," + DicRateProgram[ID2].RealStationName;
                        }
                        else
                        {
                            writline = line;
                        }

                        sw.WriteLine(writline);
                    }
                    
                    n += 1;
                    if (n % 10000 == 0)
                    {
                        tssl_Progress.Text = n.ToString();
                        Application.DoEvents();
                    }
                }
                sw.Flush();
                sw.Close();
            }
        }

        private void Btn_Cal_Click(object sender, EventArgs e)
        {
            
        }
    }
}
