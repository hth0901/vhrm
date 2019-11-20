/*
FileName: PgmEvaluation.aspx.cs
-----
Create by Le Thanh Hung
Create Date: 09/05/2014
--
Update by Le Thanh Hung
Update Date: 09/05/2014
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Data.OleDb;
using System.Web.Configuration;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class EvaluationAccess
    {
        public AuthorizationEntity SP_GET_PERMISSION(string puserid)
        {
            AuthorizationEntity entity = new AuthorizationEntity();
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("PUSERID", puserid);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable data = DBHelper.getDataTable_SP("PK_EVALUATION.SP_GET_PERMISSION", parameters);
            if (data != null && data.Rows.Count > 0)
            {
                entity.MENU_ID = data.Rows[0]["MENU_ID"].ToString();
                entity.OWNER_ID = puserid;
                foreach (DataRow row in data.Rows)
                {
                    if (row["IS_VIEW"].ToString() == "1")
                        entity.IS_VIEW = true;
                    if (row["IS_CONFIRM"].ToString() == "1")
                        entity.IS_CONFIRM = true;
                    if (row["IS_ADD"].ToString() == "1")
                        entity.IS_ADD = true;
                    if (row["IS_DELETE"].ToString() == "1")
                        entity.IS_DELETE = true;
                    if (row["IS_UPDATE"].ToString() == "1")
                        entity.IS_UPDATE = true;
                    if (row["IS_PRINT"].ToString() == "1")
                        entity.IS_PRINT = true;
                    if (row["IS_EXPORT"].ToString() == "1")
                        entity.IS_EXPORT = true;
                }
            }
            return entity;
        }

        public DataTable SP_EVALUATION_WORKER(string pdeptcpde, string pdate, string puserid)
        {
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("PDEPTCODE", pdeptcpde);
            parameters[1] = new OracleParameter("PDATE", pdate);
            parameters[2] = new OracleParameter("PUSERID", puserid);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_WORKER", parameters);
        }

        public DataTable SP_EVALUATION_LEADER(string pdeptcpde, string pdate, string puserid)
        {
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("PDEPTCODE", pdeptcpde);
            parameters[1] = new OracleParameter("PDATE", pdate);
            parameters[2] = new OracleParameter("PUSERID", puserid);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_LEADER", parameters);
        }

        public DataTable SP_EVALUATION_MANAGER(string pdeptcpde, string pdate, string puserid)
        {
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("PDEPTCODE", pdeptcpde);
            parameters[1] = new OracleParameter("PDATE", pdate);
            parameters[2] = new OracleParameter("PUSERID", puserid);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_MANAGER", parameters);
        }

        //CALCULATE
        public DataTable SP_GET_INFO_WORKER(string pdate, string empid, string grade_WorkingAtiitude, string grade_Contribution)
        {
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("pdate", pdate);
            parameters[1] = new OracleParameter("PEMPID", empid);
            parameters[2] = new OracleParameter("PGRADE_WORKINGATTITUDE", grade_WorkingAtiitude);
            parameters[3] = new OracleParameter("PGRADE_CONTRIBUTION", grade_Contribution);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_GET_INFO_WORKER", parameters);
        }
        public DataTable SP_GET_INFO_LEADER(string pdate, string empid, string grade_WorkingAtiitude, string grade_ManagementSkill, string grade_quality)
        {
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pdate", pdate);
            parameters[1] = new OracleParameter("PEMPID", empid);
            parameters[2] = new OracleParameter("PGRADE_WORKINGATTITUDE", grade_WorkingAtiitude);
            parameters[3] = new OracleParameter("PGRADE_MANAGEMENTSKILL", grade_ManagementSkill);
            parameters[4] = new OracleParameter("PGRADE_QUALITY", grade_quality);
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_GET_INFO_LEADER", parameters);
        }

        public DataTable SP_GET_INFO_MANAGER(string pdate, string empid, string grade_chuyenbiencv, string grade_caithienHoancanh, string grade_yeucaukhachhang,
            string grade_suphoihop, string grade_tochucdaotao, string grade_kynanggiaotiep,  string grade_chinhsach, string grade_traodoithongtin,  string grade_kyluat,
            string grade_chamchi, string grade_diemmanh, string grade_diemyeu, string grade_notes)
        {
            OracleParameter[] parameters = new OracleParameter[16];
            parameters[0] = new OracleParameter("pdate", pdate);
            parameters[1] = new OracleParameter("PEMPID", empid);
            parameters[2] = new OracleParameter("PGRADE_CHUYENBIENCV", grade_chuyenbiencv);
            parameters[3] = new OracleParameter("PGRADE_CAITHIENHOANCANH", grade_caithienHoancanh);
            parameters[4] = new OracleParameter("PGRADE_YEUCAUKHACHHANG", grade_yeucaukhachhang);
            parameters[5] = new OracleParameter("PGRADE_SUPHOIHOP", grade_suphoihop);
            parameters[6] = new OracleParameter("PGRADE_TOCHUCVADAOTAO", grade_tochucdaotao);
            parameters[7] = new OracleParameter("PGRADE_KYNANGGIAOTIEP", grade_kynanggiaotiep);
            parameters[8] = new OracleParameter("PGRADE_CHINHSACHCHIENLUOC", grade_chinhsach);
            parameters[9] = new OracleParameter("PGRADE_TRAODOITHONGTIN", grade_traodoithongtin);
            parameters[10] = new OracleParameter("PGRADE_KYLUAT", grade_kyluat);
            parameters[11] = new OracleParameter("PGRADE_CHAMCHI", grade_chamchi);
            parameters[12] = new OracleParameter("PGRADE_DIEMMANH", grade_diemmanh);
            parameters[13] = new OracleParameter("PGRADE_DIEMYEU", grade_diemyeu);
            parameters[14] = new OracleParameter("PNOTES", grade_notes);
            parameters[15] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_GET_INFO_MANAGER", parameters);
        }

        //DU LIEU CHO CAC DROPDOWNLIST

        public DataSet SP_EVL_FOR_WORKER()
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output }; //WORKING ATTITUDE
            parameters[1] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output }; //CONTRIBUTION
            parameters[2] = new OracleParameter("T_TABLE3", OracleType.Cursor) { Direction = ParameterDirection.Output }; //Contract kind
            return DBHelper.getDataSet_SP("PK_EVALUATION.SP_EVL_FOR_WORKER", parameters);
        }

        public DataSet SP_EVL_FOR_LEADER()
        {
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output }; //WORKING ATTITUDE
            parameters[1] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            parameters[2] = new OracleParameter("T_TABLE3", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            parameters[3] = new OracleParameter("T_TABLE4", OracleType.Cursor) { Direction = ParameterDirection.Output }; //Contract kind
            return DBHelper.getDataSet_SP("PK_EVALUATION.SP_EVL_FOR_LEADER", parameters);
        }


        public DataSet SP_EVL_FOR_MANAGER()
        {
            OracleParameter[] parameters = new OracleParameter[13];
            parameters[0] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output }; // 
            parameters[1] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            parameters[2] = new OracleParameter("T_TABLE3", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            parameters[3] = new OracleParameter("T_TABLE4", OracleType.Cursor) { Direction = ParameterDirection.Output }; // 
            parameters[4] = new OracleParameter("T_TABLE5", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            parameters[5] = new OracleParameter("T_TABLE6", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            parameters[6] = new OracleParameter("T_TABLE7", OracleType.Cursor) { Direction = ParameterDirection.Output }; // 
            parameters[7] = new OracleParameter("T_TABLE8", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            parameters[8] = new OracleParameter("T_TABLE9", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            parameters[9] = new OracleParameter("T_TABLE10", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            parameters[10] = new OracleParameter("T_TABLE11", OracleType.Cursor) { Direction = ParameterDirection.Output }; //Contract kind
            parameters[11] = new OracleParameter("T_TABLE12", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            parameters[12] = new OracleParameter("T_TABLE13", OracleType.Cursor) { Direction = ParameterDirection.Output }; //
            return DBHelper.getDataSet_SP("PK_EVALUATION.SP_EVL_FOR_MANAGER", parameters);
        }

        public DataTable SP_GETALLSALARY(string PEMPID, string PMONTH, string PJOBCODE, double PSALARY)
        {
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PEMPID", PEMPID);
            parameters[1] = new OracleParameter("PMONTH", PMONTH);
            parameters[2] = new OracleParameter("PJOBCODE", PJOBCODE);
            parameters[3] = new OracleParameter("PSALARY", PSALARY);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output }; //Contract kind
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_GETALLSALARY", parameters);
        }

        
        //SUBMIT
        public DataTable SP_EVL_CALCULATE_WORKER(string sys_empid, string jobCode, string deptcpde, double total_absence,
            double total_yellowCard, double warningLetter, string grade_WorkingAtiitude, string grade_Contribution, double basicSalary, string userID, string pdate, string kindOfuser)
        {
            OracleParameter[] parameters = new OracleParameter[13];
            parameters[0] = new OracleParameter("PSYS_EMPID", sys_empid);
            parameters[1] = new OracleParameter("PJOBCODE", jobCode);
            parameters[2] = new OracleParameter("PDEPTCODE", deptcpde);
            parameters[3] = new OracleParameter("PTOTAL_ABSENCE", total_absence);
            parameters[4] = new OracleParameter("PTOTAL_YELLOWCARD", total_yellowCard);
            parameters[5] = new OracleParameter("PTOTAL_WARNINGLETTER", warningLetter);
            parameters[6] = new OracleParameter("PGRADE_WORKINGATTITUDE", grade_WorkingAtiitude);
            parameters[7] = new OracleParameter("PGRADE_CONTRIBUTION", grade_Contribution);
            parameters[8] = new OracleParameter("PBASICSALARY", basicSalary);
            parameters[9] = new OracleParameter("PUSERID", userID);
            parameters[10] = new OracleParameter("PDATE", pdate);
            parameters[11] = new OracleParameter("PKINDOFUSER", kindOfuser);
            parameters[12] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVL_CALCULATE_WORKER", parameters);
        }

        public DataTable SP_EVL_CALCULATE_LEADER(string sys_empid, string jobCode, string deptcpde, double total_absence,
            double total_yellowCard, double warningLetter, string grade_WorkingAtiitude, string grade_managementSkill, string grade_Quality, double basicSalary, string userID, string pdate, string kindOfuser)
        {
            OracleParameter[] parameters = new OracleParameter[14];
            parameters[0] = new OracleParameter("PSYS_EMPID", sys_empid);
            parameters[1] = new OracleParameter("PJOBCODE", jobCode);
            parameters[2] = new OracleParameter("PDEPTCODE", deptcpde);
            parameters[3] = new OracleParameter("PTOTAL_ABSENCE", total_absence);
            parameters[4] = new OracleParameter("PTOTAL_YELLOWCARD", total_yellowCard);
            parameters[5] = new OracleParameter("PTOTAL_WARNINGLETTER", warningLetter);
            parameters[6] = new OracleParameter("PGRADE_WORKINGATTITUDE", grade_WorkingAtiitude);
            parameters[7] = new OracleParameter("PGRADE_MANAGEMENTSKILL", grade_managementSkill);
            parameters[8] = new OracleParameter("PGRADE_QUALITY", grade_Quality);
            parameters[9] = new OracleParameter("PBASICSALARY", basicSalary);
            parameters[10] = new OracleParameter("PUSERID", userID);
            parameters[11] = new OracleParameter("PDATE", pdate);
            parameters[12] = new OracleParameter("PKINDOFUSER", kindOfuser);
            parameters[13] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVL_CALCULATE_LEADER", parameters);
        }

        public DataTable SP_EVL_CALCULATE_MANAGER(string sys_empid, string jobCode, string deptcpde,
            string grade_chuyenbiencv, string grade_caithienhoancanh, string grade_yeucaukhachhang, string grade_suphoihop, string grade_tochucvadaotao,
            string grade_kynanggiaotiep, string grade_chinhsachchienluoc, string grade_tradoithongtin, string grade_kyluat, string grade_chamchi, string grade_diemmanh, string grade_diemyeu,
            string pnotes, double basicSalary, string userID, string pdate, string kindOfuser, string remark_other)
        {
            OracleParameter[] parameters = new OracleParameter[22];
            parameters[0] = new OracleParameter("PSYS_EMPID", sys_empid);
            parameters[1] = new OracleParameter("PJOBCODE", jobCode);
            parameters[2] = new OracleParameter("PDEPTCODE", deptcpde);
            parameters[3] = new OracleParameter("PGRADE_CHUYENBIENCV", grade_chuyenbiencv);
            parameters[4] = new OracleParameter("PGRADE_CAITHIENHOANCANH", grade_caithienhoancanh);
            parameters[5] = new OracleParameter("PGRADE_YEUCAUKHACHHANG", grade_yeucaukhachhang);
            parameters[6] = new OracleParameter("PGRADE_SUPHOIHOP", grade_suphoihop);
            parameters[7] = new OracleParameter("PGRADE_TOCHUCVADAOTAO", grade_tochucvadaotao);
            parameters[8] = new OracleParameter("PGRADE_KYNANGGIAOTIEP", grade_kynanggiaotiep);
            parameters[9] = new OracleParameter("PGRADE_CHINHSACHCHIENLUOC", grade_chinhsachchienluoc);
            parameters[10] = new OracleParameter("PGRADE_TRAODOITHONGTIN", grade_tradoithongtin);
            parameters[11] = new OracleParameter("PGRADE_KYLUAT", grade_kyluat);
            parameters[12] = new OracleParameter("PGRADE_CHAMCHI", grade_chamchi);
            parameters[13] = new OracleParameter("PGRADE_DIEMMANH", grade_diemmanh);
            parameters[14] = new OracleParameter("PGRADE_DIEMYEU", grade_diemyeu);
            parameters[15] = new OracleParameter("PNOTES", pnotes);
            parameters[16] = new OracleParameter("PBASICSALARY", basicSalary);
            parameters[17] = new OracleParameter("PUSERID", userID);
            parameters[18] = new OracleParameter("PDATE", pdate);
            parameters[19] = new OracleParameter("PKINDOFUSER", kindOfuser);
            parameters[20] = new OracleParameter("PREMARKOTHER", remark_other);
            parameters[21] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVL_CALCULATE_MANAGER", parameters);
        }



        public DataTable SP_EVL_CONFIRM(string pevlid, string puserid, string PSTEPNO, double PSALARY)
        {
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PEVLID", pevlid);
            parameters[1] = new OracleParameter("PUSERID", puserid);
            parameters[2] = new OracleParameter("PSTEPNO", PSTEPNO);
            parameters[3] = new OracleParameter("PSALARY", PSALARY);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVL_CONFIRM", parameters);
        }

        public DataTable SP_EVL_SUBMIT(string pevlid, string puserid)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PEVLID", pevlid);
            parameters[1] = new OracleParameter("PUSERID", puserid);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVL_SUBMIT", parameters);
        }

        public DataTable SP_CONFIRM_EVALUATED(string pevlid, string pconfirm, string puserid)
        {
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("PEVLID", pevlid);
            parameters[1] = new OracleParameter("PCONFIRM", pconfirm);
            parameters[2] = new OracleParameter("PUSERID", puserid);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_CONFIRM_EVALUATED", parameters);
        }

        public DataTable SP_CANCEL_EVALUATED(string pevlid, string puserid)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PEVLID", pevlid);
            parameters[1] = new OracleParameter("PUSERID", puserid);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_CANCEL_EVALUATED", parameters);
        }

        public DataTable SP_EVALUATION_APPROVE(string pevlid, string pstepno, double psalary, string puserid)
        {
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PEVLID", pevlid);
            parameters[1] = new OracleParameter("PSTEPNO", pstepno);
            parameters[2] = new OracleParameter("PSALARY", psalary);
            parameters[3] = new OracleParameter("PUSERID", puserid);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_APPROVE", parameters);
        }

        public DataTable SP_GENERATE_CONTRACT(string pevlid, string psysempid, string pdate, double pbasicSalary, string pstepno, string puserid)
        {
            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("PSYS_EMPID", psysempid);
            parameters[1] = new OracleParameter("PDATE", pdate);
            parameters[2] = new OracleParameter("PBASIC_SALARY", pbasicSalary);
            parameters[3] = new OracleParameter("PLOGINID", puserid);
            parameters[4] = new OracleParameter("PEVLID", pevlid);
            parameters[5] = new OracleParameter("PSTEPNO", pstepno);
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_GENERATE_CONTRACT", parameters);
        }

        public DataTable SP_STATISTIC_WORKER(string pdeptcode, string pdate)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PDATE", pdate);
            parameters[1] = new OracleParameter("PDEPTCODE", pdeptcode);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_STATISTIC_WORKER", parameters);
        }

        public DataTable SP_STATISTIC_LEADER(string pdeptcode, string pdate)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PDATE", pdate);
            parameters[1] = new OracleParameter("PDEPTCODE", pdeptcode);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_STATISTIC_LEADER", parameters);
        }

        public DataTable SP_STATISTIC_MANAGER(string pdeptcode, string pdate)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PDATE", pdate);
            parameters[1] = new OracleParameter("PDEPTCODE", pdeptcode);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_STATISTIC_MANAGER", parameters);
        }

        public DataTable SP_STATISTIC_ALL(string pdeptcode, string pdate)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PDATE", pdate);
            parameters[1] = new OracleParameter("PDEPTCODE", pdeptcode);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_STATISTIC_ALL", parameters);
        }

        public DataTable ReadDataExcel(string path, string _sheetName)
        {
            OleDbConnection oledbConn = new OleDbConnection();
            DataSet ds = new DataSet();
            try
            {
                if (Path.GetExtension(path) == ".xls")
                {
                    oledbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
                }
                else if (Path.GetExtension(path) == ".xlsx")
                {
                    oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "; Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
                }
                oledbConn.Open();
                OleDbCommand cmd = new OleDbCommand(); ;
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                cmd.Connection = oledbConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT *  FROM [" + _sheetName + "]";
                oleda = new OleDbDataAdapter(cmd);
                oleda.Fill(ds);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                oledbConn.Close();
            }

            return ds.Tables[0];
        }

        public DataTable GetExcelSheets(string FilePath, string Extension)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    break;
                case ".xlsx": //Excel 07
                    conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + "; Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";
                    break;
            }

            //Get the Sheets in Excel WorkBook
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            cmdExcel.Connection = connExcel;
            DataTable _result = new DataTable();
            try
            {
                connExcel.Open();
                _result = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            }
            catch(Exception ex)
            {
            }
            finally
            {
                connExcel.Close();
            }
            return _result;
        }

        //---------------------------------------------------------------------
        //DUY HUNG
        public DataTable SP_EVALUATION_QUERRY_ITEM()
        {
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_QUERRY_ITEM", parameters);
        }

        //DUY HUNG
        public DataTable SP_EVALUATION_QUERRY_GRADE(string pITEMID)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pITEMID", pITEMID);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_QUERRY_GRADE", parameters);
        }

        //DUY HUNG
        public DataTable SP_EVALUATION_ITEM_DELETE(string pITEMID, string pUID)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pITEMID", pITEMID);
            parameters[1] = new OracleParameter("pUID", pUID);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_ITEM_DELETE", parameters);
        }

        //DUY HUNG
        public DataTable SP_EVALUATION_QUERRY_KINDS(string pITEMID)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pITEMID", pITEMID);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_QUERRY_KINDS", parameters);
        }

        //DUY HUNG
        public DataTable SP_EVALUATION_ITEM_ADD(string pITEM_NAME, string pITEM_NAME_VN, string pDESCRIPTION, string pIS_ACTIVE, string pKinds, string pUID)
        {
            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("pITEMNAME", pITEM_NAME);
            parameters[1] = new OracleParameter("pITEMNAMEVN", pITEM_NAME_VN);
            parameters[2] = new OracleParameter("pDESCRIPTION", pDESCRIPTION);
            parameters[3] = new OracleParameter("pISACTIVE", pIS_ACTIVE);
            parameters[4] = new OracleParameter("pKINDS", pKinds);
            parameters[5] = new OracleParameter("pUID", pUID);
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_ITEM_ADD", parameters);
        }

        //DUY HUNG
        public DataTable SP_EVALUATION_GRADE_UPDATE(string PITEMID, string GRADE_ID, string SCORE, string DESCRIPTION, string DESCRIPTION_VN, string CND_FROM, string CND_TO, string pUID)
        {
            OracleParameter[] parameters = new OracleParameter[9];
            parameters[0] = new OracleParameter("pITEMID", PITEMID);
            parameters[1] = new OracleParameter("pGRADE_ID", GRADE_ID);
            parameters[2] = new OracleParameter("pSCORE", SCORE);
            parameters[3] = new OracleParameter("pDESCRIPTION", DESCRIPTION);
            parameters[4] = new OracleParameter("pDESCRIPTION_VN", DESCRIPTION_VN);
            parameters[5] = new OracleParameter("pCND_FROM", CND_FROM);
            parameters[6] = new OracleParameter("pCND_TO", CND_TO);
            parameters[7] = new OracleParameter("pUID", pUID);
            parameters[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_GRADE_UPDATE", parameters);
        }

        //DUY HUNG
        public DataTable SP_EVALUATION_ITEM_UPDATE(string pITEMID, string pITEM_NAME, string pITEM_NAME_VN, string pDESCRIPTION, string pIS_ACTIVE, string pKinds, string pUID)
        {
            OracleParameter[] parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("pITEMID", pITEMID);
            parameters[1] = new OracleParameter("pITEMNAME", pITEM_NAME);
            parameters[2] = new OracleParameter("pITEMNAMEVN", pITEM_NAME_VN);
            parameters[3] = new OracleParameter("pDESCRIPTION", pDESCRIPTION);
            parameters[4] = new OracleParameter("pISACTIVE", pIS_ACTIVE);
            parameters[5] = new OracleParameter("pKINDS", pKinds);
            parameters[6] = new OracleParameter("pUID", pUID);
            parameters[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_EVALUATION_ITEM_UPDATE", parameters);
        }

        //===================================================================================================================
        //add by ndhung 2016.03.17 -> save percent increase salary by HR manager
        //===================================================================================================================
        public DataTable SavePercentIncrease(string evlid, string empid, string percent, string userid)
        {
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PEVLID", evlid);
            parameters[1] = new OracleParameter("PSYS_EMPID", empid);
            parameters[2] = new OracleParameter("PPERCENT", percent == "" ? "0" : percent);
            parameters[3] = new OracleParameter("PUSERID", userid);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_SAVE_INCREASEPERCENT_MANUAL", parameters);
        }


        //===================================================================================================================
        //add by ndhung 2017.10.27 -> Delete Evaluation
        //===================================================================================================================
        public DataTable DeleteEvaluation(string evlid, string userid)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PEVLID", evlid);
            parameters[1] = new OracleParameter("PUSERID", userid);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_DELETE_EVALUATED", parameters);
        }

        //===================================================================================================================
        //add by ndhung 2017.11.06 -> Upload list other
        //===================================================================================================================
        public DataTable UploadOtherEvaluation(string deptcode, string empid, string month, string userid)
        {
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PDEPTCODE", deptcode);
            parameters[1] = new OracleParameter("PEMPID", empid);
            parameters[2] = new OracleParameter("PMONTH", month);
            parameters[3] = new OracleParameter("PUSERID", userid);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_UPLOAD_LIST_OTHER", parameters);
        }

        //===================================================================================================================
        //add by ndhung 2018.02.06 -> Upload list deny
        //===================================================================================================================
        public DataTable UploadDenyEvaluation(string deptcode, string empid, string month, string userid)
        {
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PDEPTCODE", deptcode);
            parameters[1] = new OracleParameter("PEMPID", empid);
            parameters[2] = new OracleParameter("PMONTH", month);
            parameters[3] = new OracleParameter("PUSERID", userid);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_UPLOAD_LIST_DENY", parameters);
        }

        //===================================================================================================================
        //add by ndhung 2018.02.06 -> Upload list to Remove from Deny
        //===================================================================================================================
        public DataTable UploadRemoveDenyEvaluation(string deptcode, string empid, string month, string userid)
        {
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PDEPTCODE", deptcode);
            parameters[1] = new OracleParameter("PEMPID", empid);
            parameters[2] = new OracleParameter("PMONTH", month);
            parameters[3] = new OracleParameter("PUSERID", userid);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_EVALUATION.SP_UPLOAD_LIST_REMOVE_DENY", parameters);
        }
    }
} 