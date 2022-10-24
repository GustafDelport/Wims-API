using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wims.Domain.Entities;

namespace Wims.Infrastructure.Database_Access.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("varchar(25)");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("varchar(25)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("nvarchar(100)");

            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("nvarchar(256)");
        }
    }
}
