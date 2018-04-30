using System;
using SqlSugar;
using SS.Domain.Entities;

namespace SS.DataBaseHelp
{
    public class DbInitializer
    {
        public SqlSugarClient DB;

        public DbInitializer(SqlSugarClient db)
        {
            DB = db;
        }

        public void TableInit()
        {
            DB.CodeFirst.InitTables(
                typeof(User),
                typeof(Role),
                typeof(UserRole),
                typeof(Permission),
                typeof(RolePermission)
            );
            //db.DbFirst.Where("xxxx").CreateClassFile("D:\\Demo\\2.txt");//生成文件的·地址 
        }


        public void DataInit()
        {
            if (DB.Queryable<User>().Any())
            {
                return;   // DB has been seeded
            }
            var users = new[]
            {
            new User{Name="Carson",RealName="Alexander Carson",Password = "aaa",CreationTime=DateTime.Parse("2005-09-01")},
            new User{Name="Meredith",RealName="Alonso Meredith",Password = "aaa",CreationTime=DateTime.Parse("2002-09-01")},
            new User{Name="Arturo",RealName="Anand Arturo",Password = "aaa",CreationTime=DateTime.Parse("2003-09-01")}
            };
            DB.Insertable(users).ExecuteCommand();

            var roles = new[]
            {
                new Role {RoleName = "Admin", CreationTime =DateTime.Parse("2005-09-01") }
            };
            DB.Insertable(roles).ExecuteCommand();

            var userRoles = new[]
            {
                new UserRole {UserId =1,RoleId = 1}
            };
            DB.Insertable(userRoles).ExecuteCommand();

        }
    }
}
