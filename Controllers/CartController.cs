using EasyToShop.Data;
using EasyToShop.Helpers;
using EasyToShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToShop.Controllers;

[Route("Cart")]
public class CartController : Controller
{
    private readonly ApplicationDbContext _db;

    public CartController(ApplicationDbContext db)
    {
        _db = db;
    }

    private CartViewModel GetCart()
    {
        return HttpContext.Session.GetObjectFromJson<CartViewModel>("EasyToShopCart") ?? new CartViewModel();
    }

    private void SaveCart(CartViewModel cart)
    {
        HttpContext.Session.SetObjectAsJson("EasyToShopCart", cart);
    }

    // Handles both http://localhost:5091/Cart and http://localhost:5091/Cart/Index
    [HttpGet]
    [Route("")]
    [Route("Index")]
    public IActionResult Index()
    {
        return View(GetCart());
    }

    // Handles POST and GET requests for http://localhost:5091/Cart/AddToCart
    [HttpPost("AddToCart")]
    [HttpGet("AddToCart")]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
    {
        var product = await _db.Products.FindAsync(productId);
        if (product == null)
        {
            return NotFound();
        }

        var cart = GetCart();
        var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            cart.Items.Add(new CartItemViewModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitPrice = product.Price,
                Quantity = quantity > 0 ? quantity : 1
            });
        }

        SaveCart(cart);
        return RedirectToAction("Index");
    }

    [HttpPost("UpdateQuantity")]
    [IgnoreAntiforgeryToken]
    public IActionResult UpdateQuantity(int productId, string actionType)
    {
        var cart = GetCart();
        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item != null)
        {
            if (actionType == "increase")
            {
                item.Quantity++;
            }
            else if (actionType == "decrease")
            {
                item.Quantity--;
                if (item.Quantity <= 0)
                {
                    cart.Items.Remove(item);
                }
            }
            SaveCart(cart);
        }

        return RedirectToAction("Index");
    }

    [HttpPost("RemoveFromCart")]
    [IgnoreAntiforgeryToken]
    public IActionResult RemoveFromCart(int productId)
    {
        var cart = GetCart();
        cart.Items.RemoveAll(i => i.ProductId == productId);
        SaveCart(cart);

        return RedirectToAction("Index");
    }

    [HttpPost("ApplyCoupon")]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> ApplyCoupon(string promoCode)
    {
        var cart = GetCart();
        var coupon = await _db.Coupons.FirstOrDefaultAsync(c => c.Code == promoCode && c.IsActive);

        if (coupon != null && (coupon.ExpiryDate == null || coupon.ExpiryDate > DateTime.UtcNow))
        {
            cart.AppliedCouponCode = coupon.Code;
            cart.DiscountAmount = coupon.FixedDiscountAmount > 0
                ? coupon.FixedDiscountAmount
                : (cart.Subtotal * (coupon.DiscountPercentage / 100m));
        }
        else
        {
            TempData["ErrorMessage"] = "Invalid or expired promo code.";
        }

        SaveCart(cart);
        return RedirectToAction("Index");
    }
}