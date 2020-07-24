using System;
using EmployeeKnowledgeDatabase.Dtos;
using EmployeeKnowledgeDatabase.Enums;
using MediatR;

namespace EmployeeKnowledgeDatabase.Messages.Commands
{
    public abstract class UpdateDictionaryItem : IdValueDto<long, string>, IRequest
    {
        public abstract DictionaryTypes DictionaryType { get; }
    }
}