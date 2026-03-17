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
            isX = true;

            for (int column = 0; column< boardSize; column++)
            {
                for(int row = 0; row < boardSize; row++)
                {
                    Button b = new Button();

                    b.Size = new Size(fieldSize, fieldSize);
                    b.Location = new Point(column * fieldSize, row * fieldSize);

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
                }
            }
        }
    }
}
