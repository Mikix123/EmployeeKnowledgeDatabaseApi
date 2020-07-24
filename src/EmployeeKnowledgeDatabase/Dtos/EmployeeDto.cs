using System;
using EmployeeKnowledgeDatabase.Enums;

namespace EmployeeKnowledgeDatabase.Dtos
{
    public class EmployeeDto
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string Email { get; set; }

        public Seniorities Seniority { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsEnabled { get; set; }

    }
}