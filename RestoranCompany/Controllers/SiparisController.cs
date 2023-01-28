using AutoMapper;
using DAL.Context;
using ENTITIES.Entity;
using Microsoft.AspNetCore.Mvc;
using RestoranCompany.Entity;
using RestoranCompany.Models;

namespace RestoranCompany.Controllers
{
    public class SiparisController : Controller
    {
        private readonly RestoranCompanyDbContext _restoranContext;
        private readonly IConfiguration _configuration;


        public SiparisController(RestoranCompanyDbContext restoranContext, IConfiguration configuration)
        {
            _restoranContext = restoranContext;
            _configuration = configuration;
        }

        public IActionResult Index()
        {

            //Kendime not: AutoMapper kullanmayacaksak çoklu modelleri böyle gösterebiliriz.

            SiparisModel model = new();
            model.Masa = _restoranContext.Masalar.ToList();
            model.Kategori = _restoranContext.Kategoriler.ToList();
            model.OdemeSekil = _restoranContext.OdemeSekiller.ToList();
            model.SiparisSekil = _restoranContext.SiparisSekiller.ToList();
            model.Urun = _restoranContext.Urunler.ToList();



            //List<SiparisModel> siparisler =
            //   _restoranContext.Siparisler.ToList()
            //   .Select(x => _mapper.Map<SiparisModel>(x)).ToList();

            return View(model);

        }

        public IActionResult Index2()

        {

            SiparisModel siparis = new();
            siparis.Masa = _restoranContext.Masalar.ToList();
            siparis.Kategori = _restoranContext.Kategoriler.ToList();
            siparis.OdemeSekil = _restoranContext.OdemeSekiller.ToList();
            siparis.SiparisSekil = _restoranContext.SiparisSekiller.ToList();
            siparis.Urun = _restoranContext.Urunler.ToList();

            return View(siparis);
        }


        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Create(SiparisModel siparisler)
        {
            Siparis siparis = new Siparis();

            _restoranContext.Siparisler.Add(siparis);
            _restoranContext.SaveChanges();

            return RedirectToAction(nameof(Index));


            return View(siparisler);
        }

        //public IActionResult Delete(int Id)
        //{
        //    _restoranContext.Siparisler.Find(Id);


        //    if (siparis != null)

        //    {
        //        _restoranContext.Kategoriler.Remove(Sipar);
        //        _restoranContext.SaveChanges();
        //    }

        //    return RedirectToAction(nameof(Index2));
      //  }
    }
}
