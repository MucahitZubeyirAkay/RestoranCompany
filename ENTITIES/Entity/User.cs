using ENTITIES.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestoranCompany.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        
        [StringLength(40)]
        public string? Adi { get; set; } = null;


        [StringLength(25)]
        public string? Soyadi { get; set; } = null;

        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(10)]
        public string? TelNoSu { get; set; }

        [StringLength(200)]
        public string? Adresi { get; set; }

        [StringLength(100)]
        public string? Epostasi { get; set; }

        public bool Locked { get; set; } = false;

        public DateTime Createdate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";



    }
}
