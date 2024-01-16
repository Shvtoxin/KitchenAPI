using Kitchen.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kitchen.Context.Configuration.Configurations
{
    public class TurnOutEntityTypeConfiguration : IEntityTypeConfiguration<TurnOut>
    {
        void IEntityTypeConfiguration<TurnOut>.Configure(EntityTypeBuilder<TurnOut> builder)
        {
            builder.ToTable("TurnOuts");
            builder.HasKey(x => x.Id);
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.CuisineId).IsRequired();
            builder.Property(x => x.StaffId).IsRequired();
            builder.Property(x => x.TypeOfTurnoutId).IsRequired();
            builder.Property(x => x.OpeningTime).IsRequired();
        }
    }
}
