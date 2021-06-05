using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ui.BAWANG.Models
{
    public class Tb_Tahun_Pelajaran
    {
       
        [Required(ErrorMessage = "Harap masukan Tanggal")]
        [Display(Name = "Tanggal")]
        public string Tanggal { get; set; }
        public string ID { get; set; } 

        [Display(Name = "Judul")]
        public string Judul { get; set; }

        [Display(Name = "Isi")]
        public string Isi { get; set; }
        public string isDelete { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
    }
}