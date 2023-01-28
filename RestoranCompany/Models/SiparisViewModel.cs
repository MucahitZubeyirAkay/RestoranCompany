using ENTITIES.Entity;
using RestoranCompany.Entities;
using RestoranCompany.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestoranCompany.Models
{
    public class SiparisModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public int? KategoriID { get; set; }

        public int? UrunId { get; set; }


        public int? OdemeSekilId { get; set; }

        public int? SiparisSekilId { get; set; }


        public int? MasaId { get; set; }



        public string? SiparisVerenAd { get; set; }


        public string? SiparisVerenSoyad { get; set; }


        public string? SiparisAdres { get; set; }


        public string? SiparisTelNo { get; set; }

        public string? Eposta { get; set; }

        public decimal? IndririmTutar { get; set; }

        public decimal? ToplamTutar { get; set; }


        public DateTime? SiparisZamani { get; set; } = DateTime.Now;


        public string? SiparisAciklama { get; set; }


        public IEnumerable<Kategori> Kategori { get; set; }

        public IEnumerable<Masa> Masa { get; set; }

        public IEnumerable<SiparisSekil> SiparisSekil { get; set; }

        public IEnumerable<OdemeSekil> OdemeSekil { get; set; }

        public IEnumerable<Urun> Urun { get; set; }


    }
        
}
