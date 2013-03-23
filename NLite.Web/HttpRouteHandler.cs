using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Reflection;
using System.Threading;
using System.Web.SessionState;
using NLite.Domain;
using NLite.Web.Service;
using NLite.Domain.Http;
using NLite.Net;
using System.Web;


namespace NLite.Web
{
    /// <summary>
    /// 命名路由器
    /// </summary>
    public class NamedRoute : Route
    {
        /// <summary>
        /// 路由器名称
        /// </summary>
        public string RouteName { get; private set; }
        /// <summary>
        /// 构造命名路由器
        /// </summary>
        /// <param serviceDispatcherName="routeName">路由器名称</param>
        /// <param serviceDispatcherName="url"></param>
        /// <param serviceDispatcherName="routeHandler"></param>
        public NamedRoute(string routeName, string url,IRouteHandler routeHandler):base(url,routeHandler)
        {
            if (string.IsNullOrEmpty(routeName))
                throw new ArgumentNullException("routeName");
            RouteName = routeName;
        }
    }
    public sealed class HttpRouteHandler : IRouteHandler
    {
        IHttpResponseResult ResponseResolver;
        IServiceDispatcherConfiguationItem ServiceDispatcherConfiguationItem;
        Func<IOperationDescriptor, SessionMode> GetSessionMode;

        public HttpRouteHandler(IServiceDispatcherConfiguationItem serviceDispatcherConfiguationItem
            , IHttpResponseResult responseResolver
            , Func<IOperationDescriptor,SessionMode> getSessionMode )
        {
            if (serviceDispatcherConfiguationItem == null)
                throw new ArgumentNullException("serviceDispatcherConfiguationItem");
            if (responseResolver == null)
                throw new ArgumentNullException("responseResolver");
            ServiceDispatcherConfiguationItem = serviceDispatcherConfiguationItem;
            ResponseResolver = responseResolver;
            GetSessionMode = getSessionMode;
        }

       

        internal sealed class SingleEntryGate
        {
            private const int NOT_ENTERED = 0;
            private const int ENTERED = 1;
            private int _status;
            public bool TryEnter()
            {
                int num = Interlocked.Exchange(ref this._status, 1);
                return num == 0;
            }
        }

        class HttpHandler : System.Web.IHttpHandler
        {
            public Action Handler;
            private readonly SingleEntryGate _executeWasCalledGate = new SingleEntryGate();
            internal static readonly string Version = GetVersionString();
            public static readonly string VersionHeaderName = "X-AspNet-nlite-web-Version";


            private static string GetVersionString()
            {
                return new AssemblyName(typeof(HttpHandler).Assembly.FullName).Version.ToString(2);
            }

            internal static void AddVersionHeader(NLite.Net.IHttpContext httpContext)
            {
                httpContext.Response.AppendHeader(VersionHeaderName, Version);
            }


            public bool IsReusable
            {
                get { return false; }
            }

            public void ProcessRequest(System.Web.HttpContext context)
            {
                VerifyExecuteCalledOnce();
                var contextWrapper = new NLite.Web.HttpContextWrapper(context);
                AddVersionHeader(contextWrapper);
               

                context.Response.HeaderEncoding = Encoding.UTF8;
                context.Response.ContentEncoding = Encoding.UTF8;

                Handler();
            }

            void VerifyExecuteCalledOnce()
            {
                if (!this._executeWasCalledGate.TryEnter())
                {
                    string message = "Cannot handle multiple requests";
                    throw new InvalidOperationException(message);
                }
            }


        }

        class RequireSessionHttpHandler : HttpHandler, IRequiresSessionState { }
        class ReadonlySessionHttpHandler : HttpHandler, IReadOnlySessionState { }
        class EmptyHttpHandler : IHttpHandler
        {
            public static readonly IHttpHandler Instance = new EmptyHttpHandler();

            public bool IsReusable
            {
                get { return false; }
            }

            public void ProcessRequest(HttpContext context)
            {
            }
        }

        System.Web.IHttpHandler IRouteHandler.GetHttpHandler(RequestContext context)
        {
            //var routeData = context.RouteData;
            //RemoveOptionalRoutingParameters(context.RouteData);


            var ctx = HttpRequestContext.Current.HttpContext;// new HttpContextWrapper(HttpContext.Current);
            //IServiceRequest req = null;
            //try
            //{
            //    var routeValues = routeData.Values;
            //    req = RequestResolver.Resolve(HttpRequestContext.Current.ValueProvider, routeData.Values, routeData.DataTokens);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            var req = HttpRequestContext.Current.ServiceRequest;
            if (!req.Arguments.ContainsKey(ServiceDispatcher.ServiceDispatcherParameterName))
                req.Arguments.Add(ServiceDispatcher.ServiceDispatcherParameterName, ServiceDispatcherConfiguationItem.Name);

            IServiceDispatcher serviceDispatcher = null;
            DefaultServiceDispatcher defaultServiceDispatcher = null;
            try
            {
                serviceDispatcher = ServiceDispatcherConfiguationItem.ServiceDispatcherCreator();
                if (serviceDispatcher == null)
                    throw new ServiceDispatcherException( ServiceDispatcherExceptionCode.CreateServiceException);
                defaultServiceDispatcher = serviceDispatcher as DefaultServiceDispatcher;
                if (GetSessionMode == null)
                    return CreateDefaultHandler(ctx, req, defaultServiceDispatcher);
                if(defaultServiceDispatcher == null)
                    return CreateDefaultHandler(ctx, req, defaultServiceDispatcher);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            IOperationDescriptor operationDescriptor = null;

            try
            {
                ServiceDispatcherConfiguationItem.ListenManager.OnDispatching(req);
                operationDescriptor = defaultServiceDispatcher.GetOperationDescriptor(req);
            }
            catch (Exception ex)
            {
                //ServiceDispatcherConfiguationItem
                throw ex;
            }

            Action invoke = CreateInvokeAction(ctx, req, defaultServiceDispatcher, operationDescriptor);

            SessionMode mode = SessionMode.Support;
            if (GetSessionMode != null)
            {
                try
                {
                    mode = GetSessionMode(operationDescriptor);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

            if (mode == SessionMode.NotSupport)
                return new HttpHandler { Handler = invoke };
            else if (mode == SessionMode.ReadOnly)
                return new ReadonlySessionHttpHandler { Handler = invoke };
            return new RequireSessionHttpHandler { Handler = invoke };
        }

        private Action CreateInvokeAction(IHttpContext ctx, IServiceRequest req, DefaultServiceDispatcher serviceDispatcher, IOperationDescriptor operationDescriptor)
        {
            Action invoke = () =>
            {
                IServiceResponse resp = null;
                try
                {
                    resp = serviceDispatcher.Execute(req, operationDescriptor);
                }
                catch (Exception e)
                {
                   throw  e;
                }
                finally
                {
                    var disposalbe = serviceDispatcher as IDisposable;
                    if (disposalbe != null)
                        disposalbe.Dispose();
                    ServiceDispatcherConfiguationItem.ListenManager.OnDispatched(req);
                    ServiceContext.Current = null;
                }

                try
                {
                    ResponseResolver.Execute(ctx, resp);
                }
                catch (Exception ex)
                {
                   throw ex;
                }
            };
            return invoke;
        }

        private IHttpHandler CreateDefaultHandler(IHttpContext ctx, IServiceRequest req, DefaultServiceDispatcher serviceDispatcher)
        {
            Action invoke = () =>
            {
                IServiceResponse resp = null;
                try
                {
                    resp = serviceDispatcher.Dispatch(req);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    var disposalbe = serviceDispatcher as IDisposable;
                    if (disposalbe != null)
                        disposalbe.Dispose();

                    ServiceContext.Current = null;
                }

                try
                {
                    ResponseResolver.Execute(ctx, resp);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            };

            return new RequireSessionHttpHandler { Handler = invoke };
        }
    }
}
