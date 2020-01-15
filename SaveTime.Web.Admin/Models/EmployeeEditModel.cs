using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SaveTime.Web.Admin.Models
{
    public class EmployeeEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }
        public int BranchId { get; set; }

    }
}
