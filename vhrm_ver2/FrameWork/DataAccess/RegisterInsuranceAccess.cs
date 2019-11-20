/*
 * Author: Tran Cong Tho
 * Create Date: 10/21/2013
 * Desc: Access for Register Social and Health Book
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace vhrm.FrameWork.DataAccess
{
    public class RegisterInsuranceAccess
    {
        //Create Template Table for Register Insurance
        public DataTable initTemplateTable()
        {
            DataTable dtData = new DataTable();
            DataColumn[] keys = new DataColumn[1];
            DataColumn column = new DataColumn { DataType = Type.GetType("System.String"), ColumnName = "SYS_EMPID" };
            dtData.Columns.Add(column);
            keys[0] = column;
            dtData.Columns.Add("EMPID");
            dtData.Columns.Add("EMPNAME");
            dtData.Columns.Add("DEPT");
            dtData.Columns.Add("SINO");
            dtData.Columns.Add("SIDATE");
            dtData.Columns.Add("HINO");
            dtData.Columns.Add("HIDATE");
            dtData.Columns.Add("HIPLACE");
            dtData.Columns.Add("REMARK");
            dtData.Columns.Add("RESIDENCE");
            dtData.Columns.Add("IS_COMFIRMED");
            dtData.Columns.Add("COMFIRM_UID");
            dtData.Columns.Add("CONFIRM_DT");
            dtData.Columns.Add("IS_COMPLETED");
            dtData.Columns.Add("COMPLETE_UID");
            dtData.Columns.Add("COMPLETE_DT");
            dtData.Columns.Add("F_MONTH");
            dtData.Columns.Add("F_PHASE");
            dtData.Columns.Add("GENDER");

            dtData.PrimaryKey = keys;
            return dtData;
        }
    }
}