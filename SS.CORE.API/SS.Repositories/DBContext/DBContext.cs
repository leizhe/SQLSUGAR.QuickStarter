using SqlSugar;
using SS.Domain.Entities;

namespace SS.Repositories.DBContext
{
    public class DBContext 
    {

        public DBContext()
        {
            Db =new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = "xx",
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true
                }
            );
        }

        public SqlSugarClient Db;
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        
        public DbSet<UserRole> UserRoles { get; set; }


     
    }
}
