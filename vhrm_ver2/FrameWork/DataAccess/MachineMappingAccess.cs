using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class MachineMappingAccess
    {
        public static DataTable GetMachineMapping()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_IPMACHINE.SP_LOAD_IPMACHINE", param);
        }

        public static DataTable GetMachineMappingDetail(string pParentID)
        {
            string spName = "PKTIMESHEET_IPMACHINE.SP_LOAD_IPMACHINE_DETAIL";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pParentID", pParentID);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }

        public static DataTable Save(string pWorkTag, string pDeptCode, string pIpAddress, string pUID)
        {
            string spName = "PKTIMESHEET_IPMACHINE.SP_IPMACHINE_DETAIL_Save";
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pkey", pWorkTag);
            param[1] = new OracleParameter("pDeptCode", pDeptCode);
            param[2] = new OracleParameter("pIPAddress", pIpAddress);
            param[3] = new OracleParameter("pUID", pUID);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
    }
}