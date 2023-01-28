using RestoranCompany.Entities;
using RestoranCompany.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entity
{
    [Table("Siparisler")]
    public class Siparis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

    
        public int? KategoriID { get; set; }

        public int? UrunId { get; set; }


        public int? OdemeSekilId { get; set; }

        public int? SiparisSekilId { get; set; }

  
        public int? MasaId { get; set; }


        [StringLength(40)]
        public string? SiparisVerenAd { get; set; }


        [StringLength(30)]
        public string? SiparisVerenSoyad { get; set; }

        [StringLength(200)]
        public string? SiparisAdres { get; set; }


        [StringLength(11)]
        public string? SiparisTelNo { get; set; }

        public string? Eposta { get; set; }

        public decimal? IndririmTutar { get; set; }

        public decimal? ToplamTutar { get; set; }


        public DateTime? SiparisZamani { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string? SiparisAciklama { get; set; }


       
        public Masa Masa { get; set; }

        public SiparisSekil SiparisSekil { get; set; }

        public OdemeSekil OdemeSekil { get; set; }

        public ICollection<Urun> Urunler { get; set; }


    }
}
