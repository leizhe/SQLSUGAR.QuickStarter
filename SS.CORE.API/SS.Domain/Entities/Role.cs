using System;
using System.Collections.Generic;
using SqlSugar;
using SS.Domain.Auditing;

namespace SS.Domain.Entities
{
    [SugarTable("Role")]
    public class Role : BaseModelContextEntity, ICreationAudited
    {
        [SugarColumn(Length = 20,IsNullable = false)]
        public string RoleName { get; set; }
        [SugarColumn(IsNullable = true)]
        public long? CreatorUserId { get; set; }
        [SugarColumn(IsNullable = true)]
        public DateTime CreationTime { get; set; }
        [SugarColumn(IsIgnore = true)]
        public List<RolePermission> RolePermissions { get; set; }
        [SugarColumn(IsIgnore = true)]
        public ICollection<UserRole> UserRoles
        {
            get { return base.CreateMapping<UserRole>().Where(p => p.UserId == this.Id).ToList(); }
        }

        //public Role()
        //{
        //    RolePermissions = new List<RolePermission>();
        //    UserRoles = new HashSet<UserRole>();
        //}
    }
}