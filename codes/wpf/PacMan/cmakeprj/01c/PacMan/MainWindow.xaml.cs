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
using System.Windows.Threading;

namespace PacMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool goLeft, goRight, goDown, goUp;
        bool noLeft, noRight, noDown, noUp;

        int speed = 8;

        Rect pacmanHitBox;

        int ghostSpeed = 10;
        int ghostMoveStep = 130;
        int currentGhostStep;
        int score = 0;
        public MainWindow()
        {
            InitializeComponent();
            GameSetUp();
        }

        private void CanvasKeyDown(object sender, KeyEventArgs e)
        {
            if ( e.Key == Key.Left && this.noLeft == false )
            {
                this.goRight = this.goUp = this.goDown = false;
                this.noRight = this.noUp = this.noDown = false;
                this.goLeft = true;

                this.pacman.RenderTransform = new RotateTransform(-180, this.pacman.Width/2,this.pacman.Height/2);
            }

            if (e.Key == Key.Right && this.noRight == false)
            {
                this.goLeft = this.goUp = this.goDown = false;
                this.noLeft = this.noUp = this.noDown = false;
                this.goRight = true;

                this.pacman.RenderTransform = new RotateTransform(0, this.pacman.Width / 2, this.pacman.Height / 2);
            }

            if (e.Key == Key.Up && this.noUp == false)
            {
                this.goLeft = this.goRight = this.goDown = false;
                this.noLeft = this.noRight = this.noDown = false;
                this.goUp = true;

                this.pacman.RenderTransform = new RotateTransform(-90, this.pacman.Width / 2, this.pacman.Height / 2);
            }

            if (e.Key == Key.Down && this.noDown == false)
            {
                this.goLeft = this.goRight = this.goUp = false;
                this.noLeft = this.noRight = this.noUp = false;
                this.goDown = true;

                this.pacman.RenderTransform = new RotateTransform(90, this.pacman.Width / 2, this.pacman.Height / 2);
            }

        }

        private void GameSetUp()
        {
            this.MyCanvas.Focus();
            this.gameTimer.Tick += GameLoop;
            this.gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            this.gameTimer.Start();
            ImageBrush pacmanImage = new ImageBrush();
            pacmanImage.ImageSource = new BitmapImage(new Uri($"../../Assets/pacman.jpg", UriKind.Relative));
            this.pacman.Fill = pacmanImage;

            ImageBrush redGhost = new ImageBrush();
            redGhost.ImageSource = new BitmapImage(new Uri($"../../Assets/red.jpg", UriKind.Relative));
            this.redGuy.Fill = redGhost;

            ImageBrush orangeGhost = new ImageBrush();
            orangeGhost.ImageSource = new BitmapImage(new Uri($"../../Assets/orange.jpg", UriKind.Relative));
            this.orangeGuy.Fill = orangeGhost;

            ImageBrush pinkGhost = new ImageBrush();
            pinkGhost.ImageSource = new BitmapImage(new Uri($"../../Assets/pink.jpg", UriKind.Relative));
            this.pinkGuy.Fill = pinkGhost;


        }

        private void GameLoop(object sender, EventArgs e)
        {
            this.txtScore.Content = "Score: " + this.score;

            if ( this.goRight )
            {
                Canvas.SetLeft(this.pacman, Canvas.GetLeft(this.pacman) + speed);
            }
            if (this.goLeft)
            {
                Canvas.SetLeft(this.pacman, Canvas.GetLeft(this.pacman) - speed);
            }
            if (this.goUp)
            {
                Canvas.SetTop(this.pacman, Canvas.GetTop(this.pacman) - speed);
            }
            if (this.goDown)
            {
                Canvas.SetTop(this.pacman, Canvas.GetTop(this.pacman) + speed);
            }
        }

        private void GameOver(string message)
        {
            this.gameTimer.Stop();
            MessageBox.Show(message, "The Pac Man Game");

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

    }
}