using System;
namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class QueryMasterEntity
    {
        public string PageId { get; set; }
        public string ControlType { get; set; }

        public int PositionLeft { get; set; }
        public int PositionTop { get; set; }
        public int Width { get; set; }
        public int MaxLength { get; set; }

        public string MajorCode { get; set; }
        public string DefaultValue { get; set; }
        public string DictionaryCode { get; set; }
        public int ItemIndex { get; set; }
    }
}