using System.Collections.Generic;

/*
 * 添加时间：2020年1月5日18点52分
 * 
 * 模块功能：用来记录DataGridView的表结构
 * 
 */

namespace HighwayODAnalysis
{
    class DataViewStruct
    {
        public static List<DataviewStruct> dataviewStructs;

        //this.dataGridView1.Columns["列名"].DisplayIndex=Convert.ToInt32("你要放置的位置")

        public struct DataviewStruct
        {
            string ColName;
            string ColHeaderText;
            string ColDataType;
            int ColIndex;
            int ColDisplayIndex;
            int ColWidth;
            int ColDecimal;
        }
    }
}
