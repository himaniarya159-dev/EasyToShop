using System.Diagnostics;
using EasyToShop.Data;
using EasyToShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        var products = _db.Products.ToList();
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ReturnPolicy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}