using Microsoft.EntityFrameworkCore;
using TemplateEntity.Api.Domain.Entities;
using TemplateEntity.Api.Infrastructure.Configuration;

namespace TemplateEntity.Api.Infrastructure.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.UserEntity> ExampleEntity { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
    }
}
