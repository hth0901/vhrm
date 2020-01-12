using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.BusinessLayer;
using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.Entity;
using vhrm.ViewModels;

namespace vhrm.Controllers
{
    public class FuncConfigController : Controller
    {
        // GET: FuncConfig
        public ActionResult Index()
        {
            string userId = Session["UserId"].ToString();
            FunctionConfigViewModel vm = new FunctionConfigViewModel();
            if (userId == "super")
            {
                vm.displayAdd = "inline-block";
            }
            else
            {
                vm.displayAdd = "none";
            }
            return View("FuncConfigIndex", vm);
        }

        private static List<eFunctionItem> getFunctionTree()
        {
            List<eFunctionItem> lstResult = new List<eFunctionItem>();
            DataTable dtResult = new DataTable();
            dtResult = aFunctionAccess.getAllFunction();
            foreach (DataRow dtr in dtResult.Rows)
            {
                eFunctionItem item = new eFunctionItem();
                item.FUNCCODE = dtr["FUNCCODE"].ToString();
                item.FUNCNAME = dtr["FUNCNAME"].ToString();
                item.FUNCPARENT = dtr["FUNCPARENT"].ToString();
                item.ISLEAF = dtr["ISLEAF"].ToString();
                lstResult.Add(item);
            }
            return lstResult;
        }

        public JsonResult getDeptTreeVer2(string id)
        {
            List<eFunctionItem> lstResult = new List<eFunctionItem>();
            if (Session["func_tree"] == null)
                Session["func_tree"] = getFunctionTree();
            lstResult = Session["func_tree"] as List<eFunctionItem>;

            var result = from e in lstResult
                         where (!string.IsNullOrEmpty(id) ? e.FUNCPARENT == id : string.IsNullOrEmpty(e.FUNCPARENT))
                         select new
                         {
                             id = e.FUNCCODE,
                             Name = e.FUNCNAME,
                             hasChildren = e.ISLEAF == "0"
                         };

            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrgCategory()
        {
            //return View("OrgCategory_hieuhtbk");
            return View("OrgCategory");
        }
        public JsonResult _OrgChartData(string deptcode)
        {
            KeyValuePair<JObject, List<JObject>> data = bDept.getDataForFuncChart(deptcode);
            JObject tagData = data.Key;
            List<JObject> nodeData = data.Value;
            string jsonG = JsonConvert.SerializeObject(tagData);
            string jsonN = JsonConvert.SerializeObject(nodeData);
            jsonN = jsonN.Replace("\"[", "[");
            jsonN = jsonN.Replace("]\"", "]");
            jsonN = jsonN.Replace("'", "\"");
            return Json(new { nodes = jsonN, groups = jsonG }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult getDeptDetail(string deptcode)
        {
            eFunctionItem eResult = new eFunctionItem();
            DataTable dtResult = aFunctionAccess.getFunctionDetail(deptcode);
            dynamic strResult = string.Empty;
            strResult = new
            {
                parent_name = dtResult.Rows[0]["PARENTNAME"].ToString(),
                deptcode = dtResult.Rows[0]["FUNCCODE"].ToString(),
                deptName = dtResult.Rows[0]["FUNCNAME"].ToString(),
                deptParent = dtResult.Rows[0]["FUNCPARENT"].ToString(),
                deptShortName = dtResult.Rows[0]["SHORTNAME"].ToString(),
                isActive = dtResult.Rows[0]["ISACTIVE"].ToString()
            };
            return Json(strResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult insertNewDept(eFunctionItem dept, string userId)
        {
            dept.CREATE_UID = Session["UserId"].ToString();
            dynamic showMessageString = string.Empty;
            DataTable dtResult = aFunctionAccess.insertNewFunction(dept);
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
                Session["func_tree"] = null;
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

        [HttpPut]
        public ActionResult updateDept(eFunctionItem dept, string userId)
        {
            dept.UPDATE_UID = Session["UserId"].ToString();
            dynamic showMessageString = string.Empty;
            DataTable dtResult = aFunctionAccess.updateFunction(dept);
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
                Session["func_tree"] = null;
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