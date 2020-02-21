
using Game2048Orginal.cc;
using Game2048Orginal.Src;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game2048Orginal.Forms
{
    public partial class Login : Form
    {
        public static List<Input> input = new List<Input>();

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Record record = new Record();
            record.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
           // MessageBox.Show("" + appPath);
            G.currentForm = this;
            Fill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Process p = new Process();
             p.StartInfo.FileName = "WinRAR.exe";
             p.StartInfo.Arguments = "/x \"C:\\Application.msi\"/qn";
             p.Start(); */
            try {
                if (txtUserName.Text != "")
                {
                    if (txtUserName.Text.Trim().Length < 40 && txtUserName.Text.Trim().Length > 6)
                    {
                        Users users = new Users();

                        users.userName = txtUserName.Text.Trim();
                        int i = users.selectUserName();
                        if (i == 0) {
                            users.picture = G.ADDPIC;
                            users.insertUser();
                            Fill();
                            Game game = new Game();
                            game.userName = txtUserName.Text.Trim();
                            game.bestRecord = "-1";
                            //  MessageBox.Show("" + input[i].UserPicture);
                            game.picture = input[i].UserPicture;
                            game.id = (input[input.Count - 1].Id);
                            users.insertFinder(input[input.Count - 1].Id);
                            game.Show();
                            txtUserName.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("User name is already registered ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username must be greater than 6 characters");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a new username or Login here");
                }
            }catch(Exception h)
            {

            }
        }
        public void Fill()
        {
            try {
                panel1.Controls.Clear();
                Users users = new Users();
                input = users.selectAllUser();
                int currentX = 3, currentY = 5;
                int i = 0;
                for (i = 0; i <= input.Count - 1; i++)
                {
                    UserRecord userRecord = new UserRecord();
                    userRecord.uName = input[i].UserName;
                    userRecord.picture = input[i].UserPicture;
                    userRecord.tagEntry = input[i].Id;
                    userRecord.tagDelete = input[i].Id;
                    if (i % 2 == 0)
                    {
                        userRecord.colour = "#EDF0FC";
                    }
                    else
                    {
                        userRecord.colour = "#ffffff";
                    }
                    userRecord.Location = new Point(currentX, currentY);
                    this.panel1.Controls.Add(userRecord);
                    currentY = currentY + 45;

                }
            }
            catch (Exception e)
            {

            }
           // MessageBox.Show(input[input.Count()-1].Id+"");
        }

        private void Login_Activated(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_DoubleClick(object sender, EventArgs e)
        {
            
        }

    }

}
