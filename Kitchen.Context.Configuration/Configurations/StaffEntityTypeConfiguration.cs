using Kitchen.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Kitchen.Context.Configuration.Configurations
{
    public class StaffEntityTypeConfiguration : IEntityTypeConfiguration<Staff>
    {
        void IEntityTypeConfiguration<Staff>.Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staffs");
            builder.HasKey(x => x.Id);
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Patronymic).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PostId).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(x => x.Email)
            .IsUnique()
            .HasDatabaseName($"{nameof(Staff)}_{nameof(Staff.Email)}")
                .HasFilter($"{nameof(Staff.DeletedAt)} is null");
            builder.Property(x => x.DateOfHiring).IsRequired();
            builder.HasMany(x => x.TurnOuts).WithOne(x => x.Staff).HasForeignKey(x => x.StaffId);
        }
    }
}
