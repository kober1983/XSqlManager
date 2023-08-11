using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSqlManager
{
    public class SqlManagerCommand
    {
        public string CommandText { get; set; }
        public string CommandResult { get; set; }
        public DataTable TableResult { get; set; }
        public string CommandError { get; set; }
    }
}
