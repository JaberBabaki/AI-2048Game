

using Game2048Orginal.Src;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace  Game2048Orginal.Forms
{
    public partial class Game : Form
    {
        private Color getButtonColor(int number)
        {
            switch (number)
            {
                case 0:
                    return ColorTranslator.FromHtml("#938374");
                case 2:
                    return ColorTranslator.FromHtml("#FFC16C");
                case 4:
                    return ColorTranslator.FromHtml("#C99336");
                case 8:
                    return ColorTranslator.FromHtml("#E5862E");
                case 16:
                    return ColorTranslator.FromHtml("#F9690E");
                case 32:
                    return ColorTranslator.FromHtml("#A23921");
                case 64:
                    return ColorTranslator.FromHtml("#F73108");
                case 128:
                    return ColorTranslator.FromHtml("#F7C424");
                case 256:
                    return ColorTranslator.FromHtml("#F7C424");
                case 512:
                    return ColorTranslator.FromHtml("#F7C424");
                case 1024:
                    return ColorTranslator.FromHtml("#F7C424");
                case 2048:
                    return ColorTranslator.FromHtml("#9A12B3");
                default:
                    return ColorTranslator.FromHtml("#22313F");

            }
        }
        private Color getNumberColor(int number)
        {
            switch (number)
            {
                case 0:
                    return ColorTranslator.FromHtml("#000000");
                case 2:
                    return ColorTranslator.FromHtml("#000000");
                case 4:
                    return ColorTranslator.FromHtml("#776E65");
                case 8:
                    return ColorTranslator.FromHtml("#F9F6F2");
                case 16:
                    return ColorTranslator.FromHtml("#F9F6F2");
                case 32:
                    return ColorTranslator.FromHtml("#F9F6F2");
                case 64:
                    return ColorTranslator.FromHtml("#F9F6F2");
                case 128:
                    return ColorTranslator.FromHtml("#F9F6F2");
                case 1024:
                    return ColorTranslator.FromHtml("#F9F6F2");
                default:
                    return ColorTranslator.FromHtml("#F9F6F2");
            }


        }
        private string BestReord;
        private string UserName;
        private int Id;

        private string Picture;
        public Button[,] piece = new Button[4, 4];

        private AI aii = new AI();

        public Boolean AvalibleTop=true;
        public Boolean AvalibleRight=true;
        public Boolean AvalibleDown=true;
        public Boolean AvalibleLeft=true;
        // move with mouse
        public int XxDown;
        public double XxUp;
        public int YyDown;
        public double YyUp;
        
        public string oriName;
        public Game()
        {
            InitializeComponent();
            
        }
        public string bestRecord{
            set { BestReord = value; }
            get { return BestReord; }
        }
        public string picture
        {
            set { Picture = value; }
            get { return Picture; }
        }
        public string userName
        {
            set { UserName = value; }
            get { return UserName; }
        }
        public int id
        {
            set { Id = value; }
            get { return Id; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer2.Enabled = true;
           G. currentForm = this;
            if (bestRecord.Equals("-1"))
            {
                btnBestRecord.Text ="0";
                label13.Text = "No Record";
            }else{
                btnBestRecord.Text = bestRecord ;
                label13.Text = bestRecord;
            }
            label10.Text = userName.Substring(0,7);
            circlePictureBox1.Image = Image.FromFile(picture);
            circlePictureBox1.Tag = picture;
            int currentX = 0;
            int CurrentY = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int b = 0; b < 4; b++)
                {
                    piece[i, b] = new Button();
                    piece[i, b].Location = new Point(currentX, CurrentY);
                    piece[i, b].Size = new Size(62, 62);
                    piece[i, b].FlatStyle = FlatStyle.Flat;
                    piece[i, b].BackColor = getButtonColor(0);
                    piece[i, b].ForeColor = getNumberColor(0);
                    piece[i, b].FlatAppearance.BorderSize = 0;
                    piece[i, b].KeyUp += new KeyEventHandler(keyDownButton);
                    piece[i, b].Font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
                    piece[i, b].MouseUp += new MouseEventHandler(p14_MouseUp);
                    piece[i, b].MouseDown += new MouseEventHandler(p14_MouseDown);
                    panel3.Controls.Add(piece[i,b]);
                    currentX=currentX+67;
                    //piecee[i, b] = new Button();

                }
                currentX = 0;
                CurrentY = CurrentY + 67;
            }
            restGame();
        }
        //reset game
        public  void restGame()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int b = 0; b < 4; b++)
                {
                    piece[i, b].Text = "";
                    piece[i, b].BackColor = getButtonColor(0);
                    piece[i, b].ForeColor = getNumberColor(0);
                }
            }
            generateNumber();
            generateNumber();
            AvalibleTop=true;
            AvalibleRight=true;
            AvalibleDown=true;
            AvalibleLeft=true;
            label5.Text = "0";
            label4.Text = "0";
            label3.Text = "0";
            btnMove.Text = "0";
          ///  btnBestRecord.Text = "0";
            btnScore.Text = "0";
            

        }
        // geneate new number 
        private void generateNumber(){
            //MessageBox.Show("l");
            if (piceEmpety())
            {
                Random rnd = new Random();
                while (true)
                {

                    int randomX = rnd.Next(0, 4);
                    int randomY = rnd.Next(0, 4);
                    if (piece[randomX, randomY].Text == "")
                    {
                        int probability = rnd.Next(1, 11);
                        if (probability > 9)
                        {
                            piece[randomX, randomY].BackColor = getButtonColor(4);
                            piece[randomX, randomY].Text = "" + 4;
                        }
                        else
                        {
                            piece[randomX, randomY].BackColor = getButtonColor(2);
                            piece[randomX, randomY].Text = "" + 2;
                        }
                        break;
                    }
                   

                }
            }
            else
            {
                
                restGame();
            }
        }
        //check exist empty pice
        public Boolean  piceEmpety(){
            Boolean check=false;
            for (int i = 0; i < 4; i++)
            {
                for (int b = 0; b < 4; b++)
                {
                    if (piece[i, b].Text == "")
                    {
                        check = true;
                        break;
                    }
                    
                }
            }

            return check;

        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        //in this section you move piece with arrow key
        private void keyDownButton(object sender,KeyEventArgs e)
        {
        
            if (e.KeyData == Keys.Right)
            {
                goToRight();

                if (AvalibleRight)
                {
                    generateNumber();
                    refreshColor();
                }
                else if (piceEmpety() == false)
                {
                    Boolean ch = CheckFinishedGame();
                    if (ch == false)
                    {
                       // MessageBox.Show("finish");

                        resultShow(btnScore .Text,MaxNumber().ToString(),btnBestRecord.Text,btnMove .Text ,(label3.Text +": "+label4.Text +": "+label5 .Text ));
                        insertRecord();
                    }
                }
               
            }
            else if (e.KeyData == Keys.Left)
            {
                 goToLeft();
                
                if (AvalibleLeft)
                {
                    generateNumber();
                    refreshColor();
                }
                else if (piceEmpety() == false)
                {
                    Boolean   ch = CheckFinishedGame();
                    if (ch == false)
                    {
                       // MessageBox.Show("finish");

                        resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                        insertRecord();
                    }
                }

                
            }
            else if (e.KeyData == Keys.Up)
            {
                goToUp();
                
                if (AvalibleTop) { 
                    generateNumber();
                    refreshColor();
                }
                else if (piceEmpety() == false)
                {
                    Boolean ch = CheckFinishedGame();
                    if (ch == false)
                    {
                       // MessageBox.Show("finish");

                        resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                        insertRecord();
                    }
                }

                
            }
            else if (e.KeyData == Keys.Down)
            {
                goToDown();
                
                if (AvalibleDown)
                {
                    generateNumber();
                    refreshColor();
                }
                else if (piceEmpety() == false)
                {
                    Boolean ch = CheckFinishedGame();
                    if (ch == false)
                    {
                       // MessageBox.Show("finish");

                        resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                        insertRecord();
                    }
                }

                
            }
        }
        // all of piece go to top if required then generate show new number
        private void goToUp()
        {
            AvalibleTop = false;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i > 0)
                    {
                        int k = i;
                        while (k > 0 && piece[k - 1,j].Text == "")
                        {
                           
                            piece[k - 1, j].Text = piece[k,j].Text;
                            if (piece[k - 1, j].Text!="" && piece[k,j].Text!="" && piece[k - 1, j].Text == piece[k,j].Text){                               
                                AvalibleTop = true;
                            }
                            piece[k,j].Text = "";
                            k--;
                        }

                        if (k > 0)
                        {
                            if (piece[k - 1, j].Text == piece[k,j].Text)
                            {
                                AvalibleTop = true;
                                power(k - 1, j);
                                piece[k,j].Text = "";
                            }
                        }
                    }
                }
            }
        }
        // all of piece go to down if required then generate show new number
        private void goToDown()
        {
             AvalibleDown = false; 
            for (int j = 3; j >= 0; j--)
            {
                for (int i = 3; i >= 0; i--)
                {
                    if (i < 3)
                    {
                        int k = i;
                        while (k < 3 && piece[k + 1,j].Text == "")
                        {
                            piece[k + 1,j].Text = piece[k,j].Text;
                            if (piece[k + 1, j].Text != "" && piece[k, j].Text!="" &&  piece[k + 1,j].Text == piece[k,j].Text){
                                AvalibleDown = true;
                            }
                            piece[k,j].Text ="";
                            k++;
                        }

                        if (k < 3)
                        {
                            if (piece[k + 1,j].Text == piece[k,j].Text)
                            {
                                AvalibleDown = true;
                                power(k + 1, j);
                                piece[k,j].Text = "";
                            }
                        }
                    }
                }
            }
        }
        // all of piece go to left if required then generate show new number
        private void goToLeft()
        {
            AvalibleLeft = false; 
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j > 0)
                    {
                        int k = j;
                        while (k > 0 && piece[i,k - 1].Text == "")
                        {
                            piece[i, k - 1].Text = piece[i,k].Text;
                            if (piece[i, k - 1].Text != "" && piece[i, k].Text != "" && piece[i, k - 1].Text == piece[i, k].Text)
                            {
                                AvalibleLeft = true;
                            }
                            piece[i,k].Text = "";
                            k--;
                        }

                        if (k > 0)
                        {
                            if (piece[i, k - 1].Text == piece[i,k].Text)
                            {
                                AvalibleLeft = true;
                                power(i, k - 1);
                                piece[i,k].Text = "";
                            }
                        }
                    }
                }
            }
        }
        // all of piece go to right if required then generate show new number
        private void goToRight()
        {
            AvalibleRight = false; 
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (j < 3)
                    {
                        int k = j;
                        while (k < 3 && piece[i,k + 1].Text == "")
                        {
                            piece[i,k + 1].Text = piece[i,k].Text;
                            if (piece[i, k + 1].Text != "" && piece[i, k].Text != "" && piece[i, k + 1].Text == piece[i, k].Text)
                            {
                                AvalibleRight = true;
                            }
                            piece[i,k].Text ="";
                            k++;
                        }

                        if (k < 3)
                        {
                            if (piece[i,k + 1].Text == piece[i,k].Text)
                            {
                                AvalibleRight = true;
                                power(i, k + 1);
                                piece[i,k].Text = "";
                            }
                        }
                    }
                }
            }
        }
        public void power(int i, int j)
        {

                piece[i, j].Text = "" + Convert.ToInt32(piece[i, j].Text) * 2;
                btnScore.Text = "" + (Convert.ToInt32(btnScore.Text) + Convert.ToInt32(piece[i, j].Text));
         
            
        }
        // Every move change colour and behavior and font  if required
        public void refreshColor()
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
            }
            
            btnMove.Text = "" + (Convert.ToInt16(btnMove.Text) + 1);
            for (int i = 0; i < 4; i++)
            {
                for (int b = 0; b < 4; b++)
                {
                    
                    if (piece[i, b].Text != "")
                    {
                        int textNumber = Convert.ToInt32(piece[i, b].Text);
                        piece[i, b].BackColor = getButtonColor(textNumber);
                        piece[i, b].ForeColor = getNumberColor(textNumber);
                        if (piece[i, b].Text.Length == 3)
                        {
                            piece[i, b].Font = new Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold);
                        }
                        else if (piece[i, b].Text.Length == 4)
                        {
                            piece[i, b].Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                        }
                        else if (piece[i, b].Text.Length >= 5)
                        {
                            piece[i, b].Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                        }
                        else
                        {
                            piece[i, b].Font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
                        }
                    }
                    else
                    {
                        piece[i, b].BackColor = getButtonColor(0);
                        piece[i, b].ForeColor = getNumberColor(0);
                    }

                }
            }
        }
        //chech about exist condition for finish game 
        public Boolean  CheckFinishedGame(){
            Boolean check = false;
            for (int i = 0; i < 4; i++)
            {
                for (int b = 0; b < 4; b++)
                {
                    if (i == 0 ||i==1 || i==2)
                    {
                        if ( b == 3)
                        {
                            if (piece[i, b].Text == piece[i+1, b ].Text)
                            {
                                check = true;
                                break;
                            }
                        }
                        else if(piece[i, b].Text == piece[i, b+1 ].Text || piece[i, b].Text == piece[i+1, b].Text)
                        {
                            check = true;
                            break;
                        }
                    }
                    else 
                    {
                        if (i==3 && b==3){

                        }else if(piece[i, b].Text == piece[i, b + 1].Text){
                            check = true;
                            break;
                        }
                    }

                }
            }
            return check;
        }
        private void p14_MouseDown(object sender, MouseEventArgs e)
        {
            XxDown = e.Location.X;
            YyDown = e.Location.Y;

        }
        private void p14_MouseUp(object sender, MouseEventArgs e)
        {

            //      (ربع اول)                 |     (ربع دوم) 
            //             \ 1     |         *
            //              \      |         \
            //               \     |           \
            //                \    |             \
            //                 \   |                \
            //                  \* |                   \ 2
            //    -----------------|--------------------
            //                     |
            //                     | 
            //                     |
            //                     |
            //                     |
            //      (ربع چهارم)                 |     (ربع سوم)     
            //                     |
            //
            //موقعه ای رها می شود ، با توجه به اختلاف ایکس و ایگرگ تصمیمی درست گرفته مشود
            // * نقطه کلیک اول 
            // 1- در اینجا به سمت بالا می رود چرا که ایگرگ بییشتر افزایش یافته و در ربع دوم می باشد   
            // 2- در اینجا به سمت چپ می رودالبته یه طور دقیق باید محاسبه شود 

            XxUp = e.Location.X + 0.5;
            YyUp = e.Location.Y + 0.5;

            double diffX = Math.Abs(XxUp - XxDown);
            double diffY = Math.Abs(YyUp - YyDown);
            //move with mouse to up or left
            if (XxUp < XxDown && YyUp < YyDown)
            {

                if (diffY > diffX)
                {
                    goToUp();
                    
                    if (AvalibleTop)
                    {
                        generateNumber();
                        refreshColor();
                    }
                    else if (piceEmpety() == false)
                    {
                        Boolean ch = CheckFinishedGame();
                        if (ch == false)
                        {
                            //MessageBox.Show("finish");

                            resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                            insertRecord();
                        }
                    }

                }
                else
                {

                    goToLeft();
                    
                    if (AvalibleLeft)
                    {
                        generateNumber();
                        refreshColor();
                    }
                    else if (piceEmpety() == false)
                    {
                        Boolean ch = CheckFinishedGame();
                        if (ch == false)
                        {
                          //  MessageBox.Show("finish");

                            resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                            insertRecord();
                        }
                    }
                }

            }
            //move with mouse to right or down
            if (XxUp > XxDown && YyUp > YyDown)
            {
                if (diffY < diffX)
                {

                    goToRight();
                  
                    if (AvalibleRight)
                    {
                        generateNumber();
                        refreshColor();
                    }
                    else if (piceEmpety() == false)
                    {
                        Boolean ch = CheckFinishedGame();
                        if (ch == false)
                        {
                            //MessageBox.Show("finish");

                            resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                            insertRecord();
                        }
                    }
                }
                else
                {
                    goToDown();
                    
                    if (AvalibleDown)
                    {
                        generateNumber();
                        refreshColor();
                    }
                    else if (piceEmpety() == false)
                    {
                        Boolean ch = CheckFinishedGame();
                        if (ch == false)
                        {
                           // MessageBox.Show("finish");

                            resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                            insertRecord();
                        }
                    }

                }

            }
            //move with mouse to right or up
            if (XxUp > XxDown && YyUp < YyDown)
            {
                if (diffY < diffX)
                {
                    goToRight();
                    
                    if (AvalibleRight)
                    {
                        generateNumber();
                        refreshColor();
                    }
                    else if (piceEmpety() == false)
                    {
                        Boolean ch = CheckFinishedGame();
                        if (ch == false)
                        {
                          //  MessageBox.Show("finish");

                            resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                            insertRecord();
                        }
                    }
                }
                else
                {

                    goToUp();
                    
                    if (AvalibleTop)
                    {
                        generateNumber();
                        refreshColor();
                    }
                    else if (piceEmpety() == false)
                    {
                        Boolean ch = CheckFinishedGame();
                        if (ch == false)
                        {
                           // MessageBox.Show("finish");

                            resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                            insertRecord();
                        }
                    }
                }

            }
            //move with mouse to down or left
            if (XxUp < XxDown && YyUp > YyDown)
            {

                if (diffY > diffX)
                {

                    goToDown();
                    
                    if (AvalibleDown)
                    {
                        generateNumber();
                        refreshColor();
                    }
                    else if (piceEmpety() == false)
                    {
                        Boolean ch = CheckFinishedGame();
                        if (ch == false)
                        {
                            //MessageBox.Show("finish");

                            resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                            insertRecord();
                        }
                    }
                }
                else
                {

                    goToLeft();
                    
                    if (AvalibleLeft)
                    {
                        generateNumber();
                        refreshColor();
                    }
                    else if (piceEmpety() == false)
                    {
                        Boolean ch = CheckFinishedGame();
                        if (ch == false)
                        {
                            //MessageBox.Show("finish");

                            resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                            insertRecord();
                        }
                    }

                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if((Convert.ToInt32(label5.Text)!=60)){
                label5.Text = "" + (Convert.ToInt32(label5.Text) + 1);
            }
            else if((Convert.ToInt32(label4.Text)!=60))
            {
                label4.Text = "" + (Convert.ToInt32(label4.Text) + 1);
                label5.Text = "0";
            }
            else if ((Convert.ToInt32(label3.Text) != 24))
            {
                label3.Text = "" + (Convert.ToInt32(label3.Text) + 1);
                label4.Text = "0";
            }
            else
            {
                label3.Text = "0";
                label5.Text = "0";
                label4.Text = "0";

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
           // label10.Text = userName.Substring(0, 7);
           // label10.Enabled = false;
            /*ResultGame fr = new ResultGame();
           // fr.FormBorderStyle = FormBorderStyle.None;
            //fr.BackColor = Color.Blue;
            //fr.TopLevel = false;
            //fr.Opacity = 0.5;
            // add this
            this.Opacity = 0.7;
           // this.panel1.Controls.Add(fr);
            fr.Show();*/
        }

        private void circlePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void resultShow(string Score,string Max,string Best,string Move,string Time )
        {
            ResultGame resultGame=new ResultGame();
            resultGame.score=Score;
            resultGame.max=Max;
            resultGame. best=Best;
            resultGame. move=Move;
            resultGame.time=Time;
            resultGame.Show();
            timer1.Enabled = false;
            this.Enabled = false;
            //this.Close();

        }
        public double MaxNumber(){
                     int[] values=new int[16];
                     double maxValue = 0;
                     int count=0;
                     for (int i = 0; i < 4; i++)
                     {
                         for (int j = 0; j < 4; j++)
                         {
                             values[count] = Convert.ToInt16(piece[i, j].Text);
                             count++;

                         }
                     }

                     for (var i = 0; i < values.Length; ++i)
                     {

                         if (values[i] > maxValue)
                         {
                             maxValue = values[i];
                         }

                     }
                     return maxValue;

        }

        private void Game_Activated(object sender, EventArgs e)
        {
            if (G.resetRun == 1)
            {
                restGame();
                G.resetRun = 0;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }


        private void insertRecord()
        {
           
            RcordEachUser RecordEachUser = new RcordEachUser();
            RecordEachUser.idUser = id;
            RecordEachUser.max=MaxNumber().ToString();
            RecordEachUser.move=btnMove.Text;
            RecordEachUser.score=btnScore.Text;
            RecordEachUser.time=(label3.Text + ": " + label4.Text + ": " + label5.Text);
            RecordEachUser.inserRecord();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RecordUser recordUser = new RecordUser();
            recordUser.picture =circlePictureBox1.Tag.ToString() ;
            recordUser.userName = label10.Text;
            recordUser.id = id;
            recordUser.Show();            
        }

        private void circlePictureBox1_Click_1(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.bmp, *.jpe, *.png) | *.jpg; *.bmp; *.jpe; *.png";
            dialog.InitialDirectory = @"C:\Users\User\Pictures";
            dialog.Title = "Please select an image file .";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
                //label8.Visible = false;
                circlePictureBox1.Image = Image.FromFile(filePath);
                circlePictureBox1.Tag = filePath;
                Users users = new Users();
                users.id = id;
                users.picture =filePath;
                users.updatePicture();
                users.updateIdUserPicture(id, id);
                //MessageBox.Show("ok");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            SendData sendData = new SendData();
            sendData.id = id;
            sendData.setInput();
           int i =sendData.firstSend();
            if (i!=1)
            {
                sendData.sendIP_PICTURE_USERNAME();
            }

        }


        private void label10_Click(object sender, EventArgs e)
        {
            
           // Users users = new Users();
           // users.updateIdUserName(id,id);
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
           
            //Users users = new Users();
            //users.updateIdUserName(id, id);
        }

        private void label17_Click(object sender, EventArgs e)
        {




        }

        private void label15_Click(object sender, EventArgs e)
        {
             Game2048Orginal.Forms.Help help = new Game2048Orginal.Forms.Help();
            help.Show();
 
        }

        private void btnBestRecord_Click(object sender, EventArgs e)
        {
             
           /* goToRight();

            if (AvalibleRight)
            {
                generateNumber();
                refreshColor();
            }
            else if (piceEmpety() == false)
            {
                Boolean ch = CheckFinishedGame();
                if (ch == false)
                {
                    // MessageBox.Show("finish");

                    resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                    insertRecord();
                }
            }*/
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Button[,] piecee = new Button[4, 4];
            
            double bestScore = double.MinValue;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    piecee[i, j] = new Button();
                    piecee[i, j].Text = piece[i, j].Text;

                }
            }


            List<Button[,]> movesBest = new List<Button[,]>();
            List<Button[,]> moves =aii.getAllMoveStates(piecee);
            
            foreach (Button[,] move in moves)
            {
                double moveRating = 0;
                moveRating= aii.alphabetarate(move, 1, double.MinValue, double.MaxValue, false);
                if (moveRating > bestScore)
                {
                    bestScore = moveRating;
                    movesBest.Clear();
                }

                if (moveRating == bestScore)
                {
                    movesBest.Add(move);
                }

            }
            if (movesBest.Count > 0)
            {
                Button[,] ab = movesBest[0];

                //Console.WriteLine("" + ab[2, 2].Tag.ToString());
                //Console.ReadLine();
                if (ab[2, 2].Tag.ToString().Equals("left"))
                {
                    setKey("left");
                }
                if (ab[2, 2].Tag.ToString().Equals("right"))
                {
                    setKey("right");
                }
                if (ab[2, 2].Tag.ToString().Equals("down"))
                {
                    setKey("down");
                }

                if (ab[2, 2].Tag.ToString().Equals("up"))
                {
                    setKey("up");
                }
            }
            else
            {
                timer3.Enabled = false;
                resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                insertRecord();
            }

        }




        private void button2_Click(object sender, EventArgs e)
        {
           timer3.Enabled = true;

           // MessageBox.Show("" + smoothness(piece) + " mono" + monotonicity(piece));
         /*  while (true)
           {
               Button[,] piecee = new Button[4, 4];

               double bestScore = double.MinValue;
               for (int j = 0; j < 4; j++)
               {
                   for (int i = 0; i < 4; i++)
                   {
                       piecee[i, j] = new Button();
                       piecee[i, j].Text = piece[i, j].Text;

                   }
               }


               List<Button[,]> movesBest = new List<Button[,]>();
               List<Button[,]> moves = aii.getAllMoveStates(piecee);

               foreach (Button[,] move in moves)
               {
                   double moveRating = 0;
                   moveRating = aii.alphabetarate(move, 20, double.MinValue, double.MaxValue, false);
                   if (moveRating > bestScore)
                   {
                       bestScore = moveRating;
                       movesBest.Clear();
                   }

                   if (moveRating == bestScore)
                   {
                       movesBest.Add(move);
                   }

               }

               Button[,] ab = movesBest[0];

               //Console.WriteLine("" + ab[2, 2].Tag.ToString());
               //Console.ReadLine();
               if (ab[2, 2].Tag.ToString().Equals("left"))
               {
                   setKey("left");
               }
               if (ab[2, 2].Tag.ToString().Equals("right"))
               {
                   setKey("right");
               }
               if (ab[2, 2].Tag.ToString().Equals("down"))
               {
                   setKey("down");
               }

               if (ab[2, 2].Tag.ToString().Equals("up"))
               {
                   setKey("up");
               }
               int sleepPause = 10;
               System.Threading.Thread.Sleep(sleepPause);
            }*/
        }
      
        private void setKey(string str)
        {
            if (str == "right")
            {
                goToRight();

                if (AvalibleRight)
                {
                    generateNumber();
                    refreshColor();
                }
                else if (piceEmpety() == false)
                {
                    Boolean ch = CheckFinishedGame();
                    if (ch == false)
                    {
                        // MessageBox.Show("finish");
                        
                        resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                        insertRecord();
                        timer3.Enabled = false;
                    }
                }

            }
            else if (str == "left")
            {
                goToLeft();

                if (AvalibleLeft)
                {
                    generateNumber();
                    refreshColor();
                }
                else if (piceEmpety() == false)
                {
                    Boolean ch = CheckFinishedGame();
                    if (ch == false)
                    {
                        // MessageBox.Show("finish");
                        
                        resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                        insertRecord();
                        timer3.Enabled = false;
                    }
                }


            }
            else if (str == "up")
            {
                goToUp();

                if (AvalibleTop)
                {
                    generateNumber();
                    refreshColor();
                }
                else if (piceEmpety() == false)
                {
                    Boolean ch = CheckFinishedGame();
                    if (ch == false)
                    {
                        
                        resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                        insertRecord();
                        timer3.Enabled = false;
                    }
                }


            }
            else if (str == "down")
            {
                goToDown();

                if (AvalibleDown)
                {
                    generateNumber();
                    refreshColor();
                }
                else if (piceEmpety() == false)
                {
                    Boolean ch = CheckFinishedGame();
                    if (ch == false)
                    {
                        
                        resultShow(btnScore.Text, MaxNumber().ToString(), btnBestRecord.Text, btnMove.Text, (label3.Text + ": " + label4.Text + ": " + label5.Text));
                        insertRecord();
                        timer3.Enabled = false;
                    }
                }


            }
        }

        private void label14_Click_1(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
            Game2048Orginal.Forms.Help help = new Game2048Orginal.Forms.Help();
            help.Show();
        }

    }
}
