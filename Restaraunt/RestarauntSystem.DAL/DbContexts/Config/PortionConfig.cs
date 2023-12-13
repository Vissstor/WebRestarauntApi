using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaraunt.RestarauntSystem.DAL.Entities;

namespace Restaraunt.RestarauntSystem.DAL.DbContexts.Config
{
    public class PortionConfig : IEntityTypeConfiguration<Portion>

    {
        public void Configure(EntityTypeBuilder<Portion> builder)
        {
            throw new NotImplementedException();
        }
    }
}
