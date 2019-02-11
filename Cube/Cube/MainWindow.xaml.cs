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

namespace Cube
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

        private void Scollbar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {           
            angleContent_x.Content = "X - Achse: " + Math.Floor(vScroll.Value).ToString() + "°";
            Cube.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector(1, 0, 0), vScroll.Value));
        }

        private void Scollbar_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            angleContent_y = "Y - Achse: " + Math.Floor(hScroll.Value).ToString() + "°";
            Cube.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), hScroll.Value));
        }
    }
}
