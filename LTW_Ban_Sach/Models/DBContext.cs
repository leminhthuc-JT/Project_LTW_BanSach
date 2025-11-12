using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LTW_Ban_Sach.Models
{
    public class DBContext:DbContext
    {
        public DBContext() : base("MyConnectionString") { }
        public DbSet<Books> Books { get; set; }
        public DbSet<Categories> Categories { get; set; }

    }
}