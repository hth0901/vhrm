using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class DepartmentAccess
    {
        public static DataTable Load()
        {
            string query = "PK_HR_ORGANIZATION.sp_Department_Qry";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
      
        public static DataTable Save(string workingTag, DepartmentEntity entity, string loginId)
        {
            string spName = "PK_HR_ORGANIZATION.sp_Department_Save";
            OracleParameter[] parameters = new OracleParameter[10];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag ?? "");
            parameters[1] = new OracleParameter("pDepartmentCode", entity.DepartmentCode ?? "");
            parameters[2] = new OracleParameter("pGroupCode", entity.GroupCode ?? "");
            parameters[3] = new OracleParameter("pFullName", entity.FullName ?? "");
            parameters[4] = new OracleParameter("pShortName", entity.ShortName ?? "");
            parameters[5] = new OracleParameter("pDictionary", entity.Dictionary ?? "");
            parameters[6] = new OracleParameter("pDescription", entity.Description ?? "");
            parameters[7] = new OracleParameter("pIsActive", entity.IsActive ?? "");
            parameters[8] = new OracleParameter("pLoginId", loginId );
            parameters[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}