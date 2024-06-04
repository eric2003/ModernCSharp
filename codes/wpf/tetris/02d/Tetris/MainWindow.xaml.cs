using System;
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
//using static System.Net.Mime.MediaTypeNames;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Asset/TileEmpty.png",UriKind.Relative)),
            new BitmapImage(new Uri("Asset/TileCyan.png",UriKind.Relative)),
            new BitmapImage(new Uri("Asset/TileBlue.png",UriKind.Relative)),
            new BitmapImage(new Uri("Asset/TileOrange.png",UriKind.Relative)),
            new BitmapImage(new Uri("Asset/TileYellow.png",UriKind.Relative)),
            new BitmapImage(new Uri("Asset/TileGreen.png",UriKind.Relative)),
            new BitmapImage(new Uri("Asset/TilePurple.png",UriKind.Relative)),
            new BitmapImage(new Uri("Asset/TileRed.png",UriKind.Relative))
        };

        private readonly ImageSource[] blockImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png",UriKind.Relative))
        };

        private readonly Image[,] imageControls;

        private GameState gameState = new GameState();
        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.GameGrid);
            //DrawImage();
        }

        private void DrawImage()
        {
            Image image = new Image();
            //image.Source = new BitmapImage(new Uri($"Assets/Body.png", UriKind.Relative));
            image.Source = new BitmapImage(new Uri("Assets/Body.png", UriKind.Relative));
            image.Width = 20;
            image.Height = 20;

            // 将Image控件添加到WPF窗口中
            this.Content = image;
            MessageBox.Show("Hello, World!", "Message Box Title", MessageBoxButton.OK, MessageBoxImage.Information);
            Console.WriteLine("haha!");
        }

        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };
                    Canvas.SetTop(imageControl, (r - 2) * cellSize);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }
            return imageControls;
        }

        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    imageControls[r,c].Source = tileImages[id];
                }
            }
        }

        private void DrawBlock(Block block)
        {
            foreach(Position p in block.TilePositions())
            {
                imageControls[p.Row,p.Column].Source = tileImages[block.Id];
            }
        }

        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawBlock(gameState.CurrentBlock);
        }

        private async Task GameLoop()
        {
            Draw(gameState);
            while (!gameState.GameOver)
            {
                await Task.Delay(500);
                gameState.MoveBlockDown();
                Draw(gameState);
            }
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(gameState.GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Key.Right:
                    gameState.MoveBlockRight();
                    break;
                case Key.Down:
                    gameState.MoveBlockDown();
                    break;
                case Key.Up:
                    gameState.RotateBlockCW();
                    break;
                case Key.Z:
                    gameState.RotateBlockCCW();
                    break;
                default:
                    return;
            }
            Draw(gameState);
        }
        //private async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        //private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Console.WriteLine("GameCanvas_Loaded!");
        //    //await GameLoop();
        //    //Draw(gameState);
        //}
        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            ;
        }

        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("GameCanvas_Loaded!");
            // 在Canvas加载完成后执行初始化操作
            Canvas canvas = sender as Canvas;

            // 添加一个矩形到Canvas中
            Rectangle rect = new Rectangle();
            rect.Width = 100;
            rect.Height = 50;
            rect.Fill = Brushes.Blue;

            canvas.Children.Add(rect);

            Image image1 = new Image
            {
                Width = 20,
                Height = 20,
                Source = new BitmapImage(new Uri("Assets/Body.png", UriKind.Relative))
            };
            Image image2 = new Image
            {
                Width = 20,
                Height = 20,
                Source = new BitmapImage(new Uri("Assets/Body.png", UriKind.Relative))
            };

            Canvas.SetTop(image1, 200);
            Canvas.SetLeft(image1, 100);
            canvas.Children.Add(image1);

            Canvas.SetTop(image2, 300);
            Canvas.SetLeft(image2, 100);
            canvas.Children.Add(image2);

        }
    }
}