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

namespace MyWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawImage();
        }
        private void DrawImage()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri($"Assets/Body.png", UriKind.Relative));

            // 将Image控件添加到WPF窗口中
            this.Content = image;
        }
    }
}