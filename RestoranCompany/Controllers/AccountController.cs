using DAL.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using RestoranCompany.Entities;
using RestoranCompany.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace RestoranCompany.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly RestoranCompanyDbContext _restoranContext;
        private readonly IConfiguration _configuration;

        public AccountController(RestoranCompanyDbContext restoranContext, IConfiguration configuration)
        {
            _restoranContext = restoranContext;
            _configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                //Login İşlemleri

                string hashedPassword = HashedPassword(model.Password);

                User user = _restoranContext.Users.SingleOrDefault(x => x.Username.ToLower() == model.Username.ToLower() && x.Password == hashedPassword);

                if (user != null)
                {
                    if (user.Locked)
                    {
                        ModelState.AddModelError(nameof(model.Username), "Kullanıcı kilitli. Lütfen yönetici ile görüşünüz.");
                        return View(model);
                    }

                    //Kendime not. Claim eklerken hazır typelarıda kullanabiliriz. Yada "" içerisinde kendimiz de claim tanımlayabiliriz.
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.Adi ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Surname, user.Soyadi ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Email, user.Epostasi ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.StreetAddress, user.Adresi ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.OtherPhone, user.TelNoSu ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    claims.Add(new Claim("KullanıcıAdı", user.Username));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı ya da kullanıcı parolası hatalı.");
                }

            }
            return View(model);
        }

        private string HashedPassword(string s)
        {
            string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
            string salted = s + md5Salt;
            string hashed = salted.MD5();
            return hashed;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Register işlemleri

                if(_restoranContext.Users.Any(x=> x.Username == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Bu kullanıcı adı başka bir kullanıcıya ait.");
                    return View(model);
                }

                string hashedPassword = HashedPassword(model.Password); //Yukarıda login kısmında haslediğimiz parolamızın methodunu buraya çağırıyoruz.

                User user = new()
                {
                    Username = model.Username,
                    Password = hashedPassword,
                    Adi = model.Ad,
                    Soyadi = model.Soyad,
                    TelNoSu = model.TelNo,
                    Adresi = model.Adres,
                    Epostasi = model.Eposta
                };

                _restoranContext.Users.Add(user);
                int affectedRowCount = _restoranContext.SaveChanges();

                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "Kullanici eklenemedi.");
                }
                else 
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return View(model);
        }

        public IActionResult Profil()
        {
            ProfileDataYukleyici();
            return View();
        }


        public IActionResult Profile()
        {
            ProfileDataYukleyici();

            return View();
        }

        private void ProfileDataYukleyici()
        {


            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _restoranContext.Users.SingleOrDefault(x => x.Id == userid);
            ViewData["Adi"] = user.Adi;
            ViewData["Soyadi"] = user.Soyadi;
            ViewData["Password"] = user.Password;
            ViewData["Epostasi"] = user.Epostasi;
            ViewData["Adresi"] = user.Adresi;
            ViewData["TelNoSu"] = user.TelNoSu;
            ViewData["Role"] = user.Role;

        }


        [HttpPost]
        public IActionResult ProfileChangeName([Required(ErrorMessage = "Lütfen yeni bir isim giriniz. Boş bırakmayınız.")][StringLength(40, ErrorMessage = "İsim 40 karakterden fazla olamaz.")] string? adi) //Datayı modelden çekebileceğimiz gibi View sayfasında inputa isim vererek te isimden çekebiliriz.
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _restoranContext.Users.SingleOrDefault(x => x.Id == userid);

                user.Adi = adi;
                _restoranContext.SaveChanges();
  
               ViewData["result"] = "NameChanged";

               //return RedirectToAction(nameof(Profile));

            }

            ProfileDataYukleyici();
            return View("Profile");

        }     

     

        [HttpPost]
        public IActionResult ProfileChangeSurname([Required(ErrorMessage = "Lütfen yeni bir soyisim giriniz. Boş bırakmayınız.")][StringLength(25, ErrorMessage ="Soyisim 25 karakterden fazla olamaz.")] string ? soyadi)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _restoranContext.Users.SingleOrDefault(x => x.Id == userid);

                user.Soyadi = soyadi;
                _restoranContext.SaveChanges();

               
                ViewData["result"] = "SurnameChanged";

                //return RedirectToAction(nameof(Profile));
            }

            ProfileDataYukleyici();
            return View("Profile");
        }

        [HttpPost]
        public IActionResult ProfileChangePassword([Required(ErrorMessage = "Lütfen yeni bir parola giriniz. Boş bırakmayınız.")][MinLength(4,ErrorMessage ="Parola 4 karakterden az olamaz."),MaxLength(20, ErrorMessage = "Parola 20 karakterden fazla olamaz.")] string? parola)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _restoranContext.Users.SingleOrDefault(x => x.Id == userid);

                string hashedPassword = HashedPassword(parola);

                user.Password = hashedPassword;
                _restoranContext.SaveChanges();

                ViewData["result"] = "PasswordChanged";
            }

            ProfileDataYukleyici();
            return View("Profile");

        }

        [HttpPost]
        public IActionResult ProfileChangeEposta([Required][MaxLength(100, ErrorMessage ="Eposta 100 karakterden fazla olamaz.")] string? epostasi)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _restoranContext.Users.SingleOrDefault(x => x.Id == userid);

                user.Epostasi = epostasi;
                _restoranContext.SaveChanges();

                ViewData["result"] = "EpostaChanged";

            }

            ProfileDataYukleyici();
            return View("Profile");

        }

        [HttpPost]
        public IActionResult ProfileChangeAdres([Required][MaxLength(200, ErrorMessage = "Adres 200 karakterden fazla olamaz.")] string? adresi)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _restoranContext.Users.SingleOrDefault(x => x.Id == userid);

                user.Adresi = adresi;
                _restoranContext.SaveChanges();

                ViewData["result"] = "AdresChanged";

            }

            ProfileDataYukleyici();
            return View("Profile");

        }

        [HttpPost]
        public IActionResult ProfileChangePhone([Required][MinLength(10, ErrorMessage = "Telefon Numaranız 10 karakterden az olamaz. Başına 0 girmeden tekrar deneyin.")][MaxLength(10, ErrorMessage = "Telefon Numaranız 10 karakterden fazla olamaz. Başına 0 girmeden tekrar deneyin.")] string? telnosu)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _restoranContext.Users.SingleOrDefault(x => x.Id == userid);

                user.TelNoSu = telnosu;
                _restoranContext.SaveChanges();

                ViewData["result"] = "PhoneChanged";

            }

            ProfileDataYukleyici();
            return View("Profile");

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
