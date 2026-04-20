using System;
using System.Drawing;
using System.Windows.Forms;

namespace MinesweeperGame2
{
    public partial class Form1 : Form
    {
        // Налаштування гри
        int size = 10;        
        int minesCount = 10;  
        int cellSize = 35;    

        Button[,] buttons;    
        bool[,] mines;        
        bool isGameOver = false;

        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            buttons = new Button[size, size];
            mines = new bool[size, size];
            this.ClientSize = new Size(size * cellSize, size * cellSize); 

            Random rnd = new Random();

            //  Створюємо сітку кнопок
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(cellSize, cellSize);
                    btn.Location = new Point(x * cellSize, y * cellSize);
                    btn.Tag = new Point(x, y); // Зберігаємо координати в кнопці
                    btn.MouseDown += Button_MouseDown; // Додаємо подію кліку

                    buttons[x, y] = btn;
                    this.Controls.Add(btn);
                }
            }

            //  Розставляємо міни
            int planted = 0;
            while (planted < minesCount)
            {
                int rx = rnd.Next(size);
                int ry = rnd.Next(size);
                if (!mines[rx, ry])
                {
                    mines[rx, ry] = true;
                    planted++;
                }
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (isGameOver) return;
            Button clicked = (Button)sender;
            Point pos = (Point)clicked.Tag;

            // Правий клік — прапорець
            if (e.Button == MouseButtons.Right)
            {
                clicked.Text = (clicked.Text == "🚩") ? "" : "🚩";
            }
            // Лівий клік — відкрити клітинку
            else if (e.Button == MouseButtons.Left)
            {
                if (mines[pos.X, pos.Y])
                {
                    Explode();
                }
                else
                {
                    OpenCell(pos.X, pos.Y);
                    CheckWin();
                }
            }
        }

        private void OpenCell(int x, int y)
        {
            
            if (x < 0 || x >= size || y < 0 || y >= size || !buttons[x, y].Enabled) return;

            buttons[x, y].Enabled = false; 
            buttons[x, y].BackColor = Color.White;

            int count = CountMinesAround(x, y);
            if (count > 0)
            {
                buttons[x, y].Text = count.ToString();
            }
            else
            {
                // Якщо мін поруч немає — відкриваємо сусідні автоматично (рекурсія)
                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                        OpenCell(x + i, y + j);
            }
        }

        private int CountMinesAround(int x, int y)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    int nx = x + i, ny = y + j;
                    if (nx >= 0 && nx < size && ny >= 0 && ny < size && mines[nx, ny])
                        count++;
                }
            return count;
        }

        private void Explode()
        {
            isGameOver = true;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (mines[x, y]) buttons[x, y].Text = "💣";

            MessageBox.Show("БАБАХ! Ви програли.");
            Application.Restart(); 
        }

        private void CheckWin()
        {
            int closed = 0;
            foreach (var b in buttons) if (b.Enabled) closed++;
            if (closed == minesCount)
            {
                isGameOver = true;
                MessageBox.Show("Вітаємо! Ви розмінували все поле.");
                Application.Restart();
            }
        }
    }
}