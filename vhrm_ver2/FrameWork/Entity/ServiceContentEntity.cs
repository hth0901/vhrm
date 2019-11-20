using System;

namespace vhrm.FrameWork.Entity
{
   [Serializable]
    public class ServiceContentEntity
    {
        public int ServiceContentId { get; set; }
        public int ServiceId { get; set; }
        public string SerialNo { get; set; }
        public string EquipmentName { get; set; }
        public string PartorServiceId { get; set; }
        public string PartorService { get; set; }
        public string PartorServiceCode { get; set; }
        public string UnitPrice { get; set; }
        public string StandardPrice { get; set; }
        public string Unit { get; set; }
        public string ServiceType { get; set; }
        public string ServiceTypeId { get; set; }
        public string ChargeType { get; set; }
        public string ChargeTypeId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public double ChargedPrice { get; set; }
        public string Remark { get; set; }
    }
}