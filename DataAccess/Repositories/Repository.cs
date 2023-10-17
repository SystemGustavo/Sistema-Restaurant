using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Repository
    {
        private readonly string conectionString;

        public Repository()
        {
            conectionString = "Data Source=SystemGustavo\\SQLEXPRESS;Initial Catalog=BASEBRIRESTCSHARP;Integrated Security=True;TrustServerCertificate=true";
        }

        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(conectionString);
        }
    }
}
