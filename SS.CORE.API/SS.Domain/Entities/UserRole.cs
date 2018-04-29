using SqlSugar;

namespace SS.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        [SugarColumn(IsNullable = false)]
        public long RoleId { get; set; }
        [SugarColumn(IsNullable = false)]
        public long UserId { get; set; }
        [SugarColumn(IsIgnore = true)]
        public virtual User User { get; set; }
        [SugarColumn(IsIgnore = true)]
        public virtual Role Role { get; set; }
    }
}