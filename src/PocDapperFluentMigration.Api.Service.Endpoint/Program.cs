using PocDapperFluentMigration.Shared.Api.Infrastructure;
using PocDapperFluentMigration.Shared.Api.Infrastructure.Migrations.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PocDapperFluentMigration.Api.Service.Endpoint
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateDatabase()
                .Run();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return ProgramHelper.CreateHostBuilder(args, WebHostBuilder => {
                WebHostBuilder.UseStartup<Startup>();
            });
        }
    }
}
