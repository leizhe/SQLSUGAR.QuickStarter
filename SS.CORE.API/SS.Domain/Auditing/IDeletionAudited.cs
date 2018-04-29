using System;

namespace SS.Domain.Auditing
{
    public interface IDeletionAudited : ISoftDelete
    {

        long? DeleterUserId { get; set; }

       
        DateTime? DeletionTime { get; set; } 
    }
}