using Microsoft.EntityFrameworkCore;
using RestarauntDAL.Entities;

namespace Restaraunt.RestarauntSystem.DAL.DbContexts.Config
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderDetail> builder)
        {
            builder
                .HasKey(e => new { e.OrderId, e.PortionId });
        }
    }
}
