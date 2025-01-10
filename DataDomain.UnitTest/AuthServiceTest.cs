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
            (bool ok, Client? cli, StateObject state) resp;

            // username constraint
            resp = authService.Signup("signup-test-cli1", "", "sample1@test.com");
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.cli, Is.Null);
            Assert.That(resp.state, Is.SameAs(BadStates.UniqueConstraintDefault));

            utils.ClearChanges();

            // email constraint
            resp = authService.Signup("signup-test-cli2", "", "example@test.com");
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.cli, Is.Null);
            Assert.That(resp.state, Is.SameAs(BadStates.UniqueConstraintDefault));

            utils.ClearChanges();

            // correct signup
            resp = authService.Signup("signup-test-cli3", "", "signup-test-sample3@test.com");
            Assert.That(resp.ok, Is.True);
            Assert.That(resp.cli, Is.Not.Null);
            Assert.That(resp.state, Is.SameAs(BadStates.None));
        }

        [Test]
        public void ActivateEmailTest()
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            PGContext context = services.GetRequiredService<PGContext>();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            IUtils utils = services.GetRequiredService<IUtils>();
            var cli = utils.AddClient("activate-email-cli", "randomPass", "example@test.com");

            IAuthService authService = services.GetRequiredService<IAuthService>();
            (bool ok, StateObject state) resp;

            // wrong client
            resp = authService.SendActivationEmail(Guid.NewGuid());
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.state, Is.SameAs(BadStates.ClientNotFound));

            utils.ClearChanges();

            // correct send activation email
            resp = authService.SendActivationEmail(cli.Id);
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.state, Is.SameAs(BadStates.WrongSMTPConfig));

            // to fast
            resp = authService.SendActivationEmail(cli.Id);
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.state, Is.SameAs(BadStates.TooFast));

            Code? code = utils.GetCode(cli.Id);
            if (code == null)
            {
                Assert.Fail("empty code");
                return;
            }

            // wrong code
            resp = authService.ActivateEmail(cli, "000000");
            Assert.That(resp.ok, Is.False);
            Assert.That(resp.state, Is.SameAs(BadStates.WrongCode));

            utils.ClearChanges();

            // correct code
            resp = authService.ActivateEmail(cli, code.Value);
            Assert.That(resp.ok, Is.True);
            Assert.That(resp.state, Is.SameAs(BadStates.None));





        }
    }
}