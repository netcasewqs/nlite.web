using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace NLite.Web.Internal
{
    [ControlBuilder(typeof(ViewTypeControlBuilder))]
    [NonVisualControl]
    class ViewType : Control
    {
        private string _typeName;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string TypeName
        {
            get
            {
                return _typeName ?? String.Empty;
            }
            set
            {
                _typeName = value;
            }
        }
    }
}
