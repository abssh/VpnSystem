using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WinForm.Forms;
using WinForm.FormManger;

namespace WinForm.Initialize
{
    public class Setup
    {
        IConfiguration config { get; }

        public Setup(IConfiguration configuration)
        {
            config = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<FManger>();
            services.AddTransient<LoginForm>();
            services.AddTransient<SignupForm>();
            services.AddTransient<HomeForm>();
        }
    }
}
