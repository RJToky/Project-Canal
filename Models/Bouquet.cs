using System.Data.SqlClient;

namespace Canal.Models;

public class Bouquet {
    public int id { get; set; }
    public string nom { get; set; }
    public double reduction { get; set; }
    public int idclient { get; set; }

    public static List<Bouquet> FindAll() {
        try {
            List<Bouquet> allBouquet = new List<Bouquet>();
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();
            
            string sql = "select * from bouquet where idclient is null";
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Bouquet b = new Bouquet();
                        b.id = reader.GetInt32(0);
                        b.nom = reader.GetString(1);
                        b.reduction = reader.GetDouble(2);
                        b.idclient = reader.IsDBNull(3) ? -1 : reader.GetInt32(3);
                        allBouquet.Add(b);
                    }
                }
            }
            con?.Close();
            return allBouquet;
        } catch (System.Exception e) {
            throw;
        }
    }

    public static List<Bouquet> FindAllWithPerso(SqlConnection? con, int idclient) {
        try {
            List<Bouquet> allBouquet = new List<Bouquet>();
            
            string sql = "select * from bouquet where idclient is null or idclient = " + idclient;
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Bouquet b = new Bouquet();
                        b.id = reader.GetInt32(0);
                        b.nom = reader.GetString(1);
                        b.reduction = reader.GetDouble(2);
                        b.idclient = reader.IsDBNull(3) ? -1 : reader.GetInt32(3);
                        allBouquet.Add(b);
                    }
                }
            }
            return allBouquet;
        } catch (System.Exception e) {
            throw;
        }
    }

    public static void Insert(SqlConnection? con, string nombouquet, double reduction, int idclient) {
        try {
            string sql = "insert into bouquet values (@nombouquet, @reduction, @idclient)";
            using (SqlCommand command = new SqlCommand(sql, con)) {
                command.Parameters.AddWithValue("@nombouquet", nombouquet);
                command.Parameters.AddWithValue("@reduction", reduction);
                command.Parameters.AddWithValue("@idclient", idclient);
                command.ExecuteNonQuery();
            }
        }
        catch (System.Exception e) {
            throw;
        }
    }

    public static int GetLastId(SqlConnection? con) {
        try {
            int lastid = -1;
            
            string sql = "select top 1 id from bouquet order by id desc";
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        return reader.GetInt32(0);
                    }
                }
            }
            return lastid;
        } catch (System.Exception e) {
            throw;
        }
    }

    public static void InsertPersonnalise(string nombouquet, string[] nomchaine, int idclient) {
        try {
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();

            double reduction = Canal.Models.Reduction.FindReduction(con, nomchaine.Length);
            Bouquet.Insert(con, nombouquet, reduction, idclient);
            int lastid = Bouquet.GetLastId(con);

            for (int i = 0; i < nomchaine.Length; i++) {
                string sql = "insert into bouquet_chaine values (@idbouquet, @idchaine)";
                using (SqlCommand command = new SqlCommand(sql, con)) {
                    command.Parameters.AddWithValue("@idbouquet", lastid);
                    command.Parameters.AddWithValue("@idchaine", nomchaine[i]);
                    command.ExecuteNonQuery();
                }
            }
            con?.Close();
        } catch (System.Exception e) {
            throw;
        }
    }
}