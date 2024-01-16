using Kitchen.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kitchen.Context.Configuration.Configurations
{
    public class CuisineEntityTypeConfiguration : IEntityTypeConfiguration<Cuisine>
    {
        void IEntityTypeConfiguration<Cuisine>.Configure(EntityTypeBuilder<Cuisine> builder)
        {
            builder.ToTable("Cuisines");
            builder.HasKey(x => x.Id);
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Address).HasDatabaseName($"{nameof(Cuisine)}_{nameof(Cuisine.Address)}")
                .IsUnique()
                .HasFilter($"{nameof(Cuisine.DeletedAt)} is null");
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.Type).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ClosingTime).HasMaxLength(8).IsRequired();
            builder.Property(x => x.OpeningTime).HasMaxLength(8).IsRequired();
            builder.HasMany(x => x.TurnOuts).WithOne(x => x.Cuisine).HasForeignKey(x => x.CuisineId);
        }
    }
}
