using GoogleAuth.Models;
using GoogleAuth.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoogleAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger )
        {
            _logger = logger;
         
        }
        public IActionResult CourseSelection()
        {
            var model = checkBoxRepository.GetCourses();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CourseSelection(List<CheckBoxViewModel> courses)
        {
            var selectedCourses = courses.Where(x => x.isChecked).ToList();
            return RedirectToAction("CourseSelection");
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
