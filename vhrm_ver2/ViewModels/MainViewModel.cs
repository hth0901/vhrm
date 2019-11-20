using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class MainViewModel
    {
        public string menu { get; set; }
        public List<MenuLevel1ViewModel> lstMenuLv1 { get; set; }
    }
}