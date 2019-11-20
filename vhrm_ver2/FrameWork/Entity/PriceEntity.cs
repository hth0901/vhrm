using System;

namespace vhrm.FrameWork.Entity
{
   [Serializable]
    public class PriceEntity
    {
        public string PriceId { get; set; }
        public string ProductId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
    }
}