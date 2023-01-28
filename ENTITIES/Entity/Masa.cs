using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entity
{
    [Table("Masalar")]
    public class Masa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string MasaAd { get; set; }


        public bool? Locked { get; set; } = false;


        [StringLength(50)]

        public string? MasaAciklama { get; set; }

        public ICollection<Siparis> Siparisler { get; set; }


    }
}
