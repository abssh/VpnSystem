namespace WinForm.Forms
{
    partial class HomeForm
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
            rbtn_connect_button = new CustomControls.RoundedButton();
            panel1 = new Panel();
            lbl_logout = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // rbtn_connect_button
            // 
            rbtn_connect_button.BackColor = Color.White;
            rbtn_connect_button.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            rbtn_connect_button.ForeColor = Color.Navy;
            rbtn_connect_button.Location = new Point(495, 25);
            rbtn_connect_button.Name = "rbtn_connect_button";
            rbtn_connect_button.Size = new Size(300, 300);
            rbtn_connect_button.TabIndex = 3;
            rbtn_connect_button.Text = "Off";
            rbtn_connect_button.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(lbl_logout);
            panel1.Dock = DockStyle.Left;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(405, 603);
            panel1.TabIndex = 4;
            // 
            // lbl_logout
            // 
            lbl_logout.AutoSize = true;
            lbl_logout.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbl_logout.ForeColor = Color.FromArgb(200, 200, 230);
            lbl_logout.Location = new Point(36, 534);
            lbl_logout.Name = "lbl_logout";
            lbl_logout.Size = new Size(124, 35);
            lbl_logout.TabIndex = 5;
            lbl_logout.Text = "< log out";
            lbl_logout.Click += lbl_logout_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 603);
            Controls.Add(panel1);
            Controls.Add(rbtn_connect_button);
            Name = "HomeForm";
            StartPosition = FormStartPosition.Manual;
            Text = "HomeForm";
            FormClosing += HomeForm_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CustomControls.RoundedButton rbtn_connect_button;
        private Panel panel1;
        private Label lbl_logout;
    }
}