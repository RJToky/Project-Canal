using System.Data.SqlClient;

namespace Canal.Models;

public class Chaine {
    public int id { get; set; }
    public string nom { get; set; }
    public double prix { get; set; }
    public double signal { get; set; }

    public static List<Chaine> FindChaineByIdbouqet(SqlConnection? con, int idbouquet) {
        try {
            List<Chaine> listc = new List<Chaine>();

            string sql = "select idchaine, nomchaine, prix, signal from v_detail_bouquet_chaine where idbouquet = " + idbouquet;
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Chaine c = new Chaine();
                        c.id = reader.GetInt32(0);
                        c.nom = reader.GetString(1);
                        c.prix = reader.GetDouble(2);
                        c.signal = reader.GetDouble(3);
                        listc.Add(c);
                    }
                }
            }
            return listc;
        }
        catch (System.Exception e) {
            throw;
        }
    }

    public static List<Chaine> FindChaineDisponible(int idclient) {
        try {
            List<Chaine> listc = new List<Chaine>();
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();

            string sql = "select c.* from chaine c where c.signal >= (select vdc.signal from v_detail_client vdc where vdc.idclient = " + idclient + ")";
            // string sql = "select * from chaine";
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Chaine c = new Chaine();
                        c.id = reader.GetInt32(0);
                        c.nom = reader.GetString(1);
                        c.prix = reader.GetDouble(2);
                        c.signal = reader.GetDouble(3);
                        listc.Add(c);
                    }
                }
            }
            con?.Close();
            return listc;
        }
        catch (System.Exception e) {
            throw;
        }
    }
}