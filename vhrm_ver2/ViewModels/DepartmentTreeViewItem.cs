using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class DepartmentTreeViewItem
    {
        public string ITEMCODE { get; set; }
        public string DEPTCODEFULL { get; set; }
        public string PARENTID { get; set; }
        public int ITEMLEVEL { get; set; }
        public string SHORTNAME { get; set; }
        public string FULLNM { get; set; }
    }
}