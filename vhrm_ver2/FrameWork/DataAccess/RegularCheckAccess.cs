using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.DataAccess
{
    public class RegularCheckAccess
    {
        public static DataTable Load()
        {
            string spName = "sp_RegularCheck_Qry";
            return DBHelper.getDataTable_SP(spName, null);
        }
        public static DataTable Load(string LoginId)
        {
            string spName = "sp_RegularCheck_Qry";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@LoginId", LoginId);
            return DBHelper.getDataTable_SP(spName, parameters);
        }

        public static DataTable LoadSignture(string checkId)
        {
            string spName = "sp_RegularSignture";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@CheckId", checkId);
            return DBHelper.getDataTable_SP(spName, parameters);
        }

        public static DataTable LoadEquipment(string checkId)
        {
            string spName = "sp_RegularCheckEQ_Qry";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@CheckId", checkId);
            return DBHelper.getDataTable_SP(spName, parameters);
        }

        public static DataTable LoadCheckList(string equipmentId)
        {
            string spName = "sp_RegularCheckItem_Qry";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@EquipmentId", equipmentId);
            return DBHelper.getDataTable_SP(spName, parameters);
        }
        
        public static DataTable LoadPhoto(string equipmentId)
        {
            string spName = "sp_RegularCheckPhoto_Qry";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@EquipmentId", equipmentId);
            return DBHelper.getDataTable_SP(spName, parameters);
        }
       
    }
}