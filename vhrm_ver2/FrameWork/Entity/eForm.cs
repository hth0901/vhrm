using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class eForm
    {
        public string FORM_ID { get; set; }
        public string FORM_CODE { get; set; }
        public string FORM_NAME { get; set; }
        public string DICTIONARY_ID { get; set; }
        public string FILE_PATH { get; set; }
        public string MODULE_ID { get; set; }
        public string CREATE_UID { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string UPDATE_DT { get; set; }
        public bool IS_ACTIVE { get; set; }
    }
}