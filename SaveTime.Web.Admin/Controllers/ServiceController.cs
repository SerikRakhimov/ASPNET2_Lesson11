using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Ninject;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaveTime.DaraAccess;
using SaveTime.DataModel.Dictionary;
using SaveTime.Web.Admin.Repo;
using SaveTime.Web.Admin.Models;

namespace SaveTime.Web.Admin.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly IRepository<Service> _repository;

            public ServiceController()
        {
            _repository = kernel.Get<IRepository<Service>>();
        }

        // GET: Service
        public ActionResult Index()
        {
            IEnumerable<Service> services = _repository.GetAll();
            IList<ServiceViewModel> serviceViewModels = new List<ServiceViewModel>() { };
            foreach(var service in services)
            {
                var svm = new ServiceViewModel()
                {
                    Id = service.Id,
                    Title = service.Title
                };
                serviceViewModels.Add(svm);
            }
            return View(serviceViewModels);
        }

        // GET: Service/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Service service = db.Services.Find(id);
        //    if (service == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(service);
        //}

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceViewModel serviceViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = new Service()
                {
                    Title = serviceViewModel.Title
                };
                _repository.Create(service);
                return RedirectToAction("Index");
            }

            return View(serviceViewModel);
        }

        //// GET: Service/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Service service = db.Services.Find(id);
        //    if (service == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(service);
        //}

        //// POST: Service/Edit/5
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Title")] Service service)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(service).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(service);
        //}

        //// GET: Service/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Service service = db.Services.Find(id);
        //    if (service == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(service);
        //}

        //// POST: Service/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Service service = db.Services.Find(id);
        //    db.Services.Remove(service);
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
