using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    public static class DonarInfoClass
    {
        private static Button Bn, Bp;
        private static GroupBox donarsInfo = new GroupBox();
        private static int pageIndex = 0;
        public static List<string> donarsList = new List<string>();

        private static void LoadDonarsFromTxt()
        {
            string filePath = "data.txt";
            string line;
            StreamReader sr = new StreamReader(filePath);

            while ((line = sr.ReadLine()) != null)
            {
                donarsList.Add(line);
            }
            sr.Close();
        }
        public static void CreateGroupBox(Form infoForm, Button btn)
        {
            LoadDonarsFromTxt();

            donarsInfo.Text = "Donars";
            donarsInfo.Font = new Font("Arial", 14);
            donarsInfo.Size = new Size(820, 500);
            donarsInfo.Location = new Point(20, 100);
            donarsInfo.BackColor = Color.LightGray;
            infoForm.Controls.Add(donarsInfo);
            OutputInfo(btn);
        }
        private static void NextPage(Button btn)
        {
            try
            {
                pageIndex++;
                OutputInfo(btn);
            }
            catch
            {
                pageIndex = 0;
                OutputInfo(btn);
            }

        }
        private static void PreviousPage(Button btn)
        {
            try
            {
                pageIndex--;
                OutputInfo(btn);
            }
            catch
            {
                pageIndex = 0;
                OutputInfo(btn);
            }

        }
        private static void ClickNextPage(object sender, EventArgs e)
        {
            NextPage(Bn);
        }
        private static void ClickPreviousPage(object sender, EventArgs e)
        {
            PreviousPage(Bp);
        }
        private static void ButtonCreate(Button btn)
        {
            Bn = new Button();
            Bn.Text = ">>";
            Bn.Font = new Font("Arial", 26);
            Bn.Height = 50;
            Bn.Width = 100;
            Bn.Location = new Point(700, 25);
            Bn.BackColor = Color.Black;
            Bn.ForeColor = Color.White;
            Bn.Click += ClickNextPage;
            donarsInfo.Controls.Add(Bn);

            Bp = new Button();
            Bp.Text = "<<";
            Bp.Font = new Font("Arial", 26);
            Bp.Height = 50;
            Bp.Width = 100;
            Bp.Location = new Point(20, 25);
            Bp.BackColor = Color.Black;
            Bp.ForeColor = Color.White;
            Bp.Click += ClickPreviousPage;
            donarsInfo.Controls.Add(Bp);
        }

        private static void OutputInfo(Button btn)
        {

            if (donarsList.Count > 0)
            {
                donarsInfo.Controls.Clear();

                string[] singleDonar = donarsList[pageIndex].Split(';');
                int y = 120;
                string picPath = $@"{singleDonar[singleDonar.Length - 1]}";
                string[] standardList = { "ID:", "Name:", "Surname:", "SocialID:", "Phone Number:", "Email:", "Blood Type:", "Donation Date:" };

                Label currentPage = new Label();
                currentPage.Text = $"{pageIndex + 1}/{donarsList.Count}";
                currentPage.AutoSize = true;
                currentPage.MaximumSize = new Size(300, 0);
                currentPage.Font = new Font("Arial", 26);
                currentPage.Location = new Point(380, 25);
                donarsInfo.Controls.Add(currentPage);

                for (int i = 0; i < singleDonar.Length - 1; i++)
                {
                    Label donarLabel = new Label();
                    if (singleDonar[i] == "")
                    {
                        singleDonar[i] = "-";
                    }
                    donarLabel.Text = $"{standardList[i]} {singleDonar[i]}";
                    donarLabel.Width = 400;
                    donarLabel.Height = 40;
                    donarLabel.Font = new Font("Arial", 20);
                    donarLabel.Location = new Point(20, y);
                    donarsInfo.Controls.Add(donarLabel);
                    y += 50;
                }

                PictureBox donarPic = new PictureBox();
                donarPic.Image = Image.FromFile(picPath);
                donarPic.SizeMode = PictureBoxSizeMode.StretchImage;
                donarPic.Size = new Size(350, 350);
                donarPic.Location = new Point(450, 120);
                donarsInfo.Controls.Add(donarPic);

                ButtonCreate(btn);

            }

            else if (donarsList.Count == 0)
            {
                donarsInfo.Controls.Clear();

                string[] standardList = { "ID:", "Name:", "Surname:", "SocialID:", "Phone Number:", "Email:", "Blood Type:", "Donation Date:", "Default Image\\avatar.jpg" };
                int y = 90;
                btn.Enabled = false;
                Label currentPage = new Label();
                currentPage.Text = $"0/0";
                currentPage.AutoSize = true;
                currentPage.MaximumSize = new Size(300, 0);
                currentPage.Font = new Font("Arial", 16);
                currentPage.Location = new Point(380, 25);
                donarsInfo.Controls.Add(currentPage);

                for (int i = 0; i < standardList.Length - 1; i++)
                {
                    Label donarLabel = new Label();
                    donarLabel.Text = $"{standardList[i]} -";
                    donarLabel.AutoSize = true;
                    donarLabel.MaximumSize = new Size(300, 0);
                    donarLabel.Font = new Font("Arial", 20);
                    donarLabel.Location = new Point(20, y);
                    donarsInfo.Controls.Add(donarLabel);
                    y += 45;
                }

                PictureBox donarPic = new PictureBox();
                donarPic.Image = Image.FromFile(standardList[standardList.Length - 1]);
                donarPic.SizeMode = PictureBoxSizeMode.StretchImage;
                donarPic.Size = new Size(350, 350);
                donarPic.Location = new Point(450, 120);
                donarsInfo.Controls.Add(donarPic);

                ButtonCreate(btn);
                ;
            }
        }
        public static void DeleteDonar(Button btn)
        {
            string path = "data.txt";
            FileStream fs;
            StreamWriter ws;

            donarsList.RemoveAt(pageIndex);

            fs = new FileStream(path, FileMode.Truncate, FileAccess.Write);
            ws = new StreamWriter(fs);

            for (int i = 0; i < donarsList.Count; i++)
            {
                ws.WriteLine(donarsList[i]);
            }
            ws.Close();
            fs.Close();
            try
            {
                OutputInfo(btn);
            }
            catch
            {
                pageIndex = 0;
                OutputInfo(btn);
            }
        }
    }
}
