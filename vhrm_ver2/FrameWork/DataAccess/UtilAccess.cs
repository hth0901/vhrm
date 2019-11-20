using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.DataAccess
{
    public class UtilAccess
    {
        public DataTable getComboData(string MajorCd, string ColVal, string LangID, string SubCond, string EmpID)
        {   
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("MajorCd", MajorCd);
            param[1] = new OracleParameter("ColVal", ColVal);
            param[2] = new OracleParameter("LangId", LangID);
            param[3] = new OracleParameter("SubCondIndex", SubCond);
            param[4] = new OracleParameter("EmpId", EmpID);
            //param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };


            dtData = DBHelper.getDataTable_SP("UtilAccess.sp_CodeHelpCombobox", param);

            return dtData;
        }
        public DataSet getMultiComboData(string MajorList, string LangID, string EmpID)
        {
            DataSet dtData = new DataSet();
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("@pCodeHelpList", MajorList);
            param[1] = new OracleParameter("@pLangId", LangID);
            param[2] = new OracleParameter("@pEmpId", EmpID);

            dtData = DBHelper.getDataSet_SP("sp_getComboForPage", param);

            return dtData;
        }

        // get thông tin Master cho Query form | HVT_MS
        public DataSet getMasterData(string PgmID, string LangID, string EmpID)
        {
            DataSet dsData = new DataSet();
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("PgmID", PgmID);
            param[1] = new OracleParameter("LangId", LangID);
            param[2] = new OracleParameter("EmpId", EmpID);
            param[3] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[4] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dsData = DBHelper.getDataSet_SP("PKOPM_LOGIN.sp_getMasterForQueryForm", param);
            return dsData;
        }

        /*****************************************************************************/
        // Query Combobox | HVT_MS project
        public DataTable getComboData(string CategoryID, string SubCond, string LangID, string EmpID)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[5];

            param[0] = new OracleParameter("CategoryID", CategoryID);
            param[1] = new OracleParameter("SubCond", SubCond);
            param[2] = new OracleParameter("LangId", LangID);
            param[3] = new OracleParameter("EmpId", EmpID);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP("PKOPM_LOGIN.sp_LoadCombobox", param);

            return dtData;
        }
        // ================================================================
        //              QUERY DATA FOR QUERY FORM | HVT_MS
        // ================================================================
        public DataSet LoadQueryData(DataTable dtParam, string PgmID)
        {
            DataSet dsData = new DataSet();
            OracleParameter[] param = new OracleParameter[dtParam.Rows.Count];
            for (int i = 0; i < dtParam.Rows.Count; i++)
                param[i] = new OracleParameter(dtParam.Rows[i]["Name"].ToString(), dtParam.Rows[i]["Value"]);

            dsData = DBHelper.getDataSet_SP("S" + PgmID, param);

            return dsData;
        }
        // ================================================================
        //       QUERY COMBOBOX BY LIBRARY FOR QUERY FORM | HVT_MS
        // ================================================================
        public DataSet getComboboxByLibrary(string LibraryCode,string subCond, string LangID)
        {
            DataSet dsData = new DataSet();
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("LibCode", LibraryCode);
            param[1] = new OracleParameter("SubCond", subCond);
            param[2] = new OracleParameter("LangID", LangID);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dsData = DBHelper.getDataSet_SP("PKOPM_LOGIN.sp_LibraryCombobox", param);
            return dsData;
        }
    }
}