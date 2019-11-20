using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class OPM_SQLAcesS
    {
        public static DataSet Getalldata_combo(string param)
        {
            string squery = "PKOPM_SQL.getdata";
            OracleParameter[] parameters = new OracleParameter[14];
            parameters[0] = new OracleParameter("param", param);
            parameters[1] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[2] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[3] = new OracleParameter("T_TABLE3", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[4] = new OracleParameter("T_TABLE4", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[5] = new OracleParameter("T_TABLE5", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[6] = new OracleParameter("T_TABLE6", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[7] = new OracleParameter("T_TABLE7", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[8] = new OracleParameter("T_TABLE8", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[9] = new OracleParameter("T_TABLE9", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[10] = new OracleParameter("T_TABLE10", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[11] = new OracleParameter("T_TABLE11", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[12] = new OracleParameter("T_TABLE12", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[13] = new OracleParameter("T_TABLE13", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataSet_SP(squery, parameters);
            //string SQL = DBHelper.GetName(squery, parameters);
            //return DBHelper.getDataTable_Text(SQL, null);

        }
        public static DataSet Getqueryselect()
        {
            string squery = "PKOPM_SQL.SP_GET_NAME_OPMSQL";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataSet_SP(squery, parameters);
            //string SQL = DBHelper.GetName(squery, parameters);
            //return DBHelper.getDataTable_Text(SQL, null);

        }
        public static string GetSelect(int sql_no)
        {
            string Result = "";
            //get from catch by Van
            DataTable dt = new DataTable();

            if (HttpContext.Current.Cache[vhrm.FrameWork.Utility.ToolHelper.CacheSql] != null)
            {
                dt = (DataTable)HttpContext.Current.Cache[vhrm.FrameWork.Utility.ToolHelper.CacheSql];

            }
            else
            {
                //get from data by Van
                DataSet ds = new DataSet();
                ds = Getqueryselect();
                dt = ds.Tables[0];
                HttpContext.Current.Cache[vhrm.FrameWork.Utility.ToolHelper.CacheSql] = dt;
            }
            DataView dv = dt.DefaultView;
            dv.RowFilter = "SQL_NO =" + sql_no;
            if (dv.Count == 1)
                Result = Result + dv[0][2].ToString();

            return Result;
        }
        public static DataTable EX_Select(int sql_no)
        {
            string sql = GetSelect(sql_no);
            return DBHelper.getDataTable_Text(sql, null);
        }
        public static DataTable EX_Select(int sql_no,string dk1)
        {
            string sql = GetSelect(sql_no).Replace("{0}", "'" + dk1 + "'");
            return DBHelper.getDataTable_Text(sql, null);
        }
        public static DataTable EX_Select(int sql_no, string dk1,string dk2)
        {
            string sql = GetSelect(sql_no).Replace("{0}", "'" + dk1 + "'");
            sql = sql.Replace("{1}", "'" + dk2 + "'");
            return DBHelper.getDataTable_Text(sql, null);
        }
        public static DataTable EX_Select(int sql_no, string dk1, string dk2,string dk3)
        {
            string sql = GetSelect(sql_no).Replace("{0}", "'" + dk1 + "'");
            sql = sql.Replace("{1}", "'" + dk2 + "'");
            sql = sql.Replace("{2}", "'" + dk3 + "'");
            return DBHelper.getDataTable_Text(sql, null);
        }
        public static DataTable getdata_treeviewclick(int sql_no, string dk1, string dk2, string dk3,string dk4, string dk5)
        {
            string sql = GetSelect(sql_no).Replace("{0}", "'" + dk1 + "'");
            sql = sql.Replace("{1}", "'" + dk2 + "'");
            sql = sql.Replace("{2}", "'" + dk3 + "'");
            sql = sql.Replace("{3}", "'" + dk4 + "'");
            sql = sql.Replace("{4}", "'" + dk5 + "'");
            return DBHelper.getDataTable_Text(sql, null);
        }

    }
}