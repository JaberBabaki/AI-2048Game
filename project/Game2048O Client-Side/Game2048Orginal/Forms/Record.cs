

using Game2048Orginal.cc;
using Game2048Orginal.Src;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace Game2048Orginal.Forms
{
    public partial class Record : Form
    {
        public List<Input> inp =new List<Input>();
        Input[] forloop;
        public int start, end;
        public Boolean isset=false;
        public string strC;

            
        public Record()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = ColorTranslator.FromHtml("#746A5F");
            button2.BackColor = ColorTranslator.FromHtml("#E85D3B");
            button1.BackColor = ColorTranslator.FromHtml("#E85D3B");
            panel3.Controls.Clear();
            showLocal();
            inp.Clear();
            label5.Visible = false;
            panel5.Visible = false;
            
        }

        private void Record_Load(object sender, EventArgs e)
        {

            label5.Visible = false;
            //timer1.Enabled = true;
            showLocal();
            inp.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4.BackColor =ColorTranslator.FromHtml("#E85D3B");
            button1.BackColor = ColorTranslator.FromHtml("#746A5F");

            button2.BackColor = ColorTranslator.FromHtml("#E85D3B");
            panel3.Controls.Clear();
            start = 0;
            end = 7;
            isset = false;
            strC = "";
            panel5.Visible = false;
            label5.Visible = true;
            label5.Text = "Connecting please wait ...";
            timer2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.BackColor = ColorTranslator.FromHtml("#E85D3B");
            button2.BackColor = ColorTranslator.FromHtml("#746A5F");
            button1.BackColor = ColorTranslator.FromHtml("#E85D3B");
            panel3.Controls.Clear();
            start = 0;
            end = 7;
            isset=false;
            strC="";
            panel5.Visible = false;
            label5.Visible = true;
            label5.Text = "Connecting please wait ...";
            timer1.Enabled = true;

        }
        private void each(){
            foreach (Control cnt in panel3.Controls)
            {
               
            }

        }
        public Input Sort(int id)
        {
            G.currentForm = this;
            RcordEachUser rcordEachUser = new RcordEachUser();
            rcordEachUser.id = id;
            List<Input> input = rcordEachUser.selectRecord();
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
            if (input.Count > 0)
            {
                Input temp2 = new Input();
                temp2.Id = id;
                temp2.Score = input[0].Score;
                temp2.Max = input[0].Max;
                return temp2;
            }else
            {
                Input temp2 = new Input();
                temp2.Id = id;
                temp2.Score = "0";
                temp2.Max = "0";
                return temp2;
            }

        }
        public void getBestRecorEachUser()
        {
            for (int i = 0; i < Login.input.Count ; i++)
            {
                Input temp = Sort(Login.input[i].Id);
                temp.UserPicture = Login.input[i].UserPicture;
                temp.UserName = Login.input[i].UserName;
                inp.Add(temp);
            }
        }
        private void showLocal()
        {
            G.currentForm = this;
            getBestRecorEachUser();
            int currentX = 3, currentY = 5;
            for (int i = 0; i < inp.Count; i++)
            {
                UserC userc = new UserC();
                userc.userName = inp[i].UserName;
                userc.score = inp[i].Score;
                userc.max = inp[i].Max;
                userc.path = inp[i].UserPicture;
                if (i % 2 == 0)
                {
                    userc.colour = "#EDF0FC";
                }
                else
                {
                    userc.colour = "#ffffff";
                }
                userc.Location = new Point(currentX, currentY);
                this.panel3.Controls.Add(userc);
                currentY = currentY + 45;
            }
        }
        public void change()
        {
            int currentX = 3, currentY = 5;

            if (forloop.Length > 7)
            {
                //MessageBox.Show("");
                panel5.Visible = true;
            }
            else
            {
                end = forloop.Length;
            }
            if (forloop.Length >= end)
            {
                for (int i = start; i < end; i++)
                {
                    
                    UserC userc = new UserC();
                    userc.userName = forloop[i].UserName;
                    userc.score = forloop[i].Score;
                    userc.max = forloop[i].Max;
                    userc.path = G.DIRIMG+ forloop[i].UserPicture + ""; ;
                    if (i % 2 == 0)
                    {
                        userc.colour = "#EDF0FC";
                    }
                    else
                    {
                        userc.colour = "#ffffff";
                    }
                    userc.Location = new Point(currentX, currentY);
                    this.panel3.Controls.Add(userc);
                    currentY = currentY + 45;
                    start++;
                }
            }
            else
            {
               // MessageBox.Show("end");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
          if (WebService.CheckForInternetConnection())
          { 
            
            SendData();

            WebService webService = new WebService();
            webService.uRl = "http://www.martyriran.ir/Game2048/index.php?action=read";
            string result = webService.cli();
            if (result != null)
            {
                label5.Visible = false;
                JavaScriptSerializer js = new JavaScriptSerializer();
                forloop = js.Deserialize<Input[]>(result);
                downloadFile();
                sort();
                label4.Text = "/" + (forloop.Length / 7);
                
                change();

            }
          }
          else
          {
               MessageBox.Show("Internet connection is disconnected");
               label5.Text = "Internet not available";
          }

        }
        private void  sort()
        {
            Input temp = new Input();
            for (int i = 0; i < forloop.Length; i++)
            {
                for (int j = 0; j < forloop.Length - 1; j++)
                {
                    if (Convert.ToInt16(forloop[j].Score) < Convert.ToInt16(forloop[j + 1].Score))
                    {
                        temp = forloop[j + 1];
                        forloop[j + 1] = forloop[j];
                        forloop[j] = temp;

                    }
                }
            }


        }
        private void downloadFile(){
            for (int i = 0; i < forloop.Length; i++)
            {
                WebService webService = new WebService();
                string curFile = G.DIRIMG + forloop[i].UserPicture + "";
             //   MessageBox.Show(forloop[i].Flag + "::");
                if (!File.Exists(curFile)|| forloop[i].Flag==1)
                {
                    //MessageBox.Show(forloop[i].Flag + "::");
                    webService.downloadFile(forloop[i].UserPicture);
                }
            }
            //userc.path = @"C:\Users\User\Desktop\library\" + forloop[i].UserPicture + "";
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            if (WebService.CheckForInternetConnection())
            {
               
                SendData();
                WebService webService = new WebService();
                webService.uRl = "http://www.martyriran.ir/Game2048/index.php?action=readT";
                string result = webService.cli();
                  //MessageBox.Show("" + result); 
                if (result != null && !result.Equals("n"))
                {
                    label5.Visible = false;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    forloop = js.Deserialize<Input[]>(result);
                    sort();
                    label4.Text = "/" + (forloop.Length / 7);
                    change();

                }else
                {
                    MessageBox.Show("Internet connection is disconnected");
                    label5.Text = "Internet not available";
                }
            }
            else
            {
                MessageBox.Show("Internet connection is disconnected");
                label5.Text = "Internet not available";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if ((end/7) < (forloop.Length/7))
            {
                panel3.Controls.Clear();

                // start = 7;
                end = end + 7;
                //MessageBox.Show("" + start + "::" + end + "::" + forloop.Count());
                if (isset)
                {
                    textBox1.Text = Convert.ToInt16(strC) + 1 + "";
                   // MessageBox.Show("klllll");
                    isset = false;
                }
                else
                {
                    textBox1.Text = Convert.ToInt16(textBox1.Text) + 1 + "";
                   // MessageBox.Show("kl");
                }
                pictureBox2.Enabled = true;
                change();
            }
            pictureBox1.Focus();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("" + start);
            if (start >7)
            {
                panel3.Controls.Clear();
                start = start - 14;
                end = end - 7;
               // MessageBox.Show("" + start + "::" + end + "::" + forloop.Count());
                if (isset)
                {
                    textBox1.Text = Convert.ToInt16(strC) - 1 + "";
                    isset = false;
                }
                else
                {
                    textBox1.Text = Convert.ToInt16(textBox1.Text) - 1 + "";
                    
                }
                change();
            }
            pictureBox2.Focus();
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = textBox1.Text;
            if (!(Char.IsDigit(e.KeyChar)))
            {
               // isset = false;
                e.Handled = true;
            }
               
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = false;
                //MessageBox.Show("" + Keys.Enter);
                if (Convert.ToInt16(textBox1.Text) <= (forloop.Length / 7) && Convert.ToInt16(textBox1.Text)>0)
                {
                    isset = false;
                    end = Convert.ToInt16(textBox1.Text) * 7;
                    start = end - 7;
                    panel3.Controls.Clear();

                    change();
                    //MessageBox.Show("" + start + "::" + end + "::" + forloop.Count());
                   
                }
                pictureBox1.Focus();
            }
            if (e.KeyChar == (char)Keys.Back )
            {
                e.Handled = false;
               // MessageBox.Show("" + Keys.Back);
                //isset = false;
                
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            strC = textBox1.Text;
            isset = true;
        }
        private void SendData()
        {
            for (int b = 0; b < Login.input.Count; b++)
            {
                
                SendData sendData = new SendData();
                sendData.id = Login.input[b].Id;
                sendData.setInput();
                int i = sendData.firstSend();
                if (i != 1)
                {
                    sendData.sendIP_PICTURE_USERNAME();
                }
            }
        }
    }
}
