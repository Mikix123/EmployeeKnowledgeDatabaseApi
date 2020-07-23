using System.Threading.Tasks;
using EmployeeKnowledgeDatabase.Domains;

namespace EmployeeKnowledgeDatabase.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
    }
}