using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.ModelView
{
    public class UserLoginModel
    {
        [DisplayName("TCKimlikNumarası"), Required(ErrorMessage = "{0} boş geçilemez."), StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string TCKimlik { get; set; }

        [DisplayName("DogumTarihi"), Required(ErrorMessage = "{0} boş geçilemez."), StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string DogumTarihi { get; set; }
    }
}