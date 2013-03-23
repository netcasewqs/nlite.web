using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Diagnostics;

namespace NLite.Web
{
	public static class WebHelper
	{
        public static string GetIpAddress()
        {
            string userIP;
            HttpRequest rq = HttpContext.Current.Request;
            // 如果使用代理，获取真实IP   
            if (rq.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                userIP = rq.ServerVariables["REMOTE_ADDR"];
            else
                userIP = rq.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (userIP == null || userIP == "")
                userIP = rq.UserHostAddress;
            return userIP;  
        }
	}

    internal static partial class Guard
    {
        [DebuggerStepThrough]
        public static void NotNull(object argumentValue,
                                         string argumentName)
        {
            if (argumentValue == null)
                throw new ArgumentNullException(argumentName);
        }


        [DebuggerStepThrough]
        public static void NotNullOrEmpty(string argumentValue,
                                                 string argumentName)
        {
            if (argumentValue == null || argumentValue.Length == 0)
                throw new ArgumentNullException(argumentName);
        }
    }
}
