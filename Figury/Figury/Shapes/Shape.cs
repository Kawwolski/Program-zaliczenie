using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Figury
{
    public abstract class Shape
    {
        public List<Point> pointList { get; set; }

        public void OrderPoints()
        {
            if (pointList.Count > 2)
            {
                
                double yMin = pointList.Min(o => o.Y);
                List<Point> pp = pointList.FindAll(o => o.Y == yMin);
                double xMin = pp.Min(o => o.X);

                Point pMin = pointList.Find(o => o.X == xMin && o.Y == yMin);
                pointList.Remove(pMin);

                List<Point> wspolrzedne = new List<Point>();
                List<KeyValuePair<int, double>> katy = new List<KeyValuePair<int, double>>();

                for (int i = 0; i < pointList.Count; i++)
                {
                    Point p = new Point();
                    p.X = pointList[i].X - pMin.X;
                    p.Y = pointList[i].Y - pMin.Y;
                    wspolrzedne.Add(p);
                }

                Vector vMin = new Vector(pMin.X + 1, 0);
                for (int i = 0; i < wspolrzedne.Count; i++)
                {
                    Vector v = new Vector(wspolrzedne[i].X, wspolrzedne[i].Y);
                    katy.Add(new KeyValuePair<int, double>(i, Vector.AngleBetween(vMin, v)));
                }

                List<KeyValuePair<int, double>> katyPosortowane = katy.OrderBy(o => o.Value).ToList();

                List<Point> tmp = new List<Point>();

                for (int i = 0; i < katyPosortowane.Count; i++)
                {
                    tmp.Add(pointList[katyPosortowane[i].Key]);
                }

                pointList.Clear();
                pointList.Add(pMin);

                foreach (Point p in tmp)
                    pointList.Add(p);
            }
        }

        public abstract double Area();

        public abstract double Circumference();

        public void Dispose()
        {
            pointList.Clear();
        }
    }
}
