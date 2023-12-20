using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Restaraunt.RestarauntSystem.DAL.DbContexts;


namespace TestsRestaraunt.IntegrationTests
{
    public abstract class TestsDataBaseIntegrationTests : IClassFixture<CustomWebFactory<Program>>
    {
        protected readonly CustomWebFactory<Program> factory;
        protected readonly RestarauntContext context;
        protected readonly HttpClient client;
        protected readonly IConfiguration configuration;

        public TestsDataBaseIntegrationTests(CustomWebFactory<Program> factory)
        {
            this.factory = factory;

            var scope = this.factory.Services.CreateScope();

            this.context = scope.ServiceProvider.GetRequiredService<RestarauntContext>();

            this.configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

            this.client = this.factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}
