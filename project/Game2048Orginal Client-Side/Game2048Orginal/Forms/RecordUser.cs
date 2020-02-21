

using Game2048Orginal.cc;
using Game2048Orginal.Src;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace  Game2048Orginal.Forms
{
    public partial class RecordUser : Form
    {
        private int Id;
        private string UserName;
        private string Picture;

        public int id
        {
            set { Id = value; }
            get { return Id; }
        }
        public string userName
        {
            set { UserName = value; }
            get { return UserName; }
        }
        public string picture
        {
            set { Picture = value; }
            get { return Picture; }
        }
        public List<Input> input =new  List<Input>();
        public RecordUser()
        {
            InitializeComponent();
        }

        private void RecordUser_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("" + picture);
            pictureBox1.Image = Image.FromFile(picture);
            label4.Text = userName;
            Sort();
            Fill();
        }

        public void Sort()
        {
            G.currentForm = this;
            RcordEachUser rcordEachUser = new RcordEachUser();
            rcordEachUser.id = id;
            input = rcordEachUser.selectRecord();
            Input temp = new Input();
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count - 1; j++)
                {
                    if (Convert.ToInt16(input[j].Score) < Convert.ToInt16(input[j + 1].Score))
                    {
                        temp = input[j + 1];
                        input[j + 1] = input[j];
                        input[j] = temp;

                    }
                }
            }
        }
        public void Fill()
        {
            panel1.Controls.Clear();
            int currentX = 3, currentY = 5;
            for (int i = 0; i <= input.Count - 1; i++)
            {
                //MessageBox.Show("" + i);
                EachRecord eachRecord = new EachRecord();
                eachRecord.score = input[i].Score;
                eachRecord.max = input[i].Max;
                eachRecord.move = input[i].Move;
                eachRecord.time = input[i].Time;
                eachRecord.btnDeleteId = input[i].Id;
                if (i % 2 == 0)
                {
                    eachRecord.colour = "#EDF0FC";
                }
                else
                {
                    eachRecord.colour = "#ffffff";
                }
                eachRecord.Location = new Point(currentX, currentY);
                this.panel1.Controls.Add(eachRecord);
                currentY = currentY + 45;

            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
