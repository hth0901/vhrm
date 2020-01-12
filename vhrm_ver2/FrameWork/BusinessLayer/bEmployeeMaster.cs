//using KSN.Framework.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.Entity;
using vhrm.ViewModels;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bEmployeeMaster
    {
        public static List<EmployeeMaster> getAllEmployees()
        {
            List<EmployeeMaster> dtEmployees = new List<EmployeeMaster>();
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable dtResult = access.GetEmployees();
            foreach (DataRow dtr in dtResult.Rows)
            {
                string a = dtr["BIRTHDATE"].ToString().Trim();
                //a = "20191003";
                string b = dtr["DATEJOIN"].ToString().Trim();
                //b = "20150201";
                DateTime aa;
                DateTime bb;
                if (a == "00000000" || string.IsNullOrEmpty(a))
                {
                    aa = DateTime.Now;
                }
                else
                {
                    if (a.Substring(0, 4) == "0000" || a.Substring(4, 2) == "00" || a.Substring(6, 2) == "00")
                    {
                        aa = DateTime.Now;
                    }
                    else
                        try
                        {
                            aa = DateTime.ParseExact(a, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            aa = DateTime.Now;
                        }

                }
                if (b == "00000000" || string.IsNullOrEmpty(b))
                {
                    bb = DateTime.Now;
                }
                else
                {
                    if (b.Substring(0, 4) == "0000" || b.Substring(4, 2) == "00" || b.Substring(6, 2) == "00")
                    {
                        bb = DateTime.Now;
                    }
                    else
                        try
                        {
                            bb = DateTime.ParseExact(b, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            bb = DateTime.Now;
                        }

                }
                string imgPath = dtr["IMAGE"].ToString();
                if (string.IsNullOrEmpty(imgPath))
                {
                    imgPath = "/FileServer/Photos/default.jpg";
                }
                else if (!IsFileExists(imgPath))
                {
                    imgPath = "/FileServer/Photos/default.jpg";
                }
                EmployeeMaster item = new EmployeeMaster
                {
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    EMPID = dtr["EMPID"].ToString(),
                    EMPNAME = dtr["EMPNAME"].ToString(),
                    COMPCODE = dtr["COMPCODE"].ToString(),
                    DEPTCODE = dtr["DEPTCODE"].ToString(),
                    FUNCDEPT = dtr["FUNCDEPT"].ToString(),
                    JOBCODE = dtr["JOBCODE"].ToString(),
                    JOBFIELD = dtr["JOBFIELD"].ToString(),
                    DUTY = dtr["DUTY"].ToString(),
                    BIRTHDATE = aa,//DateTime.ParseExact(dtr["BIRTHDATE"].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture),//DateTime.Parse(string.IsNullOrEmpty(dtr["BIRTHDATE"].ToString()) ? "1-1-1999" : dtr["BIRTHDATE"].ToString()),
                    BIRTHPLACE = dtr["BIRTHPLACE"].ToString(),
                    GENDER = dtr["GENDER"].ToString(),
                    STATUS = dtr["STATUS"].ToString(),
                    EMAIL = dtr["EMAIL"].ToString(),
                    PHONE = dtr["PHONE"].ToString(),
                    NATIONALITY = dtr["NATIONALITY"].ToString(),
                    DATEJOIN = bb,//DateTime.ParseExact(dtr["DATEJOIN"].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture),
                    //DATEJOIN = DateTime.Parse(string.IsNullOrEmpty(dtr["DATEJOIN"].ToString()) ? "1-1-1999" : dtr["DATEJOIN"].ToString()),
                    IDENTITYCARD = dtr["UID_FOR_MES"].ToString(),
                    IDISSUEDPLACE = dtr["IDISSUEDPLACE"].ToString(),
                    IDISSUEDDATE = dtr["IDISSUEDDATE"].ToString(),
                    ACADEMIC = dtr["ACADEMIC"].ToString(),
                    DATERESIGNED = dtr["DATERESIGNED"].ToString(),
                    FINGERPRINT = dtr["FINGERPRINT"].ToString(),
                    FINGERINDEX = dtr["FINGERINDEX"].ToString(),
                    IMAGE = imgPath,
                    POSITION = dtr["POSITION"].ToString(),
                    SKILL = dtr["SKILL"].ToString(),
                    SYS_EMPIDOLD = dtr["SYS_EMPIDOLD"].ToString(),
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    CREATE_DT = dtr["CREATE_DT"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                    UPDATE_DT = dtr["UPDATE_DT"].ToString(),
                };
                dtEmployees.Add(item);
            }
            return dtEmployees;
        }
        public static List<CategoryValueEntity> getCategories()
        {
            List<CategoryValueEntity> categoryValues = new List<CategoryValueEntity>();
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable dtResult = access.getCategories();
            foreach (DataRow dtr in dtResult.Rows)
            {
                CategoryValueEntity item = new CategoryValueEntity
                {
                    CategoryId = int.Parse(dtr["CATEGORY_ID"].ToString()),
                    CategoryValueId = int.Parse(dtr["CAT_VALUE_ID"].ToString()),
                    Code = dtr["CAT_CODE"].ToString(),
                    CategoryValue = dtr["CAT_VALUE"].ToString()
                };
                categoryValues.Add(item);
            }
            return categoryValues;
        }
        public static List<CategoryValueEntity> getPositions()
        {
            List<CategoryValueEntity> categoryValues = new List<CategoryValueEntity>();
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable dtResult = access.getPositions();
            foreach (DataRow dtr in dtResult.Rows)
            {
                CategoryValueEntity item = new CategoryValueEntity
                {
                    CategoryId = int.Parse(dtr["CATEGORY_ID"].ToString()),
                    CategoryValueId = int.Parse(dtr["CAT_VALUE_ID"].ToString()),
                    Code = dtr["CAT_CODE"].ToString(),
                    CategoryValue = dtr["CAT_VALUE"].ToString()
                };
                categoryValues.Add(item);
            }
            return categoryValues;
        }
        public static List<CategoryValueEntity> getSkills()
        {
            List<CategoryValueEntity> categoryValues = new List<CategoryValueEntity>();
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable dtResult = access.getSkills();
            foreach (DataRow dtr in dtResult.Rows)
            {
                CategoryValueEntity item = new CategoryValueEntity
                {
                    CategoryId = int.Parse(dtr["CATEGORY_ID"].ToString()),
                    CategoryValueId = int.Parse(dtr["CAT_VALUE_ID"].ToString()),
                    Code = dtr["CAT_CODE"].ToString(),
                    CategoryValue = dtr["CAT_VALUE"].ToString()
                };
                categoryValues.Add(item);
            }
            return categoryValues;
        }
        public static List<CategoryValueEntity> getAcademicLevels()
        {
            List<CategoryValueEntity> categoryValues = new List<CategoryValueEntity>();
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable dtResult = access.getAcademicLevels();
            foreach (DataRow dtr in dtResult.Rows)
            {
                CategoryValueEntity item = new CategoryValueEntity
                {
                    CategoryId = int.Parse(dtr["CATEGORY_ID"].ToString()),
                    CategoryValueId = int.Parse(dtr["CAT_VALUE_ID"].ToString()),
                    Code = dtr["CAT_CODE"].ToString(),
                    CategoryValue = dtr["CAT_VALUE"].ToString()
                };
                categoryValues.Add(item);
            }
            return categoryValues;
        }
        public static string getSysEmpId()
        {
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable result = access.GetSysEmpID();
            return result.Rows[0].ItemArray[1].ToString();
        }
        public static string getEmpId(string deptCode, DateTime joinDate)
        {
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable result = access.GetEmpID(deptCode, joinDate);
            return result.Rows[0].ItemArray[1].ToString();
        }
        public static void insertEmployee(EmployeeMaster employeeMaster)
        {
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            access.InsertEmployee(employeeMaster);
        }
        public static void UpdateEmployee(EmployeeMaster employeeMaster)
        {
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            access.UpdateEmployee(employeeMaster);
        }
        public static EmployeeMaster getEmployeeBySysEmpid(string sysEmpid)
        {
            List<EmployeeMaster> dtEmployees = new List<EmployeeMaster>();
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable dtResult = access.GetEmployeeBySysEmpID(sysEmpid);
            foreach (DataRow dtr in dtResult.Rows)
            {
                string a = dtr["BIRTHDATE"].ToString().Trim();
                //a = "20191003";
                string b = dtr["DATEJOIN"].ToString().Trim();
                //b = "20150201";
                DateTime aa;
                DateTime bb;
                if (a == "00000000" || string.IsNullOrEmpty(a))
                {
                    aa = DateTime.Now;
                }
                else
                {
                    if (a.Substring(0, 4) == "0000" || a.Substring(4, 2) == "00" || a.Substring(6, 2) == "00")
                    {
                        aa = DateTime.Now;
                    }
                    else
                        try
                        {
                            aa = DateTime.ParseExact(a, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            aa = DateTime.Now;
                        }

                }
                if (b == "00000000" || string.IsNullOrEmpty(b))
                {
                    bb = DateTime.Now;
                }
                else
                {
                    if (b.Substring(0, 4) == "0000" || b.Substring(4, 2) == "00" || b.Substring(6, 2) == "00")
                    {
                        bb = DateTime.Now;
                    }
                    else
                        try
                        {
                            bb = DateTime.ParseExact(b, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            bb = DateTime.Now;
                        }

                }
                string imgPath = dtr["IMAGE"].ToString();
                if (string.IsNullOrEmpty(imgPath))
                {
                    imgPath = "/FileServer/Photos/default.jpg";
                }
                else if (!IsFileExists(imgPath))
                {
                    imgPath = "/FileServer/Photos/default.jpg";
                }
                EmployeeMaster item = new EmployeeMaster
                {
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    EMPID = dtr["EMPID"].ToString(),
                    EMPNAME = dtr["EMPNAME"].ToString(),
                    COMPCODE = dtr["COMPCODE"].ToString(),
                    DEPTCODE = dtr["DEPTCODE"].ToString(),
                    FUNCDEPT = dtr["FUNCDEPT"].ToString(),
                    JOBCODE = dtr["JOBCODE"].ToString(),
                    JOBFIELD = dtr["JOBFIELD"].ToString(),
                    DUTY = dtr["DUTY"].ToString(),
                    DEPTNAME = dtr["DEPTNAME"].ToString(),
                    FUNCNAME = dtr["FUNCNAME"].ToString(),
                    BIRTHDATE = aa,//DateTime.ParseExact(dtr["BIRTHDATE"].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture),
                    BIRTHPLACE = dtr["BIRTHPLACE"].ToString(),
                    GENDER = dtr["GENDER"].ToString(),
                    STATUS = dtr["STATUS"].ToString(),
                    EMAIL = dtr["EMAIL"].ToString(),
                    PHONE = dtr["PHONE"].ToString(),
                    NATIONALITY = dtr["NATIONALITY"].ToString(),
                    DATEJOIN = bb,//DateTime.ParseExact(dtr["DATEJOIN"].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture),
                    IDENTITYCARD = dtr["UID_FOR_MES"].ToString(),
                    IDISSUEDPLACE = dtr["IDISSUEDPLACE"].ToString(),
                    IDISSUEDDATE = dtr["IDISSUEDDATE"].ToString(),
                    ACADEMIC = dtr["ACADEMIC"].ToString(),
                    DATERESIGNED = dtr["DATERESIGNED"].ToString(),
                    FINGERPRINT = dtr["FINGERPRINT"].ToString(),
                    FINGERINDEX = dtr["FINGERINDEX"].ToString(),
                    IMAGE = imgPath,
                    POSITION = dtr["POSITION"].ToString(),
                    SKILL = dtr["SKILL"].ToString(),
                    SYS_EMPIDOLD = dtr["SYS_EMPIDOLD"].ToString(),
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    CREATE_DT = dtr["CREATE_DT"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                    UPDATE_DT = dtr["UPDATE_DT"].ToString(),
                };
                dtEmployees.Add(item);
            }
            if (dtEmployees.Count > 0)
                return dtEmployees[0];
            else return null;
        }
    
        public static EmployeeMaster getEmployeeByEmpId(string empId)
        {
            List<EmployeeMaster> dtEmployees = new List<EmployeeMaster>();
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable dtResult = access.GetEmployeeByEmpID(empId);
            foreach (DataRow dtr in dtResult.Rows)
            {
                string a = dtr["BIRTHDATE"].ToString().Trim();
                //a = "20191003";
                string b = dtr["DATEJOIN"].ToString().Trim();
                //b = "20150201";
                DateTime aa;
                DateTime bb;
                if (a == "00000000" || string.IsNullOrEmpty(a))
                {
                    aa = DateTime.Now;
                }
                else
                {
                    if (a.Substring(0, 4) == "0000" || a.Substring(4, 2) == "00" || a.Substring(6, 2) == "00")
                    {
                        aa = DateTime.Now;
                    }
                    else
                        try
                        {
                            aa = DateTime.ParseExact(a, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            aa = DateTime.Now;
                        }

                }
                if (b == "00000000" || string.IsNullOrEmpty(b))
                {
                    bb = DateTime.Now;
                }
                else
                {
                    if (b.Substring(0, 4) == "0000" || b.Substring(4, 2) == "00" || b.Substring(6, 2) == "00")
                    {
                        bb = DateTime.Now;
                    }
                    else
                        try
                        {
                            bb = DateTime.ParseExact(b, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            bb = DateTime.Now;
                        }

                }
                string imgPath = dtr["IMAGE"].ToString();
                if (string.IsNullOrEmpty(imgPath))
                {
                    imgPath = "/FileServer/Photos/default.jpg";
                }
                else if (!IsFileExists(imgPath))
                {
                    imgPath = "/FileServer/Photos/default.jpg";
                }
                EmployeeMaster item = new EmployeeMaster
                {
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    EMPID = dtr["EMPID"].ToString(),
                    EMPNAME = dtr["EMPNAME"].ToString(),
                    COMPCODE = dtr["COMPCODE"].ToString(),
                    DEPTCODE = dtr["DEPTCODE"].ToString(),
                    FUNCDEPT = dtr["FUNCDEPT"].ToString(),
                    JOBCODE = dtr["JOBCODE"].ToString(),
                    JOBFIELD = dtr["JOBFIELD"].ToString(),
                    DUTY = dtr["DUTY"].ToString(),
                    BIRTHDATE = aa,//DateTime.ParseExact(dtr["BIRTHDATE"].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture),
                    BIRTHPLACE = dtr["BIRTHPLACE"].ToString(),
                    GENDER = dtr["GENDER"].ToString(),
                    STATUS = dtr["STATUS"].ToString(),
                    EMAIL = dtr["EMAIL"].ToString(),
                    PHONE = dtr["PHONE"].ToString(),
                    NATIONALITY = dtr["NATIONALITY"].ToString(),
                    DATEJOIN = bb,//DateTime.ParseExact(dtr["DATEJOIN"].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture),
                    IDENTITYCARD = dtr["UID_FOR_MES"].ToString(),
                    IDISSUEDPLACE = dtr["IDISSUEDPLACE"].ToString(),
                    IDISSUEDDATE = dtr["IDISSUEDDATE"].ToString(),
                    ACADEMIC = dtr["ACADEMIC"].ToString(),
                    DATERESIGNED = dtr["DATERESIGNED"].ToString(),
                    FINGERPRINT = dtr["FINGERPRINT"].ToString(),
                    FINGERINDEX = dtr["FINGERINDEX"].ToString(),                 
                    IMAGE = imgPath,
                    POSITION = dtr["POSITION"].ToString(),
                    SKILL = dtr["SKILL"].ToString(),
                    SYS_EMPIDOLD = dtr["SYS_EMPIDOLD"].ToString(),
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    CREATE_DT = dtr["CREATE_DT"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                    UPDATE_DT = dtr["UPDATE_DT"].ToString(),
                };
                dtEmployees.Add(item);
            }
            if (dtEmployees.Count() > 0)
            {
                List<DeptViewModel> depts = bDept.getActivedDepts();
                //Process display depcode in employee.
                DeptViewModel deptOfEmployee = depts.Where(d => d.DEPTCODE == dtEmployees[0].DEPTCODE).FirstOrDefault();
                if (deptOfEmployee != null)
                {
                    DeptViewModel iter = deptOfEmployee;
                    List<string> list = new List<string>();
                    while (iter != null)
                    {
                        list.Add(iter.DEPTNAME);
                        iter = depts.Where(d => d.DEPTCODE == iter.DEPTPARENT).FirstOrDefault();
                    }
                    list.Reverse();
                    dtEmployees[0].DISPLAYDEPTCODE = string.Join(" > ", list.ToArray());
                    if (string.IsNullOrEmpty(dtEmployees[0].IMAGE)) dtEmployees[0].IMAGE = "default.jpg";
                }

                //Process informations involve this employee.
                List<EmployeeMasterReport> employeeMasterReport = bEmployeeMasterReport.getEmployeeReportBySysEmpID(dtEmployees[0].SYS_EMPID);
                if(employeeMasterReport.Count > 0)
                {
                    string SYS_EMPIDGEO = employeeMasterReport[0].SYS_EMPIDGEO;
                    string SYS_EMPIDFUN = employeeMasterReport[0].SYS_EMPIDFUN;
                    string DEPTCODEGEO = employeeMasterReport[0].DEPTCODEGEO;
                    string DEPTCODEFUN = employeeMasterReport[0].DEPTCODEFUN;
                    dtEmployees[0].GEODIRECTREPORT = SYS_EMPIDGEO;
                    dtEmployees[0].GEOGRAPHICALORG = DEPTCODEGEO;
                    dtEmployees[0].FUNCTIONALORG = DEPTCODEFUN;
                    dtEmployees[0].FUNCDIRECTREPORT = SYS_EMPIDFUN;                    
                    DeptViewModel dept = depts.Where(d=>d.DEPTCODE == DEPTCODEGEO).FirstOrDefault();
                    if (dept != null)
                    {
                        DeptViewModel iter = dept;
                        List<string> list = new List<string>();
                        while (iter != null)
                        {
                            list.Add(iter.DEPTNAME);
                            iter = depts.Where(d=>d.DEPTCODE == iter.DEPTPARENT).FirstOrDefault();
                        }
                        list.Reverse();
                        dtEmployees[0].DISPLAYGEOGRAPHICALORG = string.Join(" > ", list.ToArray());
                    }
                        
                    List<FunctViewModel> functs = bFunction.getFunctions();
                    FunctViewModel funct = functs.Where(f => f.FUNCCODE == DEPTCODEFUN).FirstOrDefault();
                    if (funct != null)
                    {
                        FunctViewModel iterf = funct;
                        List<string> list = new List<string>();
                        while (iterf != null)
                        {
                            list.Add(iterf.FUNCNAME);
                            iterf = functs.Where(f => f.FUNCCODE == iterf.FUNCPARENT).FirstOrDefault();
                        }
                        list.Reverse();
                        dtEmployees[0].DISPLAYFUNCTIONALORG = string.Join(" > ", list.ToArray());
                    }
                    //Display geo user, funct user.
                    //List<EmployeeMaster> es = getAllEmployees();
                    EmployeeMaster eg = getEmployeeBySysEmpid(SYS_EMPIDGEO);
                    //EmployeeMaster eg = es.Where(ep => ep.SYS_EMPID == SYS_EMPIDGEO).FirstOrDefault();
                    if (eg != null)
                    {
                        dtEmployees[0].DISPLAYGEODIRECTREPORT = eg.EMPNAME;
                        dtEmployees[0].GEOEMPIDREPORT = eg.EMPID;
                    }
                    //EmployeeMaster ef = es.Where(ep => ep.SYS_EMPID == SYS_EMPIDFUN).FirstOrDefault();
                    EmployeeMaster ef = getEmployeeBySysEmpid(SYS_EMPIDFUN);
                    if (ef != null)
                    {
                        dtEmployees[0].DISPLAYFUNCDIRECTREPORT = ef.EMPNAME;
                        dtEmployees[0].FUNEMPIDREPORT = ef.EMPID;
                    }

                }
                return dtEmployees[0];
            }                         
            return null;
        }
        private static bool IsFileExists(string path)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(path)))
                return true;
            return false;
        }
        public static List<EmployeeMaster> getEmployeesByDeptCode()
        {
            return getAllEmployees();
        }

        public static List<EmployeeMaster> getUserByLikeName(string name)
        {
            List<EmployeeMaster> userList = new List<EmployeeMaster>();
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable dtResult = access.GetEmployeeByLikeName(name);
            foreach (DataRow dtr in dtResult.Rows)
            {
                EmployeeMaster item = new EmployeeMaster
                {
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    EMPNAME = dtr["EMPNAME"].ToString(),
                    EMPID = dtr["EMPID"].ToString()
                };
                userList.Add(item);
                
            }
            return userList;
        }
        public static List<EmployeeMaster> getUserByLikeEmpId(string empId)
        {
            List<EmployeeMaster> userList = new List<EmployeeMaster>();
            EmployeeMasterAccess access = new EmployeeMasterAccess();
            DataTable dtResult = access.GetEmployeeByLikeEmpID(empId);
            foreach (DataRow dtr in dtResult.Rows)
            {
                EmployeeMaster item = new EmployeeMaster
                {
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    EMPNAME = dtr["EMPNAME"].ToString(),
                    EMPID = dtr["EMPID"].ToString()
                };
                userList.Add(item);

            }
            return userList;
        }
    }
}