using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LTW_Ban_Sach.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ImageEvents> ImageEvents { get; set; }
        public virtual ICollection<Vouchers> Vouchers { get; set; }
    }
}