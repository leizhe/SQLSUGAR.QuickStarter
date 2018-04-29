using System;
using System.Collections.Generic;
using SqlSugar;
using SS.Domain.Auditing;

namespace SS.Domain.Entities
{
    public class User : BaseEntity, ICreationAudited
    {
        [SugarColumn(Length = 20, IsNullable = false)]
        public string Name { get; set; }

        [SugarColumn(Length = 50)]
        public string Password { get; set; }
        [SugarColumn(Length = 20)]
        public string Email { get; set; }
        [SugarColumn(Length = 20)]
        public string RealName { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public int State { get; set; }

        [SugarColumn(IsIgnore = true)]
        public ICollection<UserRole> UserRoles { get; set; }

        public User()
        {
            UserRoles = new List<UserRole>();
        }
    }
}