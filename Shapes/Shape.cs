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
    public abstract class Shape_
    {
        public Brush BrushColor { get; set; }
        public Brush StrokeColor { get; set; }
        
        public abstract UIElement UIEquivalent();
        public abstract void SetPointsViaList(List<Point> points);
    }
}
