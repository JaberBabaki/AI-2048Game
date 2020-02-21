

using Game2048Orginal.Src;
using System;
using System.Windows.Forms;

namespace  Game2048Orginal.Forms
{
    public partial class ResultGame : Form
    {
        private string Score;
        private string Max;
        private string Best;
        private string Move;
        private string Time;
        public string score
        {
            set { Score = value; }
            get { return Score; }
        }
        public string max
        {
            set { Max = value; }
            get { return Max; }
        }
        public string best
        {
            set { Best = value; }
            get { return Best; }
        }
        public string move
        {
            set { Move = value; }
            get { return Move; }
        }
        public string time
        {
            set { Time = value; }
            get { return Time; }
        }
        public ResultGame()
        {
            InitializeComponent();
        }

        private void ResultGame_Load(object sender, EventArgs e)
        {
            G.currentForm = this;
            if (Convert.ToInt32(max) > 2048)
            {
                label1.Text = "Win ";
            }
            lblScore.Text = score;
            lblTime.Text = time;
            labBest.Text = best;
            labMove.Text = move;
            labMax.Text = max;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            G.resetRun = 1;
            Application.OpenForms["Game"].Activate();
            
            Application.OpenForms["Game"].Enabled = true;
            string str = (Application.OpenForms["Game"] as Game).bestRecord;
            if (Convert.ToInt16(str) < Convert.ToInt16(score))
            {
                (Application.OpenForms["Game"] as Game).btnBestRecord.Text = score;
                (Application.OpenForms["Game"] as Game).label13.Text = score;
                Users users = new Users();
                users.updateIdRecord((Application.OpenForms["Game"] as Game).id, (Application.OpenForms["Game"] as Game).id);
            }
            this.Close();
        }

        private void ResultGame_FormClosed(object sender, FormClosedEventArgs e)
        {

            G.resetRun = 1;
            Application.OpenForms["Game"].Activate();
            Application.OpenForms["Game"].Enabled = true;
            string str = (Application.OpenForms["Game"] as Game).bestRecord;
            if (Convert.ToInt16(str) < Convert.ToInt16(score))
            {
                (Application.OpenForms["Game"] as Game).btnBestRecord.Text = score;
                (Application.OpenForms["Game"] as Game).label13.Text = score;
                Users users = new Users();
                users.updateIdRecord((Application.OpenForms["Game"] as Game).id, (Application.OpenForms["Game"] as Game).id);
            }


        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }
    }
}
