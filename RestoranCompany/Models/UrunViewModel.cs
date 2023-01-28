using RestoranCompany.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestoranCompany.Models
{
    public class UrunModel
    {
        
            public int Id { get; set; }

            public int KategoriId { get; set; }

            public string Adi { get; set; }

            public decimal UrunFiyat { get; set; }

            public int UrunAdet { get; set; }

        

    }

    public class CreatUrunModel
    {
        public int Id { get; set; }

        public int KategoriId { get; set; }

        public string Adi { get; set; }

        public decimal UrunFiyat { get; set; }

        public int UrunAdet { get; set; }


    }

    public class EditUrunModel
    {
        public int KategoriId { get; set; }

        public string Adi { get; set; }

        public decimal UrunFiyat { get; set; }

        public int UrunAdet { get; set; }

        public IEnumerable<Kategori> Kategori { get; set; }
    }
}
