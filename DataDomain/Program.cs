using DataDomain.Persistence.AppService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace DataDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("entery point");


            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var setup = new Setup(context.Configuration);
                    setup.ConfigureServices(services);
                })
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                IAuthService authService = services.GetRequiredService<IAuthService>();
                
                var resp = authService.Login("abs", "randomPass");
                if (resp.cli == null)
                {
                    Console.WriteLine($"{resp.state.message}");
                    return;
                }

                //var resp2 = authService.SendActivationEmail(resp.cli.Id);
                var resp2 = authService.ActivateEmail(resp.cli, "597154");
            }

            Console.WriteLine("end point");
        }
    }


}
