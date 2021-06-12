using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class ConnectSQL
    {
        string con;
        public ConnectSQL()
        {
            con = @"Data Source=Minh-PC\MSSQLSERVER02;Initial Catalog=QLSV;Integrated Security=True";

        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(con);
        }
    }
}
