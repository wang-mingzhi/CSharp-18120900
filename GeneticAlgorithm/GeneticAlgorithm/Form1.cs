using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace GeneticAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<VariateStruck> variateInfo;
        public struct VariateStruck
        {
            public double C0 { get; set; }
            public double C1 { get; set; }
            public double A0 { get; set; }
            public double A1 { get; set; }
            public double A2 { get; set; }
            public double A3 { get; set; }
            public int MinValue { get; set; }
            public int MaxValue { get; set; }
        }

        public static int BitsLength { get; set; }
        public static int ChromosomeLength { get; set; }
        public static int GenesLength { get; set; }
        public static int LoopTimes { get; set; }

        static int RandomSeedbyGuid => new Guid().GetHashCode();

        private static List<Chromosome> Chromosomes { get; set; } = new List<Chromosome>();
        private static List<Chromosome> ChromosomesChild { get; set; } = new List<Chromosome>();
        public static Random Random { get; set; } = new Random(RandomSeedbyGuid);

        private void Form1_Load(object sender, EventArgs e)
        {
            Cmb_recordType.SelectedIndex = 2;
            double[][] value = new double[8][];
            value[0] = new double[] { 152, 0.20, 428, 2150, 10, 60 };
            value[1] = new double[] { 152, 0.09, 248, 2750, 9, 60 };
            value[2] = new double[] { 152, 0.09, 144, 1550, 10, 60 };
            value[3] = new double[] { 152, 0.33, 912, 2750, 13, 60 };
            value[4] = new double[] { 152, 0.14, 216, 1550, 10, 60 };
            value[5] = new double[] { 152, 0.08, 288, 3450, 9, 60 };
            value[6] = new double[] { 152, 0.23, 356, 1550, 10, 60 };
            value[7] = new double[] { 152, 0.30, 832, 2750, 13, 60 };
            for(int i = 0; i < value.GetLength(0); i++)
            {
                int index = Dgv_coefficient.Rows.Add();
                for (int c = 0; c < value[i].Length; c++)
                {
                    Dgv_coefficient.Rows[index].Cells[c].Value = value[i][c];
                }
            }
        }

        private void Btn_Begin_Click(object sender, EventArgs e)
        {
            ReadConfig(Dgv_coefficient);  // 读取参数设置
            Init();  // 第一步：初始化;
            Dictionary<string, double> dict_result = new Dictionary<string, double>();
            Pgb_Progress.Maximum = LoopTimes;
            for (int i = 0; i < LoopTimes; i++)
            {
                Pgb_Progress.Value = i + 1;
                UpdateChromosomes();  // 重新计算fit值,累计概率归0,计算变量是否满足约束

                // 记录最大值的信息
                for (int ii = 0; ii < Chromosomes.Count; ii++)
                {
                    string result = string.Join(",", DeCode(Chromosomes[ii].Genes));
                    if (IsMeetConditions(Chromosomes[ii]) & dict_result.Values.Count == 0) 
                    {
                        dict_result.Add(result, Chromosomes[ii].FitValue);
                    }
                    if (IsMeetConditions(Chromosomes[ii]) & Chromosomes[ii].FitValue > dict_result.Values.Max())
                    {
                        if (!dict_result.ContainsKey(result))
                        {
                            dict_result.Add(result, Chromosomes[ii].FitValue);
                        }
                    }
                }

                CalFitPercent();  // 第二步：计算适应度
                Print(Txt_logFilePath.Text, i, dict_result.Values.Max(), Cmb_recordType.SelectedIndex);  // 输出相关信息
                UpdateNext();  // 第三步：选择算法
                CrossOperate(Convert.ToDouble(Txt_pc.Text));  // 第四步：交叉得到新个体;
                VariationOperate(Convert.ToDouble(Txt_pm.Text));  // 第五步：变异操作;
            }
            foreach (var key in dict_result.Keys.Where(key => dict_result[key] == dict_result.Values.Max()))
            {
                Rtb_result.Text += LoopTimes + "\t" + Math.Round(dict_result.Values.Max(), 2) + "\t" + key + "\r\n";
            }
        }

        /// <summary>
        /// 读取DataGridView中的数据
        /// </summary>
        /// <param name="dataGridView">包含目标数据的控件</param>
        private void ReadConfig(DataGridView dataGridView)
        {
            int rows = dataGridView.Rows.Count;
            variateInfo = new List<VariateStruck>();
            for (int r = 0; r < rows; r++)
            {
                var rowsData = new VariateStruck()
                {
                    C0 = Convert.ToDouble(Txt_coe1.Text),
                    C1 = Convert.ToDouble(Txt_coe2.Text),
                    A0 = Convert.ToDouble(dataGridView.Rows[r].Cells[0].Value),
                    A1 = Convert.ToDouble(dataGridView.Rows[r].Cells[1].Value),
                    A2 = Convert.ToDouble(dataGridView.Rows[r].Cells[2].Value),
                    A3 = Convert.ToDouble(dataGridView.Rows[r].Cells[3].Value),
                    MinValue = Convert.ToInt32(dataGridView.Rows[r].Cells[4].Value),
                    MaxValue = Convert.ToInt32(dataGridView.Rows[r].Cells[5].Value),
                };
                variateInfo.Add(rowsData);
            }

            // 读取其他配置
            BitsLength = Convert.ToInt32(Txt_BitsLength.Text);
            ChromosomeLength = Convert.ToInt32(Txt_chromosomeLength.Text);
            GenesLength = Convert.ToInt32(Txt_GenesLength.Text);
            LoopTimes = Convert.ToInt32(Txt_loopTimes.Text);
            if (Rtb_result.Text == "")
            {
                Rtb_result.Text = "多约束遗传算法\r\n";
                Rtb_result.AppendText("选择算法：轮盘赌算法\r\n");
                Rtb_result.AppendText("迭代次数\t最大值\t变量值\r\n");
            }
            if (Chk_ClearText.Checked & Cmb_recordType.SelectedIndex != 2) 
                System.IO.File.WriteAllText(Txt_logFilePath.Text, string.Empty);
        }

        /// <summary>
        /// 初始化，设置染色体
        /// </summary>
        private static void Init()
        {
            Chromosomes.Clear();
            for (int i = 0; i < ChromosomeLength; i++)
            {
                int[,] valueLimit = new int[GenesLength, 2];
                for (int ii = 0; ii < GenesLength; ii++)
                {
                    valueLimit[ii, 0] = variateInfo[ii].MinValue;
                    valueLimit[ii, 1] = variateInfo[ii].MaxValue;
                }
                Chromosome chromosome = new Chromosome {ValueLimit = valueLimit, };
                chromosome.Genes = IniVariate(chromosome);
                Chromosomes.Add(chromosome);
            }
        }

        /// <summary>
        /// 根据约束条件初始化染色体的基因序列
        /// </summary>
        /// <param name="chromosome">染色体</param>
        private static int[][] IniVariate(Chromosome chromosome)
        {
            int[][] result = new int[GenesLength][];
            try
            {
                /*
                 * x1 = 136-x2-x7-x8 =》 min_x1 <= 136-x2-x7-x8 <= max_x1
                 * x3 =    -x4+x7+x8 =》 min_x3 <=    -x4+x7+x8 <= max_x3
                 * x5 = 136-x6-x7-x8 =》 min_x5 <= 136-x6-x7-x8 <= max_x5
                 * 
                 * 对x7的值进行分析，对x7的取值范围尽可能小
                 * 然后从内往外进行推算，内部的取值范围尽可能大
                 * 推算顺序：x7 -> x8 -> x2 -> x4 -> x6 -> x1 -> x3 -> x5
                 * 
                 */
                int[,] vl = chromosome.ValueLimit;
                int[] rd = new int[BitsLength];
                int lowlimit = Math.Max(vl[2, 0] + vl[3, 0] - vl[7, 1], vl[6, 0]);
                int hightlimit = Math.Min(vl[2, 1] + vl[3, 1] - vl[7, 0], vl[6, 1]);
                rd[6] = Random.Next(lowlimit, hightlimit);
                rd[7] = Random.Next(Math.Max(vl[2, 0] + vl[3, 0] - rd[6], vl[7, 0]), Math.Min(vl[2, 1] + vl[3, 1] - rd[6], vl[7, 1]));
                rd[1] = Random.Next(Math.Max(136 - vl[0, 1] - rd[6] - rd[7], vl[1, 0]), Math.Min(136 - vl[0, 0] - rd[6] - rd[7], vl[1, 1]));
                rd[3] = Random.Next(Math.Max(rd[6] + rd[7] - vl[2, 1], vl[3, 0]), Math.Min(rd[6] + rd[7] - vl[2, 0], vl[3, 1]));
                rd[5] = Random.Next(Math.Max(136 - vl[4, 1] - rd[6] - rd[7], vl[5, 0]), Math.Min(136 - vl[4, 0] - rd[6] - rd[7], vl[5, 1]));
                rd[0] = 136 - rd[1] - rd[6] - rd[7];
                rd[2] = -rd[3] + rd[6] + rd[7];
                rd[4] = 136 - rd[5] - rd[6] - rd[7];
                for (int i = 0; i < GenesLength; i += 4) 
                {
                    if (rd[i + 1] > rd[i])
                    {
                        int t = rd[i];
                        rd[i] = rd[i + 1];
                        rd[i + 1] = t;
                    }
                    if (rd[i + 3] < rd[i + 2]) 
                    {
                        int t = rd[i + 2];
                        rd[i + 2] = rd[i + 3];
                        rd[i + 3] = t;
                    }
                }
                for (int i = 0; i < rd.Length; i++)
                {
                    result[i] = EnCoding(rd[i]);
                }
            }
            catch (Exception)
            {
                for(int i = 0; i < GenesLength; i++)
                {
                    result[i] = EnCoding(Random.Next(chromosome.ValueLimit[i, 0], chromosome.ValueLimit[i, 1]));
                }
            }
            return result;
        }

        /// <summary>
        /// 重新计算适应值、累计概率归0
        /// </summary>
        private static void UpdateChromosomes()
        {
            for (int i = 0; i < ChromosomeLength; i++)
            {
                Chromosomes[i].Genes = IsMeetConditions(Chromosomes[i]) ? Chromosomes[i].Genes : IniVariate(Chromosomes[i]);
                Chromosomes[i].FitValue = GetFitValue(Chromosomes[i]);
                Chromosomes[i].Probability = 0;
            }
        }

        /// <summary>
        /// 判断变量是否满足条件
        /// </summary>
        private static bool IsMeetConditions(Chromosome cs)
        {
            int[] gene = DeCode(cs.Genes);
            bool cd1 = (gene[0] + gene[1]) == (gene[4] + gene[5]);
            bool cd2 = (gene[2] + gene[3]) == (gene[6] + gene[7]);
            bool cd3 = (gene[0] + gene[1] + gene[2] + gene[3]) == 136;
            bool cd4 = (gene[4] + gene[5] + gene[6] + gene[7]) == 136;
            bool cd5 = gene[0] >= gene[1];
            bool cd6 = gene[3] >= gene[2];
            bool cd7 = gene[4] >= gene[5];
            bool cd8 = gene[7] >= gene[6];
            bool cd9 = gene[3] + gene[2] > gene[0] + gene[1];
            bool cd10 = gene[6] + gene[7] > gene[4] + gene[5];
            bool cd11 = gene[3] >= Math.Max(Math.Max(Math.Max(gene[0], gene[1]), gene[2]), gene[3]);
            bool cd12 = gene[7] >= Math.Max(Math.Max(Math.Max(gene[4], gene[5]), gene[6]), gene[7]);
            for (int j = 0; j < GenesLength; j++)
            {
                if (gene[j] < cs.ValueLimit[j, 0] || gene[j] > cs.ValueLimit[j, 1])
                {
                    return false;
                }
            }
            return cd1 & cd2 & cd3 & cd4 & cd5 & cd6 & cd7 & cd8 & cd9 & cd10 & cd11 & cd12;
        }

        /// <summary>
        /// 解码（二进制转十进制）
        /// </summary>
        /// <param name="gene">基因片段</param>
        /// <returns>解码值：int[GenesLength]</returns>
        private static int[] DeCode(int[][] gene)
        {
            int[] result = new int[gene.Length];
            for (int j = 0; j < gene.Length; j++)
            {
                int[] bits = gene[j];
                result[j] = 0;
                for (int i = 1; i < gene.Length; i++)
                {
                    result[j] += Convert.ToInt32(bits[8 - i] * Math.Pow(2, i - 1));
                }
                result[j] = bits[0] == 0 ? result[j] : -result[j];  //  对数值的正负进行标记
            }
            return result;
        }

        /// <summary>
        /// 编码（十进制转二进制）
        /// </summary>
        /// <param name="value">十进制的值</param>
        /// <returns>编码值：int[bitsLength]</returns>
        private static int[] EnCoding(int value)
        {
            int[] encoding = new int[BitsLength];
            int bitsLength = BitsLength;
            int quotients = Math.Abs(value);
            do
            {
                encoding[bitsLength - 1] = quotients % 2;
                quotients /= 2;
                bitsLength -= 1;
                if (bitsLength < 1)
                {
                    MessageBox.Show("编码位数不够！");
                    break;
                }
            } while (quotients != 0);
            for(int i = 1; i < bitsLength; i++)
            {
                encoding[i] = 0;
            }
            // 最高位0为正，1为负
            encoding[0] = value >= 0 ? 0 : 1;
            return encoding;
        }

        /// <summary>
        /// 计算适应度
        /// </summary>
        private static void CalFitPercent()
        {
            double totalFitValue = 0;  // 获取适应值总和
            for (int i = 0; i < ChromosomeLength; i++)
            {
                double value = IsMeetConditions(Chromosomes[i]) ? 10 * Chromosomes[i].FitValue : Chromosomes[i].FitValue;
                totalFitValue += Math.Abs(value);
            }

            // 算出每个的被选择的概率;
            for (int i = 0; i < ChromosomeLength; i++)
            {
                double value = IsMeetConditions(Chromosomes[i]) ? 10 * Chromosomes[i].FitValue : Chromosomes[i].FitValue;
                Chromosomes[i].FitValuePercent = Math.Abs(value) / totalFitValue;
            }

            // 计算累计概率；第一个的累计概率就是自己的概率
            Chromosomes[0].Probability = Chromosomes[0].FitValuePercent;
            // 该语句不可省略，否则会导致错误
            double probability = Chromosomes[0].Probability;
            for (int i = 1; i < ChromosomeLength; i++)
            {
                if (Chromosomes[i].FitValuePercent != 0)
                {
                    Chromosomes[i].Probability = Chromosomes[i].FitValuePercent + probability;
                    probability = Chromosomes[i].Probability;
                }
            }
        }

        /// <summary>
        /// 选择算子（基于轮盘赌法）
        /// </summary>
        private static void UpdateNext()
        {
            ChromosomesChild.Clear();
            //优胜劣汰,种群更新
            for (int i = 0; i < ChromosomeLength; i++)
            {
                double rand = Random.NextDouble();
                for (int j = 0; j < ChromosomeLength - 1; j++)
                {
                    if (Chromosomes[j].Probability <= rand && rand <= Chromosomes[j + 1].Probability)
                    {
                        ChromosomesChild.Add(Chromosomes[j + 1].Clone());
                        break;
                    }
                }
            }

            for (int i = 0; i < ChromosomesChild.Count; i++)
            {
                Chromosomes[i] = ChromosomesChild[i];
            }
            //为下次种群更新做准备
            ChromosomesChild.Clear();
        }

        /// <summary>
        /// 交叉算子
        /// </summary>
        /// <param name="pc">交叉概率</param>
        private static void CrossOperate(double pc)
        {
            for(int i = 0; i < Chromosomes.Count; i++)
            {
                double rand = Random.NextDouble();
                if (rand <= pc)
                {
                    int rand1 = Random.Next(0, BitsLength);  // 随机选择要交换的位点
                    int rand3 = Random.Next(0, GenesLength);
                    int rand4 = Random.Next(0, GenesLength);
                    int randGenes = Random.Next(0, ChromosomeLength);
                    for (int j = rand1; j < BitsLength; j++)
                    {
                        int t = Chromosomes[i].Genes[rand3][j];
                        Chromosomes[i].Genes[rand3][j] = Chromosomes[randGenes].Genes[rand4][j];
                        Chromosomes[randGenes].Genes[rand4][j] = t;
                    }
                }
            }
        }

        /// <summary>
        /// 变异算子
        /// </summary>
        /// <param name="pm">变异概率</param>
        private static void VariationOperate(double pm)
        {
            for(int i = 0; i < Chromosomes.Count; i++)
            {
                double rand = Random.NextDouble();
                if (rand <= pm)
                {
                    int rand2 = Random.Next(0, GenesLength);  // 被选中的染色体片段
                    int col = Random.Next(1, BitsLength);  // 被选染色体中的变异基因位
                    Chromosomes[i].Genes[rand2][col] = Chromosomes[i].Genes[rand2][col] == 0 ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// 获取适应值
        /// </summary>
        /// <param name="chromosome">染色体中的某个片段</param>
        /// <returns></returns>
        private static double GetFitValue(Chromosome chromosome)
        {
            double value1 = 0;
            double value2 = 0;
            double value3 = 0;
            int[] decodeValue = DeCode(chromosome.Genes);
            for (int i = 0; i < GenesLength; i++)
            {
                value1 += variateInfo[i].A0 * Math.Pow(1 - decodeValue[i] / variateInfo[i].A0, 2) / (2 * (1 - variateInfo[i].A1)) * variateInfo[i].A2;
                value2 += variateInfo[i].A2;
                value3 += variateInfo[i].A3 * decodeValue[i];
            }
            double y = variateInfo[0].C0 * value1 / value2 + (1 - variateInfo[0].C0) * variateInfo[0].C1 / value3 * 152;
            return y;
        }

        /// <summary>
        /// 定义染色体类
        /// </summary>
        private class Chromosome
        {
            /* 
             * 这里面的参数涉及到引用类型和值类型的问题；
             * 改错之后将导致几次迭代后，子代的染色体将会变成一样
             * 
             */

            // 染色体片段[genesLength][bitsLength]
            public int[][] Genes = new int[GenesLength][];
            // 每个变量的上下限:[genesLength,2]
            public int[,] ValueLimit = new int[GenesLength, 2];
            // 适应值，根据目标函数计算得到
            public double FitValue;
            // 适应值对应的选择概率
            public double FitValuePercent;
            // 累计概率值
            public double Probability;

            public Chromosome Clone()
            {
                Chromosome c = new Chromosome();
                for(int i = 0; i < Genes.Length; i++)
                {
                    int[] temp_gene = new int[BitsLength];
                    for(int j = 0; j < Genes[0].Length; j++)
                    {
                        temp_gene[j] = Genes[i][j];
                    }
                    c.Genes[i] = temp_gene;
                    c.ValueLimit[i, 0] = ValueLimit[i, 0];
                    c.ValueLimit[i, 1] = ValueLimit[i, 1];
                }
                c.FitValue = FitValue;
                c.FitValuePercent = FitValuePercent;
                c.Probability = Probability;
                return c;
            }
        }

        /// <summary>
        /// 输出染色体信息
        /// </summary>
        /// <param name="filepath">保存路径</param>
        /// <param name="looptime">当前迭代次数</param>
        /// <param name="max">当前迭代的均值</param>
        private static void Print(String filepath, int looptime, double max, int recordType = 0)
        {
            StringBuilder sb = new StringBuilder();
            switch (recordType)
            {
                case 1:  // 完全记录数据
                    {
                        sb.AppendLine("第" + (looptime + 1) + "次迭代后最大值：" + max);
                        sb.AppendLine("循环次数\t基因序号\t变量值\t是否满足约束\t适应性");
                        for (int i = 0; i < ChromosomeLength; i++)
                        {
                            string temp_line = "";
                            temp_line += looptime + 1 + "\t" + i + "\t";
                            temp_line += string.Join(",", DeCode(Chromosomes[i].Genes)) + "\t";
                            temp_line += IsMeetConditions(Chromosomes[i]) + "\t";
                            temp_line += Chromosomes[i].FitValue;
                            sb.AppendLine(temp_line);
                        }
                        System.IO.File.AppendAllText(filepath, sb.ToString());
                        break;
                    }

                case 0:  // 简要记录数据
                    {
                        double fitValue = 0;
                        int count = 0;
                        for (int i = 0; i < ChromosomeLength; i++)
                            if (IsMeetConditions(Chromosomes[i]))
                            {
                                fitValue += Chromosomes[i].FitValue;
                                count += 1;
                            }
                        sb.AppendLine(looptime + 1 + "\t" + fitValue / count + "\t" + max);
                        System.IO.File.AppendAllText(filepath, sb.ToString());
                        break;
                    }
            }
        }
    }
}
