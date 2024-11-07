using DataDomain.Data.Context;
using DataDomain.Persistence.Repo.Interfaces;
using DataDomain.Persistence.Repo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DataDomain.Persistence.AppService;

namespace DataDomain
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

            services.AddScoped<DSContext, PGContext>();
            services.AddScoped<IClientRepo, ClientRepo>();
            services.AddScoped<IAuthService, AuthService>();
        }

    }
}
