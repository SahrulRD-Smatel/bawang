using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ui.BAWANG.Models
{
    public class Tb_LWali_Kelas
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "Harap masukan data Email Address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(50, MinimumLength = 7)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Harap masukan data Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 7)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Harap masukan data Confirm Password")]
        [Display(Name = "Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Wali Kelas")]
        public string Wali_Kelas { get; set; }

        [Display(Name = "Nama Lengkap")]
        public string Nama_WaliKelas { get; set; }
        public string isDelete { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
    }
}