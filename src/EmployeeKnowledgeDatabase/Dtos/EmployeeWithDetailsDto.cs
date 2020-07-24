using System.Collections.Generic;

namespace EmployeeKnowledgeDatabase.Dtos
{
    public class EmployeeWithDetailsDto : EmployeeDto
    {
        public IEnumerable<IdValueDto<long, string>> Departments { get; set; }

        public IEnumerable<IdValueLevelDto<long, string>> Technologies { get; set; }

        public IEnumerable<IdValueDto<long, string>> Projects { get; set; }
    }
}