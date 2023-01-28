using System.ComponentModel.DataAnnotations;

namespace RestoranCompany.Models
{
   
        public class RegisterViewModel
        {
            [Required(ErrorMessage = "Kullanci isimi girmek zorunludur.")]
            [StringLength(15, ErrorMessage = "Kullanıcı Adı maks. '15' karakter olabilir.")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Şifre girmek zorunludur.")]
            [MinLength(4, ErrorMessage = "Şifre en az 4 karakter olmalıdır.")]
            [MaxLength(16, ErrorMessage = "Şifre en fazla 16 karakter olmalıdır.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Şifre tekrar girmek zorunludur.")]
            [MinLength(4, ErrorMessage = "Şifre en az 4 karakter olmalıdır.")]
            [MaxLength(16, ErrorMessage = "Şifre en fazla 16 karakter olmalıdır.")]
            [Compare(nameof(Password))]
            public string RePassword { get; set; }

            public string? Ad { get; set; }

            public string? Soyad { get; set; }

            public string? TelNo { get; set; }

            public string? Adres { get; set; }

            public string? Eposta { get; set; }

        


        }
    
}
