using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Data;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class AdjustPaymnetDataAccess
    {
        #region Employee
        public DataTable Query_Employee(string Deptcode, string empID, string workStatusCode, string planguage)
        {
            string spName = "PKPAYROLL_ADJUSTPAYMENTDATA.sp_T_HR_EMP_MASTER_Query";
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pDeptcode", Deptcode);
            param[1] = new OracleParameter("pSysEmpID", empID);
            param[2] = new OracleParameter("pworkStatusCode", workStatusCode);
            param[3] = new OracleParameter("planguage", planguage);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        #endregion
        #region Salary Payment
        public DataTable Query_SalaryPayment(string empID, string month)
        {
            string spName = "PKPAYROLL_ADJUSTPAYMENTDATA.sp_T_PR_SLR_ADJUST_Query";
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pMonth", month);
            param[1] = new OracleParameter("pSysEmpID", empID);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable Save_SalaryPayment(PaymentAMTEntity amtEntity, string pWorkTask)
        {
            string spName = "PKPAYROLL_ADJUSTPAYMENTDATA.sp_T_PR_SLR_ADJUST_Save";
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("pWorkTask", pWorkTask);
            param[1] = new OracleParameter("pSysEmpID", amtEntity.SysEMPID);
            param[2] = new OracleParameter("pItemId", amtEntity.Itemid);
            param[3] = new OracleParameter("pFROMDATE", amtEntity.Fromdate);
            param[4] = new OracleParameter("pTODATE", amtEntity.ToDate);
            param[5] = new OracleParameter("pAMT", value: amtEntity.Amt);
            param[6] = new OracleParameter("pLogin", amtEntity.LoginUi);
            param[7] = new OracleParameter("pRemark", amtEntity.Remarks);
            param[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        #endregion
    }
}