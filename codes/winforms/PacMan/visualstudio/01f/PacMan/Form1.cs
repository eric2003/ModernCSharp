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
            if (e.KeyCode == Keys.Up)
            {
                this.goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                this.goDown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                this.goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.goRight = true;
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                this.goDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                this.goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.goRight = false;
            }
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            this.txtScore.Text = "Score: " + this.score;
            if( this.goLeft)
            {
                this.pacman.Left -= this.playerSpeed;
                this.pacman.Image = Properties.Resources.left;

            }

            if (this.goRight)
            {
                this.pacman.Left += this.playerSpeed;
                this.pacman.Image = Properties.Resources.right;
            }

            if (this.goDown)
            {
                this.pacman.Top += this.playerSpeed;
                this.pacman.Image = Properties.Resources.down;
            }

            if (this.goUp)
            {
                this.pacman.Top -= this.playerSpeed;
                this.pacman.Image = Properties.Resources.Up;
            }
        }
        private void resetGame()
        {
            this.txtScore.Text = "Score: 0";
            score = 0;
            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            this.playerSpeed = 8;
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
                    control.Visible = true;
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
