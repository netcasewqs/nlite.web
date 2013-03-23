using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using NLite.Domain;
using NLite.Data;
using NLite;
using NLite.Domain.Cfg;
using NLite.Net;
using System.Reflection;
using NLite.Domain.Http;
using System.Web;
using NLite.Domain.Listener;
using System.Web.UI;

namespace NLite.Web
{
    
    namespace Service
    {
        ///// <summary>
        ///// 请求解析器接口
        ///// </summary>
        //public interface IHttpRequestResolver
        //{
        //    /// <summary>
        //    /// 通过请求上下文以及routeValues等获取服务请求对象
        //    /// </summary>
        //    /// <param serviceDispatcherName="httpContext"></param>
        //    /// <param serviceDispatcherName="routeValues"></param>
        //    /// <param serviceDispatcherName="dataTokens"></param>
        //    /// <returns></returns>
        //    IServiceRequest Resolve(IDictionary<string, object> requestParams, IDictionary<string,object> routeValues,IDictionary<string,object> dataTokens);
        //}

        ///// <summary>
        ///// 请求解析器
        ///// </summary>
        //public class HttpRequestResolver : IHttpRequestResolver
        //{
           
        //    /// <summary>
        //    /// 
        //    /// </summary>
        //    /// <param serviceDispatcherName="httpContext"></param>
        //    /// <param serviceDispatcherName="routeValues"></param>
        //    /// <param serviceDispatcherName="dataTokens"></param>
        //    /// <returns></returns>
        //    public IServiceRequest Resolve(IDictionary<string, object> requestParams, IDictionary<string, object> routeValues, IDictionary<string, object> dataTokens)
        //    {
        //        var @params = requestParams;
        //        var serviceName = @params["controller"] as string;
        //        var actionName = routeValues.ContainsKey("action")
        //            ? routeValues["action"] as string
        //            : @params["_method"] as string;


        //        if (serviceName != null)
        //            serviceName = serviceName.Trim('~');

        //        string areaName = null;
        //        if (dataTokens.ContainsKey("area"))
        //            areaName = dataTokens["area"] as string;
        //        if(!string.IsNullOrEmpty(areaName))
        //            serviceName = areaName + "/" + serviceName;

        //        if (!string.IsNullOrEmpty(actionName))
        //            actionName = actionName.ToLower().Replace(".aspx", "");

        //        var req = ServiceRequest.Create(serviceName, actionName, @params);
        //        req.ValidateRequest = true;

        //        return req;
        //    }
        //}

        /// <summary>
        /// 基于Json格式的异常呈现器
        /// </summary>
        public class HttpJsonExceptionRender : NLite.IExceptionRender
        {
            /// <summary>
            /// 呈现异常
            /// </summary>
            /// <param serviceDispatcherName="code"></param>
            /// <param serviceDispatcherName="ex"></param>
            public void RenderException(int code, Exception ex)
            {
              
                var httpContext = HttpContext.Current;
                if (httpContext == null)
                    throw new ArgumentNullException("httpContext");

                var requestContext = HttpRequestContext.Current;
                if (requestContext != null
                    && requestContext.RouteData != null
                    && requestContext.RouteData.RouteHandler is HttpRouteHandler)
                {
                    var response = httpContext.Response;
                    string message = ex.Message;
                    response.ContentType = "application/json";
                    var strJsonResponse = "{\"code\":\"" + code.ToString() + "\",\"message\":\"" + message + "\"}";
                    response.Write(strJsonResponse);
                    return;
                }

                throw ex;
            }
        }

       
    }
}
