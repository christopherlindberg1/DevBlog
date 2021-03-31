using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Db
{
    /// <summary>
    /// Class containing a property for the connection string name.
    /// </summary>
    public class ConnectionStringData
    {
        public string SqlConnectionName { get; set; } = "DefaultConnection";
    }
}
