namespace vhrm.FrameWork.Entity
{
    public class MenuTreeEntity
    {
        public int ID { get; set; }
        public string MenuID { get; set; }
        public string MenuName { get; set; }
        public string MotherID { get; set; }
        public int Seq { get; set; }
        public string FormID { get; set; }
        public string FilePath { get; set; }
        public string DictionaryID { get; set; }
        public string LangValue { get; set; }
        public string CREATE_DT { get; set; }
        public string CREATE_UID { get; set; }
        public string UPDATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string IsActive { get; set; }
    }
}