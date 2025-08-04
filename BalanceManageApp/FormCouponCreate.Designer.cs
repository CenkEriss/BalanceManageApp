namespace BalanceManageApp
{
    partial class FormCouponCreate
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
            button5 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ControlDarkDark;
            button5.BackgroundImageLayout = ImageLayout.None;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button5.ForeColor = Color.White;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(530, 191);
            button5.Name = "button5";
            button5.Size = new Size(248, 45);
            button5.TabIndex = 9;
            button5.Text = "Create Coupon";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(562, 133);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(178, 27);
            textBox1.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(12, 133);
            label2.Name = "label2";
            label2.Size = new Size(544, 22);
            label2.TabIndex = 11;
            label2.Text = "Please type the amount for the coupon you want to create:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(284, 43);
            label1.Name = "label1";
            label1.Size = new Size(184, 22);
            label1.TabIndex = 12;
            label1.Text = "Your Cash Balance:";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonFace;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.icons8_back_50;
            button1.Location = new Point(12, 14);
            button1.Name = "button1";
            button1.Size = new Size(65, 51);
            button1.TabIndex = 13;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.ForestGreen;
            label3.Location = new Point(468, 9);
            label3.Name = "label3";
            label3.Size = new Size(0, 22);
            label3.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(468, 44);
            label4.Name = "label4";
            label4.Size = new Size(184, 22);
            label4.TabIndex = 15;
            label4.Text = "Your Cash Balance:";
            // 
            // FormCouponCreate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(832, 438);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(button5);
            Name = "FormCouponCreate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CouponCreate";
            Load += FormCouponCreate_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button5;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Button button1;
        private Label label3;
        private Label label4;
    }
}