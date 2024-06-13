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
            RestartGame();
        }

        private void CPUMove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.DarkSalmon;
                buttons.RemoveAt(index);
                if (CheckGame())
                {
                    //Console.WriteLine("CPUMove CheckGame flag = {0}:", flag);
                    RestartGame();
                }

                CPUTimer.Stop();
            }
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            buttons.Remove(button);
            if (CheckGame())
            {
                RestartGame();
            }
            else
            {
                CPUTimer.Start();
            }
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private bool CheckGame()
        {
            //Console.WriteLine("current player is {0}:", currentPlayer.ToString());
            if (CheckGame(Player.X.ToString()))
            {
                CPUTimer.Stop();
                MessageBox.Show("Player Wins");
                playerWinCount++;
                label1.Text = "Player Wins " + playerWinCount;
                return true;
            }
            else if (CheckGame(Player.O.ToString()))
            {
                CPUTimer.Stop();
                MessageBox.Show("CPU Wins");
                CPUWinCount++;
                label2.Text = "CPU Wins " + CPUWinCount;
                return true;
            }
            return false;
        }

        private bool CheckGame(string p)
        {
            if (button1.Text == p && button2.Text == p && button3.Text == p)
            {
                flag = 1;
                return true;
            }
            if (button4.Text == p && button5.Text == p && button6.Text == p)
            {
                flag = 2;
                return true;
            }
            if (button7.Text == p && button8.Text == p && button9.Text == p)
            {
                flag = 3;
                return true;
            }

            if (button1.Text == p && button4.Text == p && button7.Text == p)
            {
                flag = 4;
                return true;
            }

            if (button2.Text == p && button5.Text == p && button8.Text == p)
            {
                flag = 5;
                return true;
            }

            if (button3.Text == p && button6.Text == p && button9.Text == p)
            {
                flag = 6;
                return true;
            }

            if (button1.Text == p && button5.Text == p && button9.Text == p)
            {
                flag = 7;
                return true;
            }
            if (button3.Text == p && button5.Text == p && button7.Text == p)
            {
                flag = 8;
                return true;
            }

            return false;
        }

        private void RestartGame()
        {
            CPUTimer.Stop();
            buttons = new List<Button>()
            {
                button1, button2, button3,
                button4, button5, button6,
                button7, button8, button9
            };
            foreach (Button button in buttons)
            {
                button.Enabled = true;
                button.Text = "?";
                button.BackColor = DefaultBackColor;
            }
        }
    }
}
