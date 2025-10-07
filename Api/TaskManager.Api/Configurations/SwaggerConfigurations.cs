using Microsoft.OpenApi.Models;

namespace TaskManager.Api.Configurations
{
    public static class SwaggerConfigurations
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Task Manager API",
                    Version = "v1",
                    Description = "API para la gestión de tareas que permite administrar y organizar tareas de manera eficiente",
                    Contact = new OpenApiContact
                    {
                        Name = "Task Manager Team"
                    }
                });

                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });
        }

        public static void UseSwaggerConfiguration(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API V1");
                c.RoutePrefix = "swagger";
            });
        }
    }
}