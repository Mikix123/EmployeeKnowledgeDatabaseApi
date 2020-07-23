using System.Collections.Generic;

namespace EmployeeKnowledgeDatabase.Infrastructure.Authentication
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }
        public long Expires { get; set; }
        public string Role { get; set; }
        public IDictionary<string, string> Claims { get; set; }
    }
}