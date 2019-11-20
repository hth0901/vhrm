using System.Data;
using vhrm.FrameWork.DataAccess;
//using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System;

namespace vhrm.FrameWork.Utility
{
    public class ComboBoxHelper
    {
        /*
        public static void LoadComboBoxData(object sender, int categoryId)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            comboBox.DataSource = categoryAccess.GetComboBoxData(categoryId, "");
            comboBox.DataBind();
        }
        public static void LoadComboBoxData(object sender, int categoryId,bool isTop)
        {
            CategoryAccess categoryAccess = new CategoryAccess();
            RadComboBox comboBox = (RadComboBox)sender;
            DataTable dtData = categoryAccess.GetComboBoxData(categoryId, "");             
            if (isTop)
            {
                 
                DataRow dr = dtData.NewRow();
                dr["DataValueField"] = "";
                dr["DataTextField"] = "";                
                dtData.Rows.InsertAt(dr, 0);
            }
            comboBox.DataSource = dtData;
            comboBox.DataBind();
        }
        /// <summary>
        /// level salary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="categoryId"></param>
        public static void LoadComboBoxDataLevel(object sender, int categoryId)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            comboBox.DataSource = LevelSaralyAccess.GetComboBoxData(categoryId);
            comboBox.DataBind();
        }
        public static void LoadComboBoxData(object sender, int categoryId,string parentId, string pLoginID)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            
            comboBox.DataSource = categoryAccess.GetComboBoxData(categoryId, parentId,pLoginID);
            comboBox.DataBind();
        }
        public static void LoadDropdownData(object sender, int categoryId, string parentId, string pLoginID)
        {
            DropDownList comboBox = (DropDownList)sender;
            CategoryAccess categoryAccess = new CategoryAccess();

            comboBox.DataSource = categoryAccess.GetComboBoxData(categoryId, parentId, pLoginID);
            comboBox.DataBind();
        }
        public static void LoadDropdownDataFilter(object sender, int categoryId, string parentId, string pLoginID)
        {
            DropDownList comboBox = (DropDownList)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            DataTable dataTable = categoryAccess.GetComboBoxData(categoryId, parentId, pLoginID);
            DataRow dataRow = dataTable.NewRow();
            dataRow["DataTextField"] = "";
            dataRow["DataValueField"] = "";
            dataTable.Rows.InsertAt(dataRow, 0);

            comboBox.DataSource = dataTable;
            comboBox.DataBind();
        }
        public static void LoadDropdownNoDataBindDataFilter(object sender, int categoryId, string parentId, string pLoginID)
        {
            DropDownList comboBox = (DropDownList)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            DataTable dataTable = categoryAccess.GetComboBoxData(categoryId, parentId, pLoginID);
            DataRow dataRow = dataTable.NewRow();
            dataRow["DataTextField"] = "";
            dataRow["DataValueField"] = "";
            dataTable.Rows.InsertAt(dataRow, 0);

            comboBox.DataSource = dataTable;
            
        }
        //Get dropdownlist Formular and dropDownlist Subcode
        public static void loadDropDownListSubCode(object sender, int categoryId, string subCode, string parentId, string pLoginID)
        {
            DropDownList comboBox = (DropDownList)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            DataTable dataTable = categoryAccess.GetDropDownListFormularSubCode(categoryId, subCode);
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);

            comboBox.DataSource = dataTable;
            comboBox.DataBind();
        }
        public static void loadDropDownListNoBindSubCode(object sender, int categoryId, string subCode, string parentId, string pLoginID)
        {
            DropDownList comboBox = (DropDownList)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            DataTable dataTable = categoryAccess.GetDropDownListFormularSubCode(categoryId, subCode);
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            comboBox.DataSource = dataTable;
        
        }

        public static void LoadComboBoxDataFilter(object sender, int categoryId)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            DataTable dataTable = categoryAccess.GetComboBoxData(categoryId, "");
            DataRow dataRow = dataTable.NewRow();
            dataRow["DataTextField"] = "";
            dataRow["DataValueField"] = "";
            dataTable.Rows.InsertAt(dataRow, 0);
            comboBox.DataSource = dataTable;
        }
        */
        /* update by Mr.Mao*/
        /*public static void LoadComboBoxSkindStaff(object sender, int categoryId)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            DataTable dataTable = categoryAccess.GetComboBoxSkindStaff(categoryId, "");
            DataRow dataRow = dataTable.NewRow();
            dataRow["DataTextField"] = "";
            dataRow["DataValueField"] = "";
            dataTable.Rows.InsertAt(dataRow, 0);
            comboBox.DataSource = dataTable;
        }*/
        /*End update*/

        /*
        public static void LoadComboBoxData(object sender, int categoryId, string parentId)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            comboBox.DataSource = categoryAccess.GetComboBoxData(categoryId, parentId);
            comboBox.DataBind();
        }

        public static void LoadComboBoxDataFilter(object sender, int categoryId, string parentId)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            DataTable dataTable = categoryAccess.GetComboBoxData(categoryId, parentId);
            DataRow dataRow = dataTable.NewRow();
            dataRow["DataTextField"] = "";
            dataRow["DataValueField"] = 0;
            dataTable.Rows.InsertAt(dataRow, 0);
            comboBox.DataSource = dataTable;
        }
        public static void BindCombohelp(RadComboBox combo, string CategoryID, DataTable dtData, bool isrowempty)
        {
            try
            {
                while (dtData.Rows[0]["CategoryID"].ToString() == "0")
                    dtData.Rows.RemoveAt(0);
                if (isrowempty == true)
                {
                    DataRow dr = dtData.NewRow();
                    dr["DataValueField"] = ""; dr["DataTextField"] = ""; dr["CategoryID"] = "0";
                    dtData.Rows.InsertAt(dr, 0);
                }

                DataView dv = dtData.DefaultView;
                dv.RowFilter = "CategoryID = " + CategoryID + " OR CategoryID = 0";
                DataTable dt = dv.ToTable();
                combo.DataSource = dt;
                combo.DataBind();
            }
            catch (Exception e)
            {

            }
        }

        //Dat.vdt add 2013-04-11
        public static void BindCombo(DropDownList combo, string CategoryID, DataTable dtData, bool isrowempty)
        {
            try
            {
                while (dtData.Rows[0]["CategoryID"].ToString() == "0")
                    dtData.Rows.RemoveAt(0);
                if (isrowempty == true)
                {
                    DataRow dr = dtData.NewRow();
                    dr["DataValueField"] = ""; dr["DataTextField"] = ""; dr["CategoryID"] = "0";
                    dtData.Rows.InsertAt(dr, 0);
                }

                DataView dv = dtData.DefaultView;
                dv.RowFilter = "CategoryID = " + CategoryID + " OR CategoryID = 0";
                DataTable dt = dv.ToTable();
                combo.DataSource = dt;
                combo.DataBind();
            }catch(Exception e){
            
            }
        }
      
        public static void ComboboxFixFillData(DropDownList pCombo, string pCondition, DataTable dt)
        {
            DataRow[] foundRows;
            foundRows = dt.Select("DataValueField = '" + pCondition + "'");
            if (foundRows.Length > 0)
                pCombo.SelectedValue = pCondition;
            else
                pCombo.SelectedValue = "";

            if (pCombo.SelectedValue == "")
                pCombo.Enabled = true;
        }
        public static void BindComboWithSubCode(DropDownList combo, string CategoryID, DataTable dtData, bool isrowempty)
        {
            while (dtData.Rows[0]["CategoryID"].ToString() == "0")
                dtData.Rows.RemoveAt(0);
            if (isrowempty == true)
            {
                DataRow dr = dtData.NewRow();
                dr["DataValueField"] = ""; dr["DataTextField"] = ""; dr["CategoryID"] = "0"; dr["DataValueWithSubCode"] = "";
                dtData.Rows.InsertAt(dr, 0);
            }

            DataView dv = dtData.DefaultView;
            dv.RowFilter = "CategoryID = " + CategoryID + " OR CategoryID = 0";
            DataTable dt = dv.ToTable();
            combo.DataTextField = "DataTextField";
            combo.DataValueField = "DataValueWithSubCode";
            combo.DataSource = dt;
            combo.DataBind();
        }
        public static void BindComboCorp(DropDownList combo, string DeptLevel, DataTable dtData, bool isrowempty)
        {


            DataView dv = dtData.DefaultView;
            dv.RowFilter = "DeptLevel = '" + DeptLevel + "'";
            //ParentId = '" + ParentId + "' AND 
            DataTable dt = dv.ToTable();

            if (isrowempty == true)
            {
                DataRow dr = dt.NewRow();
                dr["DepartmentId"] = ""; dr["DepartmentNm"] = ""; dr["ParentId"] = ""; dr["DeptLevel"] = "";
                dt.Rows.InsertAt(dr, 0);
            }

            dt.DefaultView.Sort = "DepartmentNm ASC";
            combo.DataSource = dt;
            combo.DataBind();
        }

        */
    }
}