using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Ban_Sach.Models
{
    public class Accounts
    {
        [Key]
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Member { get; set; }
        public virtual ICollection<Bills> Bills { get; set; }
    }
}