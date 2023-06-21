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
    public partial class CreateDoner : Form
    {
        private SaveInfo saveinfo;
        public CreateDoner()
        {
            InitializeComponent();
            saveinfo = new SaveInfo(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            StartMenu menu = new StartMenu();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveinfo.button2_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveinfo.button3_Click(sender, e);
        }

        private void CreateDoner_Load(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString();
        }
    }
}
