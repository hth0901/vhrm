using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class ItemSalaryRegistryEntity
    {
        public string pItemName { get; set; }
        public string pItemNameVN { get; set; }
        public string pItemId { get; set; }
        public int pItemType {get; set; }
        public string pUi { get; set; }
        public string PInputKind { get; set; }
        public string GroupCd { get; set; }
        public int OrderIndex { get; set; }
        public string GroupVer { get; set; }
        public string IsContract { get; set; }
    }
}