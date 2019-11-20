using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class AbsenceListAccess
    {
        public  DataTable Query(string corporation, string status, string employeeId, string fromDate, string toDate)
        {
            string query = "PKHR_HRINFO.SP_COUNTABSENCELIST";
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pFULLCODE", corporation ?? "");
            parameters[1] = new OracleParameter("pFROMDATE", fromDate ?? "");
            parameters[2] = new OracleParameter("pTODATE", toDate ?? "");
            parameters[3] = new OracleParameter("pSTATUS", status ?? "");
            parameters[4] = new OracleParameter("pSYSEMPID", employeeId ?? "");
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public DataTable Query_DT(string employeeId, string fromDate, string toDate)
        {
            string query = "PKHR_HRINFO.SP_COUNTABSENCELIST_DT";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pFROMDATE", fromDate ?? "");
            parameters[1] = new OracleParameter("pTODATE", toDate ?? "");
            parameters[2] = new OracleParameter("pSYSEMPID", employeeId ?? "");
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        
    }
}