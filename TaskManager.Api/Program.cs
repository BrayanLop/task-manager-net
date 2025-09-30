using TaskManager.Infrastructure.Interfaces;
using TaskManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
if (Environment.GetEnvironmentVariable("CLIENT_ID") == "")
{

}

builder.Services.AddScoped<IConfigurationInterface, EnviromentRepository>();
builder.Services.AddScoped<IConfigurationInterface, SettingsRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();