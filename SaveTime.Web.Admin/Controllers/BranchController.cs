using AutoMapper;
using Ninject;
using SaveTime.DaraAccess;
using SaveTime.DataModel.Organization;
using SaveTime.Web.Admin.Models;
using SaveTime.Web.Admin.Repo;
using SaveTime.Web.Admin.Repo.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTime.Web.Admin.Controllers
{
    public class BranchController : BaseController
    {
        private readonly IRepository<Branch> _repository;
        IMapper _mapper;

        public BranchController()
        {
            _repository = kernel.Get<IRepository<Branch>>();
            var config = new MapperConfiguration(
                    c => {
                        c.CreateMap<Branch, BranchViewModel>();
                        c.CreateMap<BranchEditModel, Branch>();
                    });
            _mapper = config.CreateMapper();
        }

        public ActionResult Index()
        {
            IEnumerable<Branch> branchs = _repository.GetAll();
            IList<BranchViewModel> viewBranchs = new List<BranchViewModel>();
            foreach (var brn in branchs)
            {
                BranchViewModel avm = _mapper.Map<BranchViewModel>(brn);
                avm.CompanyName = brn.Company.Name;
                viewBranchs.Add(avm);
            }
            return View(viewBranchs);
        }
        public ActionResult Create()
        {
            IRepository<Company> _repoCompany;
            _repoCompany = kernel.Get<IRepository<Company>>();
            IEnumerable<Company> companies = _repoCompany.GetAll().ToList();
            ViewBag.Companies = companies;
            return View();
        }
        [HttpPost]
        public ActionResult Create(BranchEditModel bem)
        {
            if (ModelState.IsValid)
            {
                Branch branch = _mapper.Map<Branch>(bem);
                branch.CompanyId = bem.CompanyId;
                _repository.Create(branch);
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}