using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyToShop.Data;
using EasyToShop.Data.Entities;
using EasyToShop.Models;

namespace EasyToShop.Controllers;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AdminController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
    {
        _db = db;
        _webHostEnvironment = webHostEnvironment;
    }

    // GET: /Admin/AddProduct
    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }

    // GET: /Admin/SearchProducts?term=...
    [HttpGet]
    public async Task<IActionResult> SearchProducts(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return Json(new List<object>());
        }

        var products = await _db.Products
            .Where(p => EF.Functions.Like(p.Name, $"%{term}%"))
            .Select(p => new { id = p.Id, title = p.Name, price = p.Price })
            .Take(5)
            .ToListAsync();

        return Json(products);
    }

    // POST: /Admin/AddProduct
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProduct(ProductCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        string imagePath = "/images/default-product.png";

        // Process file upload if provided
        if (model.ImageFile != null && model.ImageFile.Length > 0)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.ImageFile.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }

            imagePath = "/images/" + uniqueFileName;
        }

        var product = new Product
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            StockQuantity = model.StockQuantity,
            ImageUrl = imagePath
        };

        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        ModelState.Clear(); // Ensure form state clears properly after saving

        return RedirectToAction("Index", "Home");
    }
}