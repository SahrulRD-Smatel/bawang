using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ui.BAWANG.Models
{
    public class Tb_Penerima_Sertifikat
    {
        [Required(ErrorMessage = "Harap masukan data NIS")]
        [Display(Name = "NIS")]
        public int NIS { get; set; }

        [Required(ErrorMessage = "Harap masukan data Nama Siswa")]
        [Display(Name = "Nama Siswa")]
        public string Nama_Siswa { get; set; }

        [Display(Name = "Kelas")]
        public string Kelas { get; set; }

        [Required(ErrorMessage = "Harap masukan data Poin Spiritual")]
        [Display(Name = "Poin Spiritual")]
        public int Poin_Spiritual { get; set; }
               
        [Display(Name = "Poin 2")]
        public int poin_2 { get; set; }

        [Display(Name = "Poin 3")]
        public int poin_3 { get; set; }

        [Display(Name = "Poin 4")]
        public int poin_4 { get; set; }

        [Display(Name = "Poin 5")]
        public int poin_5 { get; set; }

        [Required(ErrorMessage = "Harap masukan data Jumlah Poin")]
        [Display(Name = "Jumlah_Poin")]
        public int Jumlah_Poin { get; set; }

        public string isDelete { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
    }
}