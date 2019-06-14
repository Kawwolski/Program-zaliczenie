using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Figury.Shapes
{
    public class Circle : Shape
    {
        public Circle()
        {
            pointList = new List<Point>();
        }

        override public double Area()
        {
            double area;
            double length = Math.Sqrt(Math.Pow(pointList[1].X - pointList[0].X, 2) + Math.Pow(pointList[1].Y - pointList[0].Y, 2));
            return area = Math.PI * Math.Pow(length, 2);
        }

        override public double Circumference()
        {
            double circumference;
            double length = Math.Sqrt(Math.Pow(pointList[1].X - pointList[0].X, 2) + Math.Pow(pointList[1].Y - pointList[0].Y, 2));
            return circumference = 2 * Math.PI * length;
        }
    }
}
