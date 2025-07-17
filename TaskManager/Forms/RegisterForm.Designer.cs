namespace TaskManager.WinForms.Forms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirm;
        private TextBox txtConfirm;
        private Button btnRegister;
        private Button btnCancel;

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
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblConfirm = new Label();
            this.txtConfirm = new TextBox();
            this.btnRegister = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // 
            // lblUsername
            // 
            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new Point(20, 20);
            this.lblUsername.AutoSize = true;

            this.txtUsername.Location = new Point(110, 17);
            this.txtUsername.Size = new Size(180, 23);

            // 
            // lblPassword
            // 
            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new Point(20, 55);
            this.lblPassword.AutoSize = true;

            this.txtPassword.Location = new Point(110, 52);
            this.txtPassword.Size = new Size(180, 23);
            this.txtPassword.UseSystemPasswordChar = true;

            // 
            // lblConfirm
            // 
            this.lblConfirm.Text = "Confirm:";
            this.lblConfirm.Location = new Point(20, 90);
            this.lblConfirm.AutoSize = true;

            this.txtConfirm.Location = new Point(110, 87);
            this.txtConfirm.Size = new Size(180, 23);
            this.txtConfirm.UseSystemPasswordChar = true;

            // 
            // btnRegister
            // 
            this.btnRegister.Text = "Register";
            this.btnRegister.Location = new Point(110, 130);
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new Point(200, 130);
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // 
            // RegisterForm
            // 
            this.ClientSize = new Size(330, 180);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Register";
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}