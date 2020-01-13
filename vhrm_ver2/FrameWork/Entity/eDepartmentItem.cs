using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class eDepartmentItem
    {
        public string DEPTCODE { get; set; }
        public string DEPTNAME { get; set; }
        public string DEPTPARENT { get; set; }
        public string DEPTLEVEL { get; set; }
        public string ORDERINDEX { get; set; }
        public string ISACTIVE { get; set; }
        public string REMARK { get; set; }
        public string DEPTCODEOLD { get; set; }
        public string COMPCODE { get; set; }
        public string CREATE_UID { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string UPDATE_DT { get; set; }
        public string DEPTSHORTNAME { get; set; }
        public string ISLEAF { get; set; }
    }

    public class eFunctionItem
    {
        public string FUNCCODE { get; set; }
        public string FUNCNAME { get; set; }
        public string FUNCPARENT { get; set; }
        public string FUNCLEVEL { get; set; }
        public string ORDERINDEX { get; set; }
        public string ISACTIVE { get; set; }
        public string REMARK { get; set; }
        public string CREATE_UID { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string UPDATE_DT { get; set; }
        public string SHORTNAME { get; set; }
        public string ISLEAF { get; set; }
    }
}