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
    struct AssessmentBasisStatusTableStruct
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


    public partial class Form1 : Form
    {
        mysql Mysql = new mysql();

        public Form1()
        {
            InitializeComponent();
        }

   



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_CreateDB_Click(object sender, EventArgs e)
        {
            Mysql.CreateDB("dbdb");
        }

        private void button_DropDB_Click(object sender, EventArgs e)
        {
            Mysql.DropDB("dbdb");
        }

        private void button_CreateTable_Click(object sender, EventArgs e)
        {
            Mysql.CreateTable("dbdb", "Test (Field1 VarChar(50), Field2 Integer)");
        }

        private void button_DropTable_Click(object sender, EventArgs e)
        {
            Mysql.DropTable("dbdb", "Test");
        }

        private void button_OpenDB_Click(object sender, EventArgs e)
        {
            Mysql.ConnectMysql("db");
        }
    }
}
