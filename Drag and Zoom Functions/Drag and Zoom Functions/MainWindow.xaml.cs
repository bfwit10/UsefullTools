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

namespace Drag_and_Zoom_Functions
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            INIT();
        }
        // FirstPoint um das Bild zu bewegen

        private Point firstPoint = new Point();

        public void INIT()
        {
            imgSource.MouseLeftButtonDown += (ss, ee) =>
                    {
                        firstPoint = ee.GetPosition(this);
                        imgSource.CaptureMouse();
                    };

            imgSource.MouseWheel += (ss, ee) =>
            {
                Matrix mat = imgSource.RenderTransform.Value;
                Point mouse = ee.GetPosition(imgSource);

                if (ee.Delta > 0) mat.ScaleAtPrepend(1.15, 1.15, mouse.X, mouse.Y);
                else mat.ScaleAtPrepend(1 / 1.15, 1 / 1.15, mouse.X, mouse.Y);

                MatrixTransform mtf = new MatrixTransform(mat);
                imgSource.RenderTransform = mtf;
            };

       

            imgSource.MouseMove += (ss, ee) =>
            {
                if (ee.LeftButton == MouseButtonState.Pressed)
                {
                    // Create temp point
                    Point temp = ee.GetPosition(this);
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                    // Update image Location
                    Canvas.SetLeft(imgSource, Canvas.GetLeft(imgSource) - res.X);
                    Canvas.SetTop(imgSource, Canvas.GetTop(imgSource) - res.Y);

                    // Update image Location
                    firstPoint = temp;
                }
            };

            imgSource.MouseUp += (ss, ee) => { imgSource.ReleaseMouseCapture(); };

        }
    }
}
