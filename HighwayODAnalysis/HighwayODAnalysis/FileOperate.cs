using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HighwayODAnalysis
{
    class FileOperate
    {
        public StreamWriter fs_Output;
        PublicVariable.TableStructure tableStructure;
        readonly Dictionary<string, PublicVariable.TableStructure> ODEnterExitStationID = new Dictionary<string, PublicVariable.TableStructure>();
        
        public string OpenFile()
        {
            OpenFileDialog openFileDialog_RawData = new OpenFileDialog
            {
                Filter = "TXT File(*.txt)|*.*"
            };
            string filePath = "";

            if (openFileDialog_RawData.ShowDialog() == DialogResult.OK && openFileDialog_RawData.FilterIndex == 1)
            {
                if (File.Exists(openFileDialog_RawData.FileName))
                {
                    filePath = openFileDialog_RawData.FileName;
                }
            }

            return filePath;
        }

        /// <summary>
        /// 读取文件数据
        /// </summary>
        /// <param name="textBox">文本输出位置</param>
        /// <param name="filePath">文本路径</param>
        /// <param name="fileLines">读取行数</param>
        /// <param name="readWay">读取方式，readWay:0 不显示转义符；readWay:1 显示转义符</param>
        public void ReadFile(RichTextBox textBox, string filePath, long fileLines = 100, int readWay = 0,bool isRemoveSpace=false)
        {
            textBox.Clear();
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            string line;
            for (int i = 0; i <= fileLines; i++)
            {
                line = sr.ReadLine();
                if (isRemoveSpace)
                {
                    line = Regex.Replace(line, @"\s", "");
                }

                if (readWay == 1)
                    textBox.Text += line.Replace("\t", @"\t") + "\r\n";                
                else
                    textBox.Text += string.Format("{0}\r\n",line.Trim());
            }
            sr.Close();
        }

        public void SaveFile(string filePath, PublicVariable.StatisticResultStruce contents)
        {
            StreamWriter sw = new StreamWriter(filePath, false, Encoding.Default);

            sw.WriteLine(contents.Title+"车辆数");

            foreach (string s in contents.Matrix.Keys)
            {
                string tempLine = s.ToString();
                tempLine += string.Join(",", contents.Matrix[s]);
                sw.WriteLine(tempLine);
            }
            sw.Flush();
            sw.Close();

            string messageinfo = string.Format("已完成！\r\n保存路径:{0}",filePath);
            MessageBox.Show(messageinfo, "系统提示", MessageBoxButtons.OK);
        }

        //把选中文件夹下的子目录及文件写入treeview中
        public void PaintTreeView(TreeView treeView, string fullPath)
        {
            try
            {
                treeView.Nodes.Clear(); //清空TreeView

                DirectoryInfo dirs = new DirectoryInfo(fullPath); //获得程序所在路径的目录对象
                DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
                FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
                int dircount = dir.Count();//获得文件夹对象数量
                int filecount = file.Count();//获得文件对象数量

                //循环文件夹
                for (int i = 0; i < dircount; i++)
                {
                    treeView.Nodes.Add(dir[i].Name);
                    string pathNode = fullPath + "\\" + dir[i].Name;
                    GetMultiNode(treeView.Nodes[i], pathNode);
                }

                //循环文件
                for (int j = 0; j < filecount; j++)
                {
                    treeView.Nodes.Add(file[j].Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //把选中文件夹下的子目录的子目录及文件写入treeview中
        private bool GetMultiNode(TreeNode treeNode, string path)
        {
            if (Directory.Exists(path) == false)
            {
                return false;
            }

            DirectoryInfo dirs = new DirectoryInfo(path); //获得程序所在路径的目录对象
            DirectoryInfo[] dir = dirs.GetDirectories();//获得目录下文件夹对象
            FileInfo[] file = dirs.GetFiles();//获得目录下文件对象
            int dircount = dir.Count();//获得文件夹对象数量
            int filecount = file.Count();//获得文件对象数量
            int sumcount = dircount + filecount;

            if (sumcount == 0)
            {
                return false;
            }

            //循环文件夹
            for (int j = 0; j < dircount; j++)
            {
                treeNode.Nodes.Add(dir[j].Name);
                string pathNodeB = path + "\\" + dir[j].Name;
                GetMultiNode(treeNode.Nodes[j], pathNodeB);
            }

            //循环文件
            for (int j = 0; j < filecount; j++)
            {
                treeNode.Nodes.Add(file[j].Name);
            }
            return true;
        }

        //加载目标文件，也即把文件拆分为几分
        /// <summary>
        /// 加载目标文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="textBox">显示拆分信息</param>
        /// <param name="progressBar">拆分进度条</param>
        /// <param name="label">显示文件大小</param>
        public void LoadSplitingFile(string filePath, RichTextBox textBox, ToolStripLabel progressInfoLabel, ToolStripLabel label = null)
        {
            int n = 0;
            int sampSize = 0;
            StreamReader sr = new StreamReader(filePath, Encoding.Default);

            //在label控件上显示文件的大小
            if (label != null)
            {
                PrintFileInfo(label, filePath);
            }

            WriteToTextBox(textBox, filePath + "\t开始时间:" + DateTime.Now.ToLongTimeString() + "\t");
            tableStructure = new PublicVariable.TableStructure();

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    string[] lineCols = DealLine(line);

                    double[] splitDistance = new double[Convert.ToInt32(lineCols[5])];
                    string[] splitSectionID = new string[Convert.ToInt32(lineCols[5])];

                    for (int i = 6; i < lineCols.Length / 2 - 3; i++)
                    {
                        splitDistance[i - 6] = Convert.ToDouble(lineCols[(i - 6) * 2 + 6]);
                        splitSectionID[i - 6] = lineCols[(i - 6) * 2 + 7];
                    }

                    tableStructure.ODEnterStationName = lineCols[2];
                    tableStructure.ODExitStationName = lineCols[3];
                    tableStructure.ODDistance = Convert.ToDouble(lineCols[4]);
                    tableStructure.SplitNum = Convert.ToInt32(lineCols[5]);
                    tableStructure.SplitDistance = splitDistance;
                    tableStructure.SplitSectionID = splitSectionID;

                    n += 1;
                    if (n % 10000 == 0)
                    {
                        progressInfoLabel.Text = n.ToString();
                        Application.DoEvents();
                    }

                    if (!ODEnterExitStationID.ContainsKey(lineCols[0] + lineCols[1]))
                    {
                        ODEnterExitStationID.Add(lineCols[0] + lineCols[1], tableStructure);
                        sampSize += 1;
                    }
                }
                catch (Exception)
                {
                    WriteToTextBox(textBox, "\r\n第" + n + "行出现错误");
                    _ = sr.ReadLine();
                    continue;
                }
            }
            sr.Close();
            WriteToTextBox(textBox, "完成时间:" + DateTime.Now.ToLongTimeString() + "\t拆分前数量:" + n + "\t拆分后数量:" + sampSize + "\r\n");
        }

        //加载拆分文件，也即将要被拆分的文件
        /// <summary>
        /// 加载拆分文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="textBox">显示拆分信息</param>
        /// <param name="progressBar">拆分进度条</param>
        /// <param name="label">显示文件大小</param>
        public void LoadSplitedFile(string filePath, RichTextBox textBox, ToolStripLabel progressInfoLabel, ToolStripLabel label = null)
        {
            long SampleSize = 1;

            //在label控件上显示文件的大小
            if (label != null)
            {
                PrintFileInfo(label, filePath);
            }

            WriteToTextBox(textBox, filePath + "\t开始时间:" + DateTime.Now.ToLongTimeString() + "\t");

            string CarID, EnterStationID, EnterStationName, ExitStationID, ExitStationName;
            string CarType;
            int VehicleType, AxlesNum, Weight;
            double Distance, Toll;
            int n = 1;
            int deleteNum = 0;
            string txtPath = PublicVariable.DbPath + "\\Output\\ODSplit.txt";
            fs_Output = new StreamWriter(txtPath, false, Encoding.Default);
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    string[] lineCols = DealLine(line);

                    CarID = lineCols[0];
                    EnterStationID = lineCols[1];
                    EnterStationName = lineCols[2];
                    ExitStationID = lineCols[3];
                    ExitStationName = lineCols[4];
                    CarType = lineCols[5];
                    VehicleType = Convert.ToInt32(lineCols[6]);
                    AxlesNum = Convert.ToInt32(lineCols[7]);
                    Weight = Convert.ToInt32(lineCols[8]);
                    Distance = Convert.ToDouble(lineCols[9]);
                    Toll = Convert.ToDouble(lineCols[10]);
                    string keys = EnterStationID + ExitStationID;
                    string insert_Record;
                    if (ODEnterExitStationID.ContainsKey(keys))
                    {
                        for (int i = 0; i < ODEnterExitStationID[keys].SplitNum; i++)
                        {
                            insert_Record = Convert.ToString(SampleSize) + "," + CarID + "," + EnterStationID + "," + EnterStationName + "," + ExitStationID + "," + ExitStationName + "," + CarType + "," + VehicleType + "," + AxlesNum + "," + Weight + "," + Distance + "," + Toll
                                + "," + ODEnterExitStationID[keys].SplitNum + "," + ODEnterExitStationID[keys].SplitDistance[i] + "," + ODEnterExitStationID[keys].SplitSectionID[i] + "," + Convert.ToInt32(Toll * ODEnterExitStationID[keys].SplitDistance[i] / ODEnterExitStationID[keys].ODDistance);

                            SampleSize += 1;
                            fs_Output.WriteLine(insert_Record);
                        }
                    }
                    else
                    {
                        insert_Record = Convert.ToString(SampleSize) + "," + CarID + "," + EnterStationID + "," + EnterStationName + "," + ExitStationID + "," + ExitStationName + "," + CarType + "," + VehicleType + "," + AxlesNum + "," + Weight + "," + Distance + "," + Toll;
                        fs_Output.WriteLine(insert_Record);
                        SampleSize += 1;
                        deleteNum += 1;
                    }

                    n += 1;
                    if (n % 10000 == 0 )
                    {
                        progressInfoLabel.Text = n.ToString();
                        fs_Output.Flush();
                        Application.DoEvents();
                    }
                }
                catch (Exception)
                {
                    WriteToTextBox(textBox, "\r\n第" + n + "行出现错误");
                    _ = sr.ReadLine();
                    continue;
                }
            }

            sr.Close();
            fs_Output.Close();
            WriteToTextBox(textBox, "完成时间:"+DateTime.Now.ToLongTimeString() + "\t拆分前数量:" + n + "\t拆分后数量:" + SampleSize + "\r\n");
        }

        public Dictionary<string, double[,]> StatisticData(string filePath, Dictionary<string, double[,]> statisticResult, RichTextBox textBox, ToolStripLabel progressInfoLabel, ToolStripLabel label = null)
        {      

            if (label != null)
            {
                PrintFileInfo(label, filePath);
            }

            int n = 1;
            string[] lineCols;
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                try
                {
                    lineCols = DealLine(line);
                    //EXStationName+EXLANE+EXVEHCLASS+AXISNUM
                    string ID = lineCols[6] + PublicVariable.StrConnector + lineCols[7] + PublicVariable.StrConnector + lineCols[9] + PublicVariable.StrConnector + lineCols[14];
                    double totalWeight = Convert.ToDouble(lineCols[16]);
                    double tollMoney = Convert.ToDouble(lineCols[17]);
                    double realMoney = Convert.ToDouble(lineCols[18]);
                    double miles = Convert.ToDouble(lineCols[19]);
                    double realMiles = Convert.ToDouble(lineCols[20]);

                    //20191227添加筛选条件realMiles != 0
                    if (lineCols[11] == "1" && tollMoney != 0) //只提取货车的数据
                    {
                        lineLabel:
                        if (statisticResult.ContainsKey(ID))
                        {
                            switch (lineCols[14])
                            {
                                case "6":
                                    if (totalWeight < 19000)
                                        AddToDic(ID, 0);
                                    else if (totalWeight < 24500)
                                        AddToDic(ID, 1);
                                    else if (totalWeight < 34300)
                                        AddToDic(ID, 2);
                                    else if (totalWeight < 44100)
                                        AddToDic(ID, 3);
                                    else if (totalWeight < 49000)
                                        AddToDic(ID, 4);
                                    else
                                        AddToDic(ID, 5);
                                    break;
                                case "5":
                                    if (totalWeight < 17000)
                                        AddToDic(ID, 0);
                                    else if (totalWeight < 21500)
                                        AddToDic(ID, 1);
                                    else if (totalWeight < 30100)
                                        AddToDic(ID, 2);
                                    else if (totalWeight < 38700)
                                        AddToDic(ID, 3);
                                    else if (totalWeight < 43000)
                                        AddToDic(ID, 4);
                                    else
                                        AddToDic(ID, 5);
                                    break;
                                case "4":
                                    if (totalWeight < 13700)
                                        AddToDic(ID, 0);
                                    else if (totalWeight < 18000)
                                        AddToDic(ID, 1);
                                    else if (totalWeight < 25200)
                                        AddToDic(ID, 2);
                                    else if (totalWeight < 32400)
                                        AddToDic(ID, 3);
                                    else if (totalWeight < 36000)
                                        AddToDic(ID, 4);
                                    else
                                        AddToDic(ID, 5);
                                    break;
                                case "3":
                                    if (totalWeight < 10800)
                                        AddToDic(ID, 0);
                                    else if (totalWeight < 13600)
                                        AddToDic(ID, 1);
                                    else if (totalWeight < 18900)
                                        AddToDic(ID, 2);
                                    else if (totalWeight < 24300)
                                        AddToDic(ID, 3);
                                    else if (totalWeight < 27000)
                                        AddToDic(ID, 4);
                                    else
                                        AddToDic(ID, 5);
                                    break;
                                case "2":
                                    if (totalWeight <= 4500)
                                        AddToDic(ID, 0);
                                    else if (totalWeight < 6300)
                                        AddToDic(ID, 1);
                                    else if (totalWeight < 9000)
                                        AddToDic(ID, 2);
                                    else if (totalWeight < 12600)
                                        AddToDic(ID, 3);
                                    else if (totalWeight < 16200)
                                        AddToDic(ID, 4);
                                    else if (totalWeight < 18000)
                                        AddToDic(ID, 5);
                                    else
                                        AddToDic(ID, 6);
                                    break;
                            }
                        }
                        else
                        {
                            statisticResult.Add(ID, new double[7, 6]);
                            goto lineLabel;
                        }
                    }

                    n += 1;
                    if (n % 10000 == 0)
                    {
                        progressInfoLabel.Text = n.ToString();
                        Application.DoEvents();
                    }

                    void AddToDic(string id, int row)
                    {
                        statisticResult[id][row, 0] += 1;
                        statisticResult[id][row, 1] += totalWeight;
                        statisticResult[id][row, 2] += tollMoney;
                        statisticResult[id][row, 3] += realMoney;
                        statisticResult[id][row, 4] += miles;
                        statisticResult[id][row, 5] += realMiles;
                    }
                }
                catch (Exception)
                {
                    WriteToTextBox(textBox, "\r\n第" + n + "行出现错误");
                    continue;
                }
            }
            sr.Close();
            return statisticResult;
        }

        public void LoadFileInfoToDgv(DataGridView gridView, string filePath)
        {
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            string[] lineCols = DealLine(sr.ReadLine());
            bool[] isNumber = IsNumber(filePath);

            for (int i = 0; i < lineCols.Count(); i++)
            {
                int index = gridView.Rows.Add();
                gridView.Rows[index].Cells[0].Value = index + 1;
                gridView.Rows[index].Cells[2].Value = lineCols[i];
                if (!isNumber[i])
                {
                    gridView.Rows[index].Cells[4].ReadOnly = true;
                    gridView.Rows[index].Cells[3].Value = PublicVariable.stringType;
                }   
                else
                {
                    gridView.Rows[index].Cells[3].Value = PublicVariable.numType;
                }
            }
        }

        public PublicVariable.StatisticResultStruce StatisticODData(string filePath, PublicVariable.StatisticResultStruce statisticResult, ToolStripLabel stripLabel, ToolStripLabel label = null)
        {
            if (label != null)
            {
                PrintFileInfo(label, filePath);
            }

            int n = 0;
            int errorLineCount = 0;
            string[] lineCols;
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            string line;
            List<int> lstIDindex = new List<int>();
            foreach (PublicVariable.StatisticSetting v in PublicVariable.statisticSettings)
            {
                if (v.FieldSettingMethod == PublicVariable.DGVStruck.ID)
                {
                    lstIDindex.Add(v.RealIndex);
                }
            }

            List<int[]> lstSumIndex = new List<int[]>();
            foreach (PublicVariable.StatisticSetting v in PublicVariable.statisticSettings)
            {
                int[] temp = new int[2];
                if (v.FieldSettingMethod == PublicVariable.DGVStruck.Sum)
                {
                    temp[0] = v.VirtualIndex;
                    temp[1] = v.RealIndex;
                    lstSumIndex.Add(temp);
                }
            }

            while ((line = sr.ReadLine()) != null)
            {
                n += 1;
                string ID = "";
                try
                {
                    lineCols = line.Split(PublicVariable.Separator);
                    foreach (int index in lstIDindex)
                    {
                        ID += ID != "" ? PublicVariable.StrConnector + lineCols[index] : lineCols[index];
                    }

                    sum(ID, lineCols);
                }
                catch (Exception)
                {
                    //_ = sr.ReadLine();
                    if (statisticResult.Matrix.ContainsKey(ID) && statisticResult.Matrix[ID].Count == 0)
                    {
                        statisticResult.Matrix.Remove(ID);
                    } 
                    errorLineCount += 1;
                    continue;
                }

                if (n % 10000 == 0)
                {
                    stripLabel.Text = n + "/" + errorLineCount;
                    Application.DoEvents();
                }
            }
            sr.Close();
            return statisticResult;

            void sum(string ID,string[] str)
            {
                if (statisticResult.Matrix.ContainsKey(ID))
                {
                    //用来统计该ID的数量
                    statisticResult.Matrix[ID][statisticResult.Matrix[ID].Count - 1] += 1;

                    foreach(int[] index in lstSumIndex)
                    {
                        statisticResult.Matrix[ID][index[0]] += Convert.ToDouble(str[index[1]]);
                    }
                }
                else
                {
                    PublicVariable.StatisticResultStruce statisticResultStruc = new PublicVariable.StatisticResultStruce
                    {
                        Matrix = new Dictionary<string, List<double>>()
                    };
                    List<double> matrix = new List<double>();
                    statisticResult.Matrix.Add(ID, matrix);

                    foreach (int[] index in lstSumIndex)
                    {
                        statisticResult.Matrix[ID].Add(Convert.ToDouble(str[index[1]]));
                    }

                    //用来统计该ID有多少辆车
                    matrix.Add(1);
                }
            }
        }

        #region 私有方法
        private void WriteToTextBox(RichTextBox richTextBox, string contents)
        {
            richTextBox.Text += contents;
            Application.DoEvents();
        }

        private void PrintFileInfo(ToolStripLabel label, string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if(fileInfo!=null && fileInfo.Exists)
            {
                label.Text = "文件大小:" + Math.Ceiling(fileInfo.Length / 1024.0 / 1024.0) + "MB";
            }
        }

        private bool[] IsNumber(string filePath)
        {
            string reg = "^[-\\+]?([0-9]+\\.?)?[0-9]+$";
            
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            int fieldNumber = DealLine(sr.ReadLine()).Length;

            bool[] isNumber = new bool[fieldNumber];
            string[,] tempLine = new string[PublicVariable.ReadLineCount, fieldNumber];
            int[] isNumberCount = new int[fieldNumber];

            for (int i = 0; i < PublicVariable.ReadLineCount; i++)
            {
                string[] tempLineCols = DealLine(sr.ReadLine());
                for (int k = 0; k < fieldNumber; k++)
                {
                    tempLine[i, k] = tempLineCols[k];
                    if (Regex.IsMatch(tempLine[i, k], reg))
                    {
                        isNumberCount[k] += 1;
                    }
                }
            }

            for(int i = 0; i < fieldNumber; i++)
            {
                if (isNumberCount[i] >= PublicVariable.ReadLineCount / 2)
                {
                    isNumber[i] = true;
                }
            }

            return isNumber;
        }
        
        private string[] DealLine(string line)
        {
            string[] LineCols = Regex.Replace(line.Replace(PublicVariable.Replacement, ","), @"\s+", " ").Split(PublicVariable.Separator);
            return LineCols;
        }

        public void ShowForm<T>(Form form, Form MdiParent = null) where T : Form, new()
        {
            if (form == null || form.IsDisposed)
            {
                form = new T();
                if (MdiParent != null)
                    form.MdiParent = MdiParent;
            }
            else
            {
                form.WindowState = FormWindowState.Normal;
                form.Activate();
            }

            form.Show();
        }       
        #endregion
    }
}
