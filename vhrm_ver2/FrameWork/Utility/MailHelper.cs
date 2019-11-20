using System;
using System.IO;
using System.Collections;


namespace vhrm.FrameWork.Utility
{
    [Serializable]
    public class MailHelper
    {
        public static string HostName = "smtp.googlemail.com";
        //public static string MailCredential = "noreply.hst@gmail.com";
        public static string MailCredential = "tae.voxuan@gmail.com";
        public static string PassCredential = "taekwondo9999";
        public static string MailFrom = "tae.voxuan@gmail.com";
         
        public static bool SendMail(string Subject, string Body, string From, string To)
        {
            return SendMail(Subject, Body, From, To, "", "",null);
        }

        public static bool SendMail(string Subject, string Body, string From, string To, ArrayList attachments)
        {
            return SendMail(Subject, Body, From, To, "", "", attachments);
        }

        public static bool SendMail(string Subject, string Body,string From, string To, string Cc, string Bcc)
        {
            return SendMail(Subject, Body, From, To, Cc, Bcc,null);
        }

        public static bool SendMail(string Subject, string Body, string From,
                                              string To, string Cc, string Bcc, ArrayList attachments)
        {
            try
            {
                System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(From, To);
                mm.Subject = Subject;
                mm.Body = Body;

               if (!string.IsNullOrEmpty(Cc))
                   mm.CC.Add(Cc);
              
              if (!string.IsNullOrEmpty(Bcc))
                  mm.Bcc.Add(Bcc);

              if (attachments != null && attachments.Count > 0)
              {
                  foreach (string attach in attachments)
                  {
                      if (File.Exists(attach) == true)
                      {
                          System.Net.Mail.Attachment attached = new System.Net.Mail.Attachment(attach, System.Net.Mime.MediaTypeNames.Application.Octet);
                          mm.Attachments.Add(attached);
                      }
                  }
              }

                mm.IsBodyHtml = false;
                mm.Priority = System.Net.Mail.MailPriority.High;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential(MailCredential, PassCredential);
                smtp.Host = HostName;
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(mm);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
                return false;
            }

        }

        //check string is valid Email
        public static bool IsEmail(string s)
        {
            try
            {
                return new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$").IsMatch(s);
            }
            catch
            {
                return false;
            }
        }
    }
  }

