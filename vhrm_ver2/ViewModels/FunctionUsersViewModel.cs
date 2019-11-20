using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class FunctionUsersViewModel
    {
        public string Display { get; set; }
        public string Key { get; set; }
        public int Flag { get; set; }
        public string FUNCPORTCD { get; set; }
        public string FUNCNAME { get; set; }
        public string FUNCCODE { get; set; }
        public string FUNCPARENT { get; set; }
        public string SYS_EMPID { get; set; }
        public string EMPID { get; set; }
        public bool leaf { get; set; }
        public List<FunctionUsersViewModel> childs = new List<FunctionUsersViewModel>();
    }
}