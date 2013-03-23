using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using NLite;
using NLite.Serialization;

namespace NLite.Web
{

    [Component]
    public class DefaultJsonSerializer : ISerializer
    {
        private JavaScriptSerializer ser = new JavaScriptSerializer();
        public string Serialize(object o)
        {
            return ser.Serialize(o);
        }

        public object Deserialize(string jsonString,Type type)
        {
            return ser.DeserializeObject(jsonString);
        }
    }
}
