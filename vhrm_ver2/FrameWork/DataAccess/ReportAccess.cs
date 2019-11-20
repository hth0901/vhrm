using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class ReportAccess
    {
        public static DataTable Total_Working_Time_values(String pCorporation, string pDepartment, string pTeam, string pSection, string pEmpID, string month)
        {

            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("pCORPORATION", pCorporation);
            param[1] = new OracleParameter("pDEPARTMENT", pDepartment);
            param[2] = new OracleParameter("pTEAM", pTeam);
            param[3] = new OracleParameter("pSECTION", pSection);
            param[4] = new OracleParameter("pEmp", pEmpID);
            param[5] = new OracleParameter("pMonth", month);
            param[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_QUERY.SP_TOTAL_WORKING_TIME", param);

        }
        public static DataTable Emp_list(String pCorporation, string pEmployeeId, string pContractKind, string pWorkingStatus,
            string pIsForeignCheck, string pContractLastTo, string PConfirm, string pRequestStatus, string pLanguage)
        {
            OracleParameter[] param = new OracleParameter[10];
            param[0] = new OracleParameter("pDeptCd", pCorporation);
            param[1] = new OracleParameter("pEmployeeId", pEmployeeId);
            param[2] = new OracleParameter("pContractKind", pContractKind);
            param[3] = new OracleParameter("pWorkingStatus", pWorkingStatus);
           // param[4] = new OracleParameter("pDatework", pDatework);
            param[4] = new OracleParameter("pIsForeignCheck",pIsForeignCheck);
            param[5] = new OracleParameter("pContractLastTo", pContractLastTo);
            param[6] = new OracleParameter("PConfirm", PConfirm);
            param[7] = new OracleParameter("pRequestStatus", pRequestStatus);
            param[8] = new OracleParameter("planguage",pLanguage);
            //param[9] = new OracleParameter("pdate", pdate);
            param[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_QUERY.sp_Emp_list_Qry", param);

        }
        public static DataTable Print_EmplistGroup(String pCorporation, string pEmployeeId, string pContractKind, string pWorkingStatus,
            string pIsForeignCheck, string pContractLastTo, string PConfirm, string pRequestStatus, string pLanguage)
        {
            OracleParameter[] param = new OracleParameter[10];
            //param[0] = new OracleParameter("pDepartmentId",pDepartmentId);
            param[0] = new OracleParameter("pDeptCd", pCorporation);
            param[1] = new OracleParameter("pEmployeeId", pEmployeeId);
            param[2] = new OracleParameter("pContractKind", pContractKind);
            param[3] = new OracleParameter("pWorkingStatus", pWorkingStatus);
            //param[4] = new OracleParameter("pDatework",pDatework);
            param[4] = new OracleParameter("pIsForeignCheck", pIsForeignCheck);
            param[5] = new OracleParameter("pContractLastTo", pContractLastTo);
            param[6] = new OracleParameter("PConfirm", PConfirm);
            param[7] = new OracleParameter("pRequestStatus", pRequestStatus);
            param[8] = new OracleParameter("planguage", pLanguage);
            param[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("SP_PRINT_EMPLIST_GROUP", param);

        }
        public static DataTable D07TS_ChangeSocialInsurance()
        {
            string query = "SP_D07TS_CHANGESOCIALINSURANCE";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable A01ATS_SUGGESTSOCIALIN()
        {
            string query = "SP_A01ATS_SUGGESTSOCIALIN";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable C69AHD_ALLOWANCEMATERNITY()
        {
            string query = "SP_C69AHD_ALLOWANCEMATERNITY";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable C66AHD_ENTITLEDSICK()
        {
            string query = "SP_C66AHD_ENTITLEDSICK";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable C67AHD_REQUESTMATERNITY()
        {
            string query = "SP_C67AHD_REQUESTMATERNITY";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable D02TS_INSURANCE()
        {
            string query = "SP_D02TS_INSURANCE";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        //by hung

        public static DataTable SP_SALARYREPORT(string PCORPORATION, string PMONTH, string PSYSEMPIS, string PWSTATUS,
            string PKINDREPORT, string PKINDMONEY, string PLOGIN, string PCOUNTCONTRACT)
        {
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("PCORPORATION", PCORPORATION);
            param[1] = new OracleParameter("PMONTH", PMONTH);
            param[2] = new OracleParameter("PSYSEMPIS", PSYSEMPIS);
            param[3] = new OracleParameter("PWSTATUS", PWSTATUS);
            param[4] = new OracleParameter("PKINDREPORT", PKINDREPORT);
            param[5] = new OracleParameter("PKINDMONEY", PKINDMONEY);
            param[6] = new OracleParameter("PLOGIN", PLOGIN);
            param[7] = new OracleParameter("PCOUNTCONTRACT", PCOUNTCONTRACT);
            param[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("SP_SALARYREPORT", param);
        }

        public static DataTable SP_SALARYREPORT_DETAIL(string PSYSEMPID, string PMONTH)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("PSYSEMPID", PSYSEMPID);
            param[1] = new OracleParameter("PMONTH", PMONTH);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("SP_SALARYREPORT_DETAIL", param);

        }

        //
        //by Nguyen Nhan Nghia

        public static DataTable SP_SALARYREPORT_TAXINCOME(string PCORPORATION, string PMONTH, string PSYSEMPID)
        {
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("PCORPORATION", PCORPORATION);
            param[1] = new OracleParameter("PMONTH", PMONTH);
            param[2] = new OracleParameter("PSYSEMPID", PSYSEMPID);            
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("SP_SALARYREPORT_TAXINCOME", param);
        }

        public static DataTable SP_DAILYWORKINGTIME(string PCORPORATION, string PFROMDATE, string PTODATE, string PSYSEMPID, string PWSTATUS)
        {
            int index = 0;
            OracleParameter[] param = new OracleParameter[6];
            param[index++] = new OracleParameter("PCORPORATION", PCORPORATION);
            param[index++] = new OracleParameter("PEMP", PSYSEMPID);
            param[index++] = new OracleParameter("PFROMDATE", PFROMDATE);
            param[index++] = new OracleParameter("PTODATE", PTODATE);            
            param[index++] = new OracleParameter("PWORKINGTIME", PWSTATUS);
            param[index++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("SP_DAILYWORKINGTIME", param);
        }

        public static DataTable SP_GETDEPTCODE(string PCORPORATION)
        {
            int index = 0;
            OracleParameter[] param = new OracleParameter[2];
            param[index++] = new OracleParameter("pDeptCode", PCORPORATION);            
            param[index++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("SP_GETDEPTCODE", param);
        }

        public static DataTable SP_REPORT_GET_EMP_LIST(string PDEPTCODE, string PFROM, string PTO, string PEMP, string pWorkingTime)
        {
            int index = 0;
            OracleParameter[] para = new OracleParameter[6];
            para[index++] = new OracleParameter("PDEPTCODE", PDEPTCODE);
            para[index++] = new OracleParameter("PFROM", PFROM);
            para[index++] = new OracleParameter("PTO", PTO);
            para[index++] = new OracleParameter("PEMP", PEMP);
            para[index++] = new OracleParameter("pWorkingTime", pWorkingTime);
            para[index++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("SP_REPORT_GET_EMP_LIST", para);
        }

        public static DataTable SP_REPORT_ATTENDANCE(string PFROM, string PTO, string PEMPID)
        {
            int index = 0;
            OracleParameter[] para = new OracleParameter[4];
            para[index++] = new OracleParameter("PFROM",PFROM);
            para[index++] = new OracleParameter("PTO",PTO);
            para[index++] = new OracleParameter("PEMPID",PEMPID);
            para[index++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("SP_REPORT_ATTENDANCE", para);
        }
    }
}