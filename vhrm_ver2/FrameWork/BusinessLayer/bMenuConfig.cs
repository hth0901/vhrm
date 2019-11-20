using vhrm.FrameWork.DataAccess;
using vhrm.FrameWork.Entity;
using vhrm.FrameWork.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bMenuConfig
    {
        public static List<eMenuItem> getAllMenu()
        {
            List<eMenuItem> lstResult = new List<eMenuItem>();
            DataTable dtResult = new DataTable();
            dtResult = MenuTreeAccess.GetAll("en");
            foreach(DataRow dtr in dtResult.Rows)
            {
                eMenuItem item = new eMenuItem();
                item.MENUID = dtr["MENUID"].ToString();
                item.MENUNAME = dtr["MENUNAME"].ToString();
                item.SEQ = dtr["SEQ"].ToString();
                item.FORMCODE = dtr["FORMID"].ToString();
                item.MOTHERID = dtr["MOTHERID"].ToString();
                item.ISACTIVE = dtr["ISACTIVE"].ToString();
                item.ISLEAF = dtr["ISLEAF"].ToString();
                lstResult.Add(item);
            };
            return lstResult;
        }

        public static MenuTreeEntity getMenuDetail(string menu_id)
        {
            MenuTreeEntity result = new MenuTreeEntity();
            result = MenuTreeAccess.GetByMenuID(menu_id);
            return result;
        }
    }
}