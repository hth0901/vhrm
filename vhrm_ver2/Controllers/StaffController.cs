using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KSN.Framework.DataAccess;
//using KSN.Framework.Entity;
using KSN.FrameWork.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vhrm.FrameWork.BusinessLayer;
using vhrm.FrameWork.Entity;
using vhrm.ViewModels;

namespace vhrm.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            ViewBag.Gender = ViewBag.Gender = SelectListGender("0");
            ViewBag.Countries = SelectListCountries("");
            ViewBag.Academics = SelectListAcademicLevels("");
            ViewBag.Positions = SelectListPositions("");
            ViewBag.Skills = SelectListSkills("");
            //
            ViewBag.EMPID = "0";
            ViewBag.GEODIRECTREPORT = "0";
            ViewBag.FUNCDIRECTREPORT = "0";
            ViewBag.GEOGRAPHICALORG = "0";
            ViewBag.FUNCTIONALORG = "0";
            //
            ViewBag.geoInline = getGeOrganizations_Default_Inline_Data();
            ViewBag.functInline = getFunctReports_Default_Inline_Data();
            ViewBag.isMode = 0;           
            return View();
        }
        [HttpPost]
        public JsonResult getDeptCodeAndFuncCode(string empId)
        {
            ViewBag.isMode = 1;
            if (string.IsNullOrEmpty(empId))
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            EmployeeMaster employeeMaster = bEmployeeMaster.getEmployeeByEmpId(empId);
            if (employeeMaster == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            else
            {
                var data = new
                {
                    GEOGRAPHICALORG = employeeMaster.GEOGRAPHICALORG,
                    GEODIRECTREPORT = employeeMaster.GEODIRECTREPORT,
                    GEOUSERNAME = employeeMaster.DISPLAYGEODIRECTREPORT,
                    FUNCTIONALORG = employeeMaster.FUNCTIONALORG,
                    FUNCDIRECTREPORT = employeeMaster.FUNCDIRECTREPORT,
                    FUNCTUSERNAME = employeeMaster.DISPLAYFUNCDIRECTREPORT,
                    GEOUSER = employeeMaster.GEOEMPIDREPORT,
                    FUNCUSER = employeeMaster.FUNEMPIDREPORT
                };
                return Json(new { result = Json(data)});
            }           
        }
        private bool CheckLetter(string key)
        {
            foreach (char c in key)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
        [HttpPost]
        public JsonResult SearchUserByValue(string key)
        {
            var data = new List<EmployeeMaster>();
            if (string.IsNullOrEmpty(key)) return Json(data, JsonRequestBehavior.AllowGet);
            else {
                data = bEmployeeMaster.getUserByLikeName(key);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult getDeptCodeAndFuncCodeKey(string empIdGeo, string empIdFunct)
        {
            EmployeeMaster geoemployeeMaster = bEmployeeMaster.getEmployeeByEmpId(empIdGeo);
            EmployeeMaster funtemployeeMaster = bEmployeeMaster.getEmployeeByEmpId(empIdFunct);
            if(geoemployeeMaster == null && funtemployeeMaster == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            if (geoemployeeMaster != null)
            {   if (funtemployeeMaster == null)
                {
                    var data = new
                    {
                        GEODIRECTREPORT = geoemployeeMaster.SYS_EMPID,
                        GEOUSER = geoemployeeMaster.EMPID,
                        FUNCDIRECTREPORT = "",
                        FUNCUSER = funtemployeeMaster.EMPID
                    };
                    return Json(new { result = Json(data) });
                }
                else
                {
                    var data = new
                    {
                        GEODIRECTREPORT = geoemployeeMaster.SYS_EMPID,
                        GEOUSER = geoemployeeMaster.EMPID,
                        FUNCDIRECTREPORT = funtemployeeMaster.SYS_EMPID,
                        FUNCUSER = funtemployeeMaster.EMPID
                    };
                    return Json(new { result = Json(data) });
                }                
            }
            if (funtemployeeMaster != null)
            {
                if (geoemployeeMaster == null)
                {
                    var data = new
                    {
                        GEODIRECTREPORT = "",
                        GEOUSER = "",
                        FUNCDIRECTREPORT = funtemployeeMaster.SYS_EMPID,
                        FUNCUSER = funtemployeeMaster.EMPID
                    };
                    return Json(new { result = Json(data) });
                }
                else
                {
                    var data = new
                    {
                        GEODIRECTREPORT = geoemployeeMaster.SYS_EMPID,
                        GEOUSER = geoemployeeMaster.EMPID,
                        FUNCDIRECTREPORT = funtemployeeMaster.SYS_EMPID,
                        FUNCUSER = funtemployeeMaster.EMPID
                    };
                    return Json(new { result = Json(data) });
                }
                
            }
            return Json(new { result = Json(null) });
        }
        public IEnumerable<GeoDeptViewModel> getGeOrganizations_Default_Inline_Data()
        {
            List<GeoDeptViewModel> lstResult = new List<GeoDeptViewModel>();
            lstResult = bGeoReport.getTreeGeoDepts();
            //if (Session["geoorganizationreport_tree"] == null)
            // Session["geoorganizationreport_tree"] = bGeoReport.getTreeGeoDepts();
            //lstResult = Session["geoorganizationreport_tree"] as List<GeoDeptViewModel>;
            return lstResult;
        }
        public JsonResult getGeOrganizations(string DEPTCODE)
        {
            var lstResult = new List<GeoDeptViewModel>();
            if (Session["geoorganizationreport_tree"] == null)
                Session["geoorganizationreport_tree"] = bGeoReport.getTreeGeoDepts();

            lstResult = Session["geoorganizationreport_tree"] as List<GeoDeptViewModel>;
            var result = from e in lstResult
                         where (!string.IsNullOrEmpty(DEPTCODE) ? e.DEPTPARENT == DEPTCODE : string.IsNullOrEmpty(e.DEPTPARENT))
                         select new
                         {
                             DEPTCODE = e.DEPTCODE,
                             DEPTNAME = e.DEPTNAME,
                             hasChildren = e.isChild
                         };
            return Json(result.ToList(), JsonRequestBehavior.AllowGet);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getUserInGeoReportByDeptCode([DataSourceRequest]DataSourceRequest request,string deptcode, string empid)
        {
            var data = bGeoReport.getUserInGeoReportByDeptCode(deptcode, empid);
            return Json(data.ToDataSourceResult(request));
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getUserInFunctReportByDeptCode([DataSourceRequest]DataSourceRequest request, string funccode, string empid)
        {
            var data = bFunctionReport.getUserInFunctReportByDeptCode(funccode, empid);
            return Json(data.ToDataSourceResult(request));
            //return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getFunctReports(string FUNCCODE)
        {
            var lstResult = new List<FunctionReportViewModel>();
            if (Session["functreport_tree"] == null)
                Session["functreport_tree"] = bFunctionReport.getFunctionDeptsRegistered();

            lstResult = Session["functreport_tree"] as List<FunctionReportViewModel>;
            var result = from e in lstResult
                         where (!string.IsNullOrEmpty(FUNCCODE) ? e.FUNCPARENT == FUNCCODE : string.IsNullOrEmpty(e.FUNCPARENT))
                         select new
                         {
                             FUNCCODE = e.FUNCCODE,
                             FUNCNAME = e.FUNCNAME,
                             hasChildren = e.isChild
                         };
            return Json(result.ToList(), JsonRequestBehavior.AllowGet);

            //var data = bFunctionReport.getTreeFunctionDepts();
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        public IEnumerable<FunctionReportViewModel> getFunctReports_Default_Inline_Data()
        {
            var lstResult = new List<FunctionReportViewModel>();
            lstResult = bFunctionReport.getTreeFunctionDepts();
            //if (Session["functreport_tree"] == null)
            //Session["functreport_tree"] = bFunctionReport.getTreeFunctionDepts();

            //lstResult = Session["functreport_tree"] as List<FunctionReportViewModel>;
            return lstResult;
        }
        public JsonResult getLimitedFunctions(string functCode)
        {

            var data = bFunctionReport.getTreeLimitedFunctionReports(functCode ?? "000000");
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditEmployee(EmployeeMaster employeeMaster)
        {
            if (employeeMaster != null)
            {
                ViewBag.Countries = SelectListCountries(employeeMaster.NATIONALITY);
                ViewBag.Gender = SelectListGender(employeeMaster.GENDER);
                ViewBag.Academics = SelectListAcademicLevels(employeeMaster.ACADEMIC);
                ViewBag.Positions = SelectListPositions(employeeMaster.POSITION);
                ViewBag.Skills = SelectListSkills(employeeMaster.SKILL);
                return View(employeeMaster);
            }
            else
            {
                ViewBag.Countries = SelectListCountries("");
                ViewBag.Gender = SelectListGender("");
                ViewBag.Academics = SelectListAcademicLevels("");
                ViewBag.Positions = SelectListPositions("");
                ViewBag.Skills = SelectListSkills("");
                View("Index", employeeMaster);
            }
            return View("Index", employeeMaster);
        }
        //[HttpGet]
        //public ActionResult NewEmployee()
        //{
        //    EmployeeMaster employeeMaster = new EmployeeMaster();
        //    employeeMaster.EMPID = bEmployeeMaster.getEmpId();
        //    return View("Index", employeeMaster);
        //}
        public ActionResult SaveEmployee()
        {
            ViewBag.Gender = ViewBag.Gender = SelectListGender("0");
            ViewBag.Countries = SelectListCountries("");
            ViewBag.Academics = SelectListAcademicLevels("");
            ViewBag.Positions = SelectListPositions("");
            ViewBag.Skills = SelectListSkills("");
            ViewBag.isMode = 0;            
            return View("Index");
        }
        [HttpPost]       
        public ActionResult SaveEmployee(EmployeeMaster employeeMaster)
        {            
            ViewBag.isMode = 1;
            bool isValid = true;
            //New         
            //string DATEJOIN = employeeMaster.DATEJOIN.ToString("dd-MM-yyyy");
            //employeeMaster.DATEJOIN = DateTime.Parse(DATEJOIN);
            if (string.IsNullOrEmpty(employeeMaster.SYS_EMPID))
            {
                employeeMaster.SYS_EMPID = bEmployeeMaster.getSysEmpId();
                employeeMaster.EMPID = "00000000";
                
                if (ModelState.IsValid)
                {
                    employeeMaster.EMPID = bEmployeeMaster.getEmpId(employeeMaster.DEPTCODE, employeeMaster.DATEJOIN);
                    employeeMaster.IMAGE = "default.jpg";
                    //string image = uploadImage(null, employeeMaster.EMPID);
                    //employeeMaster.IMAGE = image;
                    bEmployeeMaster.insertEmployee(employeeMaster);
                    if (!string.IsNullOrEmpty(employeeMaster.GEOGRAPHICALORG) || !string.IsNullOrEmpty(employeeMaster.FUNCTIONALORG))
                    {
                        EmployeeMasterReport employeeMasterGeReport = new EmployeeMasterReport();
                        //insert employeereport is georeport.
                        if (!string.IsNullOrEmpty(employeeMaster.GEOGRAPHICALORG))
                        {
                            employeeMasterGeReport.DEPTCODEGEO = employeeMaster.GEOGRAPHICALORG;
                            if (!string.IsNullOrEmpty(employeeMaster.GEODIRECTREPORT))
                            {
                                employeeMasterGeReport.SYS_EMPIDGEO = employeeMaster.GEODIRECTREPORT;
                            }
                        }
                        //insert employeereport is functionreport.
                        if (!string.IsNullOrEmpty(employeeMaster.FUNCTIONALORG))
                        {
                            employeeMasterGeReport.DEPTCODEFUN = employeeMaster.FUNCTIONALORG;
                            if (!string.IsNullOrEmpty(employeeMaster.FUNCDIRECTREPORT))
                            {
                                employeeMasterGeReport.SYS_EMPIDFUN = employeeMaster.FUNCDIRECTREPORT;
                            }
                        }
                        employeeMasterGeReport.REPORTCD = bEmployeeMasterReport.getReportCDID();
                        employeeMasterGeReport.SYS_EMPID = employeeMaster.SYS_EMPID;                        
                        bEmployeeMasterReport.InsertEmployeeReport(employeeMasterGeReport);
                    }
                }
                else
                {
                    isValid = false;
                    employeeMaster.SYS_EMPID = null;
                    employeeMaster.EMPID = null;
                }
                    
            }
            else//Update
            {
                if (ModelState.IsValid)
                {
                    //string image = uploadImage(null, employeeMaster.EMPID);
                    //employeeMaster.IMAGE = image;           
                    if (employeeMaster.IMAGE.Contains("default.jpg"))
                        employeeMaster.IMAGE = "default.jpg";
                    else
                        employeeMaster.IMAGE = employeeMaster.EMPID + ".jpg";
                    bEmployeeMaster.UpdateEmployee(employeeMaster);
                    List<EmployeeMasterReport> employeeMasterReport = bEmployeeMasterReport.getEmployeeReportBySysEmpID(employeeMaster.SYS_EMPID);
                    if (employeeMasterReport.Count > 0)
                    {
                        employeeMasterReport[0].DEPTCODEGEO = employeeMaster.GEOGRAPHICALORG;
                        employeeMasterReport[0].SYS_EMPIDGEO = employeeMaster.GEODIRECTREPORT;
                        employeeMasterReport[0].SYS_EMPIDGEO = employeeMaster.GEODIRECTREPORT;
                        employeeMasterReport[0].DEPTCODEFUN = employeeMaster.FUNCTIONALORG;
                        employeeMasterReport[0].SYS_EMPIDFUN = employeeMaster.FUNCDIRECTREPORT;
                        bEmployeeMasterReport.UpdateEmployeeReport(employeeMasterReport[0]);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(employeeMaster.GEOGRAPHICALORG) || !string.IsNullOrEmpty(employeeMaster.FUNCTIONALORG))
                        {
                            EmployeeMasterReport employeeMasterGeReport = new EmployeeMasterReport();
                            //insert employeereport is georeport.
                            if (!string.IsNullOrEmpty(employeeMaster.GEOGRAPHICALORG))
                            {
                                employeeMasterGeReport.DEPTCODEGEO = employeeMaster.GEOGRAPHICALORG;
                                if (!string.IsNullOrEmpty(employeeMaster.GEODIRECTREPORT))
                                {
                                    employeeMasterGeReport.SYS_EMPIDGEO = employeeMaster.GEODIRECTREPORT;
                                }
                            }
                            //insert employeereport is functionreport.
                            if (!string.IsNullOrEmpty(employeeMaster.FUNCTIONALORG))
                            {
                                employeeMasterGeReport.DEPTCODEFUN = employeeMaster.FUNCTIONALORG;
                                if (!string.IsNullOrEmpty(employeeMaster.FUNCDIRECTREPORT))
                                {
                                    employeeMasterGeReport.SYS_EMPIDFUN = employeeMaster.FUNCDIRECTREPORT;
                                }
                            }
                            employeeMasterGeReport.REPORTCD = bEmployeeMasterReport.getReportCDID();
                            employeeMasterGeReport.SYS_EMPID = employeeMaster.SYS_EMPID;
                            bEmployeeMasterReport.InsertEmployeeReport(employeeMasterGeReport);
                        }
                    }
                }
                else
                    isValid = false;
            }
            ViewBag.Countries = SelectListCountries(employeeMaster.NATIONALITY);
            ViewBag.Gender = SelectListGender(employeeMaster.GENDER);
            ViewBag.Academics = SelectListAcademicLevels(employeeMaster.ACADEMIC);
            ViewBag.Positions = SelectListPositions(employeeMaster.POSITION);
            ViewBag.Skills = SelectListSkills(employeeMaster.SKILL);
            //if (Session["geoorganizationreport_tree"] == null)
            //    Session["geoorganizationreport_tree"] = bGeoReport.getTreeGeoDepts();
            //if (Session["functreport_tree"] == null)
            //    Session["functreport_tree"] = bFunctionReport.getTreeFunctionDepts();
            ViewBag.geoInline = getGeOrganizations_Default_Inline_Data();
            ViewBag.functInline = getFunctReports_Default_Inline_Data();
            if (!string.IsNullOrEmpty(employeeMaster.EMPID)) {
                employeeMaster = bEmployeeMaster.getEmployeeByEmpId(employeeMaster.EMPID);
            }
            if (isValid == false)
            {
                ViewBag.isMode = 0;
                ModelState.Clear();
                return View("Index", employeeMaster);
            }
            ModelState.Clear();
            return View("Index", employeeMaster);
            //return View("Edit", employeeMaster);
        }
        public JsonResult getDataEmployee(string empId)
        {
            if (string.IsNullOrEmpty(empId)) return Json(null, JsonRequestBehavior.AllowGet);
            EmployeeMaster employeeMaster = bEmployeeMaster.getEmployeeByEmpId(empId);
            var data = new { empId = employeeMaster.EMPID, sys_empId = employeeMaster .SYS_EMPID};
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult QueryEmployeeByEmpId(string empId)
        {
            EmployeeMaster employeeMaster = bEmployeeMaster.getEmployeeByEmpId(empId);
            if (employeeMaster != null)
            {
                ViewBag.Countries = SelectListCountries(employeeMaster.NATIONALITY);
                ViewBag.Gender = SelectListGender(employeeMaster.GENDER);
                ViewBag.Academics = SelectListAcademicLevels(employeeMaster.ACADEMIC);
                ViewBag.Positions = SelectListPositions(employeeMaster.POSITION);
                ViewBag.Skills = SelectListSkills(employeeMaster.SKILL);
                //
                ViewBag.EMPID = employeeMaster.EMPID;
                ViewBag.GEODIRECTREPORT = employeeMaster.GEODIRECTREPORT;
                ViewBag.FUNCDIRECTREPORT = employeeMaster.FUNCDIRECTREPORT;
                ViewBag.GEOGRAPHICALORG = employeeMaster.GEOGRAPHICALORG;
                ViewBag.FUNCTIONALORG = employeeMaster.FUNCTIONALORG;
                //
                ViewBag.isMode = 1;
                ViewBag.geoInline = getGeOrganizations_Default_Inline_Data();
                ViewBag.functInline = getFunctReports_Default_Inline_Data();
                return View("Index", employeeMaster);
                //return PartialView("Edit", employeeMaster);  //View("Edit",employeeMaster);
            }
            else
            {
                ViewBag.Countries = SelectListCountries("");
                ViewBag.Gender = SelectListGender("");
                ViewBag.Academics = SelectListAcademicLevels("");
                ViewBag.Positions = SelectListPositions("");
                ViewBag.Skills = SelectListSkills("");
                //
                ViewBag.EMPID = "0";
                ViewBag.GEODIRECTREPORT = "0";
                ViewBag.FUNCDIRECTREPORT = "0";
                ViewBag.GEOGRAPHICALORG = "0";
                ViewBag.FUNCTIONALORG = "0";
                //
                ViewBag.isMode = 0;
                ViewBag.geoInline = getGeOrganizations_Default_Inline_Data();
                ViewBag.functInline = getFunctReports_Default_Inline_Data();
                employeeMaster = new EmployeeMaster();
                employeeMaster.IMAGE = "default.jpg";
                return View("Index", employeeMaster);
            }
        }       
        public ActionResult New()
        {
            EmployeeMaster employeeMaster = new EmployeeMaster();
            employeeMaster.BIRTHDATE = DateTime.Now;
            employeeMaster.DATEJOIN = DateTime.Now;
            ViewBag.Countries = SelectListCountries(employeeMaster.NATIONALITY);
            ViewBag.Gender = SelectListGender("0");
            ViewBag.Academics = SelectListAcademicLevels(employeeMaster.ACADEMIC);
            ViewBag.Positions = SelectListPositions(employeeMaster.POSITION);
            ViewBag.Skills = SelectListSkills(employeeMaster.SKILL);
            ViewBag.isMode = 0;
            ViewBag.geoInline = getGeOrganizations_Default_Inline_Data();
            ViewBag.functInline = getFunctReports_Default_Inline_Data();
            return View(employeeMaster);
        }        
        public ActionResult Edit(string empId)
        {
            EmployeeMaster employeeMaster = bEmployeeMaster.getEmployeeByEmpId(empId);
            ViewBag.isMode = 1;
            //if (Session["geoorganizationreport_tree"] == null)
            //    Session["geoorganizationreport_tree"] = bGeoReport.getTreeGeoDepts();
            //if (Session["functreport_tree"] == null)
            //    Session["functreport_tree"] = bFunctionReport.getTreeFunctionDepts();
            if (employeeMaster != null)
            {
                ViewBag.Countries = SelectListCountries(employeeMaster.NATIONALITY);
                ViewBag.Gender = SelectListGender(employeeMaster.GENDER);
                ViewBag.Academics = SelectListAcademicLevels(employeeMaster.ACADEMIC);
                ViewBag.Positions = SelectListPositions(employeeMaster.POSITION);
                ViewBag.Skills = SelectListSkills(employeeMaster.SKILL);
                ViewBag.geoInline = getGeOrganizations_Default_Inline_Data();
                ViewBag.functInline = getFunctReports_Default_Inline_Data();
                return PartialView("New", employeeMaster);//View(employeeMaster);
            }
           else
           {
                ViewBag.Countries = SelectListCountries("");
                ViewBag.Gender = SelectListGender("");
                ViewBag.Academics = SelectListAcademicLevels("");
                ViewBag.Positions = SelectListPositions("");
                ViewBag.Skills = SelectListSkills("");
                ViewBag.isMode = 0;
                ViewBag.geoInline = getGeOrganizations_Default_Inline_Data();
                ViewBag.functInline = getFunctReports_Default_Inline_Data();
                //EmployeeMaster employee = new EmployeeMaster();
                //employee.IMAGE = "default.jpg";
                return PartialView("New");
            }
            
        }
        [NonAction]
        public SelectList SelectListCountries(string selected)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<CategoryValueEntity> nations = bEmployeeMaster.getCategories();
            foreach (var country in nations)
            {
                list.Add(new SelectListItem()
                {
                    Text = country.CategoryValue,
                    Value = country.Code
                });
            }
            return new SelectList(list, "Value", "Text", selected);
        }
        [NonAction]
        public SelectList SelectListPositions(string selected)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<CategoryValueEntity> nations = bEmployeeMaster.getPositions();
            foreach (var country in nations)
            {
                list.Add(new SelectListItem()
                {
                    Text = country.CategoryValue,
                    Value = country.Code
                });
            }
            return new SelectList(list, "Value", "Text", selected);
        }
        [NonAction]
        public SelectList SelectListSkills(string selected)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<CategoryValueEntity> nations = bEmployeeMaster.getSkills();
            foreach (var country in nations)
            {
                list.Add(new SelectListItem()
                {
                    Text = country.CategoryValue,
                    Value = country.Code
                });
            }
            return new SelectList(list, "Value", "Text", selected);
        }
        [NonAction]
        public SelectList SelectListGender(string selected)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem()
            {
                Text = "Male",
                Value = "1"
            });
            list.Add(new SelectListItem()
            {
                Text = "Female",
                Value = "0"
            });
            return new SelectList(list, "Value", "Text", selected);
        }
        [NonAction]
        public SelectList SelectListAcademicLevels(string selected)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<CategoryValueEntity> academicLevels = bEmployeeMaster.getAcademicLevels();
            foreach (var academic in academicLevels)
            {
                list.Add(new SelectListItem()
                {
                    Text = academic.CategoryValue,
                    Value = academic.Code
                });
            }
            return new SelectList(list, "Value", "Text", selected);
        }

        public JsonResult getGeOrgUsers(string deptcode)
        {           
            var data = Tree.getTreeUserGeoDepts(deptcode ?? "000000");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getFunctUsers(string funccode)
        {
            var data = Tree.getTreeUserFunctions(funccode ?? "000000");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EmployeeMaster_Query([DataSourceRequest]DataSourceRequest request, string empId,string functCode)
        {
            if (string.IsNullOrEmpty(empId) && string.IsNullOrEmpty(functCode))
            {
                List<EmployeeMaster> data = new List<EmployeeMaster>();
                return Json(data.ToDataSourceResult(request));
            }
                
            List<EmployeeMaster> result = bFunctionReport.QueryEmployeeByEmpIdFunctCode(empId, functCode);
            ViewBag.geoInline = getGeOrganizations_Default_Inline_Data();
            ViewBag.functInline = getFunctReports_Default_Inline_Data();
            return Json(result.ToDataSourceResult(request));
        }
        //Version 2.0
        public ActionResult _OrgChart(string empId)
        {
            if (string.IsNullOrEmpty(empId)) return Json(0, JsonRequestBehavior.AllowGet);
            EmployeeMaster employeeMaster = bEmployeeMaster.getEmployeeByEmpId(empId);
            List<EmployeeDiagramViewModel> data = bEmployeeMasterReport.getDiagram(employeeMaster);
            if (data == null && employeeMaster != null)
            {
                data = new List<EmployeeDiagramViewModel>();
                EmployeeDiagramViewModel root = new EmployeeDiagramViewModel();
                root.EMPNAME = employeeMaster.EMPNAME;
                root.EMPID = employeeMaster.EMPID;
                root.SYS_EMPID = employeeMaster.SYS_EMPID;
                root.ColorScheme = "#ee587b";
                if (string.IsNullOrEmpty(employeeMaster.IMAGE))
                    root.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                else
                    root.Image = employeeMaster.IMAGE + "?" + (new Random()).Next(0, 100);
                data.Add(root);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _OrgChartGeo(string empId)
        {
            if (string.IsNullOrEmpty(empId)) return Json(0, JsonRequestBehavior.AllowGet);
            EmployeeMaster employeeMaster = bEmployeeMaster.getEmployeeByEmpId(empId);
            List<EmployeeDiagramViewModel> data = bEmployeeMasterReport.getDiagramGEO(employeeMaster);
            if (data == null && employeeMaster != null)
            {
                data = new List<EmployeeDiagramViewModel>();
                EmployeeDiagramViewModel root = new EmployeeDiagramViewModel();
                root.EMPNAME = employeeMaster.EMPNAME;
                root.EMPID = employeeMaster.EMPID;
                root.SYS_EMPID = employeeMaster.SYS_EMPID;
                root.ColorScheme = "#ee587b";
                if (string.IsNullOrEmpty(employeeMaster.IMAGE))
                    root.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                else
                    root.Image = employeeMaster.IMAGE + "?" + (new Random()).Next(0, 100);
                data.Add(root);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //Version 1.0
        //public ActionResult _OrgChart(string empId)
        //{
        //    if(string.IsNullOrEmpty(empId)) return Json(null, JsonRequestBehavior.AllowGet);
        //    EmployeeMaster employeeMaster = bEmployeeMaster.getEmployeeByEmpId(empId);
        //    List<EmployeeDiagramViewModel> data = bEmployeeMasterReport.getDiagram(employeeMaster);
        //    if (data == null && employeeMaster != null)
        //    {
        //        data = new List<EmployeeDiagramViewModel>();
        //        EmployeeDiagramViewModel root = new EmployeeDiagramViewModel();
        //        root.EMPNAME = employeeMaster.EMPNAME;
        //        root.EMPID = employeeMaster.EMPID;
        //        root.SYS_EMPID = employeeMaster.SYS_EMPID;
        //        root.ColorScheme = "#ee587b";
        //        if (string.IsNullOrEmpty(employeeMaster.IMAGE))
        //            root.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
        //        else
        //            root.Image = employeeMaster.IMAGE + "?" + (new Random()).Next(0, 100);
        //        data.Add(root);
        //    }            
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
        [NonAction]
        private string uploadImage(IEnumerable<HttpPostedFileBase> imgUpload, string empId)
        {
            string newName = string.Empty;
            string filePath = "";
            if (imgUpload != null)
            {
                var file = imgUpload.ToList()[0];
                var size = file.ContentLength / 1024;
                if (size <= 50)
                {
                    var fileName = Path.GetFileName(file.FileName);                    
                    string[] array = fileName.Split('.');
                    if (array.Length > 0)
                        newName = empId + "." + array[1];                    
                    filePath = "/FileServer/Photos/" + newName;
                    var pysicalPath = Path.Combine(Server.MapPath("~/FileServer/Photos"), newName);
                    file.SaveAs(pysicalPath);                    
                }                
            }
            return newName;
        }
        [HttpPost]
        public ActionResult Async_Upload_Image(IEnumerable<HttpPostedFileBase> imgUpload, string empId)
        {
            if (string.IsNullOrEmpty(empId))
                return Content("");          
            string filePath = "";
            if (imgUpload != null)
            {
                var file = imgUpload.ToList()[0];
                var size = file.ContentLength / 1024;
                if (size > 50)
                {
                    return Json(new { sys_empid = empId, img_url = "size" }, "text/plain");
                }
                var fileName = Path.GetFileName(file.FileName);
                EmployeeMaster employee = bEmployeeMaster.getEmployeeByEmpId(empId);
                string newName = string.Empty;
                string[] array = fileName.Split('.');
                if (array.Length > 0)
                    newName = empId + "." + array[1];
                employee.IMAGE = newName;
                filePath = "/FileServer/Photos/" + newName;
                var pysicalPath = Path.Combine(Server.MapPath("~/FileServer/Photos"), newName);
                file.SaveAs(pysicalPath);
                bEmployeeMaster.UpdateEmployee(employee);
            }           
            return Json(new { sys_empid = empId, img_url = filePath }, "text/plain");
        }       
    }
}