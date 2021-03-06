﻿using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using vhrm.FrameWork.DataAccess;
using vhrm.ViewModels;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using vhrm.FrameWork.Entity;
using System.IO;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bDept
    {
        public static List<JObject> getSupervisorDataForChartV2(string deptCode)
        {
            List<JObject> elements = new List<JObject>();
            DataTable dtResult = GeoReportAccess.GetSupervisorByDeptCode(deptCode);
            List<string> sys_empidgeo = new List<string>();
            string sys_parent = string.Empty;
            if (dtResult.Rows.Count > 1)
            {
                DeptAccess deptAccess = new DeptAccess();
                DataTable depResult = deptAccess.GetByDeptCodeIsActive(deptCode);
                foreach (DataRow dtr in depResult.Rows)
                {
                    JObject rootSupervisor = new JObject();
                    rootSupervisor["id"] = dtr["DEPTCODE"].ToString();
                    rootSupervisor["pid"] = "null";
                    rootSupervisor["EMPID"] = "";
                    rootSupervisor["EMPNAME"] = "";
                    rootSupervisor["DEPTNAME"] = dtr["DEPTNAME"].ToString();
                    rootSupervisor["POSITION"] = "";
                    rootSupervisor["EMAIL"] = "";
                    rootSupervisor["IMAGE"] = "/FileServer/Photos/default.jpg";
                    elements.Add(rootSupervisor);
                    sys_parent = dtr["DEPTCODE"].ToString();
                    break;
                }
            }
            foreach (DataRow dtr in dtResult.Rows)
            {
                if(!sys_empidgeo.Contains(dtr["SYS_EMPIDGEO"].ToString()))
                    sys_empidgeo.Add(dtr["SYS_EMPIDGEO"].ToString());
            }
            if (sys_empidgeo != null && sys_empidgeo.Count() > 0)
            {                
                foreach (var sys_geo in sys_empidgeo)
                {
                    DataTable geos = GeoReportAccess.GetSupervisorsBySysGeo(sys_geo);
                    foreach (DataRow dtr in geos.Rows)
                    {
                        JObject subSupervisor = new JObject();
                        subSupervisor["id"] = dtr["SYS_EMPID"].ToString();
                        subSupervisor["pid"] = dtr["SYS_EMPIDGEO"].ToString();
                        subSupervisor["EMPID"] = dtr["EMPID"].ToString();
                        subSupervisor["EMPNAME"] = dtr["EMPNAME"].ToString();
                        subSupervisor["DEPTNAME"] = dtr["DEPTNAME"].ToString();
                        subSupervisor["POSITION"] = dtr["POSITION"].ToString();
                        subSupervisor["EMAIL"] = dtr["EMAIL"].ToString();
                        string imgsPath = dtr["IMAGE"].ToString();
                        if (string.IsNullOrEmpty(imgsPath))
                        {
                            imgsPath = "/FileServer/Photos/default.jpg";
                        }
                        else if (!IsFileExists(imgsPath))
                        {
                            imgsPath = "/FileServer/Photos/default.jpg";
                        }
                        subSupervisor["IMAGE"] = imgsPath;// dtr["IMAGE"].ToString();
                        elements.Add(subSupervisor);
                    }
                    //Get root.                    
                    EmployeeMaster root = bEmployeeMaster.getEmployeeBySysEmpid(sys_geo);
                    JObject rootSupervisor = new JObject();
                    rootSupervisor["id"] = sys_geo;
                    rootSupervisor["pid"] = sys_parent;
                    rootSupervisor["EMPID"] = root.EMPID;
                    rootSupervisor["EMPNAME"] = root.EMPNAME;
                    rootSupervisor["DEPTNAME"] = root.DEPTNAME;
                    rootSupervisor["POSITION"] = root.POSITION;
                    rootSupervisor["EMAIL"] = root.EMAIL;
                    string imgPath = root.IMAGE;
                    if (string.IsNullOrEmpty(imgPath))
                    {
                        imgPath = "/FileServer/Photos/default.jpg";
                    }
                    else if (!IsFileExists(imgPath))
                    {
                        imgPath = "/FileServer/Photos/default.jpg";
                    }
                    rootSupervisor["IMAGE"] = imgPath;
                    elements.Add(rootSupervisor);
                }               
            }
            if (elements.Count() == 0)
            {
                DeptAccess deptAccess = new DeptAccess();
                DataTable depResult = deptAccess.GetByDeptCodeIsActive(deptCode);
                foreach (DataRow dtr in depResult.Rows)
                {
                    JObject rootSupervisor = new JObject();
                    rootSupervisor["id"] = dtr["DEPTCODE"].ToString();
                    rootSupervisor["pid"] = "null";
                    rootSupervisor["EMPID"] = "";
                    rootSupervisor["EMPNAME"] = "Doesn't have SUPERVISOR";
                    rootSupervisor["DEPTNAME"] = dtr["DEPTNAME"].ToString();
                    rootSupervisor["POSITION"] = "";
                    rootSupervisor["EMAIL"] = "";
                    rootSupervisor["IMAGE"] = "/FileServer/Photos/default.jpg";
                    elements.Add(rootSupervisor);
                    sys_parent = dtr["DEPTCODE"].ToString();
                    break;
                }
            }
            return elements;
        }
        private static bool IsFileExists(string path)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(path)))
                return true;
            return false;
        }
        public static List<JObject> getSupervisorDataForChart(string deptCode)
        {
            List<JObject> elements = new List<JObject>();
            DataTable dtResult = GeoReportAccess.GetSupervisorByDeptCode(deptCode);
            string sys_empidgeo = string.Empty;
            foreach (DataRow dtr in dtResult.Rows)
            {
                sys_empidgeo = dtr["SYS_EMPIDGEO"].ToString();
            }
            if (!string.IsNullOrEmpty(sys_empidgeo))
            {
                DataTable geos = GeoReportAccess.GetSupervisorsBySysGeo(sys_empidgeo);
                foreach (DataRow dtr in geos.Rows)
                {
                    JObject subSupervisor = new JObject();
                    subSupervisor["id"] = dtr["SYS_EMPID"].ToString();
                    subSupervisor["pid"] = dtr["SYS_EMPIDGEO"].ToString();
                    subSupervisor["EMPID"] = dtr["EMPID"].ToString();
                    subSupervisor["EMPNAME"] = dtr["EMPNAME"].ToString();
                    subSupervisor["DEPTNAME"] = dtr["DEPTNAME"].ToString();
                    subSupervisor["POSITION"] = dtr["POSITION"].ToString();
                    subSupervisor["EMAIL"] = dtr["EMAIL"].ToString();
                    string imggPath = dtr["IMAGE"].ToString();
                    if (string.IsNullOrEmpty(imggPath))
                    {
                        imggPath = "/FileServer/Photos/default.jpg";
                    }
                    else if (!IsFileExists(imggPath))
                    {
                        imggPath = "/FileServer/Photos/default.jpg";
                    }
                    subSupervisor["IMAGE"] = imggPath;// dtr["IMAGE"].ToString();
                    elements.Add(subSupervisor);
                }
                //Get root.
                EmployeeMaster root = bEmployeeMaster.getEmployeeBySysEmpid(sys_empidgeo);
                JObject rootSupervisor = new JObject();
                rootSupervisor["id"] = sys_empidgeo;
                rootSupervisor["pid"] = "null";
                rootSupervisor["EMPID"] = root.EMPID;
                rootSupervisor["EMPNAME"] = root.EMPNAME;
                rootSupervisor["DEPTNAME"] = root.DEPTNAME;
                rootSupervisor["POSITION"] = root.POSITION;
                rootSupervisor["EMAIL"] = root.EMAIL;
                string imgPath = root.IMAGE;
                if (string.IsNullOrEmpty(imgPath))
                {
                    imgPath = "/FileServer/Photos/default.jpg";
                }
                else if (!IsFileExists(imgPath))
                {
                    imgPath = "/FileServer/Photos/default.jpg";
                }
                rootSupervisor["IMAGE"] = imgPath;
                elements.Add(rootSupervisor);
            }
            return elements;
        }
        public static List<JObject> getFunctionorDataForChart(string funcCode)
        {
            List<JObject> elements = new List<JObject>();
            DataTable dtResult = FunctionReportAccess.GetFunctionorByFuncCode(funcCode);
            string sys_empidFun = string.Empty;
            foreach (DataRow dtr in dtResult.Rows)
            {
                sys_empidFun = dtr["SYS_EMPIDFUN"].ToString();
            }
            if (!string.IsNullOrEmpty(sys_empidFun))
            {
                DataTable geos = FunctionReportAccess.GetFunctionorsBySysFun(sys_empidFun);
                foreach (DataRow dtr in geos.Rows)
                {
                    JObject subSupervisor = new JObject();
                    subSupervisor["id"] = dtr["SYS_EMPID"].ToString();
                    subSupervisor["pid"] = dtr["SYS_EMPIDFUN"].ToString();
                    subSupervisor["EMPID"] = dtr["EMPID"].ToString();
                    subSupervisor["EMPNAME"] = dtr["EMPNAME"].ToString();
                    subSupervisor["FUNCNAME"] = dtr["FUNCNAME"].ToString();
                    subSupervisor["POSITION"] = dtr["POSITION"].ToString();
                    subSupervisor["EMAIL"] = dtr["EMAIL"].ToString();
                    subSupervisor["IMAGE"] = dtr["IMAGE"].ToString();
                    elements.Add(subSupervisor);
                }
                //Get root.
                EmployeeMaster root = bEmployeeMaster.getEmployeeBySysEmpid(sys_empidFun);
                JObject rootSupervisor = new JObject();
                rootSupervisor["id"] = sys_empidFun;
                rootSupervisor["pid"] = "null";
                rootSupervisor["EMPID"] = root.EMPID;
                rootSupervisor["EMPNAME"] = root.EMPNAME;
                rootSupervisor["FUNCNAME"] = root.FUNCNAME;
                rootSupervisor["POSITION"] = root.POSITION;
                rootSupervisor["EMAIL"] = root.EMAIL;
                rootSupervisor["IMAGE"] = root.IMAGE;
                elements.Add(rootSupervisor);
            }
            return elements;
        }
        //23-11-2019        
        public static KeyValuePair<JObject, List<JObject>> getDataForOrgChart(string deptCode)
        {
            List<DeptViewModel> depts = new List<DeptViewModel>();
            //DUNG DE DUYET LUA CHON NODE HIEN THI.
            List<ElementViewModel> result = new List<ElementViewModel>();
            #region "TAO TAT CA CAC GROUPS"
            JObject groupElements = new JObject();
            DeptAccess access = new DeptAccess();
            DataTable dtResult = access.GetChildsByDeptCodeIsActive(deptCode);
            foreach (DataRow dtr in dtResult.Rows)
            {
                JObject group = new JObject();
                group["group"] = true;
                group["groupName"] = dtr["DEPTNAME"].ToString();
                group["groupState"] = "";
                group["template"] = "group_grey";
                string key = "A" + dtr["DEPTCODE"].ToString();
                DeptViewModel item = new DeptViewModel
                {
                    DEPTCODE = dtr["DEPTCODE"].ToString(),
                    DEPTNAME = dtr["DEPTNAME"].ToString(),
                    DEPTPARENT = dtr["DEPTPARENT"].ToString(),
                    DEPTLEVEL = dtr["DEPTLEVEL"].ToString(),
                    ORDERINDEX = dtr["ORDERINDEX"].ToString(),
                    ISACTIVE = dtr["ISACTIVE"].ToString(),
                    REMARK = dtr["REMARK"].ToString()
                };
                depts.Add(item);
                ElementViewModel g = new ElementViewModel
                {
                    display = true,
                    id = dtr["DEPTCODE"].ToString(),
                    pid = dtr["DEPTPARENT"].ToString()
                };
                result.Add(g);                
                groupElements[key] = group;
            }

            //LAY VE NODE TUONG UNG DEPTCODE TUYEN VAO.
            if (deptCode != "-1")
            {
                #region "NODE ROOT NEU DEPTCODE !=-1 (LAY TAT CA)"

                dtResult = access.GetByDeptCodeIsActive(deptCode);
                foreach (DataRow dtr in dtResult.Rows)
                {
                    int oLevel;
                    int.TryParse(dtr["DEPTLEVEL"].ToString(), out oLevel);
                    JObject group = new JObject();
                    group["group"] = true;
                    group["groupName"] = dtr["DEPTNAME"].ToString();
                    group["groupState"] = "";
                    group["template"] = "group_grey";
                    string key = "A" + dtr["DEPTCODE"].ToString();
                    DeptViewModel item = new DeptViewModel
                    {
                        DEPTCODE = dtr["DEPTCODE"].ToString(),
                        DEPTNAME = dtr["DEPTNAME"].ToString(),
                        DEPTPARENT = dtr["DEPTPARENT"].ToString(),
                        DEPTLEVEL = dtr["DEPTLEVEL"].ToString(),
                        ORDERINDEX = dtr["ORDERINDEX"].ToString(),
                        ISACTIVE = dtr["ISACTIVE"].ToString(),
                        REMARK = dtr["REMARK"].ToString()
                    };
                    depts.Add(item);
                    ElementViewModel g = new ElementViewModel
                    {
                        display = true,
                        id = dtr["DEPTCODE"].ToString(),
                        pid = dtr["DEPTPARENT"].ToString()
                    };
                    result.Add(g);
                    groupElements[key] = group;
                }
                #endregion
            }
            #region "TAO GROUP EMPTY"
            JObject egroup = new JObject();
            egroup["group"] = false;
            egroup["groupName"] = "";
            egroup["groupState"] = "";
            egroup["template"] = "empty";
            groupElements["empty"] = egroup;
            #endregion
            #endregion

            #region "TAO CAC NODES EMPTY"
            List<JObject> nodeElements = new List<JObject>();
            #region "TAO CAC GEO SUPERVISOR"
            var empReporter = bEmployeeMasterReport.GeSupervisors();
            Dictionary<string,string> deptCodeDeptParents = new Dictionary<string,string>();
            //LAY CAC GEO SUPERVISOR
            foreach (var geo in empReporter)
            {                
                var dept = result.Where(d => d.id == geo.DEPTCODEGEO).FirstOrDefault();               
                if (dept == null) continue;
                //DANH DAU KO HIEN THI
                dept.display = false;
                var list = result.Where(d => d.pid == dept.id);
                //TAO MOT NODE SUPERVISOR.
                JObject group = new JObject();
                
                //CAP NHAT LAI PID TRO VAO GEO SUPERVISOR
                foreach (var g in list)
                {
                    g.pid = geo.SYS_EMPID;
                } 
                group["id"] = geo.SYS_EMPID;
                var edept = result.Where(d => d.pid == dept.pid && d.display == false).FirstOrDefault();
                if (edept != null)
                {
                    var el = empReporter.Where(em => em.DEPTCODEGEO == dept.pid).FirstOrDefault();
                    if(el != null)
                        group["pid"] = el.SYS_EMPID;
                    else
                        group["pid"] = dept.pid;
                }                
                group["tags"] = "[" + "'A" + geo.DEPTCODEGEO + "']";
                group["EMPNAME"] = geo.EMPNAME;
                group["EMPID"] = geo.EMPID;
                group["EMAIL"] = geo.EMAIL;
                group["POSITION"] = geo.POSITION;
                group["IMAGE"] = geo.IMAGE;
                nodeElements.Add(group);
            }
            #endregion

            //KIEM TRA ROOT CO GEO SUPERVISOR.
            if (deptCode != "-1")
            {
                ElementViewModel e = result.Where(d => d.id == deptCode && d.display == true).FirstOrDefault();
                if (e != null)
                {
                    JObject rgroup = new JObject();
                    rgroup["id"] = e.id;
                    rgroup["pid"] = e.pid;
                    rgroup["tags"] = "[" + "'empty','A" + deptCode + "']";
                    rgroup["EMPNAME"] = "";
                    rgroup["EMPID"] = "";
                    rgroup["EMAIL"] = "";
                    rgroup["POSITION"] = "";
                    rgroup["IMAGE"] = "";
                    nodeElements.Add(rgroup);
                }
            }
           
            foreach (var d in depts)
            {
                ElementViewModel node = result.Where(dp => dp.id == d.DEPTCODE && dp.display == true).FirstOrDefault();
                if (node != null)
                {
                    JObject group = new JObject();
                    group["id"] = node.id;
                    group["pid"] = node.pid;
                    group["tags"] = "[" + "'empty','A" + d.DEPTCODE + "']";
                    group["EMPNAME"] = "";
                    group["EMPID"] = "";
                    group["EMAIL"] = "";
                    group["POSITION"] = "";
                    group["IMAGE"] = "";
                    nodeElements.Add(group);
                }

            }
            #endregion

            KeyValuePair<JObject, List<JObject>> data = new KeyValuePair<JObject, List<JObject>>(groupElements, nodeElements);
            return data;
        }
        public static KeyValuePair<JObject, List<JObject>> getDataForFuncChart(string funccode)
        {
            List<FunctViewModel> functs = new List<FunctViewModel>();
            //DUNG DE DUYET LUA CHON NODE HIEN THI.
            List<ElementViewModel> result = new List<ElementViewModel>();
            #region "TAO TAT CA CAC GROUPS"
            JObject groupElements = new JObject();
            FunctAccess access = new FunctAccess();
            DataTable dtResult = access.GetChildsByFunccodeIsActive(funccode);
            foreach (DataRow dtr in dtResult.Rows)
            {
                JObject group = new JObject();
                group["group"] = true;
                group["groupName"] = dtr["FUNCNAME"].ToString();
                group["groupState"] = "";
                group["template"] = "group_grey";
                string key = "A" + dtr["FUNCCODE"].ToString();
                FunctViewModel item = new FunctViewModel
                {
                    FUNCCODE = dtr["FUNCCODE"].ToString(),
                    FUNCNAME = dtr["FUNCNAME"].ToString(),
                    FUNCPARENT = dtr["FUNCPARENT"].ToString(),
                    FUNCLEVEL = dtr["FUNCLEVEL"].ToString(),
                    ORDERINDEX = dtr["ORDERINDEX"].ToString(),
                    ISACTIVE = dtr["ISACTIVE"].ToString()
                };
                functs.Add(item);
                ElementViewModel g = new ElementViewModel
                {
                    display = true,
                    id = dtr["FUNCCODE"].ToString(),
                    pid = dtr["FUNCPARENT"].ToString()
                };
                result.Add(g);
                groupElements[key] = group;
            }

            //LAY VE NODE TUONG UNG DEPTCODE TUYEN VAO.
            if (funccode != "-1")
            {
                #region "NODE ROOT NEU FUNCCODE !=-1 (LAY TAT CA)"

                dtResult = access.GetByFuncCodeIsActive(funccode);
                foreach (DataRow dtr in dtResult.Rows)
                {
                    int oLevel;
                    int.TryParse(dtr["FUNCLEVEL"].ToString(), out oLevel);
                    JObject group = new JObject();
                    group["group"] = true;
                    group["groupName"] = dtr["FUNCNAME"].ToString();
                    group["groupState"] = "";
                    group["template"] = "group_grey";
                    string key = "A" + dtr["FUNCCODE"].ToString();
                    FunctViewModel item = new FunctViewModel
                    {
                        FUNCCODE = dtr["FUNCCODE"].ToString(),
                        FUNCNAME = dtr["FUNCNAME"].ToString(),
                        FUNCPARENT = dtr["FUNCPARENT"].ToString(),
                        FUNCLEVEL = dtr["FUNCLEVEL"].ToString(),
                        ORDERINDEX = dtr["ORDERINDEX"].ToString(),
                        ISACTIVE = dtr["ISACTIVE"].ToString()
                    };
                    functs.Add(item);
                    ElementViewModel g = new ElementViewModel
                    {
                        display = true,
                        id = dtr["FUNCCODE"].ToString(),
                        pid = dtr["FUNCPARENT"].ToString()
                    };
                    result.Add(g);
                    groupElements[key] = group;
                }
                #endregion
            }
            #region "TAO GROUP EMPTY"
            JObject egroup = new JObject();
            egroup["group"] = false;
            egroup["groupName"] = "";
            egroup["groupState"] = "";
            egroup["template"] = "empty";
            groupElements["empty"] = egroup;
            #endregion
            #endregion

            #region "TAO CAC NODES EMPTY"
            List<JObject> nodeElements = new List<JObject>();
            #region "TAO CAC FUNCTIONER"
            var empReporter = bEmployeeMasterReport.GeFunctioners();
            Dictionary<string, string> funcCodeDeptParents = new Dictionary<string, string>();
            //LAY CAC GEO SUPERVISOR
            foreach (var geo in empReporter)
            {
                var dept = result.Where(d => d.id == geo.DEPTCODEFUN).FirstOrDefault();
                if (dept == null) continue;
                //DANH DAU KO HIEN THI
                dept.display = false;
                var list = result.Where(d => d.pid == dept.id);
                //TAO MOT NODE SUPERVISOR.
                JObject group = new JObject();

                //CAP NHAT LAI PID TRO VAO GEO SUPERVISOR
                foreach (var g in list)
                {
                    g.pid = geo.SYS_EMPID;
                }
                group["id"] = geo.SYS_EMPID;
                var efunc = result.Where(d => d.pid == dept.pid && d.display == false).FirstOrDefault();
                if (efunc != null)
                {
                    var el = empReporter.Where(em => em.DEPTCODEFUN == dept.pid).FirstOrDefault();
                    if (el != null)
                        group["pid"] = el.SYS_EMPID;
                    else
                        group["pid"] = dept.pid;
                }
                group["tags"] = "[" + "'A" + geo.DEPTCODEFUN + "']";
                group["EMPNAME"] = geo.EMPNAME;
                group["EMPID"] = geo.EMPID;
                group["EMAIL"] = geo.EMAIL;
                group["POSITION"] = geo.POSITION;
                group["IMAGE"] = geo.IMAGE;
                nodeElements.Add(group);
            }
            #endregion

            //KIEM TRA ROOT CO GEO FUNCTIONER.
            if (funccode != "-1")
            {
                ElementViewModel e = result.Where(d => d.id == funccode && d.display == true).FirstOrDefault();
                if (e != null)
                {
                    JObject rgroup = new JObject();
                    rgroup["id"] = e.id;
                    rgroup["pid"] = e.pid;
                    rgroup["tags"] = "[" + "'empty','A" + funccode + "']";
                    rgroup["EMPNAME"] = "";
                    rgroup["EMPID"] = "";
                    rgroup["EMAIL"] = "";
                    rgroup["POSITION"] = "";
                    rgroup["IMAGE"] = "";
                    nodeElements.Add(rgroup);
                }
            }

            foreach (var d in functs)
            {
                ElementViewModel node = result.Where(dp => dp.id == d.FUNCCODE && dp.display == true).FirstOrDefault();
                if (node != null)
                {
                    JObject group = new JObject();
                    group["id"] = node.id;
                    group["pid"] = node.pid;
                    group["tags"] = "[" + "'empty','A" + d.FUNCCODE + "']";
                    group["EMPNAME"] = "";
                    group["EMPID"] = "";
                    group["EMAIL"] = "";
                    group["POSITION"] = "";
                    group["IMAGE"] = "";
                    nodeElements.Add(group);
                }
            }
            #endregion

            KeyValuePair<JObject, List<JObject>> data = new KeyValuePair<JObject, List<JObject>>(groupElements, nodeElements);
            return data;
        }
        public static List<DeptViewModel> getActivedDepts()
        {
            List<DeptViewModel> dtDept = new List<DeptViewModel>();
            DeptAccess access = new DeptAccess();
            DataTable dtResult = access.GetActivedDepartments();
            foreach (DataRow dtr in dtResult.Rows)
            {
                DeptViewModel item = new DeptViewModel
                {
                    DEPTCODE = dtr["DEPTCODE"].ToString(),
                    DEPTNAME = dtr["DEPTNAME"].ToString(),
                    DEPTPARENT = dtr["DEPTPARENT"].ToString(),
                    DEPTLEVEL = dtr["DEPTLEVEL"].ToString(),
                    ORDERINDEX = dtr["ORDERINDEX"].ToString(),
                    ISACTIVE = dtr["ISACTIVE"].ToString(),
                    REMARK = dtr["REMARK"].ToString(),
                    DEPTCODEOLD = dtr["DEPTCODEOLD"].ToString(),
                    COMPCODE = dtr["COMPCODE"].ToString(),
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    CREATE_DT = dtr["CREATE_DT"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                    UPDATE_DT = dtr["UPDATE_DT"].ToString()
                };
                dtDept.Add(item);
            }
            return dtDept;
        }
        public static string getNewDeptCode(string deptCode)
        {
            DeptAccess access = new DeptAccess();
            DataTable result = access.GetNewDeptCode(deptCode);
            if (result.Columns.Contains("'ERROR'"))
            {
                if (result.Rows[0].ItemArray[1].ToString() == "Not exist T_HR_DEPT")
                    return "-1";
            }
            return result.Rows[0]["NEWDEPTCODE"].ToString();
        }
        public static void insertGeoOrganization(DeptViewModel deptViewModel)
        {
            DeptAccess access = new DeptAccess();
            access.InsertDepartments(deptViewModel);
        }
        public static void UpdateGeoOrganization(DeptViewModel deptViewModel)
        {
            DeptAccess access = new DeptAccess();
            access.UpdateDepartments(deptViewModel);
        }
        public static List<DeptViewModel> getDepts()
        {
            var data = getActivedDepts();     
            return data;
        }
        public static List<DeptViewModel> getDepts(int? deptCode)
        {
            var data = getActivedDepts();
            List<DeptViewModel> deptList = new List<DeptViewModel>();
            var result = data;
            if (deptCode != null)
                result = data.Where(p => p.DEPTCODE == deptCode.ToString()).ToList();
            else
                result = data.Where(p => p.DEPTPARENT == null || p.DEPTPARENT == string.Empty).ToList();
            foreach (DeptViewModel org in result)
            {
                deptList.Add(Recursive(org, data));
            }
            return deptList;
        }        
        public static DeptViewModel Recursive(DeptViewModel dept, List<DeptViewModel> deptList)
        {

            if (deptList.Where(c => c.DEPTPARENT == dept.DEPTCODE).Count() < 1)
            {
                return dept;
            }
            else
            {
                List<DeptViewModel> newList = new List<DeptViewModel>();
                foreach (DeptViewModel ca in deptList.Where(c => c.DEPTPARENT == dept.DEPTCODE))
                {
                    newList.Add(Recursive(ca, deptList));
                }
                dept.DeptViewModels = newList;
                return dept;
            }
        }
    }
}