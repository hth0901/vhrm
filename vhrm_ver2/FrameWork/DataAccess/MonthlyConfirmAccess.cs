using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class MonthlyConfirmAccess
    {
       
        public static DataTable Load(string corporation, string employeeId,string month)
        {
            string query = "PKTIMESHEET_MONTHLYCONFIRM.sp_MonthlyConfirm_Qry";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pCorporation", corporation);
            parameters[1] = new OracleParameter("pEmployeeId", employeeId);
            parameters[2] = new OracleParameter("pMonth", month);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable LoadGridDetial(string corporation, string employeeId, string workDate,string contracno)
        {
            string query = "PKTIMESHEET_MONTHLYCONFIRM.sp_MonthlyConfirm_Qry2";
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("pCorporation", corporation);
            parameters[1] = new OracleParameter("pEmployeeId", employeeId);
            parameters[2] = new OracleParameter("pWorkDate", workDate);
            parameters[3] = new OracleParameter("pContracNo", contracno);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable Save(MonthlyConfirmEntity entity)
        {
            string spName = "PKTIMESHEET_MONTHLYCONFIRM.sp_MonthlyConfirm_Save";
            OracleParameter[] parameters = new OracleParameter[17];
            parameters[0] = new OracleParameter("p_EMPID", entity.EmployeeId);
            parameters[1] = new OracleParameter("p_CONTACT_NO", entity.ContractNo ?? "");
            parameters[2] = new OracleParameter("p_MONTH_LG", entity.MonthLog ?? "");
            parameters[3] = new OracleParameter("p_AMT_DAYWK", entity.AmountDayWork ?? "");
            parameters[4] = new OracleParameter("p_AMT_DAYSUB", entity.AmountDaySub ?? "");
            parameters[5] = new OracleParameter("p_AMT_OT3", entity.AmountOt3);
            parameters[6] = new OracleParameter("p_AMT_OT15", entity.AmountOt1A5 ?? "");
            parameters[7] = new OracleParameter("p_AMT_OT195", entity.AmountOt1A95);
            parameters[8] = new OracleParameter("p_AMT_OT2", entity.AmountOt2 ?? "");
            parameters[9] = new OracleParameter("p_AMT_SFT03", entity.AmountSft0A3);
            parameters[10] = new OracleParameter("p_AMT_BREAKHOUR", entity.AmountBreakHour ?? "");
            parameters[11] = new OracleParameter("p_AMT_HOUR15", entity.AmountHour1A5);
            parameters[12] = new OracleParameter("p_CONFIRM_IS", entity.IsConfirm ?? "");
            parameters[13] = new OracleParameter("p_UID", entity.ui);
            parameters[14] = new OracleParameter("p_CONFIRM_DT", entity.ConfirmDate );
            parameters[15] = new OracleParameter("p_CONFIRM_UID", entity.ui);
            parameters[16] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}