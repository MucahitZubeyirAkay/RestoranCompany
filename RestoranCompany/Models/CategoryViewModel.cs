using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ENTITIES.Entity;

namespace RestoranCompany.Models
{
    public class CategoryViewModel
    {
        
            public int Id { get; set; }


            public string KategoriAdi { get; set; }


            public string? KategoriAciklamasi { get; set; }

            public IEnumerable<Urun> Urun { get; set; }


    }

    public class CreatCategoryModel
    {

        public int Id { get; set; }


        public string KategoriAdi { get; set; }


        public string? KategoriAciklamasi { get; set; }


    }

    public class EditCategoryModel
    {


        public string KategoriAdi { get; set; }


        public string? KategoriAciklamasi { get; set; }


    }

    
}
