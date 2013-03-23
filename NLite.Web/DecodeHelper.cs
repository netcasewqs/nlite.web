using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NLite.Web
{
    public static class DecodeHelper
    {
        static readonly Dictionary<string, string> injectDatas;
        static DecodeHelper()
        {
            injectDatas = new Dictionary<string, string>();
            injectDatas[@"&ltscript[^>]*?>.*?</script>"] = ""; //删除脚本

            //删除脚本
            injectDatas[@"&ltscript[^>]*?>.*?</script>"] = "";
            //删除HTML
            injectDatas[@"<(.[^>]*)>"] = "";
            injectDatas[@"([\r\n])[\s]+"] = "";
            injectDatas[@"-->"] = "";
            injectDatas[@"<!--.*"] = "";

            injectDatas[@"&(quot|#34);"] = "\"";
            injectDatas[@"&(amp|#38);"] = "&";
            injectDatas[@"&(lt|#60);"] = "<";
            injectDatas[@"&(gt|#62);"] = ">";
            injectDatas[@"&(nbsp|#160);"] = " ";
            injectDatas[@"&(iexcl|#161);"] = "\xa1";
            injectDatas[@"&(cent|#162);"] = "\xa2";
            injectDatas[@"&(pound|#163);"] = "\xa3";
            injectDatas[@"&(copy|#169);"] = "\xa9";
            injectDatas[@"&#(\d+);"] = "";


            //删除与数据库相关的词 
            //injectDatas[ "select"]= "";
            //injectDatas[ "insert"]= "";
            //injectDatas["update"] = "";
            injectDatas[" delete from "] = " ";
            //injectDatas[ "count''"]= "";
            injectDatas[" drop table "] = " ";
            injectDatas[" truncate "] = " ";
            injectDatas[" asc "] = " ";
            //injectDatas[ " mid "]= " ";
            injectDatas[" char "] = " ";

            injectDatas[" xp_cmdshell "] = " ";
            injectDatas[" exec master "] = " ";
            injectDatas[" net localgroup administrators "] = " ";

        }

        public static string Decode(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            str = str.Trim();

            foreach (var kvp in injectDatas)
                str = Regex.Replace(str, kvp.Key, kvp.Value, RegexOptions.IgnoreCase);

            return str;
        }

    }
}
