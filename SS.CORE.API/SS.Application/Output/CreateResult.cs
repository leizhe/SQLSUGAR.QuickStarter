namespace SS.Application.Output
{
    public class CreateResult<T> : OutputBase
    {
        public T Id { get; set; }
        public bool IsCreated { get; set; }
    }
}