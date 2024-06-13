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

        }

        private void KeIsDown(object sender, KeyEventArgs e)
        {

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void CloseGame(object sender, FormClosedEventArgs e)
        {

        }
    }
}
