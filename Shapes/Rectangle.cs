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
    public class Rectangle_ : Shape_
    {
        private double area;
        private double perimeter;
        private double topSide, leftSide;
        private Point topLeft = new Point();
        private Point botRight = new Point();
        public const int definingPointsCount = 2;

        public Rectangle_(Point topLeft,
            Point botRight)
        {
            this.topLeft = topLeft;
            this.botRight = botRight;
            this.BrushColor = Brushes.White;
            this.StrokeColor = Brushes.Black;

            topSide = botRight.X - topLeft.X;
            leftSide = botRight.Y - topLeft.Y;

            CalculateProperties();
        }

        public Rectangle_()
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
            perimeter = 2 * topSide + 2 * leftSide;

            area = topSide * leftSide;
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
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = Math.Abs(topLeft.X - botRight.X);
            myRectangle.Height = Math.Abs(topLeft.Y - botRight.Y);

            myRectangle.Fill = this.BrushColor;
            myRectangle.Stroke = this.StrokeColor;
     
            Canvas.SetLeft(myRectangle, topLeft.X);
            Canvas.SetTop(myRectangle, topLeft.Y);

            return myRectangle;
        }
    }
}
