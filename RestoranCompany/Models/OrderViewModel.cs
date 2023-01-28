using ENTITIES.Entity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestoranCompany.Entity;
using RestoranCompany.Entities;

namespace RestoranCompany.Models
{
    public class OrderViewModel
    {
        public List<User> UserList{ get; set; }

        public List<Kategori> KategoriList { get; set; }

        public List<(Urun)> UrunList { get; set; }

        public User Users { get; set; }

        public Kategori Kategoriler { get; set; }

        public Urun Urunler { get; set; }
    }
}
