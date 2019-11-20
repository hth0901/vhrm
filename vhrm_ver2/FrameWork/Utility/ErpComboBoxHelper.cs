using System.Data;
using vhrm.FrameWork.DataAccess;
//using Telerik.Web.UI;

namespace vhrm.FrameWork.Utility
{
    public class ErpComboBoxHelper
    {
        /*
        public static void LoadComboBoxDataFromERP(object sender, string categoryId)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            comboBox.DataSource = categoryAccess.GetComboBoxDataFromERP(categoryId, "");
            comboBox.DataBind();
        }
        public static void LoadComboBoxDataFilterFromERP(object sender, string categoryId)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            DataTable dataTable = categoryAccess.GetComboBoxDataFromERP(categoryId, "");
            DataRow dataRow = dataTable.NewRow();
            dataTable.Rows.InsertAt(dataRow, 0);
            comboBox.DataSource = dataTable;
            comboBox.DataBind();
        }
        public static void LoadComboBoxDataFilter(object sender, string categoryId)
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

        public static void LoadComboBoxData(object sender, string categoryId, string parentId)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            CategoryAccess categoryAccess = new CategoryAccess();
            comboBox.DataSource = categoryAccess.GetComboBoxData(categoryId, parentId);
            comboBox.DataBind();
        }

        public static void LoadComboBoxDataFilter(object sender, string categoryId, string parentId)
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
        */
    }
}