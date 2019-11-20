using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class MenuSecondLevel
    {
        public string menuId { get; set; }
        public string menuName { get; set; }
        public string menuParentId { get; set; }
        public string menuPath { get; set; }
        public string menuUrl { get; set; }
        public List<MenuThirdLevel> menuThirdLevel { get; set; }
    }
}