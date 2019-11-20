/*
    2013-03-14 by Phuong
 */

using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class HRInfoEntity
    {
        public string EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string CORPORATION { get; set; }
        public string DEPARTMENT { get; set; }
        public string TEAM { get; set; }
        public string SECTION { get; set; }
        public string CONTRACTKIND { get; set; }
        public string BIRTHDAY { get; set; }
        public string BIRTHPLACE { get; set; }
        public string SEX { get; set; }
        public string STATUS { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE { get; set; }
        public string HOMETEL { get; set; }
        public string FOREIGNCHECK { get; set; }
        public string ACADEMIC { get; set; }
        public string NATIONALITY { get; set; }
        public string NATIVELAND { get; set; }
        public string RELIGION { get; set; }
        public string ETHNIC { get; set; }
        public string PREVIOUSID { get; set; }
        public string RFID { get; set; }
        public string NORMALHOUR { get; set; }
        public string JOBSERIAL { get; set; }
        public string JOBCODE { get; set; }
        public string JOBFIELD { get; set; }
        public string DUTY { get; set; }
        public string LINENO { get; set; }
        public string STEPCODE { get; set; }
        public string SENIORITY { get; set; }
        public string SENIORITYLEVEL { get; set; }
        public string IDENTITYCARD { get; set; }
        public string IDISSUEDPLACE { get; set; }
        public string IDISSUEDDATE { get; set; }
        public string RESIDENCEPROVINCE { get; set; }
        public string RESIDENCE { get; set; }
        public string PERMADD { get; set; }
        public string CONTADD { get; set; }
        public string FIRSTHIREDDATE { get; set; }
        public string LATESTHIREDDATE { get; set; }
        public string LATESTSIGNEDDATE { get; set; }
        public string LATESTSTARTINGDATE { get; set; }
        public string LATESTRESIGNEDDATE { get; set; }
        public string JCRESIGNEDDATE { get; set; }
        public string SONGTHANDATE { get; set; }
        public string HOSPITAL_CD { get; set; }
        public string PITNO { get; set; }
        public string PITPLACE { get; set; }
        public string PITDATE { get; set; }
        public string LBNO { get; set; }
        public string LBPLACE { get; set; }
        public string LBDATE { get; set; }
        public string SINO { get; set; }
        public string SIPLACE { get; set; }
        public string SIDATE { get; set; }
        public string HINO { get; set; }
        public string HIPLACE { get; set; }
        public string HIDATE { get; set; }
        public string FILECODENO { get; set; }
        public string LANGUAGE { get; set; }
        public string QUALIFICATION { get; set; }
        public string CONFIRMCHECK { get; set; }
        public string CONFIRMID { get; set; }
        public string CONFIRMDATE { get; set; }
        public string RecruitmentDate { get; set; }
        public string Joindate { get; set; }
        public string Marry { get; set; }
        public string Academickind { get; set; }
        public string AcademicMajor { get; set; }
        public string Permaddprovince { get; set; }
        public string ForeignLanguageOne { get; set; }
        public string LevelForeignLOne { get; set; }
        public string ForeignLanguageTwo { get; set; }
        public string LevelForeignLTwo { get; set; }
        public string ForeignLanguageThree { get; set; }
        public string LevelForeignLThree { get; set; }
        public string IsMerit { get; set; }
        public string IsCareer { get; set; }
        public string Seqno { get; set; }
        public string Sysempid { get; set; }
        public string ConfirmStatus { get; set; }
        public string sponsor { get; set; }

        public string ADD_PROVINCE { get; set; }
        public string ADD_DISTRICT { get; set; }
        public string ADD_WARD { get; set; }
    }
}