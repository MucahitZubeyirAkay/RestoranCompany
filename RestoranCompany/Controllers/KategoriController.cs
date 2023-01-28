using DAL.Context;
using ENTITIES.Entity;
using Microsoft.AspNetCore.Mvc;
using RestoranCompany.Entity;

namespace RestoranCompany.Controllers
{
    public class KategoriController : Controller
    {
        private readonly RestoranCompanyDbContext _restoranContext;
        private readonly IConfiguration _configuration;


        public KategoriController(RestoranCompanyDbContext restoranContext, IConfiguration configuration)
        {
            _restoranContext = restoranContext;
            _configuration = configuration;
        }


        public IActionResult Kategori()
        {
            List<Kategori> kategorilist = _restoranContext.Kategoriler.ToList();
            return View(kategorilist);
        }

        public IActionResult Urun(int id)
        {
            List<Urun> urunlist = _restoranContext.Urunler.Where(x => x.KategoriId == id).ToList();
            //var degerler = _restoranContext.Urunler.Where(x => x.KategoriId == id).ToList();
            return View(urunlist);
        }
    }
}
