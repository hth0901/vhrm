using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class OriganizationUsersViewModel
    {
        public string Display { get; set; }
        public string Key { get; set; }
        public int Flag { get; set; }
        public string GEOREPORTCD { get; set; }
        public string DEPTNAME { get; set; }
        public string DEPTCODE { get; set; }
        public string DEPTPARENT { get; set; }
        public string SYS_EMPID { get; set; }
        public string EMPID { get; set; }
        public bool leaf { get; set; }
        public List<OriganizationUsersViewModel> childs = new List<OriganizationUsersViewModel>();
    }
}