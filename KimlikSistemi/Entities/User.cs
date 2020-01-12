using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
         [Table("Users")]
        public class User:EntitiesBase
    {
        [DisplayName("T.CKİMLİK"),
        Required(ErrorMessage = "{0} alanı gereklidir."),
        StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string TCKN { get; set; }

        [DisplayName("Ad"),
        StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Soyad"),
        StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }

        [DisplayName("Şifre")]
        public string Password { get; set; }

        [DisplayName("E-Posta"),
        Required(ErrorMessage = "{0} alanı gereklidir."),
        StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }


        [DisplayName("Aktif")]
        public bool IsActive { get; set; }

        [DisplayName("Yönetici")]
        public bool IsAdmin { get; set; }


        [DisplayName("DogumTarihi")]
        public string DogumTarihi { get; set; }

        public virtual List<Randevu> Randevus { get; set; }

        public virtual Kart Karts { get; set; }











    }
}
