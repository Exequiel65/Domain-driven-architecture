using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Packgroup.Ecommerce.Aplication.Interface;
using Packgroup.Ecommerce.Aplication.Main;

namespace Packgroup.Ecommerce.Application.Test
{
    [TestClass]
    public class UserApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static IHost _host;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            _host = CreateHostBuilder().Build();
            _host.Start();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _host.StopAsync().GetAwaiter().GetResult();
            _host.Dispose();
        }


        [TestMethod]
        public void Authenticate_ParamsNotNound_ValidationError()
        {
            using var scope = _host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<IUsersApplication>();

            //Arrange
            var userName = string.Empty;
            var password = string.Empty;
            var expect = "Errores de Validación";

            //Act
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            //Assert
            Assert.AreEqual(expect, actual);
        }

        private static IHostBuilder CreateHostBuilder(string[] args = null) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddScoped<IUsersApplication, UserApplication>();
            });
    }
}