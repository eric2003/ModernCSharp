using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyCanvasApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush customColor;
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            DrawRect();
        }

        private void DrawRect()
        {
            Console.WriteLine("myCanvas.Width={0}", myCanvas.Width);
            Console.WriteLine("myCanvas.Height={0}", myCanvas.Height);
            

            byte r = (byte)random.Next(1, 255);
            byte g = (byte)random.Next(1, 255);
            byte b = (byte)random.Next(1, 255);
            Color color = Color.FromRgb(r, g, b);
            customColor = new SolidColorBrush(color);

            Rectangle newRectangle = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = customColor,
                StrokeThickness = 3,
                Stroke = Brushes.Black
            };
            Canvas.SetLeft(newRectangle, 0);
            Canvas.SetTop(newRectangle, 0);
            myCanvas.Children.Add(newRectangle);
        }

        private void AddOrRemoveItems(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
            {
                Rectangle activeRectangle = (Rectangle)e.OriginalSource;
                myCanvas.Children.Remove(activeRectangle);
            }
            else
            {
                byte r = (byte)random.Next(1, 255);
                byte g = (byte)random.Next(1, 255);
                byte b = (byte)random.Next(1, 255);
                customColor = new SolidColorBrush(Color.FromRgb(r,g,b));
                Rectangle newRectangle = new Rectangle
                {
                    Width = 50,
                    Height = 50,
                    Fill = customColor,
                    StrokeThickness = 3,
                    Stroke = Brushes.Black
                };
                Canvas.SetLeft(newRectangle, Mouse.GetPosition(myCanvas).X);
                Canvas.SetTop(newRectangle, Mouse.GetPosition(myCanvas).Y);
                myCanvas.Children.Add(newRectangle);
            }
        }
    }
}