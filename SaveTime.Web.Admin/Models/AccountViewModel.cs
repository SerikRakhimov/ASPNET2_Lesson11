using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTime.Web.Admin.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}