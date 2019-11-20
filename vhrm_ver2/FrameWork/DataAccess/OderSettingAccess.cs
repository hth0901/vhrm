using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class OderSettingAccess
    {
        public static DataTable load_OfficialOder()
        {

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_OFFICALORDER_SETTING.sp_Load_OFFICIAL_ORDER", param);

        }
        public static DataTable OfficialOderSave(string workingTag,string OfficialCd, string OfficialNm,string Statusworking, string Isjoin, string Isretirement,
            string Istransferencr, string Isperiod, int orderindex, string pLoginId)
        {
            string spName = "PKHR_OFFICALORDER_SETTING.sp_INSERT_OFFICIAL_ORDER";
            OracleParameter[] parameters = new OracleParameter[11];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag);
            parameters[1] = new OracleParameter("pOFFICIALCD", OfficialCd);
            parameters[2] = new OracleParameter("pOFFICIALNM", OfficialNm);
            parameters[3] = new OracleParameter("pSTATUSWORKING", Statusworking);
            parameters[4] = new OracleParameter("pISJOIN", Isjoin);
            parameters[5] = new OracleParameter("pISRETIREMENT", Isretirement);
            parameters[6] = new OracleParameter("pISTRANSFERENCR", Istransferencr);
            //
            parameters[7] = new OracleParameter("pIsperiod", Isperiod);
            parameters[8] = new OracleParameter("pORDERINDEX", orderindex);
            parameters[9] = new OracleParameter("pUSER", pLoginId);
            parameters[10] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);

        }
    }
}