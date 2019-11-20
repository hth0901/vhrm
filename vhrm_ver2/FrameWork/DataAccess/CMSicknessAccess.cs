using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class CMSicknessAccess
    {
        public static DataTable load_CMSickNess()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKINSURANCE_CM_SICKNESS.SP_LOAD_CM_SICKNESS", param);
        }

        public static DataTable Save(string workingTag, string ItemCD, string StartDate, float Insrate, string LoginId)
        {
            string spName = "PKINSURANCE_CM_SICKNESS.SP_SAVE_CM_SICKNESS";
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag);
            parameters[1] = new OracleParameter("pItemCD", ItemCD);
            parameters[2] = new OracleParameter("pStrDate", StartDate);
            parameters[3] = new OracleParameter("pInsrate", Insrate);
            parameters[4] = new OracleParameter("pUSER", LoginId);
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);

        }
    }
}