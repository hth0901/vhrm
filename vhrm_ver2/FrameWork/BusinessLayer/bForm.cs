using vhrm.FrameWork.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bForm
    {
        public static List<eForm> listFormFromDatatable(DataTable dtForm)
        {
            List<eForm> result = new List<eForm>();
            foreach(DataRow dtr in dtForm.Rows)
            {
                eForm item = new eForm();
                item.FORM_ID = dtr["ID"].ToString();
                item.FORM_CODE = dtr["FORMID"].ToString();
                item.FORM_NAME = dtr["FORMNAME"].ToString();
                item.DICTIONARY_ID = dtr["DICTIONARYID"].ToString();
                item.FILE_PATH = dtr["FILEPATH"].ToString();
                item.MODULE_ID = dtr["MODULEID"].ToString();
                result.Add(item);
            }
            return result;
        }
    }
}