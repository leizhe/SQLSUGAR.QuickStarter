using System.Collections.Generic;
using SqlSugar;

namespace SS.Domain.Entities
{
    public class Permission : BaseEntity
    {
        [SugarColumn(IsNullable = false)]
        public string Name { get; set; }
        [SugarColumn(IsIgnore = true)]
        public ICollection<RolePermission> RolePermissions { get; set; }

        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }
    }
}