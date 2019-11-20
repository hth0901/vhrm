using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class MenuFirstLevel
    {
        public string menuId { get; set; }
        public string menuName { get; set; }
        public string menuParentId { get; set; }
        public string menuUrl { get; set; }
        public List<MenuSecondLevel> menuSecondLevel { get; set; }
    }
}