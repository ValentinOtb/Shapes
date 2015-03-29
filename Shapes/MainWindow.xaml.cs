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
using ColorBox;

namespace Shapes
{
    public partial class MainWindow : Window
    {
        private List<Point> enteredPoints = new List<Point>();
        private int pointsToDefineCount;
        private Shape_ currentDrawingShape;
        private Button activeButton;
        private Brush restoreColor;
        private Brush currentPickColor = Brushes.White;

        public MainWindow()
        {
            
        }

        void Palette_ColorChanged(object sender, ColorChangedEventArgs e)
        {
            currentPickColor = ((Palette)sender).Brush;
        }

        private void ActivateButton(Button button)
        {
            if (activeButton != null)
            {
                activeButton.Background = restoreColor;
            }
            activeButton = button;
            restoreColor = button.Background;
            activeButton.Background = Brushes.SkyBlue;
        }

        private void DeactivateButton()
        {
            if (activeButton != null)
                activeButton.Background = restoreColor;

            activeButton = null;
        }

        private void myCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            currentDrawingShape = null;
            enteredPoints = new List<Point>();
            DeactivateButton();
        }

        private void Circle_Click(object sender, RoutedEventArgs e)
        {
            currentDrawingShape = new Circle_();
            currentDrawingShape.BrushColor = Brushes.Tomato;
            pointsToDefineCount = Circle_.definingPointsCount;
            enteredPoints = new List<Point>();

            ActivateButton(Circle);
        }

        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            currentDrawingShape = new Ellipse_();
            currentDrawingShape.BrushColor = Brushes.Tomato;
            pointsToDefineCount = Ellipse_.definingPointsCount;
            enteredPoints = new List<Point>();
            ActivateButton(Ellipse);
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            currentDrawingShape = new Line_();
            currentDrawingShape.BrushColor = Brushes.DarkMagenta;
            pointsToDefineCount = Line_.definingPointsCount;
            enteredPoints = new List<Point>();
            ActivateButton(Line);
        }

        private void Pentagon_Click(object sender, RoutedEventArgs e)
        {
            currentDrawingShape = new Pentagon_();
            currentDrawingShape.BrushColor = Brushes.DarkMagenta;
            pointsToDefineCount = Pentagon_.definingPointsCount;
            enteredPoints = new List<Point>();
            ActivateButton(Pentagon);
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            currentDrawingShape = new Rectangle_();
            currentDrawingShape.BrushColor = Brushes.DarkMagenta;
            pointsToDefineCount = Rectangle_.definingPointsCount;
            enteredPoints = new List<Point>();
            ActivateButton(Rectangle);
        }

        private void Rhombus_Click(object sender, RoutedEventArgs e)
        {
            currentDrawingShape = new Rhombus_();
            currentDrawingShape.BrushColor = Brushes.DarkMagenta;
            pointsToDefineCount = Rhombus_.definingPointsCount;
            enteredPoints = new List<Point>();
            ActivateButton(Rhombus);
        }

        private void Triangle_Click(object sender, RoutedEventArgs e)
        {
            currentDrawingShape = new Triangle_();
            currentDrawingShape.BrushColor = Brushes.DarkMagenta;
            pointsToDefineCount = Triangle_.definingPointsCount;
            enteredPoints = new List<Point>();
            ActivateButton(Triangle);
        }

        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currentDrawingShape == null)
                return;

            enteredPoints.Add(new Point(e.GetPosition(myCanvas).X, e.GetPosition(myCanvas).Y));

            if (enteredPoints.Count == pointsToDefineCount)
            {
                currentDrawingShape.SetPointsViaList(enteredPoints);
                currentDrawingShape.BrushColor = currentPickColor;
                myCanvas.Children.Add(currentDrawingShape.UIEquivalent());
                enteredPoints = new List<Point>();
            }
        }
    }
}
