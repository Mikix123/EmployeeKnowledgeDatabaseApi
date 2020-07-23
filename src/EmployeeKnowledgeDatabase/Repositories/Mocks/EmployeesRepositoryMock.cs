using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeKnowledgeDatabase.Domains;

namespace EmployeeKnowledgeDatabase.Repositories.Mocks
{
    public class EmployeesRepositoryMock : IEmployeesRepository
    {

        private readonly List<Employee> _allEmployees = new List<Employee>();

        public EmployeesRepositoryMock()
        {
            _allEmployees.Add(new Employee());
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await Task.Run(() => _allEmployees);
        }

        public async Task<Employee> GetById(long id)
        {
            return await Task.Run(() => _allEmployees.FirstOrDefault(x => x.Id == id));
        }

        public async Task Add(Employee employee)
        {
            await Task.Run(() => _allEmployees.Add(employee));
        }

        public Task Update(Employee employee)
        {
            return Task.CompletedTask;
        }

        public async Task Delete(long id)
        {
            await Task.Run(() => _allEmployees.RemoveAll(x => x.Id == id));
        }
    }
}