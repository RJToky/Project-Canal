using System.Data.SqlClient;

namespace Canal.Models;

public class DetailBouquet {
    public int id { get; set; }
    public string nom { get; set; }
    public double reduction { get; set; }
    public int idclient { get; set; }
    public double montantsansremise { get; set; }
    public double montantavecremise { get; set; }

    public static List<DetailBouquet> FindAll() {
        try {
            List<DetailBouquet> allDetailBouquet = new List<DetailBouquet>();
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();
            
            string sql = "select * from v_detail_bouquet where idclient is null";
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        DetailBouquet db = new DetailBouquet();
                        db.id = reader.GetInt32(0);
                        db.nom = reader.GetString(1);
                        db.reduction = reader.GetDouble(2);
                        db.idclient = reader.IsDBNull(3) ? -1 : reader.GetInt32(3);
                        db.montantsansremise = reader.GetDouble(4);
                        db.montantavecremise = reader.GetDouble(5);
                        allDetailBouquet.Add(db);
                    }
                }
            }
            con?.Close();
            return allDetailBouquet;
        } catch (System.Exception e) {
            throw;
        }
    }

    public static List<DetailBouquet> FindBouquetPerso(int idclient) {
        try {
            List<DetailBouquet> allDetailBouquet = new List<DetailBouquet>();
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();
            
            string sql = "select * from v_detail_bouquet where idclient = " + idclient;
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        DetailBouquet db = new DetailBouquet();
                        db.id = reader.GetInt32(0);
                        db.nom = reader.GetString(1);
                        db.reduction = reader.GetDouble(2);
                        db.idclient = reader.IsDBNull(3) ? -1 : reader.GetInt32(3);
                        db.montantsansremise = reader.GetDouble(4);
                        db.montantavecremise = reader.GetDouble(5);
                        allDetailBouquet.Add(db);
                    }
                }
            }
            con?.Close();
            return allDetailBouquet;
        } catch (System.Exception e) {
            throw;
        }
    }

}