using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class LevelSaralyEntity
    {
        public string Version { get; set; }
        public string JobCode { get; set; }
        public string StepNo { get; set; }
        public string StepLevel { get; set; }
        public float Salary { get; set; }
        public string CreateUID { get; set; }
        public string UpdateUID { get; set; }
        //public string  status { get; set; }
    }
}