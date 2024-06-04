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
//using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly static ImageSource Body = LoadImage("Body.png");
        public MainWindow()
        {
            InitializeComponent();
            //this.Background = new SolidColorBrush(Colors.Red);
            DrawImage();
        }

        private void DrawImage()
        {
            //this.Background = new SolidColorBrush(Colors.Red);
            Image image = new Image();
            image.Source = Body;
            image.Width = 100;
            image.Height = 100;
            image.Visibility = Visibility.Visible;

            // 将Image控件添加到WPF窗口中
            this.Content = image;
            this.Visibility = Visibility.Visible;
        }
        private static ImageSource LoadImage(string fileName)
        {
            return new BitmapImage(new Uri($"Assets/{fileName}", UriKind.Relative));
        }
    }



}