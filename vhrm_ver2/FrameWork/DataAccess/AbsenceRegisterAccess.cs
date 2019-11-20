using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class AbsenceRegisterAccess
    {
        public static DataTable loadComboboxAbsence(string pIsAbsence) {
            string query = "PKTIMESHEET_ABSENCEREGISTER.SP_LOAD_COMBOBOX_ABSENCE";
            OracleParameter [] para = new OracleParameter[2];
            para[0] = new OracleParameter("pIsAbsence", pIsAbsence);
            para[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, para);
        }

        public static DataTable Load(string dept,string empid, string fromdate, string todate,string WorkingStatus, string AbsenceResion)
        {
            string query = "PKTIMESHEET_ABSENCEREGISTER.SP_ABSENCEREGISTER_QRY";
            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("pDEPT", dept);
            parameters[1] = new OracleParameter("pEMPID", empid ?? "");
            parameters[2] = new OracleParameter("pFROMDATE", fromdate ?? "");
            parameters[3] = new OracleParameter("pTODATE", todate ?? "");
            parameters[4] = new OracleParameter("PWORKINGSTATUS", WorkingStatus ?? "");
            parameters[5] = new OracleParameter("pAbsence", AbsenceResion ?? "");
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable Save(string workingTag, AbsenceRegisterEntity entity)
        {
            string spName = "PKTIMESHEET_ABSENCEREGISTER.SP_ABSENCEREGISTRY_SAVE";
            OracleParameter[] parameters = new OracleParameter[12];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag ?? "");
            parameters[1] = new OracleParameter("pSYS_EMPID", entity.Sysempid);
            parameters[2] = new OracleParameter("pSEQ_NO", entity.Seqno);
            parameters[3] = new OracleParameter("pFROMDATE", entity.Fromdate ?? "");
            parameters[4] = new OracleParameter("pTODATE", entity.Todate ?? "");
            parameters[5] = new OracleParameter("pTOTALDAY", value:entity.Totalday);
            parameters[6] = new OracleParameter("pANNUALDAY",value: entity.Annualday);
            parameters[7] = new OracleParameter("pREASON", entity.Reason ?? "");
            parameters[8] = new OracleParameter("pREMARK",entity.Remarks ?? "");
            parameters[9] = new OracleParameter("pCOMFIRM_IS", entity.ConfirmIs ?? "");
            parameters[10] = new OracleParameter("pUSERID",entity.UserId ?? "");
            parameters[11] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
        public static DataTable Load_checkstatusemployee(string dept, string empid, string pfdate, string ptdate,string pIsAbsence,string planguage, string pReason)
        {
            string query = "PKTIMESHEET_CHECKSTATUSOFEMP.sp_CheckStatusOfEmp_Qry";
            OracleParameter[] parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("pDeptCd", dept);
            parameters[1] = new OracleParameter("pEmployeeId", empid ?? "");
            parameters[2] = new OracleParameter("pIsAbsence", pIsAbsence ?? "");
            parameters[3] = new OracleParameter("pFDate", pfdate);
            parameters[4] = new OracleParameter("pTDate", ptdate);
            parameters[5] = new OracleParameter("planguage", planguage ?? "");
            parameters[6] = new OracleParameter("pReason", pReason ?? "");
            parameters[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable SP_CHECK_REGISTER_ANNUALEAVE(string PUSERID)
        {
            string query = "PKTIMESHEET_ABSENCEREGISTER.SP_CHECK_REGISTER_ANNUALEAVE";
            OracleParameter[] para = new OracleParameter[2];
            para[0] = new OracleParameter("PUSERID", PUSERID);
            para[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, para);
        }

        // add by ndhung 2017.09.19 -> thêm để sửa ngày thai sản quay lại làm sớm 
        public static DataTable Update_EndDateMaternityLeave(string sys_empid, string fromdate, string todate, string userId)
        {
            string query = "PKTIMESHEET_ABSENCEREGISTER.SP_UPDATE_END_MATERNITYLEAVE";
            OracleParameter[] para = new OracleParameter[5];
            para[0] = new OracleParameter("PSYS_EMPID", sys_empid);
            para[1] = new OracleParameter("PFROMDATE", fromdate);
            para[2] = new OracleParameter("PTODATE", todate);
            para[3] = new OracleParameter("PUSERID", userId);
            para[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, para);
        }
    }
}