using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;//调用MySQL动态库

namespace mysql
{
    /// <summary>
    /// 考核基础状态表
    /// </summary>
    public struct AssessmentBasisStatusTableStruct
    {
        public int Uuid; //考核唯一标识
        public string KHKM;//考核科目
        public string DWXX;//考核地点
        public short GHDTSL;//规划电台数量
        public double KHSJ;//考核开始时间
        public double JSHJ;//考核结束时间
        public short PBDN;//平板电脑
        public short ZHBC;//作战编成
        public int CLID;//车辆ID
        public string KHMD;//预留
        public string KHMS;//预留
    }

    /// <summary>
    /// 路由状态表
    /// </summary>
    struct RoutingStatusTableStruct
    {
        public int Uuid; //考核唯一标识
        public string KHKM;//考核科目
        public string DTMac;//电台MAC
        public short PBDN;//平板电脑
        public int CARID;//车辆ID
        public string DTID;//采集电台标识
        public double KHSJ;//采集时间戳
        public string KHDD;//北斗定位
        public short DTSL;//入网电台数量
        public short LINKNUM;//规划链路数
        public short KYLL;//可用链路数
        public short ZDJJS;//最大节点数
        public string NODEINFO;//路由信息
    }

    public partial class Form1 : Form
    {
        mysql Mysql = new mysql();

        public static AssessmentBasisStatusTableStruct assessmentBasisStatusTable;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            TableBuilding();//先创建表
            FillTextbox();//初始化TEXTBOX
        }

        /// <summary>
        /// 在已有的数据库dbdb中建表
        /// </summary>
        private void TableBuilding()
        {
            string[] NewTable = { Mysql.AssessmentBasisStatusTable, Mysql.RoutingStatusTable,Mysql.NetworkingTimeAcquisitionTable,Mysql.NetworkingRoundaboutCapabilityAcquisitionTable,Mysql.MessageServiceStatusTable,Mysql.VoiceServiceStatusTable };

            for (int i = 0; i < NewTable.Length; i++)
            {
                Mysql.CreateTable("dbdb", NewTable[i]);
                
            }
        }

        /// <summary>
        /// 获取数据库中的考核基础状态表的数据填空控件
        /// </summary>
        private void FillTextbox()
        {
            string[] Filldata = new string[11];
            Filldata = Mysql.ReadDataAssessmentBasisStatusTable();

            textBox_Uuid.Text = Filldata[0];
            textBox_KHKM.Text = Filldata[1];
            textBox_DWXX.Text = Filldata[2];
            textBox_GHDTSL.Text = Filldata[3];
            textBox_KHSJ.Text = Filldata[4];
            textBox_JSHJ.Text = Filldata[5];
            textBox_PBDN.Text = Filldata[6];
            textBox_ZHBC.Text = Filldata[7];
            textBox_CLID.Text = Filldata[8];
            textBox_KHMD.Text = Filldata[9];
            textBox_KHMS.Text = Filldata[10];
        }


        /// <summary>
        /// 配置考核基础状态表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Configure_Click(object sender, EventArgs e)
        {
            try
            {
                assessmentBasisStatusTable.Uuid = int.Parse(textBox_Uuid.Text);
                assessmentBasisStatusTable.KHKM = textBox_KHKM.Text;
                assessmentBasisStatusTable.DWXX = textBox_DWXX.Text;
                assessmentBasisStatusTable.GHDTSL = short.Parse(textBox_GHDTSL.Text);
                assessmentBasisStatusTable.KHSJ =double.Parse(textBox_KHSJ.Text);
                assessmentBasisStatusTable.JSHJ = double.Parse(textBox_JSHJ.Text);
                assessmentBasisStatusTable.PBDN = short.Parse(textBox_PBDN.Text);
                assessmentBasisStatusTable.ZHBC = short.Parse(textBox_ZHBC.Text);
                assessmentBasisStatusTable.CLID = int.Parse(textBox_CLID.Text);
                assessmentBasisStatusTable.KHMD = textBox_KHMD.Text;
                assessmentBasisStatusTable.KHMS=textBox_KHMS.Text;

                Mysql.UpdateDataAssessmentBasisStatusTable();
            }
            catch
            {

               
            }
        }
    }
}
