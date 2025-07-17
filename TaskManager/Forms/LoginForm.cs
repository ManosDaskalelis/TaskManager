using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.Core.Exceptions.UserExceptions;
using TaskManager.Core.Models;
using TaskManager.Core.Service.Interface;

namespace TaskManager.WinForms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;

        public UserEntity? LoggedInUser { get; private set; }

        public LoginForm(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var username = txtUsername.Text.Trim();
                var password = txtPassword.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Συμπλήρωσε όλα τα πεδία.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = await _userService.AuthenticateAsync(username, password);
                if (user == null)
                {
                    MessageBox.Show("Λάθος όνομα χρήστη ή κωδικός.", "Αποτυχία", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoggedInUser = user;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (UserAuthenticationException ex)
            {
                MessageBox.Show(ex.Message, "Αποτυχία σύνδεσης", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Κάτι πήγε στραβά.\n\n" + ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm(_userService);
            registerForm.ShowDialog();
        }
    }
}
