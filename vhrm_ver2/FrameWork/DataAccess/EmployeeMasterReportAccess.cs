using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class EmployeeMasterReportAccess
    {
        public DataTable GetEmployeeReports()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMP_REPORT.SP_GETALL_EMP_REPORT", param);
        }
        
        public DataTable InsertEmployeeReport(EmployeeMasterReport employeeMaster)
        {
            OracleParameter[] param = new OracleParameter[15];
            param[0] = new OracleParameter("pREPORTCD", (object)employeeMaster.REPORTCD?? DBNull.Value);
            param[1] = new OracleParameter("pSYS_EMPID", (object)employeeMaster.SYS_EMPID ?? DBNull.Value);
            param[2] = new OracleParameter("pDEPTCODEGEO", (object)employeeMaster.DEPTCODEGEO ?? DBNull.Value);
            param[3] = new OracleParameter("pSYS_EMPIDGEO", (object)employeeMaster.SYS_EMPIDGEO ?? DBNull.Value);
            param[4] = new OracleParameter("pDEPTCODEFUN", (object)employeeMaster.DEPTCODEFUN ?? DBNull.Value);
            param[5] = new OracleParameter("pSYS_EMPIDFUN", (object)employeeMaster.SYS_EMPIDFUN ?? DBNull.Value);
            param[6] = new OracleParameter("pAPPLYDATE", (object)employeeMaster.APPLYDATE ?? DBNull.Value);
            param[7] = new OracleParameter("pISACTIVE", (object)employeeMaster.ISACTIVE ?? DBNull.Value);
            param[8] = new OracleParameter("pPOSITION", (object)employeeMaster.POSITION ?? DBNull.Value);
            param[9] = new OracleParameter("pSKILL", (object)employeeMaster.SKILL ?? DBNull.Value);
            param[10] = new OracleParameter("pREMARK", (object)employeeMaster.REMARK ?? DBNull.Value);
            param[11] = new OracleParameter("pLEVELGEO", (object)employeeMaster.LEVELGEO ?? DBNull.Value);
            param[12] = new OracleParameter("pLEVELFUN", (object)employeeMaster.LEVELFUN ?? DBNull.Value);
            param[13] = new OracleParameter("pCREATE_UID", (object)employeeMaster.CREATE_UID ?? DBNull.Value);
            param[14] = new OracleParameter("pUPDATE_UID", (object)employeeMaster.UPDATE_UID ?? DBNull.Value);            
            return DBHelper.getDataTable_SP("HR_EMP_REPORT.SP_INSERT_EMP_REPORT", param);
        }

        public DataTable UpdateEmployeeReport(EmployeeMasterReport employeeMaster)
        {
            OracleParameter[] param = new OracleParameter[14];
            param[0] = new OracleParameter("pREPORTCD", (object)employeeMaster.REPORTCD ?? DBNull.Value);
            param[1] = new OracleParameter("pSYS_EMPID", (object)employeeMaster.SYS_EMPID ?? DBNull.Value);
            param[2] = new OracleParameter("pDEPTCODEGEO", (object)employeeMaster.DEPTCODEGEO ?? DBNull.Value);
            param[3] = new OracleParameter("pSYS_EMPIDGEO", (object)employeeMaster.SYS_EMPIDGEO ?? DBNull.Value);
            param[4] = new OracleParameter("pDEPTCODEFUN", (object)employeeMaster.DEPTCODEFUN ?? DBNull.Value);
            param[5] = new OracleParameter("pSYS_EMPIDFUN", (object)employeeMaster.SYS_EMPIDFUN ?? DBNull.Value);
            param[6] = new OracleParameter("pAPPLYDATE", (object)employeeMaster.APPLYDATE ?? DBNull.Value);
            param[7] = new OracleParameter("pISACTIVE", (object)employeeMaster.ISACTIVE ?? DBNull.Value);
            param[8] = new OracleParameter("pPOSITION", (object)employeeMaster.POSITION ?? DBNull.Value);
            param[9] = new OracleParameter("pSKILL", (object)employeeMaster.SKILL ?? DBNull.Value);
            param[10] = new OracleParameter("pREMARK", (object)employeeMaster.REMARK ?? DBNull.Value);
            param[11] = new OracleParameter("pLEVELGEO", (object)employeeMaster.LEVELGEO ?? DBNull.Value);
            param[12] = new OracleParameter("pLEVELFUN", (object)employeeMaster.LEVELFUN ?? DBNull.Value);
            param[13] = new OracleParameter("pUPDATE_UID", (object)employeeMaster.UPDATE_UID ?? DBNull.Value);
            return DBHelper.getDataTable_SP("HR_EMP_REPORT.SP_UPDATE_EMP_REPORT", param);
        }
        public DataTable GetReportCDID()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMP_REPORT.SP_NEWREPORTCD_EMP_REPORT", param);
        }
        public DataTable getEmployeeReportBySysEmpID(string sys_empid)
        {
            OracleParameter[] param = new OracleParameter[2]; 
            param[0] = new OracleParameter("pSYS_EMPID", sys_empid);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMP_REPORT.SP_GETBYSYS_EMPID_EMP_REPORT", param);
        }
    }
}