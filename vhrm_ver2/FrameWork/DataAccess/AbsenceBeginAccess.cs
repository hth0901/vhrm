using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class AbsenceBeginAccess
    {
        public  DataTable LoadAbsenceBegin(string corporation, string reason, string employeeId, string fromDate, string toDate, string pReasonDetail)
        {
            string query = "PKINSURANCE_ABSENCE_BEGIN.SP_INS_ABSENCE_Begin_QUERY";
            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("pCorporation", corporation ?? "");
            parameters[1] = new OracleParameter("pReason", reason ?? "");
            parameters[2] = new OracleParameter("pEmployeeId", employeeId ?? "");
            parameters[3] = new OracleParameter("pFromDate", fromDate ?? "");
            parameters[4] = new OracleParameter("pToDate", toDate ?? "");
            parameters[5] = new OracleParameter("pReasonDetail", pReasonDetail ?? "");
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public  DataTable UpdateData(string workTask, AbsenceDetailEntity entity)
        {
            string query = "PKINSURANCE_ABSENCE_BEGIN.sp_SAVE_T_INS_ABSENCE";
            OracleParameter[] parameters = new OracleParameter[13];
            parameters[0] = new OracleParameter("pWorkingTag", workTask ?? "");
            parameters[1] = new OracleParameter("pSysEmpID", entity.SysEmpId ?? "");
            parameters[2] = new OracleParameter("pSEQ_NO",value:0);
            parameters[3] = new OracleParameter("pCLSID", entity.Clsid ?? "");
            parameters[4] = new OracleParameter("pFromdate", entity.FromDate ?? "");
            parameters[5] = new OracleParameter("pTodate", entity.ToDate ?? "");
            parameters[6] = new OracleParameter("ptotalDate", value: entity.TotalDate);
            parameters[7] = new OracleParameter("pPbno",value:1);
            parameters[8] = new OracleParameter("pCondition", entity.Condition ?? "");
            parameters[9] = new OracleParameter("pRemark", entity.Remark ?? "");
            parameters[10] = new OracleParameter("pUID", entity.ConfirmUid ?? "");
            parameters[11] = new OracleParameter("pPbym", entity.Pbym ?? "");
            parameters[12] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);

        }
    }
}