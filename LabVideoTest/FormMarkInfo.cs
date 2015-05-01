using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabVideoTest
{
    public partial class FormMarkInfo : Form
    {
        public FormMarkInfo()
        {
            InitializeComponent();
            db2dvgMarkInfo("tbSceneD");
        }

        //把数据保存回数据库
        private void bt_confirm_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)dgv_markInfo.DataSource;
            dgv2db(ds, "tbSceneD");
        }
        //刷新列表
        private void bt_refresh_Click(object sender, EventArgs e)
        {
            db2dvgMarkInfo("tbSceneD");
        }
        //删除选中的行，并保存回数据库
        private void bt_deleteScene_Click(object sender, EventArgs e)
        {
            dgv_markInfo.Rows.Remove(dgv_markInfo.CurrentRow);
            DataSet ds = (DataSet)dgv_markInfo.DataSource;
            dgv2db(ds, "tbSceneD");
        }

        //从db中读取dataset到dgv中
        private void db2dvgMarkInfo(String tableName) 
        {
            //刷新dgv的表
            DataSet sceneInfoSet;
            DAO mydao = new DAO("localhost", "root", "root", "ipeople");//连接数据库
            String sqlStr = "SELECT SID as '监控场景序号', AID as '监控区域序号', ZBXL as '坐标序列', ONAME as '区域类型'  FROM tbSceneD ";
            //String sqlStr = "SELECT * FROM tbScene ";
            sceneInfoSet = mydao.getDataSet(sqlStr, "tbSceneD");
            mydao.Close();
            dgv_markInfo.DataSource = sceneInfoSet;
            dgv_markInfo.DataMember = tableName;
        }

        //把dgv中的表写回数据库
        private void dgv2db(DataSet ds, String tableName)
        {
            DAO mydao = new DAO("localhost", "root", "root", "ipeople");//连接数据库
            //String sqlStr = "SELECT * FROM tbScene ";
            String sqlStr = "SELECT SID as '监控场景序号', AID as '监控区域序号', ZBXL as '坐标序列', ONAME as '区域类型'  FROM tbSceneD ";
            mydao.update(sqlStr, ds, tableName);
            mydao.Close();
        }

        
    }
}
