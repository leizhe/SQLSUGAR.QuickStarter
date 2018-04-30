using System;
using System.Collections.Generic;
using SqlSugar;
using SS.Domain.Auditing;

namespace SS.Domain.Entities
{
    public sealed class Role : BaseEntity, ICreationAudited
    {
        [SugarColumn(Length = 20,IsNullable = false)]
        public string RoleName { get; set; }
        [SugarColumn(IsNullable = true)]
        public long? CreatorUserId { get; set; }
        [SugarColumn(IsNullable = true)]
        public DateTime CreationTime { get; set; }
        [SugarColumn(IsIgnore = true)]
        public ICollection<RolePermission> RolePermissions { get; set; }
        [SugarColumn(IsIgnore = true)]
        public ICollection<UserRole> UserRoles { get; set; }

        public Role()
        {
            RolePermissions = new HashSet<RolePermission>();
            UserRoles = new HashSet<UserRole>();
        }
    }
}