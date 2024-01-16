using Kitchen.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kitchen.Context.Configuration.Configurations
{
    public class StimulationEntityTypeConfiguration : IEntityTypeConfiguration<Stimulation>
    {
        void IEntityTypeConfiguration<Stimulation>.Configure(EntityTypeBuilder<Stimulation> builder)
        {
            builder.ToTable("Stimulations");
            builder.HasKey(x => x.Id);
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Title).HasDatabaseName($"{nameof(Stimulation)}_{nameof(Stimulation.Title)}")
                .IsUnique()
                .HasFilter($"{nameof(Stimulation.DeletedAt)} is null");
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.HasMany(x => x.TurnOuts).WithOne(x => x.Stimulation).HasForeignKey(x => x.StimlationId);
        }
    }
}
