using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;

namespace Ponente.Api.Extensions
{
    public static class SwaggerServiceExtensions
    {
        private static string PonenteApiVersion = "v1";
        private static string PonenteApiName = "Ponente API";
        private static string PonenteApiDesc = "Welcome to Ponente API";

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(PonenteApiVersion, new Info
                {
                    Version = PonenteApiVersion,
                    Title = PonenteApiName,
                    Description = PonenteApiDesc
                });

                // Swagger 2.+ support
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                // Authorize => Bearer <token>
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", PonenteApiName);
                c.DocumentTitle = PonenteApiDesc;
                c.DocExpansion(DocExpansion.None);
            });
            return app;
        }
    }
}
