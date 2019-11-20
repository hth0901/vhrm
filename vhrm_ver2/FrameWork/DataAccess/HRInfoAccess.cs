
using System;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class HRInfoAccess
    {
        public DataTable HRInfo_Query(string pWorkingTag, string pEmpId, string pDeptCd, string pWorkingStatus, string planguage)
        {
            string spName = "PKHR_HRINFO.sp_HRInfo_Qry";
            //string spName = "HR.sp_HRInfo_Qry";
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEmpId", pEmpId);
            param[2] = new OracleParameter("pDeptCd", pDeptCd);
            param[3] = new OracleParameter("pWorkingStatus", pWorkingStatus);
            param[4] = new OracleParameter("planguage", planguage);
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);        
            return dt;
        }
        public DataSet HRInfo_QueryAll(string pEmpId, string pDeptCd, string pWorkingStatus, string planguage, string date)
        {
            string spName = "PKHR_HRINFO.sp_HRInfo_QryAll";
            //string spName = "HR.sp_HRInfo_Qry";
            OracleParameter[] param = new OracleParameter[11];
            param[0] = new OracleParameter("pEmpId", pEmpId);
            param[1] = new OracleParameter("pDeptCd", pDeptCd);
            param[2] = new OracleParameter("pWorkingStatus", pWorkingStatus);
            param[3] = new OracleParameter("planguage", planguage);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[5] = new OracleParameter("FamilyT_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[6] = new OracleParameter("DisciplineT_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[7] = new OracleParameter("RewardQueryT_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[8] = new OracleParameter("CertificateT_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[9] = new OracleParameter("TaskT_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[10] = new OracleParameter("SKILL_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataSet dt = DBHelper.getDataSet_SP(spName, param);
            return dt;
        }
        public DataTable HRInfo_Save(string pWorkingTag, HRInfoEntity _entity, string LoginID)
        {
            string spName = "PKHR_HRINFO.sp_HRInfo_Save";
            OracleParameter[] param = new OracleParameter[6];
            //param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            //param[1] = new OracleParameter("pEmpId", _entity.EmpId);
            //param[2] = new OracleParameter("pEmpNm", _entity.EmpNm);
            //param[3] = new OracleParameter("pDeptCd", _entity.DeptCd);
            //param[4] = new OracleParameter("pLoginID", LoginID);
            //param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable CheckIDCard_Query(string pEmpId, string idCard)
        {
            string spName = "PKHR_HRINFO.sp_Check_RFID_T_HR_EMP_MASTER";
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pEmpId", pEmpId);
            param[1] = new OracleParameter("pidCard", idCard);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
       public DataTable LoadTreeView(string pLoginID)
        {
            string query = "PK_HR_ORGANIZATION.sp_OrgRegistry_TreeView";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pLoginId", pLoginID);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        /**********************************************************************************/

        #region Personal Info Tab

        public DataTable BasicInfo_Save(string pWorkingTag, PersonalInfoEntity _entity, string LoginID)
        {
            string spName = "PKHR_HRINFO.sp_HRInfo_Save";
            OracleParameter[] param = new OracleParameter[55];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEMPNAME", OracleType.NVarChar) { Value = _entity.EMPNAME ?? "" }; //
            param[2] = new OracleParameter("pEMPNAMEEN", _entity.EMPNE??"");
            param[3] = new OracleParameter("pBIRTHDAY", _entity.BIRTHDAY ?? "");
            param[4] = new OracleParameter("pBIRTHPLACE", _entity.BIRTHPLACE ?? "");
            
            param[5] = new OracleParameter("pEMAIL", _entity.EMAIL ?? "");
            param[6] = new OracleParameter("pMOBILE", _entity.MOBILE ?? "");
            param[7] = new OracleParameter("pHOMETEL", _entity.HOMETEL ?? "");
            param[8] = new OracleParameter("pFOREIGNCHECK", _entity.FOREIGNCHECK ?? "");
            param[9] = new OracleParameter("pACADEMIC", _entity.ACADEMIC ?? "");
            param[10] = new OracleParameter("pNATIONALITY", _entity.NATIONALITY ?? "");
            param[11] = new OracleParameter("pRELIGION", _entity.RELIGION ?? "");
            param[12] = new OracleParameter("pETHNIC", _entity.ETHNIC ?? "");
            param[13] = new OracleParameter("pIDENTITYCARD", _entity.IDENTITYCARD ?? "");
            param[14] = new OracleParameter("pIDISSUEDDATE", _entity.IDISSUEDDATE ?? "");
            param[15] = new OracleParameter("pRESIDENCEPROVINCE", _entity.RESIDENCEPROVINCE ?? "");
            param[16] = new OracleParameter("pRESIDENCE", OracleType.NVarChar) { Value = _entity.RESIDENCE ?? "" };//
           //check
            param[17] = new OracleParameter("pPERMADDPROVINCE", _entity.PERMADDPROVINCE ?? "");
            param[18] = new OracleParameter("pPITNO", _entity.PITNO ?? "");
            param[19] = new OracleParameter("pPITPLACE", _entity.PITPLACE ?? "");
            param[20] = new OracleParameter("pPITDATE", _entity.PITDATE ?? "");
            param[21] = new OracleParameter("pSINO", _entity.SINO ?? "");
            param[22] = new OracleParameter("pSIPLACE", _entity.SIPLACE ?? "");
            param[23] = new OracleParameter("pSIDATE", _entity.SIDATE ?? "");
            param[24] = new OracleParameter("pHINO", _entity.HINO ?? "");
            param[25] = new OracleParameter("pHIPLACE", _entity.HIPLACE ?? "");
            param[26] = new OracleParameter("pHIDATE", _entity.HIDATE ?? "");
            param[27] = new OracleParameter("pBankCD", _entity.BankCd ?? "");
            param[28] = new OracleParameter("pBankAccount", _entity.AccountNo ?? "");
            param[29] = new OracleParameter("pBankOwnner", _entity.BranchName ?? "");
            param[30] = new OracleParameter("pSYS_EMPID", _entity.SYS_EMPID ?? "");
            param[31] = new OracleParameter("pLoginID", LoginID);
            param[32] = new OracleParameter("pJoinDate", _entity.JoinDate ?? "");
            param[33] = new OracleParameter("pAcademicMajor", _entity.AcademicMajor ?? "");
            param[34] = new OracleParameter("pCardIssuedDate", _entity.CardIssuedDate ?? "");
            param[35] = new OracleParameter("pImgeURL", _entity.ImgeUrl ?? "");
            param[36] = new OracleParameter("pRFID", _entity.RFID ?? "");
            param[37] = new OracleParameter("pPERMADD", OracleType.NVarChar) { Value = _entity.PERMADD ?? "" };//
            param[38] = new OracleParameter("pCardIssuedPlaceCd", _entity.CardIssuedPlaceCd ?? "");
            param[39] = new OracleParameter("pRFIDSerialCheck", _entity.RFIDSerialCheck ?? "");
            param[40] = new OracleParameter("pREMARK", _entity.ReasonUpdate ?? "");
            param[41] = new OracleParameter("pBANKDATE", _entity.BankDate ?? "");
            param[42] = new OracleParameter("pMaritalStatus", _entity.MARITALSTATUS ?? "0");
            param[43] = new OracleParameter("pMarriedDate", _entity.MARRIEDDATE ?? "");
            param[44] = new OracleParameter("pAcademickind", _entity.Academickind ?? "");
            param[45] = new OracleParameter("pEMIDOLD", _entity.EMPIDOLD ?? "");
            param[46] = new OracleParameter("pSEX", _entity.SEX ?? "");
            param[47] = new OracleParameter("pPayType", _entity.PayType);
            param[48] = new OracleParameter("pLABORFUND", _entity.LaborFund);

            param[49] = new OracleParameter("pDATEPK", _entity.DATEPK);
            param[50] = new OracleParameter("pBUS", _entity.BUS ?? "");
            param[51] = new OracleParameter("PADD_PROVINCE", _entity.ADD_PROVINCE ?? "");
            param[52] = new OracleParameter("PADD_DISTRICT", _entity.ADD_DISTRICT ?? "");
            param[53] = new OracleParameter("PADD_WARD", _entity.ADD_WARD ?? "");
            param[54] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }

        #endregion

       
        /**********************************************************************************/

        #region Family Info TAB
        /*public DataTable Category_Query(string pWorkingTag, string pCategoryList, string pLoginId)
        {

            string spName = "PKOPM_CATEGORY.sp_Category_Qry";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pListCategory", pCategoryList);
            param[2] = new OracleParameter("pLoginID", pLoginId);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }*/
        public DataTable FamilyInfo_Query(string pWorkingTag, string pEmpId, string pLoginId, string planguage)
        {
            string spName = "PKHR_HRINFO.sp_FamilyInfo_Qry";
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEmpId", pEmpId);
            param[2] = new OracleParameter("pLoginID", pLoginId);
            param[3] = new OracleParameter("planguage", planguage);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable FamilyInfo_Save(string pWorkingTag, FamilyInfoEntity _entity, string pLoginId)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_HRINFO.sp_FamilyInfo_Save";
            OracleParameter[] param = new OracleParameter[23];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEmpId", _entity.EMPID);
            param[2] = new OracleParameter("pSerialNo", _entity.FSERIAL);
            param[3] = new OracleParameter("pRelation", _entity.RELATIONSHIP ?? "");
            param[4] = new OracleParameter("pName", OracleType.NVarChar) { Value = _entity.FULLNAME ?? "" };
            param[5] = new OracleParameter("pStatus", _entity.STATUS ?? "");
            param[6] = new OracleParameter("pBirthdate", _entity.BIRTHDATE ?? "");
            param[7] = new OracleParameter("pSubtract", _entity.PITSUBTRACT ?? "");
            param[8] = new OracleParameter("pIdentitycard", _entity.IDENTITYCARD ?? "");
            param[9] = new OracleParameter("pWorkfor", OracleType.NVarChar) { Value = _entity.WORKFOR ?? "" };
            param[10] = new OracleParameter("pDepartment", OracleType.NVarChar) { Value = _entity.DEPARTMENT ?? "" };
            param[11] = new OracleParameter("pPosition", OracleType.NVarChar) { Value = _entity.POSITION ?? "" };
            param[12] = new OracleParameter("pMobile", _entity.MOBILE ?? "");
            param[13] = new OracleParameter("pProvince", _entity.PROVINCE ?? "");
            param[14] = new OracleParameter("pCity", "");
            param[15] = new OracleParameter("pAddress", OracleType.NVarChar) { Value = _entity.ADDRESS ?? "" };
            param[16] = new OracleParameter("pValiditydate", _entity.VALIDITYFROM ?? "");
            param[17] = new OracleParameter("pVALIDITYTO", _entity.pVALIDITYTO ?? "");
            param[18] = new OracleParameter("pLoginID", pLoginId ?? "");
            param[19] = new OracleParameter("PIS_CHILDCARE", _entity.IS_CHILDCARE ?? "");
            param[20] = new OracleParameter("PCHILDCARE_START", _entity.CHILDCARE_START ?? "");
            param[21] = new OracleParameter("PCHILDCARE_END", _entity.CHILDCARE_END ?? "");
            param[22] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP(spName, param);


            return dtData;
        }
        #endregion

        /**********************************************************************************/

        #region Discipline TAB

        public DataTable Discipline_Query(string pWorkingTag, string pEmpId, string pLoginId, string planguage)
        {
            string spName = "PKHR_HRINFO.sp_Discipline_Qry";
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEmpId", pEmpId);
            param[2] = new OracleParameter("pLoginID", pLoginId);
            param[3] = new OracleParameter("planguage", planguage);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }

        public DataTable Discipline_Save(string pWorkingTag, DisciplineEntity _entity, string pLoginId)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_HRINFO.sp_Discipline_Save";
            OracleParameter[] param = new OracleParameter[12];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEmpId", _entity.EMPID);
            param[2] = new OracleParameter("pSerialNo", _entity.DSERIAL);
            param[3] = new OracleParameter("pDisciplineKind", _entity.DISCIPLINEKIND ?? "");
            param[4] = new OracleParameter("pDISCIPLINECLSS", _entity.DISCIPLINECLSS?? "");
            param[5] = new OracleParameter("pReasonKind", _entity.REASONKIND ?? "");
            param[6] = new OracleParameter("pFromDate", _entity.FROMDATE ?? "");
            param[7] = new OracleParameter("pToDate", _entity.UNTILDATE ?? "");
            param[8] = new OracleParameter("pMonthCount", _entity.MONTHSCOUNT);
            param[9] = new OracleParameter("pRemark", OracleType.NVarChar ) { Value = _entity.REMARKS ?? ""};
            param[10] = new OracleParameter("pLoginID", pLoginId ?? "");
            param[11] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP(spName, param);


            return dtData;
        }
        #endregion        
        #region Job Desc.
        public DataTable JobDescQuery(string pEmpId)
        {
            string spName = "PKHR_HRINFO.sp_HRJobDescrition_Query";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pEmpId", pEmpId);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable JodDesSave(string pWorkingTag, JobDescEntity _entity, string pLoginId)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_HRINFO.sp_HRJobDescrition_Save";
            OracleParameter[] param = new OracleParameter[14];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("p_TIMEYEAR", _entity.PTimeyear);
            param[2] = new OracleParameter("p_REGISTERID", pLoginId);
            param[3] = new OracleParameter("p_TIMEWEEK", _entity.PTimeweek);
            param[4] = new OracleParameter("p_DESCRIPTION", OracleType.NVarChar) { Value = _entity.PDescription };
            param[5] = new OracleParameter("p_DOCUMENT", _entity.PDocument);
            param[6] = new OracleParameter("p_TIMEMONTH", _entity.PTimemonth);
            param[7] = new OracleParameter("p_AVERAGE", _entity.PAverage);
            param[8] = new OracleParameter("p_EMPID", _entity.PEMPID);
            param[9] = new OracleParameter("p_TIMEDAY", _entity.PTimeday);
            param[10] = new OracleParameter("p_APPROVAL", _entity.PApproval);
            param[11] = new OracleParameter("p_JDID", _entity.PJdid);
            param[12] = new OracleParameter("p_JOBTITLE", _entity.PJobtitle);
            param[13] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }
        public DataTable JodDesDelete(int datakey)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_HRINFO.sp_HRJobDescrition_Delete";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("p_JDID", datakey);
           param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }
        #endregion
        #region Reward
        public DataTable RewardQuery(string pEmpId)
        {
            string spName = "PKHR_Reward.sp_Reward_Qry";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pEmpId", pEmpId);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable Reward_Save(string pWorkingTag, RewardEntity entity, string pLoginId)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_Reward.sp_Reward_Save";
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEmpId", entity.pEmpID);
            param[2] = new OracleParameter("pREWARDDATE", entity.RewarDate);
            param[3] = new OracleParameter("pREWARDKIND", entity.Rewardkind ?? "");
            param[4] = new OracleParameter("pAMOUNT", value: entity.Amount);
            param[5] = new OracleParameter("pREMARK", entity.Remark?? "");
            param[6] = new OracleParameter("IsConfirm", entity.isConfirm?? "");
            param[7] = new OracleParameter("plogin", pLoginId);
            param[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }
        #endregion
        #region Certificate
        public DataTable CertificateQuery(string pEmpId)
        {
            string spName = "PKHR_HRCertificate.sp_Certificate_Qry";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pEmpId", pEmpId);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable LoadComBoboxLevel()
        {
            string spName = "PKHR_HRCertificate.sp_OPM_CATEGORY_Query";
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable CerticateSave(string pWorkingTag, CertificateEntity entity, string pLoginId)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_HRCertificate.sp_Certificate_Save";
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEmpId", entity.PSysempid);
            param[2] = new OracleParameter("pCER_KIND", entity.PCerKind);
            param[3] = new OracleParameter("pCER_ITEM", entity.PCerItem);
            param[4] = new OracleParameter("pCER_LEVEL", value: entity.PCerLevel ?? "");
            param[5] = new OracleParameter("pCER_DATE", entity.PCerDate ?? "");
            param[6] = new OracleParameter("pREMARK", entity.PRemark ?? "");
            param[7] = new OracleParameter("pLogin", pLoginId);
            param[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }
        #endregion
        public DataTable GetAll_Corporation(string pLoginId)
        {

            string spName = "PKHR_HRINFO.sp_GetAll_Corporation";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pLoginID", pLoginId);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        #region T_HR_EMP_PHOTO
        public static DataTable EmpPhotoSave(string emIDSys, byte[] imagebit)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_HRINFO.sp_T_HR_EMP_PHOTO_Save";
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pSYS_EMPID", emIDSys);
            param[1] = new OracleParameter("pPHOTO", OracleType.Blob) { Value = imagebit };
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }
        public  DataTable EmpUploadPhotoUrlSave(string emIDSys,string imageUrl,byte[] bytesImage  )
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_HRINFO.sp_T_HR_EMP_Master_SavePhoto";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pSYS_EMPID", emIDSys);
            param[1] = new OracleParameter("pUrl", imageUrl);
            param[2] = new OracleParameter("pPHOTO", OracleType.Blob) { Value = bytesImage };  
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }
        #endregion
        #region task
        public DataTable LoadTaskGrid(string pEmpId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pEmpId", pEmpId ?? "");
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_HRINFO.SP_LOAD_Task", parameters);
        }
        public DataTable TaskInsertData(string pWorkingTag, TaskEntity entity)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_HRINFO.sp_Save_Task";
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEmpId", entity.SysEmpid ?? "");
            param[2] = new OracleParameter("pSTRDATE", entity.Strdate ?? "");
            param[3] = new OracleParameter("pENDDATE", entity.Enddate ?? "");
            param[4] = new OracleParameter("pTASKID",  entity.Taskid ?? "");
            param[5] = new OracleParameter("pPARENTTASKID", entity.PARENTTASKID ?? "");
            param[6] = new OracleParameter("pSEQNO", entity.Seqno ?? "");
            param[7] = new OracleParameter("pLogin", entity.LoginID ?? "");
            param[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }
        #endregion
        #region Request
        public DataTable UpadteRequest(string pEmpId, string pRemark, string pLoginId, string pTyper, string pUserOpenConfirm, string pRequestBy)
        {
            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("pEmpId", pEmpId ?? "");
            parameters[1] = new OracleParameter("pRemark", pRemark ?? "");
            parameters[2] = new OracleParameter("pLoginID", pLoginId ?? "");
            parameters[3] = new OracleParameter("pTyper", pTyper ?? "");
            parameters[4] = new OracleParameter("pRequestBy", pRequestBy ?? "");
            parameters[5] = new OracleParameter("PUserOpenConfirm", pUserOpenConfirm ?? "");
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_HRINFO.sp_Request", parameters);
        }
        #endregion

        #region Modify By Tho 2014/01/10
        
        // Upload RFID Serial
        public DataTable UploadRFIDSerial(string sys_empid, string rfid)
        {
            string sp_name = "PKHR_HRINFO.SP_UPLOAD_RFID";
            OracleParameter[] _param = new OracleParameter[3];
            _param[0] = new OracleParameter("PSYS_EMPID", sys_empid);
            _param[1] = new OracleParameter("PRFID", rfid);
            _param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp_name, _param);
        }

        #endregion
        #region get email manager
        public string GetEmailManger_company(string pEmpId)
          {
              OracleParameter[] parameters = new OracleParameter[2];
              parameters[0] = new OracleParameter("pEmpId", pEmpId ?? "");
              parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
              DataTable dt = DBHelper.getDataTable_SP("PKHR_HRINFO.sp_HRInfo_getemailCompany", parameters);
            string email = "";
            if (dt.Rows.Count>0)
            {
                email = dt.Rows[0]["USER_EMAIL"].ToString() +"~"+ dt.Rows[0]["USER_ID"].ToString();
            }
            return email;
          }
        public DataTable InsertSenderEmail(string pEmpid, string psysEmpid, string pContentRequest, string pUserApproval, string pCreateUserid, string pStatus)
        {
            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("pEmpId", pEmpid ?? "");
            parameters[1] = new OracleParameter("psysEmpid", psysEmpid ?? "");
            parameters[2] = new OracleParameter("pContentRequest", pContentRequest ?? "");
            parameters[3] = new OracleParameter("PUSERAPPROVAL", pUserApproval ?? "");
            parameters[4] = new OracleParameter("pCreateUserid", pCreateUserid ?? "");
            parameters[5] = new OracleParameter("pStatus", pStatus ?? "");
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP("PKHR_HRINFO.sp_HRInfo_InsertEmailCompany", parameters);
            return dt;
        }
        #endregion

        //Add by hung
        public DataTable HRInfo_CancelEmployee(string pempid)
        {
            string spName = "PKHR_HRINFO.SP_HRINFO_CANCEL_EMPLOYEE";
            //string spName = "HR.sp_HRInfo_Qry";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PEMPID", pempid);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }

        //Add by hung
        public bool HRInfo_Check_LaborContract(string pempid)
        {
            string spName = "PKHR_HRINFO.Sp_Hrinfo_Check_Laborcontract";
            //string spName = "HR.sp_HRInfo_Qry";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PEMPID", pempid);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP(spName, param);
            return table.Rows[0][0].ToString() == "YES" ? true : false;
        }

        #region skill nhthien 25/01/2016
        public DataTable LoadSkillGrid(string pEmpId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pEmpId", pEmpId ?? "");
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_HRINFO.SP_LOAD_SKILL", parameters);
        }

        public DataTable KillSave(string pWorkingTag, SkillEntity _entity)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_HRINFO.SP_KILL_SAVE";
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pId", _entity.Id);
            param[2] = new OracleParameter("pEmpId", _entity.EmpId);
            param[3] = new OracleParameter("pValidityFrom", _entity.ValidityFrom ?? "");
            param[4] = new OracleParameter("pValidityTo", _entity.ValidityTo ?? "");
            param[5] = new OracleParameter("pKillLevel", _entity.SkillLevel ?? "");
            param[6] = new OracleParameter("pRemark", _entity.Remark ?? "");
            param[7] = new OracleParameter("pLoginID", _entity.UserId ?? "");
            param[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }
        #endregion

    }
}