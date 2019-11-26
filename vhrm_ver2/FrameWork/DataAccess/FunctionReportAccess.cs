using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class FunctionReportAccess
    {
        public DataTable GetFunctionReports()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_GETALL_FUNC_REPORT", param);
        }        
        public DataTable getFunctReportsRegistered()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_GETREGISTERED_FUNC_REPORT", param);//Need to add database.
        }
        public DataTable GetTreeFunctionReports()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_GETTREE_NEW_FUNC_REPORT", param);
        }
        
        public DataTable GetUsersFunctionReports(string funccode)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pFUNCCODE", (object)funccode ?? DBNull.Value);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_GETUSER_FUNC_REPORT", param);
        }
        public DataTable GetUsersFunctionForReports(string funccode)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pFUNCCODE", (object)funccode ?? DBNull.Value);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_GETUSER_FUNCTION_REPORT", param);
        }
        public DataTable InsertFunctReport(string functCode, string sysEmpId)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pFUNCCODE", (object)functCode ?? DBNull.Value);
            param[1] = new OracleParameter("pSYS_EMPID", (object)sysEmpId ?? DBNull.Value);
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_INSERT_FUNC_REPORT", param);
        }
        public DataTable DeleteFunctReportByFKey(string functCode, string sysEmpId)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pFUNCCODE", (object)functCode ?? DBNull.Value);
            param[1] = new OracleParameter("pSYS_EMPID", (object)sysEmpId ?? DBNull.Value);
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_DELETEBYFKEY_FUNC_REPORT", param);
        }
        public DataTable DeleteFunctReport(string functRortCd)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("pFUNCPORTCD", (object)functRortCd ?? DBNull.Value);
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_DELETE_FUNC_REPORT", param);
        }

        public static DataTable updateFunctReport(eFunctReportItem eReport, string userId)
        {
            OracleParameter[] sqlParam = new OracleParameter[7];
            sqlParam[0] = new OracleParameter("PFUNCPORTCD", eReport.FUNCREPORTCD);
            sqlParam[1] = new OracleParameter("PFUNCCODE", eReport.FUNCCODE);
            sqlParam[2] = new OracleParameter("PSYS_EMPID", eReport.SYS_EMPID);
            sqlParam[3] = new OracleParameter("PAPPLYDATE", eReport.APPLYDATE.ToString("yyyyMMdd"));
            sqlParam[4] = new OracleParameter("PISACTIVE", eReport.ISACTIVE ? "1" : "0");
            sqlParam[5] = new OracleParameter("PUSER", userId);
            sqlParam[6] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_UPDATE_FUNCT_REPORT", sqlParam);
        }
        public static DataTable insertNewGeoReport(eFunctReportItem eReport, string userId)
        {
            OracleParameter[] sqlParam = new OracleParameter[6];
            sqlParam[0] = new OracleParameter("PFUNCCODE", eReport.FUNCCODE);
            sqlParam[1] = new OracleParameter("PSYS_EMPID", eReport.SYS_EMPID);
            sqlParam[2] = new OracleParameter("PAPPLYDATE", eReport.APPLYDATE.ToString("yyyyMMdd"));
            //sqlParam[3] = new OracleParameter("UPDATE_DT", formEntity.UPDATE_DT);
            sqlParam[3] = new OracleParameter("PISACTIVE", eReport.ISACTIVE ? "1" : "0");
            sqlParam[4] = new OracleParameter("PUSER", userId);
            sqlParam[5] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_INSERT_NEWFUNCT_REPORT", sqlParam);
        }
        public static DataTable getFunctReportByFunctCode(string functCode)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PFUNCCODE", functCode);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_FUNC_REPORT.SP_GET_REPORT_BY_FUNCCODE", param);
        }

    }
}