using Microsoft.Extensions.DependencyInjection;
using System;
using WinForm.FormManger;

namespace WinForm.Forms
{
    public partial class HomeForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public HomeForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            InitializeComponent();
        }

        private void HomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form? form = _serviceProvider.GetRequiredService<FManger>().currentForm;
            if (form.Equals(this))
            {
                Application.Exit();
                return;
            }
        }

        private void lbl_logout_Click(object sender, EventArgs e)
        {
            var fm = _serviceProvider.GetRequiredService<FManger>();
            fm.SetClientId(Guid.Empty);
            fm.LoginFormLauncher();
        }
    }
}
