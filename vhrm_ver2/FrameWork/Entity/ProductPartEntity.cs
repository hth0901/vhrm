using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class ProductPartEntity
    {
        public int Part_ID { get; set; }
        public int MainProductId { get; set; }
        public int Product_ID { get; set; }
        public string ProductCode { get; set; }
        public string AccClass { get; set; }
        public string SalesType { get; set; }
        public string ProductClass { get; set; }
        public string ProductSubClass { get; set; }
        public string ProductName { get; set; }
        public string ProductEngName { get; set; }
        public string ProductKorName { get; set; }
        public string Unit { get; set; }
        public string Spec { get; set; }
        public string Remark { get; set; }
        public string IsActive { get; set; }
        public string UserCd { get; set; }
    }
}