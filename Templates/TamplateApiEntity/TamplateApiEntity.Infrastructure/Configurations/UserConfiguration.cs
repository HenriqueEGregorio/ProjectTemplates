using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TamplateApiEntity.Domain.Entities;

namespace TamplateApiEntity.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Sequence)
            .HasColumnName("SEQUENCE")
            .UseSerialColumn();

        builder.Property(x => x.Name)
            .HasColumnName("NAME");

        builder.Property(x => x.Email)
            .HasColumnName("EMAIL");

        builder.Property(x => x.Password)
            .HasColumnName("PASSWORD");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CREATEDAT")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UpdateAt)
            .HasColumnName("UPDATEAT")
            .ValueGeneratedOnUpdate();
    }
}
