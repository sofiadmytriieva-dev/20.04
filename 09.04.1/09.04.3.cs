using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _09._04._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string login = txtLogin.Text.Trim();
                string password = txtPassword.Text;

              
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Введіть ім'я!");
                }
                else if (login.Length < 5)
                {
                    MessageBox.Show("Логін занадто короткий (мін. 5 симв.)!");
                }
                else if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
                {
                    MessageBox.Show("Пароль має містити цифру та велику літеру!");
                }
                else if (!int.TryParse(txtAge.Text, out int age) || age < 10)
                {
                    MessageBox.Show("Вік має бути числом від 10 років!");
                }
                else
                {
                    
                    string data = $"Ім'я: {name}, Логін: {login}, Вік: {age}\n";
                    File.AppendAllText("users.txt", data);
                    MessageBox.Show("Користувача збережено!");

                    
                    txtName.Clear(); txtLogin.Clear(); txtPassword.Clear(); txtAge.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("users.txt"))
                {
                    rtbUsers.Text = File.ReadAllText("users.txt");
                }
                else
                {
                    MessageBox.Show("Файл ще не створено!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка читання: " + ex.Message);
            }
        }
    }
}