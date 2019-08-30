using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Ponente.Api.Extensions
{
    public static class CorsServiceExtensions
    {
        private static string PonenteUiOrigins = "_ponenteUiOrigins";

        public static IServiceCollection AddCorsForPonente(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PonenteUiOrigins,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(PonenteUiOrigins));
            });

            return services;
        }

        public static IApplicationBuilder UseCorsForPonente(this IApplicationBuilder app)
        {
            app.UseCors(PonenteUiOrigins);
            return app;
        }
    }
}
