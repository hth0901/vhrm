using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class OrgNodeViewModel
    {
        public string id { get; set; }//DEPTCODE
        public string pid { get; set; }//DEPTPARENT
        public string DEPTNAME { get; set; }
        public string SUPERVISORS { get; set; }
        public string IMG { get; set; }//SPLIT IMAGE
    }
}