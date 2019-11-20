using vhrm.FrameWork.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;
using vhrm.Models;
using vhrm.ViewModels;

namespace vhrm.FrameWork.BusinessLayer
{
    public class bMainMenu
    {
        public static List<MenuFirstLevel> LoadMenu(string strUserId, string strLangId)
        {
            string sqlQuery = "PK_MENU_PROJECT.sp_OPM_MENU_getMenuByUser";
            OracleParameter[] sqlParams = new OracleParameter[2];
            sqlParams[0] = new OracleParameter("pUserID", strUserId);
            sqlParams[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };

            DataTable dt = new DataTable();
            dt = DBHelper.getDataTable_SP(sqlQuery, sqlParams);

            DataTable dt1 = dt.Clone();
            DataTable dt2 = dt.Clone();
            DataTable dt3 = dt.Clone();

            DataRow[] FilterRow = dt.Select("OLDMENULEVEL = 01");
            foreach (DataRow temp in FilterRow)
            {
                dt1.ImportRow(temp);
            }

            FilterRow = dt.Select("OLDMENULEVEL = 02");
            foreach (DataRow temp in FilterRow)
            {
                dt2.ImportRow(temp);
            }
            //dt2.DefaultView.Sort = "MenuSeq";

            FilterRow = dt.Select("OLDMENULEVEL = 03");
            foreach (DataRow temp in FilterRow)
            {
                dt3.ImportRow(temp);
            }

            List<MenuFirstLevel> lstMnLv1 = new List<MenuFirstLevel>();
            foreach (DataRow dtr in dt1.Rows)
            {
                MenuFirstLevel item = new MenuFirstLevel();
                item.menuId = dtr["MenuId"].ToString();
                item.menuName = dtr["MenuNm"].ToString();
                //item.menuParentId = dtr["menuParentId"].ToString();
                item.menuUrl = dtr["URL"].ToString();
                lstMnLv1.Add(item);
            }

            foreach(MenuFirstLevel pr in lstMnLv1)
            {
                pr.menuSecondLevel = new List<MenuSecondLevel>();
                var dtMn = dt2.AsEnumerable()
                                .Where(dtr => dtr.Field<string>("parentid") == pr.menuId).CopyToDataTable();

                foreach(DataRow dtr in dtMn.Rows)
                {
                    MenuSecondLevel item = new MenuSecondLevel();
                    item.menuId = dtr["MenuId"].ToString();
                    item.menuName = dtr["MenuNm"].ToString();
                    item.menuParentId = dtr["parentid"].ToString();
                    item.menuUrl = dtr["URL"].ToString();
                    item.menuPath = pr.menuName + " -> " + item.menuName;
                    pr.menuSecondLevel.Add(item);
                }


                foreach(MenuSecondLevel sl in pr.menuSecondLevel)
                {
                    sl.menuThirdLevel = new List<MenuThirdLevel>();
                    var dtMn3 = dt3.AsEnumerable()
                                    .Where(dtr => dtr.Field<string>("parentid") == sl.menuId).CopyToDataTable();

                    foreach(DataRow dtr3 in dtMn3.Rows)
                    {
                        MenuThirdLevel item = new MenuThirdLevel();
                        item.menuId = dtr3["MenuId"].ToString();
                        item.menuName = dtr3["MenuNm"].ToString();
                        item.menuParentId = dtr3["parentid"].ToString();
                        item.url = dtr3["URL"].ToString();
                        item.menuPath = sl.menuPath + " -> " + item.menuName;
                        sl.menuThirdLevel.Add(item);
                    }
                }
            }
            return lstMnLv1;
        }
    }
}