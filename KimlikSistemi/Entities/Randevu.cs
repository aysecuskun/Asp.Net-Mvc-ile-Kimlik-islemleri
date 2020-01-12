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
    [Table("Randevularım")]
    public class Randevu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Ad"),
        StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Soyad"),
        StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }

        [DisplayName("Randevu İli")]
        public virtual Il Il { get; set; }

        [DisplayName("Nüfus Müdürlüğü")]
        public virtual Ilce Ilce { get; set; }

        [DisplayName("Randevu Oluşturma Nedeni")]
        public virtual Neden Neden { get; set; }

        [DisplayName("Saat")]
        public Saat Saat { get; set; }

        //[DisplayName("Saat")]
        //public virtual Tarih Tarih { get; set; }

        //[DisplayName("Randevu Günü")]
        //public int TarihId { get; set; }

        [DisplayName("Randevu Günü")]

        public DateTime RandevuGunu { get; set; }

        [DisplayName("Randevu Saati")]
        public int SaatId { get; set; }

        [DisplayName("Randevu Onay")]
        public bool Onay { get; set; }

        [DisplayName("Şehirler")]
        public int Ilid { get; set; }

        [DisplayName("İlçeler")]
        public int Ilceid { get; set; }

        [DisplayName("RandevuNedeni")]
        public int Nedenid { get; set; }

        public virtual User Owner { get; set; }//her bir randevu kendi kullanıcısı tarafından oluşturulur.



    }
}
