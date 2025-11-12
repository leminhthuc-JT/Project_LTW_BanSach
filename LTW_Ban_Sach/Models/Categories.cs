using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LTW_Ban_Sach.Models
{
    public class Categories
    {
        [Key]
        public string CateId { get; set; }
        public string CateName { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}