using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class AbsenceDetailAccess
    {
        public static DataTable Load(string corporation, string Reason, string employeeId, string fromDate, string toDate,string MonthPay,int Version)
        {
            string query = "PKINSURANCE_ABSENCE_DETAILS.SP_INS_ABSENCE_DETAILS_QUERY";
            OracleParameter[] parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("pCorporation", corporation ?? "");
            parameters[1] = new OracleParameter("pReason", Reason ?? "");
            parameters[2] = new OracleParameter("pEmployeeId", employeeId ?? "");
            parameters[3] = new OracleParameter("pFromDate", fromDate ?? "");
            parameters[4] = new OracleParameter("pToDate", toDate ?? "");
            parameters[5] = new OracleParameter("pMonthpay",MonthPay);
            parameters[6] = new OracleParameter("pVersion", Version);
            parameters[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable UpdateData(string workTask ,AbsenceDetailEntity entity)
        {
            string query = "PKINSURANCE_ABSENCE_DETAILS.sp_SAVE_T_INS_ABSENCE";
            OracleParameter[] parameters = new OracleParameter[17];
            parameters[0] = new OracleParameter("pWorkingTag", workTask ?? "");
            parameters[1] = new OracleParameter("pSysEmpID", entity.SysEmpId?? "");
            parameters[2] = new OracleParameter("pSEQ_NO",entity.SeqNo?? "");
            parameters[3] = new OracleParameter("pCLSID", entity.Clsid?? "");
            parameters[4] = new OracleParameter("pFromdate", entity.FromDate ?? "");
            parameters[5] = new OracleParameter("pTodate", entity.ToDate ?? "");
            parameters[6] = new OracleParameter("ptotalDate",value: entity.TotalDate);
            parameters[7] = new OracleParameter("pPbno",1);
            parameters[8] = new OracleParameter("pPbym", entity.Pbym?? "");
            parameters[9] = new OracleParameter("pCondition",entity.Condition?? "");
            parameters[10] = new OracleParameter("pRemark",entity.Remark??"");
            parameters[11] = new OracleParameter("pUID", entity.ConfirmUid ?? "");
            parameters[12] = new OracleParameter("pVersion", value: entity.Version);
            parameters[13] = new OracleParameter("pIsConfirm", entity.ConfirmIs??"");
            parameters[14] = new OracleParameter("pIsFocus", entity.IS_FOCUS?? "0");
            parameters[15] = new OracleParameter("pConditionTime", entity.Condition_Time ?? "");
            parameters[16] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
           
        }
        public DataTable LogDigWork(string sysId, string fromDate, string toDate,string ItemCode)
        {
            string query = "PKINSURANCE_ABSENCE_DETAILS.sp_GetDailyworkConfig";
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("pSysID", sysId ?? "");
            parameters[1] = new OracleParameter("pFromDate", fromDate ?? "");
            parameters[2] = new OracleParameter("pToDate", toDate ?? "");
            parameters[3] = new OracleParameter("pItemCode", ItemCode ?? "");
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public  bool AcceptData(DataTable dtAbsence)
        {
            bool result = false;
            ConnectionHelper cnHelper = new ConnectionHelper();

            using (OracleConnection sqlConnect = cnHelper.Connect())
            {
                OracleTransaction sqlTran = sqlConnect.BeginTransaction();

                OracleCommand command = new OracleCommand("PKINSURANCE_ABSENCE_DETAILS.sp_AcceptAll", sqlConnect);
                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;
                command.Transaction = sqlTran;

                command.Parameters.Add("pStatus", OracleType.Char, 1, "Status");
                command.Parameters.Add("pSEQ_NO", OracleType.Int32,2,  "SEQ_NO");
                command.Parameters.Add("pConfirmUID", OracleType.Char, 20, "ConfirmUID");
                command.Parameters.Add("pSysEmpID", OracleType.Char,8 , "pSysEmpID");
                OracleDataAdapter adpt = new OracleDataAdapter();
                adpt.InsertCommand = command;
                // Specify the number of records to be Inserted/Updated in one go. Default is 1.
                adpt.UpdateBatchSize = 2;
                try
                {
                    int recordsInserted = adpt.Update(dtAbsence);
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
        public  DataTable CreateTableAbsence()
        {
            DataTable dt = new DataTable();
           dt.Columns.Add("Status");
            dt.Columns.Add("SEQ_NO");
            dt.Columns.Add("ConfirmUID");
            dt.Columns.Add("pSysEmpID");
            
            return dt;
        }
    }
}