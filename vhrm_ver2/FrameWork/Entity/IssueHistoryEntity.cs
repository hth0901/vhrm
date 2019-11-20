using System;

namespace vhrm.FrameWork.Entity
{
    public class IssueHistoryEntity
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? IssueDate { get; set; }
        public int IssueType { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string WrittenBy { get; set; }
    }
}