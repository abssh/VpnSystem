using Microsoft.Extensions.DependencyInjection;
using System;
using WinForm.Controllers.AppState;
using WinForm.Controllers.FormManger;

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
            _serviceProvider.GetRequiredService<StateObserver>().SetClient(null);
            _serviceProvider.GetRequiredService<FManger>().LoginFormLauncher();
            
            
        }
    }
}
