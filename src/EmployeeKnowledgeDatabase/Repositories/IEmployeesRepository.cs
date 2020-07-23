using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeKnowledgeDatabase.Domains;

namespace EmployeeKnowledgeDatabase.Repositories
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<Employee> GetById(long id);

        Task Add(Employee employee);

        Task Update(Employee employee);

        Task Delete(long id);
    }
}