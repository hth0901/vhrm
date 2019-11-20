using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class InsAccidentDSPHSKAccess
    {
        public static DataSet load_Ins_Accident_DSPHSK(string Corporation, string FromDate, string ToDate, string SysEmpId)
        {
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pCorporation", Corporation);
            parameters[1] = new OracleParameter("pFromDate", FromDate);
            parameters[2] = new OracleParameter("pToDate", ToDate);
            parameters[3] = new OracleParameter("pEmpID", SysEmpId);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[5] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataSet_SP("PKINSURANCE_ACCIDENT_DSPHSK.SP_LOAD_INS_ACCIDENT_DSPHSK", parameters);
        }

        public static DataTable Save(string workingTag, int Seqno, string Sys_empid, string StrDate, string Enddate, float RateDecrease, float Dateoff1,
            float Dateoff2, float Amt, string Remark, string ConfirmIs, string ConfirmUID, string LoginId)
        {
            string spName = "PKINSURANCE_ACCIDENT_DSPHSK.SP_SAVE_INS_ACCIDENT_DSPHSK";
            OracleParameter[] parameters = new OracleParameter[14];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag);
            parameters[1] = new OracleParameter("pSEQNO", Seqno);
            parameters[2] = new OracleParameter("pSys_empid", Sys_empid);
            parameters[3] = new OracleParameter("pStrDate", StrDate);
            parameters[4] = new OracleParameter("pEnddate", Enddate);
            parameters[5] = new OracleParameter("pRateDecrease", RateDecrease);
            parameters[6] = new OracleParameter("pDateoff1", Dateoff1);
            parameters[7] = new OracleParameter("pDateoff2", Dateoff2);
            parameters[8] = new OracleParameter("pAmt", Amt);
            parameters[9] = new OracleParameter("pRemark",OracleType.NVarChar){Value = Remark};
            parameters[10] = new OracleParameter("pConfirmIs", ConfirmIs);
            parameters[11] = new OracleParameter("pConfirmUID", ConfirmUID);
            parameters[12] = new OracleParameter("pUSER", LoginId);

            parameters[13] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);

        }
    }
}