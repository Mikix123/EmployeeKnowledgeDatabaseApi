using EmployeeKnowledgeDatabase.Dtos;
using MediatR;

namespace EmployeeKnowledgeDatabase.Messages.Commands
{
    public class UpdateEmployee : EmployeeWithDetailsDto, IRequest
    {
        
    }
}