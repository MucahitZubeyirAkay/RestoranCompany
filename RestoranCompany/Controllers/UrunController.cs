using AutoMapper;
using DAL.Context;
using ENTITIES.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestoranCompany.Entity;
using RestoranCompany.Models;

namespace RestoranCompany.Controllers
{
    public class UrunController : Controller
    {


        private readonly RestoranCompanyDbContext _restoranContext;
        private readonly IMapper _mapper;

        public UrunController(RestoranCompanyDbContext restoranContext, IMapper mapper)
        {
            _restoranContext = restoranContext;
            _mapper = mapper;
        }

        


        public IActionResult Index()
        {
            List<UrunModel> urunler =
               _restoranContext.Urunler.ToList()
               .Select(x => _mapper.Map<UrunModel>(x)).ToList();

            return View(urunler);
        }

        public IActionResult Create()
        {
            var list = _restoranContext.Kategoriler.ToList();
            ViewBag.Categories = new SelectList(list, "Id", "KategoriAdi");
            return View();
        }


      
        [HttpPost]
        public IActionResult Create(CreatUrunModel urunler)
        {
           

            if (ModelState.IsValid)
            {
                if (_restoranContext.Urunler.Any(x => x.Adi.ToLower() == urunler.Adi.ToLower()))
                {
                    ModelState.AddModelError(nameof(urunler.Adi), "Bu urun zaten mevcut");
                    return View(urunler);
                }

                Urun urun = _mapper.Map<Urun>(urunler);
                
                _restoranContext.Urunler.Add(urun);
                _restoranContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

           
            return View(urunler);
        }


      

        public IActionResult Edit(int id)
        {
            Urun urun = _restoranContext.Urunler.Find(id);
            EditUrunModel model = _mapper.Map<EditUrunModel>(urun);

            model.Kategori = _restoranContext.Kategoriler.ToList();

            return View(model);
        }

        

        [HttpPost]
        public IActionResult Edit(int id, UrunModel model)
        {
            Kategori kategori = new Kategori();

            if (ModelState.IsValid)
            {
                if (_restoranContext.Urunler.Any(x => x.Adi.ToLower() == model.Adi.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.Adi), "Bu ürün zaten mevcut.");

                    //if (model = _restoranContext.Urunler.Where(x => x.KategoriId == id).ToList();)
                    //{
                    //    ModelState.AddModelError(nameof(model.KategoriId), "Böyle bi kategori yoktur.");
                    //}
                    return View(model);
                }

               

                Urun urun = _restoranContext.Urunler.Find(id);

                _mapper.Map(model, urun);
                _restoranContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {

            Urun urun = _restoranContext.Urunler.Find(id);

            if (urun != null)

            {
                _restoranContext.Urunler.Remove(urun);
                _restoranContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
