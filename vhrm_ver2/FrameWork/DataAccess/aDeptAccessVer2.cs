using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class aDeptAccessVer2
    {
        public static DataTable getAllDept()
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[1];
            _sqlParam[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtResult = DBHelper.getDataTable_SP("PKHR_ORGANIZATION_VER2.SP_GETALL_DEPARTMENT", _sqlParam);
            return dtResult;
        }

        public static DataTable getDeptDetail(string deptcode)
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("PDEPTCODE", deptcode);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtResult = DBHelper.getDataTable_SP("PKHR_ORGANIZATION_VER2.SP_GET_DEPT_DETAIL", _sqlParam);
            return dtResult;
        }

        public static DataTable insertNewDept(eDepartmentItem dept)
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[6];
            _sqlParam[0] = new OracleParameter("pDeptName", string.IsNullOrEmpty(dept.DEPTNAME) ? "" : dept.DEPTNAME);
            _sqlParam[1] = new OracleParameter("pDeptShortName", string.IsNullOrEmpty(dept.DEPTSHORTNAME) ? "" : dept.DEPTSHORTNAME);
            _sqlParam[2] = new OracleParameter("pParentCode", string.IsNullOrEmpty(dept.DEPTPARENT) ? "" : dept.DEPTPARENT);
            _sqlParam[3] = new OracleParameter("pIsActive", dept.ISACTIVE);
            _sqlParam[4] = new OracleParameter("pUserId", dept.CREATE_UID);
            _sqlParam[5] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtResult = DBHelper.getDataTable_SP("PKHR_ORGANIZATION_VER2.SP_INSERT_DEPARTMENT", _sqlParam);
            return dtResult;
        }

        public static DataTable updateDept(eDepartmentItem dept)
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[6];
            _sqlParam[0] = new OracleParameter("PDEPTCODE", string.IsNullOrEmpty(dept.DEPTCODE) ? "" : dept.DEPTCODE);
            _sqlParam[1] = new OracleParameter("pDeptName", string.IsNullOrEmpty(dept.DEPTNAME) ? "" : dept.DEPTNAME);
            _sqlParam[2] = new OracleParameter("pDeptShortName", string.IsNullOrEmpty(dept.DEPTSHORTNAME) ? "" : dept.DEPTSHORTNAME);
            _sqlParam[3] = new OracleParameter("pIsActive", dept.ISACTIVE);
            _sqlParam[4] = new OracleParameter("pUserId", dept.UPDATE_UID);
            _sqlParam[5] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtResult = DBHelper.getDataTable_SP("PKHR_ORGANIZATION_VER2.SP_UPDATE_DEPARTMENT", _sqlParam);
            return dtResult;
        }

        public static DataTable getEmpReportByDept(string deptcode)
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("PDEPTCODE", deptcode);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtResult = DBHelper.getDataTable_SP("PKHR_ORGANIZATION_VER2.SP_GET_REPORT_BY_DEPT", _sqlParam);
            return dtResult;
        }
    }
}