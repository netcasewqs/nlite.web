using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;

namespace NLite.Web
{
    public static class HttpHandlerFactory
    {
        static IKernel Kernel;

        private static void CheckKernel()
        {
            if (Kernel != null)
                return;
            Kernel = ServiceRegistry.Current as IKernel;
            Guard.NotNull(Kernel, "Kernal");
        }

        public static IHttpHandler GetHandler(string virtualPath)
        {
            IHttpHandler handler = null;
            var handlerType = BuildManager.GetCompiledType(virtualPath);
            if (handlerType == null)
                return handler;

            CheckKernel();
            
            var componentContext = Kernel.GetComponentContextByNamedArgs(virtualPath, null);
            if (componentContext != null
                && componentContext.Component.Implementation == handlerType)
            {
                handler = componentContext.LifestyleManager.Get(componentContext) as IHttpHandler;
                RegisterUserControl(handler);
                return handler;
            }

            var componentInfo = new ComponentInfo(virtualPath, typeof(IHttpHandler), handlerType, LifestyleFlags.Transient);
            lock (Kernel)
            {
                if (Kernel.HasRegister(virtualPath))
                    Kernel.UnRegister(virtualPath);
                Kernel.Register(componentInfo);
            }

            handler = Kernel.Get<IHttpHandler>(virtualPath);

            RegisterUserControl(handler);
            return handler;
        }

        private static void RegisterUserControl(IHttpHandler handler)
        {
            var page = handler as Page;
           
            Action<Control> RegisterUserControl = null;
            Action<ControlCollection> RegisterControls = null;

            EventHandler onPageLoad = null;
            onPageLoad = (sender, e) =>
                 {

                     RegisterControls = controls =>
                     {
                         foreach (Control c in controls)
                             RegisterUserControl(c);
                     };

                     RegisterUserControl = control =>
                     {
                         var userControl = control as UserControl;
                         if (userControl != null)
                             Kernel.Compose(userControl);
                         RegisterControls(control.Controls);
                     };

                     RegisterControls(page.Controls);

                     page.Load -= onPageLoad;
                 };

            if (page != null)
                page.Load += onPageLoad;

        }
    }
}
