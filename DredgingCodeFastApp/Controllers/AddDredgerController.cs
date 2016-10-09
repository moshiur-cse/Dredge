using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DredgingCodeFastApp.Models;
using PagedList;

namespace DredgingCodeFastApp.Controllers
{
    public class AddDredgerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /AddDredger/

        //int offset = 0;
        //int limit = 50;

        // GET: /Dredge/ pagging
        //public ActionResult Index(int id = 0)
        //{
        //    var count = db.Mauzas.Count();
        //    ViewBag.Count = count;
        //    ViewBag.Limit = limit;
        //    offset += id;
        //    ViewBag.Offset = offset;

        //    if (id >= 0 && offset <= count)
        //    {
        //        ViewBag.info = db.Mauzas.OrderBy(p => p.Id).Skip(offset).Take(limit).ToList();

        //    }

        //    return View(ViewBag.info);

        //}   


        //public ActionResult Index()
        //{
        //    return View(db.Mauzas.ToList());
        //}

        // GET: /AddDredger/Details/5



        public ActionResult Index(string sortOrder, string currentFilter, string searchString, double? searchNumber, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            //ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "Mauza" : "";
            ViewBag.DredgeIdParm = string.IsNullOrEmpty(sortOrder) ? "DredgeId" : "";
            ViewBag.UnionIdSortParm = string.IsNullOrEmpty(sortOrder) ? "UnionId" : "";
            ViewBag.NameSortParm = sortOrder == "Mauza" ? "Mauza_DESC" : "Mauza";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var dredger = from s in db.Mauzas
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                dredger = dredger.Where(a => a.Mauza_name.Contains(searchString));
                //dredger = from i in db.DredgInformations where SqlMethods.Like(i.Density.ToString(), "tra%ata") select i;


            }
            if (searchNumber != null)
            {
                dredger = dredger.Where(a => a.Dredger_id == searchNumber);
            }
            switch (sortOrder)
            {
                case "Mauza":
                    dredger = dredger.OrderBy(s => s.Mauza_name);
                    break;
                case "Mauza_DESC":
                    dredger = dredger.OrderByDescending(s => s.Mauza_name);
                    break;
                case "DredgeId":
                    dredger = dredger.OrderBy(s => s.Union_id);
                    break;
                default:  // Name ascending 
                    dredger = dredger.OrderBy(s => s.Id);
                    break;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(dredger.ToPagedList(pageNumber, pageSize));

        }      
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauzaModels mauzamodels = db.Mauzas.Find(id);
            if (mauzamodels == null)
            {
                return HttpNotFound();
            }
            return View(mauzamodels);
        }

        // GET: /AddDredger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AddDredger/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Union_id,Mauza_name,Dredger_id")] MauzaModels mauzamodels)
        {
            if (ModelState.IsValid)
            {
                db.Mauzas.Add(mauzamodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mauzamodels);
        }

        // GET: /AddDredger/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauzaModels mauzamodels = db.Mauzas.Find(id);
            if (mauzamodels == null)
            {
                return HttpNotFound();
            }
            return View(mauzamodels);
        }

        // POST: /AddDredger/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Union_id,Mauza_name,Dredger_id")] MauzaModels mauzamodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mauzamodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mauzamodels);
        }

        // GET: /AddDredger/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauzaModels mauzamodels = db.Mauzas.Find(id);
            if (mauzamodels == null)
            {
                return HttpNotFound();
            }
            return View(mauzamodels);
        }

        // POST: /AddDredger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MauzaModels mauzamodels = db.Mauzas.Find(id);
            db.Mauzas.Remove(mauzamodels);
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
