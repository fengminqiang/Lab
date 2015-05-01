using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using MySql.Data.Common;

namespace LabVideoTest
{
    class DAO
    {
        private DatabaseConnection dbc;
        private MySqlConnection conn;
        public DAO(String server, String userId, String psd, String db) 
        {
            dbc = new DatabaseConnection(server, userId, psd, db);
            conn = dbc.getConnection();
        }

        public void Close()
        {
            //公有方法，关闭数据库连接。
            dbc.close();
        }

        public void Dispose() 
        {
            //公有方法，释放资源。
            // 确保连接被关闭
            dbc.Dispose();
        }

        public void daoInsert(String sqlStr) 
        {
            if (conn != null)
            {
                MySqlCommand command = new MySqlCommand(sqlStr, conn);
                try
                {
                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("成功!");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("已存在记录，重复插入！");
                }
            }
            else
            {
                MessageBox.Show("数据库未连接！");
            }
        }

     
        //从一张表中取得数据并转存为dataset类型
        public DataSet getDataSet(String sqlStr,String tableName)
        {
            DataSet ds = null;
            if (conn != null)
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlStr, conn);
                ds = new DataSet();
                dataAdapter.Fill(ds, tableName);
            }
            else 
            {
                MessageBox.Show("数据库未连接！");
            }
            return ds;
        }

        public void update(String sqlStr,DataSet ds,String tableName) 
        {
            if (conn != null)
            {
                try
                {
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlStr, conn);
                    MySqlCommandBuilder scb = new MySqlCommandBuilder(dataAdapter);
                    dataAdapter.InsertCommand = scb.GetInsertCommand();
                    dataAdapter.DeleteCommand = scb.GetDeleteCommand();
                    dataAdapter.UpdateCommand = scb.GetUpdateCommand();
                    dataAdapter.Update(ds, tableName);
                }
                catch (Exception e) 
                {
                    MessageBox.Show(e.ToString());
                }
            }
            else
            {
                MessageBox.Show("数据库未连接！");
            }
        }
    }
}
