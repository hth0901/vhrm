using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.Models
{
    public class CategoryValueModel
    {
        public string CAT_VALUE_ID { get; set; }
        public string CAT_CODE { get; set; }
        public string CAT_VALUE { get; set; }
        public string CATEGORY_ID { get; set; }
        public string SEQ { get; set; }
        public string DICTIONARY_ID { get; set; }
        public string MOTHER_ID { get; set; }
        public string MOTHER_NAME { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string ORDERINDEX { get; set; }
        public bool ISEDIT { get; set; }
        public string CREATE_UID { get; set; }
        public DateTime? CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public DateTime? UPDATE_DT { get; set; }
        public string SUBCODE { get; set; }
        public string IS_ACTIVE2 { get; set; }
        public string DICTIONARY_ID2 { get; set; }
    }
}