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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建连接mysql
        /// </summary>
        public void ConnectMysql()
        {
            string connstr = "Server = localhost; UserId = root; Password = 19891018; Database = dbdb";//数据库登录信息，其中localhost代表本地计算机
            MySqlConnection mySqlConnection = new MySqlConnection(connstr);
            mySqlConnection.Open();
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="DBname">数据库名称</param>
        public void CreateDB(string name)
        {
            string DBname=string.Format("CREATE DATABASE {0}", name);
            MySqlConnection conn = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=19891018;");//数据库登录信息，其中localhost代表本地计算机
            MySqlCommand cmd = new MySqlCommand(DBname, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="DBname">数据库名称</param>
        public void DropDB(string name)
        {
            string DBname = string.Format("drop database {0}", name);
            MySqlConnection conn = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=19891018;");//数据库登录信息，其中localhost代表本地计算机
            MySqlCommand cmd = new MySqlCommand(DBname, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_CreateDB_Click(object sender, EventArgs e)
        {
            CreateDB("test");
        }

        private void button_DropDB_Click(object sender, EventArgs e)
        {
            DropDB("dbdb");
        }
    }
}
