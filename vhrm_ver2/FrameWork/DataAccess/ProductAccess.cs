using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.DataAccess
{
    public class ProductAccess
    {
        #region Product
        public static DataTable GetProduct()
        {
            string name = "ksyserpcoas.dbo.Daon_ProductQry";
            return DBHelper.getDataTable_SP(name, null);
        }
        #endregion

        #region Product part
        public static DataTable GetProductPart(string productId)
        {
            OracleParameter[] sqlParam = new OracleParameter[1];
            sqlParam[0] = new OracleParameter("@ProductId", productId);
            DataTable table = DBHelper.getDataTable_SP("sp_ProductPartGetByProductId", sqlParam);
            return table;
        }

        public static DataTable GetPriceHistory(string productId)
        {
            OracleParameter[] sqlParam = new OracleParameter[1];
            sqlParam[0] = new OracleParameter("@ProductId", productId);
            DataTable table = DBHelper.getDataTable_SP("ksyserpcoas.dbo.Daon_GetPriceHistory ", sqlParam);
            return table;
        }

        public static DataTable ProductPartSave(string workingTag, int partId,
            string mainProductId, string subProductId, string loginId)
        {
            OracleParameter[] sqlParam = new OracleParameter[5];
            sqlParam[0] = new OracleParameter("@WorkingTag", workingTag);
            sqlParam[1] = new OracleParameter("@PartId", partId);
            sqlParam[2] = new OracleParameter("@MainProductId", mainProductId);
            sqlParam[3] = new OracleParameter("@SubProductId", subProductId);
            sqlParam[4] = new OracleParameter("@LoginId", loginId);

            return DBHelper.getDataTable_SP("sp_ProductPartSave", sqlParam);
        }
        #endregion
    }
}