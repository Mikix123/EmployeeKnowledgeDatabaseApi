using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.AspNetCore;
using NSwag.Generation.Processors.Security;
using System.Linq;
using System.Net;

namespace EmployeeKnowledgeDatabase.Infrastructure.Swagger
{
    public static class Extensions
    {
        private const string SectionName = "swagger";

        public static void AddSwaggerDocs(this IServiceCollection services)
        {
            SwaggerOptions options;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                services.Configure<SwaggerOptions>(configuration.GetSection(SectionName));
                options = configuration.GetOptions<SwaggerOptions>(SectionName);
            }

            if (!options.Enabled)
            {
                return;
            }

            services.AddSwaggerDocument(config =>
            {

                config.PostProcess = document =>
                {
                    document.Info.Version = options.Version;
                    document.Info.Title = options.Title;
                };

                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("Bearer"));

                if (!options.IncludeSecurity)
                    return;

                config.AddSecurity("Bearer", Enumerable.Empty<string>(),
                    new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = nameof(Authorization),
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Copy this into the value field: Bearer {token}"
                    }
                );
            });

        }

        public static void UseSwaggerDocs(this IApplicationBuilder app)
        {

            var options = app.ApplicationServices.GetService<IConfiguration>()
                .GetOptions<SwaggerOptions>(SectionName);
            if (!options.Enabled)
            {
                return;
            }

            var routePrefix = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "swagger" : options.RoutePrefix;

            app.UseOpenApi(opt =>
            {
                opt.Path = $"/{routePrefix}/{options.Version}/swagger.json";
            });

            app.UseSwaggerUi3(opt =>
            {
                opt.Path = $"/{routePrefix}";
                opt.SwaggerRoutes.Add(new SwaggerUi3Route(options.Version,
                    $"/{routePrefix}/{options.Version}/swagger.json"));
            });
        }
    }
}