using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class ServiceAccess
    {
        #region Service Team
        public static DataTable LoadAllTeam()
        {
            string name = "sp_Service_Qry";
            return DBHelper.getDataTable_SP(name, null);
        }

        public static DataTable GetLocation(string serviceId)
        {
            string name = "sp_Service_GetLocation";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@ServiceId", serviceId);
            return DBHelper.getDataTable_SP(name, parameters);
        }

        public static DataTable LoadAllTeam(string LoginId)
        {
            string name = "sp_Service_Qry";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@LoginId", LoginId);
            return DBHelper.getDataTable_SP(name, parameters);
        }

        public static DataTable LoadSignture(string serviceId)
        {
            string spName = "sp_ServiceSignture";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@ServiceId", serviceId);
            return DBHelper.getDataTable_SP(spName, parameters);
        }

        public static DataTable GetUser()
        {
            return DBHelper.getDataTable_SP("sp_User_Popup", null); 
        }

        public static DataTable Save(string workingTag, ServiceEntity service, string loginId)
        {
            string name = "sp_Service_Save";
            OracleParameter[] parameters = new OracleParameter[14];
            parameters[0] = new OracleParameter("@WorkingTag", workingTag);
            parameters[1] = new OracleParameter("@ServiceId", service.ServiceId);
            parameters[2] = new OracleParameter("@CustomerId", service.CustomerId);
            parameters[3] = new OracleParameter("@UserId", service.UserId);
            parameters[4] = new OracleParameter("@Subscriber", service.Subscriber);
            parameters[5] = new OracleParameter("@Contents", service.Contents);
            parameters[6] = new OracleParameter("@TeamId", service.TeamId);
            parameters[7] = new OracleParameter("@StaffId", service.StaffId);
            parameters[8] = new OracleParameter("@ArrivalTime", service.ArrivalTime);
            parameters[9] = new OracleParameter("@CompletedTime", service.CompletedTime);
            parameters[10] = new OracleParameter("@ServiceStatus", service.ServiceStatus);
            parameters[11] = new OracleParameter("@Latitude", service.ArrivalLatitude);
            parameters[12] = new OracleParameter("@Longtitude", service.ArrivalLongtitude);
            parameters[13] = new OracleParameter("@LoginId", loginId);
            return DBHelper.getDataTable_SP(name, parameters);
        }
        #endregion

        #region Service Content
        public static DataTable LoadAllServiceContent(string serviceId, string languageId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("@ServiceId", serviceId);
            parameters[1] = new OracleParameter("@LanguageId", languageId);
            return DBHelper.getDataTable_SP("sp_ServiceContent_Qry", parameters);
        }

        public static DataTable LoadImage(string serviceContentId)
        {
            string spName = "sp_ServiceImage";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@ServiceContentId", serviceContentId);
            return DBHelper.getDataTable_SP(spName, parameters);
        }

        public static DataTable GetProductPart(string productId, string languageId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("@ProductId", productId);
            parameters[1] = new OracleParameter("@LanguageId", languageId);
            DataTable table = DBHelper.getDataTable_SP("sp_ProductPart_Popup", parameters);
            return table;
        }

        public static DataTable CheckProductPart(string productId, string serviceId, string serialNo)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("@ProductId", productId);
            parameters[1] = new OracleParameter("@CustomerId", serviceId);
            parameters[2] = new OracleParameter("@SerialNo", serialNo);
            DataTable dataTable = DBHelper.getDataTable_SP("sp_CheckProductPart", parameters);
            return dataTable;
        }

        public static DataTable Save(string workingTag, ServiceContentEntity team, string loginId)
        {
            string name = "sp_ServiceContent_Save";
            OracleParameter[] parameters = new OracleParameter[11];
            parameters[0] = new OracleParameter("@WorkingTag", workingTag);
            parameters[1] = new OracleParameter("@ServiceContentId", team.ServiceContentId);
            parameters[2] = new OracleParameter("@ServiceId", team.ServiceId);
            parameters[3] = new OracleParameter("@SerialNo", team.SerialNo);
            parameters[4] = new OracleParameter("@ServiceType", team.ServiceTypeId);
            parameters[5] = new OracleParameter("@ChargeType", team.ChargeTypeId);
            parameters[6] = new OracleParameter("@ProductId", team.ProductId);
            parameters[7] = new OracleParameter("@Quantity", team.Quantity);
            parameters[8] = new OracleParameter("@ChargedPrice", team.ChargedPrice);
            parameters[9] = new OracleParameter("@Remark", team.Remark);
            parameters[10] = new OracleParameter("@LoginId", loginId);
            return DBHelper.getDataTable_SP(name, parameters);

        }
        #endregion    
    }
}