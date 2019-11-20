using System;

namespace vhrm.FrameWork.Entity
{
    public class CategoryValueEntity
    {
        public int CategoryId { get; set; }
        public int CategoryValueId { get; set; }
        public string Code { get; set; }
        public string CategoryValue { get; set; }
        public int DictionaryId { get; set; }
        public string ParentId { get; set; }
        public bool IsActive { get; set; }
        public int OrderIndex { get; set; }
        public string IsEdit { get; set; }
        public string SubCode { get; set; }

        public float Amt { get; set; }
        public string KindAmt { get; set; }
        public string Region { get; set; }
    }
}