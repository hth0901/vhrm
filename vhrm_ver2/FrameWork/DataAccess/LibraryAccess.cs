using System;
using System.Linq;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class LibraryAccess
    {
        public DataTable loadLibrary(string Code,string LangID)
        {
            DataTable dsData = new DataTable();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("@pCodeHelp", Code);
            param[1] = new OracleParameter("@pLangID", LangID);

            dsData = DBHelper.getDataTable_SP("sp_CodeHelp_Qry", param);
            return dsData;
        }

        public DataTable LoadData(string code, string value)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("@Code", code);
            param[1] = new OracleParameter("@Value", value);
            DataTable dataTable = DBHelper.getDataTable_SP("sp_LoadPopupData", param);
            return dataTable;
        }


        public DataSet loadLibrary1(string Code, string LangID)
        {
            DataSet dsData = new DataSet();
            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("pLibCode", Code);
            param[1] = new OracleParameter("pLangId", LangID);
            param[2] = new OracleParameter("pSearchCol", "");
            param[3] = new OracleParameter("pSearchValue", "");
            param[6] = new OracleParameter("pType", "1");
            param[4] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[5] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dsData = DBHelper.getDataSet_SP("PKOPM_LIBLARY.sp_Library_Qry", param);
            return dsData;
        }
        public DataSet loadLibrary1(string Code, string LangID, string subCond)
        {
            DataSet dsData = new DataSet();
            OracleParameter[] param = new OracleParameter[8];
            param[0] = new OracleParameter("pLibCode", Code);
            param[1] = new OracleParameter("pLangId", LangID);
            param[2] = new OracleParameter("pSearchCol", "");
            param[3] = new OracleParameter("pSearchValue", "");
            param[4] = new OracleParameter("pSubCond1", subCond);
            param[5] = new OracleParameter("pType", "1");
            param[6] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[7] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dsData = DBHelper.getDataSet_SP("PKOPM_LIBLARY.sp_Library_Qry", param);
            return dsData;
        }
        public DataSet loadLibrary1(string Code, string LangID,string type,string value)
        {
            DataSet dsData = new DataSet();
            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("pLibCode", Code);
            param[1] = new OracleParameter("pLangId", LangID);
            param[2] = new OracleParameter("pSearchCol", type);
            param[3] = new OracleParameter("pSearchValue", OracleType.NVarChar) { Value = value };
            param[4] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[5] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[6] = new OracleParameter("pType", "1");
            dsData = DBHelper.getDataSet_SP("PKOPM_LIBLARY.sp_Library_Qry", param);
            return dsData;
        }
        public DataSet loadLibrary1(string Code, string LangID, string type, string value, string subCond)
        {
            DataSet dsData = new DataSet();
            OracleParameter[] param = new OracleParameter[8];
            param[0] = new OracleParameter("pLibCode", Code);
            param[1] = new OracleParameter("pLangId", LangID);
            param[2] = new OracleParameter("pSearchCol", type);
            param[3] = new OracleParameter("pSearchValue", OracleType.NVarChar) { Value = value};
            param[4] = new OracleParameter("pSubCond1", subCond);
            param[5] = new OracleParameter("pType", "1");
            param[6] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[7] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };
            //param[5] = new OracleParameter("pUi", uiLogin);
            dsData = DBHelper.getDataSet_SP("PKOPM_LIBLARY.sp_Library_Qry", param);
            return dsData;
        }

        /*
         * Author: Tran Cong Tho
         * Modify Date: 10/16/2013
         * Desc: Loc danh sach nhan vien theo trang thai lam viec
        */
        public DataSet loadLibrary_Employee(string Code, string LangID, string type, string value, string subCond, string pType)
        {
            DataSet dsData = new DataSet();
            OracleParameter[] param = new OracleParameter[8];
            param[0] = new OracleParameter("pLibCode", Code);
            param[1] = new OracleParameter("pLangId", LangID);
            param[2] = new OracleParameter("pSearchCol", type);
            param[3] = new OracleParameter("pSearchValue", OracleType.NVarChar) { Value = value };
            param[4] = new OracleParameter("pSubCond1", subCond);
            param[5] = new OracleParameter("pType", pType);
            param[6] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[7] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };
            //param[5] = new OracleParameter("pUi", uiLogin);
            dsData = DBHelper.getDataSet_SP("PKOPM_LIBLARY.sp_Library_Qry", param);
            return dsData;
        }

        /// <summary>
        /// Load All Library
        /// </summary>
        /// <param name="LangID"></param>
        /// <param name="EmpID"></param>
        /// <returns></returns>
        public DataSet loadListLibrary(string LangID, string EmpID)
        {
            DataSet dsData = new DataSet();
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pLangID", LangID);
            param[1] = new OracleParameter("pEmpID", EmpID);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dsData = DBHelper.getDataSet_SP("PKOPM_LIBLARY.sp_LibraryList_Qry", param);
            return dsData;
        }

        public DataTable SaveData(string WorkingTag, LibraryEntity _entity, string LangID, string EmpID)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[28];
            param[0] = new OracleParameter("pWorkingTag", WorkingTag);
            param[1] = new OracleParameter("pLibCode", _entity.LIBRARY_CODE);
            param[2] = new OracleParameter("pLibName", OracleType.NVarChar) {Value = _entity.LIBRARY_NAME};
            param[3] = new OracleParameter("pLibExe", _entity.LIBRARY_EXE);
            param[4] = new OracleParameter("pDictionary", _entity.DICTIONARY_CODE);
            param[5] = new OracleParameter("pLibNm1", _entity.LIB1_NAME);
            param[6] = new OracleParameter("pLibType1", _entity.LIB1_TYPE);
            param[7] = new OracleParameter("pLibNm2", _entity.LIB2_NAME);
            param[8] = new OracleParameter("pLibType2", _entity.LIB2_TYPE);
            param[9] = new OracleParameter("pLibNm3", _entity.LIB3_NAME);
            param[10] = new OracleParameter("pLibType3", _entity.LIB3_TYPE);
            param[11] = new OracleParameter("pLibNm4", _entity.LIB4_NAME);
            param[12] = new OracleParameter("pLibType4", _entity.LIB4_TYPE);
            param[13] = new OracleParameter("pLibNm5", _entity.LIB5_NAME);
            param[14] = new OracleParameter("pLibType5", _entity.LIB5_TYPE);
            param[15] = new OracleParameter("pLibNm6", _entity.LIB6_NAME);
            param[16] = new OracleParameter("pLibType6", _entity.LIB6_TYPE);
            param[17] = new OracleParameter("pLibNm7", _entity.LIB7_NAME);
            param[18] = new OracleParameter("pLibType7", _entity.LIB7_TYPE);
            param[19] = new OracleParameter("pLibNm8", _entity.LIB8_NAME);
            param[20] = new OracleParameter("pLibType8", _entity.LIB8_TYPE);
            param[21] = new OracleParameter("pLibNm9", _entity.LIB9_NAME);
            param[22] = new OracleParameter("pLibType9", _entity.LIB9_TYPE);
            param[23] = new OracleParameter("pLibNm10", _entity.LIB10_NAME);
            param[24] = new OracleParameter("pLibType10", _entity.LIB10_TYPE);

            param[25] = new OracleParameter("pLangID", LangID);
            param[26] = new OracleParameter("pEmpID", EmpID);
            param[27] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKOPM_LIBLARY.sp_Library_Save", param);
            return dtData;
        }
    }
}