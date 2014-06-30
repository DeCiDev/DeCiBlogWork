using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DeCiBlogWeb.Services
{
    public class MockMailService : IMailService 
    {
        public bool SendMail(string @from, string to, string subject, string body)
        {
            Debug.WriteLine(string.Format("SendMail: {0}", subject));
            return true;
        }
    }
}