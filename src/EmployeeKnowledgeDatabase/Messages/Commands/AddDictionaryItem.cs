using EmployeeKnowledgeDatabase.Dtos;
using EmployeeKnowledgeDatabase.Enums;
using MediatR;

namespace EmployeeKnowledgeDatabase.Messages.Commands
{
    public abstract class AddDictionaryItem : IRequest
    {
        public string Value { get; set; }

        public abstract DictionaryTypes DictionaryType { get; }
    }
}