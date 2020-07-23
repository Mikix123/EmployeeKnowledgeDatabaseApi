using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeKnowledgeDatabase.Domains;

namespace EmployeeKnowledgeDatabase.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return new List<Employee>();
        }

        public async Task<Employee> GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Add(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}