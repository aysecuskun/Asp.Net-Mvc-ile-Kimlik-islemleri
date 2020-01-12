using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelView
{
   public class KartModelViews
    {
        [DisplayName("KartSahibininAdıSoyadı"), Required(ErrorMessage = "{0} boş geçilemez."), StringLength(50, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string NameSurname { get; set; }

        [DisplayName("Kart Numarası"), Required(ErrorMessage = "{0} boş geçilemez.")]
        public double KartNumarasi { get; set; }

        [DisplayName("CVV"), Required(ErrorMessage = "{0} boş geçilemez.")]
        public int CVV { get; set; }


        [DisplayName("Ay"), Required(ErrorMessage = "{0} boş geçilemez.")]
        public int Ay { get; set; }


        [DisplayName("Yıl"), Required(ErrorMessage = "{0} boş geçilemez.")]
        public int Yil { get; set; }


        [DisplayName("OdemeTutarı"), Required(ErrorMessage = "{0} boş geçilemez.")]
        public int OdemeTutari { get; set; }


    }
}
