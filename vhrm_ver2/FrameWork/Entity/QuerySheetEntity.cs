namespace vhrm.FrameWork.Entity
{
    public class QuerySheetEntity
    {
        public string PageId { get; set; }
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }
        public string FormatColumn { get; set; }
        public int ColumnWidth { get; set; }

        public string BackColor { get; set; }
        public string ForeColor { get; set; }
        public string DictionaryCode { get; set; }
        public int OrderIndex { get; set; }
    }
}