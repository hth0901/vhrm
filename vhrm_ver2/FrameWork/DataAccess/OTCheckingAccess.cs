using System;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class OTCheckingAccess
    {
        public static DataTable LoadOTChecking(string date, string Department)
        {
            string sp_Name = "PKTIMESHEET_OVERTIMECHECK.SP_LOADOTCHECKING";
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pDeptcode", Department);
            param[1] = new OracleParameter("pWorkDate", date);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_Name, param);
        }
    }
}