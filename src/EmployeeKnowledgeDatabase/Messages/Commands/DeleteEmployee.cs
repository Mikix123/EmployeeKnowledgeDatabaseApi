using MediatR;

namespace EmployeeKnowledgeDatabase.Messages.Commands
{
    public class DeleteEmployee : IRequest
    {
        public long Id { get; }

        public DeleteEmployee(long id)
        {
            Id = id;
        }
    }
}