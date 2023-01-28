using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entity
{
    [Table("SiparisSekiller")]
    public class SiparisSekil
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SiparisSekilAd { get; set; }


        public ICollection<Siparis> Siparsler { get; set; }
    }
}
