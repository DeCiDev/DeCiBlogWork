using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DeCiBlog.Web.Model
{
    public class Settings
    {
        public string SmtpServerDns
        {
            get { return ConfigurationManager.AppSettings["SmtpServerDns"]; } 
        }

        public string SmtpServerPort
        {
            get { return ConfigurationManager.AppSettings["SmtpServerPort"]; }
        }

        public bool HasToSmtpAuth
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["SmtpAuth"]); }
        }

        public string SmtpUserName
        {
            get { return ConfigurationManager.AppSettings["SmtpUserName"]; }
        }

        public string SiteName
        {
            get { return ConfigurationManager.AppSettings["SiteName"]; }
        }

        public string Description
        {
            get { return ConfigurationManager.AppSettings["Description"]; }
        }

        public string Keywords
        {
            get { return ConfigurationManager.AppSettings["Keywords"]; }
        }
        public string Author
        {
            get { return ConfigurationManager.AppSettings["Author"]; }
        }
        public string MatrikelNummer
        {
            get { return ConfigurationManager.AppSettings["MatrikelNummer"]; }
        }

        public string WelcomeSubject
        {
            get { return ConfigurationManager.AppSettings["WelcomeSubject"]; }
        }
        public string WelcomeMailbody
        {
            get { return ConfigurationManager.AppSettings["WelcomeMailbody"]; }
        }
        public string ForgottenPasswordSubject
        {
            get { return ConfigurationManager.AppSettings["ForgottenPasswordSubject"]; }
        }
        public string ForgottenPasswordMailbody
        {
            get { return ConfigurationManager.AppSettings["ForgottenPasswordMailbody"]; }
        }
    }
}