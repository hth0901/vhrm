using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class FormEntity
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string formID;

        public string FormID
        {
            get { return formID; }
            set { formID = value; }
        }
        private string formName;

        public string FormName
        {
            get { return formName; }
            set { formName = value; }
        }
        private string dictionaryID;

        public string DictionaryID
        {
            get { return dictionaryID; }
            set { dictionaryID = value; }
        }
        private string cREATE_DT;

        public string CREATE_DT
        {
            get { return cREATE_DT; }
            set { cREATE_DT = value; }
        }
        private string cREATE_UID;

        public string CREATE_UID
        {
            get { return cREATE_UID; }
            set { cREATE_UID = value; }
        }
        private string uPDATE_DT;

        public string UPDATE_DT
        {
            get { return uPDATE_DT; }
            set { uPDATE_DT = value; }
        }
        private string uPDATE_UID;

        public string UPDATE_UID
        {
            get { return uPDATE_UID; }
            set { uPDATE_UID = value; }
        }

        private string filePath, moduleID;

        public string ModuleID
        {
            get { return moduleID; }
            set { moduleID = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
    }
}