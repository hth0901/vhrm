using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class InsAccidentDSPHSKEntity
    {
        public int Seqno;
        public string Sys_empid;
        public string StrDate;
        public string Todate;
        public float RateDecrease;
        public float Dateoff1;
        public float Dateoff2;
        public float Amt;
        public string Remark;
        public string ConfirmIs;
        public string ConfirmUID;
        public string LoginId;

        /*
         * pSEQNO int,pSys_empid char,pStrDate char,pEnddate char,pRateDecrease number, pDateoff1 number,pDateoff2 number,
  pAmt number,pRemark nvarchar2, pConfirmIs char, pConfirmUID varchar2,pUSER
         */
    }
}