using System.Threading.Tasks;
using EmployeeKnowledgeDatabase.Domains;

namespace EmployeeKnowledgeDatabase.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}