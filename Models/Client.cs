using System.Data.SqlClient;

namespace Canal.Models;

public class Client {
    public int id { get; set; }
    public string nom { get; set; }
    public double idregion { get; set; }

    public static List<Client> FindAll() {
        try {
            List<Client> allClient = new List<Client>();
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();
            
            string sql = "select * from client";
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Client c = new Client();
                        c.id = reader.GetInt32(0);
                        c.nom = reader.GetString(1);
                        c.idregion = reader.GetInt32(2);
                        allClient.Add(c);
                    }
                }
            }
            con?.Close();
            return allClient;
        } catch (System.Exception e) {
            throw;
        }
    }

    public static Client FindOne(int idclient) {
        try {
            Client c = new Client();
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();
            
            string sql = "select * from client where id = " + idclient;
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        c.id = reader.GetInt32(0);
                        c.nom = reader.GetString(1);
                        c.idregion = reader.GetInt32(2);
                    }
                }
            }
            con?.Close();
            return c;
        } catch (System.Exception e) {
            throw;
        }
    }

    public static List<Bouquet> FindBouquetDisponible(int idclient) {
        try {
            List<Bouquet> listb = new List<Bouquet>();
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();
            
            DetailClient dc = Canal.Models.DetailClient.FindOne(con, idclient);
            List<Bouquet> allBouquet = Canal.Models.Bouquet.FindAllWithPerso(con, idclient);
            AbonnementClient lastAbonnement = Canal.Models.AbonnementClient.FindLastByIdclient(con, idclient);

            for (int i = 0; i < allBouquet.Count; i++) {
                bool isDispo = true;
                double montant = 0.0;

                List<Chaine> listc = Canal.Models.Chaine.FindChaineByIdbouqet(con, allBouquet[i].id);
                for (int j = 0; j < listc.Count; j++) {
                    montant += listc[j].prix;
                    if (!(listc[j].signal >= dc.signal)) {
                        isDispo = false;
                        break;
                    }
                }
                montant -= (montant * allBouquet[i].reduction) / 100.0;

                if(isDispo && (montant >= lastAbonnement.montant)) {
                    listb.Add(allBouquet[i]);
                }
            }
            con?.Close();
            return listb;
        } catch (System.Exception e) {
            throw;
        }
    }
}