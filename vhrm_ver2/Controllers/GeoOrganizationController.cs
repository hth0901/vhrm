using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.BusinessLayer;
using vhrm.ViewModels;

namespace vhrm.Controllers
{
    public class GeoOrganizationController : Controller
    {
        // GET: GeoOrganization
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getGeOrganizations(string DEPTCODE)
        {
            List<DeptViewModel> lstResult = new List<DeptViewModel>();           
            if (Session["geoorganization_tree"] == null)
                Session["geoorganization_tree"] = bDept.getDepts();
            
            lstResult = Session["geoorganization_tree"] as List<DeptViewModel>;
            var result = from e in lstResult
                         where (!string.IsNullOrEmpty(DEPTCODE) ? e.DEPTPARENT == DEPTCODE : string.IsNullOrEmpty(e.DEPTPARENT))
                         select new
                         {
                             DEPTCODE = e.DEPTCODE,
                             DEPTNAME = e.DEPTNAME,
                             DEPTPARENT = e.DEPTPARENT,
                             ISACTIVE = e.ISACTIVE,
                             ORDERINDEX = e.ORDERINDEX,
                             hasChildren = lstResult.Where(c => c.DEPTPARENT == e.DEPTCODE).FirstOrDefault() != null
                         };
            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GeoOrganizationInforPartial(string departCode, string deptName, string isActive)
        {
            ViewBag.departCode = departCode;
            ViewBag.deptName = deptName;
            ViewBag.isActive = isActive;
            return PartialView("GeoOrganizationInforPartial");
        }
        [HttpGet]
        public ActionResult AddNewGeoOrganization()
        {
            DeptViewModel geoOrganization = new DeptViewModel();
            return View(geoOrganization);
        }
        [HttpPost]
        public ActionResult AddNewGeoOrganization(string deptParent, string deptName, bool active, string orderIndex)
        {
            DeptViewModel geoOrganization = new DeptViewModel();
            string deptCode = bDept.getNewDeptCode(deptParent);
            if (deptParent == null || string.Empty == deptParent)
                deptParent = "000000";
            if (deptCode == "-1")
            {
                geoOrganization.DEPTCODE = deptParent;
                geoOrganization.DEPTPARENT = null;
                geoOrganization.DEPTLEVEL = "0";
            }
            else
            {
                geoOrganization.DEPTPARENT = deptParent;
                geoOrganization.DEPTCODE = deptCode;
                geoOrganization.DEPTLEVEL = deptCode.Substring(0, 1);
            }
            geoOrganization.DEPTNAME = deptName;
            if(active)
                geoOrganization.ISACTIVE = "1";
            else
                geoOrganization.ISACTIVE = "0";
            geoOrganization.ORDERINDEX = orderIndex;
            bDept.insertGeoOrganization(geoOrganization);
            Session["geoorganization_tree"] = bDept.getDepts();
            Session["geoorganizationreport_tree"] = bGeoReport.getTreeGeoDepts();
            return PartialView("GeoOrganizationInforPartial");
        }

        [HttpPost]
        public ActionResult UpdateGeoOrganization(string deptCode, string deptParent, string deptName, bool active, string orderIndex)
        {
            DeptViewModel geoOrganization = new DeptViewModel();
            geoOrganization.DEPTCODE = deptCode;
            geoOrganization.DEPTPARENT = deptParent;
            geoOrganization.DEPTNAME = deptName;
            geoOrganization.DEPTLEVEL = deptCode.Substring(0,1);
            if (active)
                geoOrganization.ISACTIVE = "1";
            else
                geoOrganization.ISACTIVE = "0";
            geoOrganization.ORDERINDEX = orderIndex;
            bDept.UpdateGeoOrganization(geoOrganization);
            Session["geoorganization_tree"] = bDept.getDepts();
            Session["geoorganizationreport_tree"] = bGeoReport.getTreeGeoDepts();
            return PartialView("GeoOrganizationInforPartial");
        }

    }
}