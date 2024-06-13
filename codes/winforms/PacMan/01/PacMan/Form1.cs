using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X,
            O
        }

        Player currentPlayer;
        Player previousPlayer;
        Random random = new Random();
        int playerWinCount = 0;
        int CPUWinCount = 0;
        int flag = -1;
        List<Button> buttons;

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        public Form1()
        {
            InitializeComponent();
        }

    }
}
