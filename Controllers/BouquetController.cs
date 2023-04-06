using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Canal.Models;

namespace Canal.Controllers;

public class BouquetController : Controller {
    private readonly ILogger<BouquetController> _logger;

    public BouquetController(ILogger<BouquetController> logger) {
        _logger = logger;
    }

    public IActionResult ListBouquet() {
        ViewBag.alldetailbouquet = Canal.Models.DetailBouquet.FindAll();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
