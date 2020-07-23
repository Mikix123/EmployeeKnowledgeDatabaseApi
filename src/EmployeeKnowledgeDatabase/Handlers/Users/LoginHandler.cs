using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EmployeeKnowledgeDatabase.Domains;
using EmployeeKnowledgeDatabase.Enums;
using EmployeeKnowledgeDatabase.Infrastructure.Authentication;
using EmployeeKnowledgeDatabase.Infrastructure.Errors;
using EmployeeKnowledgeDatabase.Messages.Commands;
using EmployeeKnowledgeDatabase.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace EmployeeKnowledgeDatabase.Handlers.Users
{
    public class LoginHandler : IRequestHandler<Login, JsonWebToken>
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;

        public LoginHandler(IPasswordHasher<User> passwordHasher, IUserRepository userRepository, IJwtHandler jwtHandler)
        {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
        }

        public async Task<JsonWebToken> Handle(Login request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);


            if (user == null || !user.ValidatePassword(request.Password, _passwordHasher) || !user.IsEnabled)
            {
                throw new RestException(HttpStatusCode.Unauthorized, new { Error = "Invalid email / password." });
            }


            if (!Enum.TryParse<UserRoles>(user.Role, true, out var role))
            {
                role = UserRoles.User;
            }

            return _jwtHandler.CreateToken(user.Id.ToString(), role);

        }
    }
}