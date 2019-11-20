using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vhrm.FrameWork.DataAccess;
//using Telerik.Web.UI;

namespace vhrm.FrameWork.Utility
{
    public class LanguageHelper
    {
        public string PageId { get; set; }
        public string Language { get; set; }
        public MasterPage MasterPage { get; set; }

        public DataSet dataSetLanguage;
        /*

        /// <summary>
        /// Set language for master page with one  grid one page
        /// </summary>
        public void SetLanguageMasterControl()
        {
            if (HttpContext.Current.Cache[PageId] == null)
            {
                LanguageAccess languageAccess = new LanguageAccess();
                dataSetLanguage = languageAccess.getLanguageForPage(Language, PageId);
                HttpContext.Current.Cache[PageId + Language] = dataSetLanguage;
            }
            else
                dataSetLanguage = (DataSet)HttpContext.Current.Cache[PageId + Language];

            if (dataSetLanguage.Tables.Count > 0)
                SetLanguageForControls(dataSetLanguage.Tables[0]);
        }

        /// <summary>
        /// Set language for master page with one  grid one page
        /// </summary>
        /// <param name="radGrid">Id of grid</param>
        public void SetLanguageMasterControl(RadGrid radGrid)
        {
            if (HttpContext.Current.Cache[PageId + Language]  == null)
            {
                LanguageAccess languageAccess = new LanguageAccess();
                dataSetLanguage = languageAccess.getLanguageForPage(Language, PageId);
                HttpContext.Current.Cache[PageId + Language] = dataSetLanguage;
            }
            else
                dataSetLanguage = (DataSet)HttpContext.Current.Cache[PageId + Language];

            if (dataSetLanguage.Tables.Count > 0)
                SetLanguageForControls(dataSetLanguage.Tables[0]);

            if (dataSetLanguage.Tables.Count > 1)
                SetLanguageForGird(dataSetLanguage.Tables[1], radGrid);

        }
        public void SetLanguageMasterTab(RadTabStrip radTabStrip)
        {
            if (HttpContext.Current.Cache[PageId + Language] == null)
            {
                LanguageAccess languageAccess = new LanguageAccess();
                dataSetLanguage = languageAccess.getLanguageForPage(Language, PageId);
                HttpContext.Current.Cache[PageId + Language] = dataSetLanguage;
            }
            else
                dataSetLanguage = (DataSet)HttpContext.Current.Cache[PageId + Language];
            if (dataSetLanguage.Tables[3].Rows.Count > 0)
                SetLanguageForTab(dataSetLanguage.Tables[3], radTabStrip);

        }

        /// <summary>
        /// Set language for master page with two  grid on page
        /// </summary>
        /// <param name="radGrid1">Id of first grid</param>
        /// <param name="radGrid2">Id of second grid</param>
        public void SetLanguageMasterControl(RadGrid radGrid1, RadGrid radGrid2)
        {
            if (HttpContext.Current.Cache[PageId + Language] == null)
            {
                LanguageAccess languageAccess = new LanguageAccess();
                dataSetLanguage = languageAccess.getLanguageForPage(Language, PageId);
                HttpContext.Current.Cache[PageId + Language] = dataSetLanguage;
            }
            else
                dataSetLanguage = (DataSet)HttpContext.Current.Cache[PageId + Language];

            if (dataSetLanguage.Tables.Count > 0)
                SetLanguageForControls(dataSetLanguage.Tables[0]);

            if (dataSetLanguage.Tables.Count > 1)
            {
                SetLanguageForGird(dataSetLanguage.Tables[1], radGrid1);
                SetLanguageForGird(dataSetLanguage.Tables[1], radGrid2);
            }
        }

        /// <summary>
        /// Set language for master page with two  grid on page
        /// </summary>
        /// <param name="radGrid1">Id of first grid</param>
        /// <param name="radGrid2">Id of second grid</param>
        /// <param name="radGrid3">Id of third grid</param>
        public void SetLanguageMasterControl(RadGrid radGrid1, RadGrid radGrid2, RadGrid radGrid3)
        {
            if (HttpContext.Current.Cache[PageId + Language] == null)
            {
                LanguageAccess languageAccess = new LanguageAccess();
                dataSetLanguage = languageAccess.getLanguageForPage(Language, PageId);
                HttpContext.Current.Cache[PageId + Language] = dataSetLanguage;
            }
            else
                dataSetLanguage = (DataSet)HttpContext.Current.Cache[PageId + Language];

            if (dataSetLanguage.Tables.Count > 0)
                SetLanguageForControls(dataSetLanguage.Tables[0]);

            if (dataSetLanguage.Tables.Count > 1)
            {
                SetLanguageForGird(dataSetLanguage.Tables[1], radGrid1);
                SetLanguageForGird(dataSetLanguage.Tables[1], radGrid2);
                SetLanguageForGird(dataSetLanguage.Tables[1], radGrid3);
            }
        }

        /// <summary>
        /// Set language for master conntrols
        /// </summary>
        /// <param name="dataTable"></param>
        private void SetLanguageForControls(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string controlId = dataTable.Rows[i]["ControlID"].ToString().Trim();
                if (controlId != "")
                    if (MasterPage != null)
                    {
                        dynamic obj = MasterPage.FindControl("ContentPlaceHolder1").FindControl(controlId) as Label;
                        if (obj != null)
                        {
                            obj.Text = dataTable.Rows[i]["DicName"].ToString();
                            if (dataTable.Rows[i]["require"].ToString() == "1")
                            {
                                Label control = (MasterPage.FindControl("ContentPlaceHolder1").FindControl(controlId) as Label);
                                control.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
            }
        }

        /// <summary>
        /// Set language for grid
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="radGrid"></param>
        private void SetLanguageForGird(DataTable dataTable, RadGrid radGrid)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int j = 0; j < radGrid.Columns.Count; j++)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string columnName = dataTable.Rows[i]["ControlID"].ToString().Trim();
                        if (radGrid.Columns[j].UniqueName == columnName)
                        {
                            radGrid.Columns.FindByUniqueName(columnName).HeaderText = dataTable.Rows[i]["DicName"].ToString();
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Set language for Tab
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="radGrid"></param>
        /// <summary>
        private void SetLanguageForTab(DataTable dataTable, RadTabStrip tabStrip)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                 for (int i = 0; i < dataTable.Rows.Count; i++)
                 {
                     RadTab tab = tabStrip.FindTabByValue(dataTable.Rows[i]["ControlID"].ToString());
                     if (tab != null)
                       tab.Text = dataTable.Rows[i]["DICName"].ToString();
                  
                    
                 }
              }
        }

        /// Set language for nestedview
        /// </summary>
        /// <param name="item"></param>
        public void SetLanguageForGirdDetail(GridItem item)
        {
            if (dataSetLanguage.Tables.Count < 3)
                return;
            DataTable dataTable = dataSetLanguage.Tables[2];
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if ((item.FindControl(dataTable.Rows[i]["ControlID"].ToString().Trim()) as Label) != null)
                    {
                        (item.FindControl(dataTable.Rows[i]["ControlID"].ToString().Trim()) as Label).Text = dataTable.Rows[i]["DicName"].ToString();
                        //set color for control
                        if (dataTable.Rows[i]["require"].ToString() == "1")
                        {
                            Label control = (item.FindControl(dataTable.Rows[i]["ControlID"].ToString().Trim()) as Label);
                            control.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Set language for edit item
        /// </summary>
        /// <param name="item"></param>
        public void SetLanguageForGirdDetail(GridEditableItem item)
        {
            if (dataSetLanguage.Tables.Count < 3)
                return;
            DataTable dataTable = dataSetLanguage.Tables[2];
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if ((item.FindControl(dataTable.Rows[i]["ControlID"].ToString().Trim()) as Label) != null)
                    {
                        (item.FindControl(dataTable.Rows[i]["ControlID"].ToString().Trim()) as Label).Text = dataTable.Rows[i]["DicName"].ToString();
                        //set color for control
                        if (dataTable.Rows[i]["require"].ToString() == "1")
                        {
                            Label control = (item.FindControl(dataTable.Rows[i]["ControlID"].ToString().Trim()) as Label);
                            control.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }
        */
    }
}