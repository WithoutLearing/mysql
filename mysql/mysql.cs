using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//调用MySQL动态库

namespace mysql
{
    /// <summary>
    /// 关于SQL操作的类
    /// </summary>
    public class mysql
    {
        /// <summary>
        /// 考核基础状态表字段
        /// </summary>
        public string AssessmentBasisStatusTable = "AssessmentBasisStatusTable (Uuid INT ,KHKM VARCHAR(50),DWXX VARCHAR(32),GHDTSL INT,KHSJ DOUBLE,JSHJ DOUBLE,PBDN INT,ZHBC INT,CLID INT,KHMD VARCHAR(256),KHMS VARCHAR(256))";
        /// <summary>
        /// 路由状态表
        /// </summary>
        public string RoutingStatusTable = "RoutingStatusTable (Uuid INT,KHKM VARCHAR(50),DTMac VARCHAR(50),PBDN INT,CARID INT,DTID VARCHAR(5),KHSJ DOUBLE,KHDD VARCHAR(32),DTSL INT,LINKNUM INT,KYLL INT,ZDJJS INT,NODEINFO VARCHAR(16))";
        /// <summary>
        /// 组网时间采集表
        /// </summary>
        public string NetworkingTimeAcquisitionTable = "NetworkingTimeAcquisitionTable (Uuid INT,KHKM VARCHAR(50),CKLC INT,PBDN INT,RWKSSJ DOUBLE,ZWCGSJ DOUBLE)";
        /// <summary>
        /// 组网迂回能力采集表
        /// </summary>
        public string NetworkingRoundaboutCapabilityAcquisitionTable = "NetworkingRoundaboutCapabilityAcquisitionTable (Uuid INT,KHKM VARCHAR(50),PBDN INT,CKLC INT,ZWCGSJ DOUBLE,ZWHFSJ DOUBLE)";
        /// <summary>
        /// 报文业务状态表
        /// </summary>
        public string MessageServiceStatusTable = "MessageServiceStatusTable (Uuid INT,KHKM VARCHAR(50),DTID VARCHAR(5),KHSJ DOUBLE,KHDD VARCHAR(32),BWID INT,FSSJ DOUBLE,JSHJ DOUBLE)";
        /// <summary>
        /// 语音业务状态表
        /// </summary>
        public string VoiceServiceStatusTable = "VoiceServiceStatusTable (Uuid INT,KHKM VARCHAR(50),DTID VARCHAR(5),KHSJ DOUBLE,KHDD VARCHAR(32),BWID INT,HYFSSJ DOUBLE,HYKDD INT,HYJLCGL INT)";


        /// <summary>
        /// 连接一个已经存在的数据库,并打开
        /// </summary>
        /// <param name="name">已存在的数据库名称</param>
        public void ConnectMysql(string name)
        {
            try
            {
                string connstr = string.Format("Server = localhost; UserId = root; Password = 19891018; Database = {0}", name);//数据库登录信息，其中localhost代表本地计算机
                MySqlConnection mySqlConnection = new MySqlConnection(connstr);
                mySqlConnection.Open();
            }
            catch 
            {

               

            }
            
        }

        /// <summary>
        /// 连接一个已经存在的数据库,并关闭
        /// </summary>
        /// <param name="name">已存在的数据库名称</param>
        public void DisconnectMysql(string name)
        {
            try
            {
                string connstr = string.Format("Server = localhost; UserId = root; Password = 19891018; Database = {0}", name);//数据库登录信息，其中localhost代表本地计算机
                MySqlConnection mySqlConnection = new MySqlConnection(connstr);
                mySqlConnection.Close();
            }
            catch
            {



            }
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="DBname">数据库名称</param>
        public void CreateDB(string name)
        {
            try
            {
                string DBname = string.Format("CREATE DATABASE {0}", name);
                MySqlConnection conn = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=19891018;");//数据库登录信息，其中localhost代表本地计算机
                MySqlCommand cmd = new MySqlCommand(DBname, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {


            }

        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="DBname">数据库名称</param>
        public void DropDB(string name)
        {
            try
            {
                string DBname = string.Format("drop database {0}", name);
                MySqlConnection conn = new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=19891018;");//数据库登录信息，其中localhost代表本地计算机
                MySqlCommand cmd = new MySqlCommand(DBname, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {


            }

        }

        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <param name="DBname">数据库名称</param>
        /// <param name="name">新建表名称</param>
        public void CreateTable(string DBname, string name)
        {
            try
            {
                string Tablename = string.Format("CREATE TABLE IF NOT EXISTS {0}", name);//不存在创建，已存在不创建
                string connstr = string.Format("Server = localhost; UserId = root; Password = 19891018; Database = {0}", DBname);//数据库登录信息，其中localhost代表本地计算机
                MySqlConnection conn = new MySqlConnection(connstr);
                MySqlCommand cmd = new MySqlCommand(Tablename, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {


            }
        }

        /// <summary>
        /// 删除数据表
        /// </summary>
        /// <param name="DBname">数据库名称</param>
        /// <param name="name">要删除的表名称</param>
        public void DropTable(string DBname, string name)
        {
            string Tablename = string.Format("DROP TABLE IF EXISTS {0}", name);
            string connstr = string.Format("Server = localhost; UserId = root; Password = 19891018; Database = {0}", DBname);//数据库登录信息，其中localhost代表本地计算机
            MySqlConnection conn = new MySqlConnection(connstr);
            MySqlCommand cmd = new MySqlCommand(Tablename, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }





    }
}
