using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class TimeWorkAccess
    {
        public DataTable Query(string pDeptCode,string Month)
        {
            string query = "PKTIMESHEET_TIMEWORK.sp_TimeWork_Query";
            var parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pDeptCode", pDeptCode);
            parameters[1] = new OracleParameter("pMonth", Month);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public DataTable Save(string workingTag, TimeWorkEntity entity, string pLoginId)
        {

            string spName = "PKTIMESHEET_TIMEWORK.sp_TimeWork_Save";
            OracleParameter[] parameters = new OracleParameter[17];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag);
            parameters[1] = new OracleParameter("pDEPTCODE", entity.DEPTCODE);
            parameters[2] = new OracleParameter("pKINDSTAFF", entity.KINDSTAFF);
            parameters[3] = new OracleParameter("pDATEFROM", entity.DATEFROM);
            parameters[4] = new OracleParameter("pDATETO", entity.DATETO);
            parameters[5] = new OracleParameter("pATTENDANCE_TIME_FROM", entity.ATTENDANCE_TIME_FROM);
            parameters[6] = new OracleParameter("pATTENDANCE_TIME_TO", entity.ATTENDANCE_TIME_TO);
            parameters[7] = new OracleParameter("pLUNCH_TIME_FROM", entity.LUNCH_TIME_FROM);
            parameters[8] = new OracleParameter("pLUNCH_TIME_TO", entity.LUNCH_TIME_TO);
            parameters[9] = new OracleParameter("pNORMAL_TIME_FROM", entity.NORMAL_TIME_FROM);
            parameters[10] = new OracleParameter("pNORMAL_TIME_TO", entity.NORMAL_TIME_TO);
            parameters[11] = new OracleParameter("pIS_ADDITIONAL", entity.IS_ADDITIONAL);
            parameters[12] = new OracleParameter("pLIMIT_CHECKINTIME", entity.LIMIT_CHECKINTIME);
            parameters[13] = new OracleParameter("pLIMIT_CHECKOUTTIME", entity.LIMIT_CHECKOUTTIME);

            //add by ndhung 2015.08.19 -> add week day
            parameters[14] = new OracleParameter("pWEEKDAY", entity.WEEKDAY);
            
            parameters[15] = new OracleParameter("pLoginId", pLoginId);
            parameters[16] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
            
        }

        
    }
}