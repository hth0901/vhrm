using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Data;

namespace vhrm.FrameWork.DataAccess
{
    public class AnnualLeaveCreateAccess
    {
        public static DataTable loadGridAnnualLeaveCreate(string pDeptcode, string pMonth)
        {
            string spName = "PKTIMESHEET_ANNUALLEAVE_CREATE.SP_PR_ANNUALLEAVE_QRY";
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pDEPTCODE", pDeptcode);
            param[1] = new OracleParameter("pMONTH", pMonth);
            //param[2] = new OracleParameter("pSYSEMPID", pSysempid);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }
        public static DataTable CreateAnnualLeave(string pDeptcode, string pMonth, string pUser)
        {
            string spName = "PKTIMESHEET_ANNUALLEAVE_Create.sp_CreateAnnualLeave";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pDEPTCODE", pDeptcode);
            param[1] = new OracleParameter("pMONTH", pMonth);
            param[2] = new OracleParameter("pUSER", pUser);
            //param[2] = new OracleParameter("pSYSEMPID", pSysempid);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }
        public static DataTable ConfirmAnnualLeave(string pDeptcode, string pMonth,string pUser)
        {
            string spName = "PKTIMESHEET_ANNUALLEAVE_Create.SP_PR_ANNUALLEAVE_CONFIRM";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pDEPTCODE", pDeptcode);
            param[1] = new OracleParameter("pMONTH", pMonth);
            param[2] = new OracleParameter("pUSER", pUser);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }
    }
}