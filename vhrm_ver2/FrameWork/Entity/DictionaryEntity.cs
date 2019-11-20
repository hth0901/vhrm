/*
* Author: Pham Hung Dung
* Create Date:
* Description: 
*/

namespace vhrm.FrameWork.Entity
{
    public class DictionaryEntity
    {
        private int iD;       
        private string dictionaryID;    
        private string english;
        private string korean;
        private string vietnamese;
        private string other1;     
        private string other2;    
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
        public string English
        {
            get { return english; }
            set { english = value; }
        }

        public string Korean
        {
            get { return korean; }
            set { korean = value; }
        }
        public string Vietnamese
        {
            get { return vietnamese; }
            set { vietnamese = value; }
        }
        public string Other1
        {
            get { return other1; }
            set { other1 = value; }
        }
        public string Other2
        {
            get { return other2; }
            set { other2 = value; }
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