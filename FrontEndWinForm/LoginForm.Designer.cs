namespace FrontEndWinForm
{
    partial class LoginForm
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
            panel1 = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            panel12 = new Panel();
            ButLog = new Button();
            panel11 = new Panel();
            panel10 = new Panel();
            txtPassword = new TextBox();
            panel9 = new Panel();
            panel8 = new Panel();
            txtUsername = new TextBox();
            panel7 = new Panel();
            panel6 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            panel4 = new Panel();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel12.SuspendLayout();
            panel10.SuspendLayout();
            panel8.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(58, 117, 196);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(367, 653);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(367, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(738, 653);
            panel2.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel12);
            panel5.Controls.Add(panel11);
            panel5.Controls.Add(panel10);
            panel5.Controls.Add(panel9);
            panel5.Controls.Add(panel8);
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 56);
            panel5.Name = "panel5";
            panel5.Size = new Size(738, 459);
            panel5.TabIndex = 2;
            // 
            // panel12
            // 
            panel12.Controls.Add(ButLog);
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(113, 359);
            panel12.Name = "panel12";
            panel12.Size = new Size(625, 45);
            panel12.TabIndex = 8;
            // 
            // ButLog
            // 
            ButLog.Dock = DockStyle.Fill;
            ButLog.FlatStyle = FlatStyle.Popup;
            ButLog.ForeColor = Color.White;
            ButLog.Location = new Point(0, 0);
            ButLog.Name = "ButLog";
            ButLog.Size = new Size(625, 45);
            ButLog.TabIndex = 0;
            ButLog.Text = "Log in";
            ButLog.UseVisualStyleBackColor = true;
            ButLog.Click += ButLog_Click;
            // 
            // panel11
            // 
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(113, 198);
            panel11.Name = "panel11";
            panel11.Size = new Size(625, 161);
            panel11.TabIndex = 7;
            // 
            // panel10
            // 
            panel10.Controls.Add(txtPassword);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(113, 145);
            panel10.Name = "panel10";
            panel10.Size = new Size(625, 53);
            panel10.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(26, 59, 93);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Dock = DockStyle.Left;
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = SystemColors.InactiveBorder;
            txtPassword.Location = new Point(0, 0);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(625, 38);
            txtPassword.TabIndex = 0;
            txtPassword.Text = "Password";
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.KeyDown += txtPassword_KeyDown;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // panel9
            // 
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(113, 129);
            panel9.Name = "panel9";
            panel9.Size = new Size(625, 16);
            panel9.TabIndex = 5;
            // 
            // panel8
            // 
            panel8.Controls.Add(txtUsername);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(113, 76);
            panel8.Name = "panel8";
            panel8.Size = new Size(625, 53);
            panel8.TabIndex = 4;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(26, 59, 93);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Dock = DockStyle.Left;
            txtUsername.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = SystemColors.InactiveBorder;
            txtUsername.Location = new Point(0, 0);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(625, 38);
            txtUsername.TabIndex = 0;
            txtUsername.Text = "Username";
            txtUsername.Enter += txtUsername_Enter;
            txtUsername.KeyDown += txtUsername_KeyDown;
            txtUsername.Leave += txtUsername_Leave;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(113, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(625, 76);
            panel7.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Left;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(113, 459);
            panel6.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(738, 56);
            panel3.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(276, 0);
            label1.Name = "label1";
            label1.Size = new Size(92, 41);
            label1.TabIndex = 1;
            label1.Text = "Login";
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(276, 56);
            panel4.TabIndex = 0;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 59, 93);
            ClientSize = new Size(1182, 653);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "LoginForm";
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel8;
        private TextBox txtUsername;
        private Panel panel7;
        private Panel panel6;
        private Label label1;
        private Panel panel10;
        private TextBox txtPassword;
        private Panel panel9;
        private Panel panel12;
        private Button ButLog;
        private Panel panel11;
    }
}