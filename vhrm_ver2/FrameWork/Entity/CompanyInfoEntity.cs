using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class CompanyInfoEntity
    {      
        public string Corporation { get; set; }
        public string Name_en { get; set; }
        public string Name_vn { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address1_en { get; set; }
        public string Address1_vn { get; set; }
        public string Address2_en { get; set; }
        public string Address2_vn { get; set; }
        public string Update_Uid { get; set; }
        public string  Empidinit { get; set; }
        public string  CreateUID { get; set; }
        public string Code { get; set; }
    }
}