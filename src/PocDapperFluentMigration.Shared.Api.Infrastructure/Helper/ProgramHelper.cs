using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace PocDapperFluentMigration.Shared.Api.Infrastructure
{
    public static class ProgramHelper
    {
        public static IHostBuilder CreateHostBuilder(string[] args, Action<IWebHostBuilder> configure) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    configure.Invoke(webBuilder);
                    if (Environment.GetEnvironmentVariable("PORT") != null)
                    {
                        var port = Int32.Parse(Environment.GetEnvironmentVariable("PORT"));
                        webBuilder.UseKestrel(options => {
                            options.ListenAnyIP(port, c => {
                                c.UseHttps();
                            });
                        });
                    }
                });
    }
}
