using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class InsBenefitAccess
    {
        public static DataTable load_Ins_SickNess(string Corporation, string empid, string fromdate, string todate)
        {
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("pCorporation", Corporation);
            parameters[1] = new OracleParameter("pEMPID", empid ?? "");
            parameters[2] = new OracleParameter("pFromDate", fromdate ?? "");
            parameters[3] = new OracleParameter("pToDate", todate ?? "");

            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_INS_SICKNESS.SP_LOAD_INS_SICKNESS", parameters);
        }

        public static DataTable Save(string workingTag, string Sys_empid , string StrDate ,string Todate ,string DeptCode , string AppMonth , string ItemCD ,
   float BasicSalary, float Insrate, float Amt, string ConfirmIs, string ConfirmUID, string LoginId)
        {
            string spName = "PK_INS_SICKNESS.SP_SAVE_INS_SICKNESS";
            OracleParameter[] parameters = new OracleParameter[14];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag);
            parameters[1] = new OracleParameter("pSys_empid", Sys_empid);
            parameters[2] = new OracleParameter("pStrDate", StrDate);
            parameters[3] = new OracleParameter("pTodate", Todate);
            parameters[4] = new OracleParameter("pDeptCode", DeptCode);
            parameters[5] = new OracleParameter("pAppMonth", AppMonth);
            parameters[6] = new OracleParameter("pItemCD", ItemCD);
            parameters[7] = new OracleParameter("pBasicSalary", BasicSalary);
            parameters[8] = new OracleParameter("pInsrate", Insrate);
            parameters[9] = new OracleParameter("pAmt", Amt);
            parameters[10] = new OracleParameter("pConfirmIs", ConfirmIs);
            parameters[11] = new OracleParameter("pConfirmUID", ConfirmUID);
            parameters[12] = new OracleParameter("pUSER", LoginId);

            parameters[13] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);

        }
    }
}