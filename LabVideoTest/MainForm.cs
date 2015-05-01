using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Microsoft.VisualBasic.PowerPacks;
using System.IO;
using System.Runtime.InteropServices;

namespace LabVideoTest
{

    public partial class MainForm : Form
    {
        Timer myTimer;
        int timeCounter;
        int clickCount;
        static int TIME_INTERVAL = 20;//每隔20帧比较一次
        Image<Bgr, Byte> frame, frame1, frame2;
        private PointF checkedPoint;
        private int indexZone, indexPoint;
       // private Point leftTop, rightButtom;
        List<PointF> plist;//记录视频上所记录的点数
        List<Zone> zlist;//框定区域的队列
       // private float xMin, xMax, yMin, yMax;
        private bool Designate = false;//可以框定区域
        private bool isFinishRec = false;//是否完成区域绘制
        private bool pointChosed = false;
        private bool backgroundChange = true;
        private bool NotExistBkg = true;
        private bool isPlaying = true;
        private bool addZone = false;
        private bool isItemChecked = false;//是否选中listbox中的item
        private bool isReadyForWriDB = false;
        public Capture capture;
        public MovieInfo movieInfo;
        RectangleShape rectangle = new RectangleShape();//矩形
        int pictureBoxHeight, pictureBoxWidth;//视频播放窗口的高度和宽度
        float scaleHeight, scaleWidth;
        //int abscissa;//横坐标
        Graphics g;
       // Graphics gBianary;
        int thresholdValue1;//帧差的阈值
        int thresholdValue2;//二值化阈值
        int[] flagArr;
        int indexDel;//删除的区域标号
        int SID;//监控场景序号
        int zoneCount;
        string ZBXL;
        string ONAME;

        public MainForm()
        {
            InitializeComponent();
            indexZone = 0;
            indexPoint = 0;
            plist = new List<PointF>();
            zlist = new List<Zone>();
            pictureBoxHeight = pictureBox.Height;
            pictureBoxWidth = pictureBox.Width;
            g = pbShowFrameDiff.CreateGraphics();//灰底变化统计
           // gBianary = pictureBoxBinaryDiff.CreateGraphics();//二值化图帧相减像素变化统计
            thresholdValue1 = 30;//灰度差
            thresholdValue2 = 75;//二值化阈值
            timeCounter = 0;
            clickCount = 0;
            btSelect.Enabled = false;
            //num = 0;
            flagArr = new int[100];
            progressBar.Step = 1;
            progressBar.Maximum = 100;
            indexDel = -1;
            //xMax = yMax = 0;
            zoneCount = 0;
            SID = -1;
        }

        private void miOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.CheckFileExists = true;
            dialog.Filter = "视频文件|*.mp4|所有文件|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                initial();
                String file = dialog.FileName;
                capture = new Emgu.CV.Capture(file);
                movieInfo = new MovieInfo(file, capture);
                trackBar.SetRange(0, movieInfo.frameCount);
                //this.Designate = false;

                frame1 = capture.QueryFrame().Clone();//初始化帧差法帧的第一帧
                
                if (myTimer != null)
                {
                    myTimer.Stop();
                    myTimer.Dispose();
                }
                myTimer = new Timer();
                myTimer.Interval = 1000/ Convert.ToInt32(movieInfo.fps);
                myTimer.Tick += new EventHandler(ProcessFrame);
          
                labelHeight.Text = movieInfo.height.ToString();
                labelWidth.Text = movieInfo.width.ToString();
                scaleHeight = movieInfo.height / pictureBoxHeight;
                scaleWidth = movieInfo.width / pictureBoxWidth;
            }

        }


        //方法：初始化数据
        private void initial()
        {
            zlist.Clear();
            g.Clear(Color.White);
            plist.Clear();
            lbxGrayChange.Items.Clear();
            lbShowCurrFrame.Text = "0";
            pictureBox.Image = null;
            isPlaying = true;
            btPlay.Text = "播放";

        }
        
        //区域内人停留时间统计
        private void timerZone_Tick(object sender, EventArgs e)
        {
            if (zlist != null)
            {
                foreach (Zone element in zlist)
                {
                    if (element.isExistPerson)
                    {
                        //如果灰度值跳变超过阈值
                        element.addTime();
                        element.isExistPerson = false;
                    }
                }
            }
        }
        //方法：统计各个区域的时间
        private void countZone(List<Zone> zlist)
        {
            lbxGrayChange.Items.Clear();
            foreach (Zone element in zlist)
            {
                int time = element.getTime();
                string item = element.getONAME() + "---" + "停留时间：" + time + "秒";
                lbxGrayChange.Items.Add(item);
            }
        }

        //方法：统计各个区域的超过阈值的点个数
       // int itemCount = 0;
        //private void showGrayChange(int[] flagGrayChange)
        //{ 
        //    lbxGrayChange.Items.Clear();
        //    for (int i = 0; i<flagGrayChange.Length; i++)
        //    {
        //        string item = "区域" + (i+1) + "---" + "变化灰度点个数：" + flagGrayChange[i];
        //        lbxGrayChange.Items.Add(item);
        //    }
            
        //}

       

        private void ProcessFrame(object sender, EventArgs arg)
        {
            int p = movieInfo.currentFrame;
            if (p < 0)
            {
                p = 0;
            }
            if (p >= movieInfo.frameCount-1)
            {
                //renderFrame(0);
                movieInfo.currentFrame = 0;
                CvInvoke.cvSetCaptureProperty(capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_POS_FRAMES, 0);
               // return;
            }
            renderFrame(p);//播放视频
            g.DrawLine(new Pen(Color.GreenYellow), new Point(0, 50), new Point(640, 50));

            trackBar.Value = movieInfo.currentFrame;
            lbShowCurrFrame.Text = movieInfo.currentFrame.ToString();
            if (isItemChecked)
            {
                btDelete.ForeColor = Color.Red;
            }
            else 
            {
                btDelete.ForeColor = Color.Black;
            }
        }

        //渲染帧
        private void renderFrame(int p)
        {
            frame = capture.QueryFrame();
            timeCounter++;
            if (zlist!=null) 
            {
                int gap = 0;
                foreach (Zone element in zlist)
                {
                    for (int i = 0; i < element.plist.Count - 1; i++)
                    {
                        PointF point1, point2;//视频点缩放，测试数据临时变量
                        point1 = new PointF(scaleHeight * element.plist[i].X, scaleWidth * element.plist[i].Y);
                        point2 = new PointF(scaleHeight * element.plist[(i + 1) % element.getZonePointCount()].X, scaleWidth * element.plist[(i + 1) % element.getZonePointCount()].Y);


                        frame.Draw(new LineSegment2DF(point1, point2), new Bgr(0, 0, 255), 3);//画出4边形

                        if (i == element.plist.Count - 2)
                        {

                            PointF pointFirst = new PointF(scaleHeight * element.plist[0].X, scaleWidth * element.plist[0].Y);
                            PointF pointEnd = new PointF(scaleHeight * element.plist[element.getZonePointCount() - 1].X, scaleWidth * element.plist[element.getZonePointCount() - 1].Y);
                            frame.Draw(new LineSegment2DF(pointFirst, pointEnd), new Bgr(0, 0, 255), 3);
                        }
                    }
                    if (element.isEditable(pointChosed)) 
                    {
                        //双击鼠标选中
                       // element.editZone(checkedPoint);
                        frame.Draw(new CircleF(new PointF(checkedPoint.X * scaleHeight, checkedPoint.Y * scaleWidth), 15), new Bgr(0, 255, 0), -1);
                    }
                    
                    addZoneLabel(element, gap);
                    gap++;
                }
                
            }
            //创建一个区域对象,并实时画出这个区域
            Zone zone = new Zone(plist, scaleHeight, scaleWidth, ONAME);
            //zone.drawingZone(zone.plist);
            for (int i = 0; i < plist.Count - 1; i++)
            {
                PointF point1, point2;//视频点缩放，测试数据临时变量
                point1 = new PointF(scaleHeight * plist[i].X, scaleWidth * plist[i].Y);
                point2 = new PointF(scaleHeight * plist[i + 1].X, scaleWidth * plist[i + 1].Y);


                frame.Draw(new LineSegment2DF(point1, point2), new Bgr(0, 0, 255), 3);//画出4边形

                //if (i == this.zoneCount - 2)
                //{

                //    PointF pointFirst = new PointF(scaleHeight * plist[0].X, scaleWidth * plist[0].Y);
                //    PointF pointEnd = new PointF(scaleHeight * plist[this.zoneCount - 1].X, scaleWidth * plist[this.zoneCount - 1].Y);
                //    frame.Draw(new LineSegment2DF(pointFirst, pointEnd), new Bgr(0, 0, 255), 3);
                //}
            }
            if (addZone) //创建新的zone区域
            {
                if (zone != null)
                {
                    zone.setONAME(ONAME);
                    zlist.Add(zone);
                    //把坐标保存到一个string里面
                    foreach (PointF element in plist) 
                    {
                        //保存坐标序列
                        ZBXL = ZBXL + "(" + element.X + "," + element.Y + ")/";
                    }
                    plist.Clear();
                    addZone = false;
                    isReadyForWriDB = true;
                }
                
            }
 
            if (timeCounter % TIME_INTERVAL == 0 && !this.Designate && isFinishRec)
            {

                if (backgroundChange)
                {
                    frame2 = frame;
                    drawResult(zlist, this.thresholdValue1, this.thresholdValue2);
                    frame1 = frame2.Clone();//拷贝出到一块新的内存中
                    timeCounter = 0;
                }
                else 
                {
                    if (NotExistBkg) //把框定后的第一帧作为背景帧
                    {
                        frame2 = frame.Clone();
                        NotExistBkg = false;
                    }

                    frame1 = frame;
                    drawResult(zlist, this.thresholdValue1, this.thresholdValue2);
                    timeCounter = 0;
                }

               // g.Clear(Color.White);

            }
            movieInfo.currentFrame++;
            try
            {
                pictureBox.Image = frame.Bitmap;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        // 方法：结果以直方图的形式显示出来
        private void drawResult(List<Zone> zlist, int thresholdValue1, int thresholdValue2) 
        {

            Image<Gray, byte> grayImage1 = frame1.Convert<Gray, byte>();
            Image<Gray, byte> grayImage2 = frame2.Convert<Gray, byte>(); 
            //方法：帧差法比较两帧的信息
            ImageCompareArray(grayImage1,grayImage2 ,zlist,thresholdValue1,thresholdValue2);

            
        }
        //方法：bgr帧转灰度帧
        //private Image<Gray, Byte> getImageGray(Image<Bgr, Byte> frame) 
        //{
        //    Image<Bgr, byte> ImageBgr = new Image<Bgr, byte>(movieInfo.width, movieInfo.height);
        //    CvInvoke.cvCopy(frame, ImageBgr, IntPtr.Zero);
              
        //    Image<Gray, byte> frameGray = ImageBgr.Convert<Gray, byte>();
        //    return frameGray;

        //}

       

        //方法：帧差法比较两帧的信息的区别
        private void ImageCompareArray(Image<Gray, byte> grayImage1, Image<Gray, byte> grayImage2, List<Zone> zlist,int thresholdValue1, int thresholdValue2) 
        {
            g.Clear(Color.White);
            int[] flagGrayChange;//得到各个区域的灰度值变化数组
            Byte[, ,] grayData1 = grayImage1.Data;
            Byte[, ,] grayData2 = grayImage2.Data;
            int abscissa = 10;
            scanningArea(zlist, grayData1, grayData2, out flagGrayChange);
            countZone(zlist);//计算停留时间
            
            for (int i = 0; i < zlist.Count; i++) 
            {
                  g.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(abscissa, 100 - flagGrayChange[i], 15, flagGrayChange[i]));
                  abscissa += 50;
                
            }

        }

        //方法:为区域添加标签
        private void addZoneLabel(Zone zone,int p)
        {
            Label label = new Label();
            label.Text = zone.getONAME();
            label.SetBounds(50 * p, 10, 45, 15);
            label.Font = new System.Drawing.Font("宋体", 9);
            panelZoneName.Controls.Add(label);
            
        }
        //方法scanningArea（区域列队，位图1，位图2，（数组）各个区域内超过阈值点数）：扫描各个区域内的灰度值跳变的点
        private void scanningArea(List<Zone> zlist, Byte[, ,] grayData1, Byte[, ,] grayData2, out int[] flagGrayChange)
        {
            flagGrayChange = new int[zlist.Count];
            for (int i = 0; i < zlist.Count;i++ )
            {
                float xMin = zlist[i].getXmin();
                float xMax = zlist[i].getXmax();
                float yMin = zlist[i].getYmin();
                float yMax = zlist[i].getYmax();
                bool exitLoop = false;
                for (int x = (int)xMin; x < xMax; x++)
                {
                    if (exitLoop) 
                    {
                        break;
                    }
                    for (int y = (int)yMin; y < yMax; y++)
                    {
                        bool isExceedthreshold = Math.Abs(grayData1[(int)y, (int)x, 0] - grayData2[(int)y, (int)x, 0]) > thresholdValue1;

                        if (isInArea(x, y, zlist[i]) && isExceedthreshold)
                        {                           
                            flagGrayChange[i] += 1;
                            if (flagGrayChange[i] >= 100)
                            {
                                zlist[i].isExistPerson = true;
                                exitLoop = true;
                                break;
                            }
                        }
                    }

                }
            }
            

        }

        //方法 isInArea：判断dstPiont是否在封闭矩形ABCD内，若是返回true。
        //private bool isInArea(int y,int x, List<Point> plist)
        //{
        //    int nCount = plist.Count;
        //    int nCross = 0;
        //    for (int i = 0; i < plist.Count; i++) 
        //    {
        //        Point p1 = plist[i];
        //        Point p2 = plist[(i + 1) % nCount];
        //        // 求解 y=p.y 与 p1p2 的交点
        //        if (p1.Y == p2.Y) // p1p2 与 y=p0.y平行
        //            continue;
                
        //        if (x< Math.Min(p1.Y, p2.Y)) // 交点在p1p2延长线上
        //            continue;

        //        if (x >= Math.Max(p1.Y, p2.Y)) // 交点在p1p2延长线上
        //            continue;

        //        // 求交点的 X 坐标 --------------------------------------------------------------

        //        double xCross = (double)(x - p1.Y) * (double)(p2.X - p1.X) / (double)(p2.Y - p1.Y) + p1.X;

        //        if (xCross > y)
        //         nCross++; // 只统计单边交点
        //    }

        //    // 单边交点为偶数，点在多边形之外 ---

        //    return (nCross % 2 == 1);
        //}

        //方法：专门对于4边形的判定算法
        private bool isInArea(float y, float x,Zone zone)
        {
            int nCount = zone.plist.Count;
            int nCross = 0;
            for (int i = 0; i < zone.plist.Count; i++)
            {
               
                PointF p1 = new PointF(scaleHeight * zone.plist[i].X, scaleWidth * zone.plist[i].Y);
                PointF p2 = new PointF(scaleHeight * zone.plist[(i + 1) % nCount].X, scaleWidth * zone.plist[(i + 1) % nCount].Y);
                if ( p1.Y ==  p2.Y) // p1p2 与 y=p0.y平行
                    continue;

                if (x < Math.Min(p1.Y, p2.Y)) // 交点在p1p2延长线上
                    continue;

                if (x >= Math.Max(p1.Y, p2.Y)) // 交点在p1p2延长线上
                    continue;

                // 求交点的 X 坐标 --------------------------------------------------------------

                double xCross = (double)(x - p1.Y) * (double)(p2.X - p1.X) / (double)(p2.Y - p1.Y) + p1.X;

                if (xCross > y)
                    nCross++; // 只统计单边交点
            }

            // 单边交点为偶数，点在多边形之外 ---

            return (nCross % 2 == 1);
        }

       
       
        //定义视频的信息
        public struct MovieInfo
        {
            public String filename;
            public int frameCount;
            public int width;
            public int height;
            public int currentFrame;
            public int fps;
            public MovieInfo(String filename, Capture capture)
            {
                this.filename = filename;
                this.frameCount = Convert.ToInt32(CvInvoke.cvGetCaptureProperty(capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_COUNT));
                this.width = Convert.ToInt32(CvInvoke.cvGetCaptureProperty(capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH));
                this.height = Convert.ToInt32(CvInvoke.cvGetCaptureProperty(capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT));
                this.currentFrame = Convert.ToInt32(CvInvoke.cvGetCaptureProperty(capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_POS_FRAMES));
                this.fps = Convert.ToInt32(CvInvoke.cvGetCaptureProperty(capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS));
            }
        }


        private void bt_addZone_Click(object sender, EventArgs e)
        {
            if (tb_ONAME.Text != "")
            {
                Designate = true;
                //addZone = true;
                clickCount = 0;
                plist.Clear();
                pointChosed = false;
                NotExistBkg = true;
                backgroundChange = true;
                bt_bkgChange.Text = "背景帧变化";
                this.isFinishRec = false;
                isItemChecked = false;
                //zoneCount = Int32.Parse(tb_plistCount.Text);
                ONAME = tb_ONAME.Text;
            }
            else 
            {
                MessageBox.Show("请输入区域名称");
            }
        }
        
        private void btSave_Click(object sender, EventArgs e)
        {
            bool isFormateRight = true;
            int AID;
           // int OID;
            ONAME = tb_ONAME.Text;

            if(!Int32.TryParse(tb_AID.Text,out AID))
            {
                tb_AID.Focus();
                isFormateRight = false;
                MessageBox.Show("请先输入监控区域的序号");
            }
            //if (!Int32.TryParse(tb_OID.Text, out OID)) 
            //{
            //    tb_OID.Focus();
            //    isFormateRight = false;
            //}
            if (SID == -1) 
            {
                isFormateRight = false;
                MessageBox.Show(" 请先创建场景！");
                tb_SID.Focus();
            }
            if (isFormateRight && isReadyForWriDB)
            {
                DAO mydao = new DAO("localhost", "root", "root", "ipeople");//连接数据库
                String sqlStr = "insert into tbSceneD(SID,AID,ZBXL,ONAME) values(" + SID + "," + AID + ",'" + ZBXL + "'," + ONAME + ")" ;
                //String sqlStrObj = "insert into tbObjTypes(OID,ONAME) values ("+OID+",'"+ONAME+"' )";
                mydao.daoInsert(sqlStr);
                //mydao.daoInsert(sqlStrObj);
                mydao.Close();
                isReadyForWriDB = false;
                ZBXL = null;
            }
        }


        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.pointChosed) 
            {
                zlist[indexZone].plist[indexPoint] = new Point(e.X, e.Y);
                checkedPoint = new Point(e.X, e.Y);
            }
        }
        PointF p0 = new PointF();
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Designate)
            {
               
                if (clickCount == 0)
                {
                    p0 = new PointF(e.X, e.Y);
                    //plist.Insert(clickCount, p0);
                }
                //if ( clickCount < zoneCount) 
                //{
                //    PointF point=new PointF(e.X,e.Y);
                //    plist.Insert(clickCount, point);
                //}
                int delta = Math.Abs(e.X - (int)p0.X) + Math.Abs(e.Y - (int)p0.Y);
                if (clickCount < 2||delta > 8) 
                {
                    PointF point = new PointF(e.X, e.Y);
                    plist.Insert(clickCount, point);
                }
                else
                {
                    this.Designate = false;
                    this.isFinishRec = true;
                    progressBar.Value = 0;
                    addZone = true;
                    zoneCount = clickCount;
                }

                clickCount++;
                //zoneCount = clickCount;----------------------------------------------------
            }

            if (pointChosed) 
            {
                pointChosed = false;
            }
        }

        //编辑区域
        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.isFinishRec)
            {
                int delta = 9999;
                for (int i = 0; i < zlist.Count; i++)
                {
                    for (int j = 0; j < zlist[i].plist.Count; j++) 
                    {
                        delta = Math.Abs(e.X - (int)zlist[i].plist[j].X) + Math.Abs(e.Y - (int)zlist[i].plist[j].Y);
                        if (delta < 10)
                        {
                            pointChosed = true;
                            //frame.Draw(new CircleF(new PointF(plist[i].X, plist[i].Y), 5), new Bgr(0, 255, 0), -1);
                            checkedPoint = new PointF(zlist[i].plist[j].X, zlist[i].plist[j].Y);
                            indexZone = i;
                            indexPoint = j;
                        }
                    }
                    
                }
            }


        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            int p = (sender as TrackBar).Value;
            if (p < 0)
            {
                p = 0;
            }
            else if (p >= movieInfo.frameCount-1)
            {
                p = movieInfo.frameCount;
               // p = 0;
            }
            movieInfo.currentFrame = p;
            CvInvoke.cvSetCaptureProperty(capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_POS_FRAMES, p);
        }

        
        private void btPlay_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                if (myTimer == null)
                {
                    return;
                }
                else
                {
                    myTimer.Start();
                }

                btSelect.Enabled = true;
                btPlay.Text = "暂停";
            }else
            {
                if (myTimer == null)
                {
                    return;
                }
                else
                {
                    myTimer.Stop();
                }

                btSelect.Enabled = false;
                btPlay.Text = "播放";
            }

            isPlaying = !isPlaying;

        }


        private void btnPrev_Click(object sender, EventArgs e)
        {

            int p = movieInfo.currentFrame - 1;
            movieInfo.currentFrame--;
            lbShowCurrFrame.Text = movieInfo.currentFrame.ToString();
            CvInvoke.cvSetCaptureProperty(capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_POS_FRAMES, p);
            renderFrame(p);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            renderFrame(movieInfo.currentFrame + 1);
            lbShowCurrFrame.Text = movieInfo.currentFrame.ToString();
        }

  
        private void bt_bkgChange_Click(object sender, EventArgs e)
        {
            if (isFinishRec)
            {
                if (backgroundChange)
                {
                    bt_bkgChange.Text = "背景帧不变";
                    NotExistBkg = true;
                }
                else
                {
                    bt_bkgChange.Text = "背景帧变化";
                }

                backgroundChange = !backgroundChange;

            }
        }
 
        //删除选中的区域  
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (indexDel >= 0 && isItemChecked)
            {
                zlist.RemoveAt(indexDel);
                lbxGrayChange.Items.Remove(lbxGrayChange.SelectedItem);
                isItemChecked = false;
                panelZoneName.Controls.Clear();
            }
        }

        private void lbxGrayChange_MouseClick(object sender, MouseEventArgs e)
        {
            indexDel = lbxGrayChange.SelectedIndex;
            isItemChecked = true;
        }

        private void bt_addScene_Click(object sender, EventArgs e)
        {
            //int SID;//监控场景序号
            int JG;//人流量统计时间间隔
            String SJ = null;//日期时间
            DateTime dateValue;
            String DD = tb_DD.Text;//地点
            String MS = tb_MS.Text;//场景描述
            bool isFormateRight = true;

            if (!Int32.TryParse(tb_JG.Text, out JG))
            {
                tb_JG.Focus();
                //JG = 0;
                isFormateRight = false;
            }
            if (DateTime.TryParse(tb_SJ.Text, out dateValue))
            {
                SJ = dateValue.ToShortDateString();
            }
            else 
            {
                tb_SJ.Focus();
                isFormateRight = false;
            }

            if (!Int32.TryParse(tb_SID.Text, out SID))
            {
                MessageBox.Show("请输入有效的场景ID！");
                tb_SID.Focus();
                //SID = 0;
                isFormateRight = false;
            }

            //SJ = SJ.Date;
            if (isFormateRight)
            {
                DAO mydao = new DAO("localhost", "root", "root", "ipeople");//连接数据库
                String sqlStr = "insert into tbScene(SID,SJ,DD,MS,JG) values(" + SID + ",'" + SJ + "','" + DD + "','" + MS + "'," + JG + ")";
                //String sqlStr = "insert into tbScene(SID,SJ,DD,MS,JG) values(@SID,@SJ,@DD,@MS,@JG)";
                // Console.WriteLine(sqlStr);
                mydao.daoInsert(sqlStr);
                mydao.Close();
            }
            else 
            {
                MessageBox.Show("创建场景失败！");
            }
        }

        //private void bt_edit_Click(object sender, EventArgs e)
        //{
        //    //int SID;//监控场景序号
        //    int JG;//人流量统计时间间隔
        //    String SJ = null;//日期时间
        //    DateTime dateValue;
        //    String DD = tb_DD.Text;//地点
        //    String MS = tb_MS.Text;//场景描述
        //    bool isFormateRight = true;

        //    if (!Int32.TryParse(tb_JG.Text, out JG))
        //    {
        //        tb_JG.Focus();
        //        //JG = 0;
        //        isFormateRight = false;
        //    }
        //    if (DateTime.TryParse(tb_SJ.Text, out dateValue))
        //    {
        //        SJ = dateValue.ToShortDateString();
        //    }
        //    else
        //    {
        //        tb_SJ.Focus();
        //        isFormateRight = false;
        //    }

        //    if (isFormateRight)
        //    {
        //        DAO mydao = new DAO("localhost", "root", "root", "ipeople");//连接数据库
        //        String sqlStr = "UPDATE tbScene SET SJ= '" + SJ + "',DD='" + DD + "',MS='" + MS + "',JG=" + JG + " WHERE SID= '" + tb_SID.Text + "'";
        //        //String sqlStr = "insert into tbScene(SID,SJ,DD,MS,JG) values(@SID,@SJ,@DD,@MS,@JG)";
        //        // Console.WriteLine(sqlStr);
        //        mydao.daoInsert(sqlStr);
        //        mydao.Close();
        //    }
        //}

        //查看标定区域信息
        private void bt_markInfo_Click(object sender, EventArgs e)
        {
            FormMarkInfo markInfoDlg = new FormMarkInfo();
            markInfoDlg.ShowDialog();
        }

        //查看场景
        private void bt_checkScene_Click(object sender, EventArgs e)
        {
            FormSceneInfo sceneInfoDlg = new FormSceneInfo();
            sceneInfoDlg.SetTextBoxDel = loadSceneInfo;
            sceneInfoDlg.getParameterDel = GetParameter;
            sceneInfoDlg.sceneDDel = loadSceneD;
            sceneInfoDlg.ShowDialog();
        }

        private void loadSceneInfo(string SID, string SJ, string DD, string MS, string JG) 
        {
            tb_SID.Text = SID;
            tb_SJ.Text = SJ;
            tb_DD.Text = DD;
            tb_MS.Text = MS;
            tb_JG.Text = JG;
            this.SID = Int32.Parse(SID);
        }

        public Tuple<float, float> GetParameter()
        {
            return new Tuple<float, float>(this.scaleHeight, this.scaleWidth);
        }

        
        
        public void loadSceneD(List<Zone> zlist)
        {
            this.zlist = zlist;
            Designate = false;
            addZone = false;
            clickCount = 0;
            plist.Clear();
            pointChosed = false;
            NotExistBkg = true;
            backgroundChange = true;
            bt_bkgChange.Text = "背景帧变化";
            this.isFinishRec = true;
            isItemChecked = false;
        }

    }
}
