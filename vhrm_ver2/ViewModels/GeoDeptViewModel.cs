using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class GeoDeptViewModel
    {
        public string GEOREPORTCD { get; set; }
        public string DEPTNAME { get; set; }
        public string DEPTCODE { get; set; }
        public string DEPTPARENT { get; set; }
        public string SYS_EMPID { get; set; }
        public List<GeoDeptViewModel> GeoDeptViewModels { get; set; }
        public bool isChild { get; set; }
    }
}