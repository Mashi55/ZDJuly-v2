
namespace WinFormsApp1
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
            panel1 = new System.Windows.Forms.Panel();
            button2 = new System.Windows.Forms.Button();
            comboBox1 = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            comboBox2 = new System.Windows.Forms.ComboBox();
            label18 = new System.Windows.Forms.Label();
            comboBox3 = new System.Windows.Forms.ComboBox();
            label19 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.White;
            panel1.Location = new System.Drawing.Point(130, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(461, 380);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(938, 471);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(122, 45);
            button2.TabIndex = 4;
            button2.Text = "Rajzol";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = System.Drawing.Color.White;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1-Aldous Broder ", "2-Hunt and Kill", "3-Binary Tree", "4-Sidewinder", "5-Wave function Collapse", "6-Primm", "7-Kruskal" });
            comboBox1.Location = new System.Drawing.Point(748, 52);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(155, 23);
            comboBox1.TabIndex = 11;
            comboBox1.Text = "1-Aldous Broder ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = System.Drawing.Color.White;
            label6.Font = new System.Drawing.Font("Segoe UI", 19.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(13, 3);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(149, 36);
            label6.TabIndex = 13;
            label6.Text = "Generáló A.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(81, 395);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(110, 37);
            label7.TabIndex = 14;
            label7.Text = "Előnyei";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label9.Location = new System.Drawing.Point(447, 395);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(144, 37);
            label9.TabIndex = 16;
            label9.Text = "Hátrányai";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(89, 444);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(12, 15);
            label8.TabIndex = 17;
            label8.Text = "-";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(447, 444);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(12, 15);
            label10.TabIndex = 18;
            label10.Text = "-";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label11.Location = new System.Drawing.Point(764, 170);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(112, 37);
            label11.TabIndex = 19;
            label11.Text = "Lépései:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(764, 224);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(18, 15);
            label12.TabIndex = 20;
            label12.Text = "1-";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(764, 277);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(18, 15);
            label13.TabIndex = 21;
            label13.Text = "2-";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(764, 332);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(18, 15);
            label14.TabIndex = 22;
            label14.Text = "3-";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(764, 389);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(18, 15);
            label15.TabIndex = 23;
            label15.Text = "4-";
            // 
            // comboBox2
            // 
            comboBox2.BackColor = System.Drawing.Color.White;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "1-N/E/S/W", "2-Random", "3-Nincs megoldas" });
            comboBox2.Location = new System.Drawing.Point(748, 134);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(156, 23);
            comboBox2.TabIndex = 26;
            comboBox2.Text = "3-Nincs megoldas";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = System.Drawing.Color.White;
            label18.Font = new System.Drawing.Font("Segoe UI", 19.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label18.Location = new System.Drawing.Point(748, 94);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(148, 36);
            label18.TabIndex = 27;
            label18.Text = "Megoldó A.";
            label18.Click += label18_Click;
            // 
            // comboBox3
            // 
            comboBox3.BackColor = System.Drawing.Color.White;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "0ms", "10ms", "20ms", "50ms", "100ms", "200ms" });
            comboBox3.Location = new System.Drawing.Point(1066, 49);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(59, 23);
            comboBox3.TabIndex = 30;
            comboBox3.Text = "0ms";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = System.Drawing.Color.White;
            label19.Font = new System.Drawing.Font("Segoe UI", 19.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label19.Location = new System.Drawing.Point(290, 3);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(138, 36);
            label19.TabIndex = 31;
            label19.Text = "Késleltetés";
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.White;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label19);
            panel2.Location = new System.Drawing.Point(733, 9);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(433, 158);
            panel2.TabIndex = 32;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1204, 619);
            Controls.Add(label18);
            Controls.Add(comboBox2);
            Controls.Add(comboBox3);
            Controls.Add(comboBox1);
            Controls.Add(panel2);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(button2);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Labirintus algoritmusok";
            Load += Form1_Load_1;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel2;
    }
}

