using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13._04._1
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        
        private void btnRun_MouseEnter(object sender, EventArgs e)
        {
            
            int maxX = this.ClientSize.Width - btnRun.Width;
            int maxY = this.ClientSize.Height - btnRun.Height;

            
            btnRun.Location = new Point(rnd.Next(0, maxX), rnd.Next(0, maxY));
        }
        public Form1()
        {
            InitializeComponent();
        }
    }
}
