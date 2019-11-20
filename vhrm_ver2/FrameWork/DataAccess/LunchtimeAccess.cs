using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class LunchtimeAccess
    {
        #region Category DataAccess
        public DataTable GetLunchTime()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_LUNCHTIME.sp_get_lunchtime_Qry", param);
        }

        public DataTable AddLunchtime(string name, string lunchfrom, string lunchto, DateTime create_dt, string create_uid, DateTime update_dt, string update_uid)
        {
            OracleParameter[] parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("NAME_LT", name);
            parameters[1] = new OracleParameter("LUNCH_FROM", lunchfrom);
            parameters[2] = new OracleParameter("LUNCH_TO", lunchto);
            parameters[3] = new OracleParameter("CREATEDT", create_dt);
            parameters[4] = new OracleParameter("CREATEUID", create_uid);
            parameters[5] = new OracleParameter("UPDATEDT", update_dt);
            parameters[6] = new OracleParameter("UPDATEUID", update_uid);
            parameters[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_LUNCHTIME.sp_add_lunchtime", parameters);
        }

        public DataTable UpdateLunchTime(int id, string name, string lunchfrom, string lunchto, DateTime update_dt, string update_uid)
        {
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("IDLunchtime", id);
            parameters[1] = new OracleParameter("NAME_LT", name);
            parameters[2] = new OracleParameter("LUNCH_FROM", lunchfrom);
            parameters[3] = new OracleParameter("LUNCH_TO", lunchto);
            parameters[4] = new OracleParameter("UPDATEDT", update_dt);
            parameters[5] = new OracleParameter("UPDATEUID", update_uid);
            return DBHelper.getDataTable_SP("PKTIMESHEET_LUNCHTIME.sp_update_lunchtime", parameters);
        }

        public DataTable DeleteLunchTime(int id)
        {
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("IDLunchtime", id);
            return DBHelper.getDataTable_SP("PKTIMESHEET_LUNCHTIME.sp_remove_lunchtime", parameters);
        }

        #endregion
    }
}