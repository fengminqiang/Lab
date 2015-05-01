using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Text.RegularExpressions;

namespace LabVideoTest
{
    public partial class FormSceneInfo : Form
    {
        // 委托
        public delegate void SetTextBoxDelegate(string sid, string sj, string dd, string ms, string jg);
        public SetTextBoxDelegate SetTextBoxDel = null;

        public delegate Tuple<float, float> GetScaleDelegate();
        public GetScaleDelegate getParameterDel = null;

        public delegate void LoadSceneDDelegate(List<Zone> zlist);
        public LoadSceneDDelegate sceneDDel = null;

        public FormSceneInfo()
        {
            InitializeComponent();
            db2dgv("tbScene");//更新dgv中的表

        }
        //把数据保存回数据库
        private void bt_confirm_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)dgv_sceneInfo.DataSource;
            dgv2db(ds, "tbScene");
        }

        //删除选中的行，并保存回数据库
        private void bt_deleteScene_Click(object sender, EventArgs e)
        {
            dgv_sceneInfo.Rows.Remove(dgv_sceneInfo.CurrentRow);
            DataSet ds = (DataSet)dgv_sceneInfo.DataSource;
            dgv2db(ds, "tbScene");
        }

        //刷新列表
        private void bt_refresh_Click(object sender, EventArgs e)
        {
            db2dgv("tbScene");
        }
        //载入场景
        private void bt_loadScene_Click(object sender, EventArgs e)
        {
            Tuple<float, float> Parameter = null;
            string SID = dgv_sceneInfo.Rows[dgv_sceneInfo.CurrentRow.Index].Cells[0].Value.ToString();
            string SJ = dgv_sceneInfo.Rows[dgv_sceneInfo.CurrentRow.Index].Cells[1].Value.ToString();
            string DD = dgv_sceneInfo.Rows[dgv_sceneInfo.CurrentRow.Index].Cells[2].Value.ToString();
            string MS = dgv_sceneInfo.Rows[dgv_sceneInfo.CurrentRow.Index].Cells[3].Value.ToString();
            string JG = dgv_sceneInfo.Rows[dgv_sceneInfo.CurrentRow.Index].Cells[4].Value.ToString();

            if (SetTextBoxDel != null)
            {
                SetTextBoxDel(SID, SJ, DD, MS, JG);
            }
            if (getParameterDel != null)
            {
                Parameter = getParameterDel();
            }

            DataSet ds1 = getSceneDSet(SID);//获取SceneD表中的dataset
            List<Zone> zlist = new List<Zone>();
            for (int k = 0; k < ds1.Tables["tbSceneD"].Rows.Count; k++)
            {
                List<PointF> plist = new List<PointF>();
                string strZBXL = ds1.Tables["tbSceneD"].Rows[k][1].ToString();
                string ONAME = ds1.Tables["tbSceneD"].Rows[k][2].ToString();
                Regex reg = new Regex(@"\((?<X>[\d]*),(?<Y>[\d]*)\)");
                MatchCollection mc;
                mc = reg.Matches(strZBXL);
                foreach (Match element in mc)
                {
                    //MessageBox.Show(element.Groups["X"].Value.ToString());
                    PointF point = new PointF(Int32.Parse(element.Groups["X"].Value), Int32.Parse(element.Groups["Y"].Value));
                    plist.Add(point);
                }
                Zone zone = new Zone(plist, Parameter.Item1, Parameter.Item2, ONAME);
                zlist.Add(zone);

             }

            if (sceneDDel != null)
            {
                sceneDDel(zlist);
            }
        }

        private DataSet getSceneDSet(string sid) 
        {
            DataSet sceneDSet;
            DAO mydao = new DAO("localhost", "root", "root", "ipeople");//连接数据库
            String sqlStr = "SELECT  AID as '监控区域序号', ZBXL as '坐标序列', ONAME as '区域类型'  FROM tbSceneD WHERE SID="+sid;
            sceneDSet = mydao.getDataSet(sqlStr, "tbSceneD");
            mydao.Close();
            return sceneDSet;
        }
        //从db中读取dataset到dgv中
        private void db2dgv(string tableName) 
        {
            //刷新dgv的表
            DataSet sceneInfoSet;
            DAO mydao = new DAO("localhost", "root", "root", "ipeople");//连接数据库
            String sqlStr = "SELECT SID as '监控场景序号', SJ as '时间', DD as '地点', MS as '场景描述', JG as '人流量统计时间间隔'  FROM tbScene ";
            //String sqlStr = "SELECT * FROM tbScene ";
            sceneInfoSet = mydao.getDataSet(sqlStr, "tbScene");
            mydao.Close();
            dgv_sceneInfo.DataSource = sceneInfoSet;
            dgv_sceneInfo.DataMember = tableName;
        }

        //把dgv中的表写回数据库
        private void dgv2db(DataSet ds,String tableName) 
        {
            DAO mydao = new DAO("localhost", "root", "root", "ipeople");//连接数据库
            //String sqlStr = "SELECT * FROM tbScene ";
            String sqlStr = "SELECT SID as '监控场景序号', SJ as '时间', DD as '地点', MS as '场景描述', JG as '人流量统计时间间隔'  FROM tbScene ";
            mydao.update(sqlStr, ds, tableName);
            mydao.Close();
        }

       

       
    }
}
