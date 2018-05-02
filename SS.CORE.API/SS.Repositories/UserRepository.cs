using SqlSugar;
using SS.Domain.Entities;
using SS.Domain.Repositories;
using SS.Repositories.DBContext;

namespace SS.Repositories
{
    public class UserRepository: DbSet<User>, IUserRepository
    {
        public UserRepository(SqlSugarClient context) : base(context)
        {
        }

        public ISugarQueryable<User> GetAll()
        {
            return Context.Queryable<User, UserRole, Role>((user, userRole, role) => new object[]
                {
                    JoinType.Left, user.Id == userRole.UserId,
                    JoinType.Left, userRole.RoleId == role.Id
                })
                .Select((user, userRole, role) => user);
        }
    }
}
