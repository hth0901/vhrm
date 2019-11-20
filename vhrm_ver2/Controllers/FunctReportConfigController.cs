using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.BusinessLayer;
using vhrm.FrameWork.Entity;

namespace vhrm.Controllers
{
    public class FunctReportConfigController : Controller
    {
        // GET: FunctReportConfig
        public ActionResult Index()
        {
            return View();
        }
       
        public JsonResult getAllEmployee([DataSourceRequest]DataSourceRequest request)
        {
            List<EmployeeMaster> lstResult = new List<EmployeeMaster>(); 
            if (Session["users_register"] == null)
                Session["users_register"] = bEmployeeMaster.getAllEmployees();
            lstResult = Session["users_register"] as List<EmployeeMaster>;
            return Json(lstResult.ToDataSourceResult(request));
        }

        public JsonResult getEmployeesByFunctCode([DataSourceRequest]DataSourceRequest request, string FUNCCODE)
        {
            //string[] array = (string[])FUNCCODE;
            List<EmployeeMaster> employees = bFunctionReport.getUserFunctionReports(FUNCCODE);
            return Json(employees.ToDataSourceResult(request));
        }
        [HttpPost]
        public JsonResult isNotExistFunctReport(string FUNCCODE)
        {
            //string[] array = (string[])FUNCCODE;
            List<EmployeeMaster> employees = bFunctionReport.getUserFunctionReports(FUNCCODE);
            if (employees == null || employees.Count == 0)
            {
                var data = new
                {
                    status = true
                };
                return Json(new { result = Json(data) });
            }
            else
            {
                var data = new
                {
                    status = false
                };
                return Json(new { result = Json(data) });
            }
        }       

        public JsonResult SignEmployeeToGeoReport([DataSourceRequest]DataSourceRequest request,IEnumerable<EmployeeMaster> employeeMasters)
        {
            List<EmployeeMaster> employees = bFunctionReport.getUserFunctionReports("");
            return Json(employees.ToDataSourceResult(request));
        }  
        [HttpPost]
        public JsonResult CreateEmployeeToGeoReport([DataSourceRequest]DataSourceRequest request, object FUNCCODE)
        {
            string[] array = (string[])FUNCCODE;
            string funcCode = array[0];
            string[] values = funcCode.Split(',');
            funcCode = values[0];
            if (string.IsNullOrEmpty(funcCode) || funcCode.Equals(""))
            {
                List<EmployeeMaster> e = new List<EmployeeMaster>();
                return Json(e.ToDataSourceResult(request));
            }
            for (int i = 1; i < values.Length; i++)
            {
                bFunctionReport.InsertFunctReport(funcCode, values[i].Trim());
            }
            Session["function_tree"] = bFunction.getFuncts();
            List<EmployeeMaster> employees = bFunctionReport.getUserFunctionReports(funcCode);
            return Json(employees.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult DestroyEmployee([DataSourceRequest]DataSourceRequest request, EmployeeMaster employee , object FUNCCODE)
        {
            string[] array = (string[])FUNCCODE;
            string funcCode = array[0];
            string sys_empid = employee.SYS_EMPID;
            bFunctionReport.DeleteFunctReportByFKey(funcCode, sys_empid);
            Session["function_tree"] = bFunction.getFuncts();
            List<EmployeeMaster> employees = new List<EmployeeMaster>();
            return Json(employees.ToDataSourceResult(request));
        }

    }
}