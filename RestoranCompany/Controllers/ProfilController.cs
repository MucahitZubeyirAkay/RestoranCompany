using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using RestoranCompany.Entities;

namespace RestoranCompany.Controllers
{
    public class ProfilController : Controller
    {
       
        private readonly RestoranCompanyDbContext _restoranContext;
        private readonly IConfiguration _configuration;

        public ProfilController(RestoranCompanyDbContext restoranContext, IConfiguration configuration)
        {
            _restoranContext = restoranContext;
            _configuration = configuration;
        }



        public IActionResult Profil()
        {
            return View();
        }
    }
}
