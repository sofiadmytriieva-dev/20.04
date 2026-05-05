using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MultiApp
{
    public partial class Form1 : Form
    {
       
        bool isXTurn = true;
        int steps = 0;
        Random rnd = new Random();
        string currentFilePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Тікаюча кнопка
        private void btnRun_MouseEnter(object sender, EventArgs e)
        {
            int maxX = this.ClientSize.Width - btnRun.Width;
            int maxY = this.ClientSize.Height - btnRun.Height;
            btnRun.Location = new Point(rnd.Next(0, maxX), rnd.Next(0, maxY));
        }

        //  2. Хрестики-нолики 
        private void gameTile_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text != "") return;

            btn.Text = isXTurn ? "X" : "O";
            steps++;
            if (CheckWinner())
            {
                MessageBox.Show($"Переміг {(isXTurn ? "X" : "O")}!");
                ResetGrid();
            }
            else if (steps == 9)
            {
                MessageBox.Show("Нічия!");
                ResetGrid();
            }
            isXTurn = !isXTurn;
        }

        private bool CheckWinner()
        {
           
            string[][] wins = {
                new[] { button1.Text, button2.Text, button3.Text },
                new[] { button4.Text, button5.Text, button6.Text },
                new[] { button7.Text, button8.Text, button9.Text },
                new[] { button1.Text, button4.Text, button7.Text },
                new[] { button2.Text, button5.Text, button8.Text },
                new[] { button3.Text, button6.Text, button9.Text },
                new[] { button1.Text, button5.Text, button9.Text },
                new[] { button3.Text, button5.Text, button7.Text }
            };
            return wins.Any(w => w[0] != "" && w[0] == w[1] && w[1] == w[2]);
        }

        private void ResetGrid()
        {
            steps = 0; isXTurn = true;
            foreach (var b in new[] { button1, button2, button3, button4, button5, button6, button7, button8, button9 })
                b.Text = "";
        }

        // 3. Робота з файлом
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog1.FileName;
                rtbContent.Text = File.ReadAllText(currentFilePath);
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    currentFilePath = saveFileDialog1.FileName;
                else return;
            }
            File.WriteAllText(currentFilePath, rtbContent.Text);
            MessageBox.Show("Файл оновлено!");
        }
    }
}