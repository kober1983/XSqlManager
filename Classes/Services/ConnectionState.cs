using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSqlManager
{
    public class ConnectionState
    {
        public List<Connection> Connections = new List<Connection>();
        public void Save()
        {
            var con = JsonConvert.SerializeObject(Connections);
            Preferences.Default.Set("_connections", con);
        }
        public void Load()
        {
            var con = Preferences.Default.Get("_connections", "");
            if (!string.IsNullOrEmpty(con))
            {
                Connections = JsonConvert.DeserializeObject<List<Connection>>(con);
            }
        }
    }

}
