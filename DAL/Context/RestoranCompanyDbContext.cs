using ENTITIES.Entity;
using Microsoft.EntityFrameworkCore;
using RestoranCompany.Entities;
using RestoranCompany.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Context
{
    public class RestoranCompanyDbContext : DbContext
    {

        public RestoranCompanyDbContext(DbContextOptions options) : base(options)
        {
        }


        //public RestoranCompanyDbContext(DbContextOptions<RestoranCompanyDbContext> options) : base(options)
        //{

        //}

        public DbSet<User> Users { get; set; }

        public DbSet<Kategori> Kategoriler { get; set; }

        public DbSet<Urun> Urunler { get; set; }

        public DbSet<Siparis> Siparisler { get; set; }

        public DbSet<OdemeSekil> OdemeSekiller { get; set; }

        public DbSet<Masa> Masalar { get; set; }

        public DbSet<SiparisSekil> SiparisSekiller { get; set; }    




    }
}



















