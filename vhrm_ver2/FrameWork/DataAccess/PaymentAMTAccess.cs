using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Data;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class PaymentAMTAccess
    {
    #region Employee
        public DataTable Query_Employee(string Deptcode, string workStatusCode,string month, string planguage)
        {
            string spName = "PKPAYROLL_EnterPAYmentData.sp_T_HR_EMP_MASTER_Query";
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pDeptcode", Deptcode);
           // param[1] = new OracleParameter("pSysEmpID", empID);
            param[1] = new OracleParameter("pworkStatusCode", workStatusCode);
            param[2] = new OracleParameter("pMonth", month);
            param[3] = new OracleParameter("planguage", planguage);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
    #endregion 
        #region Salary Payment
        public DataTable QueryOldData(string sysId)
        {
            string spName = "PKPAYROLL_EnterPAYmentData.sp_PAYITEM_AMT_LoadOldData";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pSysEmpID", sysId);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable Query_SalaryPayment(string empID, string month)
        {
            string spName = "PKPAYROLL_EnterPAYmentData.sp_T_PR_PAYITEM_AMT_Query";
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pMonth", month);
            param[1] = new OracleParameter("pSysEmpID", empID);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable Save_SalaryPayment(PaymentAMTEntity amtEntity, string pWorkTask)
        {
            string spName = "PKPAYROLL_EnterPAYmentData.sp_T_PR_PAYITEM_AMT_Save";
            OracleParameter[] param = new OracleParameter[16];
            param[0] = new OracleParameter("pWorkTask", pWorkTask);
            param[1] = new OracleParameter("pSysEmpID", amtEntity.SysEMPID);
            param[2] = new OracleParameter("pFROMDATE", amtEntity.Fromdate);
            param[3] = new OracleParameter("pTODATE", amtEntity.ToDate);
            param[4] = new OracleParameter("pJoballow", amtEntity.JobAllow);
            param[5] = new OracleParameter("pMultiSkill", amtEntity.MultiSkill);
            param[6] = new OracleParameter("pLanguageSkill", amtEntity.LanguageSkill);
            param[7] = new OracleParameter("pHousing", amtEntity.Housing);
            param[8] = new OracleParameter("pPosition", amtEntity.Position);
            param[9] = new OracleParameter("pH3", amtEntity.H3);
            param[10] = new OracleParameter("pLaborFun", amtEntity.LaborFun);
            param[11] = new OracleParameter("pBasicSalaryUp", amtEntity.BasicSalaryUp);
            param[12] = new OracleParameter("pOthers", amtEntity.Others);
            param[13] = new OracleParameter("pRemark", OracleType.NVarChar) { Value = amtEntity.Remarks };
            param[14] = new OracleParameter("pLogin", amtEntity.LoginUi);
            param[15] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }

        // Modify By Tho
        // Modify Date: 11/15/2013
        // Desc: Check Editable Allowance
        public DataTable CheckEdit_EnterAllowance(string sys_empid, string fromdate, string todate)
        {
            string sp_name = "PKPAYROLL_ENTERPAYMENTDATA.SP_ENTER_ALLOWANCE_CHECKEDIT";
            OracleParameter[] _param = new OracleParameter[4];
            _param[0] = new OracleParameter("PSYSEMPID", sys_empid);
            _param[1] = new OracleParameter("PFROMDATE", fromdate);
            _param[2] = new OracleParameter("PTODATE", todate);
            _param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp_name, _param);
        }
        #endregion
    }
}