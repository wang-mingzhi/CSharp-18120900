using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace 高德地图截图工具
{
    public partial class frmScreenshot : Form
    {
        public frmScreenshot()
        {
            InitializeComponent();
        }

        /*
         * url信息中
         * location  表示中心点的经纬度坐标;
         * zoom      表示缩放的级别,范围为[1-16]
         * scale=1   表示显示普通图,=2表示显示高清图
         * traffic=0 表示不显示路况,=1为显示路况
         * key       表示高德地图的秘钥(可以通过账号在官网上申请)
         * 
         */

        //缩放级别为15、纬度为0°时，一纬度的像素数
        int zoomLevel = 16;
        int lat2pixel = 186500;

        Operation Operation = new Operation();

        private void frmScreenshot_Load(object sender, EventArgs e)
        {
            TscbHistory.SelectedIndex = 0;
            tscb_Map.SelectedIndex = 0;
            cmb_layerOfMarkers.SelectedIndex = 0;
            cmb_layersOfBaseMap.SelectedIndex = 0;
            cmb_ProjectionMathed.SelectedIndex = 0;
            tsslLoginTime.Text = DateTime.Now.ToLocalTime().ToString();
            Setting();
        }

        private void TsbResult_Click(object sender, EventArgs e)
        {
            zoomLevel = Convert.ToInt32(txt_ZoomLevel.Text);
            lat2pixel = Convert.ToInt32(txt_lat2Pixel.Text);

            if (Operation.PointLngLatChecked(txtMainPoint) && Operation.CheckInternetConnection()) 
            {
                double[,] Point;
                if (TscbHistory.SelectedIndex == 0)
                {
                    Point = new double[2, 2];
                    Point[0, 0] = Convert.ToDouble(txtMainPoint.Text.Split(new char[] { ',' })[0]);
                    Point[0, 1] = Convert.ToDouble(txtMainPoint.Text.Split(new char[] { ',' })[1]);
                    Point[1, 0] = Convert.ToDouble(txtReferPoint.Text.Split(new char[] { ',' })[0]);
                    Point[1, 1] = Convert.ToDouble(txtReferPoint.Text.Split(new char[] { ',' })[1]);
                }
                else
                {
                    Point = new double[1, 1];
                    Point[0, 0] = Convert.ToDouble(txtMainPoint.Text.Split(new char[] { ',' })[0]);
                    Point[0, 1] = Convert.ToDouble(txtMainPoint.Text.Split(new char[] { ',' })[1]);
                }

                int coefficient = (cmbDefinition.SelectedIndex == 1) ? 2 : 1;
                int[] tempSize = new int[]
                {
                        Convert.ToInt16(txtSizeOfWidth.Text) * coefficient ,
                        Convert.ToInt16(txtSizeOfHeight.Text) * coefficient
                };
                int[] picNumber = new int[]
                {
                        Convert.ToInt16(txtNumberOfRow.Text),
                        Convert.ToInt16(txtNumberOfCol.Text),
                };

                GenerateURL(picNumber, tempSize, Point);
                SaveSetting();
                OpenFrmImage();
            }
        }

        private void txtSizeOfWight_Leave(object sender, EventArgs e)
        {
            Operation.PicSizeChecked(txtSizeOfWidth);
        }

        private void txtSizeOfHeight_Leave(object sender, EventArgs e)
        {
            Operation.PicSizeChecked(txtSizeOfHeight);
        }

        private void txtNumberOfCol_Leave(object sender, EventArgs e)
        {
            Operation.PicNumChecked(txtNumberOfCol);
        }

        private void txtNumberOfRow_Leave(object sender, EventArgs e)
        {
            Operation.PicNumChecked(txtNumberOfRow);
        }

        private void txtReferPoint_Leave(object sender, EventArgs e)
        {
            Operation.PointLngLatChecked(txtReferPoint);
        }

        private void txtMainPoint_Leave(object sender, EventArgs e)
        {
            Operation.PointLngLatChecked(txtMainPoint);
        }

        frmOption frmOption = null;
        private void TsbOption_Click(object sender, EventArgs e)
        {
            Operation.ShowForm<frmOption>(frmOption, MdiParent);
        }

        //图片生成
        #region
        private void GenerateURL(int[] picNumber, int[] picSize, double[,] Point)
        {
            string[,] lngLat = GetLngLatInfo(cmbZoom.SelectedIndex + 1, picSize, picNumber, Point);
            txtNumberOfRow.Text = lngLat.GetLength(0).ToString();
            txtNumberOfCol.Text = lngLat.GetLength(1).ToString();
            PublicVariate.URL = new string[lngLat.GetLength(0), lngLat.GetLength(1)];

            string url = Txt_Url.Text;
            string zoom = "&zoom=" + (cmbZoom.SelectedIndex + 1);
            string scale = "&scale=" + (cmbDefinition.SelectedIndex + 1);
            string traffic = "&traffic=" + cmbRoadCondition.SelectedIndex;
            string key = "&key=" + txtAPI.Text;

            if (tscb_Map.SelectedIndex == 0)
            {
                string size = "&size=" + picSize[0] + "*" + picSize[1];
                for (int i = 0; i < PublicVariate.URL.GetLength(0); i++)
                {
                    for (int j = 0; j < PublicVariate.URL.GetLength(1); j++)
                    {
                        string location = "location=" + lngLat[i, j];
                        PublicVariate.URL[i, j] = url + location + zoom + size + scale + traffic + key;
                    }
                }
            }
            else if (tscb_Map.SelectedIndex == 1) 
            {
                string size = "&width=" + picSize[0] + "&height=" + picSize[1];
                string layers = "&layers=" + cmb_layersOfBaseMap.Text.Split('：')[1] + "," + cmb_layerOfMarkers.Text.Split('：')[1];
                for (int i = 0; i < PublicVariate.URL.GetLength(0); i++)
                {
                    for (int j = 0; j < PublicVariate.URL.GetLength(1); j++)
                    {
                        string center = "center=" + lngLat[i, j];
                        PublicVariate.URL[i, j] = url + center + size + zoom + layers + key;
                    }
                }
            }
        }

        private string[,] GetLngLatInfo(int zoom, int[] picSize, int[] picNumber, double[,] Point)
        {
            //在zoom=16时经度完全可以满足要求. lngCoe=186500;latCoe=243500;
            string[,] LngLat;
            List<double> Lng;
            List<double> Lat;
            double piexValue = 0;
            double accuracy = 0.000001;
            int loopCount = 0;
            //缩放级别为zoom时相对于zoomLevel的倍数，缩放级别每小1，对应的像素值除以2
            int scale = (int)Math.Pow(2, zoomLevel - zoom);

            if (Point.GetLength(0) == 1)
            {
                Lng = new List<double>();
                Lat = new List<double>();
                do
                {
                    piexValue += accuracy * (getLatCoe(Point[0, 1]) / scale);

                    if (piexValue > picSize[1] * (loopCount + 0.5))  
                    {
                        Lat.Add(Math.Round(Point[0, 1], 6));
                        loopCount += 1;
                    }

                    Point[0, 1] -= accuracy;
                } while (loopCount < picNumber[0]);

                for (int j = 0; j < picNumber[1]; j++)
                {
                    Lng.Add(Math.Round(Point[0, 0] + picSize[0] * scale * (0.5 + j) / lat2pixel, 6));
                }                
            }
            else
            {
                Lng = new List<double>();
                Lat = new List<double>();
                for(double k = Point[0, 1]; k >= Point[1, 1]; k -= accuracy)
                {
                    piexValue += accuracy * (getLatCoe(k) / scale);
                    if (piexValue > picSize[1] * (loopCount + 0.5))
                    {
                        Lat.Add(Math.Round(k, 6));
                        loopCount += 1;
                    }
                }

                int colNumber = (int)((Point[1, 0] - Point[0, 0]) * lat2pixel / scale / picSize[0]);
                if (Lat.Count == 0)
                {
                    Lat.Add(Point[0, 1]);
                }

                for (int j = 0; j < colNumber; j++)
                {
                    Lng.Add(Math.Round(Point[0, 0] + picSize[0] * scale * (0.5 + j) / lat2pixel, 6));
                }
            }

            LngLat = new string[Lat.Count, Lng.Count];            
            for(int i = 0; i < Lat.Count; i++)
            {
                for(int j = 0; j < Lng.Count; j++)
                {
                    LngLat[i, j] = Lng[j] + "," + Lat[i];
                }
            }
            return LngLat;

            double getLatCoe(double lat)
            {
                double latCoe = lat2pixel / Math.Cos(Math.Abs(lat) / 180 * Math.PI);
                return latCoe;
            }
        }

        frmImage frmImage = null;
        private void OpenFrmImage()
        {
            Operation.ShowForm<frmImage>(frmImage, MdiParent);
        }

        #endregion

        private void Setting()
        {
            txtMainPoint.Text = Properties.Settings.Default.mainPoint;
            txtReferPoint.Text = Properties.Settings.Default.referPoint;
            txtSizeOfHeight.Text = Properties.Settings.Default.sizeOfHeight;
            txtSizeOfWidth.Text = Properties.Settings.Default.sizeOfWide;
            txtNumberOfRow.Text = Properties.Settings.Default.numberOfRow;
            txtNumberOfCol.Text = Properties.Settings.Default.numberOfCol;
            cmbDefinition.SelectedIndex = Properties.Settings.Default.definition;
            cmbZoom.SelectedIndex = Properties.Settings.Default.zoom;
            cmbRoadCondition.SelectedIndex = Properties.Settings.Default.roadCondition;
            txtAPI.Text = Properties.Settings.Default.API;
        }

        private void SaveSetting()
        {
            Properties.Settings.Default.mainPoint = txtMainPoint.Text;
            Properties.Settings.Default.referPoint = txtReferPoint.Text;
            Properties.Settings.Default.sizeOfHeight = txtSizeOfHeight.Text;
            Properties.Settings.Default.sizeOfWide = txtSizeOfWidth.Text;
            Properties.Settings.Default.numberOfRow = txtNumberOfRow.Text;
            Properties.Settings.Default.numberOfCol = txtNumberOfCol.Text;
            Properties.Settings.Default.definition = cmbDefinition.SelectedIndex;
            Properties.Settings.Default.zoom = cmbZoom.SelectedIndex;
            Properties.Settings.Default.roadCondition = cmbRoadCondition.SelectedIndex;
            Properties.Settings.Default.API = txtAPI.Text;
            Properties.Settings.Default.Save();
        }

        private void TscbHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TscbHistory.SelectedIndex == 0)
            {
                txtMainPoint.Enabled = true;
                txtReferPoint.Enabled = true;
                txtSizeOfHeight.Enabled = false;
                txtSizeOfWidth.Enabled = false;
                txtNumberOfRow.Enabled = false;
                txtNumberOfCol.Enabled = false;
            }
            else if (TscbHistory.SelectedIndex == 1)
            {
                txtReferPoint.Enabled = false;
                txtSizeOfHeight.Enabled = true;
                txtSizeOfWidth.Enabled = true;
                txtNumberOfRow.Enabled = true;
                txtNumberOfCol.Enabled = true;
            }
        }

        private void cmbDefinition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
}
