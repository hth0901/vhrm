using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Data;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class HRCMRoleAccess
    {
        public static DataTable Query_CMRole(string pParentID)
        {
            string spName = "PKHR_CM_ROLE.SP_CM_ROLE_QUERY";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pParentID", pParentID);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public static DataTable Query_CMRole_Child(string pParentID)
        {
            string spName = "PKHR_CM_ROLE.SP_CM_ROLE_CHILD_QUERY";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pParentID", pParentID);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public static DataTable Save(string key, HRCMRoleEntity entity)
        {
            string spName = "PKHR_CM_ROLE.sp_T_HR_CM_ROLE_Save";
            OracleParameter[] parameters = new OracleParameter[9];
            parameters[0] = new OracleParameter("pkey", key ?? "");
            parameters[1] = new OracleParameter("pItemID", entity.ItemID ?? "");
            parameters[2] = new OracleParameter("pItemNM", OracleType.NVarChar) { Value = entity.ItemNM};
            parameters[3] = new OracleParameter("pParentID", entity.ParentID ?? "");
            parameters[4] = new OracleParameter("pOrderIndex", entity.OrderIndex);
            parameters[5] = new OracleParameter("pIsActive", entity.IsActive);
            parameters[6] = new OracleParameter("pCLSS", entity.CLSS??"");
            parameters[7] = new OracleParameter("pUID", entity.UID ?? "");
            parameters[8] = new OracleParameter("T_TABLE", OracleType.Cursor) {Direction = ParameterDirection.Output};
            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}