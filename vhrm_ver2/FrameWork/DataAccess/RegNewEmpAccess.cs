using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class RegNewEmpAccess
    {

        public static DataTable GetEmpRegByDept(string pDept, string pIDNo, string pEmpId, string pEmpNm, string pJoinDate,
            string pBirthday)
        {
            OracleParameter[] _sqlParam = new OracleParameter[7];
            _sqlParam[0] = new OracleParameter("pDept", pDept);
            _sqlParam[1] = new OracleParameter("pIDNo", pIDNo);
            _sqlParam[2] = new OracleParameter("pEmpId", pEmpId);
            _sqlParam[3] = new OracleParameter("pEmpNm", OracleType.NVarChar) { Value = pEmpNm };
            _sqlParam[4] = new OracleParameter("pJoinDate", pJoinDate);
            _sqlParam[5] = new OracleParameter("pBirthday", pBirthday);
            _sqlParam[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKHR_EMPLOYEEREG.sp_HR_GetEmpRegByDept", _sqlParam);
            return table;
        }

        public static DataTable SaveEmpReg(string pWorkingTag,RegNewEmpEntity _Entity, string LoginId)
        {
            OracleParameter[] _sqlParam = new OracleParameter[19];
            _sqlParam[0] = new OracleParameter("WorkingTag", pWorkingTag);
            _sqlParam[1] = new OracleParameter("pREG_ID",_Entity.RegID);
            _sqlParam[2] = new OracleParameter("pIDNO", _Entity.IDNO);
            _sqlParam[3] = new OracleParameter("pEMPID", _Entity.EMPID);
            _sqlParam[4] = new OracleParameter("pENTDATE", _Entity.ENTDATE);
            _sqlParam[5] = new OracleParameter("pEMPNAME", OracleType.NVarChar) { Value = _Entity.EMPNAME };
            _sqlParam[6] = new OracleParameter("pSEX", _Entity.SEX);
            _sqlParam[7] = new OracleParameter("pBIRTHDAY", _Entity.BIRTHDAY);
            _sqlParam[8] = new OracleParameter("pDEPTCODE", _Entity.DEPTCODE);
            _sqlParam[9] = new OracleParameter("pIDSSUEDPLACE",_Entity.ISSUEDPLACE);
            _sqlParam[10] = new OracleParameter("pIDSSUEDDATE",_Entity.Issueddate);
           // _sqlParam[8] = new OracleParameter("pEMPIDCLSS", _Entity.EMPIDCLSS);
            _sqlParam[11] = new OracleParameter("pSTRUCT", _Entity.STRUCT);
            _sqlParam[12] = new OracleParameter("pLoginId", OracleType.NVarChar) { Value = LoginId };
            _sqlParam[13] = new OracleParameter("pJOBCODE", OracleType.NVarChar) { Value = _Entity.JOBCODE };
            _sqlParam[14] = new OracleParameter("pJOBFIELD", OracleType.NVarChar) { Value = _Entity.JOBFIELD };
            _sqlParam[15] = new OracleParameter("pDUTY", OracleType.NVarChar) { Value = _Entity.DUTY };
            _sqlParam[16] = new OracleParameter("pNORMALHOUR", OracleType.NVarChar) { Value = _Entity.NORMALHOUR };
            _sqlParam[17] = new OracleParameter("pRFID", OracleType.NVarChar) { Value = _Entity.RFD };
            _sqlParam[18] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKHR_EMPLOYEEREG.sp_HR_SaveEmpReg", _sqlParam);
            return table;
        }

        public static DataTable CreateEmpId(string pRegID,string pIDNo, string pStruct,string deptcode, string pLoginId)
        {
            /*pStruct varchar2, pIDNO varchar2, pLoginId nvarchar2, T_TABLE OUT T_CURSOR*/
            OracleParameter[] _sqlParam = new OracleParameter[6];
            _sqlParam[0] = new OracleParameter("pREGid",pRegID);
            _sqlParam[1] = new OracleParameter("pStruct", pStruct);
            _sqlParam[2] = new OracleParameter("pIDNO", pIDNo);
            _sqlParam[3] = new OracleParameter("pDEPTCODE", deptcode);
            _sqlParam[4] = new OracleParameter("pLoginId", pLoginId);
            _sqlParam[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKHR_EMPLOYEEREG.sp_HR_CreateEmpId", _sqlParam);
            return table;
        }

        public static DataTable IDNoDuplicateCheck(string pIDNo,string corporation)
        {
            OracleParameter[] _sqlParam = new OracleParameter[3];
            _sqlParam[0] = new OracleParameter("pIDNO", pIDNo);
            _sqlParam[1] = new OracleParameter("pDEPTCODE", corporation);
            _sqlParam[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKHR_EMPLOYEEREG.sp_HR_IDNoDuplicateCheck", _sqlParam);
            return table;
        }

    }
}