using EfCore6.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDbContext.EntityConfigurations;
public class ChildEntityTypeConfiguration : IEntityTypeConfiguration<Child>
{
    public void Configure(EntityTypeBuilder<Child> childConfiguration)
    {
        childConfiguration.ToTable("children", TestContext.DEFAULT_SCHEMA);

        childConfiguration.HasKey(o => o.Id);

        childConfiguration.Ignore(b => b.DomainEvents);

        childConfiguration.Property(o => o.Id)
            .UseHiLo("childrenitemseq");

        childConfiguration.Property<int>("ParentId")
            .HasColumnName("parent_id")
            .IsRequired();

        childConfiguration
            .Property<string>("_description")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("description")
            .IsRequired();

        childConfiguration
            .Property<bool>("_isValid")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("is_valid")
            .IsRequired();

    }
}

