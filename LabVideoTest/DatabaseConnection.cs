using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace LabVideoTest
{
    class DatabaseConnection
    {
        private String strCon;
        MySqlConnection myCon;
        public DatabaseConnection(String server, String userId, String psd, String db)
        {
            strCon = "server="+server+";User Id="+userId+";password="+psd+";Database="+db;
            myCon = null;
        }
        public MySqlConnection getConnection()
        {
            try
            {
                myCon = new MySqlConnection(strCon);
                myCon.Open();
                return myCon;
            }
            catch (Exception e) 
            {
                throw e;
            }
        }

        public void close() 
        {
            try
            {
                if (strCon != null)
                {
                    myCon.Close();
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Dispose()
        {
            //公有方法，释放资源。
            // 确保连接被关闭
            if (myCon != null)
            {
                myCon.Dispose();
                myCon = null;
            }
        }

    }
}
