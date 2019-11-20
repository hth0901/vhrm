
/*
 * Author: Nguyen Thi Hue
 * Create Date: Oct 05 2012
 * Description:
 */

using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class VisitLoginAccess
    {
        public static bool VisitLoginSave(VisitLoginEntity ent)
        {
            string squery = "SP_OPM_LOGIN_LOG_INSERT";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("@LOGIN_ID", ent.login_ID);
            parameters[1] = new OracleParameter("@LOGIN_NAME", ent.login_Name);
            parameters[2] = new OracleParameter("@LOGIN_TIME", ent.login_Time);
            parameters[3] = new OracleParameter("@IP_ADDRESS", ent.IP_Address);
            return DBHelper.ExecuteNonQuery_SP(squery, parameters);
        }
        public static string GetLoginName(string loginID)
        {
            string squery = "sp_get_loginname";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@loginID", loginID);
            return DBHelper.GetName(squery, parameters);
        }
        public static DataTable GetVisitLog()
        {
            string squery = "SP_OPM_LOGIN_LOG_ALL";
            return DBHelper.getDataTable_SP(squery, null);

        }
        public static DataTable GetVisitLogByDate(string date)
        {
            string squery = "SP_LOGIN_LOG_BYDATE";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@DATE", date);
            return DBHelper.getDataTable_SP(squery, parameters);

        }
        public static bool DeleteVisitLog(VisitLoginEntity ent )
        {
            string squery = "SP_OPM_LOGIN_LOG_DELETE_BYID";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@ID", ent.ID);
            return DBHelper.ExecuteNonQuery_SP(squery, parameters);
        }
        public static bool DeleteVisitLog_DATE()
        {
            string squery = "SP_OPM_VISITLOG_DELETE_ALL";
            return DBHelper.ExecuteNonQuery_SP(squery, null);
        }
    }
}