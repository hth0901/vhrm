using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class eMenuItem
    {
        public string MENUID { get; set; }
        public string MENUNAME { get; set; }
        public string MOTHERID { get; set; }
        public string SEQ { get; set; }
        public string FORMCODE { get; set; }
        public string ISACTIVE { get; set; }
        public string DICTIONARYID { get; set; }
        public string CREATE_UID { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string UPDATE_DT { get; set; }
        public string ISLEAF { get; set; }
        public string MENULEVEL { get; set; }
    }
}