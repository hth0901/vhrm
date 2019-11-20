using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class MenuThirdLevel
    {
        public string menuId { get; set; }
        public string menuName { get; set; }
        public string menuParentId { get; set; }
        public string menuPath { get; set; }
        public string url { get; set; }
    }
}