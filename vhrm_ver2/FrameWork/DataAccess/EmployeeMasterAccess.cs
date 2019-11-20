using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class EmployeeMasterAccess
    {
        #region Employee Access
        public DataTable GetEmployees()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_GETALL_EMPLOYEES", param);
        }
        
        public DataTable getCategories()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_GETNATIONAL", param);
        }
        public DataTable getPositions()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_GETPOSITION", param);
        }
        public DataTable getSkills()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_SKILL", param);
        }
        public DataTable getAcademicLevels()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_GETACADEMICLEVEL", param);
        }
        public DataTable InsertEmployee(EmployeeMaster employeeMaster)
        {
            OracleParameter[] param = new OracleParameter[30];
            param[0] = new OracleParameter("pSYS_EMPID", (object)employeeMaster.SYS_EMPID ?? DBNull.Value);
            param[1] = new OracleParameter("pEMPID", (object)employeeMaster.EMPID ?? DBNull.Value);
            param[2] = new OracleParameter("pEMPNAME", (object)employeeMaster.EMPNAME ?? DBNull.Value);
            param[3] = new OracleParameter("pCOMPCODE", (object)employeeMaster.COMPCODE ?? DBNull.Value);
            param[4] = new OracleParameter("pDEPTCODE", (object)employeeMaster.DEPTCODE ?? DBNull.Value);
            param[5] = new OracleParameter("pFUNCDEPT", (object)employeeMaster.FUNCDEPT ?? DBNull.Value);
            param[6] = new OracleParameter("pJOBCODE", (object)employeeMaster.JOBCODE ?? DBNull.Value);
            param[7] = new OracleParameter("pJOBFIELD", (object)employeeMaster.JOBFIELD ?? DBNull.Value);
            param[8] = new OracleParameter("pDUTY", (object)employeeMaster.DUTY ?? DBNull.Value);
            //param[9] = new OracleParameter("pBIRTHDATE", (object)employeeMaster.BIRTHDATE ?? DBNull.Value);
            string dBirday = string.Empty;
            
            if (employeeMaster.BIRTHDATE == null)
                param[9] = new OracleParameter("pBIRTHDATE", DBNull.Value);
            else
            {
                DateTime birdday = (DateTime)employeeMaster.BIRTHDATE;
                param[9] = new OracleParameter("pBIRTHDATE", (object)birdday.ToString("yyyyMMdd"));
            }
            param[10] = new OracleParameter("pBIRTHPLACE", (object)employeeMaster.BIRTHPLACE ?? DBNull.Value);
            param[11] = new OracleParameter("pGENDER", (object)employeeMaster.GENDER ?? DBNull.Value);
            param[12] = new OracleParameter("pSTATUS", (object)employeeMaster.STATUS ?? DBNull.Value);
            param[13] = new OracleParameter("pEMAIL", (object)employeeMaster.EMAIL ?? DBNull.Value);
            param[14] = new OracleParameter("pPHONE", (object)employeeMaster.PHONE ?? DBNull.Value);
            param[15] = new OracleParameter("pNATIONALITY", (object)employeeMaster.NATIONALITY ?? DBNull.Value);
            DateTime dateJoin = (DateTime)employeeMaster.DATEJOIN;
            param[16] = new OracleParameter("pDATEJOIN", (object)dateJoin.ToString("yyyyMMdd"));
            param[17] = new OracleParameter("pIDENTITYCARD", (object)employeeMaster.IDENTITYCARD ?? DBNull.Value);
            param[18] = new OracleParameter("pIDISSUEDPLACE", (object)employeeMaster.IDISSUEDPLACE ?? DBNull.Value);
            param[19] = new OracleParameter("pIDISSUEDDATE", (object)employeeMaster.IDISSUEDDATE ?? DBNull.Value);
            param[20] = new OracleParameter("pACADEMIC", (object)employeeMaster.ACADEMIC ?? DBNull.Value);
            param[21] = new OracleParameter("pDATERESIGNED", (object)employeeMaster.DATERESIGNED ?? DBNull.Value);
            param[22] = new OracleParameter("pFINGERPRINT", (object)employeeMaster.FINGERPRINT ?? DBNull.Value);
            param[23] = new OracleParameter("pFINGERINDEX", (object)employeeMaster.FINGERINDEX ?? DBNull.Value);
            param[24] = new OracleParameter("pIMAGE", (object)employeeMaster.IMAGE ?? DBNull.Value);
            param[25] = new OracleParameter("pPOSITION", (object)employeeMaster.POSITION ?? DBNull.Value);
            param[26] = new OracleParameter("pSKILL", (object)employeeMaster.SKILL?? DBNull.Value);
            param[27] = new OracleParameter("pSYS_EMPIDOLD", (object)employeeMaster.SYS_EMPIDOLD ?? DBNull.Value);
            param[28] = new OracleParameter("pCREATE_UID", (object)employeeMaster.CREATE_UID ?? DBNull.Value);
            param[29] = new OracleParameter("pUPDATE_UID", (object)employeeMaster.CREATE_UID ?? DBNull.Value);
            //param[30] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_INSERT_EMPLOYEE", param);
        }

        public DataTable UpdateEmployee(EmployeeMaster employeeMaster)
        {
            OracleParameter[] param = new OracleParameter[29];
            param[0] = new OracleParameter("pSYS_EMPID", (object)employeeMaster.SYS_EMPID ?? DBNull.Value);
            param[1] = new OracleParameter("pEMPID", (object)employeeMaster.EMPID ?? DBNull.Value);
            param[2] = new OracleParameter("pEMPNAME", (object)employeeMaster.EMPNAME ?? DBNull.Value);
            param[3] = new OracleParameter("pCOMPCODE", (object)employeeMaster.COMPCODE ?? DBNull.Value);
            param[4] = new OracleParameter("pDEPTCODE", (object)employeeMaster.DEPTCODE ?? DBNull.Value);
            param[5] = new OracleParameter("pFUNCDEPT", (object)employeeMaster.FUNCDEPT ?? DBNull.Value);
            param[6] = new OracleParameter("pJOBCODE", (object)employeeMaster.JOBCODE ?? DBNull.Value);
            param[7] = new OracleParameter("pJOBFIELD", (object)employeeMaster.JOBFIELD ?? DBNull.Value);
            param[8] = new OracleParameter("pDUTY", (object)employeeMaster.DUTY ?? DBNull.Value);
            if (employeeMaster.BIRTHDATE == null)
                param[9] = new OracleParameter("pBIRTHDATE", DBNull.Value);
            else
            {
                DateTime birdday = (DateTime)employeeMaster.BIRTHDATE;
                param[9] = new OracleParameter("pBIRTHDATE", (object)birdday.ToString("yyyyMMdd"));
            }
            param[10] = new OracleParameter("pBIRTHPLACE", (object)employeeMaster.BIRTHPLACE ?? DBNull.Value);
            param[11] = new OracleParameter("pGENDER", (object)employeeMaster.GENDER ?? DBNull.Value);
            param[12] = new OracleParameter("pSTATUS", (object)employeeMaster.STATUS ?? DBNull.Value);
            param[13] = new OracleParameter("pEMAIL", (object)employeeMaster.EMAIL ?? DBNull.Value);
            param[14] = new OracleParameter("pPHONE", (object)employeeMaster.PHONE ?? DBNull.Value);
            param[15] = new OracleParameter("pNATIONALITY", (object)employeeMaster.NATIONALITY ?? DBNull.Value);
            DateTime dateJoin = (DateTime)employeeMaster.DATEJOIN;
            param[16] = new OracleParameter("pDATEJOIN", (object)dateJoin.ToString("yyyyMMdd"));
            param[17] = new OracleParameter("pIDENTITYCARD", (object)employeeMaster.IDENTITYCARD ?? DBNull.Value);
            param[18] = new OracleParameter("pIDISSUEDPLACE", (object)employeeMaster.IDISSUEDPLACE ?? DBNull.Value);
            param[19] = new OracleParameter("pIDISSUEDDATE", (object)employeeMaster.IDISSUEDDATE ?? DBNull.Value);
            param[20] = new OracleParameter("pACADEMIC", (object)employeeMaster.ACADEMIC ?? DBNull.Value);
            param[21] = new OracleParameter("pDATERESIGNED", (object)employeeMaster.DATERESIGNED ?? DBNull.Value);
            param[22] = new OracleParameter("pFINGERPRINT", (object)employeeMaster.FINGERPRINT ?? DBNull.Value);
            param[23] = new OracleParameter("pFINGERINDEX", (object)employeeMaster.FINGERINDEX ?? DBNull.Value);
            param[24] = new OracleParameter("pIMAGE", (object)employeeMaster.IMAGE ?? DBNull.Value);
            param[25] = new OracleParameter("pPOSITION", (object)employeeMaster.POSITION ?? DBNull.Value);
            param[26] = new OracleParameter("pSKILL", (object)employeeMaster.SKILL ?? DBNull.Value);
            param[27] = new OracleParameter("pSYS_EMPIDOLD", (object)employeeMaster.SYS_EMPIDOLD ?? DBNull.Value);
            //param[28] = new OracleParameter("pCREATE_UID", (object)employeeMaster.CREATE_UID ?? DBNull.Value);
            param[28] = new OracleParameter("pUPDATE_UID", (object)employeeMaster.CREATE_UID ?? DBNull.Value);
            //param[30] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_UPDATE_EMPLOYEE", param);
        }
        public DataTable GetSysEmpID()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_CREATESYS_EMPID", param);
        }
        public DataTable GetEmpID(string deptCode, DateTime joinDate)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pDEPTCODE", (object)deptCode ?? DBNull.Value);
            param[1] = new OracleParameter("pDATEJOIN", (object)joinDate ?? DBNull.Value);
            param[2] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_CREATE_EMPID", param);
        }
        public DataTable GetEmployeeByEmpID(string empID)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pEmpID", empID);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_SEARCH_EMPLOYEE", param);
        }
        public DataTable GetEmployeeByLikeEmpID(string empID)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pEmpID", empID);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_SEARCHLIKEEMPID_EMPLOYEE", param);
        }
        public DataTable GetEmployeeByLikeName(string name)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pEmpName", name);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_SEARCHLIKENAME_EMPLOYEE", param);
        }
        public DataTable GetEmployeeBySysEmpID(string sysEmpid)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pSYS_EMPID", sysEmpid);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_GEBYSYS_EMPID_EMPLOYEE", param);
        }
        #endregion

        public static DataTable getEmpBasic()
        {
            DataTable result = new DataTable();
            OracleParameter[] _param = new OracleParameter[1];
            _param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            result = DBHelper.getDataTable_SP("HR_EMPLOYEE.SP_GET_EMP_BASIC_INFO", _param);
            return result;
        }
    }
}