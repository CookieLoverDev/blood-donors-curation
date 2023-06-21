using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    public partial class Records : Form
    {
        Button btn;
        public Records()
        {
            btn = new Button();
            btn.Text = "Delete";
            btn.Font = new Font("Arial", 26);
            btn.Height = 50;
            btn.Width = 150;
            btn.Location = new Point(20, 607);
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.White;
            btn.Click += DeleteButton;
            this.Controls.Add(btn);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            StartMenu menu = new StartMenu();
            menu.Show();
        }

        private void Records_Load(object sender, EventArgs e)
        {
            DonarInfoClass.CreateGroupBox(this, btn);
        }

        private void DeleteButton(object sender, EventArgs e)
        {
            DonarInfoClass.DeleteDonar(btn);
        }
    }
}
