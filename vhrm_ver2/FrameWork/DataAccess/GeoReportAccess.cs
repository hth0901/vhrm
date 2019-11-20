using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class GeoReportAccess
    {
        public DataTable GetGeoReports()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_GEO_REPORT.SP_GETALL_GEO_REPORT", param);
        }
        //SP_GETREGISTERED_GEO_REPORT NEED ADD TO DATABASE.
        public DataTable GetTreeGeoReportsRegistered()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_GEO_REPORT.SP_GETREGISTERED_GEO_REPORT", param);
        }
        public DataTable GetTreeGeoReports()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_GEO_REPORT.SP_GETTREE_GEO_REPORT", param);
        }

        public DataTable GetUserGeoReports(string funccode)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pDEPTCODE", (object)funccode ?? DBNull.Value);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_GEO_REPORT.SP_GET_USERGEO_REPORT_BY_DEPT", param);
        }
        public static DataTable getReportByDepartment(string deptcode)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PDEPTCODE", deptcode);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            //return DBHelper.getDataTable_SP("HR_GEO_REPORT.SP_GET_REPORT_BY_DEPT", param);
            return DBHelper.getDataTable_SP("HR_GEO_REPORT.SP_GET_REPORT_BY_DEPT_VER2", param);
        }
        public static DataTable insertNewGeoReport(eGeoReportItem eReport, string userId)
        {
            OracleParameter[] sqlParam = new OracleParameter[6];
            sqlParam[0] = new OracleParameter("PDEPTCODE", eReport.DEPTCODE);
            sqlParam[1] = new OracleParameter("PSYS_EMPID", eReport.SYS_EMPID);
            sqlParam[2] = new OracleParameter("PAPPLYDATE", eReport.APPLYDATE.ToString("yyyyMMdd"));
            //sqlParam[3] = new OracleParameter("UPDATE_DT", formEntity.UPDATE_DT);
            sqlParam[3] = new OracleParameter("PISACTIVE", eReport.ISACTIVE ? "1" : "0");
            sqlParam[4] = new OracleParameter("PUSER", userId);
            sqlParam[5] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            //return DBHelper.getDataTable_SP("HR_GEO_REPORT.SP_INSERT_GEO_REPORT", sqlParam);
            return DBHelper.getDataTable_SP("HR_GEO_REPORT.SP_INSERT_GEO_REPORT_VER2", sqlParam);
        }

        public static DataTable updateGeoReport(eGeoReportItem eReport, string userId)
        {
            OracleParameter[] sqlParam = new OracleParameter[7];
            sqlParam[0] = new OracleParameter("PREPORTCODE", eReport.GEOREPORTCD);
            sqlParam[1] = new OracleParameter("PDEPTCODE", eReport.DEPTCODE);
            sqlParam[2] = new OracleParameter("PSYS_EMPID", eReport.SYS_EMPID);
            sqlParam[3] = new OracleParameter("PAPPLYDATE", eReport.APPLYDATE.ToString("yyyyMMdd"));
            sqlParam[4] = new OracleParameter("PISACTIVE", eReport.ISACTIVE ? "1" : "0");
            sqlParam[5] = new OracleParameter("PUSER", userId);
            sqlParam[6] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_GEO_REPORT.SP_UPDATE_GEO_REPORT", sqlParam);
        }
    }
}