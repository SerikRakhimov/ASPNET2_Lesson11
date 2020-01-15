using AutoMapper;
using Ninject;
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
    public class AccountController : BaseController
    {
        // GET: Account
        private readonly IRepository<Account> _repository;
        IMapper _mapper;

        public AccountController()
        {
            _repository = kernel.Get<IRepository<Account>>();
            var config = new MapperConfiguration(
                c => {
                    c.CreateMap<Account, AccountViewModel>();
                    c.CreateMap<AccountViewModel, Account>();
                });
            _mapper = config.CreateMapper();
        }

        public ActionResult Index()
        {
            IEnumerable<Account> accounts = _repository.GetAll();

            IList<AccountViewModel> viewAccounts = new List<AccountViewModel>();
            foreach (var acc in accounts)
            {
                AccountViewModel avm = _mapper.Map<AccountViewModel>(acc);
                viewAccounts.Add(avm);
            }
            return View(viewAccounts);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccountViewModel avm)
        {
            if (ModelState.IsValid)
            {
                Account account = _mapper.Map<Account>(avm);
                _repository.Create(account);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}