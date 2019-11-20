using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using vhrm.ViewModels;

namespace vhrm.FrameWork.DataAccess
{
    public class DeptAccess
    {
        #region Organization DataAccess
        public DataTable GetActivedDepartments()
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("ISACTIVE", "1");
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_DEPARTMENT.SP_GETALL_ISACTIVE_T_HR_DEPT", param);
        }
   
        public DataTable InsertDepartments(DeptViewModel deptViewModel)
        {           
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("pDEPTCODE", (object)deptViewModel.DEPTCODE ?? DBNull.Value);
            param[1] = new OracleParameter("pDEPTNAME", (object)deptViewModel.DEPTNAME ?? DBNull.Value);
            param[2] = new OracleParameter("pDEPTPARENT", (object)deptViewModel.DEPTPARENT ?? DBNull.Value);
            param[3] = new OracleParameter("pDEPTLEVEL", (object)deptViewModel.DEPTLEVEL ?? DBNull.Value);
            param[4] = new OracleParameter("pORDERINDEX", (object)deptViewModel.ORDERINDEX ?? DBNull.Value);
            param[5] = new OracleParameter("pISACTIVE", (object)deptViewModel.ISACTIVE ?? DBNull.Value);
            param[6] = new OracleParameter("pREMARK", (object)deptViewModel.REMARK ?? DBNull.Value);
            param[7] = new OracleParameter("pCREATE_UID", (object)deptViewModel.CREATE_UID ?? DBNull.Value);
            param[8] = new OracleParameter("pUPDATE_UID", (object)deptViewModel.UPDATE_UID ?? DBNull.Value);
            return DBHelper.getDataTable_SP("HR_DEPARTMENT.SP_INSERT_NEW_T_HR_DEPT", param);
        }
       
        public DataTable UpdateDepartments(DeptViewModel deptViewModel)
        {
            OracleParameter[] param = new OracleParameter[10];
            param[0] = new OracleParameter("pDEPTCODE", (object)deptViewModel.DEPTCODE ?? DBNull.Value);
            param[1] = new OracleParameter("pDEPTNAME", (object)deptViewModel.DEPTNAME ?? DBNull.Value);
            param[2] = new OracleParameter("pDEPTPARENT", (object)deptViewModel.DEPTPARENT ?? DBNull.Value);
            param[3] = new OracleParameter("pDEPTLEVEL", (object)deptViewModel.DEPTLEVEL ?? DBNull.Value);
            param[4] = new OracleParameter("pORDERINDEX", (object)deptViewModel.ORDERINDEX ?? DBNull.Value);
            param[5] = new OracleParameter("pISACTIVE", (object)deptViewModel.ISACTIVE ?? DBNull.Value);
            param[6] = new OracleParameter("pREMARK", (object)deptViewModel.REMARK ?? DBNull.Value);
            param[7] = new OracleParameter("pDEPTCODEOLD", (object)deptViewModel.DEPTCODEOLD ?? DBNull.Value);
            //param[8] = new OracleParameter("pCOMPCODE", (object)deptViewModel.COMPCODE ?? DBNull.Value);
            param[8] = new OracleParameter("pUPDATE_UID", (object)deptViewModel.UPDATE_UID ?? DBNull.Value);
            param[9] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_DEPARTMENT.SP_UPDATE_T_HR_DEPT", param);
        }
        public DataTable GetNewDeptCode(string deptCode)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pDEPTCODE", deptCode);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_DEPARTMENT.SP_NEWDEPTCODE_T_HR_DEPT", param);
        }
        #endregion
    }
}