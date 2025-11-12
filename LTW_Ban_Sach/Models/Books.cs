using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LTW_Ban_Sach.Models
{
    public class Books
    {
        [Key]
        public string BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string CateId { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<DetailBills> DetailBills { get; set; }
    }
}