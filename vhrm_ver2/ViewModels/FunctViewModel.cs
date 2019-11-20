using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class FunctViewModel
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
        public List<FunctViewModel> FunctViewModels { get; set; }
    }
}