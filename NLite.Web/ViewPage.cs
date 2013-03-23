using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using NLite.Web.Internal;
using NLite.Globalization;
using System.Collections.Specialized;
using NLite.Binding;
using NLite.Domain;
using NLite.Net;
using System.Web.Routing;

namespace NLite.Web
{
    /// <summary>
    /// 视图页面基类
    /// </summary>
    [FileLevelControlBuilder(typeof(ViewPageControlBuilder))]
    public class ViewPage : Page
    {
        /// <summary>
        /// Html助手类
        /// </summary>
        public HtmlHelper Html { get; private set; }

        /// <summary>
        /// 得到或设置页面模型对象
        /// </summary>
        public object Model { get; set; }

        /// <summary>
        /// 缺省构造函数
        /// </summary>
        public ViewPage()
        {
            Html = new HtmlHelper();
        }
    }

    /// <summary>
    /// 泛型视图页面基类
    /// </summary>
    /// <typeparam serviceDispatcherName="TModel"></typeparam>
    public class ViewPage<TModel> : ViewPage
    {
        /// <summary>
        /// 得到或设置泛型页面模型对象
        /// </summary>
        public new TModel Model
        {
            get { return (TModel)base.Model; }
            set { base.Model = value; }
        }
    }

    /// <summary>
    /// 控件或页面扩展方法类
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// 执行领域服务调用
        /// </summary>
        /// <param serviceDispatcherName="serviceRouteName">服务路由名称，该名称来标记一个唯一的服务分发器</param>
        /// <param serviceDispatcherName="serviceName">服务名称</param>
        /// <param serviceDispatcherName="actionName">操作名称</param>
        /// <returns>服务的返回值</returns>
        public static object Execute(this Control control, string serviceRouteName, string serviceName, string actionName, Action<Exception> exceptionHandler = null)
        {
            if (control == null)
                throw new ArgumentNullException("control");
            if (string.IsNullOrEmpty(serviceRouteName))
                throw new ArgumentNullException("serviceRouteName");
            var config = ServiceLocator.Get<IServiceDispatcherConfiguationItem>(serviceRouteName);
            if (config == null)
                throw new ApplicationException("Invalid service route name:" + serviceRouteName);


            var req = ServiceRequest.Create(serviceName, actionName, HttpRequestContext.Current.ValueProvider);
            IServiceResponse resp = null;

            try
            {
                var serviceDispatcher = config.ServiceDispatcherCreator();
                resp = serviceDispatcher.Dispatch(req);
            }
            catch (Exception e)
            {
                if (exceptionHandler != null)
                {
                    exceptionHandler(e);
                    e.Handle();
                }
                throw e;
            }

            if (resp.Success)
                return resp.Result;

            if (exceptionHandler != null && resp.Exception != null)
            {
                exceptionHandler(resp.Exception);
                throw resp.Exception;
            }

            return null;
        }
    }

    class HttpRequestContext
    {

        public IDictionary<string, object> ValueProvider;
        public IHttpContext HttpContext;
        public IServiceRequest ServiceRequest;
        public RouteData RouteData;

        static readonly IDictionary<string, object> EmptyRouteValues = new Dictionary<string, object>(0);
        //[ThreadStatic]
        //private static HttpRequestContext instance;


//#if SDK4
//        private static System.Threading.ThreadLocal<HttpRequestContext> instanceWrapper
//            = new System.Threading.ThreadLocal<HttpRequestContext>(() => CreateHttpRequestContext(System.Web.HttpContext.Current));

//        public static HttpRequestContext Current
//        {
//            get { return instanceWrapper.Value; }
//        }
//#else
        public static HttpRequestContext Current
        {
            get
            {
                var httpContext = System.Web.HttpContext.Current;
                if (!httpContext.Items.Contains("HttpRequestContext"))
                {
                    var instance = CreateHttpRequestContext(httpContext);
                    httpContext.Items["HttpRequestContext"] = instance;
                }
                return httpContext.Items["HttpRequestContext"] as HttpRequestContext;
            }
            
        }
//#endif

        static HttpRequestContext CreateHttpRequestContext(HttpContext httpContext)
        {
            var instance = new HttpRequestContext();

            var context = new HttpContextWrapper(httpContext);
            IDictionary<string, object> routeValues = EmptyRouteValues;
            RouteData routeData = RouteTable.Routes.GetRouteData(context);

            if (routeData != null)
            {
                instance.RouteData = routeData;
                routeValues = routeData.Values;
                RemoveOptionalRoutingParameters(routeValues);
                var valueProvider = new DefaultValueProviderFactory().GetValueProvider(context, routeValues);
                instance.ValueProvider = valueProvider;
                instance.ServiceRequest = CreateServiceRequest(routeValues, routeData, valueProvider);
            }
            else
            {
                instance.ValueProvider = new DefaultValueProviderFactory().GetValueProvider(context, routeValues);
            }

            instance.HttpContext = context;
            
            return instance;
        }

        static void RemoveOptionalRoutingParameters(IDictionary<string, object> values)
        {
            string[] array = (
                from entry in values
                where entry.Value == UrlParameter.Optional
                select entry.Key).ToArray();

            for (int i = 0; i < array.Length; i++)
                values.Remove(array[i]);
        }

        private static IServiceRequest CreateServiceRequest(IDictionary<string, object> routeValues, RouteData routeData, IDictionary<string, object> valueProvider)
        {
            object serviceName;
           
            if (routeValues.TryGetValue("controller", out serviceName))
            {
                var strServiceName = serviceName as string;
                if (!string.IsNullOrEmpty(strServiceName))
                {
                    strServiceName = strServiceName.Trim('~');
                    object areaName;
                    if (routeData.DataTokens.TryGetValue("area", out areaName))
                    {
                        var strAreaName = areaName as string;
                        if (!string.IsNullOrEmpty(strAreaName))
                            strServiceName = strAreaName + "/" + strServiceName;
                    }

                    object actionName;
                    if (!routeValues.TryGetValue("action", out actionName))
                        actionName = valueProvider["_method"];
                    var strActionName = actionName as string;
                    if (!string.IsNullOrEmpty(strActionName))
                        strActionName = strActionName.ToLower().Replace(".aspx", "");

                    //绑定服务分发器名称
                    var route = routeData.Route as NamedRoute;
                    if (route != null && !valueProvider.ContainsKey(ServiceDispatcher.ServiceDispatcherParameterName))
                        valueProvider.Add(ServiceDispatcher.ServiceDispatcherParameterName, route.RouteName);

                    return NLite.Domain.ServiceRequest.Create(strServiceName, strActionName, valueProvider);
                }
            }

            return null;
        }
    }
}
