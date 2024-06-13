using System;
using System.Windows.Forms;

namespace platform
{
    public partial class olayer : Form
    {
        int goLeft, goRight, jumping, isGameOver;

        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;

        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        public olayer()
        {
            InitializeComponent();
        }
    }
}
