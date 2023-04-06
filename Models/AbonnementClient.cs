using System.Data.SqlClient;

namespace Canal.Models;

public class AbonnementClient {
    public int idclient { get; set; }
    public string nomclient { get; set; }
    public int idbouquet { get; set; }
    public string nombouquet { get; set; }
    public double reduction { get; set; }
    public string datedebut { get; set; }
    public string datefin { get; set; }
    public double montant { get; set; }

    public static List<AbonnementClient> FindByIdclient(int idclient) {
        try {
            List<AbonnementClient> listac = new List<AbonnementClient>();
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();
            
            string sql = "select * from v_abonnement_client where idclient = " + idclient + " order by idclient asc, datefin asc";
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        AbonnementClient ac = new AbonnementClient();
                        ac.idclient = reader.GetInt32(0);
                        ac.nomclient = reader.GetString(1);
                        ac.idbouquet = reader.GetInt32(2);
                        ac.nombouquet = reader.GetString(3);
                        ac.reduction = reader.GetDouble(4);
                        ac.datedebut = reader.GetDateTime(5).ToString();
                        ac.datefin = reader.GetDateTime(6).ToString();
                        ac.montant = reader.GetDouble(7);
                        listac.Add(ac);
                    }
                }
            }
            con?.Close();
            return listac;
        } catch (System.Exception e) {
            throw;
        }
    }

    public static AbonnementClient FindLastByIdclient(SqlConnection? con, int idclient) {
        try {
            AbonnementClient ac = new AbonnementClient();

            string sql = "select top 1 * from v_abonnement_client where idclient = " + idclient + " order by datefin desc";
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        ac.idclient = reader.GetInt32(0);
                        ac.nomclient = reader.GetString(1);
                        ac.idbouquet = reader.GetInt32(2);
                        ac.nombouquet = reader.GetString(3);
                        ac.reduction = reader.GetDouble(4);
                        ac.datedebut = reader.GetDateTime(5).ToString();
                        ac.datefin = reader.GetDateTime(6).ToString();
                        ac.montant = reader.GetDouble(7);
                    }
                }
            }
            return ac;
        } catch (System.Exception e) {
            throw;
        }
        
    }
}