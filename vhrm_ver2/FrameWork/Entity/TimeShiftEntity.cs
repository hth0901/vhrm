using System;

namespace vhrm.FrameWork.Entity
{
    public class TimeShiftEntity
    {
        public string ShiftId { get; set; }
        public string ShiftCode { get; set; }
        public string ShiftName { get; set; }
        public string ShiftNMVN { get; set; }
        public string Corporation { get; set; }
        public int OrderIndex { get; set; }

        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string DeptCode { get; set; }
        public string UID { get; set; }
    }
}