using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using vhrm.ViewModels;

namespace vhrm.FrameWork.DataAccess
{
    public class FunctAccess
    {
        #region Function DataAccess
        public DataTable GetFunctions()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_DEPTFUNCT.SP_GETALL_T_HR_DEPTFUNCT", param);
        }
        public DataTable InsertFunctions(FunctViewModel functViewModel)
        {
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("pFUNCCODE", functViewModel.FUNCCODE) { Direction = ParameterDirection.Input };
            param[1] = new OracleParameter("pFUNCNAME", (object)functViewModel.FUNCNAME ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[2] = new OracleParameter("pFUNCPARENT", (object)functViewModel.FUNCPARENT ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[3] = new OracleParameter("pFUNCLEVEL", (object)functViewModel.FUNCLEVEL ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[4] = new OracleParameter("pORDERINDEX", (object)functViewModel.ORDERINDEX) { Direction = ParameterDirection.Input };
            param[5] = new OracleParameter("pISACTIVE", (object)functViewModel.ISACTIVE ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[6] = new OracleParameter("pREMARK", (object)functViewModel.REMARK ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[7] = new OracleParameter("pCREATE_UID", (object)functViewModel.CREATE_UID ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[8] = new OracleParameter("pUPDATE_UID", (object)functViewModel.CREATE_UID ?? DBNull.Value) { Direction = ParameterDirection.Input };
            return DBHelper.getDataTable_SP("HR_DEPTFUNCT.SP_INSERT_NEW_T_HR_DEPTFUNCT", param);
        }
        public DataTable UpdateFunctions(FunctViewModel functViewModel)
        {
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("pFUNCCODE", functViewModel.FUNCCODE) { Direction = ParameterDirection.Input };
            param[1] = new OracleParameter("pFUNCNAME", (object)functViewModel.FUNCNAME ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[2] = new OracleParameter("pFUNCPARENT", (object)functViewModel.FUNCPARENT ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[3] = new OracleParameter("pFUNCLEVEL", (object)functViewModel.FUNCLEVEL ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[4] = new OracleParameter("pORDERINDEX", (object)functViewModel.ORDERINDEX) { Direction = ParameterDirection.Input };
            param[5] = new OracleParameter("pISACTIVE", (object)functViewModel.ISACTIVE ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[6] = new OracleParameter("pREMARK", (object)functViewModel.REMARK ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[7] = new OracleParameter("pUPDATE_UID", (object)functViewModel.UPDATE_UID ?? DBNull.Value) { Direction = ParameterDirection.Input };
            param[8] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_DEPTFUNCT.SP_UPDATE_T_HR_DEPTFUNCT", param);
        }
        public DataTable GetNewFunctCode(string functCode)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pFUNCCODE", functCode);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_DEPTFUNCT.SP_NEWFUNCTIONCODE_DEPTFUNCT", param);
        }
        #endregion
    }
}