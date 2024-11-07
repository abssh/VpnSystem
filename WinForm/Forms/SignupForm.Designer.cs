namespace WinForm.Forms
{
    partial class SignupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignupForm));
            pan_main = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            llb_login = new Label();
            lbl_signup_error = new Label();
            btn_signup = new Button();
            panel1 = new Panel();
            lbl_email_error = new Label();
            txt_email = new TextBox();
            lbl_email_descriptor = new Label();
            pan_password = new Panel();
            lbl_password_error = new Label();
            txt_password = new TextBox();
            lbl_password_descriptor = new Label();
            pan_username = new Panel();
            lbl_username_error = new Label();
            txt_username = new TextBox();
            lbl_username_descriptor = new Label();
            pan_main.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            pan_password.SuspendLayout();
            pan_username.SuspendLayout();
            SuspendLayout();
            // 
            // pan_main
            // 
            pan_main.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pan_main.BackColor = Color.GhostWhite;
            pan_main.Controls.Add(label1);
            pan_main.Controls.Add(panel2);
            pan_main.Controls.Add(panel1);
            pan_main.Controls.Add(pan_password);
            pan_main.Controls.Add(pan_username);
            pan_main.Font = new Font("Rubik", 9F);
            pan_main.Location = new Point(25, 25);
            pan_main.Name = "pan_main";
            pan_main.Size = new Size(380, 530);
            pan_main.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 46);
            label1.Name = "label1";
            label1.Size = new Size(155, 47);
            label1.TabIndex = 24;
            label1.Text = "Sign up";
            // 
            // panel2
            // 
            panel2.Controls.Add(llb_login);
            panel2.Controls.Add(lbl_signup_error);
            panel2.Controls.Add(btn_signup);
            panel2.Location = new Point(24, 380);
            panel2.Name = "panel2";
            panel2.Size = new Size(336, 129);
            panel2.TabIndex = 15;
            // 
            // llb_login
            // 
            llb_login.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            llb_login.AutoSize = true;
            llb_login.Font = new Font("Rubik", 9F, FontStyle.Underline);
            llb_login.ForeColor = Color.Navy;
            llb_login.Location = new Point(0, 103);
            llb_login.Name = "llb_login";
            llb_login.Size = new Size(98, 23);
            llb_login.TabIndex = 40;
            llb_login.Text = "ورود به حساب";
            llb_login.Click += llb_login_Click;
            // 
            // lbl_signup_error
            // 
            lbl_signup_error.AutoSize = true;
            lbl_signup_error.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold);
            lbl_signup_error.ForeColor = Color.Firebrick;
            lbl_signup_error.Location = new Point(0, 48);
            lbl_signup_error.Name = "lbl_signup_error";
            lbl_signup_error.Size = new Size(180, 19);
            lbl_signup_error.TabIndex = 30;
            lbl_signup_error.Text = "this is an error message";
            // 
            // btn_signup
            // 
            btn_signup.AutoSize = true;
            btn_signup.BackColor = Color.Navy;
            btn_signup.Font = new Font("Rubik", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_signup.ForeColor = Color.White;
            btn_signup.Location = new Point(149, 0);
            btn_signup.Name = "btn_signup";
            btn_signup.Size = new Size(149, 45);
            btn_signup.TabIndex = 3;
            btn_signup.Text = "ثبت نام";
            btn_signup.UseVisualStyleBackColor = false;
            btn_signup.Click += btn_signup_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(lbl_email_error);
            panel1.Controls.Add(txt_email);
            panel1.Controls.Add(lbl_email_descriptor);
            panel1.Location = new Point(24, 299);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 57);
            panel1.TabIndex = 10;
            // 
            // lbl_email_error
            // 
            lbl_email_error.AutoSize = true;
            lbl_email_error.Dock = DockStyle.Bottom;
            lbl_email_error.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold);
            lbl_email_error.ForeColor = Color.Firebrick;
            lbl_email_error.Location = new Point(0, 38);
            lbl_email_error.Name = "lbl_email_error";
            lbl_email_error.Size = new Size(180, 19);
            lbl_email_error.TabIndex = 20;
            lbl_email_error.Text = "this is an error message";
            // 
            // txt_email
            // 
            txt_email.Dock = DockStyle.Top;
            txt_email.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_email.Location = new Point(0, 0);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(279, 30);
            txt_email.TabIndex = 2;
            // 
            // lbl_email_descriptor
            // 
            lbl_email_descriptor.AutoSize = true;
            lbl_email_descriptor.Dock = DockStyle.Right;
            lbl_email_descriptor.Font = new Font("Rubik", 10.5F);
            lbl_email_descriptor.Location = new Point(279, 0);
            lbl_email_descriptor.Name = "lbl_email_descriptor";
            lbl_email_descriptor.RightToLeft = RightToLeft.Yes;
            lbl_email_descriptor.Size = new Size(57, 27);
            lbl_email_descriptor.TabIndex = 10;
            lbl_email_descriptor.Text = "ایمیل:";
            // 
            // pan_password
            // 
            pan_password.AutoSize = true;
            pan_password.Controls.Add(lbl_password_error);
            pan_password.Controls.Add(txt_password);
            pan_password.Controls.Add(lbl_password_descriptor);
            pan_password.Location = new Point(24, 216);
            pan_password.Name = "pan_password";
            pan_password.Size = new Size(336, 57);
            pan_password.TabIndex = 10;
            // 
            // lbl_password_error
            // 
            lbl_password_error.AutoSize = true;
            lbl_password_error.Dock = DockStyle.Bottom;
            lbl_password_error.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold);
            lbl_password_error.ForeColor = Color.Firebrick;
            lbl_password_error.Location = new Point(0, 38);
            lbl_password_error.Name = "lbl_password_error";
            lbl_password_error.Size = new Size(180, 19);
            lbl_password_error.TabIndex = 20;
            lbl_password_error.Text = "this is an error message";
            // 
            // txt_password
            // 
            txt_password.Dock = DockStyle.Top;
            txt_password.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_password.Location = new Point(0, 0);
            txt_password.Name = "txt_password";
            txt_password.Size = new Size(261, 30);
            txt_password.TabIndex = 2;
            // 
            // lbl_password_descriptor
            // 
            lbl_password_descriptor.AutoSize = true;
            lbl_password_descriptor.Dock = DockStyle.Right;
            lbl_password_descriptor.Font = new Font("Rubik", 10.5F);
            lbl_password_descriptor.Location = new Point(261, 0);
            lbl_password_descriptor.Name = "lbl_password_descriptor";
            lbl_password_descriptor.RightToLeft = RightToLeft.Yes;
            lbl_password_descriptor.Size = new Size(75, 27);
            lbl_password_descriptor.TabIndex = 10;
            lbl_password_descriptor.Text = "رمز عبور:";
            // 
            // pan_username
            // 
            pan_username.AutoSize = true;
            pan_username.Controls.Add(lbl_username_error);
            pan_username.Controls.Add(txt_username);
            pan_username.Controls.Add(lbl_username_descriptor);
            pan_username.Location = new Point(24, 133);
            pan_username.Name = "pan_username";
            pan_username.Size = new Size(336, 57);
            pan_username.TabIndex = 0;
            // 
            // lbl_username_error
            // 
            lbl_username_error.AutoSize = true;
            lbl_username_error.Dock = DockStyle.Bottom;
            lbl_username_error.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold);
            lbl_username_error.ForeColor = Color.Firebrick;
            lbl_username_error.Location = new Point(0, 38);
            lbl_username_error.Name = "lbl_username_error";
            lbl_username_error.Size = new Size(180, 19);
            lbl_username_error.TabIndex = 22;
            lbl_username_error.Text = "this is an error message";
            // 
            // txt_username
            // 
            txt_username.Dock = DockStyle.Top;
            txt_username.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_username.Location = new Point(0, 0);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(249, 30);
            txt_username.TabIndex = 1;
            // 
            // lbl_username_descriptor
            // 
            lbl_username_descriptor.AutoSize = true;
            lbl_username_descriptor.Dock = DockStyle.Right;
            lbl_username_descriptor.Font = new Font("Rubik", 10.5F);
            lbl_username_descriptor.Location = new Point(249, 0);
            lbl_username_descriptor.Name = "lbl_username_descriptor";
            lbl_username_descriptor.RightToLeft = RightToLeft.Yes;
            lbl_username_descriptor.Size = new Size(87, 27);
            lbl_username_descriptor.TabIndex = 100;
            lbl_username_descriptor.Text = "نام کاربری:";
            // 
            // SignupForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Navy;
            ClientSize = new Size(432, 583);
            Controls.Add(pan_main);
            Font = new Font("Microsoft Sans Serif", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(450, 630);
            MinimizeBox = false;
            MinimumSize = new Size(450, 630);
            Name = "SignupForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            FormClosing += SignupForm_FormClosing;
            pan_main.ResumeLayout(false);
            pan_main.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pan_password.ResumeLayout(false);
            pan_password.PerformLayout();
            pan_username.ResumeLayout(false);
            pan_username.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pan_main;
        private Panel pan_username;
        private TextBox txt_username;
        private Label lbl_username_descriptor;
        private Label lbl_username_error;
        private Panel pan_password;
        private Label lbl_password_error;
        private TextBox txt_password;
        private Label lbl_password_descriptor;
        private Panel panel2;
        private Button btn_signup;
        private Label lbl_signup_error;
        private Label label1;
        private Label llb_login;
        private Panel panel1;
        private Label lbl_email_error;
        private TextBox txt_email;
        private Label lbl_email_descriptor;
    }
}
