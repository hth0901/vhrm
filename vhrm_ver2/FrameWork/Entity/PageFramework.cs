using System.Web.UI;
using System.Data;
using System.Web;


namespace vhrm.FrameWork.Entity
{
    public class PageInfo
    {
        Page page;

        public PageInfo(Page page)
        {
            this.page = page;
        }

        public void Instance()
        {
            UserId = "";
            UserNm = "";
            UserCd = "";
            CorporationCd = "";
            CorporationNm = "";
            DepartmentCd = "";
            TeamCd = "";
            SectionCd = "";

            DeptCdDefault = "";
            DeptFullCdDefault = "";
            DeptNmDefault = "";

            GroupId = "";
            StaffId = "";
            IsInsert = false;
            IsUpdate = false;
            IsDelete = false;
            IsRead = false;
            IsReport = false;
            IsExcel = false;
            IsConfirm = false;
            
        }

        public string DeptCdDefault
        {
            get
            {
                if (page.Session["DeptCdDefault"] == null)
                    return "";
                return page.Session["DeptCdDefault"].ToString();
            }
            set
            {
                page.Session.Add("DeptCdDefault", value);
            }
        }

        public string DeptFullCdDefault
        {
            get
            {
                if (page.Session["DeptFullCdDefault"] == null)
                    return "";
                return page.Session["DeptFullCdDefault"].ToString();
            }
            set
            {
                page.Session.Add("DeptFullCdDefault", value);
            }
        }

        public string DeptNmDefault
        {
            get
            {
                if (page.Session["DeptNmDefault"] == null)
                    return "";
                return page.Session["DeptNmDefault"].ToString();
            }
            set
            {
                page.Session.Add("DeptNmDefault", value);
            }
        }
        public string Email
        {
            get
            {
                if (page.Session["Email"] == null)
                    return "";
                return page.Session["Email"].ToString();
            }
            set
            {
                page.Session.Add("Email", value);
            }
        }
        public string IsLeafDefault
        {
            get
            {
                if (page.Session["IsLeafDefault"] == null)
                    return "";
                return page.Session["IsLeafDefault"].ToString();
            }
            set
            {
                page.Session.Add("IsLeafDefault", value);
            }
        }
        public string ListManagementDepartment
        {
            get
            {
                if (page.Session["ListManagementDepartment"] == null)
                    return "";
                return page.Session["ListManagementDepartment"].ToString();
            }
            set
            {
                page.Session.Add("ListManagementDepartment", value);
            }
        }
        public string CorporationCd
        {
            get
            {
                if (page.Session["CorporationCd"] == null)
                    return "";
                return page.Session["CorporationCd"].ToString();
            }
            set
            {
                page.Session.Add("CorporationCd", value);
            }
        }
        public string CorporationNm
        {
            get
            {
                if (page.Session["CorporationNm"] == null)
                    return "";
                return page.Session["CorporationNm"].ToString();
            }
            set
            {
                page.Session.Add("CorporationNm", value);
            }
        }
        public string DepartmentCd
        {
            get
            {
                if (page.Session["DepartmentCd"] == null)
                    return "";
                return page.Session["DepartmentCd"].ToString();
            }
            set
            {
                page.Session.Add("DepartmentCd", value);
            }
        }
        public string TeamCd
        {
            get
            {
                if (page.Session["TeamCd"] == null)
                    return "";
                return page.Session["TeamCd"].ToString();
            }
            set
            {
                page.Session.Add("TeamCd", value);
            }
        }
        public string SectionCd
        {
            get
            {
                if (page.Session["SectionCd"] == null)
                    return "";
                return page.Session["SectionCd"].ToString();
            }
            set
            {
                page.Session.Add("SectionCd", value);
            }
        }
        public string UserId
        {
            get
            {
                if (page.Session["EmpId"] == null)
                    return "";
                return page.Session["EmpId"].ToString();
            }
            set
            {
                page.Session.Add("EmpId", value);
            }
        }
        public string UserCd
        {
            get
            {
                if (page.Session["EmpCd"] == null)
                    return "";
                return page.Session["EmpCd"].ToString();
            }
            set
            {
                page.Session.Add("EmpCd", value);
            }
        }
        public string UserNm
        {
            get
            {
                if (page.Session["EmpNm"] == null)
                    return "Administrator";
                return page.Session["EmpNm"].ToString();
            }
            set
            {
                page.Session.Add("EmpNm", value);
            }
        }
      
        public string GroupId
        {
            get
            {
                if (page.Session["GroupId"] == null)
                    return "";
                return page.Session["GroupId"].ToString();
            }
            set
            {
                page.Session.Add("GroupId", value);
            }
        }
        public string StaffId
        {
            get
            {
                if (page.Session["StaffId"] == null)
                    return "";
                return page.Session["StaffId"].ToString();
            }
            set
            {
                page.Session.Add("StaffId", value);
            }
        }
        public string LangId
        {
            get
            {
                string langid = Utility.ToolHelper.GetCookie("Login_Lang");
                return (string.IsNullOrEmpty(langid) ? "en" : langid);
            }
            set
            {
                Utility.ToolHelper.SetCookie("Login_Lang", value);
            }
        }

        public string IsAllow
        {
            get
            {
                if (page.Session["IsAllow"] == null)
                    return "";
                return page.Session["IsAllow"].ToString();
            }
            set
            {
                page.Session.Add("IsAllow", value);
            }
        }
        public bool IsInsert { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsRead { get; set; }
        public bool IsReport { get; set; }
        public bool IsExcel { get; set; }
        public bool IsConfirm { get; set; }
      
    }
}