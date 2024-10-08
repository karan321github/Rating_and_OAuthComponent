using GoogleAuth.Data;
using GoogleAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GoogleAuth.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Ratings).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            product.AverageRating = product.Ratings.Any() ? product.Ratings.Average(r => r.Value) : 0;

            return View(product);
        }

        [HttpPost]
        public IActionResult RateProduct(int productId, int ratingValue)
        {
            // Check if the product exists
            var product = _context.Products.Include(p => p.Ratings).FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            // Create a new rating
            var rating = new Rating
            {
                ProductId = productId,
                Value = ratingValue
            };

            // Add the rating to the database
            _context.Ratings.Add(rating);
            _context.SaveChanges();

            // Recalculate the average rating
            product.AverageRating = product.Ratings.Any() ? product.Ratings.Average(r => r.Value) : 0;
            _context.SaveChanges();

            return Ok(); // Return success
        }
    }
}
