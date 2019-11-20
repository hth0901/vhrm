using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class PaymentConditionAccess
    {
        /// <summary>
        /// LOAD PAYMENT ITEM
        /// </summary>
        /// <param name="pWorkingTag"></param>
        /// <returns></returns>
        public static DataTable Query_PaymentItem(string pClassification) 
        {
            string spName = "PKPAYROLL_PAYMENTCONDITION.SP_PR_LOADPAYMENTITEM";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pClassification", pClassification);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }
        /// <summary>
        /// load payment detail
        /// </summary>
        /// <returns></returns>
        public static DataTable Query_PaymentItemDetail(string pItemCd, string deptCode, string payMethod)
        {
            //, string payMethod
            string spName = "PKPAYROLL_PAYMENTCONDITION.SP_PR_LOADPAYMENDETAIL";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pITEMCD", pItemCd);
            param[1] = new OracleParameter("pDeptCode", deptCode);
            param[2] = new OracleParameter("pPayMethod", payMethod);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }
        /// <summary>
        /// load combo for ConditionCD field
        /// </summary>
        /// <returns></returns>
        public static DataTable Combo_Corporation()
        {
            string spName = "PKPAYROLL_PAYMENTCONDITION.SP_PR_FILLCORPORATION";
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }
        /// <summary>
        /// save data Payment condition
        /// </summary>
        /// <returns></returns>
        //Load dropdownlist Version by Classification
        public static DataTable Combo_Version(string pClassification )
        {
            string spName = "PKPAYROLL_PAYMENTCONDITION.SP_T_PR_CM_VER_Query";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pClassification", pClassification);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public static DataTable CheckValidatorPayment(string verID, string itemCd, string conditionCd)
        {
            string spName = "PKPAYROLL_PAYMENTCONDITION.SP_SALARY_CONDITION_Validator";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pVER_ID", verID);
            param[1] = new OracleParameter("pITEMCD",itemCd);
            param[2] = new OracleParameter("pCONDITIONCD", conditionCd);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public static DataTable Savedata(string pWorkingTag, PaymentConditionEntity entity)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[15];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pDeptCode", entity.DeptCode??"");
            param[2] = new OracleParameter("pITEMCD", entity.ItemCD??"");
            param[3] = new OracleParameter("pCONDITIONCD", entity.ConditionCD ?? "");
            param[4] = new OracleParameter("pVFROM",value:entity.From );
            param[5] = new OracleParameter("pVTO", value: entity.To);
            param[6] = new OracleParameter("pCLSSCONDITION",entity.ClssContition??"");
            param[7] = new OracleParameter("pAMT", value: entity.Amt);
            param[8] = new OracleParameter("pRATE", value: entity.Rate);
            param[9] = new OracleParameter("pRemark",entity.Remark??"");
            param[10] = new OracleParameter("pUSERID", entity.UserID);
            param[11] = new OracleParameter("pValidTodate", entity.ValidTodate??"");
            param[12] = new OracleParameter("pValidFromdate", entity.ValidFromdate??"");
            param[13] = new OracleParameter("pIDNO", entity.IdNo??"");
            param[14] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKPAYROLL_PAYMENTCONDITION.SP_PR_PAYMENTCONDITION_INSERT", param);
            return dtData;
        }
    }
}