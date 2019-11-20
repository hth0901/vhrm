using vhrm.FrameWork.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using vhrm.Models;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bAddressCategory
    {
        public static List<PlaceModel> getProvince()
        {
            List<PlaceModel> result = new List<PlaceModel>();
            DataTable dtResult = new DataTable();
            CategoryAccess _access1 = new CategoryAccess();
            dtResult = _access1.getPlace("98", "");

            foreach(DataRow dtr in dtResult.Rows)
            {
                PlaceModel item = new PlaceModel
                {
                    Name = dtr["DATATEXTFIELD"].ToString(),
                    Code = dtr["DATAVALUEFIELD"].ToString()
                };
                result.Add(item);
            }

            return result;
        }

        public static List<PlaceModel> getSubPlace(string cateId, string mPlaceCode)
        {
            List<PlaceModel> result = new List<PlaceModel>();
            DataTable dtCombo = new DataTable();
            string[] values = mPlaceCode.Split('~');
            CategoryAccess _access1 = new CategoryAccess();
            dtCombo = _access1.getPlace(cateId, values[0]);

            foreach (DataRow dtr in dtCombo.Rows)
            {
                PlaceModel item = new PlaceModel
                {
                    Name = dtr["DATATEXTFIELD"].ToString(),
                    Code = dtr["DATAVALUEFIELD"].ToString()
                };
                result.Add(item);
            }

            return result;
        }
    }
}