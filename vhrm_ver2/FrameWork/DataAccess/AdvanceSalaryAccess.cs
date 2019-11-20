using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class AdvanceSalaryAccess
    {
        public static DataTable LoadDataFilter(string pCoporation, string pEmpId, string pAdvType, string pFromDate, string pToDate, float pAdvAmount)
        {
            string spName = "PKPAYROLL_ADVANCESALARY.sp_T_PR_ADVANCE_Query";
            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("pCORPORATION", pCoporation);
            param[1] = new OracleParameter("pEMPID", pEmpId);
            param[2] = new OracleParameter("pADV_TYP", pAdvType);
            param[3] = new OracleParameter("pFromDate", pFromDate);
            param[4] = new OracleParameter("pToDate", pToDate);
            param[5] = new OracleParameter("pADV_AMT", pAdvAmount);
            param[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public static DataTable Save(string workingTag, AdvanceSalaryEntity entity, string loginId)
        {
            string spName = "PKPAYROLL_ADVANCESALARY.sp_Save_T_PR_ADVANCE";
            OracleParameter[] parameters = new OracleParameter[11];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag ?? "");
            parameters[1] = new OracleParameter("pUID", loginId ?? "");
            parameters[2] = new OracleParameter("pADV_AMT", entity.PAdvAmt);
            parameters[3] = new OracleParameter("pADV_DATE", entity.PAdvDate ?? "");
            parameters[4] = new OracleParameter("pCONFIRM_IS", entity.PConfirmIs ?? "");
            parameters[5] = new OracleParameter("pADV_MONTH", entity.PAdvMonth ?? "");
            parameters[6] = new OracleParameter("pEMPID", entity.PEMPID ?? "");
            parameters[7] = new OracleParameter("pCONFIRM_UID", entity.PConfirmUid ?? "");
            parameters[8] = new OracleParameter("pCONFIRM_DT", entity.PConfirmDate);
            parameters[9] = new OracleParameter("pADV_TYP", entity.PAdvTyp);
            parameters[10] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
        public static DataTable Delete(AdvanceSalaryEntity entity)
        {
            string spName = "PKPAYROLL_ADVANCESALARY.sp_Delete_T_PR_ADVANCE";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pEMPID", entity.PEMPID ?? "");
            parameters[1] = new OracleParameter("pADV_MONTH", entity.PAdvMonth ?? "");
            parameters[2] = new OracleParameter("pADV_TYP", entity.PAdvTyp);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
        public static int CheckValiditor(AdvanceSalaryEntity entity)
        {
            string spName = "PKPAYROLL_ADVANCESALARY.sp_Validitor_T_PR_ADVANCE";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pEMPID", entity.PEMPID ?? "");
            parameters[1] = new OracleParameter("pADV_MONTH", entity.PAdvMonth ?? "");
            parameters[2] = new OracleParameter("pADV_TYP", entity.PAdvTyp);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table= DBHelper.getDataTable_SP(spName, parameters);
            int numberRow =int.Parse(table.Rows[0]["RowNumber"].ToString());
            return numberRow;
        }

        public static DataTable AdvanceSalary_SaveByDept(string pWorkingTag, string pDEPTCODE, string pADV_DATE, string pADV_TYP, double pADV_AMT,
                                        string pCONFIRM_IS, string pInputType,String Sysempid, string pLoginID)
        {

            string spName = "PKPAYROLL_ADVANCESALARY.sp_SaveByDepartment";
            OracleParameter[] parameters = new OracleParameter[10];
            parameters[0] = new OracleParameter("pWorkingTag", pWorkingTag ?? "U");
            parameters[1] = new OracleParameter("pDEPTCODE", pDEPTCODE ?? "");
            parameters[2] = new OracleParameter("pADV_DATE", pADV_DATE);
            parameters[3] = new OracleParameter("pADV_TYP", pADV_TYP);
            parameters[4] = new OracleParameter("pADV_AMT", pADV_AMT);
            parameters[5] = new OracleParameter("pCONFIRM_IS", pCONFIRM_IS);
            parameters[6] = new OracleParameter("pInputType", pInputType);
            parameters[7] = new OracleParameter("pSyssempID",Sysempid);
            parameters[8] = new OracleParameter("pLoginID", pLoginID);
            parameters[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP(spName, parameters);
            return table;
        }

        public static DataTable AdvanceSalary_Confirm(string corporation,string pEmpId, string pFrommonth, 
                      string pToMonth,string pADV_TYP, string pCONFIRM_IS,  string pLoginID)
        {
            string spName = "PKPAYROLL_ADVANCESALARY.sp_AdvanceSalaryConfirm";
            OracleParameter[] parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("pCORPORATION", corporation);
            parameters[1] = new OracleParameter("pEmpId", pEmpId);
            parameters[2] = new OracleParameter("pFromDate", pFrommonth);
            parameters[3] = new OracleParameter("pToDate", pToMonth);
            parameters[4] = new OracleParameter("pADV_TYP", pADV_TYP);
            parameters[5] = new OracleParameter("pCONFIRM_IS", pCONFIRM_IS);
            parameters[6] = new OracleParameter("pLoginID", pLoginID);
            parameters[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP(spName, parameters);
            return table;
        }
        public static DataTable Report_AdvanceSalary(string pCoporation, string pMonth, string kindAdvance, string pKindReport, string pLogin)
        {
            string spName = "SP_ADVANCE_PAYMENT";
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("pCorporation", pCoporation);
            param[1] = new OracleParameter("pMonth", pMonth);
            param[2] = new OracleParameter("pKindadvance",kindAdvance);
            param[3] = new OracleParameter("pKindReport", pKindReport);
            param[4] = new OracleParameter("pLogin", pLogin);
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
    }
}