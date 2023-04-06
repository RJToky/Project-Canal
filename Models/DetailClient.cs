using System.Data.SqlClient;

namespace Canal.Models;

public class DetailClient {
    public int idclient { get; set; }
    public string nomclient { get; set; }
    public int idregion { get; set; }
    public string nomregion { get; set; }
    public double signal { get; set; }

    public static List<DetailClient> FindAll() {
        try {
            List<DetailClient> allDetailClient = new List<DetailClient>();
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();
            
            string sql = "select * from v_detail_client";
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        DetailClient dc = new DetailClient();
                        dc.idclient = reader.GetInt32(0);
                        dc.nomclient = reader.GetString(1);
                        dc.idregion = reader.GetInt32(2);
                        dc.nomregion = reader.GetString(3);
                        dc.signal = reader.GetDouble(4);
                        allDetailClient.Add(dc);
                    }
                }
            }
            con?.Close();
            return allDetailClient;
        } catch (System.Exception e) {
            throw;
        }
    }

    public static DetailClient FindOne(int idclient) {
        try {
            DetailClient dc = new DetailClient();
            SqlConnection con = Canal.Models.Connection.Connect();
            con?.Open();
            
            string sql = "select * from v_detail_client where idclient = " + idclient;
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        dc.idclient = reader.GetInt32(0);
                        dc.nomclient = reader.GetString(1);
                        dc.idregion = reader.GetInt32(2);
                        dc.nomregion = reader.GetString(3);
                        dc.signal = reader.GetDouble(4);
                    }
                }
            }
            con?.Close();
            return dc;
        } catch (System.Exception e) {
            throw;
        }
    }

    public static DetailClient FindOne(SqlConnection? con, int idclient) {
        try {
            DetailClient dc = new DetailClient();
            
            string sql = "select * from v_detail_client where idclient = " + idclient;
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        dc.idclient = reader.GetInt32(0);
                        dc.nomclient = reader.GetString(1);
                        dc.idregion = reader.GetInt32(2);
                        dc.nomregion = reader.GetString(3);
                        dc.signal = reader.GetDouble(4);
                    }
                }
            }
            return dc;
        } catch (System.Exception e) {
            throw;
        }
    }
}