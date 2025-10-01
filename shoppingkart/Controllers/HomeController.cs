using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // Sample product list
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 55000, ImageUrl = "/images/laptop.jpg", Category="Laptop" },
            new Product { Id = 2, Name = "Smartphone", Price = 25000, ImageUrl = "/images/phone.png", Category="Phone" },
            new Product { Id = 3, Name = "Headphones", Price = 2000, ImageUrl = "/images/headphones.png", Category="Accessories" },
            new Product { Id = 4, Name = "Shoes", Price = 1500, ImageUrl = "/images/shoes.jpg", Category="Shoes" }
        };

        // Default home page
        public IActionResult Index()
        {
            return View(_products);
        }

        // Search products by query
        [HttpGet]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                return View("Index", _products);

            var results = _products
                .Where(p => p.Name.ToLower().Contains(query.ToLower()))
                .ToList();

            return View("Index", results);
        }

        // Filter products by category
        [HttpGet]
        public IActionResult Category(string category)
        {
            if (string.IsNullOrEmpty(category))
                return View("Index", _products);

            var results = _products
                .Where(p => p.Category.Equals(category, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            return View("Index", results);
        }

    }
}
