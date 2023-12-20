using Microsoft.EntityFrameworkCore;
using Restaraunt.RestarauntSystem.DAL.DbContexts;
using RestarauntDAL.Entities;
using RestarauntDAL.Repositories;

namespace TestsRestaraunt
{
    public abstract class TestsBaseData
    {
        protected readonly RestarauntContext context;
        protected readonly IGenericRepository<Dish> repository;

        public TestsBaseData()
        {
            var options = new DbContextOptionsBuilder<RestarauntContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            context = new RestarauntContext(options);
            repository = new GenericRepository<Dish>(context);
        }
        
    }
}