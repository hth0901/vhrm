using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;
namespace vhrm.FrameWork.DataAccess
{
    public class CompanyInfoAccess
    {
        public static DataTable Load(string pCorporation)
        {
            string query = "PKHR_COMPANYINFO.sp_HR_LOAD_COMPANYINFO";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pCorporation", pCorporation);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
           return DBHelper.getDataTable_SP(query, parameters);
        }
        
        public static DataTable Save(string Corporation,  string corporationName, string corporationEN, string RegisteredNo , string CorporationNo ,string InsuranceCode , string Tel , string Representative,string Nationality,
            string Position ,string PassportID ,string IssuedOn,string IssuedAt,string Address1VN,string Address1EN,
            string Address2VN, string Address2EN, string ProvinceCD, string pGroupSalary, string UID, string StopWorker, string ResignedPool, string Matenmity, string pHRManager, string IsoCode, int pSalaryDate, int confirmDailyWork
            //add by ndhung 2017.07.18 -> thêm thông tin địa chỉ và nơi duyệt giấy phép
            , string approveby, string approvedbyen, string approvedate, string readdress
            )
        {
            string spName = "PKHR_COMPANYINFO.SP_SAVE_COMPANYINFO";
            OracleParameter[] parameters = new OracleParameter[32];
            parameters[0] = new OracleParameter("pCorporation", Corporation);
            parameters[1] = new OracleParameter("pCorporationName", corporationName); 
            parameters[2] = new OracleParameter("pCorporationEN",  corporationEN); 
            parameters[3] = new OracleParameter("pRegisteredNo", RegisteredNo); 
            parameters[4] = new OracleParameter("pCorporationNo", CorporationNo);
            parameters[5] = new OracleParameter("pInsuranceCode", InsuranceCode); 
            parameters[6] = new OracleParameter("pTel", Tel); 
            parameters[7] = new OracleParameter("pRepresentative", Representative); 
            parameters[8] = new OracleParameter("pNationality", Nationality); 
            parameters[9] = new OracleParameter("pPosition",  Position); 
            parameters[10] = new OracleParameter("pPassportID", PassportID); 
            parameters[11] = new OracleParameter("pIssuedDate", IssuedOn);
            parameters[12] = new OracleParameter("pInsuedPlace", IssuedAt); 
            parameters[13] = new OracleParameter("pAddress1VN", Address1VN); 
            parameters[14] = new OracleParameter("pAddress1EN", Address1EN);
            parameters[15] = new OracleParameter("pAddress2VN", Address2VN); 
            parameters[16] = new OracleParameter("pAddress2EN", Address2EN);
            parameters[17] = new OracleParameter("pProvinceCD", ProvinceCD);
            parameters[18] = new OracleParameter("pGroupSalary", pGroupSalary); 
            parameters[19] = new OracleParameter("pUID",  pGroupSalary);
            parameters[20] = new OracleParameter("pStopWorker", StopWorker);
            parameters[21] = new OracleParameter("pResigned",  ResignedPool);
            parameters[22] = new OracleParameter("pMaternity", Matenmity);
            parameters[23] = new OracleParameter("pHRManager", pHRManager);
            parameters[24] = new OracleParameter("pSalaryDate", pSalaryDate);
            parameters[25] = new OracleParameter("pConfirmDailyWork", confirmDailyWork);

            parameters[26] = new OracleParameter("PAPPROVED_BY", approveby);
            parameters[27] = new OracleParameter("PAPPROVED_BY_EN", approvedbyen);
            parameters[28] = new OracleParameter("PAPPROVED_DATE", approvedate);
            parameters[29] = new OracleParameter("PREPRESENTATIVE_ADDRESS", readdress);

            parameters[30] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[31] = new OracleParameter("pIsoCode", IsoCode);
            return DBHelper.getDataTable_SP(spName, parameters);
            
        }
        public static DataTable Update(string Corporation, string corporationName, string corporationEN, string RegisteredNo, string CorporationNo, string InsuranceCode, string Tel, string Representative, string Nationality,
             string Position, string PassportID, string IssuedOn, string IssuedAt, string Address1VN, string Address1EN, string Address2VN, string Address2EN, string ProvinceCD, string UID)
        {
            string spName = "PKHR_COMPANYINFO.sp_HR_UPDATE_COMPANYINFO";
            OracleParameter[] parameters = new OracleParameter[20];
            parameters[0] = new OracleParameter("pCorporation", Corporation ?? "");
            parameters[1] = new OracleParameter("pCorporationName", corporationName ?? "");
            parameters[2] = new OracleParameter("pCorporationEN", corporationEN ?? "");
            parameters[3] = new OracleParameter("pRegisteredNo", RegisteredNo ?? "");
            parameters[4] = new OracleParameter("pCorporationNo", CorporationNo);
            parameters[5] = new OracleParameter("pInsuranceCode", InsuranceCode);
            parameters[6] = new OracleParameter("pTel", Tel);
            parameters[7] = new OracleParameter("pRepresentative", Representative);
            parameters[8] = new OracleParameter("pNationality", Nationality);
            parameters[9] = new OracleParameter("pPosition", Position);
            parameters[10] = new OracleParameter("pPassportID", PassportID);
            parameters[11] = new OracleParameter("pIssuedDate", IssuedOn);
            parameters[12] = new OracleParameter("pInsuedPlace", IssuedAt);
            parameters[13] = new OracleParameter("pAddress1VN", Address1VN);

            parameters[14] = new OracleParameter("pAddress1EN", Address1EN);
            parameters[15] = new OracleParameter("pAddress2VN", Address2VN);
            parameters[16] = new OracleParameter("pAddress2EN", Address2EN);
            parameters[17] = new OracleParameter("pProvinceCD", OracleType.NVarChar) { Value = ProvinceCD ?? "" };
            parameters[18] = new OracleParameter("pUID", UID);
            parameters[19] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(spName, parameters);
        }

        public static DataTable LoadFormHREmpidInit()
        {
            string query = "PKHR_COMPANYINFO.SP_LOAD_EMPIDINIT";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public DataTable getCorporationUser(string Corporation)
        {
            string SP_Name = "PKHR_COMPANYINFO.SP_LOADUSERBYCORP";
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("pCorporation", Corporation);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable data = DBHelper.getDataTable_SP(SP_Name, _sqlParam);
            return data;
        }

        public static DataTable HRManageerLoad(string pDeptcode)
        {
            string spName = "PK_HR_ORGANIZATION_01.SP_HRMANAGERLOAD";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pCorporation", pDeptcode);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP(spName, param);
            table.Rows.InsertAt(table.NewRow(), 0);
            return table;
        }

        public static bool Check_Hr_Manager(string puserid)
        {
            string spName = "PKHR_COMPANYINFO.SP_CHECK_HRMANAGER";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PUSERID", puserid);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param).Rows.Count > 0;
        }
    }
}