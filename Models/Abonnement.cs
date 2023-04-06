namespace Canal.Models;

public class Abonnement {
    public int id { get; set; }
    public int idclient { get; set; }
    public int idbouquet { get; set; }
    public string datedebut { get; set; }
    public string datefin { get; set; }
}