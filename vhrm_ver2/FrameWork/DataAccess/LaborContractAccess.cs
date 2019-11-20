using System;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class LaborContractAccess
    {
        #region Labor Contract
        
        //pValidityFrom char,pExtendT
        public DataTable LaborContract_ByDept_Query(string pWorkingTag, string pDeptCode, string pSysempid, string pSignedDate, string pSignDateTo, string pValidityFrom, string pExtendT, string pLoginId, string langId, string pContractKind, string pAppendix, string pRightConfrim, string pRightUNConfrim)
        {
            //(pWorkingTag char,pDeptCode nvarchar2,pSignedDate char,pValidityFrom char,pExtendTo char, pLoginID nvarchar2,T_TABLE OUT C_CURSOR)
            string spName = "PKHR_LABORCONTRACT.sp_LaborContract_byDept_Qry";
            OracleParameter[] param = new OracleParameter[14];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pDeptCode", pDeptCode);
            param[2] = new OracleParameter("pSysempid", pSysempid);
            param[3] = new OracleParameter("pSignedDate", pSignedDate);
            param[4] = new OracleParameter("pSignedDateto",pSignDateTo);
            param[5] = new OracleParameter("pValidityFrom", pValidityFrom);
            param[6] = new OracleParameter("pExtendTo", pExtendT);
            param[7] = new OracleParameter("pLoginID", pLoginId);
            param[8] = new OracleParameter("planguage", langId);
            param[9] = new OracleParameter("pContractKind", pContractKind);
            param[10] = new OracleParameter("pAppendix", pAppendix);
            param[11] = new OracleParameter("pRightConfrim", pRightConfrim);
            param[12] = new OracleParameter("pRightUNConfrim", pRightUNConfrim);
            param[13] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }

        public DataTable Query(string SysEmpID)
        {
            string spName = "PKHR_LABORCONTRACT.sp_LaborContract_QUERY";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PSYSEMPID", SysEmpID);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }

        public DataTable LaborContract_Save(string pWorkingTag, LaborContractEntity _entity, string pLoginId)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_LABORCONTRACT.sp_LaborContract_Save";
            OracleParameter[] param = new OracleParameter[18];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEmpId", _entity.Sys_EmpID);
            param[2] = new OracleParameter("pContractNo", _entity.ContractNo);
            param[3] = new OracleParameter("pContractKind", _entity.ContractKind);
            param[4] = new OracleParameter("pAppendix", _entity.Appendix);
            param[5] = new OracleParameter("pValidityFrom", _entity.ValidityFrom);
            param[6] = new OracleParameter("pExtendTo", _entity.ExtendTo);
            param[7] = new OracleParameter("pJobCode", _entity.JobCode);
            param[8] = new OracleParameter("pStepNo", _entity.StepNo);
            param[9] = new OracleParameter("pStepLevel", _entity.StepLevel);
            param[10] = new OracleParameter("pBasicSalary", _entity.BasicSalary);
            //param[11] = new OracleParameter("pContractSalary", _entity.ContractSalary);
            param[11] = new OracleParameter("pSignedDate", _entity.SignedDate);
            param[12] = new OracleParameter("pContractCD", _entity.ContractCD??"");
            param[13] = new OracleParameter("pJobDescription", OracleType.NVarChar) { Value = _entity.JobDescription ?? "" };
            param[14] = new OracleParameter("pLoginID", pLoginId);
            param[15] = new OracleParameter("pResponsibilityCD", _entity.ResponsibilityCD);
            param[16] = new OracleParameter("pResponsibility", _entity.Responsibility);
            param[17] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }


        public DataTable DeleteContract(string pcontractNo)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_LABORCONTRACT.SP_DELETECONTRACT";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PCONTRACTNO", pcontractNo);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }

        public DataTable LaborContract_Confirm(string pContractNo, string pIsConfirm, string pLoginID)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_LABORCONTRACT.sp_LaborContract_Confirm";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pContractNo", pContractNo);
            param[1] = new OracleParameter("pIsConfirm", pIsConfirm);
            param[2] = new OracleParameter("pLoginID", pLoginID);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;

        }

        public DataTable GetBasicSalary(string pEmpId, string pStepNo, string pStepLevel, string pMonth, string pJobCode)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_LABORCONTRACT.sp_GetBasicSalary";
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("pEmpId", pEmpId);
            param[1] = new OracleParameter("pStepNo", pStepNo);
            param[2] = new OracleParameter("pStepLevel", pStepLevel);
            param[3] = new OracleParameter("pMonth", pMonth);
            param[4] = new OracleParameter("pJobCode", pJobCode);
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;

        }

        public static DataTable LaborContract_Print(string pContractkind)
        {
            DataTable dtData = new DataTable();
            string spName = "SP_CT_PROBATIONAPPRENTICE";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pCONTRACTKIND", pContractkind);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;

        }
        public static DataTable LaborContract_Apprentice(string pContractNo,string pContractkind,string pLanguage)
        {
            DataTable dtData = new DataTable();
            string spName = "SP_CTA2_APPRENTICE";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pContractNo", pContractNo);
            param[1] = new OracleParameter("pCONTRACTKIND", pContractkind);
            param[2] = new OracleParameter("planguage",pLanguage);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;

        }
        //sp_LoadOldData
        public static DataTable LoadOldData(string psysemID)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_LABORCONTRACT.SP_LOADOLDDATA";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pSysempid", psysemID);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;

        }

        //sp_LoadOldData
        public static DataTable LoadRecruitment(string psysemID, string pEmpID, string pLanguage)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_LABORCONTRACT.SP_LOADRECRUITMENT";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pSysempid", psysemID);
            param[1] = new OracleParameter("pEmpid", pEmpID);
            param[2] = new OracleParameter("planguage", pLanguage);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;

        }

        public static DataTable getDateBeginEnd(string psysemID, string pEmpID, string pLanguage)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_LABORCONTRACT.sp_getDateBeginend";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pSysempid", psysemID);
            param[1] = new OracleParameter("pEmpid", pEmpID);
            param[2] = new OracleParameter("planguage", pLanguage);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }

        #endregion
        #region Next Labour Contract
        public DataTable NextLabourContractQuery(string pDeptCode, string pSysempid, string pMonth, string langId, string pContractKind, string pIshave)
        {
            //(pWorkingTag char,pDeptCode nvarchar2,pSignedDate char,pValidityFrom char,pExtendTo char, pLoginID nvarchar2,T_TABLE OUT C_CURSOR)
            string spName = "PKHR_LABORCONTRACT_ADV.SP_LABORCONTRACTNEXT_QRY";
            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("PDEPTCODE", pDeptCode);
            param[1] = new OracleParameter("PMONTH", pMonth);
            param[2] = new OracleParameter("PEMPID", pSysempid);
            param[3] = new OracleParameter("pContractKind", pContractKind);
            param[4] = new OracleParameter("pISHAVE", pIshave);
            param[5] = new OracleParameter("planguage", langId);
            param[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        #endregion

        #region Salary
        public DataTable GetAllSalary(string pEMPID,string pMONTH, string pJOBCODE)
        {
            string sp_Name = "PKHR_LABORCONTRACT.SP_GETALLSALARY";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pEmpId", pEMPID);
            param[1] = new OracleParameter("pMonth", pMONTH);
            param[2] = new OracleParameter("pJobCode", pJOBCODE);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP(sp_Name, param);
            return table;
        }

        #endregion



        public static DataTable AdjustContract(string data)
        {
            string spName = "PKHR_LABORCONTRACT.SP_ADJUST_CONTRACT";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PDATA", data);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
 
            return  DBHelper.getDataTable_SP(spName, param);
        }
    }
}