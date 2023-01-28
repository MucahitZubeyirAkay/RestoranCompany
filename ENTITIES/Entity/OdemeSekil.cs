using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Entity
{
   
        [Table("OdemeSekiller")]
        public class OdemeSekil
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required]
            [StringLength(25)]
            public string OdemeSekilAd { get; set; }

            public ICollection<Siparis> Siparisler { get; set; }


        } 
    
}
