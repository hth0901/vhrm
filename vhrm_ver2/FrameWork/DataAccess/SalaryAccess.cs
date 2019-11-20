
using System;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class SalaryAccess
    {
        /// <summary>
        /// Query All Registry version
        /// </summary>
        /// <param name="pWorkingTag"></param>
        /// <returns></returns>
        public DataTable Query_RegVersion(string pWorkingTag)
        {
            string spName = "PKHR_HRINFO.sp_RegVersion_Qry";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            
            return dt;
        }

        /// <summary>
        /// Save Registry Version
        /// </summary>
        /// <param name="pWorkingTag"></param>
        /// <param name="pVER_ID"> VERCODE(char(3)) + AUTO_ID(char(2))</param>
        /// <param name="pVER_CODE">Get from Category = 127</param>
        /// <param name="pCORPORATION"></param>
        /// <param name="pREMARK"></param>
        /// <param name="pISSUSE">If checked: Cannot Edit or Delete</param>
        /// <param name="pLoginID"></param>
        /// <returns></returns>
        public DataTable Save_RegVersion(string pWorkingTag, string pVER_ID, string pVER_Name,string pKind, string pGroupSalary,
                                 string pFromMonth, string pToMonth, string pREMARK, string pLoginID)
        {
            string spName = "PKHR_HRINFO.sp_RegVersion_Save";
            OracleParameter[] para = new OracleParameter[10];
            para[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            para[1] = new OracleParameter("pVER_ID", pVER_ID);
            para[2] = new OracleParameter("pVer_Name", pVER_Name);
            para[3] = new OracleParameter("pKind", pKind);
            para[4] = new OracleParameter("pGroupSalary", pGroupSalary);
            para[5] = new OracleParameter("pFromMonth", pFromMonth ?? "");
            para[6] = new OracleParameter("pToMonth", pToMonth ?? "");
            para[7] = new OracleParameter("pREMARK", OracleType.NVarChar) { Value = pREMARK };
            para[8] = new OracleParameter("pLoginID", pLoginID);
            para[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        public DataTable Check_Validator(string versionKindCode , string fromMonth, string toMonth , string groupSalary)
        {
            string spName = "PKHR_HRINFO.sp_RegVersion_Validator";
            OracleParameter[] para = new OracleParameter[5];
            para[0] = new OracleParameter("pVersionKind", versionKindCode);
            para[1] = new OracleParameter("pFromMonth", fromMonth);
            para[2] = new OracleParameter("pToMonth", toMonth);
            para[3] = new OracleParameter("pGroupSalary", groupSalary);
            para[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }


        public static DataTable UpdateMaster(SalaryMasterEntity ent)
        {
            string spName = "PKPAYROLL_SALARYREPORT.SP_UPDATE_SALARY_MT";
            OracleParameter[] para = new OracleParameter[19];
            para[0] = new OracleParameter("pALLOWOTHER", value: ent.ALLOWOTHER);
            para[1] = new OracleParameter("pNORETURNHEALTHCARD", value: ent.NORETURNHEALTHCARD);
            para[2] = new OracleParameter("pDEDUCTOTHER", value: ent.DEDUCTOTHER);
            para[3] = new OracleParameter("pBASICSALARYEXTRA", value: ent.BASICSALARYEXTRA);
            para[4] = new OracleParameter("pSOCIAL_INSUARANCE", value: ent.SOCIAL_INSUARANCE);
            para[5] = new OracleParameter("pOTSALARYSUPPLEMENT", value: ent.OTSALARYSUPPLEMENT);
            para[6] = new OracleParameter("pALLOWANCESUPPLEMENT", value: ent.ALLOWANCESUPPLEMENT);
            para[7] = new OracleParameter("pINTRODUCENEWWORKER", value: ent.INTRODUCENEWWORKER);
            para[8] = new OracleParameter("pOUTSIDE", value: ent.OUTSIDE);
            para[9] = new OracleParameter("pANUALLEAVEALLOWANCE",value: ent.ANUALLEAVEALLOWANCE);
            para[10] = new OracleParameter("pUPDATE_UID", ent.UPDATE_UID??"");
            para[11] = new OracleParameter("PSYSEMPIS", ent.SYS_EMPID??"");
            para[12] = new OracleParameter("PPBYM", ent.PBMM??"");
            para[13] = new OracleParameter("PBASICSALARY", value: ent.CONTRACTSALARY);

            para[14] = new OracleParameter("PINSOCIALLB", value: ent.INSOCIALLB);
            para[15] = new OracleParameter("PINHEALTHLB", value: ent.INHEALTHLB);
            para[16] = new OracleParameter("PINUNEMPLOYMENTLB", value: ent.INUNEMPLOYMENTLB);
            para[17] = new OracleParameter("PLABORFUNDLB", value: ent.LABORFUNDLB);

            para[18] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }

    }
}