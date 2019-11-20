using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.Entity;

namespace vhrm.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getEmpBasicInfo([DataSourceRequest]DataSourceRequest request)
        {
            DataTable dtResult = EmployeeMasterAccess.getEmpBasic();
            //List<EEMP> lstForm = bForm.listFormFromDatatable(dtForm);
            List<eEmpBasicInfo> lstResult = new List<eEmpBasicInfo>();
            foreach (DataRow dtr in dtResult.Rows)
            {
                eEmpBasicInfo item = new eEmpBasicInfo();
                item.SYS_EMPID = dtr["SYS_EMPID"].ToString();
                item.EMPID = dtr["EMPID"].ToString();
                item.EMPNAME = dtr["EMPNAME"].ToString();
                lstResult.Add(item);
            }

            return Json(lstResult.ToDataSourceResult(request));
        }
    }
}