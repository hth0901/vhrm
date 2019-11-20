using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net;

namespace vhrm.FrameWork.Utility
{
    [Serializable]
    public class ToolHelper
    {
        public static string CacheOrg ="CacheOrg";
        public static string CacheSql = "CacheSql";

        public static int IP2INT(string IP)
        {
            return BitConverter.ToInt32(IPAddress.Parse(IP).GetAddressBytes().Reverse().ToArray(), 0);
            //return BitConverter.ToInt32(IPAddress.Parse(IP).GetAddressBytes(), 0);
        }
        public static string INT2IP(int IntIP)
        {
            return new IPAddress(BitConverter.GetBytes(IntIP).Reverse().ToArray()).ToString();
            //return new IPAddress(BitConverter.GetBytes(IntIP)).ToString();
        }
        public static bool IPValidate(string IP)
        {
            IPAddress ot;
            bool valid = false;
            if (string.IsNullOrEmpty(IP))
            {
                valid = false;
            }
            else
            {
                valid = IPAddress.TryParse(IP, out ot);
            }
            return valid;
        }

        //Format Point
        public static string FormatDouble(double Num)
        {
            try
            {
                return String.Format("{0:N}", Num).Replace(".00", "");
            }
            catch
            {
                return string.Empty;
            }
        }

        //GetCurrentPageName
        public static string GetCurrentPageName()
        {
            string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }

        //Convert string YMD to DateTime()
        public static string ConvertYMDtoDateTime(string strYMD)
        {
            string Result = "";
            if (strYMD.Length < 8)
                return Result;
            try
            {
                DateTime dtime = DateTime.Now;
                string[] ListYMD = new string[3];
                ListYMD[0] = strYMD.Substring(0, 4);
                ListYMD[1] = strYMD.Substring(4, 2);
                ListYMD[2] = strYMD.Substring(6, 2);

                dtime = DateTime.Parse(ListYMD[0] + "/" + ListYMD[1] + "/" + ListYMD[2]);
                return dtime.ToString("yyyy-MM-dd");
            }
            catch
            { //chuoi ko dung dinh dang
            }
            return Result;
        }

        public static string ConvertStringDateTime(string strDataTime,bool IsValid)
        {
            string Result = "";
            try
            {
                DateTime dt = DateTime.Parse(strDataTime.Trim());
                Result = dt.ToString("yyyy-MM-dd");
            }
            catch
            {
                Result = (IsValid==true?"###":""); //chuoi ko dung dinh dang
            }

            return Result;
        }

        public static string ConvertStringDouble(string strDouble)
        {
            string Result = "";
            try
            {
                double Point = double.Parse(strDouble.Trim());
                return FormatDouble(Point);
            }
            catch
            {
                Result = "###"; //chuoi ko dung dinh dang
            }

            return Result;
        
        }
        


        // Get the key from config file (AppSetting)
        public static string GetAppSetting(string key)
        {
            try
            {
                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                return (string)settingsReader.GetValue(key, typeof(String));

            }
            catch
            {
                return string.Empty;
            }
        }



        //Sub string have space
        public static string SubString(string value, int length)
        {
            string Result = string.Empty;

            value = value.Trim();
            if (value.Length <= length)
                Result = value;
            else
            {
                string strContent = value.Substring(0, length);
                string characternext = value.Substring(length, 1);
                if (characternext != " ")
                {
                    int k = strContent.LastIndexOf(" ");
                    Result = (k < 0 ? strContent : strContent.Substring(0, k));
                }
            }

            return Result;

        }

        //Remove All Html Tag
        public static string RemoveAllHtmlTag(string content)
        {
            string result = content;
            string[] removeTagArray = new string[] { "b", "a", "script", "i", "ul", "li", "ol", "font", "span", "div", "u" };
            foreach (string removeTag in removeTagArray)
            {
                string regExpressionToRemoveBeginTag = string.Format("<{0}([^>]*)>", removeTag);
                Regex regEx = new Regex(regExpressionToRemoveBeginTag, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                result = regEx.Replace(result, "");

                string regExpressionToRemoveEndTag = string.Format("</{0}([^>]*)>", removeTag);
                regEx = new Regex(regExpressionToRemoveEndTag, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                result = regEx.Replace(result, "");
            }
            return result;
        }

        //Get Session
        public static object GetSession(string key)
        {

            if (HttpContext.Current.Session[key] == null)
                return null;
            else
                return HttpContext.Current.Session[key];

        }

        //Delete Session
        public static void DeleteSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }


        //Set Session
        public static void SetSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }

        //Set Cookie
        public static void SetCookie(string key, string value)
        {
            HttpCookie _cookie = new HttpCookie(key, value);
            _cookie.Expires = DateTime.Now.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(_cookie);
        }

        //Delete Cookie by key
        public static void DeleteCookie(string key)
        {
            HttpCookie _cookie = new HttpCookie(key, null);
            _cookie.Expires = DateTime.Now;
            HttpContext.Current.Response.Cookies.Add(_cookie);
        }

        //Get Value of Cookie
        public static string GetCookie(string key)
        {
            string Result = string.Empty;
            if (HttpContext.Current.Request.Cookies[key] != null)
                Result = HttpContext.Current.Request.Cookies[key].Value;

            return Result;
        }

        //get querystring
        public static string GetQueryString(string key)
        {
            string Result = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                if (HttpContext.Current.Request.QueryString[key] != null)
                    Result = HttpContext.Current.Request.QueryString[key].ToString().Trim();
            }

            return Result;
        }

        //check string is datetime --not  finished
        public static bool IsDateTime(string strDateTime)
        {
            if (string.IsNullOrEmpty(strDateTime))
                return false;

            try
            {
                DateTime dt = DateTime.Parse(strDateTime);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //check string is datetime --not  finished
        public static bool IsDateTime(string strDateTime, string strFormat)
        {
            if (string.IsNullOrEmpty(strDateTime))
                return false;

            try
            {
                DateTime dt = DateTime.Parse(strDateTime);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //check string is valid Decimal
        public static bool IsDecimal(string strDecimal)
        {
            if (string.IsNullOrEmpty(strDecimal))
                return false;

            try
            {
                decimal Num = decimal.Parse(strDecimal);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //check string is valid Number
        public static bool IsNumber(string strNumber)
        {
            if (string.IsNullOrEmpty(strNumber))
                return false;

            try
            {
                int Num = int.Parse(strNumber);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Random Password
        public static string RandomPassword(int LenPass)
        {
            string passwordString = "";

            if (LenPass > 5)
            {
                string allowedChars = @"a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,
                                    A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,
                                    1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

                char[] sep = { ',' };
                string[] arr = allowedChars.Split(sep);

                string temp = "";
                Random rand = new Random();
                for (int i = 0; i < LenPass; i++)
                {
                    temp = arr[rand.Next(0, arr.Length)];
                    passwordString += temp;
                }

            }
            return passwordString;
        }


        public static void ExportExcel(string FileName, GridView _gridView, DataTable ojData)
        {
            if (string.IsNullOrEmpty(FileName))
                FileName = "Report-" + DateTime.Now.ToString("dd-MM-yyyy");

            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + FileName + ".xls");
            HttpContext.Current.Response.ContentType = "application/vnd.xls";
            HttpContext.Current.Response.Charset = "utf-8";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw); //grid.AllowPaging = false; //grid.DataBind(); 

            _gridView.DataSource = ojData;
            _gridView.DataBind();
            _gridView.RenderControl(htw);

            HttpContext.Current.Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">");
            HttpContext.Current.Response.Output.Write(sw.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        #region GenerateID
        // Generate a generated ID from the date and time
        private static String generatedID
        {
            // create a read only unique ID
            get { return String.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond); }
        }
        public static String ReturnUniqueID(EUniqueIDFormat format)
        {
            // return value
            String modifiedID = "";
            // create a return value
            String capturedID = generatedID;

            // select which format the ID should take
            switch (format)
            {
                // text only
                case (EUniqueIDFormat.Text):
                    {
                        // work through each character
                        foreach (Char idElement in capturedID)
                        {
                            // expose its int value, + 16 for ASCII offset to captials
                            modifiedID += (Char)((Int32)idElement + 17);
                        }
                        break;
                    }
                // text and numeric
                case (EUniqueIDFormat.Combined):
                    {
                        // work through each character
                        foreach (Char idElement in capturedID)
                        {
                            // if the characters ascii value is even
                            if ((Int32)idElement % 2 == 0)
                            {
                                // expose its int value, + 16 for ASCII offset to captials
                                modifiedID += (Char)((Int32)idElement + 17);
                            }
                            // element must be odd
                            else
                            {
                                // just add the element as its numeric form
                                modifiedID += idElement;
                            }
                        }
                        break;
                    }
                case (EUniqueIDFormat.Numeric):
                    {
                        // just set ID
                        modifiedID = capturedID;
                        break;
                    }
                default:
                    {
                        // throw excetion
                        throw new Exception("Unique format type is invalid");
                    }
            }

            // retun ID
            return modifiedID;
        }
        #endregion




    }

    /// <summary>
    /// Enumeration of UniqueID types
    /// </summary>
    public enum EUniqueIDFormat { Numeric = 0, Text, Combined }
}
