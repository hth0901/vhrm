using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.BusinessLayer;
using vhrm.FrameWork.Entity;

namespace vhrm.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult deptDetailQuery([DataSourceRequest]DataSourceRequest request)
        {
            DataTable dtResult = aDeptDetailAccess.getAllDeptDetail();
            List<eDepartmentDetailItem> lstResult = new List<eDepartmentDetailItem>();
            foreach(DataRow dtr in dtResult.Rows)
            {
                eDepartmentDetailItem item = new eDepartmentDetailItem();
                item.LEVEL1_CODE = dtr["LEVEL1_CODE"].ToString();
                item.LEVEL1_NAME = dtr["LEVEL1_NAME"].ToString();
                item.LEVEL2_CODE = dtr["LEVEL2_CODE"].ToString();
                item.LEVEL2_NAME = dtr["LEVEL2_NAME"].ToString();
                item.LEVEL3_CODE = dtr["LEVEL3_CODE"].ToString();
                item.LEVEL3_NAME = dtr["LEVEL3_NAME"].ToString();
                item.LEVEL4_CODE = dtr["LEVEL4_CODE"].ToString();
                item.LEVEL4_NAME = dtr["LEVEL4_NAME"].ToString();
                item.LEVEL5_CODE = dtr["LEVEL5_CODE"].ToString();
                item.LEVEL5_NAME = dtr["LEVEL5_NAME"].ToString();
                item.DEPTLEVEL = dtr["DEPTLEVEL"].ToString();
                item.DEPTCODE = dtr["DEPTCODE"].ToString();
                item.DEPTNAME = dtr["DEPTNAME"].ToString();
                lstResult.Add(item);
            }
            var jsonResult = Json(lstResult.ToDataSourceResult(request));
            jsonResult.MaxJsonLength = int.MaxValue;
            //return Json(lstResult.ToDataSourceResult(request));
            return jsonResult;
        }

        public ActionResult empDeptQuery([DataSourceRequest]DataSourceRequest request)
        {
            DataTable dtResult = aDeptDetailAccess.getAllDeptDetail();
            List<eEmployeeDept> lstResult = new List<eEmployeeDept>();
            /*
            foreach (DataRow dtr in dtResult.Rows)
            {
                eEmployeeDept item = new eEmployeeDept();
                item.SYS_EMPID = dtr["SYS_EMPID"].ToString();
                item.EMPID = dtr["EMPID"].ToString();
                item.EMPNAME = dtr["EMPNAME"].ToString();
                item.DEPTCODE = dtr["DEPTCODE"].ToString();
                item.DEPTNAME = dtr["DEPTNAME"].ToString();
                lstResult.Add(item);
            }
            */

            for(int i = 0; i < 10000; i++)
            {
                DataRow dtr = dtResult.Rows[i] as DataRow;
                eEmployeeDept item = new eEmployeeDept();
                item.SYS_EMPID = dtr["SYS_EMPID"].ToString();
                item.EMPID = dtr["EMPID"].ToString();
                item.EMPNAME = dtr["EMPNAME"].ToString();
                item.DEPTCODE = dtr["DEPTCODE"].ToString();
                item.DEPTNAME = dtr["DEPTNAME"].ToString();
                lstResult.Add(item);
            }
            var jsonResult = Json(lstResult.ToDataSourceResult(request));
            jsonResult.MaxJsonLength = int.MaxValue;
            //return Json(lstResult.ToDataSourceResult(request));
            return jsonResult;
        }
    }
}