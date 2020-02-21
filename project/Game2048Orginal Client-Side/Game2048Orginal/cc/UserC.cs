

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game2048Orginal.cc
{
    public partial class UserC : UserControl
    {
        private string UserName;
        private string Max;
        private string Score;
        private string Path;
        private string Colour;
        public string userName
        {
            set { UserName = value; }
            get { return UserName; }
        }
        public string max
        {
            set { Max = value; }
            get { return Max; }
        }
        public string score
        {
            set { Score = value; }
            get { return Score; }
        }
        public string path
        {
            set { Path = value; }
            get { return Path; }
        }
        public string colour
        {
            set { Colour = value; }
            get { return Colour; }
        }
        public UserC()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserC_Load(object sender, EventArgs e)
        {
            Color col = ColorTranslator.FromHtml(colour);
            label1.Text = userName;
            label2.Text = score;
            label3.Text = max;
            try
            {
                pictureBox1.Image = Image.FromFile(path);
            }
            catch
            {

                pictureBox1.Image = Image.FromFile(G.ADDPIC);
            }
           
            this.BackColor = col;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
