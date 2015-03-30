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
    public class Circle_ : Shape_, IClosable, IDrawable
    {
        private double area;
        private double perimeter;
        public const int definingPointsCount = 2;

        private Point center = new Point();
        private int radius;



        public Circle_(Point center)
        {
            this.center = center;
            this.BrushColor = Brushes.White;
            this.StrokeColor = Brushes.Black;

            CalculateProperties();
        }

        public Circle_()
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

        protected override void CalculateProperties()
        {
            double pi = 3.14;
            area = pi * radius * radius;
            perimeter = 2 * pi * radius;
        }

        public override void SetPointsViaList(List<Point> points)
        {
            if (points.Count != definingPointsCount)
            {
                while (points.Count != definingPointsCount)
                    points.Add(new Point());
            }

            center = points[0];
            radius = (int)Math.Abs(Point.Subtract(points[0], points[1]).Length);
        }

        public override UIElement UIEquivalent()
        {
            Ellipse myEllipse = new Ellipse();
            myEllipse.Width = 2 * radius;
            myEllipse.Height = myEllipse.Width;
            myEllipse.Fill = this.BrushColor;
            myEllipse.Stroke = this.StrokeColor;

            Canvas.SetLeft(myEllipse, center.X - radius);
            Canvas.SetTop(myEllipse, center.Y - radius);

            return myEllipse;
        }
    }
}
