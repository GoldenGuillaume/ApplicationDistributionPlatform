using DistributionPlatform.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistributionPlatform.Infrastructure.Context.Configurations
{
    internal class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("applications");
            builder.HasComment("Table containing application saved.");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id").UseIdentityAlwaysColumn();
            builder.Property(e => e.CreationDate).IsRequired().HasColumnName("creation_date").HasColumnType("timestamp").HasDefaultValueSql("now()");
            builder.Property(e => e.ApplicationName).IsRequired().HasColumnName("application_name").HasMaxLength(70);
            builder.Property(e => e.Thumbnail).IsRequired().HasColumnName("thumbnail");
            builder.Property(e => e.SourceFiles).IsRequired().HasColumnName("source_files");
        }
    }
}
