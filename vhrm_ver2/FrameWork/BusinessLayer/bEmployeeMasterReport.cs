using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.Entity;
using vhrm.ViewModels;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bEmployeeMasterReport
    {
        public static List<SupervisorViewModel> GeSupervisors()
        {
            List<SupervisorViewModel> dtEmployees = new List<SupervisorViewModel>();
            EmployeeMasterReportAccess access = new EmployeeMasterReportAccess();
            DataTable dtResult = access.getEmployeeReportToChart();
            foreach (DataRow dtr in dtResult.Rows)
            {
                SupervisorViewModel item = new SupervisorViewModel
                {
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    DEPTCODEGEO = dtr["DEPTCODEGEO"].ToString(),
                    IMAGE = dtr["IMAGE"].ToString(),
                    EMPNAME = dtr["EMPNAME"].ToString()
                };
                dtEmployees.Add(item);
            }
            return dtEmployees;
        }

        public static List<EmployeeMasterReport> GetEmployeeReports()
        {
            List<EmployeeMasterReport> dtEmployees = new List<EmployeeMasterReport>();
            EmployeeMasterReportAccess access = new EmployeeMasterReportAccess();
            DataTable dtResult = access.GetEmployeeReports();
            foreach (DataRow dtr in dtResult.Rows)
            {
                EmployeeMasterReport item = new EmployeeMasterReport
                {
                    REPORTCD = dtr["REPORTCD"].ToString(),
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    DEPTCODEGEO = dtr["DEPTCODEGEO"].ToString(),
                    SYS_EMPIDGEO = dtr["SYS_EMPIDGEO"].ToString(),
                    DEPTCODEFUN = dtr["DEPTCODEFUN"].ToString(),
                    SYS_EMPIDFUN = dtr["SYS_EMPIDFUN"].ToString(),
                    APPLYDATE = dtr["APPLYDATE"].ToString(),
                    ISACTIVE = dtr["ISACTIVE"].ToString(),
                    POSITION = dtr["POSITION"].ToString(),
                    SKILL = dtr["SKILL"].ToString(),
                    REMARK = dtr["REMARK"].ToString(),
                    LEVELGEO = dtr["LEVELGEO"].ToString(),
                    LEVELFUN = dtr["LEVELFUN"].ToString(),
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                };
                dtEmployees.Add(item);
            }
            return dtEmployees;
        }
        public static string getReportCDID()
        {
            EmployeeMasterReportAccess access = new EmployeeMasterReportAccess();
            DataTable result = access.GetReportCDID();
            return result.Rows[0].ItemArray[1].ToString();
        }
        public static void InsertEmployeeReport(EmployeeMasterReport employeeMaster)
        {
            EmployeeMasterReportAccess access = new EmployeeMasterReportAccess();
            access.InsertEmployeeReport(employeeMaster);
        }
        public static void UpdateEmployeeReport(EmployeeMasterReport employeeMaster)
        {
            EmployeeMasterReportAccess access = new EmployeeMasterReportAccess();
            access.UpdateEmployeeReport(employeeMaster);
        }
        //GEO
        public static List<EmployeeDiagramViewModel> getDiagramGEO(EmployeeMaster e)
        {
            if (e == null) return null;
            List<EmployeeMasterReport> employeeMasterReport = bEmployeeMasterReport.getEmployeeReportBySysEmpID(e.SYS_EMPID);
            List<EmployeeMaster> employeeMaster = bEmployeeMaster.getAllEmployees();
            List<EmployeeMasterReport> allEmployeeReport = bEmployeeMasterReport.GetEmployeeReports();
            List<EmployeeMasterReport> result = new List<EmployeeMasterReport>();

            EmployeeMasterReport iterate = new EmployeeMasterReport();
            iterate.SYS_EMPID = e.SYS_EMPID;
            iterate.SYS_EMPIDFUN = e.FUNCDIRECTREPORT;
            iterate.SYS_EMPIDGEO = e.GEODIRECTREPORT;
            while (iterate != null)
            {
                if (result.Where(i => i.SYS_EMPID == iterate.SYS_EMPID).FirstOrDefault() == null)
                    result.Add(iterate);
                iterate = allEmployeeReport.Where(erp => erp.SYS_EMPID == iterate.SYS_EMPIDGEO).FirstOrDefault();
            }
            result.Reverse();
            if (result.Count == 0) return null;
            List<EmployeeDiagramViewModel> data = new List<EmployeeDiagramViewModel>();
            if (result.Count == 1)
            {
                if (!string.IsNullOrEmpty(e.GEODIRECTREPORT))
                {
                    EmployeeDiagramViewModel parent = new EmployeeDiagramViewModel();
                    EmployeeMaster eOldParent = employeeMaster.Where(emp => emp.SYS_EMPID == e.GEODIRECTREPORT).FirstOrDefault();
                    parent.EMPNAME = eOldParent.EMPNAME;
                    parent.EMPID = eOldParent.EMPID;
                    parent.SYS_EMPID = eOldParent.SYS_EMPID;
                    parent.SYS_EMPIDGEO = e.GEODIRECTREPORT;
                    parent.SYS_EMPIDFUN = e.FUNCDIRECTREPORT;
                    if (string.IsNullOrEmpty(eOldParent.IMAGE))
                        parent.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                    else
                        parent.Image = eOldParent.IMAGE + "?" + (new Random()).Next(0, 100);
                    parent.ColorScheme = "#1696d3";
                    EmployeeDiagramViewModel current = new EmployeeDiagramViewModel();
                    EmployeeMaster eCurrent = employeeMaster.Where(emp => emp.SYS_EMPID.Trim() == result[0].SYS_EMPID.Trim()).FirstOrDefault();
                    if (eCurrent != null)
                    {
                        current.EMPNAME = eCurrent.EMPNAME;
                        current.EMPID = eCurrent.EMPID;
                        current.SYS_EMPID = eCurrent.SYS_EMPID;
                        current.SYS_EMPIDGEO = e.GEODIRECTREPORT;
                        current.SYS_EMPIDFUN = e.FUNCDIRECTREPORT;
                        if (string.IsNullOrEmpty(eCurrent.IMAGE))
                            current.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                        else
                            current.Image = eCurrent.IMAGE + "?" + (new Random()).Next(0, 100);
                        current.ColorScheme = "#ee587b";
                        parent.Items = new List<EmployeeDiagramViewModel>();
                        parent.Items.Add(current);
                    }                    
                    data.Add(parent);
                    return data;
                }
                else
                {
                    EmployeeDiagramViewModel current = new EmployeeDiagramViewModel();
                    EmployeeMaster eCurrent = employeeMaster.Where(emp => emp.SYS_EMPID == result[0].SYS_EMPID).FirstOrDefault();
                    current.EMPNAME = eCurrent.EMPNAME;
                    current.EMPID = eCurrent.EMPID;
                    current.SYS_EMPID = eCurrent.SYS_EMPID;
                    current.SYS_EMPIDGEO = e.GEODIRECTREPORT;
                    current.SYS_EMPIDFUN = e.FUNCDIRECTREPORT;
                    if (string.IsNullOrEmpty(eCurrent.IMAGE))
                        current.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                    else
                        current.Image = eCurrent.IMAGE + "?" + (new Random()).Next(0, 100);
                    current.ColorScheme = "#ee587b";
                    data.Add(current);
                    return data;
                }
            }
            else
            {
                EmployeeDiagramViewModel parent = new EmployeeDiagramViewModel();
                EmployeeMaster eOldParent = employeeMaster.Where(emp => emp.SYS_EMPID == result[0].SYS_EMPID).FirstOrDefault();
                parent.EMPNAME = eOldParent.EMPNAME;
                parent.EMPID = eOldParent.EMPID;
                parent.SYS_EMPID = eOldParent.SYS_EMPID;
                parent.SYS_EMPIDGEO = result[0].SYS_EMPIDGEO;
                parent.SYS_EMPIDFUN = result[0].SYS_EMPIDFUN;
                if (string.IsNullOrEmpty(eOldParent.IMAGE))
                    parent.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                else
                    parent.Image = eOldParent.IMAGE + "?" + (new Random()).Next(0, 100);
                parent.ColorScheme = "#1696d3";
                EmployeeDiagramViewModel firtChild = RecursiveGEO(parent, e.SYS_EMPID, result);
                EmployeeDiagramViewModel child = null;
                if (firtChild != null && !string.IsNullOrEmpty(firtChild.SYS_EMPIDGEO))
                {
                    child = new EmployeeDiagramViewModel();
                    EmployeeMaster echild = employeeMaster.Where(emp => emp.SYS_EMPID == firtChild.SYS_EMPIDGEO).FirstOrDefault();
                    child.EMPNAME = echild.EMPNAME;
                    child.EMPID = echild.EMPID;
                    child.SYS_EMPID = echild.SYS_EMPID;
                    //child.SYS_EMPIDGEO = ca.SYS_EMPIDGEO;
                    //child.SYS_EMPIDFUN = ca.SYS_EMPIDFUN;
                    if (string.IsNullOrEmpty(echild.IMAGE))
                        child.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                    else
                        child.Image = echild.IMAGE + "?" + (new Random()).Next(0, 100);
                    child.ColorScheme = "#1696d3";
                    child.Items = new List<EmployeeDiagramViewModel>();
                    child.Items.Add(firtChild);
                    //node.Items = new List<EmployeeDiagramViewModel>();
                    //node.Items.Add(child);
                }
                if (child != null)
                {
                    data.Add(child);
                }
                else
                    data.Add(firtChild);
            }
            return data;
        }
        public static EmployeeDiagramViewModel RecursiveGEO(EmployeeDiagramViewModel node, string SYS_EMPID, List<EmployeeMasterReport> list)
        {
            if (list.Where(c => c.SYS_EMPIDGEO == node.SYS_EMPID).Count() < 1)
            {
                return node;
            }
            else
            {
                List<EmployeeDiagramViewModel> newList = new List<EmployeeDiagramViewModel>();
                List<EmployeeMaster> employeeMaster = bEmployeeMaster.getAllEmployees();
                foreach (EmployeeMasterReport ca in list.Where(c => c.SYS_EMPIDGEO == node.SYS_EMPID))
                {
                    EmployeeDiagramViewModel child = new EmployeeDiagramViewModel();
                    EmployeeMaster echild = employeeMaster.Where(emp => emp.SYS_EMPID == ca.SYS_EMPID).FirstOrDefault();
                    child.EMPNAME = echild.EMPNAME;
                    child.EMPID = echild.EMPID;
                    child.SYS_EMPID = echild.SYS_EMPID;
                    child.SYS_EMPIDGEO = ca.SYS_EMPIDGEO;
                    child.SYS_EMPIDFUN = ca.SYS_EMPIDFUN;
                    if (string.IsNullOrEmpty(echild.IMAGE))
                        child.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                    else
                        child.Image = echild.IMAGE + "?" + (new Random()).Next(0, 100);
                    if (SYS_EMPID == child.SYS_EMPID)
                        child.ColorScheme = "#ee587b";
                    else
                        child.ColorScheme = "#1696d3";
                    EmployeeDiagramViewModel org = RecursiveGEO(child, SYS_EMPID, list);
                    if (org != null)
                    {
                        newList.Add(org);
                    }
                }
                node.Items = newList;
                return node;
            }
        }
        //END GEO
        //Version 2.0
        public static List<EmployeeDiagramViewModel> getDiagram(EmployeeMaster e)
        {
            if (e == null) return null;
            List<EmployeeMasterReport> employeeMasterReport = bEmployeeMasterReport.getEmployeeReportBySysEmpID(e.SYS_EMPID);
            List<EmployeeMaster> employeeMaster = bEmployeeMaster.getAllEmployees();
            List<EmployeeMasterReport> allEmployeeReport = bEmployeeMasterReport.GetEmployeeReports();
            List<EmployeeMasterReport> result = new List<EmployeeMasterReport>();

            EmployeeMasterReport iterate = new EmployeeMasterReport();
            iterate.SYS_EMPID = e.SYS_EMPID;
            iterate.SYS_EMPIDFUN = e.FUNCDIRECTREPORT;
            iterate.SYS_EMPIDGEO = e.GEODIRECTREPORT;
            while (iterate != null)
            {
                if (result.Where(i => i.SYS_EMPID == iterate.SYS_EMPID).FirstOrDefault() == null)
                    result.Add(iterate);
                iterate = allEmployeeReport.Where(erp => erp.SYS_EMPID == iterate.SYS_EMPIDFUN).FirstOrDefault();
            }
            result.Reverse();
            if (result.Count == 0) return null;
            List<EmployeeDiagramViewModel> data = new List<EmployeeDiagramViewModel>();
            if (result.Count == 1)
            {
                if (!string.IsNullOrEmpty(e.FUNCDIRECTREPORT))
                {
                    EmployeeDiagramViewModel parent = new EmployeeDiagramViewModel();
                    EmployeeMaster eOldParent = employeeMaster.Where(emp => emp.SYS_EMPID == e.FUNCDIRECTREPORT).FirstOrDefault();
                    parent.EMPNAME = eOldParent.EMPNAME;
                    parent.EMPID = eOldParent.EMPID;
                    parent.SYS_EMPID = eOldParent.SYS_EMPID;
                    parent.SYS_EMPIDGEO = e.GEODIRECTREPORT;
                    parent.SYS_EMPIDFUN = e.FUNCDIRECTREPORT;
                    if (string.IsNullOrEmpty(eOldParent.IMAGE))
                        parent.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                    else
                        parent.Image = eOldParent.IMAGE + "?" + (new Random()).Next(0, 100);
                    parent.ColorScheme = "#1696d3";
                    EmployeeDiagramViewModel current = new EmployeeDiagramViewModel();
                    EmployeeMaster eCurrent = employeeMaster.Where(emp => emp.SYS_EMPID == result[0].SYS_EMPID).FirstOrDefault();
                    current.EMPNAME = eCurrent.EMPNAME;
                    current.EMPID = eCurrent.EMPID;
                    current.SYS_EMPID = eCurrent.SYS_EMPID;
                    current.SYS_EMPIDGEO = e.GEODIRECTREPORT;
                    current.SYS_EMPIDFUN = e.FUNCDIRECTREPORT;
                    if (string.IsNullOrEmpty(eCurrent.IMAGE))
                        current.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                    else
                        current.Image = eCurrent.IMAGE + "?" + (new Random()).Next(0, 100);
                    current.ColorScheme = "#ee587b";
                    parent.Items = new List<EmployeeDiagramViewModel>();
                    parent.Items.Add(current);
                    data.Add(parent);
                    return data;
                }
                else
                {
                    EmployeeDiagramViewModel current = new EmployeeDiagramViewModel();
                    EmployeeMaster eCurrent = employeeMaster.Where(emp => emp.SYS_EMPID == result[0].SYS_EMPID).FirstOrDefault();
                    if (eCurrent != null)
                    {
                        current.EMPNAME = eCurrent.EMPNAME;
                        current.EMPID = eCurrent.EMPID;
                        current.SYS_EMPID = eCurrent.SYS_EMPID;
                        current.SYS_EMPIDGEO = e.GEODIRECTREPORT;
                        current.SYS_EMPIDFUN = e.FUNCDIRECTREPORT;
                        if (string.IsNullOrEmpty(eCurrent.IMAGE))
                            current.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                        else
                            current.Image = eCurrent.IMAGE + "?" + (new Random()).Next(0, 100);
                        current.ColorScheme = "#ee587b";
                        data.Add(current);
                    }                    
                    return data;
                }  
            }
            else
            {
                EmployeeDiagramViewModel parent = new EmployeeDiagramViewModel();
                EmployeeMaster eOldParent = employeeMaster.Where(emp => emp.SYS_EMPID == result[0].SYS_EMPID).FirstOrDefault();
                parent.EMPNAME = eOldParent.EMPNAME;
                parent.EMPID = eOldParent.EMPID;
                parent.SYS_EMPID = eOldParent.SYS_EMPID;
                parent.SYS_EMPIDGEO = result[0].SYS_EMPIDGEO;
                parent.SYS_EMPIDFUN = result[0].SYS_EMPIDFUN;
                if (string.IsNullOrEmpty(eOldParent.IMAGE))
                    parent.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                else
                    parent.Image = eOldParent.IMAGE + "?" + (new Random()).Next(0, 100);
                parent.ColorScheme = "#1696d3";
                EmployeeDiagramViewModel firtChild = Recursive(parent, e.SYS_EMPID, result);
                EmployeeDiagramViewModel child = null;
                if (firtChild != null && !string.IsNullOrEmpty(firtChild.SYS_EMPIDFUN))
                {
                    child = new EmployeeDiagramViewModel();
                    EmployeeMaster echild = employeeMaster.Where(emp => emp.SYS_EMPID == firtChild.SYS_EMPIDFUN).FirstOrDefault();
                    child.EMPNAME = echild.EMPNAME;
                    child.EMPID = echild.EMPID;
                    child.SYS_EMPID = echild.SYS_EMPID;
                    //child.SYS_EMPIDGEO = ca.SYS_EMPIDGEO;
                    //child.SYS_EMPIDFUN = ca.SYS_EMPIDFUN;
                    if (string.IsNullOrEmpty(echild.IMAGE))
                        child.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                    else
                        child.Image = echild.IMAGE + "?" + (new Random()).Next(0, 100);
                    child.ColorScheme = "#1696d3";
                    child.Items = new List<EmployeeDiagramViewModel>();
                    child.Items.Add(firtChild);
                    //node.Items = new List<EmployeeDiagramViewModel>();
                    //node.Items.Add(child);
                }
                if (child != null)
                {
                    data.Add(child);
                }
                else
                    data.Add(firtChild);
            }           
            return data;
        }
        public static EmployeeDiagramViewModel Recursive(EmployeeDiagramViewModel node,string SYS_EMPID, List<EmployeeMasterReport> list)
        {
            if (list.Where(c => c.SYS_EMPIDFUN == node.SYS_EMPID).Count() < 1)
            {                
                return node;
            }
            else
            {
                List<EmployeeDiagramViewModel> newList = new List<EmployeeDiagramViewModel>();
                List<EmployeeMaster> employeeMaster = bEmployeeMaster.getAllEmployees();
                foreach (EmployeeMasterReport ca in list.Where(c => c.SYS_EMPIDFUN == node.SYS_EMPID))
                {
                    EmployeeDiagramViewModel child = new EmployeeDiagramViewModel();
                    EmployeeMaster echild = employeeMaster.Where(emp => emp.SYS_EMPID == ca.SYS_EMPID).FirstOrDefault();
                    child.EMPNAME = echild.EMPNAME;
                    child.EMPID = echild.EMPID;
                    child.SYS_EMPID = echild.SYS_EMPID;
                    child.SYS_EMPIDGEO = ca.SYS_EMPIDGEO;
                    child.SYS_EMPIDFUN = ca.SYS_EMPIDFUN;
                    if (string.IsNullOrEmpty(echild.IMAGE))
                        child.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                    else
                        child.Image = echild.IMAGE + "?" + (new Random()).Next(0, 100);
                    if(SYS_EMPID == child.SYS_EMPID)
                        child.ColorScheme = "#ee587b";
                    else
                        child.ColorScheme = "#1696d3";
                    EmployeeDiagramViewModel org = Recursive(child, SYS_EMPID, list);
                    if (org != null)
                    {
                        newList.Add(org);
                    }
                }
                node.Items = newList;
                return node;
            }
        }
    
    //Version 1.0
    /*public static List<EmployeeDiagramViewModel> getDiagram(EmployeeMaster e)
    {
        if (e == null) return null;
        List<EmployeeMasterReport> employeeMasterReport = bEmployeeMasterReport.getEmployeeReportBySysEmpID(e.SYS_EMPID);
        List<EmployeeMaster> employeeMaster = bEmployeeMaster.getAllEmployees();
        EmployeeMaster fOfEmployee = employeeMaster.Where(em=>em.SYS_EMPID == e.FUNCDIRECTREPORT).FirstOrDefault();
        if (fOfEmployee == null) return null;
        List<EmployeeDiagramViewModel> data = new List<EmployeeDiagramViewModel>();
        EmployeeDiagramViewModel root = new EmployeeDiagramViewModel();
        EmployeeDiagramViewModel current = new EmployeeDiagramViewModel();
        root.EMPNAME = fOfEmployee.EMPNAME;
        root.EMPID = fOfEmployee.EMPID;
        root.SYS_EMPID = fOfEmployee.SYS_EMPID;
        if (string.IsNullOrEmpty(fOfEmployee.IMAGE))
            root.Image = "default.jpg" + "?" + (new Random()).Next(0,100);
        else
            root.Image = fOfEmployee.IMAGE + "?" + (new Random()).Next(0, 100);
        //root.Image = fOfEmployee.IMAGE;
        root.ColorScheme = "#1696d3";
        current.EMPNAME = e.EMPNAME;
        current.EMPID = e.EMPID;
        current.SYS_EMPID = e.SYS_EMPID;
        if (string.IsNullOrEmpty(e.IMAGE))
            current.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
        else
            current.Image = e.IMAGE + "?" + (new Random()).Next(0, 100);
        current.ColorScheme = "#ee587b";
        root.Items = new List<EmployeeDiagramViewModel>();           
        List<EmployeeMasterReport> allEmployeeReport = bEmployeeMasterReport.GetEmployeeReports();
        var allEmReportFunctions = allEmployeeReport.Where(em => em.SYS_EMPIDFUN == e.SYS_EMPID);
        if (allEmReportFunctions.Count() > 0)
        {
            current.Items = new List<EmployeeDiagramViewModel>();
            foreach (var em in allEmReportFunctions)
            {
                EmployeeDiagramViewModel child = new EmployeeDiagramViewModel();
                EmployeeMaster employee = employeeMaster.Where(emp => emp.SYS_EMPID == em.SYS_EMPID).FirstOrDefault();
                child.EMPNAME = employee.EMPNAME;
                child.EMPID = employee.EMPID;
                child.SYS_EMPID = employee.SYS_EMPID;
                if (string.IsNullOrEmpty(employee.IMAGE))
                    child.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                else
                    child.Image = employee.IMAGE + "?" + (new Random()).Next(0, 100);
                child.ColorScheme = "#1696d3";
                current.Items.Add(child);
            }
        }
        //The same level.
        var sameLevelEmployeeReport = allEmployeeReport.Where(em => em.SYS_EMPIDFUN == e.FUNCDIRECTREPORT && em.SYS_EMPID != e.SYS_EMPID);
        if (sameLevelEmployeeReport.Count() > 0)
        {
            foreach (var em in sameLevelEmployeeReport)
            {
                EmployeeDiagramViewModel child = new EmployeeDiagramViewModel();
                EmployeeMaster employee = employeeMaster.Where(emp => emp.SYS_EMPID == em.SYS_EMPID).FirstOrDefault();
                child.EMPNAME = employee.EMPNAME;
                child.EMPID = employee.EMPID;
                child.SYS_EMPID = employee.SYS_EMPID;
                if(string.IsNullOrEmpty(employee.IMAGE))
                    child.Image = "default.jpg" + "?" + (new Random()).Next(0, 100);
                else
                    child.Image = employee.IMAGE + "?" + (new Random()).Next(0, 100);
                child.ColorScheme = "#1696d3";
                root.Items.Add(child);
            }
        }
        root.Items.Add(current);
        data.Add(root);            
        return data;
    }*/
    public static List<EmployeeMasterReport> getEmployeeReportBySysEmpID(string sys_empid)
        {
            List<EmployeeMasterReport> dtEmployees = new List<EmployeeMasterReport>();
            EmployeeMasterReportAccess access = new EmployeeMasterReportAccess();
            DataTable dtResult = access.getEmployeeReportBySysEmpID(sys_empid);
            foreach (DataRow dtr in dtResult.Rows)
            {
                EmployeeMasterReport item = new EmployeeMasterReport
                {
                    REPORTCD = dtr["REPORTCD"].ToString(),
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    DEPTCODEGEO = dtr["DEPTCODEGEO"].ToString(),
                    SYS_EMPIDGEO = dtr["SYS_EMPIDGEO"].ToString(),
                    DEPTCODEFUN = dtr["DEPTCODEFUN"].ToString(),
                    SYS_EMPIDFUN = dtr["SYS_EMPIDFUN"].ToString(),
                    APPLYDATE = dtr["APPLYDATE"].ToString(),
                    ISACTIVE = dtr["ISACTIVE"].ToString(),
                    POSITION = dtr["POSITION"].ToString(),
                    SKILL = dtr["SKILL"].ToString(),
                    REMARK = dtr["REMARK"].ToString(),
                    LEVELGEO = dtr["LEVELGEO"].ToString(),
                    LEVELFUN = dtr["LEVELFUN"].ToString(),
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                };
                dtEmployees.Add(item);
            }
            return dtEmployees;
        }
    }
}