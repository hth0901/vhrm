using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class DailyDnILogConfirmAccess
    {
        public static DataTable LoadDailyDnILog(string corporation, string employeeId, string workDate, string workStatus)
        {
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.sp_DailyDnILogConfirm_Qry";
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pCorporation", corporation);
            parameters[1] = new OracleParameter("pEmployeeId", employeeId);
            parameters[2] = new OracleParameter("pWorkDate", workDate);
            parameters[3] = new OracleParameter("pWorkStatus", workStatus);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[5] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataSet_SP(query, parameters).Tables[0];
        }

        public static DataSet LoadDailyDnILog(string corporation, string employeeId, string workDate, string workStatus, int from, int to)
        {
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.sp_DailyLogConfirm_FROM_TO_Qry";
            OracleParameter[] parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("pCorporation", corporation);
            parameters[1] = new OracleParameter("pEmployeeId", employeeId);
            parameters[2] = new OracleParameter("pWorkDate", workDate);
            parameters[3] = new OracleParameter("pWorkStatus", workStatus);
            parameters[4] = new OracleParameter("pfrom", from);
            parameters[5] = new OracleParameter("pto", to);
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[7] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataSet_SP(query, parameters);
        }

        public static int SP_GET_TOTALCOUNT(string corporation, string employeeId, string workDate, string workStatus)
        {
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.SP_GET_TOTALCOUNT";
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("pCorporation", corporation);
            parameters[1] = new OracleParameter("pEmployeeId", employeeId);
            parameters[2] = new OracleParameter("pWorkDate", workDate);
            parameters[3] = new OracleParameter("pWorkStatus", workStatus);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(query, parameters);
            return int.Parse(dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "0");
        }

        public static DataTable LoadLog(string corporation, string employeeId, string workDate)
        {
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.sp_DailyDnILogConfirm_Qry2";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pCorporation", corporation);
            parameters[1] = new OracleParameter("pEmployeeId", employeeId);
            parameters[2] = new OracleParameter("pWorkDate", workDate);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable Save(DailyDnILogConfirmEntity entity)
        {
            OracleParameter[] parameters = new OracleParameter[20];
            parameters[0] = new OracleParameter("pEmployeeId", entity.sys_empid);
            parameters[1] = new OracleParameter("pDateWK", entity.Date_wk);
            parameters[2] = new OracleParameter("pShiftCD", entity.shiftcd);
            parameters[3] = new OracleParameter("pWorkkind", entity.Workkind);
            parameters[4] = new OracleParameter("pTimeIn", entity.TimeIn);
            parameters[5] = new OracleParameter("pTimeOut", entity.TimeOut);
            parameters[6] = new OracleParameter("pMinutesLate", entity.MinutesLate);
            parameters[7] = new OracleParameter("pMinutesSoon", entity.MinutesSoon);
            parameters[8] = new OracleParameter("pDeducTimeIn", entity.DeductTimeIn ?? "");
            parameters[9] = new OracleParameter("pDeductTimeOut", entity.DeductTimeOut ?? "");
            parameters[10] = new OracleParameter("pDeductTime", entity.DeductTime);
            parameters[11] = new OracleParameter("pDeductDay", entity.Deductday);
            parameters[12] = new OracleParameter("pRemark", OracleType.NVarChar) { Value = entity.Remark ?? "" };
            parameters[13] = new OracleParameter("pStartTime130", entity.StartTime130 ?? "");
            parameters[14] = new OracleParameter("pEndTime130", entity.EndTime130 ?? "");
            parameters[15] = new OracleParameter("pWorkHour130", entity.WorkHour130 );
            parameters[16] = new OracleParameter("pHisLog", entity.LogHistory);
            parameters[17] = new OracleParameter("pUserID", entity.UserID ?? "");
            parameters[18] = new OracleParameter("pLUNCHTIME", entity.LunchTime ?? "");
            parameters[19] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_DAILYLOGCONFIRM.sp_DailyDnILogConfirm_Save", parameters);
        }

        public static DataTable Confirm(DailyDnILogConfirmEntity entity)
        {
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pEmployeeId", entity.sys_empid);
            parameters[1] = new OracleParameter("pDateWK", entity.Date_wk);
            parameters[2] = new OracleParameter("pShiftCD", entity.shiftcd);
            parameters[3] = new OracleParameter("pConfirm_is", entity.Confirm_IS);
            parameters[4] = new OracleParameter("pUserID", entity.UserID ?? "");
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_DAILYLOGCONFIRM.sp_DailyDnILogConfirm_Confirm", parameters);
        }

        public static DataTable LogDataCreateByDept(string pWorkDate, string pDeptCode, string pSysEmpId,
                                string pStaffTimeIn, string pStaffTimeOut, string pWkTimeIn, string pWkTimeOut, string pUserID, string pWorkStatus)
        {
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.sp_LogDataCreateByDept";
            OracleParameter[] parameters = new OracleParameter[10];
            parameters[0] = new OracleParameter("pWorkDate", pWorkDate);
            parameters[1] = new OracleParameter("pDeptCode", pDeptCode);
            parameters[2] = new OracleParameter("pSysEmpId", pSysEmpId);
            parameters[3] = new OracleParameter("pStaffTimeIn", pStaffTimeIn);
            parameters[4] = new OracleParameter("pStaffTimeOut", pStaffTimeOut);
            parameters[5] = new OracleParameter("pWkTimeIn", pWkTimeIn);
            parameters[6] = new OracleParameter("pWkTimeOut", pWkTimeOut);
            parameters[7] = new OracleParameter("pUserID", pUserID);
            parameters[8] = new OracleParameter("pWorkStatus", pWorkStatus);  
            parameters[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable BatchConfirm(string pWorkDate, string pDeptCode, string pConfirm_is, string pUserID)
        {
            //pWorkDate varchar2, pDeptCode varchar2, pConfirm_is char, pUserID varchar2
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.sp_BatchConfirm";
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("pWorkDate", pWorkDate);
            parameters[1] = new OracleParameter("pDeptCode", pDeptCode);
            parameters[2] = new OracleParameter("pConfirm_is", pConfirm_is);
            parameters[3] = new OracleParameter("pUserID", pUserID);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable BatchConfirmEmpList(string pWorkDate, string pDeptCode, string pEmpList, string pConfirm_is, string pUserID)
        {
            //pWorkDate varchar2, pDeptCode varchar2, pConfirm_is char, pUserID varchar2
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.sp_BatchConfirmEmpList";
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pWorkDate", pWorkDate);
            parameters[1] = new OracleParameter("pDeptCode", pDeptCode);
            parameters[2] = new OracleParameter("pEmpList", pEmpList);
            parameters[3] = new OracleParameter("pConfirm_is", pConfirm_is);
            parameters[4] = new OracleParameter("pUserID", pUserID);
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable BatchInputData(string pDeptCode, DailyDnILogConfirmEntity entity, string pUserID)
        {
            /*pWorkDate varchar2, pDeptCode varchar2, pShiftCD varchar2, pWorkkind char, pTimeIn varchar2, pTimeOut varchar2,
            pMinutesLate int, pMinutesSoon int, pDeducTimeIn varchar2, pDeductTimeOut varchar2, pDeductDay float, pRemark nvarchar2,
            pStartTime130 varchar2, pEndTime130 varchar2,  pWorkHour130 float, pUserID varchar2 */
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.sp_BatchInput";
            OracleParameter[] parameters = new OracleParameter[18];
            parameters[0] = new OracleParameter("pWorkDate", entity.Date_wk);
            parameters[1] = new OracleParameter("pDeptCode", pDeptCode);
            parameters[2] = new OracleParameter("pShiftCD", entity.shiftcd);
            parameters[3] = new OracleParameter("pWorkkind", entity.Workkind);
            parameters[4] = new OracleParameter("pTimeIn", entity.TimeIn);
            parameters[5] = new OracleParameter("pTimeOut", entity.TimeOut);
            parameters[6] = new OracleParameter("pMinutesLate", entity.MinutesLate);
            parameters[7] = new OracleParameter("pMinutesSoon", entity.MinutesSoon);
            parameters[8] = new OracleParameter("pDeducTimeIn", entity.DeductTimeIn);
            parameters[9] = new OracleParameter("pDeductTimeOut", entity.DeductTimeOut);
            parameters[10] = new OracleParameter("pDeductTime",entity.DeductTime);
            parameters[11] = new OracleParameter("pDeductDay", entity.Deductday);
            parameters[12] = new OracleParameter("pRemark", OracleType.NVarChar) { Value = entity.Remark };
            parameters[13] = new OracleParameter("pStartTime130", entity.StartTime130);
            parameters[14] = new OracleParameter("pEndTime130", entity.EndTime130);
            parameters[15] = new OracleParameter("pWorkHour130", entity.WorkHour130);
            parameters[16] = new OracleParameter("pUserID", pUserID);
            parameters[17] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }


        public static DataTable BatchInputDataByEmplist(DailyDnILogConfirmEntity entity, string pUserID)
        {
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.sp_BatchInputEmpList";
            OracleParameter[] parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("pWorkDate", entity.Date_wk);
            parameters[1] = new OracleParameter("pSysEmpList", entity.sys_empid);
            parameters[2] = new OracleParameter("pWorkkind", entity.Workkind);
            parameters[3] = new OracleParameter("pTimeIn", entity.TimeIn);
            parameters[4] = new OracleParameter("pTimeOut", entity.TimeOut);
            parameters[5] = new OracleParameter("pRemark", OracleType.NVarChar) { Value = entity.Remark };
            parameters[6] = new OracleParameter("pUserID", pUserID);
            parameters[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        //update by ndhung 2014.10.05 -> check Role of user when reset confirm 
        public static DataTable Reset_Confirm(string pWorkdate,string pEmpid, string pUserID)
        {
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.SP_DELETE_CONFIRM";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pWorkDate", pWorkdate);
            parameters[1] = new OracleParameter("PSYSEMPID", pEmpid);
            parameters[2] = new OracleParameter("PUSERID", pUserID);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable LogDataUpdate_ByEmp(string pWorkDate, string pDeptCode, string pSysEmpId,
                                string pStaffTimeIn, string pStaffTimeOut, string pWkTimeIn, string pWkTimeOut, string pUserID, string pWorkStatus)
        {
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.SP_LOGDATAUPDATE_BYEMP";
            OracleParameter[] parameters = new OracleParameter[10];
            parameters[0] = new OracleParameter("pWorkDate", pWorkDate);
            parameters[1] = new OracleParameter("pDeptCode", pDeptCode);
            parameters[2] = new OracleParameter("pSysEmpId", pSysEmpId);
            parameters[3] = new OracleParameter("pStaffTimeIn", pStaffTimeIn);
            parameters[4] = new OracleParameter("pStaffTimeOut", pStaffTimeOut);
            parameters[5] = new OracleParameter("pWkTimeIn", pWkTimeIn);
            parameters[6] = new OracleParameter("pWkTimeOut", pWkTimeOut);
            parameters[7] = new OracleParameter("pUserID", pUserID);
            parameters[8] = new OracleParameter("pWorkStatus", pWorkStatus);  
            parameters[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        
    }
}