using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class EmpWKDaysMonthlyAccess
    {
        
        public static DataSet AttendanceStaff_Query(string pMonth, string pEmpId)
        {
            string query = "PKTIMESHEET_ATTENDACEMONTHLY.sp_AttendanceStaff_Qry";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pMonth", pMonth);
            parameters[1] = new OracleParameter("pEmpId", pEmpId);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[3] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataSet_SP(query, parameters);
        }

        public static DataTable AttendanceStaff_Save(DailyDnILogConfirmEntity entity)
        {
            OracleParameter[] parameters = new OracleParameter[17];
            parameters[0] = new OracleParameter("pEmployeeId", entity.sys_empid);
            parameters[1] = new OracleParameter("pDateWK", entity.Date_wk);
            parameters[2] = new OracleParameter("pShiftCD", entity.shiftcd);
            parameters[3] = new OracleParameter("pWorkkind", entity.Workkind);
            parameters[4] = new OracleParameter("pTimeIn", entity.TimeIn ?? "");
            parameters[5] = new OracleParameter("pTimeOut", entity.TimeOut ?? "");
            parameters[6] = new OracleParameter("pMinutesLate", entity.MinutesLate);
            parameters[7] = new OracleParameter("pMinutesSoon", entity.MinutesSoon);
            parameters[8] = new OracleParameter("pDeducTimeIn", entity.DeductTimeIn ?? "");
            parameters[9] = new OracleParameter("pDeductTimeOut", entity.DeductTimeOut ?? "");
            parameters[10] = new OracleParameter("pDeductDay", entity.Deductday);

            parameters[11] = new OracleParameter("pRemark", OracleType.NVarChar) { Value = entity.Remark ?? "" };
            parameters[12] = new OracleParameter("pConfirm_is", entity.Confirm_IS ?? "");
            parameters[13] = new OracleParameter("pConfirm_UID", entity.Confirm_UID ?? "");
            parameters[14] = new OracleParameter("pUserID", entity.UserID ?? "");
            parameters[15] = new OracleParameter("pLogHistory", entity.LogHistory ?? "");
            parameters[16] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_ATTENDACEMONTHLY.sp_AttendanceStaff_Save", parameters);
        }

        public static DataTable GetLogHistory(string pDate, string pEmpId)
        {
            string query = "PKTIMESHEET_ATTENDACEMONTHLY.sp_getLogHistory";
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pDate", pDate);
            parameters[1] = new OracleParameter("pEmpId", pEmpId);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

    }
}