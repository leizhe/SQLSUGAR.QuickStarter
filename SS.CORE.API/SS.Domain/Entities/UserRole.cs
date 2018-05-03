using SqlSugar;

namespace SS.Domain.Entities
{
    [SugarTable("UserRole")]
    public class UserRole : BaseModelContextEntity
    {
        [SugarColumn(IsNullable = false)]
        public long RoleId { get; set; }

        [SugarColumn(IsNullable = false)]
        public long UserId { get; set; }

        [SugarColumn(IsIgnore = true)]
        public User User
        {
            get { return CreateMapping<User>().Single(p => p.Id == this.UserId); }
        }

        [SugarColumn(IsIgnore = true)]
        public Role Role
        {
            get { return CreateMapping<Role>().Single(p => p.Id == this.RoleId); }
        }
    }
}