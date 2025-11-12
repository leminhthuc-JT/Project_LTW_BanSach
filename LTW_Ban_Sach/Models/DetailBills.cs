using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTW_Ban_Sach.Models
{
    public class DetailBills
    {
        [Key, Column(Order = 0)]
        public string BillId { get; set; }
        [Key, Column(Order = 1)]
        public string BookId { get; set; }
        public int Quantity { get; set; }
        public virtual Bills Bills { get; set; }
        public virtual Books Books { get; set; }
    }
}