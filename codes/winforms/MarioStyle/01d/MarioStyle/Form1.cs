using System;
using System.Windows.Forms;

namespace MarioStyle
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, jumping, hasKey;

        int jumpSpeed = 10;
        int force = 8;
        int score = 0;

        int playerSpeed = 10;
        int backgroundSpeed = 8;

        public Form1()
        {
            InitializeComponent();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            this.txtScore.Text = "Score: " + this.score;

            this.player.Top += this.jumpSpeed;
            if (this.goLeft && this.player.Left > 60)
            {
                this.player.Left -= this.playerSpeed;
            }

            if (this.goRight && ( this.player.Left + this.player.Width + 60 ) < this.ClientSize.Width )
            {
                this.player.Left += this.playerSpeed;
            }

            if ( this.goLeft && this.background.Left < 0 )
            {
                this.background.Left += this.backgroundSpeed;
                this.MoveGameElements("forward");
            }

            if (this.goRight && this.background.Left > -1372 )
            {
                this.background.Left -= this.backgroundSpeed;
                this.MoveGameElements("back");
            }

            if (this.jumping)
            {
                this.jumpSpeed = -12;
                this.force -= 1;
            }
            else
            {
                this.jumpSpeed = 12;
            }

            if (this.jumping && this.force < 0)
            {
                this.jumping = false;
            }

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox &&(string)x.Tag =="platform")
                {
                    if ( this.player.Bounds.IntersectsWith(x.Bounds) && !this.jumping )
                    {
                        this.force = 8;
                        this.player.Top = x.Top - this.player.Height;
                        this.jumpSpeed = 0;
                    }
                    x.BringToFront();
                }

                if (x is PictureBox && (string)x.Tag == "coin")
                {
                    if (this.player.Bounds.IntersectsWith(x.Bounds) && x.Visible)
                    {
                        x.Visible = false;
                        this.score += 1;
                    }
                }
            }

            if (this.player.Bounds.IntersectsWith(this.key.Bounds) && this.key.Visible )
            {
                this.key.Visible = false;
                this.hasKey = true;
            }

            if (this.player.Bounds.IntersectsWith(this.key.Bounds) && this.hasKey)
            {
                this.door.Image = MarioStyle.Properties.Resources.door_open;
                this.gameTimer.Stop();
                MessageBox.Show("Well done, your jouney is complete!" +
                    Environment.NewLine + "Click OK to play again!");
                this.RestartGame();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left )
            {
                this.goLeft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                this.goRight = true;
            }

            if (e.KeyCode == Keys.Space && !this.jumping)
            {
                this.jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                this.goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                this.goRight = false;
            }

            if (this.jumping)
            {
                this.jumping = false;
            }

        }

        private void CloseGame(object sender, FormClosedEventArgs e)
        {

        }

        private void RestartGame()
        {
        }

        private void MoveGameElements(string direction)
        {
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                     if( (string)x.Tag == "platform" ||
                         (string)x.Tag == "coin" ||
                         (string)x.Tag == "key" ||
                         (string)x.Tag == "door" )
                    {
                        if (direction == "back")
                        {
                            x.Left -= this.backgroundSpeed;
                        }

                        if (direction == "forward")
                        {
                            x.Left += this.backgroundSpeed;
                        }
                    }


                }
            };
        }
    }
}
