using System.Data.SqlClient;

namespace Canal.Models;

public class Connection
{

    public static SqlConnection? Connect()
    {
        string conString = @"Data Source=localhost;Initial Catalog=canal;Integrated Security=True";
        return new SqlConnection(conString);
    }
}