namespace SS.Domain.Auditing
{
    public interface ISoftDelete
    {
        bool IsDeleted { get;} 
    }
}