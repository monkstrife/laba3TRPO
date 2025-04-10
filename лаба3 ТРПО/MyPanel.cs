using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace лаба3_ТРПО
{
    class MyPanel : Panel
    {

        Graphics g;
        Brush ColorPoint = Brushes.Red;
        Pen ColorLine = Pens.Red;

        int xSpeed = 5;
        int ySpeed = 5;
        Dictionary<int, int[]> speedDic = new Dictionary<int, int[]>();

        List<Point> points = new List<Point>();

        List<Dictionary<int,Point>> pointsCurve = new List<Dictionary<int,Point>>();
        int countCurve = 0;

        List<Dictionary<int, Point>> pointsFillCurve = new List<Dictionary<int, Point>>();
        int countFillCurve = 0;

        List<Dictionary<int, Point>> pointsPol = new List<Dictionary<int, Point>>();
        int countPol = 0;

        List<Dictionary<int, Point>> pointsBez = new List<Dictionary<int, Point>>();
        int countBez = 0;

        private bool des_Point = false;
        private bool des_Curve = false;
        private bool des_Pol = false;
        private bool des_Bez = false;
        private bool des_FillCurve = false;

        int iDraggingPoint;
        bool bDrag = false;
        public MyPanel() 
        {
            DoubleBuffered = true;


            Paint += PaintHandler;
            Paint += ClosedCurveHandler;
            Paint += PolygonHandler;
            Paint += BeziersHandler;
            Paint += FillClosedCurveHandler;

            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
        }

        public void DictFill()
        {
            for (int i = 0; i < points.Count; i++)
            {
                speedDic[i] = new int[2] {-10,-10 };
            }
        }

        public void SpeedUp()
        {
            for (int i = 0; i < points.Count; i++)
            {
                speedDic[i][0] = speedDic[i][0] * 2;
                speedDic[i][1] = speedDic[i][1] * 2;
            }
        }

        public void SpeedDown()
        {
            for (int i = 0; i < points.Count; i++)
            {
                speedDic[i][0] = speedDic[i][0] / 2;
                speedDic[i][1] = speedDic[i][1] / 2;
            }
        }

        public void MovePoints(object sender, EventArgs e)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].X + speedDic[i][0] < 0)
                {
                    speedDic[i][0] = speedDic[i][0] * (-1);
                }
                if (points[i].Y + speedDic[i][0] < 0)
                {
                    speedDic[i][1] = speedDic[i][1] * (-1);
                }
                if (points[i].X + speedDic[i][0] > 659)
                {
                    speedDic[i][0] = speedDic[i][0] * (-1);
                }
                if (points[i].Y + speedDic[i][0] > 390)
                {
                    speedDic[i][1] = speedDic[i][1] * (-1);
                }

                points[i] = new Point(points[i].X + speedDic[i][0], points[i].Y + speedDic[i][1]);

                for (int j = 0; j < countCurve; j++)
                {
                    if (pointsCurve[j].ContainsKey(i))
                        pointsCurve[j][i] = new Point(points[i].X + speedDic[i][0], points[i].Y + speedDic[i][1]);
                }

                for (int j = 0; j < countPol; j++)
                {
                    if (pointsPol[j].ContainsKey(i))
                        pointsPol[j][i] = new Point(points[i].X + speedDic[i][0], points[i].Y + speedDic[i][1]);
                }

                for (int j = 0; j < countBez; j++)
                {
                    if (pointsBez[j].ContainsKey(i))
                        pointsBez[j][i] = new Point(points[i].X + speedDic[i][0], points[i].Y + speedDic[i][1]);
                }

                for (int j = 0; j < countFillCurve; j++)
                {
                    if (pointsFillCurve[j].ContainsKey(i))
                        pointsFillCurve[j][i] = new Point(points[i].X + speedDic[i][0], points[i].Y + speedDic[i][1]);
                }
            }

            Refresh();
        }

        public void MovePointsTo(string s)
        {
            int speedx = 0;
            int speedy = 0;

            switch(s)
            {
                case ("Up"):
                    speedy = -10;
                    break;
                case ("Left"):
                    speedx = -10;
                    break;
                case ("Down"):
                    speedy = 10;
                    break;
                case ("Right"):
                    speedx = 10;
                    break;
            }

            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new Point(points[i].X + speedx, points[i].Y + speedy);

                for (int j = 0; j < countCurve; j++)
                {
                    if (pointsCurve[j].ContainsKey(i))
                        pointsCurve[j][i] = new Point(points[i].X + speedx, points[i].Y + speedy);
                }

                for (int j = 0; j < countPol; j++)
                {
                    if (pointsPol[j].ContainsKey(i))
                        pointsPol[j][i] = new Point(points[i].X + speedx, points[i].Y + speedy);
                }

                for (int j = 0; j < countBez; j++)
                {
                    if (pointsBez[j].ContainsKey(i))
                        pointsBez[j][i] = new Point(points[i].X + speedx, points[i].Y + speedy);
                }

                for (int j = 0; j < countFillCurve; j++)
                {
                    if (pointsFillCurve[j].ContainsKey(i))
                        pointsFillCurve[j][i] = new Point(points[i].X + speedx, points[i].Y + speedy);
                }
            }

            Refresh();
        }

        public void AR_Form1_MouseClick()
        {
            if(!des_Point)
            {
                MouseClick += Form1_MouseClick;
                des_Point = true;
            }
            else
            {
                MouseClick -= Form1_MouseClick;
                des_Point = false;
            }
                
        }

        public void AR_ClosedCurveHandler()
        {
            if (!des_Curve)
            {
                des_Curve = true;
                pointsCurve.Add(new Dictionary<int, Point>());
                countCurve++;
            }
            else
            {
                des_Curve = false;
            }

        }

        public void AR_FillClosedCurveHandler()
        {
            if (!des_FillCurve)
            {
                des_FillCurve = true;
                pointsFillCurve.Add(new Dictionary<int, Point>());
                countFillCurve++;
            }
            else
            {
                des_FillCurve = false;
            }

        }

        public void AR_PolygonHandler()
        {
            if (!des_Pol)
            {
                des_Pol = true;
                pointsPol.Add(new Dictionary<int, Point>());
                countPol++;
            }
            else
            {
                des_Pol = false;
            }

        }

        public void AR_BeziersHandler()
        {
            if (!des_Bez)
            {
                des_Bez = true;
                pointsBez.Add(new Dictionary<int, Point>());
                countBez++;
            }
            else
            {
                des_Bez = false;
            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.Location.X, e.Location.Y);
                ref Point pRef = ref p;
                p.X = e.X - 5;
                p.Y = e.Y - 5;
                points.Add(pRef);
                speedDic.Add(points.Count - 1, new int[2] { -10, -10 });
                if (des_Curve == true)
                    pointsCurve[countCurve - 1].Add(points.Count - 1, pRef);
                if (des_FillCurve == true)
                    pointsFillCurve[countFillCurve - 1].Add(points.Count - 1, pRef);
                if (des_Pol == true)
                    pointsPol[countPol - 1].Add(points.Count - 1, pRef);
                if (des_Bez == true)
                {
                    pointsBez[countBez - 1].Add(points.Count - 1, pRef);
                    if(pointsBez[countBez - 1].Count == 4)
                    {
                        pointsBez.Add(new Dictionary<int, Point> ());
                        countBez++;
                    }
                }
                Refresh();
            }

        }

        public void PaintHandler(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            foreach (Point p in points)
            {
                g.FillEllipse(ColorPoint, p.X, p.Y, 10, 10);
            }
        }

        public void ClosedCurveHandler(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            /*for(int i = 0; i < countCurve; i++)
            {
                if (pointsCurve[i].Count >= 3)
                {
                    g.DrawClosedCurve(ColorLine, pointsCurve[i].ToArray());
                }
            }*/

            for (int i = 0; i < countCurve; i++)
            {
                if (pointsCurve[i].Count >= 3)
                {
                    List<Point> l = new List<Point>();
                    foreach(var item in pointsCurve[i])
                    {
                        l.Add(item.Value);
                    }
                    g.DrawClosedCurve(ColorLine, l.ToArray());
                }
            }
        }

        public void PolygonHandler(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            /*for (int i = 0; i < countPol; i++)
            {
                if (pointsPol[i].Count >= 3)
                {
                    g.DrawPolygon(ColorLine, pointsPol[i].ToArray());
                }
            }*/

            for (int i = 0; i < countPol; i++)
            {
                if (pointsPol[i].Count >= 3)
                {
                    List<Point> l = new List<Point>();
                    foreach (var item in pointsPol[i])
                    {
                        l.Add(item.Value);
                    }
                    g.DrawPolygon(ColorLine, l.ToArray());
                }
            }
        }

        public void BeziersHandler(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            /*for (int i = 0; i < countBez; i++)
            {
                if (pointsBez[i].Count == 4)
                {
                    g.DrawBeziers(ColorLine, pointsBez[i].ToArray());
                }
            }*/

            for (int i = 0; i < countBez; i++)
            {
                if (pointsBez[i].Count >= 3)
                {
                    List<Point> l = new List<Point>();
                    foreach (var item in pointsBez[i])
                    {
                        l.Add(item.Value);
                    }
                    g.DrawBeziers(ColorLine, l.ToArray());
                }
            }
        }

        public void FillClosedCurveHandler(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            /*for (int i = 0; i < countFillCurve; i++)
            {
                if (pointsFillCurve[i].Count >= 3)
                {
                    g.FillClosedCurve(Brushes.Aqua, pointsFillCurve[i].ToArray());
                    g.DrawClosedCurve(ColorLine, pointsFillCurve[i].ToArray());
                }
            }*/

            for (int i = 0; i < countFillCurve; i++)
            {
                if (pointsFillCurve[i].Count >= 3)
                {
                    List<Point> l = new List<Point>();
                    foreach (var item in pointsFillCurve[i])
                    {
                        l.Add(item.Value);
                    }
                    g.FillClosedCurve(Brushes.Aqua, l.ToArray());
                    g.DrawClosedCurve(ColorLine, l.ToArray());
                }
            }
        }

        public bool IsOnPoint(Point e, Point p)
        {
            if(Math.Abs(e.X - p.X) <= 10 && Math.Abs(e.Y - p.Y) <= 10)
                return true;
            else
                return false;
        }

        public void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            for(int i = 0; i < points.Count; i++)
            {
                Point p = points[i];

                if(IsOnPoint(e.Location, p))
                {
                    iDraggingPoint = i;
                    bDrag = true;
                }
            }
        }

        public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(bDrag)
            {
                points[iDraggingPoint] = new Point(e.Location.X, e.Location.Y);
                /*Point p = new Point(e.Location.X, e.Location.Y);
                ref Point pRef = ref p;
                points[iDraggingPoint] = pRef;*/

                for (int i = 0; i < countCurve; i++)
                {
                    if(pointsCurve[i].ContainsKey(iDraggingPoint))
                        pointsCurve[i][iDraggingPoint] = new Point(e.Location.X, e.Location.Y);
                }

                for (int i = 0; i < countPol; i++)
                {
                    if (pointsPol[i].ContainsKey(iDraggingPoint))
                        pointsPol[i][iDraggingPoint] = new Point(e.Location.X, e.Location.Y);
                }

                for (int i = 0; i < countBez; i++)
                {
                    if (pointsBez[i].ContainsKey(iDraggingPoint))
                        pointsBez[i][iDraggingPoint] = new Point(e.Location.X, e.Location.Y);
                }

                for (int i = 0; i < countFillCurve; i++)
                {
                    if (pointsFillCurve[i].ContainsKey(iDraggingPoint))
                        pointsFillCurve[i][iDraggingPoint] = new Point(e.Location.X, e.Location.Y);
                }

                Refresh();
            }
        }

        public void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            bDrag = false;
        }

        public void clearPanel()
        {
            points.Clear();

            pointsCurve.Clear();
            if (des_Curve == true)
            {
                pointsCurve.Add(new Dictionary<int, Point>());
                countCurve = 1;
            }
            else
                countCurve = 0;

            pointsFillCurve.Clear();
            if (des_FillCurve == true)
            {
                pointsFillCurve.Add(new Dictionary<int, Point>());
                countFillCurve = 1;
            }
            else
                countFillCurve = 0;

            pointsPol.Clear();
            if (des_Pol == true)
            {
                pointsPol.Add(new Dictionary<int, Point>());
                countPol = 1;
            }
            else
                countPol = 0;

            pointsBez.Clear();
            if (des_Bez == true)
            {
                pointsBez.Add(new Dictionary<int, Point>());
                countBez = 1;
            }
            else
                countBez = 0;

            speedDic.Clear();

            Refresh();
        }

        public void setColor(Brush color, Pen color2)
        {
            ColorPoint = color;
            ColorLine = color2;
            Refresh();
        }
    }
}
