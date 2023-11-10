using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_Gestion_de_Magasin
{
    class Connexion
    {
       public static SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-DJR5LN8\SQLEXPRESS;Initial Catalog=GESTION_MAGASIN;Integrated Security=True");

        public static void open()
        {
            sqlConnection.Open();
        }

        public static void close()
        {
            sqlConnection.Close();
        }

    }
}
