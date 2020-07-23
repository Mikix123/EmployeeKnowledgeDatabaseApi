using EmployeeKnowledgeDatabase.Repositories.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeKnowledgeDatabase.Repositories
{
    public static class Extensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEmployeesRepository, EmployeesRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void AddMocksRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEmployeesRepository, EmployeesRepositoryMock>();
            services.AddTransient<IUserRepository, UserRepositoryMock>();
        }
    }
}