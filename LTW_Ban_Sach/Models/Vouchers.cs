using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;    

namespace LTW_Ban_Sach.Models
{
    public class Vouchers
    {
        [Key]
        public string VoucherId { get; set; }
        public string VoucherName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DiscountAmount { get; set; }
        public string EventId { get; set; }
        public virtual ICollection<Bills> Bills { get; set; }
        public virtual Events Events { get; set; }
    }
}