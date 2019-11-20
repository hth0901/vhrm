using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.DataAccess
{
    public class ServiceTeamAccess
    {
        public static DataTable LoadAllTeam()
        {
            string spName = "ksyserpcoas.dbo.Daon_GetTeam";
            return DBHelper.getDataTable_SP(spName, null);
        }

        public static DataTable LoadAllTeamStaff(string teamId)
        {
            string spName = "ksyserpcoas.dbo.Daon_GetTeamStaff";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@TeamId", teamId);
            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}