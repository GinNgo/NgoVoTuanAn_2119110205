using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.EmloyeeDTO
{
    public class DBConnection
    {
        public DBConnection()
        {

        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = @"Data Source=DELL-PC\SQLEXPRESS;Initial Catalog=HR;User Id=sa;Password=sa"
            };
            return conn;
        }
    }
}
