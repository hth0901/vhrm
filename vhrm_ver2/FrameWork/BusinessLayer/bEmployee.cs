using vhrm.ViewModels;
using vhrm.FrameWork.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bEmployee
    {
        public static DataTable dtDept;
        public static List<EmployeeItemViewModel> GetAllEmpoyee(string pDeptCode, string pStatus)
        {
            List<EmployeeItemViewModel> res = new List<EmployeeItemViewModel>();
            if (string.IsNullOrEmpty(pDeptCode))
                return res;
            DataTable dtRes = new DataTable();
            HRInfoAccess _access = new HRInfoAccess();
            dtRes = _access.HRInfo_Query("Q", "", pDeptCode, pStatus, "en");
            foreach(DataRow dtr in dtRes.Rows)
            {
                EmployeeItemViewModel item = new EmployeeItemViewModel
                {
                    EMPID = dtr["EMPID"].ToString(),
                    SYS_EMPID = dtr["SYS_EMPID"].ToString(),
                    FULLNAME = dtr["FULLNAME"].ToString(),
                    EMPNAME = dtr["EMPNAME"].ToString(),
                    DEPARTMENT = dtr["DEPARTMENT"].ToString(),
                    STATUS = dtr["STATUS"].ToString(),
                    IDENTITYCARD = dtr["UID_FOR_MES"].ToString(),
                    RFID = dtr["RFID"].ToString(),
                    DATEJOIN = dtr["DATEJOIN"].ToString()
                };
                res.Add(item);
            }
            return res;
        }

        public static List<DepartmentTreeViewItem> getDeptTree(string lstDept)
        {
            if (dtDept == null)
            {
                OrganazationRegistryAccess accessOrganazation = new OrganazationRegistryAccess();
                //dtDept = accessOrganazation.LoadTreeViewPermit("1003,1008,1011,1009,1012,1001,1002,1006");
                dtDept = accessOrganazation.LoadTreeViewPermit(lstDept);
            }
            List<DepartmentTreeViewItem> result = new List<DepartmentTreeViewItem>();

            foreach(DataRow dtr in dtDept.Rows)
            {
                //if (int.Parse(dtr["ITEMLEVEL"].ToString()) > 3)
                //    continue;
                DepartmentTreeViewItem item = new DepartmentTreeViewItem
                {
                    ITEMCODE = dtr["ITEMCODE"].ToString(),
                    DEPTCODEFULL = dtr["DEPTCODEFULL"].ToString(),
                    PARENTID = dtr["PARENTID"].ToString(),
                    ITEMLEVEL = int.Parse(dtr["ITEMLEVEL"].ToString()),
                    SHORTNAME = dtr["SHORTNAME"].ToString(),
                    FULLNM = dtr["FULLNM"].ToString(),
                };
                result.Add(item);
            }
            
            return result;
        }

        public static EmployeeViewModel getEmployeeInfo(string sys_empid)
        {
            DataSet dtSet = new DataSet();
            HRInfoAccess _access = new HRInfoAccess();
            dtSet = _access.HRInfo_QueryAll(sys_empid, "", "", "en", "");
            DataTable dtHr = dtSet.Tables[0];
            EmployeeViewModel result = new EmployeeViewModel();
            result.EMPID = dtHr.Rows[0]["EMPID"].ToString();
            result.EMPNAME = dtHr.Rows[0]["EMPNAME"].ToString();
            result.EMPNAMEEN = dtHr.Rows[0]["EMPNAMEEN"].ToString();
            result.SYS_EMPID = dtHr.Rows[0]["SYS_EMPID"].ToString();
            result.SEX = dtHr.Rows[0]["SEX"].ToString();
            result.GENDERNAME = dtHr.Rows[0]["GENDERNAME"].ToString();
            result.BIRTHDAY = dtHr.Rows[0]["BIRTHDAY"].ToString();
            result.EMPIDOLD = dtHr.Rows[0]["EMPIDOLD"].ToString();
            result.RFID = dtHr.Rows[0]["RFID"].ToString();
            result.FULLNAME = dtHr.Rows[0]["FULLNAME"].ToString();
            result.FULLCD = dtHr.Rows[0]["FULLCD"].ToString();
            result.ISLEAF = dtHr.Rows[0]["ISLEAF"].ToString();
            result.DEPTCODE = dtHr.Rows[0]["DEPTCODE"].ToString();
            result.IMAGEURL = dtHr.Rows[0]["IMAGEURL"].ToString();


            return result;
        }
    }
}