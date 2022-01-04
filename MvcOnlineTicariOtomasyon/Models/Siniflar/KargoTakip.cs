using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipid { get; set; }

        [Display(Name = "Takip Kodu")]
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }

        [Display(Name = "Açıklama")]
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Aciklama { get; set; }

        [Display(Name = "Tarih")]
        public DateTime TarihZaman { get; set; }
    }
}