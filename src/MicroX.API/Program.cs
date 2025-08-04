using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using MicroX.API.Extensions;
using MicroX.API.Middlewares;
using MicroX.Application.Interfaces;
using MicroX.Infrastructure;
using MicroX.Infrastructure.Services;
using Serilog;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Serilog configuration
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/microx-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Host.UseSerilog();

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("MicroXDB")); // or UseSqlServer(...connectionString)

builder.Services.AddSingleton<IConnectionMultiplexer>(
    _ => ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis")!)
);

builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();

// Swagger + XML comments
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

builder.Services.AddMicroXServices();

// Redis Health Check
var redisConnection = builder.Configuration.GetConnectionString("Redis");
Log.Information("Current Redis Config: {Redis}", redisConnection);

builder.Services.AddHealthChecks()
    .AddRedis(redisConnection, name: "redis");

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>(); 

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Health Check endpoint
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var result = System.Text.Json.JsonSerializer.Serialize(
            new
            {
                status = report.Status.ToString(),
                totalDuration = report.TotalDuration,
                entries = report.Entries.ToDictionary(
                    e => e.Key,
                    e => new
                    {
                        status = e.Value.Status.ToString(),
                        duration = e.Value.Duration,
                        description = e.Value.Description,
                        data = e.Value.Data,
                        exception = e.Value.Exception?.Message,
                        tags = e.Value.Tags
                    })
            });
        await context.Response.WriteAsync(result);
    }
});

app.Run();

public partial class Program { }
