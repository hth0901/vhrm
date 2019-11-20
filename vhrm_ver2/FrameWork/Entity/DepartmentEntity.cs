using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class DepartmentEntity
    {
        public string DepartmentCode { get; set; }
        public string GroupCode { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Dictionary { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
    }
}