using System.Data;
using Oracle.ManagedDataAccess.Client;
//using KSN.Framework.Entity;
using vhrm.FrameWork.Entity;

namespace KSN.Framework.DataAccess
{
    public class OrganazationAccess
    {
        public static DataTable Load(string level)
        {
            string query = "PK_HR_ORGANIZATION.sp_Origanaztion_Qry";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pLevel", level);
            parameters[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable LoadTreeViewDetail(string value)
        {
            string query = "PK_HR_ORGANIZATION.sp_Origanaztion_TreeViewSelect";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pDeptCode", value);
            parameters[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable LoadTreeView()
        {
            string query = "PK_HR_ORGANIZATION.sp_Origanaztion_TreeView";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        
        public static DataTable Save(string workingTag, OrganazationEntity entity, string loginId)
        {
            string spName = "PK_HR_ORGANIZATION.sp_Origanaztion_Save";
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag ?? "");
            parameters[1] = new OracleParameter("pDepartmentCode", entity.DepartmentCode ?? "");
            parameters[2] = new OracleParameter("pOrganization", entity.Organazation ?? "");
            parameters[3] = new OracleParameter("pParentId", entity.ParentId ?? "");
            parameters[4] = new OracleParameter("pLoginId", loginId);
            parameters[5] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}