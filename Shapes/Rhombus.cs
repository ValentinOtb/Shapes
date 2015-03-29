using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shapes
{
    public class Rhombus_ : Shape_
    {
        private double area;
        private double perimeter;
        private double side;
        private Point topPoint = new Point();
        private Point leftPoint = new Point();
        public const int definingPointsCount = 2;


        public Rhombus_(Point topPoint,
            Point leftPoint)
        {
            this.topPoint = topPoint;
            this.leftPoint = leftPoint;
            this.BrushColor = Brushes.White;
            this.StrokeColor = Brushes.Black;

            side = Point.Subtract(topPoint, leftPoint).Length;
            CalculateProperties();
        }

        public Rhombus_()
        {
            this.BrushColor = Brushes.White;
            this.StrokeColor = Brushes.Black;

            CalculateProperties();
        }

        public double Area
        {
            get { return area; }
        }

        public double Perimeter
        {
            get { return perimeter; }
        }

        private void CalculateProperties()
        {
            perimeter = 4 * side;

            area = (leftPoint.Y - topPoint.Y) * 2 * (topPoint.X - leftPoint.X);
        }

        public override void SetPointsViaList(List<Point> points)
        {
            if (points.Count != definingPointsCount)
            {
                while (points.Count != definingPointsCount)
                    points.Add(new Point());
            }

            topPoint = points[0];
            leftPoint = points[1];
        }

        public override UIElement UIEquivalent()
        {
            Path rhombus = new Path();
            PathFigure pathFigure = new PathFigure(topPoint,
                new PathSegment[] { new LineSegment(leftPoint, true), 
                    new LineSegment(Point.Add(topPoint, new Vector(0, 2 * (leftPoint.Y - topPoint.Y))), true),
                    new LineSegment(Point.Add(leftPoint, new Vector(2 * (topPoint.X - leftPoint.X), 0)), true)}, true);
            PathGeometry figure = new PathGeometry(new PathFigure[] { pathFigure });
            rhombus.Data = figure;
            rhombus.Stroke = this.StrokeColor;
            rhombus.Fill = this.BrushColor;
            return rhombus;
        }
    }
}
