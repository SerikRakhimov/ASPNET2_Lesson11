using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTime.Web.Admin.Modules.Company.ViewModel
{
    public class CompanyViewModel
    {
        public IList<CompanyDetailsViewModel> Companies { get; set; }
        public CreateCompanyViewModel CreateCompany { get; set; }
        public CompanyViewModel()
        {
            Companies = new List<CompanyDetailsViewModel>();
            CreateCompany = new CreateCompanyViewModel();
        }
    }
}