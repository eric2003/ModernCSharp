using System;
using System.Windows.Forms;

namespace TRexRunner
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int jumpSpeed = 12;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 10;
        Random random = new Random();
        int position;
        bool isGameOver = false;

        public Form1()
        {
            InitializeComponent();
            this.GameReset();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            this.trex.Top += this.jumpSpeed;
            this.txtScore.Text = "Score: " + this.score;

            if ( this.jumping && this.force < 0 )
            {
                this.jumping = false;
            }

            if( this.jumping)
            {
                this.jumpSpeed = -12;
                this.force -= 1;
            }
            else
            {
                this.jumpSpeed = 12;
            }

            if( this.trex.Top >366 && !this.jumping)
            {
                this.force = 12;
                this.trex.Top = 367;
                this.jumpSpeed = 0;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !this.jumping )
            {
                this.jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (this.jumping)
            {
                this.jumping = false;
            }

            if (e.KeyCode == Keys.R && this.isGameOver)
            {
                this.GameReset();
            }
        }

        private void GameReset()
        {
            this.jumping = false;
            this.jumpSpeed = 0;
            this.force = 12;
            this.score = 0;
            this.obstacleSpeed = 10;
            this.isGameOver = false;
            this.txtScore.Text = "SCore: " + this.score;
            this.trex.Image = Properties.Resources.running;
            this.trex.Top = 367;

            foreach (Control x in this.Controls )
            {
                if( x is PictureBox && (string)x.Tag == "obstacle" )
                {
                    this.position = this.ClientSize.Width + random.Next(500,800) + ( x.Width * 10 );
                    x.Left = this.position;
                }
            }
            this.gameTimer.Start();

        }
    }
}
