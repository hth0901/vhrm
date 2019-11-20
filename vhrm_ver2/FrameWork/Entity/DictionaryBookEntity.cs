/*
* Author: Pham Hung Dung
* Create Date:
* Description: 
*/

namespace SaFa.FrameWork.Entity.Opm
{
    public class DictionaryBookEntity
    {
        private int iD;
        private string formID;
        private string dictionaryID;
        private string cREATE_DT;
        private string cREATE_UID;
        private string uPDATE_DT;
        private string uPDATE_UID;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string DictionaryID
        {
            get { return dictionaryID; }
            set { dictionaryID = value; }
        }
        public string FormID
        {
            get { return formID; }
            set { formID = value; }
        }
        public string CREATE_DT
        {
            get { return cREATE_DT; }
            set { cREATE_DT = value; }
        }
        public string CREATE_UID
        {
            get { return cREATE_UID; }
            set { cREATE_UID = value; }
        }
        public string UPDATE_DT
        {
            get { return uPDATE_DT; }
            set { uPDATE_DT = value; }
        }
        public string UPDATE_UID
        {
            get { return uPDATE_UID; }
            set { uPDATE_UID = value; }
        }
    }
}