using SqlSugar;
using SS.Domain.Entities;
using SS.Domain.Repositories;
using SS.Repositories.SqlSugar;

namespace SS.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(DBService server) : base(server)
        {
        }

        public ISugarQueryable<User> GetAll()
        {
            
            return null;
            //return Context.Queryable<User, UserRole, Role>((user, userRole, role) => new object[]
            //    {
            //        JoinType.Left, user.Id == userRole.UserId,
            //        JoinType.Left, userRole.RoleId == role.Id
            //    })
            //    .Select((user, userRole, role) => new User()
            //    {
            //        Id = user.Id,
            //        Name = user.Name,
            //        UserRoles = userRole
            //    });
        }
    }
}
