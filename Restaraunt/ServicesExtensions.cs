using RestarauntBLL.Services.Abstract;
using RestarauntBLL.Services;
using RestarauntDAL.Repositories;
using System.Reflection;
using RestarauntBLL.Mapping;
using Microsoft.EntityFrameworkCore;
using Restaraunt.RestarauntSystem.DAL.DbContexts;

namespace Restaraunt
{
    public static class ServicesExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IPortionService, PortionService>();
            services.AddScoped<IOrderService, OrderService>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(DishProfile)));
        }

        public static void AddRestaurantDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestarauntContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RestarauntContext")));
        }
    }
}
