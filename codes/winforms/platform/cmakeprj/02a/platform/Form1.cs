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
        int playerSpeed = 7;

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

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void MainGameTimeEvent(object sender, EventArgs e)
        {

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
        }


    }
}
