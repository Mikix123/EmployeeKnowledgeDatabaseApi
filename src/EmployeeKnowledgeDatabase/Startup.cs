using System.Reflection;
using System.Text.Json.Serialization;
using EmployeeKnowledgeDatabase.Domains;
using EmployeeKnowledgeDatabase.Infrastructure.Authentication;
using EmployeeKnowledgeDatabase.Infrastructure.Errors;
using EmployeeKnowledgeDatabase.Infrastructure.Serilog;
using EmployeeKnowledgeDatabase.Infrastructure.Swagger;
using EmployeeKnowledgeDatabase.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EmployeeKnowledgeDatabase
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddCors();
            services.AddJwt();
            services.AddSwaggerDocs();


            services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

            if(_env.IsDevelopment())
                services.AddMocksRepositories();
            else
                services.AddRepositories();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddSerilogLogging(app);

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseCors(builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerDocs();
        }
    }
}
