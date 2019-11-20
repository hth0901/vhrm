/*
 * author: Nguyen Duy Hung
 * Date: 2017.05.14
 * Desc: New function to get, check, view Annual leave
 
 /* =================================================================
 * --> SỬA LẠI TOÀN BỘ CÔNG THỨC PHÉP NĂM, TÍNH LẺ TỚI 0.5
 * --> Request by chị Hà Bình (
 * 1. Report Total Annual Leave (this)
 * 2. Severance pay
 * 3. Annual Leave View
 * 4. Function get Annual Leave
 * 5. Check annual Leave (enter absence)
 * 6. Transfer Annual Leave
 * 7. Enter absence -> Cho phép đăng ký 1/2 ngày phép năm
 * 8. Daily Work Confirm -> chấm công cho 1/2 ngày phép năm
 * 9. Tăng ca cho 1/2 phép năm
 * 10.Tính lương tính 1/2 ngày phép năm
 * =================================================================

  Công thức hiện tại:
  - Vào làm việc từ 01 đến 15  hoặc nghỉ việc từ ngày 16 đến cuối tháng thì được tính phép năm từ tháng đó
  - Vào làm từ ngày 16 đến cuối tháng hoặc nghỉ việc từ ngày 01 đến ngày 15 thì không được tính phép năm của tháng đó
  Nguyên tắc làm tròn khi tính phép năm (bao gồm cả phép năm thâm niên):
  - Từ 05 trở lên thì làm tròn thành 1
  - Từ dưới 0.5 trở xuống thì làm tròn bằng 0
  
  Công thức mới:
  - Đối với CNV mới vào làm hoặc nghỉ việc thì công thức tính như sau:
  CNV mới: thời gian làm việc để tính phép năm =  số ngày dương lịch từ ngày vào làm đến cuối tháng / số ngày dương lịch của tháng đó
  CN nghỉ việc: thời gian làm việc để tính phép năm = số ngày dương lịch từ ngày 01 của tháng đến ngày nghỉ việc / số ngày dương lịch của tháng đó
  - Nguyên tắc làm tròn khi tính phép năm (bao gồm cả phép năm thâm niên):
  0.1<= số ngày phép lẻ <= 0.5 ---> = 0.5 ngày
  0.5 < số ngày phép lẻ <= 1 ----> = 1 ngày
  Ví dụ: công nhân vào làm ngày 16/05/2017 thì
  - Thời gian làm việc tính phép năm = 16/31 = 0.52 tháng
  - Phép năm của năm 2017 (từ 16/05/2017 đến 31/12/2017) = 7 tháng + 0.52 tháng = 7.52 tháng
  - Số phép năm được hưởng của năm 2017 = 7.52 *14/12 = 8.8 ngày ---> làm tròn thành 9 ngày
  Ví dụ: công nhân nghỉ việc từ ngày 05/05/2017 thì
  - Thời gian làm việc tính phép năm = 5/31 = 0.16
  - Phép năm của năm 2017 (từ 01/01/2017 đến 05/05/2017) = 4 + 0.16 = 4.16 tháng
  - Số  phép năm được hưởng của năm 2017 = 4.16 * 14/12 = 4.85 ngày ---> làm tròn thành 5 ngày
  Ví dụ: Người lao động vào tháng 10/2012, đến tháng 10/2017 sẽ được cộng thêm 1 ngày phép năm theo thâm niên
  - Thời gian làm việc để hưởng phép năm theo thâm niên = 3 tháng / 12 tháng = 0.25 ---> làm tròn thành 0.5 ngày
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class aAnnualLeaveAccess_v2
    {
        public static DataTable GetData_ViewAnnualleave(string deptcode, string pMonth, string pSysEmpID, string pStatus)
        {
            OracleParameter[] param = new OracleParameter[5];

            param[0] = new OracleParameter("PDEPTCODE", deptcode);
            param[1] = new OracleParameter("PMONTH", pMonth);
            param[2] = new OracleParameter("PSYSEMPID", pSysEmpID);
            param[3] = new OracleParameter("PSTATUS", pStatus);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) {Direction = ParameterDirection.Output};

            return DBHelper.getDataTable_SP("PKTIMESHEET_ANNUALLEAVE_V2.SP_TOTALANNUALLEAVE_VIEW", param);
        }



        /// <summary>
        /// add by ndhung 2018.01.30
        /// use for dynamic configuration of when any corporation use new Annual leave fomular
        /// firstly PKBT, PKLA, PKMT not use new fomular
        /// now: PKBT start to use from 01/2018  
        /// </summary>
        /// <param name="deptcode"></param>
        /// <param name="pMonth"></param>
        /// <returns></returns>
        public static DataTable GetData_CorpUseNewFomular(string deptcode, string pMonth)
        {
            OracleParameter[] param = new OracleParameter[3];

            param[0] = new OracleParameter("PCORP", deptcode);
            param[1] = new OracleParameter("PMONTH", pMonth);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PKTIMESHEET_ANNUALLEAVE_V2.SP_CHECK_CORP_WITH_FOMULAR_V2", param);
        }
    }
}