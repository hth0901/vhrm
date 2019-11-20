using System.Data;
using vhrm.FrameWork.Utility;
using System.Data.SqlClient;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class GridAccess
    {
        #region Master
        public DataTable GetDataForComboBox(int categoryId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("CategoryId", categoryId);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_DICTIONARY.sp_GetDataForComboBox", parameters);
        }

        public DataSet LoadData(string pageId, string controlType)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("@PageId", pageId);
            parameters[1] = new OracleParameter("@ControlType", controlType);
            return DBHelper.getDataSet_SP("sp_SettingQuery_Qry", parameters);
        }

        public bool SaveData(QuerySettingEntity entity)
        {
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("@PageId", entity.PageId);
            parameters[1] = new OracleParameter("@ReportFile", entity.ReportFile);
            parameters[2] = new OracleParameter("@JumpPageId", entity.JumpPageId);
            parameters[3] = new OracleParameter("@JumpKey", entity.JumpKey);

            return DBHelper.ExecuteNonQuery_SP("sp_SettingQuery_Save", parameters);
        }

        public DataTable GetMasterData(string pageId, string controlType)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("@PageId", pageId);
            parameters[1] = new OracleParameter("@ControlType", controlType);
            return DBHelper.getDataTable_SP("sp_QuerySearch_Qry", parameters);
        }

        public bool SaveMaster(string workingtag, QueryMasterEntity entity)
        {
            OracleParameter[] parameters = new OracleParameter[11];
            parameters[0] = new OracleParameter("@WorkingTag", workingtag);
            parameters[1] = new OracleParameter("@PageId", entity.PageId);
            parameters[2] = new OracleParameter("@ControlType", entity.ControlType);
            parameters[3] = new OracleParameter("@PositionLeft", entity.PositionLeft);
            parameters[4] = new OracleParameter("@PositionTop", entity.PositionTop);
            parameters[5] = new OracleParameter("@Width", entity.Width);
            parameters[6] = new OracleParameter("@MaxLength", entity.MaxLength);
            parameters[7] = new OracleParameter("@MajorCode", entity.MajorCode);
            parameters[8] = new OracleParameter("@DefaultValue", entity.DefaultValue);
            parameters[9] = new OracleParameter("@DictionaryCode", entity.DictionaryCode);
            parameters[10] = new OracleParameter("@ItemIndex", entity.ItemIndex);
            return DBHelper.ExecuteNonQuery_SP("sp_QueryMaster_Save", parameters);
        }
        #endregion

        #region Sheets
        public DataTable GetSheetData(string pageId)
        {
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("@PageId", pageId);
            return DBHelper.getDataTable_SP("sp_QuerySheet_Qry", parameters);
        }

        public bool SaveSheet(string workingtag, QuerySheetEntity entity)
        {
            OracleParameter[] parameters = new OracleParameter[10];
            parameters[0] = new OracleParameter("@WorkingTag", workingtag);
            parameters[1] = new OracleParameter("@PageId", entity.PageId);
            parameters[2] = new OracleParameter("@ColumnName", entity.ColumnName);
            parameters[3] = new OracleParameter("@ColumnType", entity.ColumnType);
            parameters[4] = new OracleParameter("@FormatColumn", entity.FormatColumn);
            parameters[5] = new OracleParameter("@ColumnWidth", entity.ColumnWidth);
            parameters[6] = new OracleParameter("@BackColor", entity.BackColor);
            parameters[7] = new OracleParameter("@ForeColor", entity.ForeColor);
            parameters[8] = new OracleParameter("@DictionaryCode", entity.DictionaryCode);
            parameters[9] = new OracleParameter("@OrderIndex", entity.OrderIndex);
            return DBHelper.ExecuteNonQuery_SP("sp_QuerySheet_Save", parameters);
        }
        #endregion
    }
}