using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class TimeWorkEntity
    {
        public string DEPTCODE { get; set; }
        public string KINDSTAFF { get; set; } //101, staff=8h, worker=7h30
        public string DATEFROM { get; set; }
        public string DATETO { get; set; } 

        public string ATTENDANCE_TIME_FROM { get; set; }
        public string ATTENDANCE_TIME_TO { get; set; }

        //ADD BY NDHUNG 2014.09.22 -> USE FOR LIMIT CHECK IN TIME
        public string LIMIT_CHECKINTIME { get; set; }
        public string LIMIT_CHECKOUTTIME { get; set; }

        //ADD BY NDHUNG 2015.08.19 -> ADD WEEK DAY
        public string WEEKDAY { get; set; }

        public string LUNCH_TIME_FROM { get; set; }
        public string LUNCH_TIME_TO { get; set; }
        public string NORMAL_TIME_FROM { get; set; }
        public string NORMAL_TIME_TO { get; set; }
        public string IS_ADDITIONAL { get; set; }

        public string UID { get; set; }
    }
}