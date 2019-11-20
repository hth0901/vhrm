using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class OrganazationEntity
    {
        public string DepartmentCode { get; set; }
        public string Organazation { get; set; }
        public string ParentId { get; set; }
    }
}