using System;
using System.Collections.Generic;
using SqlSugar;
using SS.Domain.Entities;

namespace SS.Repositories.DBContext
{
    public class DBContext : IDisposable
    {
      
        public DBContext(SqlSugarClient db)
        {
            Db = db;
        }

        public SqlSugarClient Db;
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        
        public DbSet<UserRole> UserRoles { get; set; }


        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
