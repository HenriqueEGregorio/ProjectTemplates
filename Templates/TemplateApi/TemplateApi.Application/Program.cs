using TemplateApi.Infrastructure.Data;
using TemplateApi.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TemplateApi.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddControllers()
    .AddCustom400ErrorMessages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( x => 
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = $"{builder.Environment.ApplicationName} - {builder.Environment.EnvironmentName}",
        Version = "v1",
        Contact = new OpenApiContact { },
    });

    var xmlFile = $"{builder.Environment.ApplicationName}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    x.IncludeXmlComments(xmlPath);
});

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseGlobalExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
