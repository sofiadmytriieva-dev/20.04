using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace _09._04._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string wordToFind = txtSearchWord.Text.Trim();

            
            if (string.IsNullOrWhiteSpace(wordToFind))
            {
                MessageBox.Show("Будь ласка, введіть слово для пошуку!");
                return;
            }

            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    
                    string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                    int count = 0;
                    lstLines.Items.Clear(); 

                    
                    for (int i = 0; i < lines.Length; i++)
                    {
                        
                        if (lines[i].Contains(wordToFind))
                        {
                            count++;
                            
                            lstLines.Items.Add($"Рядок {i + 1}: {lines[i]}");
                        }
                    }

                    
                    if (count > 0)
                    {
                        lblResult.Text = $"Знайдено! Кількість рядків зі словом: {count}";
                    }
                    else
                    {
                        lblResult.Text = "Слово не знайдено у файлі.";
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Помилка при читанні файлу: " + ex.Message);
                }
            }
        }
    }
}
