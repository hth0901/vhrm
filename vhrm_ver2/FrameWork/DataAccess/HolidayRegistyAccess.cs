using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class HolidayRegistyAccess
    {
        public static DataTable LoadData( string month)
        {
            string query = "PKTIMESHEET_HOLIDAY.sp_Holiday_Qry";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pMonth", month ?? "");
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable Save( string task,HolidayRegistyEntity hldREntity)
        {
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pTask", task);
            parameters[1] = new OracleParameter("pHDDATE", hldREntity.Hddate);
            parameters[2] = new OracleParameter("pHDCODE", hldREntity.Hdcode ?? "");
            parameters[3] = new OracleParameter("pLoginId", hldREntity.Uid ?? "");
            parameters[4] = new OracleParameter("pRemarks", hldREntity.Remarks ?? "");
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_HOLIDAY.sp_Holiday_Save", parameters);
        }
        public static DataTable CheckValidator(string fromDate ,string toDate )
        {
            string query = "PKTIMESHEET_HOLIDAY.sp_Holiday_Validator";
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pFromDate", fromDate);
            parameters[1] = new OracleParameter("pToDate", toDate);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
    }
}