using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeKnowledgeDatabase.Dtos;
using EmployeeKnowledgeDatabase.Messages.Queries;
using EmployeeKnowledgeDatabase.Repositories;
using MediatR;

namespace EmployeeKnowledgeDatabase.Handlers.Employees
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployees, IEnumerable<EmployeeDto>>
    {
        private readonly IEmployeesRepository _employeesRepository;

        public GetAllEmployeesHandler(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployees request, CancellationToken cancellationToken)
        {
            return (await _employeesRepository.GetAll()).Select(x => new EmployeeDto());
        }
    }
}