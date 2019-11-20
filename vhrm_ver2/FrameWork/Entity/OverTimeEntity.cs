using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class OverTimeEntity
    {
        public string OTDate { get; set; }
        public string EmpId { get; set; }
        public string DeptCode { get; set; }
        public string Corporation { get; set; }
        public string Department { get; set; }
        public string Team { get; set; }
        public string SecTion { get; set; }
        public string OTKind { get; set; }
        public string PlanTimeIn { get; set; }
        public string PlanTimeOut { get; set; }
        public float PlanOTHour { get; set; }
        public float PlanOTBreak { get; set; }
        public string RegisterId { get; set; }
        public DateTime RegistryDate { get; set; }
        public string AcceptCheck { get; set; }
        public string AcceptId { get; set; }
        public DateTime AcceptDate { get; set; }
        public string LogTimeIn { get; set; }
        public string LogTimeOut { get; set; }
        public string AdjTimeIn { get; set; }
        public string AdjTimeOut { get; set; }
        public float AdjOTHour { get; set; }
        public float AdjOTBreak { get; set; }
        public string ConfirmCheck { get; set; }
        public string ConfirmId { get; set; }
        public string ConfirmDate { get; set; }
        public string FromNormal15 { get; set; }
        public string ToNormal15 { get; set; }
        public float TotalNormal15 { get; set; }
        public string Hislogdate { get; set; }
        public string Nhour_timein { get; set; }
        public string Nhour_timeout { get; set; }
        public float Nhour_Total { get; set; }

        public string DEDUCT_TIME_START { get; set; }

        public string DEDUCT_TIME_END { get; set; }

        public float DEDUCT_HOUR { get; set; }

        public string CreateId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}