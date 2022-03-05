using System;
using System.Collections.Generic;
using System.Text;

namespace PocDapperFluentMigration.Shared.Core.Contract.Settings
{
    public interface IMysqlDatabaseSettings
    {
        string MySqlConnection { get; set; }
    }
}
