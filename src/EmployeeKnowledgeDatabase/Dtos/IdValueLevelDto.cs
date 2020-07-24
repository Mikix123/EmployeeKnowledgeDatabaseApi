namespace EmployeeKnowledgeDatabase.Dtos
{
    public class IdValueLevelDto<T, TT> : IdValueDto<T, TT>
    {
        public int Level { get; set; }
    }
}