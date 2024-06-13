namespace PacMan
{
    public partial class Form1 : Form
    {
        bool goUp,goDown,goLeft,goRight;
        bool isGameOver;
        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY;
        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {

        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void mainGameTimer(object sender, EventArgs e)
        {

        }
        private void resetGame()
        {
            this.txtScore.Text = "Score: 0";
            score = 0;
            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            pacman.Left = 31;
            pacman.Top = 46;
            redGhost.Left = 236;
            redGhost.Top = 56;
            yellowGhost.Left = 549;
            yellowGhost.Top = 554;
            pinkGhost.Left = 636;
            pinkGhost.Top = 259;

            foreach(Control control in this.Controls)
            {
                if(control is PictureBox)
                {
                    //control.Visible = true;
                }
            }

            gameTimer.Start();
        }

        private void gameOver(string message)
        {
            ;
        }
    }
}
