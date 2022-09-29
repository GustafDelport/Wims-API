using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wims.Domain.Entities;

namespace Wims.Infrastructure.Database_Access.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "dbo");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier ");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(25)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar(250)");

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category);
        }
    }
}
