using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NLite.Collections;
using NLite.Threading;

namespace NLite.Web
{
    public class ComponentLifestyleModule : CompositeDisposable,IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(context_EndRequest);
            AddDisposable(Disposable.Create(null, () => context.EndRequest -= context_EndRequest));
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            var httpContext = HttpContext.Current;
            if (httpContext == null)
                return;

            Local.Clear();

            var values = httpContext.Items.Values.Cast<object>().ToArray();
            for (int i = 0; i < values.Length; i++)
            {
                var item = values[0];
                if (item == null)
                    continue;

                var dis = item as IDisposable;
                if (dis != null)
                {
                    try
                    {
                        dis.Dispose();
                    }
                    catch { }
                }

                item = null;

            }

            httpContext.Items.Clear();
        }
    }
}
