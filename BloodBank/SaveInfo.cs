using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    internal class SaveInfo
    {
        private string imagePath;
        private string all;
        private CreateDoner form2;
        public SaveInfo(CreateDoner form)
        {
            form2 = form;
        }
        public void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                form2.pictureBox1.ImageLocation = imagePath;
            }

        }
        public void button2_Click(object sender, EventArgs e)
        {
            {
                Random random = new Random();
                int ID = random.Next(10000, 99999);
                string name = form2.textBox1.Text;
                string surname = form2.textBox2.Text;
                string socialID = form2.textBox5.Text;
                string phoneNumber = form2.textBox3.Text;
                string email = form2.textBox4.Text;
                string blood = form2.comboBox1.Text;
                string imagePath = form2.pictureBox1.ImageLocation;

                if (string.IsNullOrEmpty(imagePath))
                {
                    imagePath = @"Default Image\avatar.jpg";
                }
                string imageName = Path.GetFileName(imagePath);
                string destinationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imageName);
                File.Copy(imagePath, destinationPath, true);
                MessageBox.Show("Everything saved successfully!");
                string[] shortenPath = destinationPath.Split('\\');
                string sP = shortenPath[shortenPath.Length - 1];
                imagePath = sP;
                string data = $"{ID};{name};{surname};{socialID};{phoneNumber};{email};{blood};{imagePath}";
                FileStream fs;
                StreamWriter sw;
                fs = new FileStream("data.txt", FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(data);
                sw.Close();
                fs.Close();
                ClearEasy();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            form2.label9.Text = DateTime.Now.ToString();
        }
        public void ClearEasy()
        {
            form2.textBox1.Text = string.Empty;
            form2.textBox2.Text = string.Empty;
            form2.textBox3.Text = string.Empty;
            form2.textBox4.Text = string.Empty;
            form2.textBox5.Text = string.Empty;
            form2.comboBox1.Text = string.Empty;
            string path = "avatar.jpg";
            form2.pictureBox1.Image = System.Drawing.Image.FromFile(path);
            form2.label9.Text = DateTime.Now.ToString();
        }
    }
}
