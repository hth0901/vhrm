using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Data;

namespace vhrm.FrameWork.DataAccess
{
    public class DepartLineAccess
    {
        #region Dept
        public static DataTable LoadgrdDept(string pDEPTCODE)
        {
            string query = "PK_HR_ORGANIZATION.sp_Dept_Detail_Master_Query";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pDEPTCODE", pDEPTCODE);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        #endregion
        #region line
        public static DataTable LoadLine(string deptCode)
        {
            string query = "PK_HR_ORGANIZATION.sp_DepartLine_Query";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pDeptCode", deptCode ?? "");
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        #endregion
        #region Combobox
        public static DataTable LoadCmbCorporation()
        {
            string query = "PK_HR_ORGANIZATION.sp_LoadCorportion_Query";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        #endregion
        public static DataTable Save(string DeptCode, string SectionName)
        {
            string spName = "PK_HR_ORGANIZATION.sp_DepartLine_Save";
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pDeptCode", DeptCode ?? "");
            parameters[1] = new OracleParameter("pSectionName", SectionName ?? "");
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
        public static DataTable Delete(string pLINECD)
        {
            string spName = "PK_HR_ORGANIZATION.sp_DepartLine_Delete";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pLINECD", pLINECD);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}