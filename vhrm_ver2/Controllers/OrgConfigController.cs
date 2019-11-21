using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.BusinessLayer;
using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.Entity;

namespace vhrm.Controllers
{
    public class OrgConfigController : Controller
    {
        // GET: OrgConfig
        public ActionResult Index()
        {
            return View("OrgConfigIndex");
        }

        public JsonResult getDeptTreeVer2(string id)
        {
            List<eDepartmentItem> lstResult = new List<eDepartmentItem>();
            if (Session["dept_tree_ver2"] == null)
                Session["dept_tree_ver2"] = bDepartment.getDeptTreeVer2();
            lstResult = Session["dept_tree_ver2"] as List<eDepartmentItem>;

            var result = from e in lstResult
                         where (!string.IsNullOrEmpty(id) ? e.DEPTPARENT == id : string.IsNullOrEmpty(e.DEPTPARENT))
                         select new
                         {
                             id = e.DEPTCODE,
                             Name = e.DEPTNAME,
                             hasChildren = e.ISLEAF == "0"
                         };

            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrgCategory()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getDeptDetail(string deptcode)
        {
            eDepartmentItem eResult = new eDepartmentItem();
            DataTable dtResult = aDeptAccessVer2.getDeptDetail(deptcode);
            dynamic strResult = string.Empty;
            strResult = new
            {
                parent_name = dtResult.Rows[0]["parentname"].ToString(),
                deptcode = dtResult.Rows[0]["deptcode"].ToString(),
                deptName = dtResult.Rows[0]["deptname"].ToString(),
                deptParent = dtResult.Rows[0]["deptparent"].ToString(),
                deptShortName = dtResult.Rows[0]["deptshortname"].ToString(),
                isActive = dtResult.Rows[0]["isactive"].ToString()
            };
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult insertNewDept(eDepartmentItem dept, string userId)
        {
            dept.CREATE_UID = Session["UserId"].ToString();
            dynamic showMessageString = string.Empty;
            DataTable dtResult = aDeptAccessVer2.insertNewDept(dept);
            string strResult = dtResult.Rows[0][0].ToString();
            string strMes = dtResult.Rows[0][1].ToString();
            showMessageString = new
            {
                param1 = 200,
                param2 = strResult,
                param3 = strMes
            };

            try
            {
                Session["dept_tree_ver2"] = null;
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                var errorMsg = ex.Message.ToString();
                showMessageString = new
                {
                    param1 = 404,
                    param2 = "error",
                    param3 = "proccess error"
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPut]
        public ActionResult updateDept(eDepartmentItem dept, string userId)
        {
            dept.UPDATE_UID = Session["UserId"].ToString();
            dynamic showMessageString = string.Empty;
            DataTable dtResult = aDeptAccessVer2.updateDept(dept);
            string strResult = dtResult.Rows[0][0].ToString();
            string strMes = dtResult.Rows[0][1].ToString();
            showMessageString = new
            {
                param1 = 200,
                param2 = strResult,
                param3 = strMes
            };

            try
            {
                Session["dept_tree_ver2"] = null;
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message.ToString();
                showMessageString = new
                {
                    param1 = 404,
                    param2 = "error",
                    param3 = "proccess error"
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult getEmpReportByDept([DataSourceRequest]DataSourceRequest request, string deptcode)
        {
            DataTable dtResult = aDeptAccessVer2.getEmpReportByDept(deptcode);
            var jsonResult = Json(dtResult.ToDataSourceResult(request));
            jsonResult.MaxJsonLength = int.MaxValue;
            //return Json(dtResult.ToDataSourceResult(request));
            return jsonResult;
        }

        public ActionResult viewChart()
        {
            return View("OrgChart");
        }
    }
}