using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace vhrm.FrameWork.Entity
{
    public class ItemSalaryRegistryVEntity
    {
        public string p_UID { get; set; }
        public string p_ITEMID { get; set; }
        public string p_VER_ID { get; set; }
        public string p_VER_IDtmp { get; set; }
        public int p_ISACTIVE { get; set;}
        public bool Isedit { get; set; }
        public DataTable createdataTable()
        {
            DataTable dataTable =new DataTable();
            dataTable.Columns.Add("p_ITEMID");
            dataTable.Columns.Add("p_VER_ID");
            dataTable.Columns.Add("p_ISACTIVE");
            dataTable.Columns.Add("p_UID");
            return dataTable;
        } 

    }
}