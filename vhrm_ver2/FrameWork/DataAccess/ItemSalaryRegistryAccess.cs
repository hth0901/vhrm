using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class ItemSalaryRegistryAccess
    {
        public static DataTable Load(int itemType)
        {
            string query = "PKPayroll_SalaryREGISTRY.sp_T_PR_CM_SALARYITEM_Query";
            var parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pITEMTYPE", itemType);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) {Direction = ParameterDirection.Output};
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable Save(string workingTag, ItemSalaryRegistryEntity entity)
        {
            string spName = "PKPayroll_SalaryREGISTRY.sp_Save_T_PR_CM_SALARYITEM";
            OracleParameter[] parameters = new OracleParameter[12];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag ?? "");
            parameters[1] = new OracleParameter("p_ITEMNMVN", OracleType.NVarChar) {Value = entity.pItemNameVN ?? ""};
            parameters[2] = new OracleParameter("p_ITEMNM", entity.pItemName ?? "");
            parameters[3] = new OracleParameter("p_ITEMID", entity.pItemId ?? "");
            parameters[4] = new OracleParameter("p_ITEMTYPE", entity.pItemType);
            parameters[5] = new OracleParameter("p_Ui", entity.pUi ?? "");
            parameters[6] = new OracleParameter("pINPUT_KIND", entity.PInputKind ?? "");
            parameters[7] = new OracleParameter("pGROUPCD", entity.GroupCd ?? "");
            parameters[8] = new OracleParameter("pOrderIndex", entity.OrderIndex);
            parameters[9] = new OracleParameter("pGROUP_VER", entity.GroupVer ??"");
            parameters[10] = new OracleParameter("pIsContract",entity.IsContract ?? "");
            parameters[11] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
        public static DataTable GetComboBoxData(int categoryId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pCategoryId", categoryId);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKPayroll_SalaryREGISTRY.sp_GetComboBoxData", parameters);
        }
    }
}