using SqlSugar;
using SS.Domain.Entities;

namespace SS.Domain.Repositories
{
    public interface IUserRepository :IRepository<User>
    {
        ISugarQueryable<User> GetAll();
    }
}
