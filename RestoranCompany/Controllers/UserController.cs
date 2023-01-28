using AutoMapper;
using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using RestoranCompany.Entities;
using RestoranCompany.Entity;
using RestoranCompany.Models;

namespace RestoranCompany.Controllers
{
    public class UserController : Controller
    {
        private readonly RestoranCompanyDbContext _restoranContext;
        private readonly IMapper _mapper; //Mapper kullanılacağı zaman bunun yazılması gerekiyor.

        public UserController(RestoranCompanyDbContext restoranContext, IMapper mapper) //Mapper kullanılacağı zaman bunun yazılması gerekiyor.
        {
            _restoranContext = restoranContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<UserModel> users =
               _restoranContext.Users.ToList()
               .Select(x => _mapper.Map<UserModel>(x)).ToList();


            //List<User> users = _restoranContext.Users.ToList();
            //List<UserModel> model = users.Select(x => _mapper.Map<UserModel>(x)).ToList();  //Kendime not. Datayı modele çevirirken automapper sayasinde bu şekilde çevirebiliriz. 2 yöntemde olur.
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {
            if(ModelState.IsValid)
            {
                if(_restoranContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))  //Bu if ile kullanıcı adı sistemde varsa tekrar aynı kullanıcı adınının alınmasını engelliyor.
                {
                    ModelState.AddModelError(nameof(model.Username), "Kullanıcı adı başkası tarafından alınmış.");
                    return View(model);
                }

                User user= _mapper.Map<User>(model);

                _restoranContext.Users.Add(user);
                _restoranContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(Guid id)
        {
          

            User user = _restoranContext.Users.Find(id);
            EditUserModel model = _mapper.Map<EditUserModel>(user);  //Kendime not. EditUserModeli CreateUserModelden miras alsak da automapper tanımlamasını yapıyoruz ki çevirebilsin..
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_restoranContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.Username), "Kullanıcı adı başkası tarafından alınmış.");
                    return View(model);
                }

                User user = _restoranContext.Users.Find(id);

                _mapper.Map(model, user);
                _restoranContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(Guid id)
        {
     
                User user = _restoranContext.Users.Find(id);

                if(user != null)

                {
                    _restoranContext.Users.Remove(user);
                    _restoranContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
        }
    }
}
