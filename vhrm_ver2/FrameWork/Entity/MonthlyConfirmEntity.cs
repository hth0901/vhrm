using System;
namespace vhrm.FrameWork.Entity
{
    public class MonthlyConfirmEntity
    {
        public string ui { get; set; }
        public string EmployeeId { get; set; }
        public string ContractNo { get; set; }
        public string MonthLog { get; set; }
        public string AmountDayWork { get; set; }
        public string AmountDaySub{ get; set; }

        public string AmountSft0A3{ get; set; }
        public string AmountOt1A5{ get; set; }
        public string AmountOt1A95 { get; set; }
        public string AmountOt2 { get; set; }
        public string AmountOt3 { get; set; }

        public string AmountBreakHour{ get; set; }
        public string AmountHour1A5{ get; set; }
        public string RegistryId { get; set; }
        public string IsConfirm { get; set; }
        public string ConfirmId { get; set; }
        public DateTime ConfirmDate { get; set; }
    }
}