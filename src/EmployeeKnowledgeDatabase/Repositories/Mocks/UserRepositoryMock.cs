using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using EmployeeKnowledgeDatabase.Domains;
using EmployeeKnowledgeDatabase.Enums;

namespace EmployeeKnowledgeDatabase.Repositories.Mocks
{
    public class UserRepositoryMock : IUserRepository
    {

        private readonly List<User> _users = new List<User>();
        public UserRepositoryMock()
        {
            var faker = new Faker();
            _users.Add(new User
            {
                Id = 1,
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Email = "test@test.com",
                Password = "AQAAAAEAACcQAAAAEN1YwhgBZTGY7bCRJV8bkHCrIf1Fubz0l/jrdxFZM0JwFa/+PmkUOOpDPgS/XEp/vw==",
                CreatedAt = faker.Date.Past(),
                IsEnabled = true,
                Role = UserRoles.Administrator.ToString()
            });
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await Task.Run(() => _users.FirstOrDefault(x => x.Email == email));
        }
    }
}