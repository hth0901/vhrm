using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class DailyTempAccess
    {
        public static DataTable loadDailyTemp(string pRfid, string pFromDate, string pToDate)
        {
            string query = "PKTIMESHEET_DAILY_TEMP.SP_LOAD_DAILY_TEMP";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pRfid", pRfid);
            parameters[1] = new OracleParameter("pFromDate", pFromDate);
            parameters[2] = new OracleParameter("pTodate", pToDate);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable Save(string pWorkingTag, string pRfid, string pFromDate, string pToDate, string pLogDate, string pIPAddress)
        {
            string query = "PKTIMESHEET_DAILY_TEMP.SP_SAVE_DAILY_TEMP";
            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            parameters[1] = new OracleParameter("pRfid", pRfid);
            parameters[2] = new OracleParameter("pFromDate", pFromDate);
            parameters[3] = new OracleParameter("pTodate", pToDate);

            parameters[4] = new OracleParameter("pLogDate", pLogDate);
            parameters[5] = new OracleParameter("pIpAddress", pIPAddress);
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
    }
}