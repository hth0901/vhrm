using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class AnnualLeaveSettingAccess
    {
        public static DataTable loadGridAnnualLeaveSetting()
        {
            string spName = "PKTIMESHEET_ANNUALLEAVESETTING.sp_T_TS_CM_ANNUALLEAVE_Query";
             OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName,param);
        }
        public static DataTable SaveAnnualLeaveSetting(string workingTag, AnnualLeaveSettingEntity AnnualLeaveEntity)
        {
            string spName = "PKTIMESHEET_ANNUALLEAVESETTING.sp_T_TS_CM_ANNUALLEAVE_SAVE";
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pWorking", workingTag ?? "");
            parameters[1] = new OracleParameter("pJobcd", AnnualLeaveEntity.JobCD);
            parameters[2] = new OracleParameter("pAldays", AnnualLeaveEntity.Aldays);
            parameters[3] = new OracleParameter("pAlyears", AnnualLeaveEntity.Alyears);
            parameters[4] = new OracleParameter("pUID", AnnualLeaveEntity.UID);
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
      #region Annual leave
        public  DataTable LoadGridAnnualLeave(string pDeptcode, string pYear, string pSysempid, string pStatus)
        {
            string spName = "PKTIMESHEET_ANNUALLEAVE_STATUS.SP_ANNUALLEAVE_QRY";
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pDEPTCODE", pDeptcode);
            param[1] = new OracleParameter("pMonth", pYear);
            param[2] = new OracleParameter("pSYSEMPID", pSysempid??"");
            param[3] = new OracleParameter("pStatus", pStatus ?? "");
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }
        public DataTable ExecutionRow(string working ,AnnualLeaveCreateEntity entity)
        {
            string spName = "PKTIMESHEET_ANNUALLEAVE_STATUS.sp_T_PR_ANNUALLEAVE_Execution";
           OracleParameter[] param = new OracleParameter[8];
            param[0] = new OracleParameter("pWorkingTag", working);
            param[1] = new OracleParameter("pLogin", entity.login ?? "");
            param[2] = new OracleParameter("pPAYABLEDAYS", value: entity.PAYABLEDAYS);
            param[3] = new OracleParameter("pPAYTYPE", entity.PayType ?? "");
            param[4] = new OracleParameter("pPBYY", entity.Year ?? "");
            param[5] = new OracleParameter("pSYS_EMPID", entity.Sys ?? "");
            param[6] = new OracleParameter("pDUTY", entity.Position ?? "");
            param[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }
        public DataTable CreateTableAnnualLeave()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Login");
            dt.Columns.Add("PAYABLEDAYS",typeof(Int32));
            dt.Columns.Add("PAYTYPE");
            dt.Columns.Add("PBYY");
            dt.Columns.Add("SYS_EMPID");
            dt.Columns.Add("pWorkingTag");
            dt.Columns.Add("DUTY");
            return dt;
        }
        public bool SaveAllAnualleaveDattable(DataTable dtAnnualLeave)
        {
            bool result = false;
            ConnectionHelper cnHelper = new ConnectionHelper();

            using (OracleConnection sqlConnect = cnHelper.Connect())
            {
                OracleTransaction sqlTran = sqlConnect.BeginTransaction();

                OracleCommand command = new OracleCommand("PKTIMESHEET_ANNUALLEAVE_STATUS.sp_T_PR_ANNUALLEAVE_SaveTable", sqlConnect);
                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;
                command.Transaction = sqlTran;
                command.Parameters.Add("pLogin", OracleType.Char, 20, "Login");
                command.Parameters.Add("pPAYABLEDAYS", OracleType.Int32,20,"PAYABLEDAYS");
                command.Parameters.Add("pPAYTYPE", OracleType.Char, 4, "PAYTYPE");
                command.Parameters.Add("pPBYY", OracleType.Char, 6, "PBYY");
                command.Parameters.Add("pSYS_EMPID", OracleType.Char,8, "SYS_EMPID");
                command.Parameters.Add("pDUTY", OracleType.Char, 8, "DUTY");
                OracleDataAdapter adpt = new OracleDataAdapter();
                adpt.InsertCommand = command;
                // Specify the number of records to be Inserted/Updated in one go. Default is 1.
                adpt.UpdateBatchSize = 2;
                try
                {
                    int recordsInserted = adpt.Update(dtAnnualLeave);
                    result = (recordsInserted != 0);
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    sqlConnect.Close();
                }
            }
            return result;
        }
        public bool ConfirmAllData(DataTable dtAnnualLeave)
        {
            bool result = false;
            ConnectionHelper cnHelper = new ConnectionHelper();

            using (OracleConnection sqlConnect = cnHelper.Connect())
            {
                OracleTransaction sqlTran = sqlConnect.BeginTransaction();

                OracleCommand command = new OracleCommand("PKTIMESHEET_ANNUALLEAVE_STATUS.sp_T_PR_ANNUALLEAVE_Confirm", sqlConnect);
                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;
                command.Transaction = sqlTran;
                command.Parameters.Add("pLogin", OracleType.Char, 20, "Login");
                command.Parameters.Add("pSYS_EMPID", OracleType.Char, 8, "SYS_EMPID");
                command.Parameters.Add("pPBYY", OracleType.Char,4 , "PBYY");
                OracleDataAdapter adpt = new OracleDataAdapter();
                adpt.InsertCommand = command;
                // Specify the number of records to be Inserted/Updated in one go. Default is 1.
                adpt.UpdateBatchSize = 2;
                try
                {
                    int recordsInserted = adpt.Update(dtAnnualLeave);
                    result = (recordsInserted != 0);
                    sqlTran.Commit();
                 }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    sqlConnect.Close();
                }
            }
            return result;
        }
        public DataTable ConfirmByCorporation(string loginId, string Year, string depcode)
        {
            string spName = "PKTIMESHEET_ANNUALLEAVE_STATUS.sp_ANNUALLEAVE_CRFByDepCode";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pLogin", loginId);
            param[1] = new OracleParameter("pPBYY", Year ?? "");
            param[2] = new OracleParameter("pDepCode", depcode);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }


        // report total annualleave
        public DataTable GetDataReport(string deptcode, string pMonth, string pSysEmpID, string pStatus)
        {
            string spName = "PKTIEM_ANNUALLEAVE_PAYMENT.SP_TOTALANNUALLEAVE_VIEW";
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("PDEPTCODE", deptcode);
            param[1] = new OracleParameter("PMONTH", pMonth);
            param[2] = new OracleParameter("PSYSEMPID", pSysEmpID);
            param[3] = new OracleParameter("PSTATUS", pStatus);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(spName, param);
        }
        #endregion
        #region Pay Annual Leave 
        public DataTable GetPayAnnualLeave(string pDeptcode, string pYear, string pSysempid)
        {
            string spName = "PKTIEM_ANNUALLEAVE_Payment.SP_PAYANNUALLEAVE_QRY";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pDEPTCODE", pDeptcode);
            param[1] = new OracleParameter("PENDDATE", pYear);
            param[2] = new OracleParameter("pSYSEMPID", pSysempid ?? "");
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }
        public DataTable GetAdjustDateLeave(string pYear, string pSysempid)
        {
            string spName = "PKTIEM_ANNUALLEAVE_Payment.SP_PAYANNUALLEAVE_ADJUST";
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("PENDDATE", pYear);
            param[1] = new OracleParameter("PSYSEMPID", pSysempid ?? "");
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }
        public DataTable SaveAnnualLeave(PaymentAnnualLeave paymentAnnual, string logid, string pworkingtag)
        {
            string spName = "PKTIEM_ANNUALLEAVE_Payment.SP_SAVE_PAYMENTANNUALLEAVE";
            OracleParameter[] param = new OracleParameter[14];
            param[0] = new OracleParameter("PWORKINGTAG", pworkingtag);
            param[1] = new OracleParameter("PLOGIN", logid ?? "");
            param[2] = new OracleParameter("PSYS_EMPID", paymentAnnual.SysEmpid);
            param[3] = new OracleParameter("PSTARTDATE", paymentAnnual.Startdate ?? "");
            param[4] = new OracleParameter("PENDDATE", paymentAnnual.Enddate ?? "");
            param[5] = new OracleParameter("PPAYDAY", value: paymentAnnual.Payday);
            param[6] = new OracleParameter("PBASIC_SALARY", value: paymentAnnual.BasicSalary);
            param[7] = new OracleParameter("PALLOWANCE", value: paymentAnnual.Allowance);
            param[8] = new OracleParameter("PISCONFIRM", paymentAnnual.ISCONFIRM ?? "");
            param[9] = new OracleParameter("PLEAVEDAYS", value: paymentAnnual.LeaveDays);
            param[10] = new OracleParameter("PUSEDDAYS", value: paymentAnnual.UsedDays);
            param[11] = new OracleParameter("PREMAINDAYS", value: paymentAnnual.RemainDays);
            param[12] = new OracleParameter("pPBYY", paymentAnnual.PBYY ?? "");
            param[13] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }
        public bool SaveAllPaymentAnualLeaveDatatable(DataTable dtAnnualLeave)
        {
            bool result = false;
            ConnectionHelper cnHelper = new ConnectionHelper();

            using (OracleConnection sqlConnect = cnHelper.Connect())
            {
                OracleTransaction sqlTran = sqlConnect.BeginTransaction();

                OracleCommand command = new OracleCommand("PKTIEM_ANNUALLEAVE_PAYMENT.SP_SAVETATABLE_PAYANNUALLEAVE", sqlConnect);
                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;
                command.Transaction = sqlTran;
                command.Parameters.Add("pLogin", OracleType.Char, 20, "Login");
                command.Parameters.Add("PSYS_EMPID", OracleType.Char, 8, "SYS_EMPID");
                command.Parameters.Add("PSTARTDATE", OracleType.Char, 8, "STARTDATE");
                command.Parameters.Add("PENDDATE", OracleType.Char, 8, "ENDDATE");
                command.Parameters.Add("PPAYDAY", OracleType.Int32,20,"PAYDAY");
                command.Parameters.Add("PBASIC_SALARY", OracleType.Float, 19,"BASIC_SALARY");
                command.Parameters.Add("PALLOWANCE", OracleType.Float,19, "ALLOWANCE");
                command.Parameters.Add("PLEAVEDAYS", OracleType.Int32, 20, "LEAVEDAYS");
                command.Parameters.Add("PUSEDDAYS", OracleType.Int32, 20, "USEDDAYS");
                command.Parameters.Add("PREMAINDAYS", OracleType.Int32, 20, "REMAINDAYS");
                command.Parameters.Add("pPBYY", OracleType.Char,4, "PBYY");
                OracleDataAdapter adpt = new OracleDataAdapter();
                adpt.InsertCommand = command;
                // Specify the number of records to be Inserted/Updated in one go. Default is 1.
                adpt.UpdateBatchSize = 2;
                try
                {
                    int recordsInserted = adpt.Update(dtAnnualLeave);
                    result = (recordsInserted != 0);
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    sqlConnect.Close();
                }
            }
            return result;
        }
        public bool ConfirmAllPayAnnualLeave(DataTable dtAnnualLeave)
        {
            bool result = false;
            ConnectionHelper cnHelper = new ConnectionHelper();

            using (OracleConnection sqlConnect = cnHelper.Connect())
            {
                OracleTransaction sqlTran = sqlConnect.BeginTransaction();

                OracleCommand command = new OracleCommand("PKTIEM_ANNUALLEAVE_PAYMENT.SP_PAYANNUALLEAVE_CONFIRMTable", sqlConnect);
                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;
                command.Transaction = sqlTran;
                command.Parameters.Add("pLogin", OracleType.Char, 20, "Login");
                command.Parameters.Add("PSYS_EMPID", OracleType.Char, 8, "SYS_EMPID");
                command.Parameters.Add("PSTARTDATE", OracleType.Char, 8, "STARTDATE");
                command.Parameters.Add("pPBYY", OracleType.Char, 4, "PBYY");
                OracleDataAdapter adpt = new OracleDataAdapter();
                adpt.InsertCommand = command;
                // Specify the number of records to be Inserted/Updated in one go. Default is 1.
                adpt.UpdateBatchSize = 2;
                try
                {
                    int recordsInserted = adpt.Update(dtAnnualLeave);
                    result = (recordsInserted != 0);
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    sqlConnect.Close();
                }
            }
            return result;
        }
        public DataTable CreateDataAnnualLeave()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Login");
            dt.Columns.Add("SYS_EMPID", typeof(Int32));
            dt.Columns.Add("STARTDATE");
            dt.Columns.Add("ENDDATE");
            dt.Columns.Add("PAYDAY", typeof(Int32));
            dt.Columns.Add("BASIC_SALARY", typeof(float));
            dt.Columns.Add("ALLOWANCE", typeof(float));
            dt.Columns.Add("LEAVEDAYS", typeof(Int32));
            dt.Columns.Add("USEDDAYS", typeof(Int32));
            dt.Columns.Add("REMAINDAYS", typeof(Int32));
            dt.Columns.Add("PBYY");
            return dt;
        }
        #endregion
    }
}