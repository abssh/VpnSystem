using DataDomain.Data.Context;
using DataDomain.UnitTest.Tools;
using EntityFramework.Exceptions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DataDomain.UnitTest
{
    public class ClientTableTest
    {
        private IHost host;

        [SetUp]
        public void Start()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    var setup = new Setup();
                    setup.ConfigureServices(services);
                })
                .Build();
        }

        [TearDown]
        public void Down()
        {
            host?.Dispose();
        }

        [Test]
        public void EmailUniqueConstraints()
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            PGContext context = services.GetRequiredService<PGContext>();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            IUtils utils = services.GetRequiredService<IUtils>();
            utils.AddClient("test-cli-1", "", "sample@test.com");

            UniqueConstraintException? exception = null;
            try
            {
                utils.AddClient("test-cli_2", "", "sample@test.com");
            }
            catch (UniqueConstraintException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception, "Email constraint bypassed");
        }

        [Test]
        public void UsernameUniqueConstraints()
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            PGContext context = services.GetRequiredService<PGContext>();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            IUtils utils = services.GetRequiredService<IUtils>();
            utils.AddClient("sample", "", "ex1@gm.com");

            UniqueConstraintException? exception = null;
            try
            {
                utils.AddClient("sample", "", "ex2@gm.com");
            }
            catch (UniqueConstraintException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception, "Username constraint bypassed");
        }
    }
}