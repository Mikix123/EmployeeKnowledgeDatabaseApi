using System.Collections.Generic;
using EmployeeKnowledgeDatabase.Enums;

namespace EmployeeKnowledgeDatabase.Dtos
{
    public class DictionaryDto
    {
        public DictionaryTypes Type { get; set; }

        public IEnumerable<IdValueDto<long, string>> Items { get; set; }
    }
}