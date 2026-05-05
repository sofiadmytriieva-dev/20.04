using System;
using System.Windows.Forms;
using System.Drawing;

namespace _13._04._2
{
    public partial class Form1 : Form
    {
        bool turn = true; 
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

       
        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn; 
            b.Enabled = false; 
            turnCount++;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool there_is_a_winner = false;

            
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled)) there_is_a_winner = true;
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled)) there_is_a_winner = true;
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled)) there_is_a_winner = true;

            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled)) there_is_a_winner = true;
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled)) there_is_a_winner = true;
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled)) there_is_a_winner = true;

            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled)) there_is_a_winner = true;
            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button3.Enabled)) there_is_a_winner = true;

            if (there_is_a_winner)
            {
                string winner = "";
                if (turn) winner = "O"; else winner = "X";
                MessageBox.Show("Переміг: " + winner);
                ResetGame();
            }
            else if (turnCount == 9)
            {
                MessageBox.Show("Нічия!");
                ResetGame();
            }
        }

        private void ResetGame()
        {
            turn = true;
            turnCount = 0;
            foreach (Control c in Controls)
            {
                if (c is Button && c.Name != "btnReset")
                {
                    c.Enabled = true;
                    c.Text = "";
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}