using Microsoft.Extensions.DependencyInjection;
using DataDomain.Persistence.AppService;
using WinForm.FormManger;

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
            txt_password.Enabled = false;
            txt_password.ForeColor = Color.Gray;
            txt_username.Enabled = false;
            txt_username.ForeColor = Color.Gray;
            btn_login.Enabled = false;
        }

        private void Resume()
        {
            txt_password.Enabled = true;
            txt_password.ForeColor = Color.Black;
            txt_username.Enabled = true;
            txt_username.ForeColor = Color.Black;
            btn_login.Enabled = true;

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
            (bool ok, Guid id, string msg) resp;
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

            if (resp.ok)
            {
                
                var fm = _serviceProvider.GetRequiredService<FManger>();
                fm.SetClientId(resp.id);
                fm.HomeLauncher();
                return;
            }

            lbl_login_error.Text = resp.msg;
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
    }
}
