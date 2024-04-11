using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateApi.Domain.Entities;

namespace TemplateApi.Infrastructure.Configuration
{
    public class ExampleEntityConfiguration : IEntityTypeConfiguration<ExampleEntity>
    {
        public void Configure(EntityTypeBuilder<ExampleEntity> builder)
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

            builder.Property(w => w.Age)
                .HasColumnName("Age");

            builder.Property(w => w.UpdateDate)
                .HasColumnName("UpdateDate");

            builder.Property(w => w.CreationDate)
                .HasColumnName("CreationDate");
        }
    }
}
