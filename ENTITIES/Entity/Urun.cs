using RestoranCompany.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entity
{
    [Table("Urunler")]
    public class Urun
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Kategori))]
        public int KategoriId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }

        public decimal UrunFiyat  { get; set; }

        public int UrunAdet { get; set; }

        public Kategori Kategori { get; set; }

        public ICollection<Siparis> Siparisler { get; set; }

    }
}
