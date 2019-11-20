using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class SeveranceEntity
    {
        public string SYSEMPID { get; set; }
        public string PCorporation { get; set; }
        public string PMonth { get; set; }
        public string PValidityfrom { get; set; }
        public string PStopworkreason { get; set; }
        public string PSigneddate { get; set; }

        public string PAYTYPE { get; set; }
        public string TOTALWORKYEAR { get; set; }
        public string TOTALWORKMONTH { get; set; }
        public string TOTALWORKDAY { get; set; }
        public string VIOLATEDDAYS { get; set; }
        public string AVGSALARY { get; set; }
        public string AVGALLOWANCE { get; set; }
        public string PPayrate { get; set; }
        public string PPaydate { get; set; }
        public string PSeverancepay { get; set; }
        public string SEVERANCEALLOWANCE { get; set; }
        public string COMPENSATION { get; set; }

        public string PNopayreason { get; set; }
        public string RETURNHEALTHCARD { get; set; }
        public string PReturniddate { get; set; }
        public string PRemark { get; set; }
        public string PConfirmcheck { get; set; }
        public string PUser { get; set; }

        //update by ndhung 2014.07.25
        public string ANNUALPAY { get; set; }
        public string MONTHDEDUCT { get; set; }
        public string AVAILABLE_DAY { get; set; }
        public string ANN_PAYDAY { get; set; }
        public string TOTALSEVERANCE { get; set; }
        public string NORETURNHEALTHCARD { get; set; }

        //add by ndhung 2015.11.09 -> for probation month & maternity leave month
        public string TOTAL_MONTH_MATERNITYLEAVE { get; set; }
        public string TOTAL_MONTH_PROBATION { get; set; }

        //add by ndhung 2015.11.09 -> for probation month & maternity leave month
        public string TOTAL_MONTH_SICKLEAVE { get; set; }
        public string RETURN_INSREFUND { get; set; }

        //add by ndhung 2017.04.24 -. thêm cột other payment
        public string OTHER_PAYMENT { get; set; }

        //add by ndhung 2018.05.18 -> thêm số ngày lẻ thử việc & thai sản và tính lại ngày hưởng tctv
        public string DAY_MATERNITYLEAVE { get; set; }
        public string DAY_PROBATION { get; set; }
        public string TOTALWORKYEAR_ACTUAL { get; set; }
        public string TOTALWORKMONTH_ACTUAL { get; set; }
        public string TOTALWORKDAY_ACTUAL { get; set; }
    }
}