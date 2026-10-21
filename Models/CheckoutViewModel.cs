using System.ComponentModel.DataAnnotations;

namespace EasyToShop.Models;

public class CheckoutViewModel
{
    [Required(ErrorMessage = "Full Name is required")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Shipping address is required")]
    [Display(Name = "Shipping Address")]
    public string ShippingAddress { get; set; } = string.Empty;

    [Required(ErrorMessage = "City is required")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Postal Code is required")]
    [Display(Name = "Postal Code")]
    public string PostalCode { get; set; } = string.Empty;

    // --- Payment Fields ---
    [Required(ErrorMessage = "Please select a payment method")]
    [Display(Name = "Payment Method")]
    public string PaymentMethod { get; set; } = "CreditCard"; // Options: CreditCard, PayPal, COD

    public string? CardNumber { get; set; }
    public string? ExpirationDate { get; set; }
    public string? Cvv { get; set; }

    public CartViewModel Cart { get; set; } = new();
}