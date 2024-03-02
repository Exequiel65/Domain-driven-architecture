using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Packgroup.Ecommerce.Aplication.Interface.UserCases;
using Packgroup.Ecommerce.Aplication.UseCases.Users;

namespace Packgroup.Ecommerce.Application.Test
{
    [TestClass]
    public class UserApplicationTest
    {
        private static WebApplicationFactory<Program> _factory = null;
        private static IServiceScopeFactory _scopeFactory = null;
        private static IHost _host;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_ParamsNotNound_ValidationError()
        {
            using var scope = _factory.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<IUsersApplication>();

            //Arrange
            var userName = string.Empty;
            var password = string.Empty;
            var expect = "Errores de validación";

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