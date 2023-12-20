using RestarauntBLL.Mapping;
using RestarauntBLL.Services;
using RestarauntBLL.Services.Abstract;
using RestarauntDAL.Repositories;
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
