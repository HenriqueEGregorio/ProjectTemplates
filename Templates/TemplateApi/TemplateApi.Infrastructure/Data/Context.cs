using Microsoft.EntityFrameworkCore;
using TemplateApi.Domain.Entities;
using TemplateApi.Infrastructure.Configuration;

namespace TemplateApi.Infrastructure.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<ExampleEntity> ExampleEntity { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleEntityConfiguration).Assembly);
    }
}
