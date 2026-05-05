using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace _09._04._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                    List<double> prices = new List<double>();

                    
                    foreach (string line in lines)
                    {
                        if (double.TryParse(line.Replace(".", ","), out double price))
                        {
                            prices.Add(price);
                        }
                    }

                    if (prices.Count == 0)
                    {
                        MessageBox.Show("Файл порожній або не містить коректних цін.");
                        return;
                    }

                    
                    double[] pricesArray = prices.ToArray();
                    double sum = pricesArray.Sum();
                    double avg = pricesArray.Average();
                    double max = pricesArray.Max();
                    double min = pricesArray.Min();
                    int expensiveItems = pricesArray.Count(p => p > 100);

                   
                    label1.Text = $"Сума: {sum:F2} грн\n" +
                                  $"Середня: {avg:F2} грн\n" +
                                  $"Макс: {max:F2} грн\n" +
                                  $"Мін: {min:F2} грн\n" +
                                  $"Дорожче 100 грн: {expensiveItems} шт.";

                   
                    File.WriteAllText("результат.txt", label1.Text);
                    MessageBox.Show("Дані оброблено та збережено у 'результат.txt'");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Помилка при роботі з файлом: " + ex.Message);
            }
        }
    }
}
