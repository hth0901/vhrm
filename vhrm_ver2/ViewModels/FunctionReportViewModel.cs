using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class FunctionReportViewModel
    {
        public string FUNCPORTCD { get; set; }
        public string FUNCNAME { get; set; }
        public string FUNCCODE { get; set; }
        public string FUNCPARENT { get; set; }
        public bool isChild { get; set; }
        public List<FunctionReportViewModel> FunctionReportViewModels = new List<FunctionReportViewModel>();
    }
}