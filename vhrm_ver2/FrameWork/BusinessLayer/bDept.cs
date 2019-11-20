using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.DataAccess;
using vhrm.ViewModels;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bDept
    {
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