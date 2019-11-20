using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class EmpIDClassAccess
    {
        public static DataTable LoadEmpIdClassification()
        {
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) {Direction = ParameterDirection.Output};
            return DBHelper.getDataTable_SP("PKHR_EMPID_CLASSIFICATION.SP_LOAD_EMPID_CLASSIFICATION", parameters);
        }

        public static DataTable LoadEmpDetail(string pCorporation)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pCorporation", pCorporation);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_EMPID_CLASSIFICATION.SP_LOAD_EMP_DETAIL", parameters);
        }
        public static DataTable Save(string pDeptcode, string pDiget8,string pUser)
        {
            string query = "PKHR_EMPID_CLASSIFICATION.SP_EMPID_CLASSIFICATION_SAVE";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pDEPTCODE", pDeptcode);
            parameters[1] = new OracleParameter("pCOLUM8", pDiget8);
            parameters[2] = new OracleParameter("pUSER", pUser);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable SaveDetail(string pWorkingtag,string pDeptcode,string pItemCD,string pItemNM,string pDigit8, string pDiget7,string pDiget6,string pRemark, string OrderIndex, string pUser)
        {
            string query = "PKHR_EMPID_CLASSIFICATION.SP_EMPID_CLASS_DETAIL_SAVE";
            OracleParameter[] parameters = new OracleParameter[11];
            parameters[0] = new OracleParameter("pWORKINGTAG",pWorkingtag);
            parameters[1] = new OracleParameter("pDEPTCODE", pDeptcode);
            parameters[2] = new OracleParameter("pITEMCD",pItemCD);
            parameters[3] = new OracleParameter("pITEMNM",OracleType.NVarChar){Value = pItemNM};
            parameters[4] = new OracleParameter("pCOLUM8", pDigit8);
            parameters[5] = new OracleParameter("pCOLUM7", pDiget7);
            parameters[6] = new OracleParameter("pCOLUM6", pDiget6);
            parameters[7] = new OracleParameter("pREMARKS",OracleType.NVarChar){Value = pRemark};
            parameters[8] = new OracleParameter("pORDERINDEX", OrderIndex);
            parameters[9] = new OracleParameter("pUSER", pUser);
            parameters[10] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
    }
}