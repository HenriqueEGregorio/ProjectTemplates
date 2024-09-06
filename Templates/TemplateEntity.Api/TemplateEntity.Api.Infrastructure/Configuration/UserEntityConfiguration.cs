using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateEntity.Api.Domain.Entities;

namespace TemplateEntity.Api.Infrastructure.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.UserEntity>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.UserEntity> builder)
    {
        builder.ToTable("ExampleEntity");

        builder.HasKey(w => w.Id)
            .HasName("Id");

        builder.Property(w => w.Id)
            .HasColumnName("Id");

        builder.Property(w => w.Sequence)
            .HasColumnName("Sequence")
            .UseSerialColumn();

        builder.Property(w => w.Name)
            .HasColumnName("Name");

        builder.Property(w => w.Document)
            .HasColumnName("Document");

        builder.Property(w => w.Password)
            .HasColumnName("Password");

        builder.Property(w => w.UpdateAt)
            .HasColumnName("UpdateDate");

        builder.Property(w => w.CreationAt)
            .HasColumnName("CreationDate");
    }
}
