﻿namespace лаба3_ТРПО
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            panel1 = new MyPanel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(88, 23);
            button1.TabIndex = 0;
            button1.Text = "Точки";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 41);
            button2.Name = "button2";
            button2.Size = new Size(88, 23);
            button2.TabIndex = 1;
            button2.Text = "Параметры";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.Location = new Point(12, 99);
            button3.Name = "button3";
            button3.Size = new Size(88, 23);
            button3.TabIndex = 3;
            button3.Text = "Ломанная";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Location = new Point(12, 70);
            button4.Name = "button4";
            button4.Size = new Size(88, 23);
            button4.TabIndex = 2;
            button4.Text = "Кривая";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.White;
            button6.Location = new Point(12, 186);
            button6.Name = "button6";
            button6.Size = new Size(88, 23);
            button6.TabIndex = 6;
            button6.Text = "Движение";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.White;
            button7.Location = new Point(12, 157);
            button7.Name = "button7";
            button7.Size = new Size(88, 23);
            button7.TabIndex = 5;
            button7.Text = "Заполненная";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.White;
            button8.Location = new Point(12, 128);
            button8.Name = "button8";
            button8.Size = new Size(88, 23);
            button8.TabIndex = 4;
            button8.Text = "Безье";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.White;
            button9.Location = new Point(12, 215);
            button9.Name = "button9";
            button9.Size = new Size(88, 23);
            button9.TabIndex = 8;
            button9.Text = "Очистить";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Location = new Point(117, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(659, 390);
            panel1.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(button9);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private MyPanel panel1;
    }
}
