using System.Data.OracleClient;
using System.Data;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class RecruitmentAccess
    {
        public  DataTable SaveDataForRecruitment(string workingTag,string userLogin,HRInfoEntity entity)
        {
                DataTable dtData = new DataTable();
                OracleParameter[] param = new OracleParameter[46];
                param[0] = new OracleParameter("pWorkingTag", workingTag);
                param[1] = new OracleParameter("pSEQNO", entity.Seqno??"");
                param[2] = new OracleParameter("pISMERIT", entity.IsMerit ?? "");
                param[3] = new OracleParameter("pPERMADDPROVINCE", entity.Permaddprovince ?? "");
                param[4] = new OracleParameter("pNORMALHOUR", entity.NORMALHOUR ?? "");
                param[5] = new OracleParameter("pJOBFIELD", entity.JOBFIELD ?? "");
                param[6] = new OracleParameter("pISCAREER", entity.IsCareer ?? "");
                param[7] = new OracleParameter("pBIRTHPLACE", entity.BIRTHPLACE ?? "");
                param[8] = new OracleParameter("pNATIONALITY", entity.NATIONALITY ?? "");
                param[9] = new OracleParameter("pPERMADD", entity.PERMADD ?? "");
                param[10] = new OracleParameter("pIDISSUEDPLACE", entity.IDISSUEDPLACE ?? "");
                param[11] = new OracleParameter("pMARRYSTATUS", entity.Marry ?? "");
                param[12] = new OracleParameter("pSEX", entity.SEX ?? "");
                param[13] = new OracleParameter("pSYSEMPID", entity.Sysempid ?? "");
                param[14] = new OracleParameter("pDEPTCODE", entity.CORPORATION ?? "");
                param[15] = new OracleParameter("pDATEREC", entity.RecruitmentDate ?? "");
                param[16] = new OracleParameter("pACADEMICMAJOR", entity.AcademicMajor ?? "");
                param[17] = new OracleParameter("pEMAIL", entity.EMAIL ?? "");
                param[18] = new OracleParameter("pETHNIC", entity.ETHNIC ?? "");
                param[19] = new OracleParameter("pJOBCODE", entity.JOBCODE ?? "");
                param[20] = new OracleParameter("pHOMETEL", entity.HOMETEL ?? "");
                param[21] = new OracleParameter("pBIRTHDAY", entity.BIRTHDAY ?? "");
                param[22] = new OracleParameter("pACADEMICKIND", entity.Academickind ?? "");
                param[23] = new OracleParameter("pACADEMIC", entity.ACADEMIC ?? "");
                param[24] = new OracleParameter("pIDENTITYCARD", entity.IDENTITYCARD ?? "");
                param[25] = new OracleParameter("pIDISSUEDDATE", entity.IDISSUEDDATE ?? "");
                param[26] = new OracleParameter("pRESIDENCE", entity.RESIDENCE ?? "");
                param[27] = new OracleParameter("pDATEJOIN", entity.Joindate ?? "");
                param[28] = new OracleParameter("pMOBILE", entity.MOBILE ?? "");
                param[29] = new OracleParameter("pRESIDENCEPROVINCE", entity.RESIDENCEPROVINCE ?? "");
                param[30] = new OracleParameter("pEMPNAME", entity.EMPNAME ?? "");
                param[31] = new OracleParameter("pRELIGION", entity.RELIGION ?? "");
                param[32] = new OracleParameter("pDUTY", entity.DUTY ?? "");
                param[33] = new OracleParameter("pFOREIGNCHECK", entity.FOREIGNCHECK ?? "");
                param[34] = new OracleParameter("pLogin", userLogin ?? "");
                param[35] = new OracleParameter("pStatusConfirm", entity.ConfirmStatus?? "");
                param[36] = new OracleParameter("pLanguageOne", entity.ForeignLanguageOne ?? "");
                param[37] = new OracleParameter("pLevelOne", entity.LevelForeignLOne ?? "");
                param[38] = new OracleParameter("pLanguageTwo", entity.ForeignLanguageTwo ?? "");
                param[39] = new OracleParameter("pLevelTwo", entity.LevelForeignLTwo ?? "");

                param[40] = new OracleParameter("pLanguageThree", entity.ForeignLanguageThree ?? "");
                param[41] = new OracleParameter("pLevelThree", entity.LevelForeignLThree ?? "");


                param[42] = new OracleParameter("PADD_PROVINCE", entity.ADD_PROVINCE ?? "");
                param[43] = new OracleParameter("PADD_DISTRICT", entity.ADD_DISTRICT ?? "");
                param[44] = new OracleParameter("PADD_WARD", entity.ADD_WARD ?? "");

                param[45]= new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
                dtData = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.SP_HR_RECRUITMENT_Save", param);
            return dtData;
        }

        public bool CheckIdNoAccept(string pseqno, string pidno, string chksponsor)
        {
            string sql = "select * from t_hr_recruitment where seqno = :pseqno and identitycard = :pidno";
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("pseqno", pseqno);
            _sqlParam[1] = new OracleParameter("pidno", pidno);
            DataTable tb = DBHelper.getDataTable_Text(sql, _sqlParam);
            if (tb.Rows.Count <= 0)
            {
                DataTable dtData = HR_Recruitment_CheckExists(pidno, chksponsor);
                if (!(dtData.Rows[0][0].Equals("OK")))
                    return false;
            }
            return true;
        }

        public  DataTable GetValueContrl(string pSeqno, string pLanguage)
        {
            /*pStruct varchar2, pIDNO varchar2, pLoginId nvarchar2, T_TABLE OUT T_CURSOR*/
            OracleParameter[] _sqlParam = new OracleParameter[3];
            _sqlParam[0] = new OracleParameter("PSEQNO", pSeqno);
            _sqlParam[1] = new OracleParameter("planguage", pLanguage);
            _sqlParam[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.sp_Recruitment_Qry", _sqlParam);
            return table;
        }
        public static DataTable IDNoDuplicateCheck(string pIDNo, string corporation)
        {
            OracleParameter[] _sqlParam = new OracleParameter[3];
            _sqlParam[0] = new OracleParameter("pIDNO", pIDNo);
            _sqlParam[1] = new OracleParameter("pDEPTCODE", corporation);
            _sqlParam[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.sp_HR_IDNoDuplicateCheck", _sqlParam);
            return table;
        }

        //ADD BY HUNG
        public DataTable ADD(string userLogin, HRInfoEntity entity)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[46];
            param[0] = new OracleParameter("pSEQNO", entity.Seqno ?? "");
            param[1] = new OracleParameter("pISMERIT", entity.IsMerit ?? "");
            param[2] = new OracleParameter("pPERMADDPROVINCE", entity.Permaddprovince ?? "");
            param[3] = new OracleParameter("pNORMALHOUR", entity.NORMALHOUR ?? "");
            param[4] = new OracleParameter("pJOBFIELD", entity.JOBFIELD ?? "");
            param[5] = new OracleParameter("pISCAREER", entity.IsCareer ?? "");
            param[6] = new OracleParameter("pBIRTHPLACE", entity.BIRTHPLACE ?? "");
            param[7] = new OracleParameter("pNATIONALITY", entity.NATIONALITY ?? "");
            param[8] = new OracleParameter("pPERMADD", entity.PERMADD ?? "");
            param[9] = new OracleParameter("pIDISSUEDPLACE", entity.IDISSUEDPLACE ?? "");
            param[10] = new OracleParameter("pMARRYSTATUS", entity.Marry ?? "");
            param[11] = new OracleParameter("pSEX", entity.SEX ?? "");
            param[12] = new OracleParameter("pSYSEMPID", entity.Sysempid ?? "");
            param[13] = new OracleParameter("pDEPTCODE", entity.CORPORATION ?? "");
            param[14] = new OracleParameter("pDATEREC", entity.RecruitmentDate ?? "");
            param[15] = new OracleParameter("pACADEMICMAJOR", entity.AcademicMajor ?? "");
            param[16] = new OracleParameter("pEMAIL", entity.EMAIL ?? "");
            param[17] = new OracleParameter("pETHNIC", entity.ETHNIC ?? "");
            param[18] = new OracleParameter("pJOBCODE", entity.JOBCODE ?? "");
            param[19] = new OracleParameter("pHOMETEL", entity.HOMETEL ?? "");
            param[20] = new OracleParameter("pBIRTHDAY", entity.BIRTHDAY ?? "");
            param[21] = new OracleParameter("pACADEMICKIND", entity.Academickind ?? "");
            param[22] = new OracleParameter("pACADEMIC", entity.ACADEMIC ?? "");
            param[23] = new OracleParameter("pIDENTITYCARD", entity.IDENTITYCARD ?? "");
            param[24] = new OracleParameter("pIDISSUEDDATE", entity.IDISSUEDDATE ?? "");
            param[25] = new OracleParameter("pRESIDENCE", entity.RESIDENCE ?? "");
            param[26] = new OracleParameter("pDATEJOIN", entity.Joindate ?? "");
            param[27] = new OracleParameter("pMOBILE", entity.MOBILE ?? "");
            param[28] = new OracleParameter("pRESIDENCEPROVINCE", entity.RESIDENCEPROVINCE ?? "");
            param[29] = new OracleParameter("pEMPNAME", entity.EMPNAME ?? "");
            param[30] = new OracleParameter("pRELIGION", entity.RELIGION ?? "");
            param[31] = new OracleParameter("pDUTY", entity.DUTY ?? "");
            param[32] = new OracleParameter("pFOREIGNCHECK", entity.FOREIGNCHECK ?? "");
            param[33] = new OracleParameter("pLogin", userLogin ?? "");
            param[34] = new OracleParameter("pStatusConfirm", entity.ConfirmStatus ?? "");
            param[35] = new OracleParameter("pLanguageOne", entity.ForeignLanguageOne ?? "");
            param[36] = new OracleParameter("pLevelOne", entity.LevelForeignLOne ?? "");
            param[37] = new OracleParameter("pLanguageTwo", entity.ForeignLanguageTwo ?? "");
            param[38] = new OracleParameter("pLevelTwo", entity.LevelForeignLTwo ?? "");
            param[39] = new OracleParameter("pLanguageThree", entity.ForeignLanguageThree ?? "");
            param[40] = new OracleParameter("pLevelThree", entity.LevelForeignLThree ?? "");
            param[41] = new OracleParameter("psponsor", entity.sponsor ?? "");
            param[42] = new OracleParameter("PADD_PROVINCE", entity.ADD_PROVINCE ?? "");
            param[43] = new OracleParameter("PADD_DISTRICT", entity.ADD_DISTRICT ?? "");
            param[44] = new OracleParameter("PADD_WARD", entity.ADD_WARD ?? "");
            param[45] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.SP_HR_RECRUITMENT_ADD", param);
            return dtData;
        }

        public DataTable UPDATE(string userLogin, HRInfoEntity entity)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[46];
            param[0] = new OracleParameter("pSEQNO", entity.Seqno ?? "");
            param[1] = new OracleParameter("pISMERIT", entity.IsMerit ?? "");
            param[2] = new OracleParameter("pPERMADDPROVINCE", entity.Permaddprovince ?? "");
            param[3] = new OracleParameter("pNORMALHOUR", entity.NORMALHOUR ?? "");
            param[4] = new OracleParameter("pJOBFIELD", entity.JOBFIELD ?? "");
            param[5] = new OracleParameter("pISCAREER", entity.IsCareer ?? "");
            param[6] = new OracleParameter("pBIRTHPLACE", entity.BIRTHPLACE ?? "");
            param[7] = new OracleParameter("pNATIONALITY", entity.NATIONALITY ?? "");
            param[8] = new OracleParameter("pPERMADD", entity.PERMADD ?? "");
            param[9] = new OracleParameter("pIDISSUEDPLACE", entity.IDISSUEDPLACE ?? "");
            param[10] = new OracleParameter("pMARRYSTATUS", entity.Marry ?? "");
            param[11] = new OracleParameter("pSEX", entity.SEX ?? "");
            param[12] = new OracleParameter("pSYSEMPID", entity.Sysempid ?? "");
            param[13] = new OracleParameter("pDEPTCODE", entity.CORPORATION ?? "");
            param[14] = new OracleParameter("pDATEREC", entity.RecruitmentDate ?? "");
            param[15] = new OracleParameter("pACADEMICMAJOR", entity.AcademicMajor ?? "");
            param[16] = new OracleParameter("pEMAIL", entity.EMAIL ?? "");
            param[17] = new OracleParameter("pETHNIC", entity.ETHNIC ?? "");
            param[18] = new OracleParameter("pJOBCODE", entity.JOBCODE ?? "");
            param[19] = new OracleParameter("pHOMETEL", entity.HOMETEL ?? "");
            param[20] = new OracleParameter("pBIRTHDAY", entity.BIRTHDAY ?? "");
            param[21] = new OracleParameter("pACADEMICKIND", entity.Academickind ?? "");
            param[22] = new OracleParameter("pACADEMIC", entity.ACADEMIC ?? "");
            param[23] = new OracleParameter("pIDENTITYCARD", entity.IDENTITYCARD ?? "");
            param[24] = new OracleParameter("pIDISSUEDDATE", entity.IDISSUEDDATE ?? "");
            param[25] = new OracleParameter("pRESIDENCE", entity.RESIDENCE ?? "");
            param[26] = new OracleParameter("pDATEJOIN", entity.Joindate ?? "");
            param[27] = new OracleParameter("pMOBILE", entity.MOBILE ?? "");
            param[28] = new OracleParameter("pRESIDENCEPROVINCE", entity.RESIDENCEPROVINCE ?? "");
            param[29] = new OracleParameter("pEMPNAME", entity.EMPNAME ?? "");
            param[30] = new OracleParameter("pRELIGION", entity.RELIGION ?? "");
            param[31] = new OracleParameter("pDUTY", entity.DUTY ?? "");
            param[32] = new OracleParameter("pFOREIGNCHECK", entity.FOREIGNCHECK ?? "");
            param[33] = new OracleParameter("pLogin", userLogin ?? "");
            param[34] = new OracleParameter("pStatusConfirm", entity.ConfirmStatus ?? "");
            param[35] = new OracleParameter("pLanguageOne", entity.ForeignLanguageOne ?? "");
            param[36] = new OracleParameter("pLevelOne", entity.LevelForeignLOne ?? "");
            param[37] = new OracleParameter("pLanguageTwo", entity.ForeignLanguageTwo ?? "");
            param[38] = new OracleParameter("pLevelTwo", entity.LevelForeignLTwo ?? "");
            param[39] = new OracleParameter("pLanguageThree", entity.ForeignLanguageThree ?? "");
            param[40] = new OracleParameter("pLevelThree", entity.LevelForeignLThree ?? "");
            param[41] = new OracleParameter("psponsor", entity.sponsor ?? "");
            param[42] = new OracleParameter("PADD_PROVINCE", entity.ADD_PROVINCE ?? "");
            param[43] = new OracleParameter("PADD_DISTRICT", entity.ADD_DISTRICT ?? "");
            param[44] = new OracleParameter("PADD_WARD", entity.ADD_WARD ?? "");
            param[45] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.SP_HR_RECRUITMENT_UPDATE", param);
            return dtData;
        }

        public DataTable DELETE(string Seqno)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PSEQNO", Seqno);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.SP_HR_RECRUITMENT_DELETE", param);
            return dtData;
        }
        //ADD BY NEZUMI_NGUYEN
        public DataTable DECLINE(string Seqno, string user)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("PSEQNO", Seqno);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            param[2] = new OracleParameter("PUSER",user);
            dtData = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.SP_HR_RECRUITMENT_DECLINE", param);
            return dtData;
        }


        public DataTable CONFIRMDATA(string PSEQNO, string pDateRec, string pDateJoin, string pLogin, string pStatusConfirm)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pSEQNO", pDateRec ?? "");
            param[1] = new OracleParameter("pDATEJOIN", pDateJoin ?? "");
            param[2] = new OracleParameter("pLogin", pLogin ?? "");
            param[3] = new OracleParameter("pStatusConfirm", pStatusConfirm ?? "");
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.SP_HR_RECRUITMENT_CONFIRMDATA", param);
            return dtData;
        }

        public DataTable CREATESYSID(string userLogin, HRInfoEntity entity)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[42];
            param[0] = new OracleParameter("pSEQNO", entity.Seqno ?? "");
            param[1] = new OracleParameter("pISMERIT", entity.IsMerit ?? "");
            param[2] = new OracleParameter("pPERMADDPROVINCE", entity.Permaddprovince ?? "");
            param[3] = new OracleParameter("pNORMALHOUR", entity.NORMALHOUR ?? "");
            param[4] = new OracleParameter("pJOBFIELD", entity.JOBFIELD ?? "");
            param[5] = new OracleParameter("pISCAREER", entity.IsCareer ?? "");
            param[6] = new OracleParameter("pBIRTHPLACE", entity.BIRTHPLACE ?? "");
            param[7] = new OracleParameter("pNATIONALITY", entity.NATIONALITY ?? "");
            param[8] = new OracleParameter("pPERMADD", entity.PERMADD ?? "");
            param[9] = new OracleParameter("pIDISSUEDPLACE", entity.IDISSUEDPLACE ?? "");
            param[10] = new OracleParameter("pMARRYSTATUS", entity.Marry ?? "");
            param[11] = new OracleParameter("pSEX", entity.SEX ?? "");
            param[12] = new OracleParameter("pSYSEMPID", entity.Sysempid ?? "");
            param[13] = new OracleParameter("pDEPTCODE", entity.CORPORATION ?? "");
            param[14] = new OracleParameter("pDATEREC", entity.RecruitmentDate ?? "");
            param[15] = new OracleParameter("pACADEMICMAJOR", entity.AcademicMajor ?? "");
            param[16] = new OracleParameter("pEMAIL", entity.EMAIL ?? "");
            param[17] = new OracleParameter("pETHNIC", entity.ETHNIC ?? "");
            param[18] = new OracleParameter("pJOBCODE", entity.JOBCODE ?? "");
            param[19] = new OracleParameter("pHOMETEL", entity.HOMETEL ?? "");
            param[20] = new OracleParameter("pBIRTHDAY", entity.BIRTHDAY ?? "");
            param[21] = new OracleParameter("pACADEMICKIND", entity.Academickind ?? "");
            param[22] = new OracleParameter("pACADEMIC", entity.ACADEMIC ?? "");
            param[23] = new OracleParameter("pIDENTITYCARD", entity.IDENTITYCARD ?? "");
            param[24] = new OracleParameter("pIDISSUEDDATE", entity.IDISSUEDDATE ?? "");
            param[25] = new OracleParameter("pRESIDENCE", entity.RESIDENCE ?? "");
            param[26] = new OracleParameter("pDATEJOIN", entity.Joindate ?? "");
            param[27] = new OracleParameter("pMOBILE", entity.MOBILE ?? "");
            param[28] = new OracleParameter("pRESIDENCEPROVINCE", entity.RESIDENCEPROVINCE ?? "");
            param[29] = new OracleParameter("pEMPNAME", entity.EMPNAME ?? "");
            param[30] = new OracleParameter("pRELIGION", entity.RELIGION ?? "");
            param[31] = new OracleParameter("pDUTY", entity.DUTY ?? "");
            param[32] = new OracleParameter("pFOREIGNCHECK", entity.FOREIGNCHECK ?? "");
            param[33] = new OracleParameter("pLogin", userLogin ?? "");
            param[34] = new OracleParameter("pStatusConfirm", entity.ConfirmStatus ?? "");
            param[35] = new OracleParameter("pLanguageOne", entity.ForeignLanguageOne ?? "");
            param[36] = new OracleParameter("pLevelOne", entity.LevelForeignLOne ?? "");
            param[37] = new OracleParameter("pLanguageTwo", entity.ForeignLanguageTwo ?? "");
            param[38] = new OracleParameter("pLevelTwo", entity.LevelForeignLTwo ?? "");
            param[39] = new OracleParameter("pLanguageThree", entity.ForeignLanguageThree ?? "");
            param[40] = new OracleParameter("pLevelThree", entity.LevelForeignLThree ?? "");
            param[41] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.SP_HR_RECRUITMENT_CREATESYSID", param);
            return dtData;
        }

        public DataTable LOADDATA_IDENTITY(string pIdNo)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pIDNO", pIdNo ?? "");
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.SP_HR_RECRUITMENT_LOADDATA", param);
            return dtData; 
        }

        public DataTable CHECK_EXISTSIDNO(string pIDENTITYCARD)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pIDNO", pIDENTITYCARD ?? "");
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.SP_CHECK_EXISTSIDNO", param);
            return dtData;
        }

        public bool CHECK_ALLOW_RECRUITMENT(string pIDENTITYCARD)
        {
            //SP_HR_EMPLOYEES_MISSING
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pIDNO", pIDENTITYCARD ?? "");
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKHR_RECRUITMENT.SP_HR_EMPLOYEES_MISSING", param);
            return dtData.Rows.Count <= 0; //FALSE: NOT ALLOW, TRUE: ALLOW
        }

        //Add by Tho 
        // Modify Date : 01/02/2014
        public DataTable HR_Recruitment_CheckExists(string pIDNo, string sponsor)
        {
            OracleParameter[] _param = new OracleParameter[3];
            _param[0] = new OracleParameter("PIDNO", pIDNo);
            _param[1] = new OracleParameter("sponsor", sponsor);
            _param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            string sp_name = "PKHR_RECRUITMENT.SP_HR_RECRUITMENT_CHECKALLOW";
            return DBHelper.getDataTable_SP(sp_name, _param);
        }

        public DataTable HR_Recruitment_CheckAllow(string pIDNo)
        {
            string sp_name = "PKHR_RECRUITMENt.SP_HR_RECRUITMENT_CHECKALLOW";
            OracleParameter[] _param = new OracleParameter[2];
            _param[0] = new OracleParameter("PIDNO", pIDNo);
            _param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, _param);
        }

        //Add by Cong
        //Modify date: 11/02/2014
        public DataTable HR_Recruiment_Delete(string pSEQNO)
        {
            string sp_name = "PKHR_RECRUITMENT.SP_HR_RECRUIMENT_DEL";
            OracleParameter[] _param = new OracleParameter[2];
            _param[0] = new OracleParameter("PSEQNO", pSEQNO);
            _param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, _param);
        }

        public DataTable HR_Recruiment_Get(string pSEQNO, string userLogin)
        {
            string sp_name = "PKHR_RECRUITMENT.sp_hr_recruiment_CREATESYS";
            OracleParameter[] _param = new OracleParameter[3];
            _param[0] = new OracleParameter("PSEQNO", pSEQNO);
            _param[1] = new OracleParameter("PLOGIN", userLogin);
            _param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, _param);
        }
    }
}