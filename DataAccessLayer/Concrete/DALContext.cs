using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class DALContext
    {

        readonly string connectionString = "Data Source=DESKTOP-D2RIL31;Initial Catalog=DapperAndSignalRDb;Integrated Security=True;TrustServerCertificate=True;";
        //public DALContext()
        //{
        //    _connection = new SqlConnection(connectionString);

        //}
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);

    }
}
