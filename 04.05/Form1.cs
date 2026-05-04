using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using System.IO;

namespace _5
{
    public partial class Form1 : Form
    {
        BindingList<TaskItem> tasks = new BindingList<TaskItem>();
        public Form1()
        {
            InitializeComponent();
            dgvTasks.DataSource = tasks;
            LoadTasks();
        }
        private void SaveTasks()
        {
            string json = JsonConvert.SerializeObject(tasks);
            File.WriteAllText("tasks.json", json);
        }

        private void LoadTasks()
        {
            if (File.Exists("tasks.json"))
            {
                string json = File.ReadAllText("tasks.json");
                var loadedTasks = JsonConvert.DeserializeObject<List<TaskItem>>(json);
                if (loadedTasks != null)
                {
                    tasks.Clear();
                    foreach (var task in loadedTasks) tasks.Add(task);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TaskItem newTask = new TaskItem()
            {
                Title = txtTitle.Text,             
                Description = txtDescription.Text, 
                DueDate = dtpDueDate.Value,  
                Priority = cmbPriority.Text,         
                Status = "Нове"                    
            };

            
            tasks.Add(newTask);

            
            txtTitle.Clear();
            txtDescription.Clear();
            SaveTasks();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var filtered = tasks.Where(t => t.Title.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            dgvTasks.DataSource = new BindingList<TaskItem>(filtered);
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtered = tasks.Where(t => t.Status == cmbFilterStatus.Text).ToList();
            dgvTasks.DataSource = new BindingList<TaskItem>(filtered);
        }

        private void cmbFilterPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtered = tasks.Where(t => t.Priority == cmbFilterPriority.Text).ToList();
            dgvTasks.DataSource = new BindingList<TaskItem>(filtered);
        }

        private void dgvTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTasks.Rows[e.RowIndex].DataBoundItem is TaskItem task)
            {
                
                if (task.DueDate < DateTime.Now && task.Status != "Виконано")
                {
                    
                    dgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                }
                else
                {
                    
                    dgvTasks.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
