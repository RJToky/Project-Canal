using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Canal.Models;

namespace Canal.Controllers;

public class ClientController : Controller {
    private readonly ILogger<ClientController> _logger;

    public ClientController(ILogger<ClientController> logger) {
        _logger = logger;
    }

    public IActionResult ListClient() {
        ViewBag.listc = Canal.Models.DetailClient.FindAll();
        return View();
    }

    public IActionResult DetailAbonnementClient(int idclient) {
        ViewBag.client = Canal.Models.DetailClient.FindOne(idclient);
        ViewBag.listac = Canal.Models.AbonnementClient.FindByIdclient(idclient);
        ViewBag.bouquetdispo = Canal.Models.Client.FindBouquetDisponible(idclient);
        ViewBag.chainedispo = Canal.Models.Chaine.FindChaineDisponible(idclient);
        ViewBag.bouquetperso = Canal.Models.DetailBouquet.FindBouquetPerso(idclient);

        return View();
    }

    [HttpPost]
    public IActionResult Reserver(IFormCollection form) {
        int idbouquet = int.Parse(form["idbouquet"]);
        int idclient = int.Parse(form["idclient"]);
        Canal.Models.Abonnement.Insert(idclient, idbouquet);

        return RedirectToAction("DetailAbonnementClient", new {idclient = form["idclient"]});
    }

    [HttpPost]
    public IActionResult Personnaliser(IFormCollection form) {
        string nombouquet = form["nombouquet"];
        string[] chaines = form["idchaine"];
        int idclient = int.Parse(form["idclient"]);
        Canal.Models.Bouquet.InsertPersonnalise(nombouquet, chaines, idclient);

        return RedirectToAction("DetailAbonnementClient", new {idclient = form["idclient"]});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
