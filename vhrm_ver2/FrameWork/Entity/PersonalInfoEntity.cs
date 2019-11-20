/*
    2013-03-29 by Phuong
 */

using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class PersonalInfoEntity
    {
        public string EMPIDOLD { get; set; }
        public string EMPNAME { get; set; }
        public string EMPNE { get; set; }
        public string BIRTHDAY { get; set; }
        public string CONTRACTKIND { get; set; }
        public string BIRTHPLACE { get; set; }
        public string SEX { get; set; }
        public string STATUS { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE { get; set; }
        public string HOMETEL { get; set; }
        public string FOREIGNCHECK { get; set; }
        public string BUS { get; set; }
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
        public string PROFESSION { get; set; }
        public string CONFIRMCHECK { get; set; }
        public string CONFIRMID { get; set; }
        public DateTime CONFIRMDATE { get; set; }
        public string PERMADDPROVINCE { get; set; }
        public string CONTADDPROVINCE { get; set; }
        public string DEPTCODE { get; set; }
        public string EMPID { get; set; }
        public string SYS_EMPID { get; set; }
        public string BankCd { get; set; }
        public string BranchName { get; set; }
        public string BankDate { get; set; }
        public string AccountNo { get; set; }
        public string JoinDate { get; set; } 
        public byte []ImageBinary { get; set; }
        public string AcademicSchool { get; set; }
        public string AcademicFromDate { get; set; }
        public string AcademicToDate { get; set; }
        public string AcademicMajor { get; set; }
        public string CardIssuedPlaceCd { get; set; }
        public string CardIssuedDate { get; set; }
        public string RFIDSerialCheck { get; set; }
        public string ReasonUpdate { get; set; }
        public string WorkHours { get; set; }
        public string ImgeUrl { get; set; }
        public string Academickind { get; set; }

        public string MARITALSTATUS { get; set; }
        public string MARRIEDDATE { get; set; }
        public string PayType { get; set; }
        public string LaborFund { get; set; }
        
        //UPDATE BY NDHUNG 2014.1202
        public string DATEPK { get; set; }
        public string ADD_PROVINCE { get; set; }
        public string ADD_DISTRICT { get; set; }
        public string ADD_WARD { get; set; }

       public PersonalInfoEntity()
        {
            EMPIDOLD = "";
            EMPNAME = "";
            CONTRACTKIND = "";
            BIRTHDAY = "";
            BIRTHPLACE = "";
            SEX = "";
            STATUS = "";
            EMAIL = "";
            MOBILE = "";
            HOMETEL = "";
            FOREIGNCHECK = "";
            BUS = "";
            ACADEMIC = "";
            NATIONALITY = "";
            NATIVELAND = "";
            RELIGION = "";
            ETHNIC = "";
            PREVIOUSID = "";
            RFID = "";
            NORMALHOUR = "";
            JOBSERIAL = "";
            JOBCODE = "";
            JOBFIELD = "";
            DUTY = "";
            LINENO = "";
            STEPCODE = "";
            SENIORITY = "";
            SENIORITYLEVEL = "";
            IDENTITYCARD = "";
            IDISSUEDPLACE = "";
            IDISSUEDDATE = "";
            RESIDENCEPROVINCE = "";
            RESIDENCE = "";
            PERMADD = "";
            CONTADD = "";
            FIRSTHIREDDATE = "";
            LATESTHIREDDATE = "";
            LATESTSIGNEDDATE = "";
            LATESTSTARTINGDATE = "";
            LATESTRESIGNEDDATE = "";
            JCRESIGNEDDATE = "";
            SONGTHANDATE = "";
            HOSPITAL_CD = "";
            PITNO = "";
            PITPLACE = "";
            PITDATE = "";
            LBNO = "";
            LBPLACE = "";
            LBDATE = "";
            SINO = "";
            SIPLACE = "";
            SIDATE = "";
            HINO = "";
            HIPLACE = "";
            HIDATE = "";
            FILECODENO = "";
            LANGUAGE = "";
            QUALIFICATION = "";
            PROFESSION = "";
            CONFIRMCHECK = "";
            CONFIRMID = "";
            CONFIRMDATE = DateTime.Now;
            PERMADDPROVINCE = "";
            CONTADDPROVINCE = "";
            DEPTCODE = "";
            EMPID = "";
            SYS_EMPID = "";
            WorkHours = "";

            MARITALSTATUS = "0";
            MARRIEDDATE = "";
            PayType = "1";
            //update by ndhung 2014.12.02
           DATEPK = "";
        }
  
    }
}