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
                var resp = authService.Signup("hello1", "randomPass1", "exa@gm.com");
                Console.WriteLine(resp.state.message);
            }

            Console.WriteLine("end point");
        }
    }


}
