using Microsoft.Extensions.DependencyInjection;
using DataDomain.Persistence.AppService;
using WinForm.Controllers.FormManger;

using DataDomain.Data.entity;
using DataDomain.Types.States;
using WinForm.Controllers.AppState;

namespace WinForm.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public LoginForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            InitializeComponent();
            ClearError();
        }

        private void ClearError()
        {
            lbl_login_error.Text = string.Empty;
            lbl_password_error.Text = string.Empty;
            lbl_username_error.Text = string.Empty;
        }

        private void Pause()
        {
            txt_password.ReadOnly = true;
            txt_username.ReadOnly = true;
            btn_login.Visible = false;
            btn_login.Enabled = false;
            txt_password.ForeColor = Color.Gray;
            txt_username.ForeColor = Color.Gray;

            Update();
        }

        private void Resume()
        {
            txt_password.ReadOnly = false;
            txt_username.ReadOnly = false;
            btn_login.Visible = true;
            btn_login.Enabled = true;
            txt_password.ForeColor = Color.Black;
            txt_username.ForeColor = Color.Black;

            Update();
        }

        private void llb_signup_Click(object sender, EventArgs e)
        {
            _serviceProvider.GetRequiredService<FManger>().SignupFormLauncher();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            ClearError();

            if (!ValidateInput())
            {
                lbl_login_error.Text = "invalid input";
                return;
            }

            Pause();

            (bool ok, Client? cli, StateObject state) resp;
            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider;
                IAuthService authService = service.GetRequiredService<IAuthService>();

                resp = authService.LoginWithUsernameAndPassword(
                    txt_username.Text,
                    txt_password.Text
                    );
            }

            Resume();

            if (!resp.ok)
            {
                switch (resp.state.stateCode)
                {
                    case StateCode.None:
                        break;
                    case StateCode.UsernameNotFound:
                        lbl_username_error.Text = resp.state.message;
                        break;
                    case StateCode.WrongPassword:
                        lbl_password_error.Text = resp.state.message;
                        break;
                }

                lbl_login_error.Text = "couldn't login";

                return;
            }
            _serviceProvider.GetRequiredService<StateObserver>().SetClient(resp.cli);
            _serviceProvider.GetRequiredService<FManger>().HomeLauncher();
        }

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

            return true;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form? form = _serviceProvider.GetRequiredService<FManger>().currentForm;
            if (form.Equals(this))
            {
                Application.Exit();
                return;
            }
        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            lbl_username_error.Text = string.Empty;
            lbl_login_error.Text = string.Empty;
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            lbl_password_error.Text = string.Empty;
            lbl_login_error.Text = string.Empty;
        }

        private void txt_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btn_login_Click(sender, e);
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btn_login_Click(sender, e);
            }
        }
    }
}
