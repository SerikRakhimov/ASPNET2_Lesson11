using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaveTime.DaraAccess;
using SaveTime.DataModel.Organization;

namespace SaveTime.Web.Admin.Repo.Impl
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly SaveTimeModel model;

        public CompanyRepository()
        {
            this.model = new SaveTimeModel();
        }
        public void Create(Company company)
        {
            model.Companies.Add(company);
            model.SaveChanges();
        }
    }
}