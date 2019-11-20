using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.BusinessLayer;
using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.Entity;

namespace vhrm.Controllers
{
    public class MenuConfigController : Controller
    {
        // GET: MenuConfig
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getAllMenu(string id)
        {
            List<eMenuItem> lstResult = new List<eMenuItem>();
            if (Session["list_menu"] == null)
                Session["list_menu"] = bMenuConfig.getAllMenu();
            lstResult = Session["list_menu"] as List<eMenuItem>;

            var result = from e in lstResult
                         where (!string.IsNullOrEmpty(id) ? e.MOTHERID == id : string.IsNullOrEmpty(e.MOTHERID))
                         select new
                         {
                             id = e.MENUID,
                             Name = e.MENUNAME,
                             hasChildren = e.ISLEAF == "0"
                         };

            return Json(result.ToList(), JsonRequestBehavior.AllowGet);

            //return Json(lstResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getMenuDetail(string menu_id)
        {
            MenuTreeEntity vm = new MenuTreeEntity();
            if (!string.IsNullOrEmpty(menu_id))
                vm = bMenuConfig.getMenuDetail(menu_id);
            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult inserNewMenu(MenuTreeEntity menuEntity)
        {
            menuEntity.DictionaryID = "";
            menuEntity.FormID = "";
            menuEntity.MenuID = "";
            dynamic showMessageString = string.Empty;
            showMessageString = new
            {
                param1 = 200,
                param2 = "insert success"
            };
            try
            {
                menuEntity.CREATE_UID = "hieuht";
                bool insertResult = MenuTreeAccess.InsertMenu(menuEntity);
                if (insertResult == true)
                    Session["list_menu"] = null;
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message.ToString();
                showMessageString = new
                {
                    param1 = 404,
                    param2 = "proccess error"
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
            //return Json(menuEntity, JsonRequestBehavior.AllowGet);
            //return Json(showMessageString, "text/plain");
        }
        [HttpPut]
        public ActionResult updateMenu(MenuTreeEntity menuEntity)
        {
            //bool result = MenuTreeAccess.UpdateMenu(menuEntity);
            menuEntity.DictionaryID = "";
            if (string.IsNullOrEmpty(menuEntity.FormID))
                menuEntity.FormID = "";
            dynamic showMessageString = string.Empty;
            showMessageString = new
            {
                param1 = 200,
                param2 = "update success"
            };
            try
            {
                menuEntity.UPDATE_UID = "hieuht";
                bool insertResult = MenuTreeAccess.UpdateMenu(menuEntity);
                if (insertResult == true)
                    Session["list_menu"] = null;
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message.ToString();
                showMessageString = new
                {
                    param1 = 404,
                    param2 = "proccess error"
                };
                return Json(showMessageString, JsonRequestBehavior.AllowGet);
            }
            //return Json(menuEntity, JsonRequestBehavior.AllowGet);
        }
    }
}