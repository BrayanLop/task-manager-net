using TaskManager.Infrastructure.Interfaces;
using TaskManager.Infrastructure.Repositories;
using TaskManager.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerConfiguration();
if (Environment.GetEnvironmentVariable("CLIENT_ID") == "")
{

}

//builder.Services.AddScoped<IConfigurationInterface, EnviromentRepository>();
builder.Services.AddScoped<IConfigurationInterface, SettingsRepository>();
builder.Services.AddScoped<ICacheRepository, CacheRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

// Redirección automática a /swagger
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

app.MapControllers();

// Health endpoint
app.MapGet("/health", () => "pong");

app.Run();app.Run();