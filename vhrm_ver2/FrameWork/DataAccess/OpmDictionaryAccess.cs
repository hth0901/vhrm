using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.DataAccess
{
    public class OpmDictionaryAccess
    {
        // Load list of Dictionary
        public DataSet loadData(string LangID, string EmpID, string FormCode)
        {
            DataSet dataSet = new DataSet();
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pLangID", LangID);
            param[1] = new OracleParameter("pEmpID", EmpID);
            param[2] = new OracleParameter("pFormCode", OracleType.NVarChar){Value = FormCode};
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dataSet = DBHelper.getDataSet_SP("PKOPM_DICTIONARY.sp_Dictionary_Qry", param);
            return dataSet;
        }
        public DataSet ExportData(string formCode)
        {
            DataSet dataSet = new DataSet();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pFormCode", formCode);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dataSet = DBHelper.getDataSet_SP("PKOPM_DICTIONARY.sp_Dictionary_Qry", param);
            return dataSet;
        }
        public DataTable SaveData(string WorkingTag, int FormID, string FormCode, string ControlID, string ControlType, string Dictionary, string LangID, string EmpID,string is_require)
        {

            HttpContext.Current.Cache.Remove(FormCode + "en");
            HttpContext.Current.Cache.Remove(FormCode + "kr");
            HttpContext.Current.Cache.Remove(FormCode + "vi");


            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[10];
            param[0] = new OracleParameter("pWorkingTag", WorkingTag);
            param[1] = new OracleParameter("pFormID", FormID);
            param[2] = new OracleParameter("pFormCode", FormCode);
            param[3] = new OracleParameter("pControlID", ControlID);
            param[4] = new OracleParameter("pControlType", ControlType);
            param[5] = new OracleParameter("pDictionaryID", Dictionary);
            param[6] = new OracleParameter("pLangID", LangID);
            param[7] = new OracleParameter("pEmpID", EmpID);
            param[8] = new OracleParameter("pIsrequire", is_require);
            param[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP("PKOPM_DICTIONARY.sp_Dictionary_Save", param);
            return dtData;
        }
    }
}