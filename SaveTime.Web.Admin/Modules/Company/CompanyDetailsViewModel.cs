using SaveTime.Web.Admin.Modules.Branch;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTime.Web.Admin.Modules.Company
{
    public class CompanyDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public IList<BranchDetailsViewModel> Branches { get; set; }
    }
}


