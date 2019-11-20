using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class TimeSheetItemEntity
    {
        private string _itemID;
        public string ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        private string _itemNM;

        public string ItemNM
        {
            get { return _itemNM; }
            set { _itemNM = value; }
        }
        private string _itemNMVN;

        public string ItemNMVN
        {
            get { return _itemNMVN; }
            set { _itemNMVN = value; }
        }
        private string _methodPay;

        public string MethodPay
        {
            get { return _methodPay; }
            set { _methodPay = value; }
        }

        private string _symBol;

        public string SymBol
        {
            get { return _symBol; }
            set { _symBol = value; }
        }
        private string _isabSence;

        public string IsabSence
        {
            get { return _isabSence; }
            set { _isabSence = value; }
        }
        private int _orderIndex;

        public int OrderIndex
        {
            get { return _orderIndex; }
            set { _orderIndex = value; }
        }
        private string _createUID;

        public string CreateUID
        {
            get { return _createUID; }
            set { _createUID = value; }
        }
        private DateTime? _createDT;

        public DateTime? CreateDT
        {
            get { return _createDT; }
            set { _createDT = value; }
        }
        private string _updateUID;

        public string UpdateUID
        {
            get { return _updateUID; }
            set { _updateUID = value; }
        }
        private DateTime? _updateDT;
        public DateTime? UpdateDT
        {
            get { return _updateDT; }
            set { _updateDT = value; }
        }
    }
}