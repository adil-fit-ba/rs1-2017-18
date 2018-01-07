using System.Configuration;
using System.Data.SqlClient;

namespace Video02.Data
{
    public class Konekcija
    {
        public static SqlConnection getKonekcija()
        {
            string s = ConfigurationManager.ConnectionStrings["MojConnectionString"].ConnectionString;

            SqlConnection konekcija = new SqlConnection(s);
            konekcija.Open();
            return konekcija;
        }
    }
}
