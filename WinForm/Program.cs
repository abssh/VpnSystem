using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinForm.Controllers.FormManger;

namespace WinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.AddJsonFile("appsettings.json", false, true);
                })
                .ConfigureServices((context, services) =>
                {
                    var DDSetup = new DataDomain.Setup(context.Configuration);
                    DDSetup.ConfigureServices(services);
                    var WFSetup = new Initialize.Setup(context.Configuration);
                    WFSetup.ConfigureServices(services);
                })
                .Build();


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var fm = host.Services.GetRequiredService<FManger>();
            fm.LoginFormLauncher();
            Application.Run();
        }
    }
}