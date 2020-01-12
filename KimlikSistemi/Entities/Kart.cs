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
  public  class Kart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string KartSahibiAdSoyad { get; set; }

        public double KartNumarasi { get; set; }

        public int CVV { get; set; }

        public int Ay { get; set; }

        public int Yil { get; set; }

        [DisplayName("Randevu Onay")]
        public bool Onay { get; set; }

        public virtual int OdenecekTutar { get; set; }

        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }

    }
}
