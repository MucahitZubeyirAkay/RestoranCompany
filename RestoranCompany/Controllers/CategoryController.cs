using AutoMapper;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using RestoranCompany.Entities;
using RestoranCompany.Entity;
using RestoranCompany.Models;
using System.Collections.Generic;

namespace RestoranCompany.Controllers
{
    public class CategoryController : Controller
    {

        private readonly RestoranCompanyDbContext _restoranContext;
        private readonly IMapper _mapper; 

        public CategoryController(RestoranCompanyDbContext restoranContext, IMapper mapper) 
        {
            _restoranContext = restoranContext;
            _mapper = mapper;
        }


        public IActionResult Index()
        {

            
            List<CategoryViewModel> kategoriler =
               _restoranContext.Kategoriler.ToList()
               .Select(x => _mapper.Map<CategoryViewModel>(x)).ToList();


            return View(kategoriler);

        }






        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatCategoryModel kategoriler)
        {
            if (ModelState.IsValid)
            {
                if (_restoranContext.Kategoriler.Any(x => x.KategoriAdi.ToLower() == kategoriler.KategoriAdi.ToLower()))
                {
                    ModelState.AddModelError(nameof(kategoriler.KategoriAdi), "Bu kategori zaten mevcut");
                    return View(kategoriler);
                }

                Kategori kategori = _mapper.Map<Kategori>(kategoriler);

                _restoranContext.Kategoriler.Add(kategori);
                _restoranContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(kategoriler);
        }

        public IActionResult Edit(int id)
     {
            Kategori kategori = _restoranContext.Kategoriler.Find(id);
            EditCategoryModel model = _mapper.Map<EditCategoryModel>(kategori);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, CategoryViewModel model)
       {
            if (ModelState.IsValid)
          {
               if (_restoranContext.Kategoriler.Any(x => x.KategoriAdi.ToLower() == model.KategoriAdi.ToLower() && x.Id != id))
               {
                  ModelState.AddModelError(nameof(model.KategoriAdi), "Bu katageri zaten mevcut.");
                  return View(model);
              }

              Kategori kategori = _restoranContext.Kategoriler.Find(id);

             _mapper.Map(model, kategori);
             _restoranContext.SaveChanges();
    
              return RedirectToAction(nameof(Index));
        }
            return View(model);
     }

        public IActionResult Delete(int id)
        {

            Kategori kategori = _restoranContext.Kategoriler.Find(id);

            if (kategori != null)

            {
                _restoranContext.Kategoriler.Remove(kategori);
                _restoranContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
    

