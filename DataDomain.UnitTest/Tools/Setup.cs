using DataDomain.Data.Context;
using DataDomain.Persistence.AppService;
using DataDomain.Persistence.Repo;
using DataDomain.Types.ConfigTypes;
using EntityFramework.Exceptions.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataDomain.UnitTest.Tools
{
    public class Setup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PGContext>(options =>
                options.UseSqlite("DataSource=:memory:")
                .UseExceptionProcessor());

            SMTPConfig smtp = new SMTPConfig();
            smtp.Port = "0";
            smtp.Host = "";
            smtp.Username = "";
            smtp.Password = "";

            services.AddSingleton(smtp);
            services.AddScoped<DSContext, PGContext>();
            services.AddScoped<IClientRepo, ClientRepo>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUtils, Utils>();
        }
    }
}
