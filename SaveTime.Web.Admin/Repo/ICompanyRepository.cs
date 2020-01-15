using SaveTime.DataModel.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTime.Web.Admin.Repo
{
    public interface ICompanyRepository
    {
        void Create(Company company);
    }
}
