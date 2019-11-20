using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class TimeShiftAccess
    {
        public static DataTable LoadData(string pShiftKind)
        {
            string query = "PKTIMESHEET_DAILYLOG.sp_TimeShift_Qry";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pShiftKind", pShiftKind ?? "");
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable LoadDailyDnILog(string departmentId, string employeeId, string fromDate, string toDate, string isCheck)
        {
            string query = "PKTIMESHEET_DAILYLOG.sp_DailyDnILog_Qry";
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pDepartmentId", departmentId);
            parameters[1] = new OracleParameter("pEmployeeId", employeeId);
            parameters[2] = new OracleParameter("pFromDate", fromDate);
            parameters[3] = new OracleParameter("pToDate", toDate);
            parameters[4] = new OracleParameter("pIsCheck", isCheck);
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable Save(string workingTag, string shift_id, string shift_cd, string shiftnm, string time_in, string time_out, string uid, int orderindex, string shiftnmvn, string pShiftKind)
        {
            OracleParameter[] parameters = new OracleParameter[11];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag?? "");
            parameters[1] = new OracleParameter("pShiftId", shift_id);
            parameters[2] = new OracleParameter("pShiftCode", shift_cd);
            parameters[3] = new OracleParameter("pShiftName", shiftnm);
            parameters[4] = new OracleParameter("pTime_in", time_in);
            parameters[5] = new OracleParameter("pTime_out", time_out);
            parameters[6] = new OracleParameter("pLoginId", uid);
            parameters[7] = new OracleParameter("pOrderIndex", orderindex);
            parameters[8] = new OracleParameter("pshiftnmvn", shiftnmvn);
            parameters[9] = new OracleParameter("pShiftKind", pShiftKind);
            parameters[10] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_DAILYLOG.sp_TimeShift_Save", parameters);
        }

        // Duy Hung 02/06/2014
        public static DataTable SP_TIMESHIFT_QUERRY()
        {
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_DAILYLOG.SP_TIMESHIFT_QUERRY", parameters);
        }

        // Duy Hung 02/06/2014
        public static DataTable SP_TIMESHIFT_COMBO_QRY()
        {
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_DAILYLOG.SP_TIMESHIFT_COMBO_QRY", parameters);
        }

        // Duy Hung 03/06/2014
        public static DataTable SP_TIMESHIFT_UPDATE(string SHIFT_ID, string SHIFTNM, string SHIFTNMVN, string TIME_IN, string TIME_OUT, string UPDATE_UID, int ORDERINDEX, string STATUS)
        {
            OracleParameter[] parameters = new OracleParameter[9];
            parameters[0] = new OracleParameter("pSHIFT_ID", SHIFT_ID);
            parameters[1] = new OracleParameter("pSHIFTNM", SHIFTNM);
            parameters[2] = new OracleParameter("pSHIFTNMVN", SHIFTNMVN);
            parameters[3] = new OracleParameter("pTIME_IN", TIME_IN);
            parameters[4] = new OracleParameter("pTIME_OUT", TIME_OUT);
            parameters[5] = new OracleParameter("pUPDATE_UID", UPDATE_UID);
            parameters[6] = new OracleParameter("pORDERINDEX", ORDERINDEX);
            parameters[7] = new OracleParameter("pSTATUS", STATUS);
            parameters[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_DAILYLOG.SP_TIMESHIFT_UPDATE", parameters);
        }

        // Duy Hung 03/06/2014
        public static DataTable SP_TIMESHIFT_INSERT(string SHIFTNM, string SHIFTNMVN, string TIME_IN, string TIME_OUT, string CREATE_UID, int ORDERINDEX, string SHIFTKINDNM, string STATUS)
        {
            OracleParameter[] parameters = new OracleParameter[9];
            parameters[0] = new OracleParameter("pSHIFTNM", SHIFTNM);
            parameters[1] = new OracleParameter("pSHIFTNMVN", SHIFTNMVN);
            parameters[2] = new OracleParameter("pTIME_IN", TIME_IN);
            parameters[3] = new OracleParameter("pTIME_OUT", TIME_OUT);
            parameters[4] = new OracleParameter("pCREATE_UID", CREATE_UID);
            parameters[5] = new OracleParameter("pORDERINDEX", ORDERINDEX);
            parameters[6] = new OracleParameter("pSHIFTKINDNM", SHIFTKINDNM);
            parameters[7] = new OracleParameter("pSTATUS", STATUS);
            parameters[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_DAILYLOG.SP_TIMESHIFT_INSERT", parameters);
        }
    }
}