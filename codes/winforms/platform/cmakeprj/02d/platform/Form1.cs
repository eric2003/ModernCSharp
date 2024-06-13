using System;
using System.Windows.Forms;

namespace platform
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, jumping, isGameOver;

        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 10;

        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                this.goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.goRight = true;
            }

            if ((e.KeyCode == Keys.Space) && this.jumping == false)
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

            if ( this.jumping )
            {
                this.jumping = false;
            }

            if ((e.KeyCode == Keys.Enter) && this.isGameOver)
            {
                this.RestartGame();
            }
        }

        private void MainGameTimeEvent(object sender, EventArgs e)
        {
            this.txtScore.Text = "Score: " + this.score;
            this.player.Top += this.jumpSpeed;

            if (this.goLeft)
            {
                this.player.Left -= this.playerSpeed;
            }

            if (this.goRight)
            {
                this.player.Left += this.playerSpeed;
            }

            if (this.jumping && this.force < 0)
            {
                this.jumping = false;
            }

            if (this.jumping)
            {
                this.jumpSpeed = -8;
                this.force -= 1;
            }
            else
            {
                this.jumpSpeed = 10;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.force = 8;
                            this.player.Top = x.Top - this.player.Height;
                            if ((string)x.Name == "horizontalPlatform" && !goLeft ||
                                (string)x.Name == "horizontalPlatform" && !goRight )
                            {
                                this.player.Left -= this.horizontalSpeed;
                            }
                        }
                        x.BringToFront();
                    }

                    if ((string)x.Tag == "coin" && x.Visible)
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            x.Visible = false;
                            this.score++;
                        }
                    }


                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.gameTimer.Stop();
                            this.isGameOver = true;
                            this.txtScore.Text = "Score: " + this.score + Environment.NewLine
                                + "YOu were killed in your journey!!";
                        }
                    }
                }
            }

            this.horizontalPlatform.Left -= this.horizontalSpeed;
            if (this.horizontalPlatform.Left < 0 || this.horizontalPlatform.Left + this.horizontalPlatform.Width > this.ClientSize.Width)
            {
                this.horizontalSpeed = -this.horizontalSpeed;
            }

            this.verticalPlatform.Top += this.verticalSpeed;
            if (this.verticalPlatform.Top < 195 || this.verticalPlatform.Top > 581)
            {
                this.verticalSpeed = -this.verticalSpeed;
            }

            this.enemyOne.Left -= this.enemyOneSpeed;
            if (this.enemyOne.Left < this.pictureBox5.Left ||
                this.enemyOne.Left + this.enemyOne.Width > this.pictureBox5.Left + this.pictureBox5.Width)
            {
                this.enemyOneSpeed = -this.enemyOneSpeed;
            }

            this.enemyTwo.Left -= this.enemyTwoSpeed;
            if (this.enemyTwo.Left < this.pictureBox2.Left ||
                this.enemyTwo.Left + this.enemyTwo.Width > this.pictureBox2.Left + this.pictureBox2.Width)
            {
                this.enemyTwoSpeed = -this.enemyTwoSpeed;
            }

            if ( this.player.Top + this.player.Height > this.ClientSize.Height + 50 )
            {
                this.gameTimer.Stop();
                this.isGameOver = true;
                this.txtScore.Text = "Score: " + this.score + Environment.NewLine + "You Fell to your death!";
            }

            if( this.player.Bounds.IntersectsWith(door.Bounds) )
            {
                if (this.score == 26)
                {
                    this.gameTimer.Stop();
                    this.isGameOver = true;
                    this.txtScore.Text = "Score: " + this.score + Environment.NewLine + "Your quest is complete!";
                }
                else
                {
                    this.txtScore.Text = "Score: " + this.score + Environment.NewLine + "Collect all the coins!";
                }
            }
        }

        private void RestartGame()
        {
            this.jumping = false;
            this.goLeft = false;
            this.goRight = false;
            this.isGameOver = false;
            this.score = 0;

            this.txtScore.Text = "Score: " + this.score;

            foreach ( Control x in this.Controls )
            {
                if ( x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            // reset the position of player, platform and enemies

            this.player.Left = 72;
            this.player.Top = 656;

            this.enemyOne.Left = 471;
            this.enemyTwo.Left = 360;

            this.horizontalPlatform.Left = 275;
            this.verticalPlatform.Top = 581;

            this.gameTimer.Start();
        }


    }
}
