using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class SalaryVersionAccess
    {
        public static DataTable Load_combo()
        {
            OracleParameter[] _sqlParam = new OracleParameter[1];
            _sqlParam[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKPAYROLL_SALARYVERSION.SP_LOADCOMBO_PBYM", _sqlParam);
        }
        public static DataTable Getdata(string frommonth, string corporation)
        {
            OracleParameter[] _sqlParam = new OracleParameter[3];
            _sqlParam[0] = new OracleParameter("pFrommonth", frommonth);
            _sqlParam[1] = new OracleParameter("pCorporation", corporation);
            _sqlParam[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKPAYROLL_SALARYVERSION.SP_lOAD_T_PR_CLOSING", _sqlParam);
        }
        public static DataTable Savedata(string workingtag, SalaryVersionEntity enty)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("pWorkingTag", workingtag);
            param[1] = new OracleParameter("pPBYM", enty.Pbym??"");
            param[2] = new OracleParameter("pDeptcode", enty.Deptcode ?? "");
            param[3] = new OracleParameter("pUSERID", enty.UserId ?? "");
            param[4] = new OracleParameter("pClosing", enty.Closing ?? "");
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKPAYROLL_SALARYVERSION.SP_T_PR_CLOSING_SAVE", param);
            return dtData;
        }
    }
}