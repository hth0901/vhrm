using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;
using System.Web.UI;
using vhrm.FrameWork.Entity;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class CategoryAccess
    {

        #region Category DataAccess
        public DataTable GetCategory()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.sp_OPM_Category_Qry", param);
        }

        public DataTable GetComboBoxData(int categoryId, string parentId)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pCategoryId", categoryId);
            parameters[1] = new OracleParameter("pParentId", parentId);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.sp_GetComboBoxData", parameters);
        }

        //get dataTable DropDownList Formular and DropDownlist Subcode 
        public DataTable GetDropDownListFormularSubCode(int categoryID, string subcode) { 
                OracleParameter [] para = new OracleParameter[3];
                para[0] = new OracleParameter("pCategoryId",categoryID);
                para[1] = new OracleParameter("pSubCode", subcode);
                para[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output};
                return DBHelper.getDataTable_SP("PKOPM_CATEGORY.sp_Category_Qry_SubCode",para);
        }
        
        public DataTable GetComboBoxData(int categoryId, string parentId, string pLoginID)
        {
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pCategoryId", categoryId);
            parameters[1] = new OracleParameter("pParentId", parentId);
            parameters[2] = new OracleParameter("pLoginID", pLoginID);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.sp_GetComboBoxData", parameters);
        }

        public DataTable SaveCategory(string workingTag, string loginId,
           CategoryEntity entity, string description)
        {
            OracleParameter[] parameters = new OracleParameter[13];
            parameters[0] = new OracleParameter("WorkingTag", workingTag);
            parameters[1] = new OracleParameter("CategoryId", entity.CategoryId);
            parameters[2] = new OracleParameter("CategoryName", entity.CategoryName);
            parameters[3] = new OracleParameter("DictionaryId", entity.DictionaryId);
            parameters[4] = new OracleParameter("IsActive", entity.IsActive);
            parameters[5] = new OracleParameter("ParentId", entity.ParentId);
            parameters[6] = new OracleParameter("pIsEdit", entity.IsEdit);
            parameters[7] = new OracleParameter("LoginId", loginId);
            parameters[8] = new OracleParameter("CategoryCode", entity.CategoryCode);
            parameters[9] = new OracleParameter("Motherid", entity.Motherid);
            parameters[10] = new OracleParameter("pIssubcode",entity.Issubcode);
            parameters[11] = new OracleParameter("pDescription", description);
            parameters[12] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.sp_Category_Save", parameters);
        }

        #endregion

        #region Category Value DataAccess

        public DataSet GetCategoryValue(string categoryId)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("CategoryId", categoryId);
            parameters[1] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[2] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataSet_SP("PKOPM_CATEGORY.sp_CategoryValue_Qry", parameters); ;
        }

        public DataTable SaveCategoryValue(string workingTag, string loginId, CategoryValueEntity entity)
        {
            OracleParameter[] parameters = new OracleParameter[13];
            parameters[0] = new OracleParameter("WorkingTag", workingTag);
            parameters[1] = new OracleParameter("catcode", entity.Code);
            parameters[2] = new OracleParameter("CategoryValueId", entity.CategoryValueId);
            parameters[3] = new OracleParameter("CategoryValue", OracleType.NVarChar) { Direction = ParameterDirection.Input, Value = entity.CategoryValue };
            parameters[4] = new OracleParameter("CategoryId", entity.CategoryId);
            parameters[5] = new OracleParameter("DictionaryId", entity.DictionaryId);
            parameters[6] = new OracleParameter("IsActive", entity.IsActive);
            parameters[7] = new OracleParameter("ParentId", entity.ParentId);
            parameters[8] = new OracleParameter("pOrderIndex", entity.OrderIndex);
            parameters[9] = new OracleParameter("pIsEdit", entity.IsEdit);
            parameters[10] = new OracleParameter("pSubCode", entity.SubCode);
            parameters[11] = new OracleParameter("LoginId", loginId);
            parameters[12] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.sp_CategoryValue_Save", parameters);
        }

        //Added by V. Xuan
        public DataTable GetCategoryValueDt(string categoryId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("CategoryId", categoryId);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_FORMANDMENU.sp_CategoryValue_Get_ByCateId", parameters);
        }

        public DataTable GetLocations()
        {
            return DBHelper.getDataTable_SP("sp_LocationMST_GetForPopup", null);
        }
        #endregion
        public static DataTable GetCategoryValue_Dictionary()
        {
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_DICTIONARY.SP_Dictioanry_loadForm", parameters);
        }
        public DataTable GetCategoryValue_Dictionary(string LangId)
        {
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_DICTIONARY.SP_Dictioanry_loadForm", parameters);
        }
        #region CategoryItemNm
        public static string getItemNm(string ItemId, string ItemCode, string CategoryId, string LangId)
        {
            string ItemNm = "", Condition = "";   
            DataTable dt = new DataTable();
            dt = GetCategoryValue_Dictionary();
            if (HttpContext.Current.Cache["Category"] == null)
            {
                //get table here
                HttpContext.Current.Cache["Category"] = dt;
            }
            else
                dt = (DataTable)HttpContext.Current.Cache["Category"];  
    
            Condition ="CATEGORY_ID='" + CategoryId + "'";

            if (ItemId !="")
                Condition = Condition + " and CAT_VALUE_ID='" + ItemId + "'";
            if (ItemCode!="")
                Condition = Condition + " and CAT_VALUE_CODE='" + ItemCode + "'";

    
            DataView dv = dt.DefaultView;
            dv.RowFilter = Condition; //dieu kien tim kiem


            if (dv.Count > 0)
            {
                ItemNm = dv[0]["ItemNm" + LangId].ToString();
            }

            return ItemNm;
        }

        #endregion

        public DataTable Category_Query(string pWorkingTag, string pCategoryList, string pLoginId)
        {

            string spName = "PKOPM_CATEGORY.sp_Category_Qry";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pListCategory", pCategoryList);
            param[2] = new OracleParameter("pLoginID", pLoginId);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }

        /* update by Mr.Mao*/
        public DataTable GetComboBoxSkindStaff(int categoryId, string parentId)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pCategoryId", categoryId);
            parameters[1] = new OracleParameter("pParentId", parentId);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.sp_GetComboboxSkindStaff", parameters);
        }
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /*DUY HUNG*/
        public DataTable SP_CATEGORY_QRY()
        {
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.SP_CATEGORY_QRY", parameters);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /*DUY HUNG*/
        public DataTable SP_CATEGORY_VALUE_QRY(string pCategoryID)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pCategoryID", pCategoryID);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.SP_CATEGORY_VALUE_QRY", parameters);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /*DUY HUNG*/
        public DataTable SP_CATEGORY_DELETE(string pCategoryID)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pCategoryID", pCategoryID);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.SP_CATEGORY_DELETE", parameters);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /*DUY HUNG*/
        public DataTable SP_CATEGORY_VALUE_DELETE(string pCatValueID)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pCatValueID", pCatValueID);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.SP_CATEGORY_VALUE_DELETE", parameters);
        }
        /*NHTHIEN SKILL CODE*/
        public DataTable GetCategoryValuesKill(string categoryId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pCategoryId", categoryId);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.SP_GETCOMBOBOXSKILL", parameters); ;
        }
        public DataTable GetSkillLevelByKill(string parentId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pParentId", parentId);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_CATEGORY.SP_GetSkillLevelByKill", parameters); ;
        }

        public DataTable getPlace(string categoryId, string categoryMotherId)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PCATEGORY_ID", categoryId);
            parameters[1] = new OracleParameter("PCATE_MOTHER_ID", categoryMotherId);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dtResult = DBHelper.getDataTable_SP("SP_PLACE_QUERY", parameters);
            return dtResult;
        }

    }
}