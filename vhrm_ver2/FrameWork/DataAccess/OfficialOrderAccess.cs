using System;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class OfficialOrderAccess
    {

        #region Official Order Access
        public DataTable loadOfficialOrder(string pEmpId, string planguage, string pConfirm, string pUnConfirm)
        {
            OracleParameter[] parameters = new OracleParameter[5];
            //parameters[0] = new OracleParameter("pDeptCode", pDeptCode ?? "");
            parameters[0] = new OracleParameter("pEmpId", pEmpId ?? "");
            parameters[1] = new OracleParameter("planguage", planguage ?? "");
            parameters[2] = new OracleParameter("pConfirm", pConfirm ?? "");
            parameters[3] = new OracleParameter("pUnConfirm", pUnConfirm ?? "");
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_OFFICIAL_ORDER.SP_LOAD_OFFICIAL_ORDER", parameters);
        }
        public DataTable GetLastOfficialOrder(string pEmpId, string planguage)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            //parameters[0] = new OracleParameter("pDeptCode", pDeptCode ?? "");
            parameters[0] = new OracleParameter("pEmpId", pEmpId ?? "");
            parameters[1] = new OracleParameter("planguage", planguage ?? "");
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_OFFICIAL_ORDER.sp_GetLastData", parameters);
        }
        public DataTable Save_OfficialOrder(string WorkingTag, Official_Order_Entity _entity, string pLoginId)
        {
            OracleParameter[] parameter = new OracleParameter[22];
            parameter[0] = new OracleParameter("pWorkingTag", WorkingTag ?? "");
            parameter[1] = new OracleParameter("pSYS_EMPID", _entity.EmpId ?? "");
            parameter[2] = new OracleParameter("pOFFICIAL_DATE", _entity.OFFICIAL_DATE ?? "");
            parameter[3] = new OracleParameter("pOFFICIAL_CD", _entity.OFFICIAL_CD ?? "");
            parameter[4] = new OracleParameter("pOFFICIAL_NM", _entity.OFFICIAL_NM ?? "");
            parameter[5] = new OracleParameter("pOFFICIAL_FROM", _entity.OFFICIAL_FROM ?? "");
            parameter[6] = new OracleParameter("pOFFICIAL_TO", _entity.OFFICIAL_TO ?? "");
            parameter[7] = new OracleParameter("pROAbsence", _entity.ROAbsence ?? "");
            parameter[8] = new OracleParameter("pDEPT_CODE", _entity.DEPT_CODE ?? "");
            parameter[9] = new OracleParameter("pDISPATCH_CODE", _entity.DISPATCH_CODE ?? "");
            parameter[10] = new OracleParameter("pDUTY", _entity.DUTY ?? "");
            parameter[11] = new OracleParameter("pRole", _entity.Role ?? "");
            parameter[12] = new OracleParameter("pJOB_FIELD", _entity.JOB_FIELD ?? "");
            // parameter[14] = new OracleParameter("pJOB_DESC", _entity.JOB_DESC ?? "");
            parameter[13] = new OracleParameter("pCONFIRM_IS", _entity.CONFIRM_IS ?? "");
            parameter[14] = new OracleParameter("pTASK", OracleType.NVarChar) { Value = _entity.TASK ?? "" };
            parameter[15] = new OracleParameter("pLoginId", pLoginId ?? "");
            parameter[16] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameter[17] = new OracleParameter("pNORMALHOUR", _entity.WorkHours ?? "");
            parameter[18] = new OracleParameter("pIndex", OracleType.Int32) { Value = _entity.ID };
            parameter[19] = new OracleParameter("PREMARK", OracleType.NVarChar) { Value = _entity.Remark };
            parameter[20] = new OracleParameter("POFFICIAL_REASON", _entity.OFFICIAL_REASON ?? "");
            parameter[21] = new OracleParameter("PDECIDE_NO", _entity.DECIDE_NO ?? "");
            return DBHelper.getDataTable_SP("PKHR_OFFICIAL_ORDER.SP_SAVE_OFFICIAL_ORDER", parameter);
        }

        public static DataTable ReCreateEmpId(string pStruct, string psysEmpId, string pOfficialDT, string pOfficialCd, string pEmpIdClass, string pLoginId)
        {
            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("pStruct", pStruct ?? "");
            parameters[1] = new OracleParameter("psysEmpId", psysEmpId ?? "");
            parameters[2] = new OracleParameter("pOfficialDT", pOfficialDT ?? "");
            parameters[3] = new OracleParameter("pOfficialCd", pOfficialCd ?? "");
            parameters[4] = new OracleParameter("pEmpIdClass", pEmpIdClass ?? "");
            parameters[5] = new OracleParameter("pLoginId", pLoginId ?? "");
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_OFFICIAL_ORDER.sp_HR_CreateEmpId", parameters);
        }

        public DataTable UpdateModifyContract(string id, string contractfrom, string contractto, string ismodify, string pLoginId)
        {
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("PID", id ?? "");
            parameters[1] = new OracleParameter("PCONTRACTFROM", contractfrom ?? "");
            parameters[2] = new OracleParameter("PCONTRACTTO", contractto ?? "");
            parameters[3] = new OracleParameter("PISMODIFY", ismodify ?? "");
            parameters[4] = new OracleParameter("PLOGINID", pLoginId ?? "");
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_OFFICIAL_ORDER.SP_MODIFY_CONTRACT", parameters);
        }

        #endregion

        public DataTable GetOfficialReason(string pSYS_EMPID)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("PSYS_EMPID", pSYS_EMPID ?? "");
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_OFFICIAL_ORDER.SP_GET_OFFICAL_REASON", parameters);
        }


        #region Create EMPID
        public DataTable CreateEmpId(string pStruct, string sysEmpid)
        {
            OracleParameter[] parameter = new OracleParameter[3];
            parameter[0] = new OracleParameter("pStruct", pStruct ?? "");
            parameter[1] = new OracleParameter("pEmpsysID", sysEmpid ?? "");
            parameter[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_EMPLOYEEREG.sp_HR_CreateEmpID_OFFICIAL", parameter);
        }
        #endregion
    }
}