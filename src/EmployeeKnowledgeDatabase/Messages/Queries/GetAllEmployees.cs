using System.Collections.Generic;
using EmployeeKnowledgeDatabase.Dtos;
using MediatR;

namespace EmployeeKnowledgeDatabase.Messages.Queries
{
    public class GetAllEmployees : IRequest<IEnumerable<EmployeeDto>>
    {
    }
}