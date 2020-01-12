using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class aFunctionAccess
    {
        public static DataTable getAllFunction()
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[1];
            _sqlParam[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtResult = DBHelper.getDataTable_SP("PKHR_FUNC_ORG_VER2.SP_GETALL_FUNCTION", _sqlParam);
            return dtResult;
        }

        public static DataTable getFunctionDetail(string funcCode)
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("PDEPTCODE", funcCode);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtResult = DBHelper.getDataTable_SP("PKHR_FUNC_ORG_VER2.SP_GET_FUNCTION_DETAIL", _sqlParam);
            return dtResult;
        }

        public static DataTable insertNewFunction(eFunctionItem dept)
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[6];
            _sqlParam[0] = new OracleParameter("pDeptName", string.IsNullOrEmpty(dept.FUNCNAME) ? "" : dept.FUNCNAME);
            _sqlParam[1] = new OracleParameter("pDeptShortName", string.IsNullOrEmpty(dept.SHORTNAME) ? "" : dept.SHORTNAME);
            _sqlParam[2] = new OracleParameter("pParentCode", string.IsNullOrEmpty(dept.FUNCPARENT) ? "" : dept.FUNCPARENT);
            _sqlParam[3] = new OracleParameter("pIsActive", dept.ISACTIVE);
            _sqlParam[4] = new OracleParameter("pUserId", dept.CREATE_UID);
            _sqlParam[5] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtResult = DBHelper.getDataTable_SP("PKHR_FUNC_ORG_VER2.SP_INSERT_FUNCTION", _sqlParam);
            return dtResult;
        }

        public static DataTable updateFunction(eFunctionItem dept)
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[6];
            _sqlParam[0] = new OracleParameter("PDEPTCODE", string.IsNullOrEmpty(dept.FUNCCODE) ? "" : dept.FUNCCODE);
            _sqlParam[1] = new OracleParameter("pDeptName", string.IsNullOrEmpty(dept.FUNCNAME) ? "" : dept.FUNCNAME);
            _sqlParam[2] = new OracleParameter("pDeptShortName", string.IsNullOrEmpty(dept.SHORTNAME) ? "" : dept.SHORTNAME);
            _sqlParam[3] = new OracleParameter("pIsActive", dept.ISACTIVE);
            _sqlParam[4] = new OracleParameter("pUserId", dept.UPDATE_UID);
            _sqlParam[5] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtResult = DBHelper.getDataTable_SP("PKHR_FUNC_ORG_VER2.SP_UPDATE_FUNCTION", _sqlParam);
            return dtResult;
        }

        public static DataTable getEmpReportByFunction(string funcCode)
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("PDEPTCODE", funcCode);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtResult = DBHelper.getDataTable_SP("PKHR_ORGANIZATION_VER2.SP_GET_REPORT_BY_FUNCTION", _sqlParam);
            return dtResult;
        }
    }
}