using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ui.BAWANG.Models
{
    public class Tb_Jejaring
    {

        [Required(ErrorMessage = "Harap masukan data NIS")]
        [Display(Name = "NIS")]
        public int NIS { get; set; }

        [Display(Name = "Nama Lengkap")]
        public string Nama_Siswa { get; set; }

        [Display(Name = "Kelas")]
        public string Kelas { get; set; }

        [Display(Name = "Jumlah_Poin")]
        public int Jumlah_Poin { get; set; }
        public string isDelete { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
    }
}