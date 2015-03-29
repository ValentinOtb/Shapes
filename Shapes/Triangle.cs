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
    public class Triangle_ :  Shape_, IClosable
    {
        private double area;
        private double perimeter;
        private Point firstPoint = new Point();
        private Point secondPoint = new Point();
        private Point thirdPoint = new Point();
        public const int definingPointsCount = 3;


        public Triangle_(Point firstPoint,
            Point secondPoint, Point thirdPoint, Brush color)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.thirdPoint = thirdPoint;
            this.BrushColor = color;
            this.StrokeColor = Brushes.Black;

            CalculateProperties();
        }

        public Triangle_()
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
            perimeter += Point.Subtract(firstPoint, secondPoint).Length +
                Point.Subtract(secondPoint, thirdPoint).Length +
                Point.Subtract(thirdPoint, firstPoint).Length;

            double semiPerimeter = perimeter / 2;
            area = Math.Sqrt(semiPerimeter * (semiPerimeter - Point.Subtract(firstPoint, secondPoint).Length) *
                (semiPerimeter - Point.Subtract(secondPoint, thirdPoint).Length) *
                (semiPerimeter - Point.Subtract(thirdPoint, firstPoint).Length));
        }

        public override void SetPointsViaList(List<Point> points)
        {
            if (points.Count != definingPointsCount)
            {
                while (points.Count != definingPointsCount)
                    points.Add(new Point());
            }

            firstPoint = points[0];
            secondPoint = points[1];
            thirdPoint = points[2];
        }

        public override UIElement UIEquivalent()
        {
            Path triangle = new Path();
            PathFigure pathFigure = new PathFigure(firstPoint,
                new PathSegment[] { new LineSegment(secondPoint, true), new LineSegment(thirdPoint, true) }, true);
            PathGeometry figure = new PathGeometry(new PathFigure[] { pathFigure });
            triangle.Data = figure;
            triangle.Stroke = this.StrokeColor;
            triangle.Fill = this.BrushColor;

            return triangle;
        }
    }
}
