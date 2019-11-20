using System;

namespace vhrm.FrameWork.Entity
{
   [Serializable]
    public class ServiceTeamEntity
    {
        public int TeamId { get; set; }
        public string TeamCode { get; set; }
        public string TeamName { get; set; }
        public int TeamLeaderId { get; set; }
        public string Remark { get; set; }
        public int IsActive { get; set; }
    }
}