using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //double d = CoordDispose.GetDistance(new Degree(116.403856, 39.915415), new Degree(116.405751, 39.914875));
            //MessageBox.Show(d.ToString());

            double lat = 116.35473013706;
            double lng = 40.0018424987793;

            Convert_GCJ02_To_BD09(ref lat, ref lng);

            //MessageBox.Show(lat + "---" + lng);

            //---------------------------------------------------
            string ss = "{\"status\":0,\"result\":[{\"x\":40.108201381092,\"y\":116.4548685837}]}";
            var jsonR=JsonConvert.DeserializeObject<JsonResult>(ss);

            MessageBox.Show(jsonR.result[0].x.ToString());
            
        }

        private const double x_pi = 3.14159265358979324 * 3000.0 / 180.0;
        /// <summary>
        /// 中国正常坐标系GCJ02协议的坐标，转到 百度地图对应的 BD09 协议坐标
        /// </summary>
        /// <param name="lat">维度</param>
        /// <param name="lng">经度</param>
        public static void Convert_GCJ02_To_BD09(ref double lat, ref double lng)
        {
            double x = lng, y = lat;
            double z = Math.Sqrt(x * x + y * y) + 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) + 0.000003 * Math.Cos(x * x_pi);
            lng = z * Math.Cos(theta) + 0.0065;
            lat = z * Math.Sin(theta) + 0.006;
        }
    }

    public class JsonResult
    {
        public int status { get; set; }
        public List<Location> result { get; set; }
    }

    public class Location
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    /// <summary>
    /// 经纬度坐标
    /// </summary>   
    public class Degree
    {
        public Degree(double x, double y)
        {
            X = x;
            Y = y;
        }
        private double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
    }

    public class CoordDispose
    {
        private const double EARTH_RADIUS = 6378137.0;//地球半径(米)
        /// <summary>
        /// 角度数转换为弧度公式
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double radians(double d)
        {
            return d * Math.PI / 180.0;
        }
        /// <summary>
        /// 弧度转换为角度数公式
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double degrees(double d)
        {
            return d * (180 / Math.PI);
        }
        /// <summary>
        /// 计算两个经纬度之间的直接距离
        /// </summary>
        public static double GetDistance(Degree Degree1, Degree Degree2)
        {
            double radLat1 = radians(Degree1.X);
            double radLat2 = radians(Degree2.X);
            double a = radLat1 - radLat2;
            double b = radians(Degree1.Y) - radians(Degree2.Y);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }
        /// <summary>
        /// 计算两个经纬度之间的直接距离(google 算法)
        /// </summary>
        public static double GetDistanceGoogle(Degree Degree1, Degree Degree2)
        {
            double radLat1 = radians(Degree1.X);
            double radLng1 = radians(Degree1.Y);
            double radLat2 = radians(Degree2.X);
            double radLng2 = radians(Degree2.Y);
            double s = Math.Acos(Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Cos(radLng1 - radLng2) + Math.Sin(radLat1) * Math.Sin(radLat2));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }
        /// <summary>
        /// 以一个经纬度为中心计算出四个顶点
        /// </summary>
        /// <param name="distance">半径(米)</param>
        /// <returns></returns>
        public static Degree[] GetDegreeCoordinates(Degree Degree1, double distance)
        {
            double dlng = 2 * Math.Asin(Math.Sin(distance / (2 * EARTH_RADIUS)) / Math.Cos(Degree1.X));
            dlng = degrees(dlng);//一定转换成角度数  原PHP文章这个地方说的不清楚根本不正确 后来lz又查了很多资料终于搞定了
            double dlat = distance / EARTH_RADIUS;
            dlat = degrees(dlat);//一定转换成角度数
            return new Degree[] { new Degree(Math.Round(Degree1.X + dlat,6), Math.Round(Degree1.Y - dlng,6)),//left-top
                                  new Degree(Math.Round(Degree1.X - dlat,6), Math.Round(Degree1.Y - dlng,6)),//left-bottom
                                  new Degree(Math.Round(Degree1.X + dlat,6), Math.Round(Degree1.Y + dlng,6)),//right-top
                                  new Degree(Math.Round(Degree1.X - dlat,6), Math.Round(Degree1.Y + dlng,6)) //right-bottom
            };
        }
    }
}
