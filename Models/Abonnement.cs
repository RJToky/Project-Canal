using System.Data.SqlClient;

namespace Canal.Models;

public class Abonnement {
    public int id { get; set; }
    public int idclient { get; set; }
    public int idbouquet { get; set; }
    public DateTime datedebut { get; set; }
    public DateTime datefin { get; set; }

    public static void Insert(int idclient, int idbouquet) {
        try {
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();

            DateTime debut = AbonnementClient.FindLastByIdclient(con, idclient).datefin;
            if(debut <= DateTime.Now || debut == null) {
                debut = DateTime.Now;
            } else {
                debut = debut.AddDays(1);
            }
            DateTime fin = debut.AddDays(30);

            string sql = "insert into abonnement values (@idclient, @idbouquet, @debut, @fin)";
            using (SqlCommand command = new SqlCommand(sql, con)) {
                command.Parameters.AddWithValue("@idclient", idclient);
                command.Parameters.AddWithValue("@idbouquet", idbouquet);
                command.Parameters.AddWithValue("@debut", debut.ToString());
                command.Parameters.AddWithValue("@fin", fin.ToString());
                command.ExecuteNonQuery();
            }
            con?.Close();
        } catch (System.Exception e) {
            throw;
        }
    }
}