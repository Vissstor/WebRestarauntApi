using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestarauntDAL.Entities;

namespace Restaraunt.RestarauntSystem.DAL.DbContexts.Config
{
    public class PortionConfig : IEntityTypeConfiguration<Portion>

    {
        public void Configure(EntityTypeBuilder<Portion> builder)
        {
            builder
                .HasMany(hm => hm.OrderDetails)
                .WithOne(wo => wo.Portion)
                .HasForeignKey(wo => wo.PortionId)
                .IsRequired();
        }
    }
}
