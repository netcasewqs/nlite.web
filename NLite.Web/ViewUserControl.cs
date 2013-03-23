using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using NLite.Web.Internal;
using NLite.Globalization;
using NLite.Binding;
using System.Web;
using System.Collections.Specialized;

namespace NLite.Web
{
    [FileLevelControlBuilder(typeof(ViewUserControlControlBuilder))]
    public class ViewUserControl:UserControl
    {
        protected HtmlHelper Html
        {
            get
            {
                return (Page as ViewPage).Html;
            }
        }

        
    }
}
