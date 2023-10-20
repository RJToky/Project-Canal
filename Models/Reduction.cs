using System.Data.SqlClient;

namespace Canal.Models;

public class Reduction {
    public int nbrchaine { get; set; }
    public double valeur { get; set; }

    public static double FindReduction(SqlConnection? con, int nbrchaine) {
        try {
            string sql = "select valeur from reduction where nbrchaine = " + nbrchaine;
            using(SqlCommand command = new SqlCommand(sql, con)) {
                using(SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        return reader.GetDouble(0);
                    }
                }
            }
            return 0.0;
        } catch (System.Exception e) {
            throw;
        }
    }
}