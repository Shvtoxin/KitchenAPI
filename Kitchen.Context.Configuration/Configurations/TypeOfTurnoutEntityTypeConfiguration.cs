using Kitchen.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kitchen.Context.Configuration.Configurations
{
    public class TypeOfTurnoutEntityTypeConfiguration : IEntityTypeConfiguration<TypeOfTurnout>
    {
        void IEntityTypeConfiguration<TypeOfTurnout>.Configure(EntityTypeBuilder<TypeOfTurnout> builder)
        {
            builder.ToTable("TypeOfTurnouts");
            builder.HasKey(x => x.Id);
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.HasMany(x => x.TurnOuts).WithOne(x => x.Type).HasForeignKey(x => x.TypeOfTurnoutId);
        }
    }
}
