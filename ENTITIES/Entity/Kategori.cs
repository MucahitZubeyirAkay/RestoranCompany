using ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranCompany.Entity
{
    [Table("Kategoriler")]
    public class Kategori
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string KategoriAdi { get; set; }

        [StringLength(200)]
        public string? KategoriAciklamasi { get; set; }

        public ICollection<Urun> Urunler { get; set; }

    }
}
