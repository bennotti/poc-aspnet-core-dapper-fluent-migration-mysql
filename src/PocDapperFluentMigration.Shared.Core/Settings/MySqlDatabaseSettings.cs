using PocDapperFluentMigration.Shared.Core.Contract.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocDapperFluentMigration.Shared.Core.Settings
{
    public class MySqlDatabaseSettings : IMysqlDatabaseSettings
    {
        public string MySqlConnection { get; set; }
    }
}
