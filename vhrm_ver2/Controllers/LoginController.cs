using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.Utility;
using vhrm.Models;

namespace vhrm.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult logout()
        {
            Session.Abandon();
            Session.Clear();
            return View("index");
        }

        [HttpPost]
        public ActionResult DoLogin(UserLoginModel _loginInfo)
        {
            bool loginResult = LoginDB(_loginInfo.UserId, _loginInfo.Password);
            if (loginResult == true)
            {
                //FormsAuthentication.SetAuthCookie(_loginInfo.UserId, false);
                Session["UserId"] = _loginInfo.UserId;
                return RedirectToAction("Index", "Main");
            }
            return RedirectToAction("Index", "Login");
        }

        private string getIP()
        {
            string strIpAddress = "";
            strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(strIpAddress))
                strIpAddress = Request.ServerVariables["REMOTE_ADDR"];//we can use REMOTE_ADDR
            return strIpAddress;
        }


        private bool LoginDB(string strUser, string strPwd)
        {
            string sqlQuery = "PKOPM_LOGIN.sp_Login";
            strPwd = ED5Helper.Encrypt(strPwd);
            string ipAddress = getIP();
            OracleParameter[] sqlParams = new OracleParameter[7];
            sqlParams[0] = new OracleParameter("UserCd", strUser);
            sqlParams[1] = new OracleParameter("Pwd", strPwd);
            sqlParams[2] = new OracleParameter("Lang", "en");
            sqlParams[3] = new OracleParameter("pIpAddress", ipAddress);
            sqlParams[4] = new OracleParameter("pSessionID", Session.SessionID);
            sqlParams[5] = new OracleParameter("T_TABLE1", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            sqlParams[6] = new OracleParameter("T_TABLE2", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };

            DataSet ds = DBHelper.getDataSet_SP(sqlQuery, sqlParams);
            if (ds == null || ds.Tables.Count == 0)
            {
                //MessageHelper.ShowMessage(this, "Error!");
                return false;
            }
            else
            {

                if (ds.Tables[0].Rows[0][0].ToString() == "Err")
                    //MessageHelper.ShowMessage(this, ds.Tables[0].Rows[0][1].ToString());
                    return false;
                else if (ds.Tables[0].Rows[0][0].ToString() == "OK" && ds.Tables.Count > 1)
                {
                    int ipint = ToolHelper.IP2INT(ipAddress);
                    if (ds.Tables[1].Rows[0]["IP_RESTRICTION"].ToString() != "1")
                    {
                        //_page.UserId = ds.Tables[1].Rows[0]["UserId"].ToString();
                        //_page.UserNm = ds.Tables[1].Rows[0]["UserName"].ToString();
                        //_page.UserCd = ds.Tables[1].Rows[0]["UserId"].ToString();
                        //_page.Email = ds.Tables[1].Rows[0]["user_email"].ToString();
                        //_page.GroupId = ds.Tables[1].Rows[0]["GROUP_ID"].ToString();
                        //_page.StaffId = ds.Tables[1].Rows[0]["STAFF_ID"].ToString();
                        //_page.CorporationCd = ds.Tables[1].Rows[0]["corporation"].ToString();
                        //_page.CorporationNm = ds.Tables[1].Rows[0]["corporationName"].ToString();
                        //_page.DepartmentCd = ds.Tables[1].Rows[0]["department"].ToString();
                        //_page.TeamCd = ds.Tables[1].Rows[0]["team"].ToString();
                        //_page.SectionCd = ds.Tables[1].Rows[0]["section"].ToString();
                        //_page.LangId = "en";
                        //_page.ListManagementDepartment = ds.Tables[1].Rows[0]["ListDepcode"].ToString();
                        //temp
                        //_page.CorporationCd = "1001";
                        //Response.Redirect("~/Main.aspx");
                        Session["UserId"] = ds.Tables[1].Rows[0]["UserId"].ToString();
                        Session["UserName"] = ds.Tables[1].Rows[0]["UserName"].ToString();
                        Session["DeptsManage"] = ds.Tables[1].Rows[0]["ListDepcode"].ToString();

                        return true;
                    }
                    else if (!(Convert.ToInt32(ds.Tables[1].Rows[0]["START_ID"]) <= ipint && ipint <= Convert.ToInt32(ds.Tables[1].Rows[0]["END_ID"])))
                    {
                        //MessageHelper.ShowMessage(this, "Từ chối truy cập! User ko thể đăng nhập bên ngoài PK!");
                        //Response.Redirect("~/Login.aspx");
                        return false;
                    }
                    else
                    {
                        //_page.UserId = ds.Tables[1].Rows[0]["UserId"].ToString();
                        //_page.UserNm = ds.Tables[1].Rows[0]["UserName"].ToString();
                        //_page.UserCd = ds.Tables[1].Rows[0]["UserId"].ToString();
                        //_page.Email = ds.Tables[1].Rows[0]["user_email"].ToString();
                        //_page.GroupId = ds.Tables[1].Rows[0]["GROUP_ID"].ToString();
                        //_page.StaffId = ds.Tables[1].Rows[0]["STAFF_ID"].ToString();
                        //_page.CorporationCd = ds.Tables[1].Rows[0]["corporation"].ToString();
                        //_page.CorporationNm = ds.Tables[1].Rows[0]["corporationName"].ToString();
                        //_page.DepartmentCd = ds.Tables[1].Rows[0]["department"].ToString();
                        //_page.TeamCd = ds.Tables[1].Rows[0]["team"].ToString();
                        //_page.SectionCd = ds.Tables[1].Rows[0]["section"].ToString();
                        //_page.LangId = "en";
                        //_page.ListManagementDepartment = ds.Tables[1].Rows[0]["ListDepcode"].ToString();
                        //temp
                        //_page.CorporationCd = "1001";
                        //Response.Redirect("~/Main.aspx");
                        Session["UserId"] = ds.Tables[1].Rows[0]["UserId"].ToString();
                        Session["UserName"] = ds.Tables[1].Rows[0]["UserName"].ToString();
                        Session["DeptsManage"] = ds.Tables[1].Rows[0]["ListDepcode"].ToString();
                        return true;
                    }

                }
                else
                {
                    //MessageHelper.ShowMessage(this, "Login Faile!");
                    return false;
                }

            }

        }
    }
}