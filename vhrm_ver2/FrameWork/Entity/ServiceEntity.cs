using System;

namespace vhrm.FrameWork.Entity
{
   [Serializable]
    public class ServiceEntity
    {
        public int ServiceId { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string Subscriber { get; set; }
        public string Contents { get; set; }
        public string TeamId { get; set; }
        public string StaffId { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? CompletedTime { get; set; }
        public string ArrivalLatitude { get; set; }
        public string ArrivalLongtitude { get; set; }
        public string ServiceStatus { get; set; }
    }
}