using EmployeeKnowledgeDatabase.Infrastructure.Authentication;
using MediatR;

namespace EmployeeKnowledgeDatabase.Messages.Commands
{
    public class Login : IRequest<JsonWebToken>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}