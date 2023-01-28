using ENTITIES.Entity;
using RestoranCompany.Entities;
using RestoranCompany.Entity;
using System.ComponentModel.DataAnnotations;

namespace RestoranCompany.Models
{
    public class UrunKategoriUserSiparisViewModel
    {
        //public class User
        //{
            
        //    public Guid Id { get; set; }

        //    public string? Adi { get; set; } = null;

        //    public string? Soyadi { get; set; } = null;

        //    public string Username { get; set; }

        //    public string? TelNoSu { get; set; }

        //    public string? Adresi { get; set; }

        //    public string? Epostasi { get; set; }

        //    public string Role { get; set; } = "user";

        //}

        public IEnumerable<User> User { get; set; }
        public IEnumerable<Siparis> Siparis { get; set; }
        public IEnumerable<Kategori> Kategori { get; set; }

        public IEnumerable<Urun> Urun { get; set; }

        public IEnumerable<OdemeSekil> OdemeSekil { get; set; }
    }
    
}

