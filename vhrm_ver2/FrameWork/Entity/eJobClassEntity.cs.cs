//<%-- 
//    Author: ndhung
//    Date: 2017.06.01
//    Desc: page for management new JobCode Class of PKVN
//--%>

namespace vhrm.FrameWork.Entity
{
    public class eJobClassEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SubCode { get; set; }
        public string Definition { get; set; }
        public string IsActive { get; set; }
    }

    public class eJobSubCodeEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string SubCode { get; set; }
        public string Definition { get; set; }
        public string Remark { get; set; }
        public string IsActive { get; set; }
    }

    public class eJobSubCodeMappingEntity
    {
        public string JobId { get; set; }
        public string MapId { get; set; }
        public string ValidityFrom { get; set; }
        public string Extendto { get; set; }
        public string Description { get; set; }
        public string LevelMappingContent { get; set; }
    }

    public class eJobEmpManagement
    {
        public string Idx { get; set; }
        public string SysEmpId { get; set; }
        public string ValidityFrom { get; set; }
        public string Extendto { get; set; }
        public string MainJob { get; set; }
        public string MainJob_Level { get; set; }
        public string Remark { get; set; }
        public string SubJobCode_Content { get; set; }
    }
}