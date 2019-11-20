using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.DataAccess
{
    public class StaffAccess
    {
        public static DataTable LoadData()
        {
            string name = "ksyserpcoas.dbo.Daon_GetStaff";
            return DBHelper.getDataTable_SP(name, null);
        }

        public static DataTable LoadPopup(string jobTitle, string teamId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("@JobTitle", jobTitle);
            parameters[1] = new OracleParameter("@TeamId", teamId);
            return DBHelper.getDataTable_SP("ksyserpcoas.dbo.Daon_StaffPopup", parameters);
        }
    }
}