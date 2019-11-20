using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class GAAccess
    {
        public DataTable SP_GET_LIST_EMPLOYEES(string deptcode, string status)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("PDEPTCODE", deptcode);
            param[1] = new OracleParameter("PSTATUS", status);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_LIST_EMPLOYEES", param);
        }

        public DataTable SP_GET_REQUEST_MASTER(string requester, string month)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("PREQUESTER", requester);
            param[1] = new OracleParameter("PMONTH", month);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_REQUEST_MASTER", param);
        }

        public DataTable SP_GET_REQUEST_DETAIL(string rdno)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PRDNO", rdno);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_REQUEST_DETAIL", param);
        }

        public DataTable SP_GET_LIST_ITEM_MASTER(string rdno, string category)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("PRDNO", rdno);
            param[1] = new OracleParameter("PCATEGORY", category);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_LIST_ITEM_MASTER", param);
        }

        public DataTable SP_GET_LIST_REQUEST(string pmonth, string pdept)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("PDEPT", pdept);
            param[1] = new OracleParameter("PMONTH", pmonth);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_LIST_REQUEST", param);
        }

        public DataTable SP_PRINT_REPORT(string PRDNO)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PRDNO", PRDNO);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_PRINT_REPORT", param);
        }

        public DataTable SP_MASTER_ADD(string PRDTYPE, string PDEPTCODE, string PREQUESTER,
                          string PREMARKS, string PREGISTERID)
        {
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("PRDTYPE", PRDTYPE);
            param[1] = new OracleParameter("PDEPTCODE", PDEPTCODE);
            param[2] = new OracleParameter("PREQUESTER", PREQUESTER);
            param[3] = new OracleParameter("PREMARKS", PREMARKS);
            param[4] = new OracleParameter("PREGISTERID", PREGISTERID);
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_MASTER_ADD", param);
        }

        public DataTable SP_DETAIL_ADD(string PRDNO, string PEQGROUP, string PEQLEVEL1, string PEQLEVEL2,
                          string PUNIT, string PREASONTYPE, string PREASON, string PPUSCHASETYPE, string PQUANTITY,
                          string PPDNO, string PPDNO_SERIAL, string PREGISTRYID)
        {
            OracleParameter[] param = new OracleParameter[13];
            param[0] = new OracleParameter("PRDNO", PRDNO);
            param[1] = new OracleParameter("PEQGROUP", PEQGROUP);
            param[2] = new OracleParameter("PEQLEVEL1", PEQLEVEL1);
            param[3] = new OracleParameter("PEQLEVEL2", PEQLEVEL2);
            param[4] = new OracleParameter("PUNIT", PUNIT);
            param[5] = new OracleParameter("PREASONTYPE", PREASONTYPE);
            param[6] = new OracleParameter("PREASON", PREASON);
            param[7] = new OracleParameter("PPUSCHASETYPE", PPUSCHASETYPE);
            param[8] = new OracleParameter("PQUANTITY", PQUANTITY);
            param[9] = new OracleParameter("PPDNO", PPDNO);
            param[10] = new OracleParameter("PPDNO_SERIAL", PPDNO_SERIAL);
            param[11] = new OracleParameter("PREGISTRYID", PREGISTRYID);
            param[12] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_DETAIL_ADD", param);
        }

        public DataTable SP_DETAIL_SAVE(string PRDNO, int PEQSERIAL, string PEQGROUP, string PEQLEVEL1, string PEQLEVEL2,
                          string PUNIT, string PREASONTYPE, string PREASON, string PPUSCHASETYPE, string PQUANTITY,
                          string PPDNO, string PPDNO_SERIAL, string PREGISTRYID)
        {
            OracleParameter[] param = new OracleParameter[14];
            param[0] = new OracleParameter("PRDNO", PRDNO);
            param[1] = new OracleParameter("PEQSERIAL", PEQSERIAL);
            param[2] = new OracleParameter("PEQGROUP", PEQGROUP);
            param[3] = new OracleParameter("PEQLEVEL1", PEQLEVEL1);
            param[4] = new OracleParameter("PEQLEVEL2", PEQLEVEL2);
            param[5] = new OracleParameter("PUNIT", PUNIT);
            param[6] = new OracleParameter("PREASONTYPE", PREASONTYPE);
            param[7] = new OracleParameter("PREASON", PREASON);
            param[8] = new OracleParameter("PPUSCHASETYPE", PPUSCHASETYPE);
            param[9] = new OracleParameter("PQUANTITY", PQUANTITY);
            param[10] = new OracleParameter("PPDNO", PPDNO);
            param[11] = new OracleParameter("PPDNO_SERIAL", PPDNO_SERIAL);
            param[12] = new OracleParameter("PREGISTRYID", PREGISTRYID);
            param[13] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_DETAIL_SAVE", param);
        }

        public DataTable SP_DETAIL_DELETE(string PRDNO, int PEQSERIAL)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("PRDNO", PRDNO);
            param[1] = new OracleParameter("PEQSERIAL", PEQSERIAL);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_DETAIL_DELETE", param);
        }

        public DataTable SP_ITEM_ADD(string PCODEGROUP, string PSCODE, string PMCODE, string PCODENAME, string PCODEDETAIL, string PACNTCODE, string PCODEDESC)
        {
            OracleParameter[] param = new OracleParameter[8];
            param[0] = new OracleParameter("PCODEGROUP", PCODEGROUP);
            param[1] = new OracleParameter("PSCODE", PSCODE);
            param[2] = new OracleParameter("PMCODE", PMCODE);
            param[3] = new OracleParameter("PCODENAME", PCODENAME);
            param[4] = new OracleParameter("PCODEDETAIL", PCODEDETAIL);
            param[5] = new OracleParameter("PACNTCODE", PACNTCODE);
            param[6] = new OracleParameter("PCODEDESC", PCODEDESC);
            param[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_ITEM_ADD", param);
        }

        public DataTable SP_ITEM_UPDATE(string PCODEGROUP, string PSCODE, string PMCODE, string PCODENAME, string PCODEDETAIL, string PACNTCODE, string PCODEDESC)
        {
            OracleParameter[] param = new OracleParameter[8];
            param[0] = new OracleParameter("PCODEGROUP", PCODEGROUP);
            param[1] = new OracleParameter("PSCODE", PSCODE);
            param[2] = new OracleParameter("PMCODE", PMCODE);
            param[3] = new OracleParameter("PCODENAME", PCODENAME);
            param[4] = new OracleParameter("PCODEDETAIL", PCODEDETAIL);
            param[5] = new OracleParameter("PACNTCODE", PACNTCODE);
            param[6] = new OracleParameter("PCODEDESC", PCODEDESC);
            param[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_ITEM_UPDATE", param);
        }

        public DataTable SP_ITEM_DELETE(string PCODEGROUP, string PSCODE, string PMCODE)
        {
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("PCODEGROUP", PCODEGROUP);
            param[1] = new OracleParameter("PSCODE", PSCODE);
            param[2] = new OracleParameter("PMCODE", PMCODE);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_ITEM_DELETE", param);
        }

        public DataTable SP_PURCHASE_GET(string PDEPTCODE, string PCATEGORY, string PFROMDATE, string PTODATE)
        {
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("PDEPTCODE", PDEPTCODE);
            param[1] = new OracleParameter("PCATEGORY", PCATEGORY);
            param[2] = new OracleParameter("PFROMDATE", PFROMDATE);
            param[3] = new OracleParameter("PTODATE", PTODATE);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_PURCHASE_GET", param);
        }

        public DataTable SP_PURCHASE_ADD(string PDEPTCODE, string PCATEGORY, string PSUPPLIER, DateTime PDELIVERYDATE, string PTAXKIND, double PNETAMOUNT, string PCURRCODE, string PTAX_ACNT_CODE, string PPAYCODE, string PUSERID)
        {
            OracleParameter[] param = new OracleParameter[11];
            param[0] = new OracleParameter("PDEPTCODE", PDEPTCODE);
            param[1] = new OracleParameter("PCATEGORY", PCATEGORY);
            param[2] = new OracleParameter("PSUPPLIER", PSUPPLIER);
            param[3] = new OracleParameter("PDELIVERYDATE", PDELIVERYDATE);
            param[4] = new OracleParameter("PTAXKIND", PTAXKIND);
            param[5] = new OracleParameter("PNETAMOUNT", PNETAMOUNT);
            param[6] = new OracleParameter("PCURRCODE", PCURRCODE);
            param[7] = new OracleParameter("PTAX_ACNT_CODE", PTAX_ACNT_CODE);
            param[8] = new OracleParameter("PPAYCODE", PPAYCODE);
            param[9] = new OracleParameter("PUSERID", PUSERID);
            param[10] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_PURCHASE_ADD", param);
        }

        public DataTable SP_PURCHASE_UPDATE(string PPDNO, string PSUPPLIER, DateTime PDELIVERYDATE, string PTAXKIND, double PNETAMOUNT, string PCURRCODE, string PTAX_ACNT_CODE, string PPAYCODE, string PUSERID)
        {
            OracleParameter[] param = new OracleParameter[10];
            param[0] = new OracleParameter("PPDNO", PPDNO);
            param[1] = new OracleParameter("PSUPPLIER", PSUPPLIER);
            param[2] = new OracleParameter("PDELIVERYDATE", PDELIVERYDATE);
            param[3] = new OracleParameter("PTAXKIND", PTAXKIND);
            param[4] = new OracleParameter("PNETAMOUNT", PNETAMOUNT);
            param[5] = new OracleParameter("PCURRCODE", PCURRCODE);
            param[6] = new OracleParameter("PTAX_ACNT_CODE", PTAX_ACNT_CODE);
            param[7] = new OracleParameter("PPAYCODE", PPAYCODE);
            param[8] = new OracleParameter("PUSERID", PUSERID);
            param[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_PURCHASE_UPDATE", param);
        }

        public DataTable SP_PURCHASE_GET_DETAIL(string PPDNO)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PPDNO", PPDNO);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_PURCHASE_GET_DETAIL", param);
        }

        public DataTable SP_PURCHASE_SAVE_DETAIL(string PPDNO, double PSERIAL, string PCODEGROUP, string PCODELEVEL1, string PCODELEVEL2, string PACNT_CODE,string  PREMARKS ,
             string  PUNIT, double PQUANTITY, double PPRICE, DateTime PBILLDATE, DateTime PDELIVERYDATE, DateTime PREQUESTDATE,
             string PREQUESTER, string PREGISTER, string PCONFIRMER, DateTime PCONFIRMDATE, string PCURRCODE, DateTime PREGISTRYDATE, string PSUPPLIER, string PRDNO)
        {
            OracleParameter[] param = new OracleParameter[22];
            param[0] = new OracleParameter("PPDNO", PPDNO);
            param[1] = new OracleParameter("PSERIAL", PSERIAL);
            param[2] = new OracleParameter("PCODEGROUP", PCODEGROUP);
            param[3] = new OracleParameter("PCODELEVEL1", PCODELEVEL1);
            param[4] = new OracleParameter("PCODELEVEL2", PCODELEVEL2);
            param[5] = new OracleParameter("PACNT_CODE", PACNT_CODE);
            param[6] = new OracleParameter("PREMARKS", PREMARKS);
            param[7] = new OracleParameter("PUNIT", PUNIT);
            param[8] = new OracleParameter("PQUANTITY", PQUANTITY);
            param[9] = new OracleParameter("PPRICE", PPRICE);
            param[10] = new OracleParameter("PBILLDATE", PBILLDATE);
            param[11] = new OracleParameter("PDELIVERYDATE", PDELIVERYDATE);
            param[12] = new OracleParameter("PREQUESTDATE", PREQUESTDATE);
            param[13] = new OracleParameter("PREQUESTER", PREQUESTER);
            param[14] = new OracleParameter("PREGISTER", PREGISTER);
            param[15] = new OracleParameter("PCONFIRMER", PCONFIRMER);
            param[16] = new OracleParameter("PCONFIRMDATE", PCONFIRMDATE);
            param[17] = new OracleParameter("PCURRCODE", PCURRCODE);
            param[18] = new OracleParameter("PREGISTRYDATE", PREGISTRYDATE);
            param[19] = new OracleParameter("PSUPPLIER", PSUPPLIER);
            param[20] = new OracleParameter("PRDNO", PRDNO);
            param[21] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_PURCHASE_SAVE_DETAIL", param);
        }

        public DataTable SP_PURCHASE_DELETE_DETAIL(string PPDNO, double PSERIAL, string rdno)
        {
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("PPDNO", PPDNO);
            param[1] = new OracleParameter("PSERIAL", PSERIAL);
            param[2] = new OracleParameter("PRDNO", rdno);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_PURCHASE_DELETE_DETAIL", param);
        }
        

        public double SP_PURCHASE_GET_CURRPRICE(string PGROUP, string PLEVEL1, string PLEVEL2)
        {
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("PGROUP", PGROUP);
            param[1] = new OracleParameter("PLEVEL1", PLEVEL1);
            param[2] = new OracleParameter("PLEVEL2", PLEVEL2);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable result = DBHelper.getDataTable_SP("PK_GA.SP_PURCHASE_GET_CURRPRICE", param);
            return result.Rows.Count > 0 ? double.Parse(result.Rows[0][0].ToString()) : 0;
        }
        public string SP_PURCHASE_GET_ACNTCODE(string PGROUP, string PLEVEL1, string PLEVEL2)
        {
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("PGROUP", PGROUP);
            param[1] = new OracleParameter("PLEVEL1", PLEVEL1);
            param[2] = new OracleParameter("PLEVEL2", PLEVEL2);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable result = DBHelper.getDataTable_SP("PK_GA.SP_PURCHASE_GET_ACNTCODE", param);
            return result.Rows.Count > 0 ? result.Rows[0][0].ToString() : "";
        }

        public DataTable SP_GET_EXPENSE_TRANSFER(string PDEPTCODE, string PGROUP, string PTAXKIND, string PFROMDATE, string PTODATE)
        {
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("PDEPTCODE", PDEPTCODE);
            param[1] = new OracleParameter("PGROUP", PGROUP);
            param[2] = new OracleParameter("PTAXKIND", PTAXKIND);
            param[3] = new OracleParameter("PFROMDATE", PFROMDATE);
            param[4] = new OracleParameter("PTODATE", PTODATE);
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_EXPENSE_TRANSFER", param);
        }

        public DataTable SP_GET_EXPENSE_TRANSFER_DETAIL(string PPDNO_ARRAY)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PPDNO_ARRAY", PPDNO_ARRAY);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_EXPENSE_TRANSFER_DETAIL", param);
        }

        public DataTable SP_GET_GA_TRANSFER_DETAIL(string PPDNO_ARRAY)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PPDNO_ARRAY", PPDNO_ARRAY);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_GA_TRANSFER_DETAIL", param);
        }

        public DataTable SP_GET_TRANSFER_MASTER(string PREQMARK)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PREQMARK", PREQMARK);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_TRANSFER_MASTER", param);
        }

        public DataTable SP_GET_TRANSFER_DETAIL(string PREQMARK)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PREQMARK", PREQMARK);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_TRANSFER_DETAIL", param);
        }

        public DataTable SP_GET_INFO_USER(string PUSERID)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PUSERID", PUSERID);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_INFO_USER", param);
        }

        public DataTable SP_INSERT_TRANSFER_MASTER(string POUTLINE, string PCUR_UNIT, double PSUM_AMT, string PAPR_CHK,
            string PPAY_CHK, string PPAY_BY, string PUSERID)
        {
            OracleParameter[] param = new OracleParameter[8];
            param[0] = new OracleParameter("POUTLINE", POUTLINE);
            param[1] = new OracleParameter("PCUR_UNIT", PCUR_UNIT);
            param[2] = new OracleParameter("PSUM_AMT", PSUM_AMT);
            param[3] = new OracleParameter("PAPR_CHK", PAPR_CHK);
            param[4] = new OracleParameter("PPAY_CHK", PPAY_CHK);
            param[5] = new OracleParameter("PPAY_BY", PPAY_BY);
            param[6] = new OracleParameter("PUSERID", PUSERID);
            param[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_INSERT_TRANSFER_MASTER", param);
        }

        public DataTable SP_TRANSFER_INTO_ERP(string PREQ_MARK, string PREQ_TYPE, string PPAY_TYPE, string PCORPORATION,
            string PREGISTERID, string PPDNO, double PSERIAL, string PUSERID)
        {
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("PREQ_MARK", PREQ_MARK);
            param[1] = new OracleParameter("PREQ_TYPE", PREQ_TYPE);
            param[2] = new OracleParameter("PPAY_TYPE", PPAY_TYPE);
            param[3] = new OracleParameter("PCORPORATION", PCORPORATION);
            param[4] = new OracleParameter("PREGISTERID", PREGISTERID);
            param[5] = new OracleParameter("PPDNO", PPDNO);
            param[6] = new OracleParameter("PSERIAL", PSERIAL);
            param[7] = new OracleParameter("PUSERID", PUSERID);
            param[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_TRANSFER_INTO_ERP", param);
        }

        public DataTable SP_TRANSFER_UPDATE_PAYMENT(string PREQ_MARK, string PSUPPLIER, string PVOUCHER_TYPE, string PUSERID)
        {
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("PREQ_MARK", PREQ_MARK);
            param[1] = new OracleParameter("PSUPPLIER", PSUPPLIER);
            param[2] = new OracleParameter("PVOUCHER_TYPE", PVOUCHER_TYPE);
            param[3] = new OracleParameter("PUSERID", PUSERID);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_TRANSFER_UPDATE_PAYMENT", param);
        }

        public DataTable SP_GET_SUPPLIER()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_GET_SUPPLIER", param);
        }

        public DataTable SP_SUPPLIER_ADD(string PFULLNAME, string PACCOUNTNO, string PGACHECK, string PSTATUS)
        {
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("PFULLNAME", PFULLNAME);
            param[1] = new OracleParameter("PACCOUNTNO", PACCOUNTNO);
            param[2] = new OracleParameter("PGACHECK", PGACHECK);
            param[3] = new OracleParameter("PSTATUS", PSTATUS);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_SUPPLIER_ADD", param);
        }

        public DataTable SP_SUPPLIER_UPDATE(string PSOS, string PFULLNAME, string PACCOUNTNO, string PGACHECK, string PSTATUS)
        {
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("PSOS", PSOS);
            param[1] = new OracleParameter("PFULLNAME", PFULLNAME);
            param[2] = new OracleParameter("PACCOUNTNO", PACCOUNTNO);
            param[3] = new OracleParameter("PGACHECK", PGACHECK);
            param[4] = new OracleParameter("PSTATUS", PSTATUS);
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_SUPPLIER_UPDATE", param);
        }

        public DataTable SP_SUPPLIERDELETE(string PSOS)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PSOS", PSOS);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_GA.SP_SUPPLIERDELETE", param);
        }

        public DataSet SP_DATASOURCE_DRP()
        {
            OracleParameter[] param = new OracleParameter[11];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output }; //working status
            param[1] = new OracleParameter("T_TABLE1", OracleType.Cursor) { Direction = ParameterDirection.Output }; //category request
            param[2] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output }; //unit
            param[3] = new OracleParameter("T_TABLE3", OracleType.Cursor) { Direction = ParameterDirection.Output }; //quantity
            param[4] = new OracleParameter("T_TABLE4", OracleType.Cursor) { Direction = ParameterDirection.Output }; //PURCHASE TYPE
            param[5] = new OracleParameter("T_TABLE5", OracleType.Cursor) { Direction = ParameterDirection.Output }; //PURCHASE TYPE
            param[6] = new OracleParameter("T_TABLE6", OracleType.Cursor) { Direction = ParameterDirection.Output }; //SOS
            param[7] = new OracleParameter("T_TABLE7", OracleType.Cursor) { Direction = ParameterDirection.Output }; //SOS
            param[8] = new OracleParameter("T_TABLE8", OracleType.Cursor) { Direction = ParameterDirection.Output }; //ACOUNT CODE
            param[9] = new OracleParameter("T_TABLE9", OracleType.Cursor) { Direction = ParameterDirection.Output }; //PAY BY
            param[10] = new OracleParameter("T_TABLE10", OracleType.Cursor) { Direction = ParameterDirection.Output }; //PAY BY
            return DBHelper.getDataSet_SP("PK_GA.SP_DATASOURCE_DRP", param);
        }

    }
}