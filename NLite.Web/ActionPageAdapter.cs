using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.Adapters;
using System.Collections;
using System.Reflection;
using NLite.Reflection;
using NLite.Net;
using NLite.Binding;
using NLite.Collections;
using NLite.Domain;
using System.Web.UI;

namespace NLite.Web.Adapters
{
    
    /// <summary>
    /// 用户控件方法映射调用适配器，一次页面请求只能处理一个用户控件内的公共方法
    /// </summary>
    /// <remarks>方法必须是公共的、没有返回值、方法的参数不允许是返回值参数或者输出参数、并且不允许是泛型方法</remarks>
    public class UserControlActionAdapter : ControlAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param serviceDispatcherName="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ActionExecutor.Execute(base.Control);
        }

     
    }

    /// <summary>
    /// 页面方法映射调用适配器，一次页面请求只能处理一个页面内的公共方法
    /// </summary>
    /// <remarks>方法必须是公共的、没有返回值、方法的参数不允许是返回值参数或者输出参数、并且不允许是泛型方法</remarks>
    public class PageActionAdapter : PageAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param serviceDispatcherName="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ActionExecutor.Execute(base.Page);
        }

    }

   
}
