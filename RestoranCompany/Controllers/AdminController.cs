using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestoranCompany.Controllers
{
    //Kendime not. [Authorize(Roles = "admin,manager")] Buradan hangi role sahipse onun girişine izin verileceğini ayarlıyoruz. Authorize içerisine yazdığımız admin dışındaki
    //role sahip kişilerin girişini engeller.
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        //[Authorize] Bu şeklide tek actiona da verebiliriz. Tüm actionlara vermek istiyorsak sınıfın üstüne yazarız.
        public IActionResult Index()
        {
            return View();
        }
    }
}
