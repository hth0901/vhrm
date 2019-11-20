using vhrm.ViewModels;
using vhrm.FrameWork.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using vhrm.Models;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bCategoryConfig
    {
        public static List<CategoryModel> getCategory()
        {
            List<CategoryModel> result = new List<CategoryModel>();
            CategoryAccess access = new CategoryAccess();
            DataTable dtResult = access.SP_CATEGORY_QRY();
            foreach(DataRow dtr in dtResult.Rows)
            {
                CategoryModel item = new CategoryModel
                {
                    CATEGORY_ID = dtr["CATEGORY_ID"].ToString(),
                    CATEGORY_NAME = dtr["CATEGORY_NAME"].ToString(),
                    DICTIONARY_ID = dtr["DICTIONARY_ID"].ToString(),
                    MOTHER_CAT_ID = dtr["MOTHER_CAT_ID"].ToString(),
                    IS_ACTIVE = dtr["IS_ACTIVE"].ToString() == "1",
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                    ISEDIT = dtr["ISEDIT"].ToString() == "1",
                    CATEGORY_CODE = dtr["CATEGORY_CODE"].ToString(),
                    MOTHER_ID = dtr["MOTHER_ID"].ToString(),
                    ISSUBCODE = dtr["ISSUBCODE"].ToString() == "1",
                    DESCRIPTION = dtr["DESCRIPTION"].ToString(),
                    IS_ACTIVE2 = dtr["IS_ACTIVE2"].ToString(),
                    DESCTRIM = dtr["DESCTRIM"].ToString(),
                    DICTIONARY_ID2 = dtr["DICTIONARY_ID2"].ToString(),
                };
                if (!string.IsNullOrEmpty(dtr["CREATE_DT"].ToString()))
                    item.CREATE_DT = DateTime.Parse(dtr["CREATE_DT"].ToString());
                if (!string.IsNullOrEmpty(dtr["UPDATE_DT"].ToString()))
                    item.UPDATE_DT = DateTime.Parse(dtr["UPDATE_DT"].ToString());

                result.Add(item);
            }

            return result;
        }

        public static List<CategoryValueModel> GetCategoryValue(string catId)
        {
            List<CategoryValueModel> result = new List<CategoryValueModel>();
            CategoryAccess access = new CategoryAccess();
            DataTable dtResult = access.SP_CATEGORY_VALUE_QRY(catId);
            foreach (DataRow dtr in dtResult.Rows)
            {
                CategoryValueModel item = new CategoryValueModel
                {
                    CAT_VALUE_ID = dtr["CAT_VALUE_ID"].ToString(),
                    CAT_CODE = dtr["CAT_CODE"].ToString(),
                    CAT_VALUE = dtr["CAT_VALUE"].ToString(),
                    CATEGORY_ID = dtr["CATEGORY_ID"].ToString(),
                    SEQ = dtr["SEQ"].ToString(),
                    DICTIONARY_ID = dtr["DICTIONARY_ID"].ToString(),
                    MOTHER_ID = dtr["MOTHER_ID"].ToString(),
                    MOTHER_NAME = dtr["MOTHER_NAME"].ToString(),
                    IS_ACTIVE = dtr["IS_ACTIVE"].ToString() == "1",
                    ORDERINDEX = dtr["ORDERINDEX"].ToString(),
                    ISEDIT = dtr["ISEDIT"].ToString() == "1",
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                    SUBCODE = dtr["SUBCODE"].ToString(),
                    IS_ACTIVE2 = dtr["IS_ACTIVE2"].ToString(),
                    DICTIONARY_ID2 = dtr["DICTIONARY_ID2"].ToString(),
                };
                if (!string.IsNullOrEmpty(dtr["CREATE_DT"].ToString()))
                    item.CREATE_DT = DateTime.Parse(dtr["CREATE_DT"].ToString());
                if (!string.IsNullOrEmpty(dtr["UPDATE_DT"].ToString()))
                    item.UPDATE_DT = DateTime.Parse(dtr["UPDATE_DT"].ToString());

                result.Add(item);
            }

            return result;
        }

        public static List<CategoryItemViewModel> categoryQueryById(string catId)
        {
            DataTable dtCombo = new DataTable();
            CategoryAccess _access = new CategoryAccess();
            dtCombo = _access.Category_Query("Q", catId, "");
            List<CategoryItemViewModel> result = new List<CategoryItemViewModel>();
            foreach(DataRow dtr in dtCombo.Rows)
            {
                CategoryItemViewModel item = new CategoryItemViewModel
                {
                    DATATEXTFIELD = dtr["DATATEXTFIELD"].ToString(),
                    DATAVALUEFIELD = dtr["DATAVALUEFIELD"].ToString()
                };
                result.Add(item);
            }

            return result;
        }
    }
}