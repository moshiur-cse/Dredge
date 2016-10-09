using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DredgingCodeFastApp.Models;

namespace DredgingCodeFastApp.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //
        // GET: /Search/
        public ActionResult Index()
        {
            
            ViewBag.Divisions = db.Divisions.ToList();
            return View();
        }
        public JsonResult GetDistrictByDivisionId(string divisionId)
        {
            
            var districtList = db.Districts.Where(a => a.Division_id == divisionId).ToList();
            return Json(districtList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUpazilaByDistrictId(string districtId)
        {
            
            var upazilaList = db.Upazilas.Where(a => a.District_id == districtId).ToList();
            return Json(upazilaList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUnionByUpazilaId(string upazilaId)
        {
            var unionsList = db.Unions.Where(a => a.Upazila_id == upazilaId).ToList();
            return Json(unionsList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMauzaByUnionId(string unionId)
        {
            var mauzasList = db.Mauzas.Where(a => a.Union_id == unionId).ToList();
            return Json(mauzasList, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetDredgerByMauzaId(int mauzaId)
        //{
        //    var dredgeInfoList = db.DredgInformations.Where(a => a.DredgerId == mauzaId).ToList();

        //    //ViewBag.DredgeInfo = db.DredgInformations.Where(a => a.DredgerId == mauzaId).ToList();
        //    return Json(dredgeInfoList, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetDredgeInfoByMauzaId(int dredgeId)
        {
            var dredgeInfoList = db.DredgInformations.Where(a => a.DredgerId == dredgeId).ToList();

            //ViewBag.DredgeInfo = db.DredgInformations.Where(a => a.DredgerId == mauzaId).ToList();
            return Json(dredgeInfoList, JsonRequestBehavior.AllowGet);
        }
	}
}