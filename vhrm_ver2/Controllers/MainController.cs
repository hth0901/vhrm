using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.BusinessLayer;
using vhrm.Models;
using vhrm.ViewModels;

namespace vhrm.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            if(Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            string userId = Session["UserId"].ToString();
            UserViewModel user = new UserViewModel();
            user.UserId = userId;
            user.UserName = Session["UserName"].ToString();
            //return View("kdc", user);
            //return View("mainview", user);
            //return View("mainviewver2", user);
            return View("mainviewver3", user);
        }

        public ActionResult GetMenuByUser()
        {
            List<MenuFirstLevel> menuList = new List<MenuFirstLevel>();
            menuList = bMainMenu.LoadMenu(Session["UserId"].ToString(), "en");
            //menuList = bMainMenu.LoadMenu("super", "en");
            //return PartialView("MenuPartial", menuList);
            return PartialView("MenuPartialVer3", menuList);
        }
    }
}