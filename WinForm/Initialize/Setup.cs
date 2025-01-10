using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WinForm.Forms;
using WinForm.Controllers.FormManger;
using WinForm.Controllers.AppState;
using DataDomain.Data.Context;
using Microsoft.EntityFrameworkCore;
using DataDomain.Persistence.AppService;
using DataDomain.Persistence.Repo;

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
            services.AddDbContext<PGContext>(options =>
                options.UseNpgsql(config.GetConnectionString("PGContext")));

            services.AddScoped<IAuthService, AuthService>();

            services.AddSingleton<FManger>();
            services.AddSingleton<StateObserver>();
            services.AddTransient<LoginForm>();
            services.AddTransient<SignupForm>();
            services.AddTransient<HomeForm>();
        }
    }
}
