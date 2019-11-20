using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.DataAccess
{
    public class LanguageAccess
    {
        public DataSet getLanguageForPage(string LangID, string Page)
        {
            DataSet dtData = new DataSet();
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("Lang", LangID) { Direction = ParameterDirection.Input };
            param[1] = new OracleParameter("PgmId", Page) { Direction = ParameterDirection.Input };
            param[2] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[3] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[4] = new OracleParameter("T_TABLE3", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[5] = new OracleParameter("T_TABLE4", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataSet_SP("PKOPM_DICTIONARY.sp_SDictionaryByFormID", param);

            return dtData;
        }
 
        public DataTable Dictionary_Save(string WorkingTag, string DicCode, string DicName, string DicLang, string LangID, string EmpID)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("WorkingTag", WorkingTag);
            param[1] = new OracleParameter("DicCode", DicCode);
            param[2] = new OracleParameter("DicName", DicName);
            param[3] = new OracleParameter("DicLang", DicLang);
            param[4] = new OracleParameter("LangID", LangID);
            param[5] = new OracleParameter("EmpID", EmpID);
            param[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };


            dtData = DBHelper.getDataTable_SP("PKOPM_DICTIONARY.sp_Dictionary_Save", param);

            return dtData;
        }
    }
}