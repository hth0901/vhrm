using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Data;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class TimeOfRestAccess
    {
        public static DataTable Load(string pCORPORATION, string pEMPID, string pWORKKIND, string FromDate, string ToDate)
        {
            string query = "PKTIMESHEET_TimeOfRest.sp_T_ht_pwmt_Query";
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pCORPORATION", pCORPORATION);
            parameters[1] = new OracleParameter("pEMPID", pEMPID);
            parameters[2] = new OracleParameter("pWORKKIND", pWORKKIND);
            parameters[3] = new OracleParameter("FromDate", FromDate);
            parameters[4] = new OracleParameter("ToDate", ToDate);
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) 
            { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable Save(string workingTag, TimeOfRestEntity entity,string loginId)
        {
            string spName = "PKTIMESHEET_TimeOfRest.sp_T_ht_pwmt_Save";
            OracleParameter[] parameters = new OracleParameter[12];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag ?? "");
            parameters[1] = new OracleParameter("p_REGISTERID", loginId ?? "");
            parameters[2] = new OracleParameter("p_EMPID", entity.p_EMPID ?? "");
            parameters[3] = new OracleParameter("p_WORKKIND", entity.p_WORKKIND ?? "");
            parameters[4] = new OracleParameter("p_REMARKS", entity.p_Remark ?? "");
            parameters[5] = new OracleParameter("p_VALIDITYFROM", entity.p_VALIDITYFROM ?? "");
            parameters[6] = new OracleParameter("p_ALEAVEDEDUCTION", entity.p_ALEAVEDEDUCTION );
            parameters[7] = new OracleParameter("p_CONFIRMID", entity.p_CONFIRMID ?? "");
            parameters[8] = new OracleParameter("p_CONFIRMDATE", entity.p_CONFIRMDATE );
            parameters[9] = new OracleParameter("p_CONFIRMCHECK", entity.p_CONFIRMCHECK ?? "");
            parameters[10] = new OracleParameter("p_ENDDATE", entity.p_ENDDATE);
            parameters[11] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}