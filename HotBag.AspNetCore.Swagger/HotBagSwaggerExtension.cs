using HotBag.AspNetCore.Swagger.SwaggerDocumentFilter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace HotBag.AspNetCore.Swagger
{
    public static class HotBagSwaggerExtension
    {
        public static IApplicationBuilder UseHotBagSwagger(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"HotBag Enterprise Application Framework");
            });
            return app;
        }

        public static IServiceCollection AddHotBagSwagger(this IServiceCollection service, Info option)
        {

            // Register the Swagger generator, defining 1 or more Swagger documents
            option.Contact = new Contact
            {
                Name = "Pradeep Raj Thapaliya",
                Email = "pradeep.thapaliya95@gmail.com",
                Url = "https://www.pradeeprajthapaliya.com.np"
            };

            option.License = new License
            {
                Name = "Git Source Url",
                Url = "https://github.com/pradeept95/HotBag-Core"
            };



            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", option);

                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
                c.DocumentFilter<CustomDocumentFilter>();
                c.OperationFilter<GenericOperationFilter>();
            });

            return service;
        }
    } 
}
