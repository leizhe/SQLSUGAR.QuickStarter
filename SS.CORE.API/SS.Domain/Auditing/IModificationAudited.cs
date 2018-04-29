using System;

namespace SS.Domain.Auditing
{
    public interface IModificationAudited
    {

        DateTime? LastModificationTime { get; set; }


        long? LastModifierUserId { get; set; }
    }
}