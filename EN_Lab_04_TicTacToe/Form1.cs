using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EN_Lab_04_TicTacToe
{
    public partial class Form1 : Form
    {
        private const int boardSize = 3;
        private const int fieldSize = 150;
        private Button[,] board;
        private bool isX;

        public Form1()
        {
            InitializeComponent();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            PrepareNewGame();
        }

        private void PrepareNewGame()
        {
            board = new Button[boardSize, boardSize];
            isX = true;

            for (int column = 0; column < boardSize; column++)
            {
                for (int row = 0; row < boardSize; row++)
                {
                    Button b = new Button();

                    b.Size = new Size(fieldSize, fieldSize);
                    b.Location = new Point(column * fieldSize, row * fieldSize);

                    board[row, column] = b;

                    b.Click += B_Click;

                    this.Controls.Add(b);
                }
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button b = (sender as Button);
                if (b.Text == "")
                {
                    b.Text = (isX ? "X" : "O");
                    isX = !isX;

                    if (isWinner(b.Text))
                    {
                        MessageBox.Show($"The Winner is {b.Text}!");
                        return;
                    }

                    int count = 0;
                    foreach (Button tmp in this.Controls)
                    {
                        if (tmp.Text != "")
                        {
                            count++;
                        }
                    }

                    if (count == boardSize * boardSize)
                    {
                        MessageBox.Show($"The End Game without Winner!");
                        return;
                    }
                }
            }
        }

        private bool isWinner(string player)
        {
            //check columns
            for (int column = 0; column < boardSize; column++)
            {
                int count = 0;
                for (int row = 0; row < boardSize; row++)
                {
                    if (board[row, column].Text == player)
                    {
                        count++;
                    }
                }
                if (count == boardSize)
                {
                    return true;
                }
            }
            //check rows
            for (int row = 0; row < boardSize; row++)
            {
                int count = 0;
                for (int column = 0; column < boardSize; column++)
                {
                    if (board[row, column].Text == player)
                    {
                        count++;
                    }
                }
                if (count == boardSize)
                {
                    return true;
                }
            }
            //check main/primary diagonal
            {
                int count = 0;
                for (int n = 0; n < boardSize; n++)
                {
                    if (board[n, n].Text == player)
                    {
                        count++;
                    }
                }
                if (count == boardSize)
                {
                    return true;
                }
            }
            //check reverse/secondary diagonal
            {
                int count = 0;
                for (int n = 0; n < boardSize; n++)
                {
                    if (board[n, boardSize - 1 - n].Text == player)
                    {
                        count++;
                    }
                }
                if (count == boardSize)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
