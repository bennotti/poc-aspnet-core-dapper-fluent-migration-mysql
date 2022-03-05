using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Microsoft.AspNetCore.HttpOverrides;
using PocDapperFluentMigration.Shared.Api.Infrastructure.Migrations.Extensions;
using PocDapperFluentMigration.Api.Application.Migrations;
using PocDapperFluentMigration.Shared.Core.Settings;

namespace PocDapperFluentMigration.Api.Service.Endpoint
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            string defaultCertPath = Configuration.GetSection("Kestrel:Certificates:Default:Path").Value;
            if (!string.IsNullOrEmpty(defaultCertPath))
            {
                Console.WriteLine($"Kestrel Default cert path: {defaultCertPath}");
                Console.WriteLine(File.Exists(defaultCertPath) ? "Default Cert file exists" : "Default Cert file does NOT exist!");
                Console.WriteLine($"Kestrel Default cert pass: {Configuration.GetSection("Kestrel:Certificates:Default:Password").Value}");
            }

            string devCertPath = Configuration.GetSection("Kestrel:Certificates:Development:Path").Value;
            if (!string.IsNullOrEmpty(devCertPath))
            {
                Console.WriteLine($"Kestrel Development cert path: {devCertPath}");
                Console.WriteLine(File.Exists(devCertPath) ? "Development Cert file exists" : "Development Cert file does NOT exist!");
                Console.WriteLine($"Kestrel Development cert pass: {Configuration.GetSection("Kestrel:Certificates:Development:Password").Value}");
            }

            #region Cors
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            services.AddCors();
            #endregion

            services.AddMvc()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.WriteIndented = true;
                });
            services.Configure<ApiBehaviorOptions>(opt => {
                opt.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddTransient<Random>();
            services.AddMemoryCache();
            services.AddOptions();
            var mysqSettings = Configuration.GetSection("ConnectionStrings").Get<MySqlDatabaseSettings>();
            services.AddMigrationRunner(
                mysqSettings.MySqlConnection,
                typeof(Init202203050001).Assembly
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseForwardedHeaders();

            app.UseRouting();

            app.UseCors(x => x
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
