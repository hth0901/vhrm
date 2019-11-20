using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class SalaryReportAccess
    {
        public static DataTable Query(string pDeptCode, string pSysempid, string pWstatus, string pMonth)
        {
            string query = "PKPAYROLL_SALARYREPORT.SP_LOAD_SALARYREPORT";
            var parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PDEPTCODE", pDeptCode);
            parameters[1] = new OracleParameter("PSYSEMPIS", pSysempid);
            parameters[2] = new OracleParameter("PWSTATUS", pWstatus);
            parameters[3] = new OracleParameter("PMONTH", pMonth);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable QueryDetail(string pSysempid,string pMonth,string plange)
        {
            string query = "PKPAYROLL_SALARYREPORT.SP_LOAD_DETAIL";
            var parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("PSYSEMPIS", pSysempid);
            parameters[1] = new OracleParameter("PPBYM", pMonth);
            parameters[2] = new OracleParameter("planguage", plange);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable Closing(string pSysempid, string pPbym, float Basicsalary)
        {
            string query = "PKPAYROLL_SALARYREPORT.SP_T_PR_SLR_MT_CLOSING";
            var parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("PSYSEMPIS", pSysempid);
            parameters[1] = new OracleParameter("PPBYM", pPbym);
            parameters[2] = new OracleParameter("PBASICSALARY", Basicsalary);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable Open(string pSysempid, string pPbym)
        {
            string query = "PKPAYROLL_SALARYREPORT.SP_T_PR_SLR_MT_OPEN_MULTI";
            var parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PSYSEMPID", pSysempid);
            parameters[1] = new OracleParameter("PPBYM", pPbym);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable ClosingALL(string pSysempid, string pPbym)
        {
            string query = "PKPAYROLL_SALARYREPORT.SP_T_PR_SLR_MT_CLOSING_MULTI";
            var parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PSYSEMPID", pSysempid);
            parameters[1] = new OracleParameter("PPBYM", pPbym);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable PrintSalary(string pDeptCode, string pMonth, string pSysempid, string pWstatus,string pKindreport)
        {
            string query = "SP_SALARYREPORT";
            var parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pCorporation", pDeptCode);
            parameters[1] = new OracleParameter("pMonth", pMonth);
            parameters[2] = new OracleParameter("PSYSEMPIS", pSysempid);
            parameters[3] = new OracleParameter("PWSTATUS", pWstatus);
            parameters[4] = new OracleParameter("pKindReport", pKindreport);
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
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