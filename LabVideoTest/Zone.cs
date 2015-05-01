using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;


namespace LabVideoTest
{
    public class Zone
    {
        //private bool pointChosed = false;
        //Image<Bgr, Byte> frame;
        public List<PointF> plist;
        float scaleHeight;
        float scaleWidth;
        private float xMin = 999999;
        private float yMin = 999999;
        private float xMax = 0;
        private float yMax = 0;
        private int   time = 0;//区域中人停留时间的统计
        public  bool  isExistPerson = false;//灰度值跳变超过阈值则为true
        private int   zoneCount;//区域的顶点数
        private string ONAME;
        public Zone(List<PointF> plist,float scaleHeight,float scaleWidth,string ONAME) 
        {
            //this.frame = frame;
            this.scaleHeight = scaleHeight;
            this.scaleWidth = scaleWidth;
            this.plist = new List<PointF>(plist);
            this.zoneCount = plist.Count;
            //this.pointChosed = pointChosed;
            this.ONAME = ONAME;
            for (int j = 0; j < plist.Count; j++)
            {
                xMin = Math.Min(scaleHeight * plist[j].X, xMin);
                xMax = Math.Max(scaleHeight * plist[j].X, xMax);
                yMin = Math.Min(scaleWidth * plist[j].Y, yMin);
                yMax = Math.Max(scaleWidth * plist[j].Y, yMax);
            }
        }

        public void setONAME(String zoneName) 
        {
            this.ONAME = zoneName;
        }

        public String getONAME() 
        {
            return this.ONAME;
        }

        public void addTime( )
        {
            this.time++;
        }

        public int getTime() 
        {
            return this.time;
        }
        public bool isEditable(bool pointChosed) 
        {
            return pointChosed;
        }

        public float getXmin() 
        {
            return xMin;
        }

        public float getXmax() 
        {
            return xMax;
        }
        public float getYmin() 
        {
            return yMin;
        }
        public float getYmax()
        {
            return yMax;
        }
        public int getZonePointCount() 
        {
            return zoneCount;
        }
        //public void editZone(PointF checkedPoint)
        //{
        //    frame.Draw(new CircleF(new PointF(checkedPoint.X * scaleHeight, checkedPoint.Y * scaleWidth), 15), new Bgr(0, 255, 0), -1);
        //}

        //public void drawingZone(List<PointF> plist)
        //{

        //    for (int i = 0; i < plist.Count-1; i++)
        //    {
        //        PointF point1, point2;//视频点缩放，测试数据临时变量
        //        point1 = new PointF(scaleHeight * plist[i].X, scaleWidth * plist[i].Y);
        //        point2 = new PointF(scaleHeight * plist[(i + 1) % zoneCount].X, scaleWidth * plist[(i + 1) % zoneCount].Y);
               

        //        frame.Draw(new LineSegment2DF(point1, point2), new Bgr(0, 0, 255), 3);//画出4边形
                
        //        if (i == this.zoneCount-2) 
        //        {
                    
        //            PointF pointFirst = new PointF(scaleHeight * plist[0].X, scaleWidth * plist[0].Y);
        //            PointF pointEnd   = new PointF(scaleHeight * plist[this.zoneCount-1].X, scaleWidth * plist[this.zoneCount-1].Y);
        //            frame.Draw(new LineSegment2DF(pointFirst, pointEnd), new Bgr(0, 0, 255), 3);
        //        }
        //    }
              
        //}
    }
}
