using EasyToShop.Data;
using EasyToShop.Data.Entities;
using EasyToShop.DTOs;
using EasyToShop.Helpers;
using EasyToShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToShop.Controllers;

public class CheckoutController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<IdentityUser> _userManager;

    public CheckoutController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    private CartViewModel GetCart()
    {
        return HttpContext.Session.GetObjectFromJson<CartViewModel>("EasyToShopCart") ?? new CartViewModel();
    }

    private void ClearCart()
    {
        HttpContext.Session.Remove("EasyToShopCart");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var cart = GetCart();

        if (cart == null || !cart.Items.Any())
        {
            return RedirectToAction("Index", "Cart");
        }

        var viewModel = new CheckoutViewModel
        {
            Cart = cart
        };

        // Autofill email if user is authenticated
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                viewModel.Email = user.Email ?? string.Empty;
            }
        }

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PlaceOrder(CheckoutViewModel model)
    {
        var cart = GetCart();

        if (cart == null || !cart.Items.Any())
        {
            return RedirectToAction("Index", "Cart");
        }

        model.Cart = cart;

        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }

        // 1. Map ViewModel input to CreateOrderDto to isolate input payload
        var orderDto = new CreateOrderDto
        {
            FullName = model.FullName,
            Email = model.Email,
            ShippingAddress = model.ShippingAddress,
            City = model.City,
            PostalCode = model.PostalCode,
            PaymentMethod = model.PaymentMethod
        };

        // 2. Map DTO to Database Order Entity
        var order = new Order
        {
            UserId = User.Identity != null && User.Identity.IsAuthenticated ? _userManager.GetUserId(User) : null,
            FullName = orderDto.FullName,
            Email = orderDto.Email,
            ShippingAddress = orderDto.ShippingAddress,
            City = orderDto.City,
            PostalCode = orderDto.PostalCode,
            PaymentMethod = orderDto.PaymentMethod,
            TotalAmount = cart.Total,
            OrderDate = DateTime.UtcNow,
            Status = "Paid / Processing"
        };

        // 3. Attach Order Items and deduct Product Stock
        foreach (var item in cart.Items)
        {
            var product = await _db.Products.FindAsync(item.ProductId);
            if (product != null)
            {
                product.StockQuantity = Math.Max(0, product.StockQuantity - item.Quantity);
            }

            order.OrderItems.Add(new OrderItem
            {
                ProductId = item.ProductId,
                UnitPrice = item.UnitPrice,
                Quantity = item.Quantity
            });
        }

        // 4. Save Order to Database
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        // 5. Clear Session Cart
        ClearCart();

        // 6. Redirect to Confirmation Page
        return RedirectToAction("Confirmation", new { id = order.Id });
    }

    [HttpGet]
    public async Task<IActionResult> Confirmation(int id)
    {
        var order = await _db.Orders
            .FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        // Map Entity to Response DTO for View display
        var summaryDto = new OrderSummaryDto
        {
            OrderId = order.Id,
            FullName = order.FullName,
            Email = order.Email,
            ShippingAddress = $"{order.ShippingAddress}, {order.City}, {order.PostalCode}",
            PaymentMethod = order.PaymentMethod,
            TotalAmount = order.TotalAmount,
            OrderDate = order.OrderDate,
            Status = order.Status
        };

        return View(summaryDto);
    }

    // ==========================================
    // Added: Order History Page Action Endpoint
    // ==========================================
    [HttpGet]
    public async Task<IActionResult> Orders()
    {
        var orders = await _db.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();

        return View(orders);
    }
}