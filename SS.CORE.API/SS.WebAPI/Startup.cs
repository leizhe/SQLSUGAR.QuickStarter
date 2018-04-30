using System;
using System.Collections.Generic;
using log4net;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using SS.Application.ServiceImp;
using SS.Common.Filters;
using SS.Common.Helpers;
using SS.Common.IoC;
using SS.Domain.Repositories;
using SS.Repositories.DBContext;
using Swashbuckle.AspNetCore.Swagger;

namespace SS.WebAPI
{
    public class Startup
    {
        public static ILoggerRepository LoggerRepository { get; set; }

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LoggerRepository = LogManager.CreateRepository("NETCoreRepository");
            Log4NetHelper.SetConfig(LoggerRepository, "log4net.config");
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option =>
            {
                option.Filters.Add(new GlobalExceptionFilter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Shayne Boyer", Email = "", Url = "https://twitter.com/spboyer" },
                    License = new License { Name = "Use under LICX", Url = "https://example.com/license" }
                });
            });

            return InitIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseStaticFiles();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseMvc();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
          
        }

        private IServiceProvider InitIoC(IServiceCollection services)
        {
            var commandString = Configuration.GetConnectionString("CommandDB");
            var queryString = Configuration.GetConnectionString("QueryDB");
            var connectionConfig = new ConnectionConfig()
            {
                ConnectionString = commandString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                //InitKeyType = InitKeyType.Attribute  // Attribute用于DbFirst  从数据库生成model的
                InitKeyType = InitKeyType.SystemTable, //SystemTable用于Codefirst 从model库生成数据库表的
                SlaveConnectionConfigs = new List<SlaveConnectionConfig>()
                {
                    new SlaveConnectionConfig() {HitRate = 10, ConnectionString = queryString}
                }
            };
            var sqlSugarClient = new SqlSugarClient(connectionConfig);

            IoCContainer.Register(Configuration);//注册配置
            IoCContainer.Register(sqlSugarClient);//注册数据库配置信息
            IoCContainer.Register(typeof(DBContext));
            IoCContainer.Register(typeof(DbSet<>).Assembly, "Repository");//注册仓储
            IoCContainer.Register(typeof(BaseService).Assembly, "Service");
            IoCContainer.Register(typeof(DbSet<>), typeof(IRepository<>));
            return IoCContainer.Build(services);
        }
    }
}
