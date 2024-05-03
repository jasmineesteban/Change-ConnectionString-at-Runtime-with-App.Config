using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_String
{
    public class SqlHelper
    {
        MySqlConnection cn;
        
        public SqlHelper(string connectionString)
        {
            cn = new MySqlConnection(connectionString);
        }

        public bool IsConnection
        {
            get
            {
                if(cn.State==System.Data.ConnectionState.Closed)
                    cn.Open();
                return true;
            }
        }
    }
}
