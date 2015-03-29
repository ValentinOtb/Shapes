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
    class Pentagon_ : Shape_
    {
        //private double area;
        //private double perimeter;
        private Point firstPoint = new Point();
        private Point secondPoint = new Point();
        private Point thirdPoint = new Point();
        private Point fourthPoint = new Point();
        private Point fifthPoint = new Point();
        public const int definingPointsCount = 5;

        public Pentagon_(Point firstPoint,
            Point secondPoint, Point thirdPoint,
            Point fourthPoint, Point fifthPoint)
        {
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.thirdPoint = thirdPoint;
            this.fourthPoint = fourthPoint;
            this.fifthPoint = fifthPoint;

            this.BrushColor = Brushes.White;
            this.StrokeColor = Brushes.Black;

            CalculateProperties();
        }

        public Pentagon_()
        {
            this.BrushColor = Brushes.White;
            this.StrokeColor = Brushes.Black;

            CalculateProperties();
        }

        private void CalculateProperties()
        {

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
            fourthPoint = points[3];
            fifthPoint = points[4];
        }

        public override UIElement UIEquivalent()
        {
            Path pentagon = new Path();
            PathFigure pathFigure = new PathFigure(firstPoint,
                new PathSegment[] { new LineSegment(secondPoint, true), new LineSegment(thirdPoint, true),
                new LineSegment(fourthPoint, true), new LineSegment(fifthPoint, true)}, true);
            PathGeometry figure = new PathGeometry(new PathFigure[] { pathFigure });
            pentagon.Data = figure;
            pentagon.Stroke = this.StrokeColor;
            pentagon.Fill = this.BrushColor;

            return pentagon;
        }
    }
}