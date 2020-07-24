using EmployeeKnowledgeDatabase.Dtos;
using MediatR;

namespace EmployeeKnowledgeDatabase.Messages.Queries
{
    public class GetEmployeeById : IRequest<EmployeeWithDetailsDto>
    {
        public long Id { get; }

        public GetEmployeeById(long id)
        {
            Id = id;
        }
    }
}