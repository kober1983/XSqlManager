using Microsoft.Data.SqlClient;
using System.Data;

namespace XSqlManager
{
    // TABLE_CATALOG: dwh; TABLE_SCHEMA: webgui; TABLE_NAME: CustomCorr_2019; TABLE_TYPE: BASE TABLE;
    public class TableInfo
    {
        public string Catalog { get; set; }
        public string Schema { get; set; }
        public string Name { get; set; }
    }
    public class TableResult
    {
        public int RecordsAffected { get; set; }
        public DataTable Table { get; set; }
        public string Error { get; set; }
    }
    public class BaseServerService
    {
        private const int _max_row_count = 500;
        protected string _connectionString;
        protected string _getTablesQuery;
        public async Task<List<TableInfo>> GetTables()
        {
            var ret = new List<TableInfo>();
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(_getTablesQuery, connection))
                {

                    await connection.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {

                        while (await reader.ReadAsync())
                        {
                            ret.Add(new TableInfo
                            {
                                Catalog = reader["catalog"].ToString(),
                                Schema = reader["schema"].ToString(),
                                Name = reader["name"].ToString(),
                            });

                        }
                    }
                    //  var d = await cmd.ExecuteScalarAsync();
                    return ret;
                }
                //  return null;
            }
        }
        public async Task<TableResult> ExecCommand(string command)
        {
            try
            {
                DataTable dt = new DataTable();

                var rows = 0;
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(command, connection))
                    {
                        await connection.OpenAsync();
                        bool isFirst = true;
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {

                                if (isFirst)
                                {
                                    isFirst = false;
                                    for (int i = 0; i < reader.FieldCount; i++)
                                        dt.Columns.Add(reader.GetName(i));
                                }
                                var row = dt.NewRow();
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    // var cname = dt.Columns[i].ColumnName;
                                    row[i] = reader[i];
                                }

                                dt.Rows.Add(row);
                                rows++;
                                if (rows >= _max_row_count)
                                    break;
                            }
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync())
                                    rows++;
                            }
                        }
                        //  var d = await cmd.ExecuteScalarAsync();
                        return new TableResult { Table = dt, RecordsAffected = rows };
                    }
                }
            }
            catch (Exception ex)
            {
                return new TableResult { Error = ex.Message };
            }
            //  return null;
        }


        public string GetSelectCommand(TableInfo tableinfo)
        {
            return $"select top 100 * from {tableinfo.Schema}.{tableinfo.Name}";
        }
    }
}
