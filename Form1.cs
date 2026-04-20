using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        {
      
        private List<string> memePaths = new List<string>
        {
            "memes/1.jpg",
            "memes/2.jpg",
            "memes/3.jpg",
            "memes/4.jpg",
            "memes/5.jpg"
        };

        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            picMeme.SizeMode = PictureBoxSizeMode.Zoom;
            if (!Directory.Exists("meme"))
            {
                Directory.CreateDirectory("meme");
                MessageBox.Show("Папка 'meme' була створена. Будь ласка, покладіть туди файли 1.jpg, 2.jpg і т.д.");
            }
            UpdateMeme();
        }

        private void UpdateMeme()
        {
            if (memePaths.Count > 0)
            {

                string currentPath = memePaths[currentIndex];

                if (File.Exists(currentPath))
                {
                    
                    if (picMeme.Image != null) picMeme.Image.Dispose();

                    
                    picMeme.Image = Image.FromFile(currentPath);
                    this.Text = $"Галерея мемів - {currentIndex + 1} із {memePaths.Count}";
                }
                else
                {
                   
                    this.Text = "Файл не знайдено!";
                }

            }
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0) 
            {
                currentIndex = memePaths.Count - 1;
            }
            UpdateMeme();
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            currentIndex++;
            if (currentIndex >= memePaths.Count)
            {
                currentIndex = 0;
            }
            UpdateMeme();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

