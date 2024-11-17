using DataDomain.Data.Context;
using DataDomain.Data.entity;
using DataDomain.Persistence.AppService;
using DataDomain.Types.States;
using DataDomain.UnitTest.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace DataDomain.UnitTest
{
    public class AuthServiceTest
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
        public void LoginTest()
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            PGContext context = services.GetRequiredService<PGContext>();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            IUtils utils = services.GetRequiredService<IUtils>();
            utils.AddClient("login-test-cli", "randomPass", "example@test.com");

            IAuthService authService = services.GetRequiredService<IAuthService>();
            (bool ok, Client? cli, StateObject state) resp;

            // wrong username
            resp = authService.Login("login-test-cli_wrong", "randomPass");
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.cli, Is.Null);
            Assert.That(resp.state, Is.SameAs(BadStates.UsernameNotFound));

            // wrong password
            resp = authService.Login("login-test-cli", "randomPassWrong");
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.cli, Is.Null);
            Assert.That(resp.state, Is.SameAs(BadStates.WrongPassword));

            // correct login
            resp = authService.Login("login-test-cli", "randomPass");
            Assert.That(resp.ok, Is.True);
            Assert.That(resp.cli, Is.Not.Null);
            Assert.That(resp.state, Is.SameAs(BadStates.None));
        }

        [Test]
        public void SignUpTest()
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            PGContext context = services.GetRequiredService<PGContext>();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            IUtils utils = services.GetRequiredService<IUtils>();
            utils.AddClient("signup-test-cli1", "randomPass", "example@test.com");

            IAuthService authService = services.GetRequiredService<IAuthService>();
            (bool ok, StateObject state) resp;

            // username constraint
            resp = authService.Signup("signup-test-cli1", "", "sample1@test.com");
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.state, Is.SameAs(BadStates.UniqueConstraintDefault));

            // email constraint
            resp = authService.Signup("signup-test-cli2", "", "example@test.com");
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.state, Is.SameAs(BadStates.UniqueConstraintDefault));

            // correct signup
            resp = authService.Signup("signup-test-cli1", "", "sample1@test.com");
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.state, Is.SameAs(BadStates.UniqueConstraintDefault));
        }
    }
}