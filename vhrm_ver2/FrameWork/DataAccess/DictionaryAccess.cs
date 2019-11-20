
/*
* Author: Pham Hung Dung 
* Create Date:
* Description: 
*/

using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;
using SaFa.FrameWork.Entity.Opm;

namespace SaFa.FrameWork.DataAccess.Opm
{
    public class DictionaryAccess
    {
        public static DataTable GetDictionary()
        {
            OracleParameter[] _sqlParam = new OracleParameter[1];
            _sqlParam[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_DICTIONARY.sp_OPM_Dictionary_Select", _sqlParam);
        }
        public static DictionaryEntity GetDictionaryById(string id)
        {
            OracleParameter[] sqlParam = new OracleParameter[2];
            sqlParam[0] = new OracleParameter("DictionaryID", id);
            sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKOPM_DICTIONARY.sp_OPM_Dic_get_by_ID", sqlParam);
            DictionaryEntity dictionaryEntity = new DictionaryEntity();
            if (table == null || table.Rows.Count == 0)
                return null;
            dictionaryEntity.ID = int.Parse(table.Rows[0]["ID"].ToString());
            dictionaryEntity.DictionaryID = table.Rows[0]["DictionaryID"].ToString();
            dictionaryEntity.English = table.Rows[0]["English"].ToString();
            dictionaryEntity.Korean = table.Rows[0]["Korean"].ToString();
            dictionaryEntity.Vietnamese = table.Rows[0]["Vietnamese"].ToString();
            dictionaryEntity.Other1 = table.Rows[0]["Other1"].ToString();
            dictionaryEntity.Other2 = table.Rows[0]["Other2"].ToString();
            return dictionaryEntity;
        }

        public static DataTable GetDictionaryBookById(string id)
        {
            OracleParameter[] sqlParam = new OracleParameter[2];
            sqlParam[0] = new OracleParameter("DictionaryID", id);
            sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKOPM_DICTIONARY.sp_OPMDic_get_DicBook_ID", sqlParam);
            return table;
        }

        public static bool InsertDictionary(DictionaryEntity dictionaryEntity)
        {
            OracleParameter[] sqlParam = new OracleParameter[7];
            sqlParam[0] = new OracleParameter("DictionaryID", dictionaryEntity.DictionaryID);
            sqlParam[1] = new OracleParameter("English", dictionaryEntity.English);
            sqlParam[2] = new OracleParameter("Korean", dictionaryEntity.Korean);
            sqlParam[3] = new OracleParameter("Vietnamese", dictionaryEntity.Vietnamese);
            sqlParam[4] = new OracleParameter("Other1", dictionaryEntity.Other1);
            sqlParam[5] = new OracleParameter("Other2", dictionaryEntity.Other2);
            sqlParam[6] = new OracleParameter("CREATE_UID", dictionaryEntity.CREATE_UID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_DICTIONARY.sp_OPM_Dictionary_Insert", sqlParam);

        }
        public static bool InsertDictionaryBook(DictionaryBookEntity dicbookEntity)
        {
            OracleParameter[] sqlParam = new OracleParameter[3];
            sqlParam[0] = new OracleParameter("FormID", dicbookEntity.FormID);
            sqlParam[1] = new OracleParameter("DictionaryID", dicbookEntity.DictionaryID);
            //sqlParam[2] = new OracleParameter("CREATE_DT", dicbookEntity.CREATE_DT);
            sqlParam[2] = new OracleParameter("CREATE_UID", dicbookEntity.CREATE_UID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_DICTIONARY.sp_OPM_Dictionary_Book_insert", sqlParam);

        }
        public static bool DeleteDictionary(string ID)
        {
            OracleParameter[] sqlParam = new OracleParameter[1];
            sqlParam[0] = new OracleParameter("DictionaryID", ID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_DICTIONARY.sp_OPM_Dictionary_Delete", sqlParam);

        }
        public static bool DeleteDictionaryBook(DictionaryBookEntity dicbookEntity)
        {
            OracleParameter[] sqlParam = new OracleParameter[2];
            sqlParam[0] = new OracleParameter("FormID", dicbookEntity.FormID);
            sqlParam[1] = new OracleParameter("DictionaryID", dicbookEntity.DictionaryID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_DICTIONARY.sp_OPM_Dictionary_Book_Delete", sqlParam);

        }
        public static bool UpdateDictionary(DictionaryEntity dictionaryEntity)
        {
            OracleParameter[] sqlParam = new OracleParameter[7];
            sqlParam[0] = new OracleParameter("DictionaryID", dictionaryEntity.DictionaryID);
            sqlParam[1] = new OracleParameter("English", dictionaryEntity.English);
            sqlParam[2] = new OracleParameter("Korean", dictionaryEntity.Korean);
            sqlParam[3] = new OracleParameter("Vietnamese", dictionaryEntity.Vietnamese);
            sqlParam[4] = new OracleParameter("Other1", dictionaryEntity.Other1);
            sqlParam[5] = new OracleParameter("Other2", dictionaryEntity.Other2);
            //sqlParam[6] = new OracleParameter("UPDATE_DT", dictionaryEntity.UPDATE_DT);
            sqlParam[6] = new OracleParameter("UPDATE_UID", dictionaryEntity.UPDATE_UID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_DICTIONARY.sp_OPM_Dictionary_Update", sqlParam);

        }
        public static bool UpdateDictionaryBook(DictionaryBookEntity dicbookEntity)
        {
            OracleParameter[] sqlParam = new OracleParameter[4];
            sqlParam[0] = new OracleParameter("FormID", dicbookEntity.FormID);
            sqlParam[1] = new OracleParameter("DictionaryID", dicbookEntity.DictionaryID);
            //sqlParam[2] = new OracleParameter("UPDATE_DT", dicbookEntity.UPDATE_DT);
            sqlParam[2] = new OracleParameter("UPDATE_UID", dicbookEntity.UPDATE_UID);
            sqlParam[3] = new OracleParameter("OldformID", dicbookEntity.CREATE_UID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_DICTIONARY.sp_OPM_Dictionary_Book_Update", sqlParam);

        }
        public static DataTable GetFormById(string id)
        {
            OracleParameter[] sqlParam = new OracleParameter[1];
            sqlParam[0] = new OracleParameter("DictionaryID", id);
            DataTable table = DBHelper.getDataTable_SP("sp_OPM_Dictionary_Book_get_Form", sqlParam);
            return table;
        }
    }
}