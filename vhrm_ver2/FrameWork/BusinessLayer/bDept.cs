using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using vhrm.FrameWork.DataAccess;
using vhrm.ViewModels;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bDept
    {
        public static List<OrgNodeViewModel> getOrganizationChartData(string deptCode)
        {
            var data = getActivedDepartments();
            List<OrgNodeViewModel> deptList = new List<OrgNodeViewModel>();
            var empReport = bEmployeeMasterReport.GeSupervisors();
            foreach (OrgNodeViewModel org in data)
            {
                var geosupervisors = empReport.Where(er => er.DEPTCODEGEO == org.id);
                if (geosupervisors == null || geosupervisors.Count() == 0)
                    org.SUPERVISORS = "<div></div>";
                else
                    org.SUPERVISORS = formatHTML(geosupervisors);
                org.IMG = "/FileServer/Photos/lineorg.png";
            }
            return data;
        }
        private static string formatHTML(IEnumerable<SupervisorViewModel> supervisors)
        {
            string html = "<div><br>";
            foreach (var item in supervisors)
            {
                var str = string.Empty;
                if (string.IsNullOrEmpty(item.IMAGE))//style='border-radius: 50%; width:20px; height:20px;'
                    str = "<img class='supervisorimg' src='/FileServer/Photos/default.jpg'><label class='lbsupervisor'>" + item.EMPNAME + "</lable><br/>";//style='color: white;'>
                else
                {
                    str = "<img class='supervisorimg' src='/FileServer/Photos/" + item.IMAGE + "'><label class='lbsupervisor'>" + item.EMPNAME + "</lable><br/>";
                }
                html = html + str;
            }
            html = html + "</div>";
            return html;
        }

        public static List<OrgNodeViewModel> getActivedDepartments()
        {
            List<OrgNodeViewModel> dtDept = new List<OrgNodeViewModel>();
            DeptAccess access = new DeptAccess();
            DataTable dtResult = access.GetActivedDepartments();
            int level = 0;
            foreach (DataRow dtr in dtResult.Rows)
            {
                int.TryParse(dtr["DEPTLEVEL"].ToString(), out var oLevel);
                level = oLevel;
                if (level > 3) continue;
                OrgNodeViewModel item = new OrgNodeViewModel
                {
                    id = dtr["DEPTCODE"].ToString(),
                    DEPTNAME = dtr["DEPTNAME"].ToString(),
                    pid = string.IsNullOrEmpty(dtr["DEPTPARENT"].ToString()) ? null : dtr["DEPTPARENT"].ToString()
                };
                dtDept.Add(item);
            }
            return dtDept;
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