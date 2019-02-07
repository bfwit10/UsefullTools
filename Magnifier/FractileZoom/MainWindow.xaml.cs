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

namespace FractileZoom
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private double _factor = 0.5;

        private void ContentPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Point center = e.GetPosition(ContentPanel);
            double length = MagnifierCircle.ActualWidth * _factor;
            // mit einem Plus bzw einem deutlich geringerem wert und einem nicht anzeigen eines Kreises
            // kann der Welleneffekt optisch realisiert werden = reine Umsetzung der Sinne
            double radius = length / 2;
            Rect viewboxRect = new Rect(center.X - radius, center.Y - radius, length, length);
            MagnifierBrush.Viewbox = viewboxRect;

            MagnifierCircle.SetValue(Canvas.LeftProperty, center.X - (MagnifierCircle.ActualWidth / 2));
            MagnifierCircle.SetValue(Canvas.TopProperty, center.Y - (MagnifierCircle.ActualHeight / 2));


            // Rechteckversion 1.01 CreativeRyu

            // MagnifierRectangle
            // MagnifierBrushRectangle

            //Point center = e.GetPosition(ContentPanel);
            //double lenght = MagnifierRectangle.ActualWidth * _factor;
            //double height = MagnifierRectangle.ActualHeight * _factor;
            //Rect viewboxRect = new Rect(center.X - lenght, center.Y - height, lenght, lenght);
            //MagnifierBrushRectangle.Viewbox = viewboxRect;

        }

        private void ContentPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            MagnifierCircle.Visibility = Visibility.Visible;
            Mouse.OverrideCursor = Cursors.None;
            // MagnifierRectangle.Visibility = Visibility.Visible;
        }

        private void ContentPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            MagnifierCircle.Visibility = Visibility.Hidden;
            Mouse.OverrideCursor = Cursors.Arrow;
            // MagnifierRectangle.Visibility = Visibility.Hidden;

        }

    //    private void MagnifierBtn_1_MouseEnter(object sender, MouseEventArgs e)
    //    {
    //        // MagnifierBtn_1.Visibility = Visibility.Visible;
    //    }
    }
}
