using System;

namespace SS.Domain.Auditing
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; } 
    }
}