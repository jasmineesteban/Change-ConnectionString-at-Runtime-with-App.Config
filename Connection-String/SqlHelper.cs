using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_String
{
    public class SqlHelper
    {
        SqlConnection cn;
        
        public SqlHelper(string connectionString)
        {
            cn = new SqlConnection(connectionString);
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
