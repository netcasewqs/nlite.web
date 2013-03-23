using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using NLite.Web.Service;
using NLite.Cfg;
using NLite.Domain;
using NLite.Domain.Cfg;
using NLite.Domain.Http;
namespace NLite.Web
{
    /// <summary>
    /// 路由设置类
    /// </summary>
    public class RouteOption
    {
        /// <summary>
        /// 路由名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 路由Url
        /// </summary>
        public string Url;
        /// <summary>
        /// 缺省路由参数
        /// </summary>
        public object Defaults;
        /// <summary>
        /// 路由约束
        /// </summary>
        public object Constraints;
        /// <summary>
        /// DataTokens
        /// </summary>
        public object DataTokens;
        /// <summary>
        /// Namespaces
        /// </summary>
        public string[] Namespaces;
    }

    /// <summary>
    /// 服务路由设置
    /// </summary>
    public class ServiceRouteOption : RouteOption
    {
        /// <summary>
        /// 缺省构造函数
        /// </summary>
        public ServiceRouteOption()
        {
            //RequestResolver = new HttpRequestResolver();
            ResponseResult = new HttpResponseResult();
            PopulateServiceName = ServiceDispatcher.GetServiceNameByDefault;
        }

        /// <summary>
        /// 检查特定的类型是否是服务类型,如果是返回服务名称，否则返回null
        /// </summary>
        public Func<Type, string> PopulateServiceName;
        ///// <summary>
        ///// 请求解析器
        ///// </summary>
        //public IHttpRequestResolver RequestResolver;
        /// <summary>
        /// 响应结果处理器
        /// </summary>
        public IHttpResponseResult ResponseResult;
        /// <summary>
        /// 设置一个委托，用来判断当前的操作是否支持Session
        /// </summary>
        public Func<IOperationDescriptor, SessionMode> GetSessionMode;

    }

    /// <summary>
    /// Action所支持的Session模式
    /// </summary>
    public enum SessionMode
    {
        /// <summary>
        /// 不支持
        /// </summary>
        NotSupport,
        /// <summary>
        /// 全支持
        /// </summary>
        Support,
        /// <summary>
        /// 仅支持读取
        /// </summary>
        ReadOnly
    }


    public static class HttpServiceRouteExtensions
    {
        private sealed class IgnoreRouteInternal : Route
        {
            public IgnoreRouteInternal(string url)
                : base(url, new StopRoutingHandler())
            {
            }
            public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary routeValues)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param serviceDispatcherName="cfg"></param>
        /// <param serviceDispatcherName="url"></param>
        public static void IgnoreRoute(this Configuration cfg, string url)
        {
           
            cfg.IgnoreRoute(url, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param serviceDispatcherName="cfg"></param>
        /// <param serviceDispatcherName="url"></param>
        /// <param serviceDispatcherName="constraints"></param>
        public static void IgnoreRoute(this Configuration cfg, string url, object constraints)
        {
            Guard.NotNull(cfg, "cfg");
            Guard.NotNull(url, "url");

            IgnoreRouteInternal item = new IgnoreRouteInternal(url)
            {
                Constraints = new RouteValueDictionary(constraints)
            };

            RouteTable.Routes.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param serviceDispatcherName="cfg"></param>
        /// <param serviceDispatcherName="option"></param>
        /// <returns></returns>
        public static Route MapRequestRoute(this Configuration cfg, ServiceRouteOption option)
        {
            if (cfg == null)
                throw new ArgumentNullException("cfg");
            if (option == null)
                throw new ArgumentNullException("option");
            if (string.IsNullOrEmpty(option.Name))
                throw new ArgumentNullException("option.Name");
            if (string.IsNullOrEmpty(option.Url))
                throw new ArgumentNullException("option.Url");
            //if (option.RequestResolver == null)
            //    throw new ArgumentNullException("option.RequestResolver");
            if (option.ResponseResult == null)
                throw new ArgumentNullException("option.ResponseResult");

            var serviceDispatcherOption = option.PopulateServiceName == null ?
                new ServiceDispatcherConfiguationItem(option.Name)
                : new ServiceDispatcherConfiguationItem(option.Name, option.PopulateServiceName);
            var routeHandler = new HttpRouteHandler(serviceDispatcherOption,/*option.RequestResolver,*/option.ResponseResult, option.GetSessionMode);

            Route route = new Route(option.Url, routeHandler)
            {
                Defaults = new RouteValueDictionary(option.Defaults),
                Constraints = new RouteValueDictionary(option.Constraints),
                DataTokens = new RouteValueDictionary(option.DataTokens)
            };
            if (option.Namespaces != null && option.Namespaces.Length > 0)
                route.DataTokens["Namespaces"] = option.Namespaces;

            cfg.ConfigureServiceDispatcher(serviceDispatcherOption);

            RouteTable.Routes.Add(option.Name, route);

            return route;
        }

    }

    /// <summary>
    /// 缺省路由参数类
    /// </summary>
    public sealed class UrlParameter
    {
        public static readonly UrlParameter Optional = new UrlParameter();
        private UrlParameter()
        {
        }
    }
}
