using EfCore6.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDbContext.EntityConfigurations;


public class ParentEntityTypeConfiguration : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> parentConfiguration)
    {
        parentConfiguration.ToTable("parents", TestContext.DEFAULT_SCHEMA);

        parentConfiguration.HasKey(t => t.Id);
        parentConfiguration.Property(t => t.Id)
            .HasColumnName("id")
            .UseHiLo("parentseq", TestContext.DEFAULT_SCHEMA);

        parentConfiguration.Property(t => t.Name)
            .HasColumnName("name")
            .HasMaxLength(64)
            .IsRequired();

        parentConfiguration.Property<int>("_statusId")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("status_id")
            .IsRequired();

        parentConfiguration.HasOne(o => o.Status)
            .WithMany()
            .HasForeignKey("_statusId");

        var navigation = parentConfiguration.Metadata.FindNavigation(nameof(Parent.Children));
        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}