using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using vhrm.FrameWork.DataAccess;
using vhrm.ViewModels;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bFunction
    {
        public static List<FunctViewModel> getFunctions()
        {
            List<FunctViewModel> dtFunct = new List<FunctViewModel>();
            FunctAccess access = new FunctAccess();
            DataTable dtResult = access.GetFunctions();
            foreach (DataRow dtr in dtResult.Rows)
            {
                FunctViewModel item = new FunctViewModel
                {
                    FUNCCODE = dtr["FUNCCODE"].ToString(),
                    FUNCNAME = dtr["FUNCNAME"].ToString(),
                    FUNCPARENT = dtr["FUNCPARENT"].ToString(),
                    FUNCLEVEL = dtr["FUNCLEVEL"].ToString(),
                    ORDERINDEX = dtr["ORDERINDEX"].ToString(),
                    ISACTIVE = dtr["ISACTIVE"].ToString(),
                    REMARK = dtr["REMARK"].ToString(),
                    CREATE_UID = dtr["CREATE_UID"].ToString(),
                    CREATE_DT = dtr["CREATE_DT"].ToString(),
                    UPDATE_UID = dtr["UPDATE_UID"].ToString(),
                    UPDATE_DT = dtr["UPDATE_DT"].ToString()
                };
                dtFunct.Add(item);
            }
            return dtFunct;
        }
        public static string getNewFunctCode(string functCode)
        {
            FunctAccess access = new FunctAccess();
            DataTable result = access.GetNewFunctCode(functCode);
            if (result.Columns.Contains("'ERROR'"))
            {
                if(result.Rows[0].ItemArray[1].ToString() == "Not exist T_HR_DEPT")
                    return "-1";
            }
            return result.Rows[0]["NEWFUNCCODE"].ToString();
        }
        public static void insertFunction(FunctViewModel functViewModel)
        {
            FunctAccess access = new FunctAccess();
            access.InsertFunctions(functViewModel);
        }
        public static void UpdateFunction(FunctViewModel functViewModel)
        {
            FunctAccess access = new FunctAccess();
            access.UpdateFunctions(functViewModel);
        }
        public static List<FunctViewModel> getFuncts()
        {
            var data = getFunctions();
            return data;
        }
        public static List<FunctViewModel> getFuncts(int? functCode)
        {
            var data = getFunctions();
            List<FunctViewModel> functList = new List<FunctViewModel>();
            var result = data;
            if (functCode != null)
                result = data.Where(p => p.FUNCCODE == functCode.ToString()).ToList();
            else
                result = data.Where(p => p.FUNCPARENT == null || p.FUNCPARENT == string.Empty).ToList();
            foreach (FunctViewModel org in result)
            {
                functList.Add(Recursive(org, data));
            }
            return functList;
        }
        public static FunctViewModel Recursive(FunctViewModel funct, List<FunctViewModel> functList)
        {

            if (functList.Where(c => c.FUNCPARENT == funct.FUNCCODE).Count() < 1)
            {
                return funct;
            }
            else
            {
                List<FunctViewModel> newList = new List<FunctViewModel>();
                foreach (FunctViewModel ca in functList.Where(c => c.FUNCPARENT == funct.FUNCCODE))
                {
                    newList.Add(Recursive(ca, functList));
                }
                funct.FunctViewModels = newList;
                return funct;
            }
        }
    }
}