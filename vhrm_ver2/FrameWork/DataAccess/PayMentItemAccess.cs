using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class PayMentItemAccess
    {
        /// <summary>
        /// LOAD PAYMENT ITEM
        /// </summary>
        /// <param name="pWorkingTag"></param>
        /// <returns></returns>
        public static DataTable Query_PaymentItem()
        {
            string spName = "PKPAYROLL_PAYMENTANDBONUS.SP_PR_LOADPAYMENTITEM";
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }


        /// <summary>
        /// LOAD PAYMENT AMT
        /// </summary>
        /// <returns></returns>
        public static DataTable Query_PaymentAmt(string pItemID, string pEmpID, string pDept,string pMonth )
        {
            string spName = "PKPAYROLL_PAYMENTANDBONUS.SP_PR_LOADPAYMENTAMT";
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pITEMID", pItemID);
            param[1] = new OracleParameter("pEmpId", pEmpID);
            param[2] = new OracleParameter("pDeptCd", pDept);
            param[3] = new OracleParameter("pMonth", pMonth);
           // param[3] = new OracleParameter("pWStatus", pWS);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }


        /// <summary>
        /// LOAD PAYMENT AMT for input
        /// </summary>
        /// <returns></returns>
        public static DataTable Query_PaymentAmtForInput(string pItemID, string pEmpID, string pDept, string pMonth)
        {
            string spName = "PKPAYROLL_PAYMENTANDBONUS.SP_PR_LOADPAYMENTAMT_FOR_INPUT";
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pITEMID", pItemID);
            param[1] = new OracleParameter("pEmpId", pEmpID);
            param[2] = new OracleParameter("pDeptCd", pDept);
            param[3] = new OracleParameter("pMonth", pMonth);
            // param[3] = new OracleParameter("pWStatus", pWS);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }


        /// <summary>
        /// LOAD PAYMENT AMT for input
        /// </summary>
        /// <returns></returns>
        public static DataTable Query_PaymentAmtForInput(string pItemID, string pEmpID, string pDept, string pMonth, string pWorkingStatus)
        {
            string spName = "PKPAYROLL_PAYMENTANDBONUS.SP_PR_LOADPAYMENTAMT_INPUT_WS";
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("pITEMID", pItemID);
            param[1] = new OracleParameter("pEmpId", pEmpID);
            param[2] = new OracleParameter("pDeptCd", pDept);
            param[3] = new OracleParameter("pMonth", pMonth);
            param[4] = new OracleParameter("pWorkingStatus", pWorkingStatus);
            // param[3] = new OracleParameter("pWStatus", pWS);
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }


        /// <summary>
        /// Create tabe for insert data from Excel
        /// </summary>
        /// <returns></returns>
        public static DataTable Table_T_PR_PAYMENT_ITEM()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SYS_EMPID");
            dt.Columns.Add("ITEMID");
            dt.Columns.Add("MONTH");
            //dt.Columns.Add("MTO");
            dt.Columns.Add("AMT");
            dt.Columns.Add("CREATE_UID");
            dt.Columns.Add("CREATE_DT");
            dt.Columns.Add("UPDATE_UID");
            dt.Columns.Add("UPDATE_DT");
            dt.Columns.Add("EMPID");
            dt.Columns.Add("EMPIDOLD");
            dt.Columns.Add("FULLNM");
            dt.Columns.Add("DEPARTMENT");
            dt.Columns.Add("STATUS");
            dt.Columns.Add("ISCHANGED");
            return dt;
        }


        /// <summary>
        /// Create table for export
        /// </summary>
        /// <returns></returns>
        public static DataTable Table_T_PR_PAYMENT_ITEMEXPORT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ITEMID");
            //dt.Columns.Add("MFROM");
            //dt.Columns.Add("MTO");
            dt.Columns.Add("AMT");
            dt.Columns.Add("EMPID");
            dt.Columns.Add("FULLNM");
            dt.Columns.Add("DEPARTMENT");
            dt.Columns.Add("STATUS");
            return dt;
        }


        public static DataTable Savedata(string WorkingTag, string ItemID,string pMonth, float Amt,string EmpID, string CreateUID, string UpdateUID)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[8];
            param[0] = new OracleParameter("pWorkingTag", WorkingTag);
            //param[1] = new OracleParameter("pSysempid", pSysempid);
            param[1] = new OracleParameter("pITEMID", ItemID);
            param[2] = new OracleParameter("pMonth", pMonth);
            param[3] = new OracleParameter("pAMT", Amt);
            param[4] = new OracleParameter("pEMPID", EmpID);
            param[5] = new OracleParameter("pCREATE_UID", CreateUID);
            param[6] = new OracleParameter("pUPDATE_UID", UpdateUID);
            param[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP("PKPAYROLL_PAYMENTANDBONUS.SP_PR_PAYMENTINSERT", param);
            return dtData;
        }


        public static bool SubmitData(DataTable dtcost)
        {
            bool result = false;
            ConnectionHelper cnHelper = new ConnectionHelper();

            using (OracleConnection sqlConnect = cnHelper.Connect())
            {
                OracleTransaction sqlTran = sqlConnect.BeginTransaction();

                OracleCommand command = new OracleCommand("PKPAYROLL_PAYMENTANDBONUS.SP_PR_PAYMENTINSERT", sqlConnect);
                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;
                command.Transaction = sqlTran;

                command.Parameters.Add("pWorkingTag", OracleType.Char, 1, "STATUS");
                command.Parameters.Add("pITEMID", OracleType.Char, 5, "ITEMID");
                command.Parameters.Add("pMONTH", OracleType.Char, 6, "MONTH");
                //command.Parameters.Add("pMTO", OracleType.Char, 6, "MTO");
                command.Parameters.Add("pAMT", OracleType.Number, 20, "AMT");
                command.Parameters.Add("pEMPID", OracleType.Char, 8, "EMPID");
                command.Parameters.Add("pCREATE_UID", OracleType.NVarChar, 20, "CREATE_UID");
                command.Parameters.Add("pUPDATE_UID", OracleType.NVarChar, 20, "UPDATE_UID");

                OracleDataAdapter adpt = new OracleDataAdapter();
                adpt.InsertCommand = command;
                // Specify the number of records to be Inserted/Updated in one go. Default is 1.
                adpt.UpdateBatchSize = 2;
                try
                {
                    DataTable Temp = new DataTable();
                    Temp = Table_T_PR_PAYMENT_ITEM();

                    foreach (DataRow dataRow in dtcost.Rows)
                    {
                        DataRow dr = Temp.NewRow();
                        Temp.Rows.Add(dr);

                        dr["ITEMID"] = dataRow["ITEMID"]??"";
                        dr["MONTH"] = dataRow["MONTH"] ?? "";
                        //dr["MTO"] = dataRow["MTO"] ?? "";
                        dr["AMT"] = dataRow["AMT"] ?? "";
                        dr["EMPID"] = dataRow["EMPID"] ?? "";
                        dr["CREATE_UID"] = dataRow["CREATE_UID"] ?? "";
                        dr["FULLNM"] = dataRow["FULLNM"] ?? "";
                        dr["DEPARTMENT"] = dataRow["DEPARTMENT"] ?? "";
                        dr["STATUS"] = dataRow["STATUS"] ?? "";
                    }
                    int recordsInserted = adpt.Update(Temp);
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


        public static DataTable SavedataAll(string ITEMID, string month, string sysEmpId_amt, string loginId)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pITEMID", ITEMID);
            param[1] = new OracleParameter("pMonth", month);
            param[2] = new OracleParameter("pSysEmpId_amt", OracleType.LongVarChar);
            param[2].Value = sysEmpId_amt;
            param[3] = new OracleParameter("pLoginId", loginId);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP("PKPAYROLL_PAYMENTANDBONUS.SP_PR_PAYMENTINSERT_ALL", param);
            return dtData;
        }


        public static DataTable GetMapID(string strEmpIdList)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pSysEmpId", OracleType.LongVarChar, 50000);
            param[0].Value = strEmpIdList;
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP("PKPAYROLL_PAYMENTANDBONUS.SP_GET_MAPID", param);
            return dtData;
        }
    }
}