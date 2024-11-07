namespace WinForm.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pan_main = new Panel();
            lbl_login_descriptor = new Label();
            panel2 = new Panel();
            label1 = new Label();
            llb_signup = new Label();
            lbl_login_error = new Label();
            btn_login = new Button();
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
            pan_password.SuspendLayout();
            pan_username.SuspendLayout();
            SuspendLayout();
            // 
            // pan_main
            // 
            pan_main.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pan_main.BackColor = Color.GhostWhite;
            pan_main.Controls.Add(lbl_login_descriptor);
            pan_main.Controls.Add(panel2);
            pan_main.Controls.Add(pan_password);
            pan_main.Controls.Add(pan_username);
            pan_main.Font = new Font("Leelawadee UI", 9F);
            pan_main.Location = new Point(25, 25);
            pan_main.Name = "pan_main";
            pan_main.Size = new Size(380, 530);
            pan_main.TabIndex = 0;
            // 
            // lbl_login_descriptor
            // 
            lbl_login_descriptor.AutoSize = true;
            lbl_login_descriptor.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Bold);
            lbl_login_descriptor.Location = new Point(24, 46);
            lbl_login_descriptor.Name = "lbl_login_descriptor";
            lbl_login_descriptor.Size = new Size(120, 47);
            lbl_login_descriptor.TabIndex = 24;
            lbl_login_descriptor.Text = "log in";
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(llb_signup);
            panel2.Controls.Add(lbl_login_error);
            panel2.Controls.Add(btn_login);
            panel2.Location = new Point(24, 359);
            panel2.Name = "panel2";
            panel2.Size = new Size(336, 148);
            panel2.TabIndex = 15;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Rubik", 9F, FontStyle.Underline);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(119, 122);
            label1.Name = "label1";
            label1.Size = new Size(88, 23);
            label1.TabIndex = 41;
            label1.Text = "فراموشی رمز";
            // 
            // llb_signup
            // 
            llb_signup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            llb_signup.AutoSize = true;
            llb_signup.Font = new Font("Rubik", 9F, FontStyle.Underline);
            llb_signup.ForeColor = Color.Navy;
            llb_signup.Location = new Point(0, 122);
            llb_signup.Name = "llb_signup";
            llb_signup.Size = new Size(95, 23);
            llb_signup.TabIndex = 40;
            llb_signup.Text = "ساخت حساب";
            llb_signup.Click += llb_signup_Click;
            // 
            // lbl_login_error
            // 
            lbl_login_error.AutoSize = true;
            lbl_login_error.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold);
            lbl_login_error.ForeColor = Color.Firebrick;
            lbl_login_error.Location = new Point(0, 48);
            lbl_login_error.Name = "lbl_login_error";
            lbl_login_error.Size = new Size(180, 19);
            lbl_login_error.TabIndex = 30;
            lbl_login_error.Text = "this is an error message";
            // 
            // btn_login
            // 
            btn_login.AutoSize = true;
            btn_login.BackColor = Color.Navy;
            btn_login.Font = new Font("Rubik", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_login.ForeColor = Color.White;
            btn_login.Location = new Point(174, 0);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(124, 45);
            btn_login.TabIndex = 3;
            btn_login.Text = "ورود";
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
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
            txt_username.Size = new Size(251, 30);
            txt_username.TabIndex = 1;
            // 
            // lbl_username_descriptor
            // 
            lbl_username_descriptor.AutoSize = true;
            lbl_username_descriptor.Dock = DockStyle.Right;
            lbl_username_descriptor.Font = new Font("Rubik", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_username_descriptor.Location = new Point(251, 0);
            lbl_username_descriptor.Name = "lbl_username_descriptor";
            lbl_username_descriptor.RightToLeft = RightToLeft.Yes;
            lbl_username_descriptor.Size = new Size(85, 26);
            lbl_username_descriptor.TabIndex = 100;
            lbl_username_descriptor.Text = "نام کاربری:";
            // 
            // LoginForm
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
            Name = "LoginForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.Manual;
            Text = "Log in";
            FormClosing += LoginForm_FormClosing;
            pan_main.ResumeLayout(false);
            pan_main.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Button btn_login;
        private Label lbl_login_error;
        private Label lbl_login_descriptor;
        private Label llb_signup;
        private Label label1;
    }
}
