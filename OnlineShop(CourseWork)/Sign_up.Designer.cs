
namespace OnlineShop_CourseWork_
{
    partial class Sign_up
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sign_up));
            this.Login_label = new System.Windows.Forms.Label();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.closedEye = new System.Windows.Forms.PictureBox();
            this.openedEye = new System.Windows.Forms.PictureBox();
            this.sign_up_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closedEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openedEye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Login_label
            // 
            this.Login_label.AutoSize = true;
            this.Login_label.BackColor = System.Drawing.Color.Transparent;
            this.Login_label.Font = new System.Drawing.Font("GOST type A", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Login_label.ForeColor = System.Drawing.Color.Yellow;
            this.Login_label.Location = new System.Drawing.Point(864, 321);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(178, 84);
            this.Login_label.TabIndex = 3;
            this.Login_label.Text = "Login:";
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(874, 408);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(150, 27);
            this.textBox_login.TabIndex = 4;
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.BackColor = System.Drawing.Color.Transparent;
            this.Password_label.Font = new System.Drawing.Font("GOST type A", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Password_label.ForeColor = System.Drawing.Color.Yellow;
            this.Password_label.Location = new System.Drawing.Point(797, 438);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(310, 84);
            this.Password_label.TabIndex = 5;
            this.Password_label.Text = "Password:";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(874, 525);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(150, 27);
            this.textBox_password.TabIndex = 6;
            // 
            // closedEye
            // 
            this.closedEye.BackColor = System.Drawing.Color.Transparent;
            this.closedEye.Image = ((System.Drawing.Image)(resources.GetObject("closedEye.Image")));
            this.closedEye.InitialImage = ((System.Drawing.Image)(resources.GetObject("closedEye.InitialImage")));
            this.closedEye.Location = new System.Drawing.Point(1056, 515);
            this.closedEye.Name = "closedEye";
            this.closedEye.Size = new System.Drawing.Size(50, 50);
            this.closedEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closedEye.TabIndex = 7;
            this.closedEye.TabStop = false;
            this.closedEye.Click += new System.EventHandler(this.closedEye_Click);
            // 
            // openedEye
            // 
            this.openedEye.BackColor = System.Drawing.Color.Transparent;
            this.openedEye.Image = ((System.Drawing.Image)(resources.GetObject("openedEye.Image")));
            this.openedEye.Location = new System.Drawing.Point(1056, 515);
            this.openedEye.Name = "openedEye";
            this.openedEye.Size = new System.Drawing.Size(50, 50);
            this.openedEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.openedEye.TabIndex = 8;
            this.openedEye.TabStop = false;
            this.openedEye.Click += new System.EventHandler(this.openedEye_Click);
            // 
            // sign_up_button
            // 
            this.sign_up_button.BackColor = System.Drawing.Color.DodgerBlue;
            this.sign_up_button.Font = new System.Drawing.Font("GOST type A", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sign_up_button.Location = new System.Drawing.Point(832, 581);
            this.sign_up_button.Name = "sign_up_button";
            this.sign_up_button.Size = new System.Drawing.Size(243, 95);
            this.sign_up_button.TabIndex = 9;
            this.sign_up_button.Text = "Sign up";
            this.sign_up_button.UseVisualStyleBackColor = false;
            this.sign_up_button.Click += new System.EventHandler(this.sign_up_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::OnlineShop_CourseWork_.Properties.Resources.back;
            this.pictureBox1.Location = new System.Drawing.Point(1045, 507);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 58);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Sign_up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.sign_up_button);
            this.Controls.Add(this.closedEye);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.Login_label);
            this.Controls.Add(this.openedEye);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Sign_up";
            this.Text = "Sign_up";
            this.Load += new System.EventHandler(this.Sign_up_Load);
            ((System.ComponentModel.ISupportInitialize)(this.closedEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openedEye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.PictureBox closedEye;
        private System.Windows.Forms.PictureBox openedEye;
        private System.Windows.Forms.Button sign_up_button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}