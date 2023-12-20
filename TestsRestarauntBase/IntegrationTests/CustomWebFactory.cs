using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaraunt.RestarauntSystem.DAL.DbContexts;

namespace TestsRestaraunt.IntegrationTests
{
    public class CustomWebFactory<TProgram> :
     WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor =
                    services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<RestarauntContext>));

                if (dbContextDescriptor is not null)
                    services.Remove(dbContextDescriptor);

                services.AddDbContext<RestarauntContext>(options =>
                {
                    options.UseInMemoryDatabase(databaseName: "IntegrationTest");
                });
            });
        }
    }
}