using EfCore6.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDbContext.EntityConfigurations;

class StatusEntityTypeConfiguration
    : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> statusConfiguration)
    {
        statusConfiguration.ToTable("status", TestContext.DEFAULT_SCHEMA);

        statusConfiguration.HasKey(o => o.Id);

        statusConfiguration.Property(o => o.Id)
            .HasColumnName("id")
            .ValueGeneratedNever()
            .IsRequired();

        statusConfiguration.Property(o => o.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();
    }
}