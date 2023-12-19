using Microsoft.EntityFrameworkCore;
using Restaraunt.RestarauntSystem.BLL.Mapping;
using Restaraunt.RestarauntSystem.BLL.Services;
using Restaraunt.RestarauntSystem.BLL.Services.Abstract;
using Restaraunt.RestarauntSystem.DAL.Repositories;
using System.Reflection;

namespace Restaraunt
{
    public static class ServiceCollectionExtensions
    {
      
        public static void RegisterCustomServices(this IServiceCollection services)
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
            services.AddAutoMapper(Assembly.GetAssembly(typeof(IngredientProfile)));
        }
    }
}
