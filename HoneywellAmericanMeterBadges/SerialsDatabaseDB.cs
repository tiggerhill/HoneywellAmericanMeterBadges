using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace HoneywellAmericanMeterBadges
{
    public class SerialsDatabaseDB
    {
        public static OleDbConnection GetConnection()
        {
            string connectionString =
                @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = |DataDirectory|\\HoneywellAmericanMeterBadges.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            return connection;
        }        
    }
}
