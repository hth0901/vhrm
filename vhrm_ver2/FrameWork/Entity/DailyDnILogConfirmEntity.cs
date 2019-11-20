using System;

namespace vhrm.FrameWork.Entity
{
    public class DailyDnILogConfirmEntity
    {
        public string sys_empid { get; set; }
        public string Date_wk { get; set; }
        public string shiftcd { get; set; }
        public string Workkind { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }

        public int MinutesLate { get; set; }
        public int MinutesSoon { get; set; }
        public string DeductTimeIn { get; set; }
        public string DeductTimeOut { get; set; }
        public int DeductTime{ get; set; }
        public float Deductday { get; set; }

        public string StartTime130 { get; set; } 
        public string EndTime130 { get; set; }
        public float WorkHour130 { get; set; }

        public string Remark { get; set; }
        public string Confirm_IS { get; set; }
        public string Confirm_UID { get; set; }
        public string UserID { get; set; }
        public string LogHistory { get; set; }
        public string LunchTime { get; set; }
    }
}