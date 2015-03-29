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
    public class Ellipse_ : Shape_
    {
        private double area;
        private double perimeter;
        public const int definingPointsCount = 2;

        private Point topLeft = new Point();
        private Point botRight = new Point();


        public Ellipse_(Point topLeft,
            Point botRight)
        {
            this.topLeft = topLeft;
            this.botRight = botRight;
            this.BrushColor = Brushes.White;
            this.StrokeColor = Brushes.Black;

            CalculateProperties();
        }

        public Ellipse_()
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
            double pi = 3.14;

            double a = (botRight.X - topLeft.X) / 2;
            double b = (botRight.Y - topLeft.Y) / 2;

            area = pi * a * b;

            perimeter = 4 * (pi * a * b + (a - b) * (a - b)) / (a + b);
        }

        public override void SetPointsViaList(List<Point> points)
        {
            if (points.Count != definingPointsCount)
            {
                while (points.Count != definingPointsCount)
                    points.Add(new Point());
            }

            topLeft = points[0];
            botRight = points[1];
        }

        public override UIElement UIEquivalent()
        {
            Ellipse myEllipse = new Ellipse();
            if (botRight.X < topLeft.X)
            {
                botRight.X += topLeft.X;
                topLeft.X = botRight.X - topLeft.X;
                botRight.X -= topLeft.X;
            }

            if (botRight.Y < topLeft.Y)
            {
                botRight.Y += topLeft.Y;
                topLeft.Y = botRight.Y - topLeft.Y;
                botRight.Y -= topLeft.Y;
            }
            myEllipse.Width = botRight.X - topLeft.X;
            myEllipse.Height = botRight.Y - topLeft.Y;
            myEllipse.Fill = this.BrushColor;
            myEllipse.Stroke = this.StrokeColor;

            Canvas.SetLeft(myEllipse, topLeft.X);
            Canvas.SetTop(myEllipse, topLeft.Y);

            return myEllipse;
        }
    }
}
