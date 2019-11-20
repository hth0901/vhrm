/*
 * AUthor: Tran Cong Tho
 * Create Date:10/03/2012 
 */

namespace vhrm.FrameWork.Entity
{
    public class AuthorizationEntity
    {
        public int MENU_RIGHT_ID { get; set; }
        public string OWNER_ID { get; set; }
        public string MENU_ID { get; set; }
        public bool IS_VIEW { get; set; }
        public bool IS_ADD { get; set; }
        public bool IS_CONFIRM { get; set; }
        public bool IS_UNCONFIRM { get; set; }
        public bool IS_UPDATE { get; set; }
        public bool IS_DELETE { get; set; }
        public bool IS_PRINT { get; set; }
        public bool IS_EXPORT { get; set; }
        public bool IS_USER { get; set; }
        public string CREATE_UID { get; set; }
        public string UPDATE_UID { get; set; }

        public AuthorizationEntity()
        {
            this.OWNER_ID = "";
            this.MENU_ID = "";
           this.IS_UNCONFIRM= this.IS_ADD = this.IS_DELETE = this.IS_EXPORT = this.IS_PRINT = this.IS_UPDATE = this.IS_VIEW = false;
        }
    }
}