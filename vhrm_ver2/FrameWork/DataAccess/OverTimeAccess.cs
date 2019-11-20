using System;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class OverTimeAccess
    {
        #region Overtime Registration Methods
        public static DataTable Query_OTRegistration(string pWorkingTag, string pCoporation, string pEmpId, string OTDateFrom, string OTDateTo,string OTKind)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_GET_OTREGISTRATION";
            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pDeptcode", pCoporation);
            param[2] = new OracleParameter("pEmpId", pEmpId);
            param[3] = new OracleParameter("pOTDate1", OTDateFrom);
            param[4] = new OracleParameter("pOTDate2", OTDateTo);
            param[5] = new OracleParameter("pOTKind",OTKind);
            param[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }
        public static DataTable LoadListEmpRegistration(string pCoporation, string pOtDate)
        {
            string spName = "PKTIMESHEET_OVERTIME.sp_LoadDataBeginOverTime";
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pDeptcode", pCoporation);
            param[1] = new OracleParameter("pOTDate", pOtDate);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        //ver1
        public static DataTable Save_OTRegistrationForCorporation_BK(string pWorkingTag, OverTimeEntity enty, string pLoginID)
        { 
            string spName = "PKTIMESHEET_OVERTIME.sp_save_OTREGISTRANTIONListEmp";
            OracleParameter[] para = new OracleParameter[13];
            para[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            para[1] = new OracleParameter("pOTDate", enty.OTDate);
            para[2] = new OracleParameter("pDEPTCODE", enty.Corporation);
            para[3] = new OracleParameter("pOTKind", enty.OTKind);
            para[4] = new OracleParameter("pPlanTimeIn", enty.PlanTimeIn);
            para[5] = new OracleParameter("pPlanTimeOut", enty.PlanTimeOut);
            para[6] = new OracleParameter("pPlanOTHour", enty.PlanOTHour);
            para[7] = new OracleParameter("pPlanOTBreak", enty.PlanOTBreak);
            para[8] = new OracleParameter("pRegisterId", enty.RegisterId);
            para[9] = new OracleParameter("pRegistryDate", enty.RegistryDate);
            para[10] = new OracleParameter("pLoginID", pLoginID);
            para[11] = new OracleParameter("pSYS_EMPID", enty.EmpId);
            para[12] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        //ver2
        public static DataTable Save_OTRegistrationForCorporation(string pWorkingTag, OverTimeEntity enty, string pLoginID)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_SAVE_OTREGISTRANTION_LIST";
            OracleParameter[] para = new OracleParameter[6];
            para[0] = new OracleParameter("pOTDate", enty.OTDate);
            //para[1] = new OracleParameter("pOTKind", enty.OTKind);
            para[1] = new OracleParameter("pPlanTimeIn", enty.PlanTimeIn);
            para[2] = new OracleParameter("pPlanTimeOut", enty.PlanTimeOut);
            para[3] = new OracleParameter("pLoginID", pLoginID);
            para[4] = new OracleParameter("pSYS_EMPID", enty.EmpId);
            para[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        public static DataTable Save_OTRegistrationforLine(string pWorkingTag, OverTimeEntity enty, string pLoginID)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_SAVE_OTREGISTRANTION_LINE";
            OracleParameter[] para = new OracleParameter[6];
            para[0] = new OracleParameter("pOTDate", enty.OTDate);
            //para[1] = new OracleParameter("pOTKind", enty.OTKind);
            para[1] = new OracleParameter("pPlanTimeIn", enty.PlanTimeIn);
            para[2] = new OracleParameter("pPlanTimeOut", enty.PlanTimeOut);
            para[3] = new OracleParameter("pLoginID", pLoginID);
            para[4] = new OracleParameter("PDEPTCODE", enty.Corporation);
            para[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        public static DataTable CheckOvertimeDataForLine(string PDEPTCODE , string date, string otKind)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_CHECK_DUPLICATEforLine";
            OracleParameter[] para = new OracleParameter[4];
            para[0] = new OracleParameter("PDEPTCODE", PDEPTCODE);
            para[1] = new OracleParameter("pOTDate", date);
            para[2] = new OracleParameter("pOTKind", otKind);
            para[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }

        public static DataTable CheckIsHoliday(string date)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_CHECKIS_HOLIDAY";
            OracleParameter[] para = new OracleParameter[2];
            para[0] = new OracleParameter("pDATE", date);
            para[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }

        public static DataTable CheckOvertimeData(string empList, string date, string otKind)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_CHECK_DUPLICATE";
            OracleParameter[] para = new OracleParameter[4];
            para[0] = new OracleParameter("pSYS_EMPID", empList);
            para[1] = new OracleParameter("pOTDate", date);
            para[2] = new OracleParameter("pOTKind", otKind);
            para[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }

        public static DataTable Save_OTRegistration(string pWorkingTag, OverTimeEntity enty, string pLoginID)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_SAVE_OTREGISTRATION";
            OracleParameter[] para = new OracleParameter[13];
            para[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            para[1] = new OracleParameter("pDAYWK", enty.OTDate??"");
            para[2] = new OracleParameter("pEmpId", enty.EmpId ?? "");
            para[3] = new OracleParameter("pOTKind", enty.OTKind ?? "");
            para[4] = new OracleParameter("pTimeIn", enty.PlanTimeIn ?? "");
            para[5] = new OracleParameter("pTimeOut", enty.PlanTimeOut ?? "");
            para[6] = new OracleParameter("pOTHour",  enty.PlanOTHour);
            para[7] = new OracleParameter("pOTBreak", enty.PlanOTBreak );
            para[8] = new OracleParameter("pRegisterId", enty.RegisterId ?? "");
            para[9] = new OracleParameter("pDeptCode", enty.DeptCode ?? "");
            para[10] = new OracleParameter("pCreateId", enty.CreateId ?? "");
            para[11] = new OracleParameter("pCreateDT", enty.CreateDate);
            para[12] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        
        #endregion

        #region New register overtime -> ndhung 2016.01.06

        /// <summary>
        /// added by ndhung 2014/07/14 -> register OT by sending param string
        /// </summary>
        /// <param name="pstring"></param> string store sys_empID, OTKind, DAYWK split by "|"
        /// <param name="pLoginID"></param> user update
        /// <returns></returns>
        public static DataTable BatchAccept_byString(string pstring, string pLoginID, string pAcceptCheck)
        {
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pPARAM", pstring);
            parameters[1] = new OracleParameter("pUSER_ID", pLoginID);
            parameters[2] = new OracleParameter("pACCEPT_CHECK", pAcceptCheck);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PKTIMESHEET_OVERTIME.SP_BATCH_ACCEPT_BY_STRING", parameters);
        }

        /// <summary>
        /// added by ndhung 2016.01.06 -> BATCH REGISTER OT WITHOUT OTKIND
        /// </summary>
        /// <param name="enty"></param> OVERTIME ENTITY
        /// <param name="checkLine"></param> TRUE IF CHKLINE IS CHECKED
        /// <param name="pLoginID"></param> USERID
        /// <returns></returns>
        public static DataTable BatchRegisterOverTime(OverTimeEntity enty, bool checkLine, string pLoginID)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_BATCH_REGISTER_OT";

            OracleParameter[] para = new OracleParameter[8];

            para[0] = new OracleParameter("pOTDATE", enty.OTDate);
            para[1] = new OracleParameter("pDEPTCODE", enty.Corporation);
            para[2] = new OracleParameter("pTIMEIN", enty.PlanTimeIn);
            para[3] = new OracleParameter("pTIMEOUT", enty.PlanTimeOut);
            para[4] = new OracleParameter("pCHECKLINE", (checkLine ? "Y" : "N"));
            para[5] = new OracleParameter("pSYS_EMPID", enty.EmpId);
            para[6] = new OracleParameter("pUSERID", pLoginID);
            para[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(spName, para);
        }

        #endregion


        #region Overtime Confirmation Methods
        public static DataTable Query_OTConfirmation(string pWorkingTag, string pCoporation, string pEmpId, string pOTKind, string OTDateFrom, string OTDateTo, string planguage)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_GET_OTCONFIRMATION";
            OracleParameter[] param = new OracleParameter[8];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pDeptcode", pCoporation);
            param[2] = new OracleParameter("pEmpId", pEmpId);
            param[3] = new OracleParameter("pOTKind", pOTKind);
            param[4] = new OracleParameter("pOTDate1", OTDateFrom);
            param[5] = new OracleParameter("pOTDate2", OTDateTo);
            param[6] = new OracleParameter("planguage", planguage);
            param[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }

        public static DataTable Save_OTConfirmation(string pWorkingTag, OverTimeEntity enty, string pLoginID)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_SAVE_OTCONFIRMATION";
            OracleParameter[] para = new OracleParameter[17];
            para[0] = new OracleParameter("pOTDate", enty.OTDate);
            para[1] = new OracleParameter("pEmpId", enty.EmpId);
            para[2] = new OracleParameter("pOTKind", enty.OTKind);
            para[3] = new OracleParameter("pAdjTimeIn", enty.AdjTimeIn);
            para[4] = new OracleParameter("pAdjTimeOut", enty.AdjTimeOut);
            para[5] = new OracleParameter("pAdjOTHour", enty.AdjOTHour);
            para[6] = new OracleParameter("pAdjOTBreak", enty.AdjOTBreak);
            para[7] = new OracleParameter("pConfirmCheck", enty.ConfirmCheck);
            para[8] = new OracleParameter("pLoginID", pLoginID);
            para[9] = new OracleParameter("pHislogdate",enty.Hislogdate);
            para[10] = new OracleParameter("pHourTimein", enty.Nhour_timein);
            para[11] = new OracleParameter("pHourTimeOut", enty.Nhour_timeout);
            para[12] = new OracleParameter("pHourTotal", enty.Nhour_Total);  
            para[13] = new OracleParameter("pDEDUCT_TIME_START", enty.DEDUCT_TIME_START??"");
            para[14] = new OracleParameter("pDEDUCT_TIME_END", enty.DEDUCT_TIME_END??"");
            para[15] = new OracleParameter("pDEDUCT_HOUR",value:enty.DEDUCT_HOUR);
            para[16] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        public static DataTable AcceptOtregistrationForCorporation(OverTimeEntity enty, string pLoginID)
        {
            string spName = "PKTIMESHEET_OVERTIME.sp_Confirm_CORP_OTREGISTRATION";
            OracleParameter[] para = new OracleParameter[7];
            para[0] = new OracleParameter("pOTDate", enty.OTDate);
            para[1] = new OracleParameter("pDEPTCODE", enty.Corporation);
            para[2] = new OracleParameter("pOTKind", enty.OTKind);
            para[3] = new OracleParameter("pAcceptCheck", enty.ConfirmCheck);
            para[4] = new OracleParameter("plogin", pLoginID);
            para[5] = new OracleParameter("pSYS_EMPID", enty.EmpId);
            para[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        //SP_SAVE_OTCONFIRMATION
        public static DataTable Save_OTConfirmationForCorporation(OverTimeEntity enty, string pLoginID)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_SAVE_CORP_OTCONFIRMATION";
            OracleParameter[] para = new OracleParameter[5];
            para[0] = new OracleParameter("pSYS_EMPID", enty.EmpId);
            para[1] = new OracleParameter("pAT_TimeIn", enty.AdjTimeIn);
            para[2] = new OracleParameter("pAT_TimeOut", enty.AdjTimeOut);
            para[3] = new OracleParameter("pLoginID", pLoginID);
            para[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        public static DataTable Confirm_OTConfirmationForCorporation(OverTimeEntity enty, string pLoginID)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_Confirm_CORP_OTCONFIRMATION";
            OracleParameter[] para = new OracleParameter[4];
            //para[0] = new OracleParameter("pOTDate", enty.OTDate);
            //para[1] = new OracleParameter("pDEPTCODE", enty.Corporation);
            //para[2] = new OracleParameter("pOTKind", enty.OTKind);
            para[0] = new OracleParameter("pSYS_EMPID", enty.EmpId); 
            para[1] = new OracleParameter("pCONFIRM_IS", enty.ConfirmCheck);
            para[2] = new OracleParameter("pLoginID", pLoginID);
            para[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        public static DataTable GetLogHistory(string pDate, string pEmpId)
        {
            string query = "PKTIMESHEET_OVERTIME.sp_getLogHistory";
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pDate", pDate);
            parameters[1] = new OracleParameter("pEmpId", pEmpId);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable GetLogShowTable(string pDate, string pEmpId)
        {
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.sp_getLogHistory";
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pDate", pDate);
            parameters[1] = new OracleParameter("pEmpId", pEmpId);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable LogDataUpdate(OverTimeEntity enty)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_LOG_DATA_UPDATE";
            OracleParameter[] para = new OracleParameter[4];
            para[0] = new OracleParameter("pDEPTCODE", enty.Corporation);
            para[1] = new OracleParameter("pOTDate", enty.OTDate);
            para[2] = new OracleParameter("pSYS_EMPID", enty.EmpId);
            para[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        public static DataTable DeleteLog(string pOtdate,string pEmpid,string pOtkind)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_LOG_DATA_UPDATE";
            OracleParameter[] para = new OracleParameter[4];
            para[0] = new OracleParameter("pOTDate", pOtdate);
            para[1] = new OracleParameter("pEmpId", pEmpid);
            para[2] = new OracleParameter("pOTKind", pOtkind);
            para[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }

        public static DataTable SP_OVERTIME_REGISTRATION_DEL(string PDAYWK, string PSYSEMPID, string OTKind)
        {
            string spName = "PKTIMESHEET_OVERTIME.SP_OVERTIME_REGISTRATION_DEL";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("PDAYWK", PDAYWK);
            param[1] = new OracleParameter("PSYSEMPID", PSYSEMPID);
            param[2] = new OracleParameter("POTKIND", OTKind);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }

        #endregion
    }
}