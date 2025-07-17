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
using TaskManager.Core.Service.Interface;

namespace TaskManager.WinForms.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly IUserService _userService;
        public RegisterForm(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Συμπλήρωσε όλα τα πεδία.", "Προσοχή");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Οι κωδικοί δεν ταιριάζουν.", "Σφάλμα");
                return;
            }

            try
            {
                await _userService.RegisterAsync(username, password);
                MessageBox.Show("Ο λογαριασμός δημιουργήθηκε!", "Επιτυχία");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (UserRegistrationException ex)
            {
                MessageBox.Show(ex.Message, "Αποτυχία εγγραφής");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Απρόβλεπτο σφάλμα: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
