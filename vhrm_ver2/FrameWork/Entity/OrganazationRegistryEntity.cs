using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class OrganazationRegistryEntity
    {
        public string DepartmentCode { get; set; }
        public string DepartmentLevel { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Dictionary { get; set; }
        public string Description { get; set; }
        public string Corporation { get; set; }
        public string Department { get; set; }
        public string Team { get; set; }
        public string Section { get; set; }
        public string IsActive { get; set; }
        public string IsProduction { get; set; }
    }
}