using System;

namespace vhrm.FrameWork.Entity
{
    public class CategoryEntity
    {
        public string CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public string DictionaryId { get; set; }
        public string ParentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsEdit { get; set; }
        public int Motherid { get; set; }
        public bool Issubcode { get; set; }
    }   
}