using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class PriceAccess
    {
        public static DataTable LoadData()
        {
            string spName = "ksyserpcoas.dbo.Daon_ProductPrice_Qry";
            return DBHelper.getDataTable_SP(spName, null);
        }

        public static DataTable Save(string workingTag, PriceEntity team, string loginId)
        {
            string spName = "sp_ProductPrice_Save";
            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("@WorkingTag", workingTag);
            parameters[1] = new OracleParameter("@PriceId", team.PriceId);
            parameters[2] = new OracleParameter("@ProductId", team.ProductId);
            parameters[3] = new OracleParameter("@BeginDate", team.BeginDate);
            parameters[4] = new OracleParameter("@EndDate", team.EndDate);
            parameters[5] = new OracleParameter("@Price", team.Price);
            parameters[6] = new OracleParameter("@LoginId", loginId);
            return DBHelper.getDataTable_SP(spName, parameters);
        }     
    }
}