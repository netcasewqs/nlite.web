using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Reflection;
using NLite.Reflection;
using NLite.Collections;

namespace NLite.Web
{
    /// <summary>
    /// Http监听器接口，是IHttpModule的适配器接口
    /// </summary>
    public interface IHttpListener
    {

        /// <summary>
        /// 当 ASP.NET 获取与当前请求关联的当前状态（如会话状态）时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnAcquireRequestState(object sender, EventArgs e);

        /// <summary>
        /// 当安全模块已建立用户标识时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnAuthenticateRequest(object sender, EventArgs e);

        /// <summary>
        /// 当安全模块已验证用户授权时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnAuthorizeRequest(object sender, EventArgs e);

        /// <summary>
        /// 在 ASP.NET 响应请求时作为 HTTP 执行管线链中的第一个事件发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnBeginRequest(object sender, EventArgs e);

        /// <summary>
        /// 在释放应用程序时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDisposed(object sender, EventArgs e);

        /// <summary>
        /// 在 ASP.NET 响应请求时作为 HTTP 执行管线链中的最后一个事件发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnEndRequest(object sender, EventArgs e);

        /// <summary>
        /// 当引发未经处理的异常时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnError(object sender, EventArgs e);

        /// <summary>
        /// 恰好在 ASP.NET 为当前请求执行任何记录之前发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnLogRequest(object sender, EventArgs e);

        /// <summary>
        /// 基础结构。在选择了用来响应请求的处理程序时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMapRequestHandler(object sender, EventArgs e);

        /// <summary>
        /// 在已获得与当前请求关联的请求状态（例如会话状态）时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPostAcquireRequestState(object sender, EventArgs e);

        /// <summary>
        /// 当安全模块已建立用户标识时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPostAuthenticateRequest(object sender, EventArgs e);

        /// <summary>
        /// 在当前请求的用户已获授权时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPostAuthorizeRequest(object sender, EventArgs e);

        /// <summary>
        /// 在 ASP.NET 处理完 LogRequest 事件的所有事件处理程序后发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPostLogRequest(object sender, EventArgs e);

        /// <summary>
        /// 在 ASP.NET 已将当前请求映射到相应的事件处理程序时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPostMapRequestHandler(object sender, EventArgs e);

        /// <summary>
        /// 在 ASP.NET 已完成所有请求事件处理程序的执行并且请求状态数据已存储时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPostReleaseRequestState(object sender, EventArgs e);

        /// <summary>
        /// 在 ASP.NET 事件处理程序（例如，某页或某个 XML Web service）执行完毕时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPostRequestHandlerExecute(object sender, EventArgs e);

        /// <summary>
        /// 在 ASP.NET 跳过当前事件处理程序的执行并允许缓存模块满足来自缓存的请求时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPostResolveRequestCache(object sender, EventArgs e);

        /// <summary>
        /// 在 ASP.NET 完成缓存模块的更新并存储了用于从缓存中为后续请求提供服务的响应后，发生此事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPostUpdateRequestCache(object sender, EventArgs e);

        /// <summary>
        /// 恰好在 ASP.NET 开始执行事件处理程序（例如，某页或某个 XML Web services）前发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPreRequestHandlerExecute(object sender, EventArgs e);

        /// <summary>
        /// 恰好在 ASP.NET 向客户端发送内容之前发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPreSendRequestContent(object sender, EventArgs e);

        /// <summary>
        /// 恰好在 ASP.NET 向客户端发送 HTTP 标头之前发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPreSendRequestHeaders(object sender, EventArgs e);

        /// <summary>
        /// 在 ASP.NET 执行完所有请求事件处理程序后发生。 该事件将使状态模块保存当前状态数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnReleaseRequestState(object sender, EventArgs e);

        /// <summary>
        /// 在 ASP.NET 完成授权事件以使缓存模块从缓存中为请求提供服务后发生，从而绕过事件处理程序（例如某个页或 XML Web services）的执行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnResolveRequestCache(object sender, EventArgs e);

        /// <summary>
        /// 当 ASP.NET 执行完事件处理程序以使缓存模块存储将用于从缓存为后续请求提供服务的响应时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnUpdateRequestCache(object sender, EventArgs e);
    }

    /// <summary>
    /// 模块监听管理器
    /// </summary>
    class ModuleManager
    {
        static Dictionary<Type, byte> RegisteredTypes = new Dictionary<Type, byte>();
        static Assembly CurrentAssembly = typeof(ModuleManager).Assembly;
        static Assembly NListAssembly = typeof(NLite.ServiceLocator).Assembly;
        static Assembly NdfAssembly = typeof(NLite.Domain.IServiceDispatcher).Assembly;


        internal class InnerListenerManager
        {
            private HashSet<IHttpListener> Items = new HashSet<IHttpListener>();
            private HttpApplication context;
            public void InitApplication(HttpApplication application)
            {
                context = application;
                foreach (var type in RegisteredTypes.Keys.ToArray())
                {
                    try
                    {
                        var item = Activator.CreateInstance(type) as IHttpListener;
                        Register(item);
                    }
                    catch (Exception e)
                    {
                        e.Handle();
                    }
                }
            }
            void OnAfterRegister(IHttpListener listner)
            {
                var methods = listner.GetType().GetMethods();
                var type = listner.GetType();
                foreach (var m in methods)
                {
                    if (m.DeclaringType != type)
                        continue;

                    try
                    {
                        AddEvent(listner, m);
                    }
                    catch (Exception e)
                    {
                        e.Handle();
                    }
                }
            }

            void AddEvent(IHttpListener listner, MethodInfo m)
            {
                switch (m.Name)
                {
                    case "OnAcquireRequestState":
                        context.AcquireRequestState += listner.OnAcquireRequestState;
                        break;
                    case "OnAuthenticateRequest":
                        context.AuthenticateRequest += listner.OnAuthenticateRequest;
                        break;
                    case "OnAuthorizeRequest":
                        context.AuthorizeRequest += listner.OnAuthorizeRequest;
                        break;
                    case "OnBeginRequest":
                        context.BeginRequest += listner.OnBeginRequest;
                        break;
                    case "OnDisposed":
                        context.Disposed += listner.OnDisposed;
                        break;
                    case "OnEndRequest":
                        context.EndRequest += listner.OnEndRequest;
                        break;

                    case "OnError":
                        context.Error += listner.OnError;
                        break;
                    case "OnLogRequest":
                        context.LogRequest += listner.OnLogRequest;
                        break;
                    case "OnMapRequestHandler":
                        context.MapRequestHandler += listner.OnMapRequestHandler;
                        break;
                    case "OnPostAcquireRequestState":
                        context.PostAcquireRequestState += listner.OnPostAcquireRequestState;
                        break;
                    case "OnPostAuthenticateRequest":
                        context.PostAuthenticateRequest += listner.OnPostAuthenticateRequest;
                        break;
                    case "OnPostAuthorizeRequest":
                        context.PostAuthorizeRequest += listner.OnPostAuthorizeRequest;
                        break;

                    case "OnPostLogRequest":
                        context.PostLogRequest += listner.OnPostLogRequest;
                        break;
                    case "OnPostMapRequestHandler":
                        context.PostMapRequestHandler += listner.OnPostMapRequestHandler;
                        break;
                    case "OnPostReleaseRequestState":
                        context.PostReleaseRequestState += listner.OnPostReleaseRequestState;
                        break;
                    case "OnPostRequestHandlerExecute":
                        context.PostRequestHandlerExecute += listner.OnPostRequestHandlerExecute;
                        break;
                    case "OnPostResolveRequestCache":
                        context.PostResolveRequestCache += listner.OnPostResolveRequestCache;
                        break;
                    case "OnPostUpdateRequestCache":
                        context.PostUpdateRequestCache += listner.OnPostUpdateRequestCache;
                        break;

                    case "OnPreRequestHandlerExecute":
                        context.PreRequestHandlerExecute += listner.OnPreRequestHandlerExecute;
                        break;
                    case "OnPreSendRequestContent":
                        context.PreSendRequestContent += listner.OnPreSendRequestContent;
                        break;
                    case "OnPreSendRequestHeaders":
                        context.PreSendRequestHeaders += listner.OnPreSendRequestHeaders;
                        break;
                    case "OnReleaseRequestState":
                        context.ReleaseRequestState += listner.OnReleaseRequestState;
                        break;
                    case "OnResolveRequestCache":
                        context.ResolveRequestCache += listner.OnResolveRequestCache;
                        break;
                    case "OnUpdateRequestCache":
                        context.UpdateRequestCache += listner.OnUpdateRequestCache;
                        break;
                }
            }

            void OnAfterUnRegister(IHttpListener listner)
            {
             
                var type = listner.GetType();

                var methods = listner.GetType().GetMethods();
                foreach (var m in methods)
                {
                    if (m.DeclaringType != type)
                        continue;
                    RemoveEvent(listner, m);
                }
            }

            private void RemoveEvent(IHttpListener listner, MethodInfo m)
            {
                switch (m.Name)
                {
                    case "OnAcquireRequestState":
                        context.AcquireRequestState -= listner.OnAcquireRequestState;
                        break;
                    case "OnAuthenticateRequest":
                        context.AuthenticateRequest -= listner.OnAuthenticateRequest;
                        break;
                    case "OnAuthorizeRequest":
                        context.AuthorizeRequest -= listner.OnAuthorizeRequest;
                        break;
                    case "OnBeginRequest":
                        context.BeginRequest -= listner.OnBeginRequest;
                        break;
                    case "OnDisposed":
                        context.Disposed -= listner.OnDisposed;
                        break;
                    case "OnEndRequest":
                        context.EndRequest -= listner.OnEndRequest;
                        break;

                    case "OnError":
                        context.Error -= listner.OnError;
                        break;
                    case "OnLogRequest":
                        context.LogRequest -= listner.OnLogRequest;
                        break;
                    case "OnMapRequestHandler":
                        context.MapRequestHandler -= listner.OnMapRequestHandler;
                        break;
                    case "OnPostAcquireRequestState":
                        context.PostAcquireRequestState -= listner.OnPostAcquireRequestState;
                        break;
                    case "OnPostAuthenticateRequest":
                        context.PostAuthenticateRequest -= listner.OnPostAuthenticateRequest;
                        break;
                    case "OnPostAuthorizeRequest":
                        context.PostAuthorizeRequest -= listner.OnPostAuthorizeRequest;
                        break;

                    case "OnPostLogRequest":
                        context.PostLogRequest -= listner.OnPostLogRequest;
                        break;
                    case "OnPostMapRequestHandler":
                        context.PostMapRequestHandler -= listner.OnPostMapRequestHandler;
                        break;
                    case "OnPostReleaseRequestState":
                        context.PostReleaseRequestState -= listner.OnPostReleaseRequestState;
                        break;
                    case "OnPostRequestHandlerExecute":
                        context.PostRequestHandlerExecute -= listner.OnPostRequestHandlerExecute;
                        break;
                    case "OnPostResolveRequestCache":
                        context.PostResolveRequestCache -= listner.OnPostResolveRequestCache;
                        break;
                    case "OnPostUpdateRequestCache":
                        context.PostUpdateRequestCache -= listner.OnPostUpdateRequestCache;
                        break;

                    case "OnPreRequestHandlerExecute":
                        context.PreRequestHandlerExecute -= listner.OnPreRequestHandlerExecute;
                        break;
                    case "OnPreSendRequestContent":
                        context.PreSendRequestContent -= listner.OnPreSendRequestContent;
                        break;
                    case "OnPreSendRequestHeaders":
                        context.PreSendRequestHeaders -= listner.OnPreSendRequestHeaders;
                        break;
                    case "OnReleaseRequestState":
                        context.ReleaseRequestState -= listner.OnReleaseRequestState;
                        break;
                    case "OnResolveRequestCache":
                        context.ResolveRequestCache -= listner.OnResolveRequestCache;
                        break;
                    case "OnUpdateRequestCache":
                        context.UpdateRequestCache -= listner.OnUpdateRequestCache;
                        break;
                }
            }

            public void Register(IHttpListener item)
            {
                if (!Items.Contains(item))
                {
                    Items.Add(item);
                    OnAfterRegister(item);
                }
            }

            public void Unregister(IHttpListener item)
            {
                if (Items.Contains(item))
                {
                    Items.Remove(item);
                    OnAfterUnRegister(item);
                }
            }

            public void Clear()
            {
                foreach (var item in Items.ToArray())
                    Unregister(item);
                Items.Clear();
            }
        }

        internal static Dictionary<HttpApplication, InnerListenerManager> Repository = new Dictionary<HttpApplication, InnerListenerManager>();
 
        /// <summary>
        /// 清除所有监听器
        /// </summary>
        public static void Clear(HttpApplication app)
        {
            InnerListenerManager instance;
            if (Repository.TryGetValue(app, out instance))
                instance.Clear();
        }

        /// <summary>
        /// 设置Application
        /// </summary>
        /// <param name="app"></param>
        public static void InitApplication(HttpApplication app)
        {
            InnerListenerManager instance;
            if (!Repository.TryGetValue(app, out instance))
            {
                RegisterTypeFromAppDomain();
                instance = new InnerListenerManager();
                Repository[app] = instance;
                instance.InitApplication(app);
            }
        }

        static void RegisterType(Type type)
        {
            if (RegisteredTypes.ContainsKey(type))
                return;
            RegisteredTypes[type] = 1;
        }

       

        /// <summary>
        /// 从指定的Assembly中注册模块监听器
        /// </summary>
        /// <param name="asm"></param>
        static void RegisterFromAssembly(Assembly asm)
        {
            if (asm == null)
                throw new ArgumentNullException("asm");
            if (asm == CurrentAssembly || asm == NListAssembly || asm == NdfAssembly)
                return;
            var types = asm.GetTypes()
                .Where(t => !t.IsAbstract
                           && !t.IsInterface
                           && typeof(IHttpListener).IsAssignableFrom(t)
                           && t.GetConstructor(Type.EmptyTypes) != null)
                           .ToArray();
            types.ForEach(t => RegisterType(t));
        }

        static bool HasLoadFromAppDomain;
        /// <summary>
        /// 从指定的AppDomain中注册模块监听器
        /// </summary>
        static void RegisterTypeFromAppDomain()
        {
            if (!HasLoadFromAppDomain)
            {
                lock (RegisteredTypes)
                {
                    BuildManager.GetReferencedAssemblies().Cast<Assembly>()
                        .Where(p => !p.IsSystemAssembly())
                        .ForEach(p => RegisterFromAssembly(p));
                    HasLoadFromAppDomain = true;
                }
            }
        }
    }

    class HttpModule : IHttpModule
    {
        private HttpApplication Application;
        void IHttpModule.Dispose()
        {
            ModuleManager.Clear(Application);
        }

        void IHttpModule.Init(HttpApplication context)
        {
            Application = context;
            ModuleManager.InitApplication(context);
        }
    }

    /// <summary>
    /// Http监听器适配器，是IHttpModule的适配器默认实现
    /// </summary>
    public abstract class HttpListener : IHttpListener
    {
        /// <summary>
        /// 当 ASP.NET 获取与当前请求关联的当前状态（如会话状态）时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnAcquireRequestState(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当安全模块已建立用户标识时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnAuthenticateRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当安全模块已验证用户授权时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnAuthorizeRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在 ASP.NET 响应请求时作为 HTTP 执行管线链中的第一个事件发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnBeginRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在释放应用程序时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnDisposed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在 ASP.NET 响应请求时作为 HTTP 执行管线链中的最后一个事件发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnEndRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当引发未经处理的异常时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnError(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 恰好在 ASP.NET 为当前请求执行任何记录之前发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnLogRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 基础结构。在选择了用来响应请求的处理程序时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnMapRequestHandler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在已获得与当前请求关联的请求状态（例如会话状态）时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPostAcquireRequestState(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当安全模块已建立用户标识时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在当前请求的用户已获授权时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPostAuthorizeRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在 ASP.NET 处理完 LogRequest 事件的所有事件处理程序后发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPostLogRequest(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在 ASP.NET 已将当前请求映射到相应的事件处理程序时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPostMapRequestHandler(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在 ASP.NET 已完成所有请求事件处理程序的执行并且请求状态数据已存储时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPostReleaseRequestState(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在 ASP.NET 事件处理程序（例如，某页或某个 XML Web service）执行完毕时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPostRequestHandlerExecute(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在 ASP.NET 跳过当前事件处理程序的执行并允许缓存模块满足来自缓存的请求时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPostResolveRequestCache(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在 ASP.NET 完成缓存模块的更新并存储了用于从缓存中为后续请求提供服务的响应后，发生此事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPostUpdateRequestCache(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 恰好在 ASP.NET 开始执行事件处理程序（例如，某页或某个 XML Web services）前发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPreRequestHandlerExecute(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 恰好在 ASP.NET 向客户端发送内容之前发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPreSendRequestContent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 恰好在 ASP.NET 向客户端发送 HTTP 标头之前发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在 ASP.NET 执行完所有请求事件处理程序后发生。 该事件将使状态模块保存当前状态数据。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnReleaseRequestState(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 在 ASP.NET 完成授权事件以使缓存模块从缓存中为请求提供服务后发生，从而绕过事件处理程序（例如某个页或 XML Web services）的执行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnResolveRequestCache(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 当 ASP.NET 执行完事件处理程序以使缓存模块存储将用于从缓存为后续请求提供服务的响应时发生。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnUpdateRequestCache(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
