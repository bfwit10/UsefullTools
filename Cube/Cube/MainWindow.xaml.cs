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
using System.Windows.Media.Media3D;
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

        public void Scrollbar_X_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            angleContent_x.Content = "X - Achse: " + Math.Floor(Scrollbar_X.Value).ToString() + "°";
            Cube.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), Scrollbar_X.Value));
        }

        public void Scrollbar_Y_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            angleContent_y.Content = "Y - Achse: " + Math.Floor(Scrollbar_Y.Value).ToString() + "°";
            Cube.Transform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0,1, 0), Scrollbar_Y.Value));
        }

        private void Viewport3D_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {

            if ((Keyboard.Modifiers == ModifierKeys.Alt))
            {

                if (e.Delta > 0)
                {
                    Viewport3D viewPort = sender as Viewport3D;
                    Point mousePosition = e.GetPosition(viewPort);
                    HitTestResult result = VisualTreeHelper.HitTest(viewPort, mousePosition);
                    ModelVisual3D vYPlus3D = result.VisualHit as ModelVisual3D;
                    RotateTransform3D rotYPlus = (vYPlus3D.Transform as RotateTransform3D);
                    (rotYPlus.Rotation as AxisAngleRotation3D).Angle += 10;
                }

                else if (e.Delta < 0)
                {
                    Viewport3D viewPort = sender as Viewport3D;
                    Point mousePosition = e.GetPosition(viewPort);
                    HitTestResult result = VisualTreeHelper.HitTest(viewPort, mousePosition);
                    ModelVisual3D vYMinus3D = result.VisualHit as ModelVisual3D;
                    RotateTransform3D rotYMinus = (vYMinus3D.Transform as RotateTransform3D);
                    (rotYMinus.Rotation as AxisAngleRotation3D).Angle -= 10;
                }
            }
            else 
            {
                
                if (e.Delta > 0)
                {
                    Scrollbar_X.Value = Scrollbar_X.Value + 10;
                }

                else if (e.Delta < 0)
                {

                    Scrollbar_X.Value = Scrollbar_X.Value - 10;

                }
            }           
        }


        // Methode zur Skalierung des Würfels
        //private void Viewport3D_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    if (Keyboard.Modifiers != ModifierKeys.Control)
        //        return;

        //    if (e.Delta > 0)
        //    {
        //        zoom = new ScaleTransform3D();
        //        ScaleTransform3D.ScaleY + 0.2;
        //        ScaleTransform3D.ScaleY + 0.2;
        //    }
        //    //PerspectiveCamera.Position()

        //    else if (e.Delta < 0)
        //    {
        //        ScaleTransform3D.ScaleXProperty - 0.2;
        //        ScaleTransform3D.ScaleYProperty - 0.2;
        //        ScaleTransform3D.ScaleYProperty - 0.2;
        //    }

        //}
    }
}
