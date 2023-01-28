using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestoranCompany.Models;
using System.Diagnostics;

namespace RestoranCompany.Controllers
{
    [Authorize] //Kendime not. Bu kod ile girişleri engelleyebilirsin. Sınıfın başına koyarsan tüm actionları etkiler.
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous] //Kendime not. Bu kod ile de yukarıda ki authorize ezip buraya girişi serbest bırakabilirsin.
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous] 
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}