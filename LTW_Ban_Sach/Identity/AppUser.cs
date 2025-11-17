using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LTW_Ban_Sach.Identity
{
    public class AppUser: IdentityUser
    {
        public string Address { get; set; }
        public string Avatar { get; set; }

    }
}