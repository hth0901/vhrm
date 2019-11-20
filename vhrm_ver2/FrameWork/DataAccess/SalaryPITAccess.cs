using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;
//using KSN.Modules.Setting;

namespace vhrm.FrameWork.DataAccess
{
    public class SalaryPITAccess
    {
        public static DataTable Getdata(string verid)
        {
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("pversion", verid);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKPALLROLL_SALARYPIT.sp_Load_PRSALARY_PIT", _sqlParam);
        }
        public static DataTable Savedata(string workingtag, SalaryPITEntity enty)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[10];
            param[0] = new OracleParameter("pWorkingTag", workingtag);
            param[1] = new OracleParameter("pPIT_ID", enty.Pit_id);
            param[2] = new OracleParameter("pVER_ID", enty.Ver_id);
            param[3] = new OracleParameter("pPIT_FROM", enty.Pit_from);
            param[4] = new OracleParameter("pPIT_TO", enty.Pit_to);
            param[5] = new OracleParameter("pPIT_RATE", enty.Pit_rate);
            param[6] = new OracleParameter("pAMT", enty.Amt);
            param[7] = new OracleParameter("pCREATE_UID", enty.Create_UID);
            param[8] = new OracleParameter("pUPDATE_UID", enty.Update_UID);
            param[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP("PKPALLROLL_SALARYPIT.sp_INSERT_PRSALARY_PIT", param);
            return dtData;
        }
    }
}