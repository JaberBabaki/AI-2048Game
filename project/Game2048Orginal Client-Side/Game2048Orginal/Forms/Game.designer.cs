using _Game2048Orginal.cc;

namespace Game2048Orginal.Forms
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMove = new System.Windows.Forms.Label();
            this.btnBestRecord = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnScore = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.circlePictureBox1 = new CirclePictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox1)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(-7, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 38);
            this.panel2.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gabrielle", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(119, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 24);
            this.label9.TabIndex = 28;
            this.label9.Text = "2048";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Gadugi", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(116, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 86);
            this.button2.TabIndex = 30;
            this.button2.Text = "Run AI";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(246, 428);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 17);
            this.label8.TabIndex = 71;
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(225, 428);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 17);
            this.label7.TabIndex = 70;
            this.label7.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gabrielle", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(167, 429);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 69;
            this.label6.Text = "Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(256, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 17);
            this.label5.TabIndex = 68;
            this.label5.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(234, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 67;
            this.label4.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(212, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 17);
            this.label3.TabIndex = 66;
            this.label3.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gabrielle", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 65;
            this.label1.Text = "Move";
            // 
            // btnMove
            // 
            this.btnMove.AutoSize = true;
            this.btnMove.Font = new System.Drawing.Font("Georgia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMove.ForeColor = System.Drawing.Color.Black;
            this.btnMove.Location = new System.Drawing.Point(56, 429);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(16, 17);
            this.btnMove.TabIndex = 64;
            this.btnMove.Text = "0";
            // 
            // btnBestRecord
            // 
            this.btnBestRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.btnBestRecord.FlatAppearance.BorderSize = 0;
            this.btnBestRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBestRecord.Font = new System.Drawing.Font("Gabrielle", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnBestRecord.ForeColor = System.Drawing.Color.White;
            this.btnBestRecord.Location = new System.Drawing.Point(211, 89);
            this.btnBestRecord.Name = "btnBestRecord";
            this.btnBestRecord.Size = new System.Drawing.Size(69, 36);
            this.btnBestRecord.TabIndex = 63;
            this.btnBestRecord.Text = "0";
            this.btnBestRecord.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBestRecord.UseVisualStyleBackColor = false;
            this.btnBestRecord.Click += new System.EventHandler(this.btnBestRecord_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(10, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 266);
            this.panel3.TabIndex = 57;
            // 
            // btnScore
            // 
            this.btnScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.btnScore.FlatAppearance.BorderSize = 0;
            this.btnScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScore.Font = new System.Drawing.Font("Gabrielle", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnScore.ForeColor = System.Drawing.Color.White;
            this.btnScore.Location = new System.Drawing.Point(166, 56);
            this.btnScore.Name = "btnScore";
            this.btnScore.Size = new System.Drawing.Size(114, 28);
            this.btnScore.TabIndex = 62;
            this.btnScore.Text = "0";
            this.btnScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnScore.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Gabrielle", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(93)))), ((int)(((byte)(85)))));
            this.label11.Location = new System.Drawing.Point(2, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 55);
            this.label11.TabIndex = 59;
            this.label11.Text = "2048";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(166, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 36);
            this.button1.TabIndex = 58;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gabrielle", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(7, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 14);
            this.label2.TabIndex = 61;
            this.label2.Text = "Swipe to move tiles and get to 2048 tile !";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Gabrielle", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(228)))), ((int)(((byte)(218)))));
            this.button4.Location = new System.Drawing.Point(166, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 23);
            this.button4.TabIndex = 60;
            this.button4.Text = "SCORE";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 120000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 300;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.panel1.Controls.Add(this.circlePictureBox1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(2, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 411);
            this.panel1.TabIndex = 73;
            this.panel1.Visible = false;
            // 
            // circlePictureBox1
            // 
            this.circlePictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.circlePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("circlePictureBox1.Image")));
            this.circlePictureBox1.Location = new System.Drawing.Point(108, 7);
            this.circlePictureBox1.Name = "circlePictureBox1";
            this.circlePictureBox1.Size = new System.Drawing.Size(58, 58);
            this.circlePictureBox1.TabIndex = 14;
            this.circlePictureBox1.TabStop = false;
            this.circlePictureBox1.Click += new System.EventHandler(this.circlePictureBox1_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Gabrielle", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(8, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 26);
            this.label10.TabIndex = 16;
            this.label10.Text = "label10";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.pictureBox4);
            this.panel9.Controls.Add(this.label16);
            this.panel9.Location = new System.Drawing.Point(3, 169);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(159, 31);
            this.panel9.TabIndex = 15;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // label16
            // 
            this.label16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label16.Font = new System.Drawing.Font("Gabrielle", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(43, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 25);
            this.label16.TabIndex = 9;
            this.label16.Text = "Exit";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Gray;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel10.Location = new System.Drawing.Point(6, 200);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(160, 2);
            this.panel10.TabIndex = 14;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pictureBox3);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Location = new System.Drawing.Point(3, 134);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(159, 31);
            this.panel7.TabIndex = 13;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // label15
            // 
            this.label15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label15.Font = new System.Drawing.Font("Gabrielle", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label15.Location = new System.Drawing.Point(43, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 26);
            this.label15.TabIndex = 9;
            this.label15.Text = "Help";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Click += new System.EventHandler(this.label15_Click_1);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Gray;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Location = new System.Drawing.Point(6, 165);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(160, 2);
            this.panel8.TabIndex = 11;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Location = new System.Drawing.Point(3, 97);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(159, 32);
            this.panel5.TabIndex = 10;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label14
            // 
            this.label14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label14.Font = new System.Drawing.Font("Gabrielle", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(42, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 27);
            this.label14.TabIndex = 9;
            this.label14.Text = "About me";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Click += new System.EventHandler(this.label14_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Gabrielle", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(98, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "2048";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Gabrielle", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(6, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Best Record :";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gray;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Location = new System.Drawing.Point(6, 129);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(160, 2);
            this.panel6.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(6, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(160, 2);
            this.panel4.TabIndex = 5;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(233)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(287, 455);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnBestRecord);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnScore);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel2);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(303, 494);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048";
            this.Activated += new System.EventHandler(this.Game_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circlePictureBox1)).EndInit();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnMove;
        public System.Windows.Forms.Button btnBestRecord;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnScore;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private CirclePictureBox circlePictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
    }
}

