using System.Data;
using Oracle.ManagedDataAccess.Client;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class MenuTreeAccess
    {

        public static DataTable GetAll(string LangCode)
        {
            string sqlQuery = "PKOPM_FORMANDMENU.sp_OPM_Menu_getALLLangCode";
            OracleParameter[] sqlParams = new OracleParameter[2];
            sqlParams[0] = new OracleParameter("p_Lang", LangCode);
            sqlParams[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(sqlQuery, sqlParams);
            if (dt == null || dt.Rows.Count == 0)
                return null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["LangValue"] = string.IsNullOrEmpty(dt.Rows[i]["LangValue"].ToString())
                                              ? dt.Rows[i]["MenuName"].ToString()
                                              : dt.Rows[i]["LangValue"].ToString();
                dt.Rows[i]["MotherID"] = string.IsNullOrEmpty(dt.Rows[i]["MotherID"].ToString()) ? null : dt.Rows[i]["MotherID"].ToString();
            }
            return dt;
        }

        public static MenuTreeEntity GetByMenuID(string MenuID)
        {
            string sqlQuery = "PKOPM_FORMANDMENU.sp_OPM_Menu_get_by_MenuID";
            OracleParameter[] sqlParams = new OracleParameter[2];
            sqlParams[0] = new OracleParameter("p_MenuID", MenuID);
            sqlParams[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(sqlQuery, sqlParams);
            if (dt == null || dt.Rows.Count == 0)
                return null;

            MenuTreeEntity menuEntity = new MenuTreeEntity();
            menuEntity.MenuID = dt.Rows[0]["MenuID"].ToString();
            menuEntity.MenuName = dt.Rows[0]["MenuName"].ToString();
            menuEntity.MotherID = dt.Rows[0]["MotherID"].ToString();
            menuEntity.FormID = dt.Rows[0]["FormCode"].ToString();
            menuEntity.DictionaryID = dt.Rows[0]["DictionaryID"].ToString();
            menuEntity.FilePath = dt.Rows[0]["FilePath"].ToString();
            menuEntity.Seq = string.IsNullOrEmpty(dt.Rows[0]["Seq"].ToString())? 0
                                 : int.Parse(dt.Rows[0]["Seq"].ToString());
            menuEntity.IsActive = dt.Rows[0]["IsActive"].ToString();
            return menuEntity;
        }

        public static bool InsertMenu(MenuTreeEntity menuEntity)
        {
            OracleParameter[] sqlParam = new OracleParameter[8];
            sqlParam[6] = new OracleParameter("p_MenuID", menuEntity.MenuID);
            sqlParam[0] = new OracleParameter("p_MenuName", menuEntity.MenuName);
            sqlParam[1] = new OracleParameter("p_MotherID", menuEntity.MotherID);
            sqlParam[2] = new OracleParameter("p_Seq", menuEntity.Seq);
            sqlParam[3] = new OracleParameter("p_FormCode", menuEntity.FormID);
            sqlParam[4] = new OracleParameter("p_DictionaryID", menuEntity.DictionaryID);
            sqlParam[7] = new OracleParameter("p_IsActive", menuEntity.IsActive);
            sqlParam[5] = new OracleParameter("p_CREATE_UID", menuEntity.CREATE_UID);

            return DBHelper.ExecuteNonQuery_SP("PKOPM_FORMANDMENU.sp_OPM_Menu_Insert", sqlParam);
        }

        public static bool DeleteMenu(string ID)
        {
            OracleParameter[] sqlParam = new OracleParameter[1];
            sqlParam[0] = new OracleParameter("MenuID", ID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_FORMANDMENU.sp_OPM_Menu_Delete", sqlParam);
        }

        public static bool UpdateMenu(MenuTreeEntity menuEntity)
        {
            OracleParameter[] sqlParam = new OracleParameter[8];
            sqlParam[0] = new OracleParameter("p_MenuID", menuEntity.MenuID);
            sqlParam[1] = new OracleParameter("p_MenuName", menuEntity.MenuName);
            sqlParam[2] = new OracleParameter("p_MotherID", menuEntity.MotherID);
            sqlParam[3] = new OracleParameter("p_Seq", menuEntity.Seq);
            sqlParam[4] = new OracleParameter("p_DictionaryID", menuEntity.DictionaryID);
            sqlParam[5] = new OracleParameter("p_FormCode", menuEntity.FormID);
            sqlParam[6] = new OracleParameter("p_IsActive", menuEntity.IsActive);
            sqlParam[7] = new OracleParameter("p_UPDATE_UID", menuEntity.UPDATE_UID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_FORMANDMENU.sp_OPM_Menu_Update", sqlParam);

        }

        public static bool UpdateMotherIdMenu(MenuTreeEntity menuEntity)
        {
            OracleParameter[] sqlParam = new OracleParameter[4];
            sqlParam[0] = new OracleParameter("MenuID", menuEntity.MenuID);
            sqlParam[1] = new OracleParameter("MotherID", menuEntity.MotherID);
            sqlParam[2] = new OracleParameter("Seq", menuEntity.Seq);
            sqlParam[3] = new OracleParameter("UPDATE_UID", menuEntity.UPDATE_UID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_FORMANDMENU.sp_OPM_Menu_Update_MotherID", sqlParam);
        }
        public static int CheckMenuId(string MenuId)
        {
            string spName = "PKOPM_FORMANDMENU.sp_OPM_Menu_CheckID";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pMenuID", MenuId);
            parameters[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP(spName, parameters);
            int numberRow= int.Parse(table.Rows[0]["NumberRow"].ToString());
            return numberRow;
        }


        // Duy Hung 31/05/2014
        public static DataTable sp_Delete_Menu(string MenuId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pMenu_ID", MenuId);
            parameters[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_FORMANDMENU.sp_Delete_Menu", parameters);
        }

        // Duy Hung 31/05/2014
        public static bool SP_UPDATE_DRAGED_NODE(MenuTreeEntity menuEntity)
        {
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("p_MenuID", menuEntity.MenuID);
            parameters[1] = new OracleParameter("p_MotherID", menuEntity.MotherID);
            parameters[2] = new OracleParameter("p_Seq", menuEntity.Seq);
            parameters[3] = new OracleParameter("p_UPDATE_UID", menuEntity.UPDATE_UID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_FORMANDMENU.SP_UPDATE_DRAGED_NODE", parameters);
        }
    }
}