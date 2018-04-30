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
    }
}
