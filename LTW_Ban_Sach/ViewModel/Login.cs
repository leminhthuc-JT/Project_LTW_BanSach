using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LTW_Ban_Sach.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "Không được để trống")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}