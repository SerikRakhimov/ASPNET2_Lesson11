using AutoMapper;
using Ninject;
using SaveTime.DaraAccess;
using SaveTime.DataModel.Organization;
using SaveTime.Web.Admin.Modules.Branch;
using SaveTime.Web.Admin.Modules.Company;
using SaveTime.Web.Admin.Modules.Company.ViewModel;
using SaveTime.Web.Admin.Modules.Employee;
using SaveTime.Web.Admin.Repo;
using SaveTime.Web.Admin.Repo.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTime.Web.Admin.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IRepository<Company> _repository;
        IMapper _mapper;

        public CompanyController()
        {
            _repository = kernel.Get<IRepository<Company>>();
            var config = new MapperConfiguration(
                c => {
                    c.CreateMap<Employee, EmployeeDetailsViewModel>();
                    c.CreateMap<Branch, BranchDetailsViewModel>();
                    c.CreateMap<Company, CompanyDetailsViewModel>();
                });
            _mapper = config.CreateMapper();
        }
        public ActionResult Index()
        {
            IEnumerable<Company> companies = _repository.GetAll();
            var company = new CompanyViewModel();
            foreach(var com in companies)
            {
                var cvm = _mapper.Map<CompanyDetailsViewModel>(com);
                company.Companies.Add(cvm);
            }
            return View(company);
        }

        public ActionResult Details(int id)
        {
            Company company = _repository.GetById(id);
            if (company == null)
            {
                return HttpNotFound();
            }

            var companyDetails = _mapper.Map<CompanyDetailsViewModel>(company);
            //CompanyDetailsViewModel companyDetails = new CompanyDetailsViewModel()
            //{
            //    Id = company.Id,
            //    Name = company.Name,
            //    City = company.City,
            //};
            IList<BranchDetailsViewModel> branchDetails = new List<BranchDetailsViewModel>();

            foreach(var branch in company.Branches)
            {
                var branchDetail = _mapper.Map<BranchDetailsViewModel>(branch);
                //BranchDetailsViewModel branchDetail = new BranchDetailsViewModel()
                //{
                //    Id = branch.Id,
                //    Adress = branch.Adress,
                //    Email = branch.Email,
                //    Phone = branch.Phone,
                //    StartWork = branch.StartWork,
                //    EndWork = branch.EndWork,
                //    StepWork = branch.StepWork,
                //};

                IList<EmployeeDetailsViewModel> employeesDetails = new List<EmployeeDetailsViewModel>();

                foreach (var employee in branch.Employees)
                {
                    var employeeDetail = _mapper.Map<EmployeeDetailsViewModel>(employee);
                    //EmployeeDetailsViewModel employeeDetail = new EmployeeDetailsViewModel
                    //{
                    //    Id = employee.Id,
                    //    Name = employee.Name
                    //};

                    employeesDetails.Add(employeeDetail);
                }
                branchDetail.Employees = employeesDetails;
                branchDetails.Add(branchDetail);

            }

            companyDetails.Branches = branchDetails;
            return View(companyDetails);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CompanyViewModel companyViewModel)
        {
            if ((ModelState.IsValid)  && (companyViewModel!=null))
            {
                var company = new Company
                {
                    Name = companyViewModel.CreateCompany.Name,
                    City = companyViewModel.CreateCompany.City
                };
                _repository.Create(company);
                return RedirectToAction("Index");
            }
            return View();

        }
    }

    public class Info
    {
        public string Message { get; set; }
        public Company Company { get; set; }
    }
}