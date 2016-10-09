using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DredgingCodeFastApp.Models;
using PagedList;


namespace DredgingCodeFastApp.Controllers
{
    public class DredgeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: /Dredge/
        public ActionResult Index(string sortOrder, DateTime? currentFilter, DateTime? searchString1, DateTime? searchString2, int? page)
        {
            //var startTime=DateTime.MinValue;
           // var endTime = DateTime.MinValue;
            //if (searchString1 != "" || searchString2 != "")
            //{

             var startTime = Convert.ToDateTime(searchString1);
             var endTime = Convert.ToDateTime(searchString2);
            //}

            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Density" : "";
            ViewBag.DateSortParm = sortOrder == "DateTime" ? "Date_DSC" : "DateTime";

            if (searchString1 != null || searchString2 != null)
            {
                page = 1;
            }
            else
            {
                searchString1 = currentFilter;
            }

            ViewBag.CurrentFilter = searchString1;

            var dredger = from s in db.DredgInformations
                           select s;
            if (searchString1 != null || searchString2 != null)
            {
                //dredger = dredger.Where(a => a.DateTime==searchString);
                dredger = dredger.Where(p => p.DateTime >=startTime && p.DateTime <= endTime);

                //var dredger1 = from s in db.DredgInformations where s.DateTime   '2016-08-27' && '2016-08-29' select s;
                              
                 
            }
            switch (sortOrder)
            {

                case "DateTime":
                    dredger = dredger.OrderBy(s => s.DateTime);
                    break;
                case "Date_DSC":
                    dredger = dredger.OrderByDescending(s => s.DateTime);
                    break;
                                   
                default:  // Name ascending 
                    dredger = dredger.OrderBy(s => s.Id);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(dredger.ToPagedList(pageNumber, pageSize));
            
        }      
        // GET: /Dredge/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DredgInformationModels dredginformationmodels = db.DredgInformations.Find(id);
            if (dredginformationmodels == null)
            {
                return HttpNotFound();
            }
            return View(dredginformationmodels);
        }

        // GET: /Dredge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Dredge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,DateTime,Density,Velocity,Production,DredgerId")] DredgInformationModels dredginformationmodels)
        {
            if (ModelState.IsValid)
            {
                db.DredgInformations.Add(dredginformationmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dredginformationmodels);
        }

        // GET: /Dredge/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DredgInformationModels dredginformationmodels = db.DredgInformations.Find(id);
            if (dredginformationmodels == null)
            {
                return HttpNotFound();
            }
            return View(dredginformationmodels);
        }

        // POST: /Dredge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,DateTime,Density,Velocity,Production,DredgerId")] DredgInformationModels dredginformationmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dredginformationmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dredginformationmodels);
        }

        // GET: /Dredge/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DredgInformationModels dredginformationmodels = db.DredgInformations.Find(id);
            if (dredginformationmodels == null)
            {
                return HttpNotFound();
            }
            return View(dredginformationmodels);
        }

        // POST: /Dredge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DredgInformationModels dredginformationmodels = db.DredgInformations.Find(id);
            db.DredgInformations.Remove(dredginformationmodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
