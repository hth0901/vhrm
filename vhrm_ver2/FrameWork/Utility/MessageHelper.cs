using System;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ShowErrorFunction
/// </summary>

namespace vhrm.FrameWork.Utility
{
    [Serializable]
    public class MessageHelper
    {
        public MessageHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static void ShowMessage(Control page,TextBox txt, string msgString)
        {
            msgString = msgString.Replace("'", "\\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "MsgBox", "alert('" + msgString + "');", true);
            txt.Focus();
        }
        public static void ShowMessage(Control page, string msgString)
        {
            msgString = msgString.Replace("'", "\\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "MsgBox", "alert('" + msgString + "');", true);

        }

        public static void ShowMessage(Control page, string msgString, string url)
        {
            msgString = msgString.Replace("'", "\\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "MsgBox", "alert('" + msgString + "'); window.location='" + url  + "';", true);

        }
       
    }
}
