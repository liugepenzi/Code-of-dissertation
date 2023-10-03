namespace Program5
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.N_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tmax_textBox = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.coffA_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.coffB_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.uRead_textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PloteScale_textBox = new System.Windows.Forms.TextBox();
            this.PlotScale = new System.Windows.Forms.Label();
            this.TimeStep = new System.Windows.Forms.Label();
            this.TimeStep_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // N_textBox
            // 
            this.N_textBox.Location = new System.Drawing.Point(228, 66);
            this.N_textBox.Name = "N_textBox";
            this.N_textBox.Size = new System.Drawing.Size(100, 25);
            this.N_textBox.TabIndex = 0;
            this.N_textBox.TextChanged += new System.EventHandler(this.N_textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of points(N) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max time(s) :";
            // 
            // tmax_textBox
            // 
            this.tmax_textBox.Location = new System.Drawing.Point(228, 115);
            this.tmax_textBox.Name = "tmax_textBox";
            this.tmax_textBox.Size = new System.Drawing.Size(100, 25);
            this.tmax_textBox.TabIndex = 3;
            this.tmax_textBox.TextChanged += new System.EventHandler(this.tmax_textBox_TextChanged);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(123, 537);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 6;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "u_t +";
            // 
            // coffA_textBox
            // 
            this.coffA_textBox.Location = new System.Drawing.Point(225, 200);
            this.coffA_textBox.Name = "coffA_textBox";
            this.coffA_textBox.Size = new System.Drawing.Size(172, 25);
            this.coffA_textBox.TabIndex = 8;
            this.coffA_textBox.TextChanged += new System.EventHandler(this.coffA_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "u_x -";
            // 
            // coffB_textBox
            // 
            this.coffB_textBox.Location = new System.Drawing.Point(461, 200);
            this.coffB_textBox.Name = "coffB_textBox";
            this.coffB_textBox.Size = new System.Drawing.Size(190, 25);
            this.coffB_textBox.TabIndex = 10;
            this.coffB_textBox.TextChanged += new System.EventHandler(this.coffB_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(657, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "u_xx + u_xxx = 0";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 15);
            this.label7.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "KDV equation :";
            // 
            // uRead_textBox
            // 
            this.uRead_textBox.Location = new System.Drawing.Point(270, 246);
            this.uRead_textBox.Name = "uRead_textBox";
            this.uRead_textBox.Size = new System.Drawing.Size(300, 25);
            this.uRead_textBox.TabIndex = 14;
            this.uRead_textBox.TextChanged += new System.EventHandler(this.uRead_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(215, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Initial condition u(x,0) :";
            // 
            // PloteScale_textBox
            // 
            this.PloteScale_textBox.Location = new System.Drawing.Point(161, 293);
            this.PloteScale_textBox.Name = "PloteScale_textBox";
            this.PloteScale_textBox.Size = new System.Drawing.Size(100, 25);
            this.PloteScale_textBox.TabIndex = 16;
            // 
            // PlotScale
            // 
            this.PlotScale.AutoSize = true;
            this.PlotScale.Location = new System.Drawing.Point(47, 296);
            this.PlotScale.Name = "PlotScale";
            this.PlotScale.Size = new System.Drawing.Size(103, 15);
            this.PlotScale.TabIndex = 17;
            this.PlotScale.Text = "PloteScale :";
            this.PlotScale.Click += new System.EventHandler(this.label3_Click);
            // 
            // TimeStep
            // 
            this.TimeStep.AutoSize = true;
            this.TimeStep.Location = new System.Drawing.Point(46, 160);
            this.TimeStep.Name = "TimeStep";
            this.TimeStep.Size = new System.Drawing.Size(111, 15);
            this.TimeStep.TabIndex = 18;
            this.TimeStep.Text = "TimeStep(s) :";
            // 
            // TimeStep_textBox
            // 
            this.TimeStep_textBox.Location = new System.Drawing.Point(228, 160);
            this.TimeStep_textBox.Name = "TimeStep_textBox";
            this.TimeStep_textBox.Size = new System.Drawing.Size(100, 25);
            this.TimeStep_textBox.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 637);
            this.Controls.Add(this.TimeStep_textBox);
            this.Controls.Add(this.TimeStep);
            this.Controls.Add(this.PlotScale);
            this.Controls.Add(this.PloteScale_textBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.uRead_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.coffB_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.coffA_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.tmax_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.N_textBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox N_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tmax_textBox;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox coffA_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox coffB_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox uRead_textBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PloteScale_textBox;
        private System.Windows.Forms.Label PlotScale;
        private System.Windows.Forms.Label TimeStep;
        private System.Windows.Forms.TextBox TimeStep_textBox;
    }
}

