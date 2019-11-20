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
    public class bFunctionReport
    {
        public static List<FunctionReport> getAllGeoReports()
        {
            List<FunctionReport> functionReports = new List<FunctionReport>();
            FunctionReportAccess access = new FunctionReportAccess();
            DataTable dtResult = access.GetFunctionReports();
            foreach (DataRow dtr in dtResult.Rows)
            {
                FunctionReport item = new FunctionReport
                {
                    FUNCPORTCD = dtr["FUNCPORTCD"].ToString(),
                    FUNCCODE = dtr["FUNCCODE"].ToString(),
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    APPLYDATE = DateTime.Parse(string.IsNullOrEmpty(dtr["APPLYDATE"].ToString()) ? "1-1-1999" : dtr["APPLYDATE"].ToString()),
                    ISACTIVE = dtr["ISACTIVE"].ToString(),
                    POSITION = dtr["POSITION"].ToString(),
                    SKILL = dtr["SKILL"].ToString(),
                    REMARK = dtr["REMARK"].ToString(),
                    FUNCTREPORTLEVEL = dtr["FUNCTREPORTLEVEL"].ToString(),
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    CREATE_DT = dtr["CREATE_DT"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                    UPDATE_DT = dtr["UPDATE_DT"].ToString(),
                };
                functionReports.Add(item);
            }
            return functionReports;
        }
        public static List<EmployeeMaster> getUserFunctionReports(string funccode)
        {
            List<EmployeeMaster> functionReports = new List<EmployeeMaster>();
            FunctionReportAccess access = new FunctionReportAccess();
            DataTable dtResult = access.GetUsersFunctionReports(funccode);
            foreach (DataRow dtr in dtResult.Rows)
            {
                EmployeeMaster item = new EmployeeMaster
                {
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    EMPID = dtr["EMPID"].ToString(),
                    EMPNAME = dtr["EMPNAME"].ToString(),
                    POSITION = dtr["POSITION"].ToString(),
                    SKILL = dtr["SKILL"].ToString()
                };
                CategoryValueEntity position = bEmployeeMaster.getPositions().Where(p => p.Code == item.POSITION).FirstOrDefault();
                CategoryValueEntity skill = bEmployeeMaster.getSkills().Where(p => p.Code == item.SKILL).FirstOrDefault();
                if(position != null)
                    item.POSITION = position.CategoryValue;
                if(skill != null)
                    item.SKILL = skill.CategoryValue;
                functionReports.Add(item);
            }
            return functionReports;
        }
        public static List<EmployeeMaster> QueryEmployeeByEmpIdFunctCode(string empId, string functCode)
        {
            List<EmployeeMaster> functReports = getUserFunctionReports(functCode);
            if (string.IsNullOrEmpty(empId))
            {
                var functReportResult = functReports.ToList();
                return functReportResult;
            }
            else
            {
                var functReportResult = functReports.Where(p => p.EMPID.Trim() == empId.Trim()).ToList();
                return functReportResult;
            }          
           
        }
        public static List<EmployeeMaster> getUserInFunctReportByDeptCode(string functCode)
        {
            List<EmployeeMaster> functionReports = new List<EmployeeMaster>();
            FunctionReportAccess access = new FunctionReportAccess();
            DataTable dtResult = access.GetUsersFunctionReports(functCode);
            foreach (DataRow dtr in dtResult.Rows)
            {
                EmployeeMaster item = new EmployeeMaster
                {
                    //FUNCPORTCD = dtr["FUNCPORTCD"].ToString(),
                    EMPID = dtr["EMPID"].ToString(),
                    EMPNAME = dtr["EMPNAME"].ToString() + "," + dtr["SYS_EMPID"].ToString(),
                    SYS_EMPID = dtr["SYS_EMPID"].ToString()
                };
                functionReports.Add(item);
            }
            return functionReports;
        }
        
        public static List<FunctionReportViewModel> getFunctReportsRegistered()
        {
            List<FunctionReportViewModel> functionReports = new List<FunctionReportViewModel>();
            FunctionReportAccess access = new FunctionReportAccess();
            DataTable dtResult = access.getFunctReportsRegistered();
            foreach (DataRow dtr in dtResult.Rows)
            {
                FunctionReportViewModel item = new FunctionReportViewModel
                {
                    FUNCPORTCD = dtr["FUNCPORTCD"].ToString(),
                    FUNCNAME = dtr["FUNCNAME"].ToString(),
                    FUNCCODE = dtr["FUNCCODE"].ToString(),
                    FUNCPARENT = dtr["FUNCPARENT"].ToString()
                };
                functionReports.Add(item);
            }
            return functionReports;
        }
        public static List<FunctionReportViewModel> getTreeFunctionReports()
        {
            List<FunctionReportViewModel> functionReports = new List<FunctionReportViewModel>();
            FunctionReportAccess access = new FunctionReportAccess();
            DataTable dtResult = access.GetTreeFunctionReports();
            foreach (DataRow dtr in dtResult.Rows)
            {
                FunctionReportViewModel item = new FunctionReportViewModel
                {
                    FUNCPORTCD = dtr["FUNCPORTCD"].ToString(),
                    FUNCNAME = dtr["FUNCNAME"].ToString(),
                    FUNCCODE = dtr["FUNCCODE"].ToString(),
                    FUNCPARENT = dtr["FUNCPARENT"].ToString()
                };
                functionReports.Add(item);
            }
            return functionReports;
        }
        public static List<eFunctReportItem> getFunctReportByFunctCode(string functCode)
        {
            List<eFunctReportItem> lstResult = new List<eFunctReportItem>();
            DataTable dtResult = FunctionReportAccess.getFunctReportByFunctCode(functCode);
            foreach (DataRow dtr in dtResult.Rows)
            {
                eFunctReportItem item = new eFunctReportItem();
                item.FUNCREPORTCD = dtr["FUNCPORTCD"].ToString();
                item.FUNCCODE = dtr["FUNCCODE"].ToString();
                item.SYS_EMPID = dtr["SYS_EMPID"].ToString();
                string strDate = dtr["APPLYDATE"].ToString();
                item.APPLYDATE = DateTime.ParseExact(strDate, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                if(dtr["ISACTIVE"].ToString() == "0")
                    item.ISACTIVE = false;
                else
                    item.ISACTIVE = true;
                item.EMPNAME = dtr["EMPNAME"].ToString();
                lstResult.Add(item);
            }

            return lstResult;
        }
        public static List<FunctionReportViewModel> getTreeFunctionReports(int? deptFunction)
        {
            var data = getTreeFunctionReports();
            List<FunctionReportViewModel> functReportList = new List<FunctionReportViewModel>();
            FunctionReportViewModel functReport = data.Where(p => p.FUNCPARENT == null || p.FUNCPARENT == string.Empty).FirstOrDefault();
            FunctionReportViewModel root = Recursive(functReport, data);
            if (root != null)
                functReportList.Add(root);
            return functReportList;
        }
        //Version 2.0 for improving performance.
        public static List<FunctionReportViewModel> getTreeFunctionDepts()
        {
            var functReports = getFunctReportsRegistered();//Lay all GeoReport.
            if(functReports == null || functReports.Count == 0)
                return new List<FunctionReportViewModel>();
            var data = getTreeFunctionReports();

            List<FunctionReportViewModel> result = new List<FunctionReportViewModel>();
            FunctionReportViewModel root = new FunctionReportViewModel();
            foreach (FunctionReportViewModel funct in functReports)
            {
                FunctionReportViewModel functTemp = funct;
                funct.isChild = false;
                while (functTemp != null && functTemp.FUNCPARENT != null && !string.IsNullOrEmpty(functTemp.FUNCPARENT))
                {
                    if (result.Where(r => r.FUNCCODE == functTemp.FUNCCODE).FirstOrDefault() == null)
                    {
                        result.Add(functTemp);
                    }
                    functTemp = data.Where(g => g.FUNCCODE == functTemp.FUNCPARENT).FirstOrDefault();
                    if (functTemp != null)
                    {
                        functTemp.isChild = true;
                        root = functTemp;
                    }
                    
                }
            }
            if (result.Where(r => r.FUNCCODE == root.FUNCCODE).FirstOrDefault() == null)
            {
                result.Add(root);
            }
            List<FunctionReportViewModel> finalResult = new List<FunctionReportViewModel>();
            FunctionReportViewModel functRoot = FunctRecursive(root, result);
            if (functRoot != null)
            {
                finalResult.Add(functRoot);
            }
            return finalResult;
        }
        public static FunctionReportViewModel FunctRecursive(FunctionReportViewModel org, List<FunctionReportViewModel> list)
        {
            var objects = list.Where(c => c.FUNCPARENT == org.FUNCCODE);

            if (objects.Count() < 1)
            {
                return org;
            }
            else
            {
                List<FunctionReportViewModel> newList = new List<FunctionReportViewModel>();
                foreach (FunctionReportViewModel ca in objects)
                {
                    FunctionReportViewModel child = FunctRecursive(ca, list);
                    if (child != null)
                    {
                        if (newList.Where(p => p.FUNCCODE == child.FUNCCODE).FirstOrDefault() == null)
                        {
                            newList.Add(child);
                        }

                    }
                }
                org.FunctionReportViewModels = newList;
                return org;
            }
        }
        //Version 1.0
        public static List<FunctionReportViewModel> getFunctionDeptsRegistered()
        {
            var data = getTreeFunctionReports();
            int count = 0;
            List<FunctionReportViewModel> a = new List<FunctionReportViewModel>();
            a = (from e in data
                 select new FunctionReportViewModel
                 {
                     FUNCPORTCD = e.FUNCPORTCD,
                     FUNCCODE = e.FUNCCODE,
                     FUNCNAME = e.FUNCNAME,
                     FUNCPARENT = e.FUNCPARENT,
                     isChild = data.Where(obj => obj.FUNCPARENT == e.FUNCCODE).FirstOrDefault() != null,
                 }).ToList();
            a.RemoveAll(obj => obj.isChild == false && string.IsNullOrEmpty(obj.FUNCPORTCD));

            while (count < 4)
            {
                a = (from e in a
                     select new FunctionReportViewModel
                     {
                         FUNCPORTCD = e.FUNCPORTCD,
                         FUNCCODE = e.FUNCCODE,
                         FUNCNAME = e.FUNCNAME,
                         FUNCPARENT = e.FUNCPARENT,
                         isChild = a.Where(obj => obj.FUNCPARENT == e.FUNCCODE).FirstOrDefault() != null,
                     }).ToList();
                a.RemoveAll(obj => obj.isChild == false && string.IsNullOrEmpty(obj.FUNCPORTCD));
                count++;
            }
            var result = a.Distinct(new FunctComparer<FunctionReportViewModel>());
            return result.ToList();
        }
        public static FunctionReportViewModel Recursive(FunctionReportViewModel function, List<FunctionReportViewModel> functList)
        {

            if (functList.Where(c => c.FUNCPARENT == function.FUNCCODE).Count() < 1)
            {
                if (string.IsNullOrEmpty(function.FUNCPORTCD))
                    return null;
                return function;
            }
            else
            {
                List<FunctionReportViewModel> newList = new List<FunctionReportViewModel>();
                foreach (FunctionReportViewModel ca in functList.Where(c => c.FUNCPARENT == function.FUNCCODE))
                {
                    FunctionReportViewModel org = Recursive(ca, functList);
                    if (org != null)
                    {
                        if(newList.Where(p =>p.FUNCCODE == org.FUNCCODE).FirstOrDefault() == null)
                            newList.Add(org);
                    }
                        
                }
                function.FunctionReportViewModels = newList;
                return function;
            }
        }

        public static void InsertFunctReport(string functCode, string sysEmpId)
        {
            FunctionReportAccess access = new FunctionReportAccess();
            access.InsertFunctReport(functCode, sysEmpId);
        }
        public static void DeleteFunctReportByFKey(string functCode, string sysEmpId)
        {
            FunctionReportAccess access = new FunctionReportAccess();
            access.DeleteFunctReportByFKey(functCode, sysEmpId);
        }
        public static void DeleteFunctReport(string functRortCd)
        {
            FunctionReportAccess access = new FunctionReportAccess();
            access.DeleteFunctReport(functRortCd);
        }
        /*
         * Process for FunctionUser.
         */
        public static List<FunctionReportViewModel> getTreeLimitedFunctionReports(string deptFunction)
        {
            var data = getTreeFunctionReports();
            List<FunctionReportViewModel> functReportList = new List<FunctionReportViewModel>();
            FunctionReportViewModel functReport = data.Where(p => p.FUNCCODE == deptFunction).FirstOrDefault();
            FunctionReportViewModel root = RecursiveLimited(functReport, data);
            if (root != null)
                functReportList.Add(root);

            FunctionReportViewModel current = root;
            List<FunctionReportViewModel> result = new List<FunctionReportViewModel>();
            List<FunctionReportViewModel> usergeoreport = new List<FunctionReportViewModel>();

            if (current != null)
            {
                result.Add(current);

                while (current.FunctionReportViewModels.Count() > 0)
                {
                    current = current.FunctionReportViewModels[0];
                    result.Add(current);
                }
                result.Reverse();
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].FunctionReportViewModels.Clear();
                }
                for (int i = 0; i < result.Count - 1; i++)
                {
                    result[i].FunctionReportViewModels.Add(result[i + 1]);
                }
                usergeoreport.Add(result[0]);
            }
            return usergeoreport;

            //return functReportList;
        }
        public static FunctionReportViewModel RecursiveLimited(FunctionReportViewModel function, List<FunctionReportViewModel> functList)
        {
            if (function == null) return null;
            if (functList.Where(c => c.FUNCCODE == function.FUNCPARENT).Count() < 1)
            {
                //if (string.IsNullOrEmpty(function.FUNCPORTCD))
                //    return null;
                return function;
            }
            else
            {
                List<FunctionReportViewModel> newList = new List<FunctionReportViewModel>();
                foreach (FunctionReportViewModel ca in functList.Where(c => c.FUNCCODE == function.FUNCPARENT))
                {
                    FunctionReportViewModel org = RecursiveLimited(ca, functList);
                    if (org != null)
                    {
                        if (newList.Where(p => p.FUNCCODE == org.FUNCCODE).FirstOrDefault() == null)
                            newList.Add(org);
                    }
                }
                function.FunctionReportViewModels = newList;
                return function;
            }
        }
    }
    class FunctComparer<T> : IEqualityComparer<T> where T : FunctionReportViewModel
    {
        public bool Equals(T x, T y)
        {
            return x.FUNCNAME.Equals(y.FUNCNAME);
        }

        public int GetHashCode(T obj)
        {
            return obj.FUNCCODE.GetHashCode();
        }
    }
}