using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class SalaryReport_ResignedWorker_Access
    {
        public static DataTable LoadMaster(string pDeptCode, string fromdate, string todate, string sys_empid)
        {
            string query = "PKPAYROLL_RESIGNEDSALARYREPORT.SP_LOAD_SALARYMASTER";
            var parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PDEPTCODE", pDeptCode);
            parameters[1] = new OracleParameter("PFROMDATE", fromdate);
            parameters[2] = new OracleParameter("PTODATE", todate);
            parameters[3] = new OracleParameter("PSYSEMPID", sys_empid);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable LoadDetail(string pSysempid)
        {
            string query = "PKPAYROLL_RESIGNEDSALARYREPORT.SP_LOAD_SALARYDETAIL";
            var parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("PSYSEMPIS", pSysempid);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        // Modify By Tho 2014/01/10
        // Load Annual Leave for Employee
        public static DataTable LoadAnnualLeave(string sys_empid, string pMonth)
        {
            string query = "PKPAYROLL_SALARYREPORT.SP_LOAD_ANNUALLEAVE";
            OracleParameter[] _param = new OracleParameter[3];
            _param[0] = new OracleParameter("PSYS_EMPID", sys_empid);
            _param[1] = new OracleParameter("PMONTH", pMonth);
            _param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(query, _param);
        }
    }
}