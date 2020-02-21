



using Game2048Orginal.Forms;
using Game2048Orginal.Src;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game2048Orginal.cc
{
    public partial class EachRecord : UserControl
    {
        private int IdUser;
        private string Score;
        private string Max;
        private string Move;
        private string Time;
        private string Colour;
        private int BtnDeleteId;
        public int idUser
        {
            set { IdUser = value; }
            get { return IdUser; }
        }
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
        public string colour
        {
            set { Colour = value; }
            get { return Colour; }
        }
        public int btnDeleteId
        {
            set { BtnDeleteId = value; }
            get { return BtnDeleteId; }
        }
        public EachRecord()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void EachRecord_Load(object sender, EventArgs e)
        {
            Color col = ColorTranslator.FromHtml(colour);
            label2.Text = score;
            label1.Text = max;
            label3.Text = move;
            label4.Text = time;
            button1.Tag = btnDeleteId;
            this.BackColor = col;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("" + Convert.ToInt16(btnDeleteId));
            RcordEachUser rcordEachUser = new RcordEachUser();
            rcordEachUser.id = Convert.ToInt16(btnDeleteId);
            rcordEachUser.DeleteRecord();
            (Application.OpenForms["RecordUser"] as RecordUser).Fill();

        }
    }
}
