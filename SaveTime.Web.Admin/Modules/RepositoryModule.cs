using Ninject.Modules;
using SaveTime.Web.Admin.Repo;
using SaveTime.Web.Admin.Repo.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTime.Web.Admin.Modules
{
    public class RepositoryModule: NinjectModule
    {
        public override void Load()
        {
//          Bind<IRepository<T>>().To<Repository<T>>();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}