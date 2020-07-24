using EmployeeKnowledgeDatabase.Enums;
using MediatR;

namespace EmployeeKnowledgeDatabase.Messages.Commands
{
    public class DeleteDictionaryItem : IRequest
    {
        public DictionaryTypes DictionaryType { get; }

        public long Id { get; }

        public DeleteDictionaryItem(DictionaryTypes dictionaryType, long id)
        {
            DictionaryType = dictionaryType;
            Id = id;
        }
    }
}