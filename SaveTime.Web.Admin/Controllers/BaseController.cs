using Ninject;
using SaveTime.DataModel.Organization;
using SaveTime.Web.Admin.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTime.Web.Admin.Controllers
{
    public class BaseController:Controller
    {
        protected IKernel kernel;

        public BaseController()
        {
            kernel = new StandardKernel(new RepositoryModule());
        }
    }
}