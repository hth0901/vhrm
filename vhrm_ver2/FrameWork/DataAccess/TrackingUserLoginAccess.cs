using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class TrackingUserLoginAccess
    {
        public DataTable UpdateLogOut(string sesionId)
        {
            string spName = "PKOPM_LOGIN.SP_UpdateTracking";
            OracleParameter[] para = new OracleParameter[2];
            para[0] = new OracleParameter("PSESSIONID", sesionId);
            para[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);    
        }
    }
}