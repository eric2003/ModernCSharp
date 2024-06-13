using System;
using System.Windows.Forms;

namespace BalloonPop
{
    public partial class Form1 : Form
    {
        int speed = 5; // this integer holds the value 5
        int score = 0; // this integer holds the value 0
        Random rand = new Random(); // this will create a new instance of the random class called rand
        bool gameOver = false; // this Boolean will be used to check if the game is over or not

        public Form1()
        {
            InitializeComponent();
            resetGame(); // invoke the reset game function. 
        }

        private void popBalloon(object sender, EventArgs e)
        {
            // is game over is false
            if (gameOver == false)
            {
                // then do the follow
                var baloon = (PictureBox)sender; // verify the picture box that sends the event
                baloon.Top = rand.Next(700, 1000); // change the top on a random location between 700 and 1000 pixels
                baloon.Left = rand.Next(5, 500); // change the left on a random location between 5 to 400 pixels
                score++; // increase the score by 1
            }
        }

        private void popBomb(object sender, EventArgs e)
        {
            // this event will trigger when the bomb picture box is clicked in the game
            // if game over is false
            if (gameOver == false)
            {
                // then do the following
                bomb.Image = Properties.Resources.boom; // change the picture to the boom picture
                gameTimer.Stop(); // stop the timer
                label1.Text += "  Game Over! -  Press Enter to retry"; // show game over text on the label
                gameOver = true; // change the game over boolean to true
            }
        }

        private void gameEngine(object sender, EventArgs e)
        {
            label1.Text = "Score: " + score; // show the score on the label
            // below is the for each loop that will check all of the picture boxes in this form
            foreach (Control X in this.Controls)
            {
                if (X is PictureBox)
                {
                    // move the picture boxes to the top
                    // each frame will trigger the picture boxes 5 pixels to the top
                    X.Top -= speed;
                    // if the picture box reaches the top
                    if (X.Top + X.Height < 0)
                    {
                        // the do the following
                        X.Top = rand.Next(700, 1000); // change the top to  random location between 700 to 1000 pixels
                        X.Left = rand.Next(5, 500); // change the left to a random location between 5 to 400 pixels
                    }
                    // if the picture box has a tag of Baloon AND it reaches the top of -50 pixels
                    if ((string)X.Tag == "Balloon" && X.Top < -50)
                    {
                        // then do the following
                        gameTimer.Stop(); // stop the timer
                        label1.Text += "  Game Over! -  Press Enter to retry"; // show game over text on the label
                        gameOver = true; // change the game over boolean to true
                    }
                }
            }
            /**
             * Below is the if statement that will determine when to speed up
             * the balloons in the game. 
             * If the score is EQUALS to or GREATER than 10 then change the speed to 8
             * If the score is EQUALS to or GREATER than 20 then change the speed to 16
             * if the score is EQUALS to or GREATER than 35 then change the speed to 20
             * This will increase the challenge in the game 
             **/
            if (score >= 10)
            {
                speed = 8;
            }
            if (score >= 20)
            {
                speed = 16;
            }
            if (score >= 35)
            {
                speed = 20;
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            // if the player presses enter key and the game is over then we can run the reset function
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                resetGame();
            }
        }

        private void resetGame()
        {
            // below is the for each loop to check for all of the picture boxes in this form
            // once it is found it will randomly assign their places below the the form
            // so it looks like its coming up from bottom to the top
            foreach (Control X in this.Controls)
            {
                if (X is PictureBox)
                {
                    X.Top = rand.Next(700, 1000);
                    // x being the picture box we are changing the the top from anywhere betwene 700 to 1000 pixels
                    X.Left = rand.Next(5, 500);
                    // x being the picture box we are changing the left side from anywhere between 5 to 400 pixles
                }
            }
            // reset the variables for the game
            bomb.Image = Properties.Resources.bomb; // change the picture to the boom picture
            speed = 5; // reset the speed back to 5
            score = 0; // reset the score to 0
            gameOver = false; // change game over to false
            label1.Text = "Score: " + score; // show the score on the label
            gameTimer.Start(); // start the time so the game can begin
        }



    }
}
