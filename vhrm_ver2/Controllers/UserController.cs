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
using vhrm.FrameWork.Utility;
using Oracle.ManagedDataAccess.Client;

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

        [HttpPost]
        public ActionResult updateUserPassword(string UserId, string oldPassword, string newPassword, string newPasswordConfirm)
        {
            dynamic showMessageString = string.Empty;
            showMessageString = new
            {
                param1 = "OK",
                param2 = "Update success!!"
            };
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newPasswordConfirm))
            {
                showMessageString = new
                {
                    param1 = "Error",
                    param2 = "Please Check Data"
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }

            if (newPassword != newPasswordConfirm)
            {
                showMessageString = new
                {
                    param1 = "Error",
                    param2 = "New password not match"
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
            string oldpass = ED5Helper.Encrypt(oldPassword);
            string newpass = ED5Helper.Encrypt(newPassword);

            UserAccess uAccess = new UserAccess();
            DataTable dtResult = new DataTable();
            dtResult = uAccess.ChangePasswrod(UserId, oldPassword, newPassword);
            if (dtResult.Rows[0][0].ToString() != "OK")
            {
                showMessageString = new
                {
                    param1 = "Error",
                    param2 = "Change password failed!!"
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
            return Json(showMessageString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult createNewUser(string Username, string Password)
        {
            dynamic showMessageString = string.Empty;
            string sqlQuery = "sp_insert_new_user";
            string pw = ED5Helper.Encrypt(Password);

            showMessageString = new
            {
                param1 = 200,
                param2 = "insert success",
                param3 = Username,
                param4 = pw
            };

            OracleParameter[] sqlParams = new OracleParameter[3];
            sqlParams[0] = new OracleParameter("PEMPID", Username);
            sqlParams[1] = new OracleParameter("PPASSWORD", OracleDbType.NVarchar2) { Value = pw };
            sqlParams[2] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            DataTable dtResult = new DataTable();

            try
            {
                dtResult = DBHelper.getDataTable_SP(sqlQuery, sqlParams);
            }
            catch(Exception ex)
            {
                showMessageString = new
                {
                    param1 = 404,
                    param2 = "proccess error",
                    param3 = Username,
                    param4 = pw
                };
            }

            if (dtResult.Rows[0][0].ToString() != "OK")
            {
                showMessageString = new
                {
                    param1 = 404,
                    param2 = "proccess error",
                    param3 = Username,
                    param4 = pw
                };
            }

            return Json(showMessageString, JsonRequestBehavior.AllowGet);
        }
    }
}