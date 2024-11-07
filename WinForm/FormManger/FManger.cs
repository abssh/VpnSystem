using Microsoft.Extensions.DependencyInjection;
using WinForm.Forms;

namespace WinForm.FormManger
{
    public class FManger
    {
        private readonly IServiceProvider _serviceProvider;
        private Guid clientId;
        internal Form currentForm;

        public FManger(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            
            currentForm = new Form();
            clientId = Guid.Empty;
        }

        public void SetClientId(Guid id)
        {
            clientId = id;
        }

        public void LoginFormLauncher ()
        {
            LoginForm lg = _serviceProvider.GetRequiredService<LoginForm>();
            lg.Location = currentForm.Location;

            var temp = currentForm;
            currentForm = lg;
            temp.Close();
            lg.Show();

        }

        public void SignupFormLauncher()
        {
            SignupForm sn = _serviceProvider.GetRequiredService<SignupForm>();
            sn.Location = currentForm.Location;

            var temp = currentForm;
            currentForm = sn;
            temp.Close();
            sn.Show();

        }

        public void HomeLauncher()
        {
            HomeForm home = _serviceProvider.GetRequiredService<HomeForm>();
            home.Location = currentForm.Location;

            var temp = currentForm;
            currentForm = home;
            temp.Close();
            home.Show();
        }

        
    }
}
