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
using Newtonsoft.Json;
using System.Reflection;

namespace vhrm.Controllers
{
    public class GeoReportConfigController : Controller
    {
        // GET: GeoReportConfig
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getDeptTree(string id)
        {
            List<eDepartmentItem> lstResult = new List<eDepartmentItem>();
            if (Session["dept_tree"] == null)
                Session["dept_tree"] = bDepartment.getDeptTree();
            lstResult = Session["dept_tree"] as List<eDepartmentItem>;
            //var result = from e in lstResult
            //             where (!string.IsNullOrEmpty(id) ? e.DEPTPARENT == id : string.IsNullOrEmpty(e.DEPTPARENT))
            //             select new
            //             {
            //                 id = e.DEPTCODE,
            //                 Name = e.DEPTNAME,
            //                 hasChildren = lstResult.Where(c => c.DEPTPARENT == e.DEPTCODE).FirstOrDefault() != null
            //                 //e.ISLEAF == "0"
            //             };
            //return Json(result.ToList(), JsonRequestBehavior.AllowGet);


            var result = from e in lstResult
                         where (!string.IsNullOrEmpty(id) ? e.DEPTPARENT == id : string.IsNullOrEmpty(e.DEPTPARENT))
                         select new
                         {
                             id = e.DEPTCODE,
                             Name = e.DEPTNAME,
                             hasChildren = e.ISLEAF == "0"
                         };

            return Json(result.ToList(), JsonRequestBehavior.AllowGet);

            //return Json(lstResult, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult getGeoReportByDept([DataSourceRequest]DataSourceRequest request, string deptcode)
        //{
        //    List<eGeoReportItem> result = new List<eGeoReportItem>();
        //    result = bGeoReport.getGeoReportByDepartment(deptcode);
        //    return Json(result.ToDataSourceResult(request));
        //}

        public ActionResult getGeoReportByDept([DataSourceRequest]DataSourceRequest request, string deptcode)
        {
            List<eGeoReportItem> result = new List<eGeoReportItem>();
            result = bGeoReport.getGeoReportByDepartment(deptcode);

            DataTable dtResult = GeoReportAccess.getReportByDepartment(deptcode);
            string jsonString = JsonConvert.SerializeObject(dtResult);
            JsonResult jsResult = new JsonResult();
            jsResult = Json(dtResult.ToDataSourceResult(request));
            DataTable dtTest = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
            //return jsResult;
            //return jsonResult;
            /*
            DataRow dtr = dtResult.Rows[0];
            eGeoReportItem item = new eGeoReportItem();
            foreach(DataColumn cl in dtr.Table.Columns)
            {
                PropertyInfo prop = item.GetType().GetProperty(cl.ColumnName);
                FieldInfo fld = item.GetType().GetField(cl.ColumnName);
            }
            */

            return Json(dtTest.ToDataSourceResult(request));
            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult updateGeoReporter([DataSourceRequest] DataSourceRequest request, eGeoReportItem _reporter, string deptcode)
        {
            //FormEntity formEntity = new FormEntity();
            //formEntity.FormID = _form.FORM_CODE;
            //formEntity.FormName = _form.FORM_NAME;
            //formEntity.DictionaryID = "";
            //formEntity.FilePath = _form.FILE_PATH;
            //formEntity.ModuleID = "";
            //formEntity.UPDATE_UID = "hieuht";
            //bool result = FormAccess.UpdateForm(formEntity);
            _reporter.DEPTCODE = deptcode;
            string userId = Session["UserId"].ToString();
            DataTable dtResult = GeoReportAccess.updateGeoReport(_reporter, userId);
            Session["geoorganizationreport_tree"] = bGeoReport.getTreeGeoDepts();
            dynamic res = string.Empty;
            res = new
            {
                result = dtResult.Rows[0][0].ToString(),
                message = dtResult.Rows[0][1].ToString()
            };
            return Json(new[] { _reporter, res }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult createGeoReporter([DataSourceRequest] DataSourceRequest request, eGeoReportItem _reporter, string deptcode)
        {
            //FormEntity formEntity = new FormEntity();
            //formEntity.FormID = _form.FORM_CODE;
            //formEntity.FormName = _form.FORM_NAME;
            //formEntity.DictionaryID = "";
            //formEntity.CREATE_UID = "hieuht";
            //formEntity.FilePath = _form.FILE_PATH;
            //formEntity.ModuleID = "";
            //bool result = FormAccess.InsertForm(formEntity);
            _reporter.DEPTCODE = deptcode;
            string userId = Session["UserId"].ToString();
            DataTable dtResult = GeoReportAccess.insertNewGeoReport(_reporter, userId);
            Session["geoorganizationreport_tree"] = bGeoReport.getTreeGeoDepts();
            dynamic res = string.Empty;
            res = new
            {
                result = dtResult.Rows[0][0].ToString(),
                message = dtResult.Rows[0][1].ToString()
            };
            return Json(new[] { _reporter, res }.ToDataSourceResult(request, ModelState));
            //return Json("ok", JsonRequestBehavior.AllowGet);
        }
    }
}