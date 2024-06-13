using System;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Form1 : Form
    {
        bool goUp, goDown, goLeft, goRight;
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
            if (e.KeyCode == Keys.Enter)
            {
                this.resetGame();
            }
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            this.txtScore.Text = "Score: " + this.score;
            if (this.goLeft)
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

            if (this.pacman.Left < 0)
            {
                this.pacman.Left = 820;
            }

            if (this.pacman.Left > 820)
            {
                this.pacman.Left = 0;
            }

            if (this.pacman.Top < 0)
            {
                this.pacman.Top = 710;
            }

            if (this.pacman.Top > 710)
            {
                this.pacman.Top = 0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "coin" && x.Visible)
                    {
                        if (this.pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.score += 1;
                            x.Visible = false;
                        }
                    }

                    if ((string)x.Tag == "wall")
                    {
                        if (this.pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            //game over
                            this.gameOver("You Lose!");
                        }

                        if (this.pinkGhost.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.pinkGhostX = -this.pinkGhostX;
                        }
                    }

                    if ((string)x.Tag == "ghost")
                    {
                        if (this.pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            //game over
                            this.gameOver("You Lose!");
                        }
                    }
                }
            }

            //moving ghost
            this.redGhost.Left += this.redGhostSpeed;
            if (this.redGhost.Bounds.IntersectsWith(pictureBox1.Bounds) ||
                this.redGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                this.redGhostSpeed = -this.redGhostSpeed;
            }

            this.yellowGhost.Left += this.yellowGhostSpeed;
            if (this.yellowGhost.Bounds.IntersectsWith(pictureBox3.Bounds) ||
                this.yellowGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                this.yellowGhostSpeed = -this.yellowGhostSpeed;
            }

            this.pinkGhost.Left -= this.pinkGhostX;
            this.pinkGhost.Top -= this.pinkGhostY;

            if (this.pinkGhost.Top < 0 ||
                 this.pinkGhost.Top > 710)
            {
                this.pinkGhostY = -this.pinkGhostY;
            }

            if (this.pinkGhost.Left < 0 ||
                 this.pinkGhost.Left > 820)
            {
                this.pinkGhostX = -this.pinkGhostX;
            }

            if (this.score == 46)
            {
                this.gameOver("You Win!");
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
            pacman.Left = 12;
            pacman.Top = 61;
            redGhost.Left = 236;
            redGhost.Top = 56;
            yellowGhost.Left = 549;
            yellowGhost.Top = 554;
            pinkGhost.Left = 636;
            pinkGhost.Top = 259;

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                    control.Visible = true;
                }
            }

            gameTimer.Start();
        }

        private void gameOver(string message)
        {
            this.isGameOver = true;
            this.gameTimer.Stop();

            this.txtScore.Text = "Score: " + this.score + Environment.NewLine + message;
        }
    }
}
