/*
 * Author:     NguuNguyen
 * Create Date: 2012-03-07
 * Description: present a User table
 * ---------------------------------
 * Deveoper:    VanXuan
 * Date:        2012-03-08
 */

using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class UserEntity
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string SalesforceId { get; set; }
        public int IPRestriction { get; set; }
        public string StartIP { get; set; }
        public string EndIP { get; set; }
        public bool IsActive { get; set; }
        public bool ResetPass { get; set; }
        public string StaffId { get; set; }
        public string Saver { get; set; }
        public string UpdateUID { get; set; }
        public string GroupID { get; set; }
        public string Corporation { get; set; }
        public string Department { get; set; }
        public string Team { get; set; }
        public string Section { get; set;}
        public string DEPTCODE { get; set; }
        
    }
    public class GroupEntity
    {
        public string Name { get; set; }
        public string USER_ID { get; set; }
        public string Group_Name { get; set; }
        public string GROUP_ID { get; set; }
        public string p_UID { get; set; }
        public bool p_ISACTIVE { get; set; }
        public bool Isedit { get; set; }
    }
}