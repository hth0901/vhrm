using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class TaskEntity
    {
        public string SysEmpid { get; set; }
        public string Strdate { get; set; }
        public string Enddate { get; set; }
        public string Taskid { get; set; }
        public string PARENTTASKID { get; set; }
        public string Seqno { get; set; }
        public string LoginID { get; set; }
    }
}