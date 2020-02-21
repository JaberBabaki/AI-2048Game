

using Game2048Orginal.Forms;
using Game2048Orginal.Src;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game2048Orginal.cc
{
    public partial class UserRecord : UserControl
    {
        private string UName;
        private string Colour;
        private int TagDelete;
        private int TagEntry;
        private string Picture;
        public string uName
        {
            set { UName = value; }
            get { return UName; }
        }
        public string picture
        {
            set { Picture = value; }
            get { return Picture; }
        }
        public string colour
        {
            set { Colour = value; }
            get { return Colour; }
        }
        public int tagDelete
        {
            set { TagDelete = value; }
            get { return TagDelete; }
        }
        public int tagEntry
        {
            set { TagEntry = value; }
            get { return TagEntry; }
        }
        public UserRecord()
        {
            InitializeComponent();
        }

        private void UserRecord_Load(object sender, EventArgs e)
        {
            label1.Tag = picture;
            label1.Text = uName;
            button1.Tag = tagDelete;
            button2.Tag = tagEntry;
            Color col = ColorTranslator.FromHtml(colour);
            this.BackColor = col;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users users = new Users();

            users.id = Convert.ToInt16(button1.Tag);
            users.DeleteUser();
            // G.currentForm.Activate();
            (Application.OpenForms["Login"] as Login).Fill() ;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RcordEachUser rcordEachUser = new RcordEachUser();
            rcordEachUser.id = Convert.ToInt16(button2.Tag);
            List<Input>  input = rcordEachUser.selectRecord();
            Input temp = new Input();
            if (input.Count > 0)
            {
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

                Game game = new Game();
                game.bestRecord = input[0].Score;
                game.userName = uName;
                game.id = Convert.ToInt16(button2.Tag);
                game.picture = label1.Tag.ToString();
                game.Show();
            }
            else
            {
                Game game = new Game();
                game.bestRecord = "-1";
                game.userName = uName;
                game.picture = label1.Tag.ToString();
                game.id = Convert.ToInt16(button2.Tag);
                game.Show();
            }

        }
    }
}
