using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.BusinessLayer;
using vhrm.ViewModels;

namespace vhrm.Controllers
{
    public class DeptFunctionController : Controller
    {
        // GET: DeptFunction
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getFunctions(string FUNCCODE)
        {
            List<FunctViewModel> lstResult = new List<FunctViewModel>();
            if (Session["function_tree"] == null)
                Session["function_tree"] = bFunction.getFuncts(); 
            lstResult = Session["function_tree"] as List<FunctViewModel>;
            var result = from e in lstResult
                         where (!string.IsNullOrEmpty(FUNCCODE) ? e.FUNCPARENT == FUNCCODE : string.IsNullOrEmpty(e.FUNCPARENT))
                         select new
                         {
                             FUNCCODE = e.FUNCCODE,
                             FUNCNAME = e.FUNCNAME,
                             FUNCPARENT = e.FUNCPARENT,
                             ISACTIVE = e.ISACTIVE,
                             ORDERINDEX = e.ORDERINDEX,
                             hasChildren = lstResult.Where(c => c.FUNCPARENT == e.FUNCCODE).FirstOrDefault() != null
                         };
            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
            //var data = bFunction.getFuncts(functCode);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult AddNewFunction()
        {
            FunctViewModel functViewModel = new FunctViewModel();
            return View(functViewModel);
        }
        [HttpPost]
        public ActionResult AddNewFunction(string functParent, string functName, bool active, string orderIndex)
        {
            FunctViewModel functViewModel = new FunctViewModel();
            string functCode = bFunction.getNewFunctCode(functParent);
            if (functParent == null || string.Empty == functParent)
                functParent = "000000";
            if (functCode == "-1")
            {
                functViewModel.FUNCCODE = functParent;
                functViewModel.FUNCPARENT = null;
                functViewModel.FUNCLEVEL = "0";
            }
            else
            {
                functViewModel.FUNCPARENT = functParent;
                functViewModel.FUNCCODE = functCode;
                functViewModel.FUNCLEVEL = functCode.Substring(0, 1);
            }                        
            functViewModel.FUNCNAME = functName;
            if (active)
                functViewModel.ISACTIVE = "1";
            else
                functViewModel.ISACTIVE = "0";
            functViewModel.ORDERINDEX = orderIndex;
            bFunction.insertFunction(functViewModel);
            Session["function_tree"] = bFunction.getFuncts();
            Session["functreport_tree"] = bFunctionReport.getTreeFunctionDepts();
            return PartialView("FunctionInforPartial");
        }

        [HttpPost]
        public ActionResult UpdateFunction(string functCode, string functParent, string functName, bool active, string orderIndex)
        {
            FunctViewModel functViewModel = new FunctViewModel();
            functViewModel.FUNCCODE = functCode;
            functViewModel.FUNCPARENT = functParent;
            functViewModel.FUNCNAME = functName;
            functViewModel.FUNCLEVEL = functCode.Substring(0, 1);
            if (active)
                functViewModel.ISACTIVE = "1";
            else
                functViewModel.ISACTIVE = "0";
            functViewModel.ORDERINDEX = orderIndex;
            bFunction.UpdateFunction(functViewModel);
            Session["function_tree"] = bFunction.getFuncts();
            Session["functreport_tree"] = bFunctionReport.getTreeFunctionDepts();
            return PartialView("FunctionInforPartial");
        }
    }
}