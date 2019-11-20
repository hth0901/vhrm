using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.DataAccess
{
    public class ProductCheckAccess
    {
        public static DataTable LoadData()
        {
            string spName = "sp_ProductCheckList_Qry";
            return DBHelper.getDataTable_SP(spName, null);
        }

        public static DataTable Save(string workingTag, int checkId,
            string productId, string content, string loginId)
        {
            OracleParameter[] sqlParam = new OracleParameter[5];
            sqlParam[0] = new OracleParameter("@WorkingTag", workingTag);
            sqlParam[1] = new OracleParameter("@CheckId", checkId);
            sqlParam[2] = new OracleParameter("@ProductId", productId);
            sqlParam[3] = new OracleParameter("@Content", content);
            sqlParam[4] = new OracleParameter("@LoginId", loginId);

            return DBHelper.getDataTable_SP("sp_ProductCheckListSave", sqlParam);
        }
    }
}