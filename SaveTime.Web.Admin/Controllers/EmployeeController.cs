using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using SaveTime.DaraAccess;
using SaveTime.DataModel.Organization;
using SaveTime.Web.Admin.Models;
using SaveTime.Web.Admin.Repo;

namespace SaveTime.Web.Admin.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IRepository<Employee> _repository;
        IMapper _mapper;

        public EmployeeController()
        {
            _repository = kernel.Get<IRepository<Employee>>();
            var config = new MapperConfiguration(
                c => {
                    c.CreateMap<EmployeeEditModel, Employee>();
                });
            _mapper = config.CreateMapper();

        }

        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = _repository.GetAll();
            IList<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>() { };
            foreach (var employee in employees)
            {
                var svm = new EmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    AccountPhone = employee.Account.Phone,
                    AccountEmail = employee.Account.Email,
                    CompanyName = employee.Branch.Company.Name,
                    BranchAdress = employee.Branch.Adress

                };
                employeeViewModels.Add(svm);
            }
            return View(employeeViewModels);
        }

        // GET: Employees/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employee);
        //}

        // GET: Employees/Create
        public ActionResult Create()
        {
            IRepository<Account> _repoAccount;
            _repoAccount = kernel.Get<IRepository<Account>>();
            IEnumerable<Account> accounts = _repoAccount.GetAll().ToList();
            ViewBag.Accounts = accounts;

            IRepository<Branch> _repoBranch;
            _repoBranch = kernel.Get<IRepository<Branch>>();
            IEnumerable<Branch> branches = _repoBranch.GetAll().ToList();
            ViewBag.Branches = branches;

            return View();
        }

        // POST: Employees/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeEditModel eem)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _mapper.Map<Employee>(eem);
                employee.AccountId = eem.AccountId;
                employee.BranchId = eem.BranchId;
                _repository.Create(employee);
                return RedirectToAction("Index");
            }

            return View();
        }

        //// GET: Employees/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employee);
        //}

        //// POST: Employees/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name")] Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(employee).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        //// GET: Employees/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employee);
        //}

        //// POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    db.Employees.Remove(employee);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
