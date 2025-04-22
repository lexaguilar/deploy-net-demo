using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using TaskManagerAPI.API.Extensions;
using TaskManagerAPI.Core.Infrastructure.Data;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.ConfigureLogger();
    builder.Services.ConfigureDbContext(builder.Configuration);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.ConfigureSwagger();
    builder.Services.ConfigureServices();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    // Apply migrations
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }

    app.MapControllers();


    app.Run();
   
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
throw;
}
finally
{
    LogManager.Shutdown();
}