using System;
using System.Collections.Generic;
using SqlSugar;
using SS.Domain.Auditing;

namespace SS.Domain.Entities
{
    [SugarTable("User")]
    public class User : BaseModelContextEntity, ICreationAudited
    {
        [SugarColumn(Length = 20)]
        public string Name { get; set; }

        [SugarColumn(Length = 50, IsNullable = true)]
        public string Password { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string Email { get; set; }
        [SugarColumn(Length = 20, IsNullable = true)]
        public string RealName { get; set; }
        [SugarColumn(IsNullable = true)]
        public long? CreatorUserId { get; set; }

        [SugarColumn(IsNullable = false)]
        public DateTime CreationTime { get; set; }
        [SugarColumn(IsNullable = true)]
        public int State { get; set; }

        [SugarColumn(IsIgnore = true)]
        public ICollection<UserRole> UserRoles {
            get { return base.CreateMapping<UserRole>().Where(p => p.UserId == this.Id).ToList(); }
        }
        
    }
}