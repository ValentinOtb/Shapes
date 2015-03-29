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
    public class Line_ : Shape_
    {
        private Point firstPoint = new Point();
        private Point secondPoint = new Point();
        private double length;
        public const int definingPointsCount = 2;

        public Line_(Point firstPoint,
            Point secondPoint)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.BrushColor = Brushes.White;
            this.StrokeColor = Brushes.Black;

            CalculateProperties();
        }

        public Line_()
        {
            this.BrushColor = Brushes.White;
            this.StrokeColor = Brushes.Black;

            CalculateProperties();
        }

        public double Length
        {
            get { return length; }
        }

        private void CalculateProperties()
        {
            length = Point.Subtract(firstPoint, secondPoint).Length;
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
        }

        public override UIElement UIEquivalent()
        {
            Line line = new Line();
            line.X1 = firstPoint.X;
            line.Y1 = firstPoint.Y;
            line.X2 = secondPoint.X;
            line.Y2 = secondPoint.Y;

            line.Stroke = this.StrokeColor;
            line.StrokeThickness = 4;

            return line;
        }
    }
}
