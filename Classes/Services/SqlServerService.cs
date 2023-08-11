using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSqlManager { 
    public class SqlServerService : BaseServerService
    {
        public SqlServerService()
        {
            _connectionString = "Server=SPB-S-DWH1;Database=dwh;User Id=commercial;Password=PCEwF9cQYG1;trusted_connection=true;encrypt=false;";
            _getTablesQuery = "SELECT TABLE_CATALOG as catalog, TABLE_SCHEMA as [schema], TABLE_NAME as name FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME;";
        }

    }
}
