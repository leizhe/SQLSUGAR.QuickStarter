using System;
using System.Collections.Generic;
using SqlSugar;
using SS.Domain.Entities;

namespace SS.DataBaseHelp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var commandString = "Server=.\\SQLExpress;Database=SSWEBAPI;User ID=sa;Password=1qaz!QAZ;Application Name=test;";
            var queryString = "Server=.\\SQLExpress;Database=SSWEBAPI;User ID=sa;Password=1qaz!QAZ;Application Name=test;";
            var connectionConfig = new ConnectionConfig()
            {
                ConnectionString = commandString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,  // Attribute用于Codefirst 从数据库生成model的
                //InitKeyType = InitKeyType.SystemTable, //SystemTable用于DbFirst  从model库生成数据库表的
                SlaveConnectionConfigs = new List<SlaveConnectionConfig>()
                {
                    new SlaveConnectionConfig() {HitRate = 10, ConnectionString = queryString}
                }
            };
           

            using (var db = new SqlSugarClient(connectionConfig))
            {
                var initialize = new DbInitializer(db);
                try
                {
                    initialize.TableInit();

                    initialize.DataInit();
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            Console.WriteLine("Task execution success!");
            Console.ReadKey();
        }
    }
}
