using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using WinForm.Controllers.FormManger;

namespace WinForm.Forms
{
    public partial class SignupForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public SignupForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            InitializeComponent();
            ClearError();
        }

        private void ClearError()
        {
            lbl_signup_error.Text = string.Empty;
            lbl_password_error.Text = string.Empty;
            lbl_username_error.Text = string.Empty;
            lbl_email_error.Text = string.Empty;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

        }

        private void llb_login_Click(object sender, EventArgs e)
        {
            _serviceProvider.GetRequiredService<FManger>().LoginFormLauncher();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            ClearError();

            if (!ValidateInput())
            {
                lbl_signup_error.Text = "invalid input";
                return;
            }


        }

        private const string emailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        private bool ValidateInput()
        {
            string username = this.txt_username.Text;
            if (username == "")
            {
                lbl_username_error.Text = "username can't be empty";
                return false;
            }

            string password = this.txt_password.Text;
            if (password == "")
            {
                lbl_password_error.Text = "password can't be empty";
                return false;
            }

            string email = this.txt_email.Text;
            if (email == "")
            {
                lbl_email_error.Text = "email can't be empty";
                return false;
            }
            if (!Regex.IsMatch(email, emailPattern))
            {
                lbl_email_error.Text = "invalid email address";
                return false;
            }

            return true;
        }

        private void SignupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form? form = _serviceProvider.GetRequiredService<FManger>().currentForm;
            if (form.Equals(this))
            {
                Application.Exit();
                return;
            }
        }
    }
}
