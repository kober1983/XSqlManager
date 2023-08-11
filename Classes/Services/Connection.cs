using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSqlManager
{
    public class Connection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public ConnectionType Type { get; set; }
    }
    public enum ConnectionType
    {
        SQL
    }
}
