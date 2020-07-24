using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace 高德地图截图工具
{
    public partial class frmImage : Form
    {
        public frmImage()
        {
            InitializeComponent();
        }

        //RowCount代表纬度,ColCount代表经度
        int picWidth;
        int picHeight;
        string[,] Url;
        readonly int RowCount = PublicVariate.URL.GetLength(0);
        readonly int ColCount = PublicVariate.URL.GetLength(1);
        private int PicRowLocation = 0;
        private int PicColLocation = 0;

        private void frmImage_Load(object sender, EventArgs e)
        {
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
            Url = PublicVariate.URL;
            pictureBox1.Location = new Point(0, 0);
            ShowImage(pictureBox1);
            UpdateLblInfo(tslPage);          
        }

        private void frmImage_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(0, toolStrip1.Height);
            panel1.Width = ClientRectangle.Width;
            panel1.Height = ClientRectangle.Height - toolStrip1.Height;
            pictureBox1.Location = new Point(0, toolStrip1.Height);
        }

        private void tsbMerge_Click(object sender, EventArgs e)
        {
            try
            {
                Image[,] images = new Image[RowCount, ColCount];

                toolStripProgressBar1.Maximum = RowCount * ColCount;
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColCount; j++)
                    {
                        images[i, j] = GetImageByUrl(Url[i, j]);
                        toolStripProgressBar1.Value = i * ColCount + j + 1;
                        tslProgress.Text = "当前进度:" + toolStripProgressBar1.Value + "/" + toolStripProgressBar1.Maximum;
                        Application.DoEvents();
                    }
                }

                var width = images[0, 0].Width * ColCount;
                var height = images[0, 0].Height * RowCount;

                // 初始化画布(最终的拼图画布)并设置宽高
                Bitmap bitMap = new Bitmap(width, height);
                // 初始化画板
                Graphics g1 = Graphics.FromImage(bitMap);
                // 将画布涂为白色(底部颜色可自行设置)
                g1.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));

                //画图
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColCount; j++)
                    {
                        g1.DrawImage(images[i, j], j * images[i, j].Width, i * images[i, j].Height, images[i, j].Height, images[i, j].Width);                     
                    }
                }

                Image img = bitMap;
                string time = DateTime.Now.ToString("yyyyMMddHHmmss");
                SavePic(img, time);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tsbMergeByRow_Click(object sender, EventArgs e)
        {
            try
            {
                Image[,] images = new Image[RowCount, ColCount];

                toolStripProgressBar1.Maximum = RowCount * ColCount;
                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColCount; j++)
                    {
                        images[i, j] = GetImageByUrl(Url[i, j]);
                        toolStripProgressBar1.Value = i * ColCount + j + 1;
                        tslProgress.Text = "当前进度:" + toolStripProgressBar1.Value + "/" + toolStripProgressBar1.Maximum;
                        Application.DoEvents();
                    }
                }

                var width = images[0, 0].Width * ColCount;
                var height = images[0, 0].Height;   /* RowCount;*/

                //画图
                for (int i = 0; i < RowCount; i++)
                {
                    // 初始化画布(最终的拼图画布)并设置宽高
                    Bitmap bitMap = new Bitmap(width, height);
                    // 初始化画板
                    Graphics g1 = Graphics.FromImage(bitMap);
                    // 将画布涂为白色(底部颜色可自行设置)
                    g1.FillRectangle(Brushes.White, new Rectangle(0, 0, width, height));

                    for (int j = 0; j < ColCount; j++)
                    {
                        g1.DrawImage(images[i, j], j * images[i, j].Width, 0, images[i, j].Height, images[i, j].Width);
                    }

                    Image img = bitMap;
                    string time = DateTime.Now.ToString("yyyyMMddHHmmss");
                    SavePic(img, time);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            string pictureName = string.Format("picture_{0}{1}", PicRowLocation + 1, PicColLocation + 1);
            SavePic(pictureBox1.Image, pictureName);
        }

        private void tsbPrevious_Click(object sender, EventArgs e)
        {
            if (PicColLocation == 0 && PicRowLocation == 0)
            {
                PicRowLocation = RowCount - 1;
                PicColLocation = ColCount - 1;
            }
            else if (PicColLocation == 0)
            {
                PicRowLocation -= 1;
                PicColLocation = ColCount - 1;
            }
            else
            {
                PicColLocation -= 1;
            }

            ShowImage(pictureBox1);
            UpdateLblInfo(tslPage);
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (PicColLocation == ColCount - 1 && PicRowLocation == RowCount - 1)
            {
                PicRowLocation = 0;
                PicColLocation = 0;
            }
            else if (PicColLocation == ColCount - 1)
            {
                PicRowLocation += 1;
                PicColLocation = 0;
            }
            else
            {
                PicColLocation += 1;
            }

            ShowImage(pictureBox1);
            UpdateLblInfo(tslPage);
        }

        private Image GetImageByUrl(string url)
        {
            Image image;
            try
            {
                WebRequest webreq = WebRequest.Create(url);
                WebResponse webres = webreq.GetResponse();
                using (Stream stream = webres.GetResponseStream())
                {
                    return image = Image.FromStream(stream);
                }
            }
            catch (ArgumentNullException ae)
            {
                MessageBox.Show(ae.ToString(), "错误提示!");
                return image = pictureBox1.Image;
            }
        }

        private void SavePic(Image image, string pictureName = "Picture")
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存图片!";
            saveFileDialog.Filter = "png格式|*.png|jpeg格式|*.jpeg|bmp格式|*.bmp";
            saveFileDialog.FileName = pictureName;
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image != null)
                {
                    string filePath = saveFileDialog.FileName;
                    using (MemoryStream mem = new MemoryStream())
                    {
                        if (saveFileDialog.FilterIndex == 1)
                        {
                            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                        }
                        else if (saveFileDialog.FilterIndex == 2)
                        {
                            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        else if (saveFileDialog.FilterIndex == 3)
                        {
                            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Bmp);
                        }
                    }
                }
            }
        }

        private void ShowImage(PictureBox pictureBox)
        {
            try
            {
                WebRequest webreq = WebRequest.Create(Url[PicRowLocation, PicColLocation]);
                WebResponse webres = webreq.GetResponse();
                using (Stream stream = webres.GetResponseStream())
                {
                    pictureBox.Image = Image.FromStream(stream);
                    pictureBox.Width = pictureBox.Image.Width;
                    pictureBox.Height = pictureBox.Image.Height;
                    picWidth = pictureBox.Image.Width;
                    picHeight = pictureBox.Image.Height;
                }
            }
            catch (ArgumentNullException ae)
            {
                MessageBox.Show(ae.ToString(), "错误提示!");
            }
        }

        private void UpdateLblInfo(ToolStripLabel label)
        {
            label.Text = (PicRowLocation * ColCount + PicColLocation + 1).ToString() + "/" + RowCount + "*" + ColCount;
        }

        //对picturebox的操作

        int xPos;
        int yPos;
        bool CanMove = false;

        #region
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            CanMove = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            CanMove = true;
            xPos = e.X;
            yPos = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (CanMove)
            {
                pictureBox1.Left += Convert.ToInt32(e.X - xPos);
                pictureBox1.Top += Convert.ToInt32(e.Y - yPos);
            }
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            int x;

            if (e.Delta < 0 && pictureBox1.Width <= picWidth * 0.2)
            {
                MessageBox.Show("已经缩放到最小！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (e.Delta > 0 && pictureBox1.Width >= picWidth * 3) 
            {
                MessageBox.Show("已经缩放到最大！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                pictureBox1.Width += Convert.ToInt32(picWidth * 0.1 * (x = e.Delta > 0 ? 1 : -1));
                pictureBox1.Height += Convert.ToInt32(picHeight * 0.1 * (x = e.Delta > 0 ? 1 : -1));
                Text = (Math.Round((double)pictureBox1.Width / picWidth, 2) * 100).ToString() + "%";
            }
        }
        #endregion
    }
}
