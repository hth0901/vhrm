﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class FunctionReport
    {
        public string FUNCPORTCD { get; set; }
        public string FUNCCODE { get; set; }
        public string SYS_EMPID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime APPLYDATE { get; set; }
        public string ISACTIVE { get; set; }
        public string POSITION { get; set; }
        public string SKILL { get; set; }
        public string REMARK { get; set; }
        public string FUNCTREPORTLEVEL { get; set; }
        public string CREATE_UID { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string UPDATE_DT { get; set; }
    }
}