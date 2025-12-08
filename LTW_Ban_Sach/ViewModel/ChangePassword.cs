using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LTW_Ban_Sach.ViewModel
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Không được để trống")]
        [DataType(DataType.Password)]
        public string PasswordOld { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [DataType(DataType.Password)]
        public string PasswordNew { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [DataType(DataType.Password)]
        [Compare("PasswordNew", ErrorMessage = "Mật khẩu không giống nhau.")]
        public string ConfirmPassword { get; set; }
    }
}