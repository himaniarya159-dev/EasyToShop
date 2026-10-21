using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EasyToShop.Models;

public class ProductCreateViewModel
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 10000.00)]
    public decimal Price { get; set; }

    [Required]
    [Range(0, 1000)]
    public int StockQuantity { get; set; }

    [Display(Name = "Product Image")]
    public IFormFile? ImageFile { get; set; }
}