namespace EmployeeKnowledgeDatabase.Dtos
{
    public class IdValueDto<T, TT>
    {
        public T Id { get; set; }

        public TT Value { get; set; }
    }
}