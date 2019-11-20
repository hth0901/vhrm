using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class eUser
    {
        public string USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public string STAFF_ID { get; set; }
        public string USER_EMAIL { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATE_UID { get; set; }
        public DateTime CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public DateTime UPDATE_DT { get; set; }
    }
}