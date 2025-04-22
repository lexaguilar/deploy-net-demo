using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using TaskManagerAPI.Core.Application.Interfaces;
using TaskManagerAPI.Core.Application.Services;
using TaskManagerAPI.Core.Domain.Interfaces;
using TaskManagerAPI.Core.Infrastructure.Data;
using TaskManagerAPI.Core.Infrastructure.Repositories;

namespace TaskManagerAPI.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureLogger(this IServiceCollection services)
    {
        LogManager.Setup().LoadConfigurationFromFile("nlog.config");
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddNLog();
        });
    }
    
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))        
            connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
    }
    
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "TaskManagerAPI", Version = "v1" });
        });
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ITareaService, TareaService>();
        // Agrega aquí otros servicios según sea necesario
    }
}