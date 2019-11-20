using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class aLocationAccess
    {
        public static DataTable insertNewDistrict(eLocationInfo _location)
        {
            OracleParameter[] _param = new OracleParameter[7];
            _param[0] = new OracleParameter("PWARD_CODE", _location.ward_code);
            _param[1] = new OracleParameter("PDISTRICT_CODE", _location.district_code);
            _param[2] = new OracleParameter("PPROVINCE_CODE", _location.province_code);
            _param[3] = new OracleParameter("PWARD_NAME", OracleType.NVarChar) { Value = _location.ward_name };
            _param[4] = new OracleParameter("PDISTRICT_NAME", OracleType.NVarChar) { Value = _location.district_name };
            _param[5] = new OracleParameter("PPROVINCE_NAME", OracleType.NVarChar) { Value = _location.province_name };
            _param[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dtResult = DBHelper.getDataTable_SP("SP_INSERT_NEW_DISTRICT_WARD", _param);
            return dtResult;
        }

        public static DataTable insertNewWard(eLocationInfo _location)
        {
            OracleParameter[] _param = new OracleParameter[7];
            _param[0] = new OracleParameter("PWARD_CODE", _location.ward_code);
            _param[1] = new OracleParameter("PDISTRICT_CODE", _location.district_code);
            _param[2] = new OracleParameter("PPROVINCE_CODE", _location.province_code);
            _param[3] = new OracleParameter("PWARD_NAME", OracleType.NVarChar) { Value = _location.ward_name };
            _param[4] = new OracleParameter("PDISTRICT_NAME", OracleType.NVarChar) { Value = _location.district_name };
            _param[5] = new OracleParameter("PPROVINCE_NAME", OracleType.NVarChar) { Value = _location.province_name };
            _param[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dtResult = DBHelper.getDataTable_SP("SP_INSERT_NEW_WARD", _param);
            return dtResult;
        }
    }
}