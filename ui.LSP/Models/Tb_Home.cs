using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ui.LSP.Models
{
    public class Tb_Home
    {
        [Display(Name = "Jumlah SMK")] public int jmlSMK { get; set; }

        [Display(Name = "Jumlah Asesor")] public int jmlAsesor { get; set; }

        [Display(Name = "Jumlah LSP")] public int jmlLSP { get; set; }
        [Display(Name = "Jumlah Kompetensi Keahlian Terlisensi")] public int jmlKKT { get; set; }
        [Display(Name = "Jumlah Penerima Sertifikat")] public int jmlPS { get; set; }

    }
}