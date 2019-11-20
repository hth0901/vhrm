using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class SkillEntity
    {
        public string Id { get; set; }
        public string EmpId { get; set; }
        public string ValidityFrom { get; set; }
        public string ValidityTo { get; set; }
        public string SkillLevel { get; set; }
        public string Remark { get; set; }
        public string UserId { get; set; }
    }
}