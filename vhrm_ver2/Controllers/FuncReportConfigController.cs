using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using vhrm.FrameWork.BusinessLayer;
using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.Entity;
using vhrm.ViewModels;

namespace vhrm.Controllers
{
    public class FuncReportConfigController : Controller
    {
        // GET: FuncReportConfig
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getFunctTree(string id)
        {
            List<FunctViewModel> lstResult = new List<FunctViewModel>();
            if (Session["funct_report_tree"] == null)
                Session["funct_report_tree"] = bFunction.getFunctions();
            lstResult = Session["funct_report_tree"] as List<FunctViewModel>;
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
                         where (!string.IsNullOrEmpty(id) ? e.FUNCPARENT == id : string.IsNullOrEmpty(e.FUNCPARENT))
                         select new
                         {
                             id = e.FUNCCODE,
                             Name = e.FUNCNAME,
                             hasChildren = lstResult.Where(c => c.FUNCPARENT == e.FUNCCODE).FirstOrDefault() != null
                         };

            return Json(result.ToList(), JsonRequestBehavior.AllowGet);

            //return Json(lstResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getFunctReportByDept([DataSourceRequest]DataSourceRequest request, string deptcode)
        {
            List<eFunctReportItem> result = new List<eFunctReportItem>();
            result = bFunctionReport.getFunctReportByFunctCode(deptcode);
            return Json(result.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult updateFunctReporter([DataSourceRequest] DataSourceRequest request, eFunctReportItem _reporter, string deptcode)
        {
            //FormEntity formEntity = new FormEntity();
            //formEntity.FormID = _form.FORM_CODE;
            //formEntity.FormName = _form.FORM_NAME;
            //formEntity.DictionaryID = "";
            //formEntity.FilePath = _form.FILE_PATH;
            //formEntity.ModuleID = "";
            //formEntity.UPDATE_UID = "hieuht";
            //bool result = FormAccess.UpdateForm(formEntity);
            _reporter.FUNCCODE = deptcode;
            string userId = Session["UserId"].ToString();
            DataTable dtResult = FunctionReportAccess.updateFunctReport(_reporter, userId);
            Session["functreport_tree"] = bFunctionReport.getTreeFunctionDepts();
            dynamic res = string.Empty;
            res = new
            {
                result = dtResult.Rows[0][0].ToString(),
                message = dtResult.Rows[0][1].ToString()
            };
            return Json(new[] { _reporter, res }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult createFunctReporter([DataSourceRequest] DataSourceRequest request, eFunctReportItem _reporter, string deptcode)
        {
            //FormEntity formEntity = new FormEntity();
            //formEntity.FormID = _form.FORM_CODE;
            //formEntity.FormName = _form.FORM_NAME;
            //formEntity.DictionaryID = "";
            //formEntity.CREATE_UID = "hieuht";
            //formEntity.FilePath = _form.FILE_PATH;
            //formEntity.ModuleID = "";
            //bool result = FormAccess.InsertForm(formEntity);
            _reporter.FUNCCODE = deptcode;
            string userId = Session["UserId"].ToString();
            DataTable dtResult = FunctionReportAccess.insertNewGeoReport(_reporter, userId);
            Session["functreport_tree"] = bFunctionReport.getTreeFunctionDepts();
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