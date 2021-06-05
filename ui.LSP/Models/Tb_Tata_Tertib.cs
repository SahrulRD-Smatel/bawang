using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ui.BAWANG.Models
{
    public class Tb_SMK_Kompetensi_Keahlian
    {
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Display(Name = "Tata Tertib")]    
        public string Tata_Tertib { get; set; }

        [Display(Name = "Poin")]
        public string Poin { get; set; }

        [Display(Name = "Aspek")]
        public string Aspek { get; set; }

        public string isDelete { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }

    }
}