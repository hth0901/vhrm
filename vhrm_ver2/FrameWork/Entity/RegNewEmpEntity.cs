using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class RegNewEmpEntity
    {
        public string RegID { get; set; }
        public string IDNO { get; set; }
        public string EMPID { get; set; }        
        public string EMPNAME { get; set; }
        public string ENTDATE { get; set; }
        public string SEX { get; set; }
        public string BIRTHDAY { get; set; }
        public string DEPTCODE { get; set; }
        public string ISSUEDPLACE { get; set; }
        public string Issueddate { get; set; }
        //public string EMPIDCLSS { get; set; }
        public string STRUCT { get; set; }
        public string JOBCODE { get; set; }
        public string JOBFIELD { get; set; }
        public string DUTY { get; set; }
        public string NORMALHOUR { get; set; }
        public string RFD { get; set; }
        public RegNewEmpEntity()
        {
            IDNO = "";
            EMPID = "";
            ENTDATE = "";
            EMPNAME = "";
            SEX = "";
            BIRTHDAY = "";
            DEPTCODE = "";
            //EMPIDCLSS = "";
            STRUCT = "";
            JOBCODE ="";
            JOBFIELD = "";
            DUTY = "";
            NORMALHOUR = "";
            RFD = "";
        }

    }
}