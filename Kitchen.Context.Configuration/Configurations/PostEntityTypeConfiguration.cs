using Kitchen.Context.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kitchen.Context.Configuration.Configurations
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        /// <summary>
        /// Конфигурация для <see cref="Post"/>
        /// </summary>
        void IEntityTypeConfiguration<Post>.Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);
            builder.PropertyAuditConfiguration();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
            builder.HasIndex(x => x.Title).HasDatabaseName($"{nameof(Post)}_{nameof(Post.Title)}")
                .IsUnique()
                .HasFilter($"{nameof(Post.DeletedAt)} is null");
            builder.Property(x => x.PayPerHour).IsRequired();
            builder.HasMany(x => x.Staffs).WithOne(x => x.Post).HasForeignKey(x => x.PostId);
        }
    }
}
