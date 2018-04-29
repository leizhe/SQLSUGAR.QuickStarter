using SqlSugar;

namespace SS.Domain.Entities
{
    public class RolePermission : BaseEntity
    {
        [SugarColumn(IsNullable = false)]
        public long RoleId { get; set; }
        [SugarColumn(IsNullable = false)]
        public long PermissionId { get; set; }
        [SugarColumn(IsIgnore = true)]
        public virtual Role Role { get; set; }
        [SugarColumn(IsIgnore = true)]
        public virtual Permission Permission { get; set; }
    }
}