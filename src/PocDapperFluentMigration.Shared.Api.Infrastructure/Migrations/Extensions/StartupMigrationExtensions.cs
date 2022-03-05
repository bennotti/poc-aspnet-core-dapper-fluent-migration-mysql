using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PocDapperFluentMigration.Shared.Api.Infrastructure.Migrations.Extensions
{
    public static class StartupMigrationExtensions
    {
        public static IServiceCollection AddMigrationRunner(this IServiceCollection services, string connectionString, Assembly assembly)
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddMySql5()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
            return services;
        }
    }
}
