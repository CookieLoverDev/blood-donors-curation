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
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateDoner Doner = new CreateDoner();
            Doner.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Records records = new Records();
            records.ShowDialog();
        }

    }
}
