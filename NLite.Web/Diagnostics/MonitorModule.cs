using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Web;

namespace NLite.Web.Diagnostics
{
    /// <summary>
    /// 监视数据信息
    /// </summary>
    public class PerformanceInfo
    {
        /// <summary>
        /// 保存监视数据
        /// </summary>
        public static Action<PerformanceInfo> Save = m => { };
        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// 当前请求的用户
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// 请求开始时间
        /// </summary>
        public DateTime BeginTime { get; set; }
        /// <summary>
        /// 请求结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 请求的Url地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 请求响应时间
        /// </summary>
        public double HttpProcessTime { get; set; }

        /// <summary>
        /// 是否发生错误
        /// </summary>
        public bool HasError { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// 错误堆栈信息
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// 领域性能监控数据集合
        /// </summary>
        public List<NLite.Domain.Diagnostics.PerformanceInfo> Items = new List<Domain.Diagnostics.PerformanceInfo>(); 
    }

    class MonitorContext
    {
        internal static MonitorContext Current
        {
            get
            {
                var TLS = HttpContext.Current.Items;
                const string Key = "_NLite_Web_Monitor_Context_";
                if (!TLS.Contains(Key))
                {
                    var instance = new MonitorContext();
                    TLS[Key] = instance;
                    return instance;
                }

                return TLS[Key] as MonitorContext;
            }
        }

        internal PerformanceInfo Data;
        internal Stopwatch Stopwatch;
        internal MonitorContext()
        {
            Data = new PerformanceInfo();
            Stopwatch = new System.Diagnostics.Stopwatch();
            Data.BeginTime = DateTime.UtcNow;

            var httpContext = HttpContext.Current;
            Data.Url = httpContext.Request.Url.ToString();
            Data.Ip = WebHelper.GetIpAddress();
            NLite.Domain.Diagnostics.MonitorContext.Current.Save = m => Data.Items.Add(m);
            Data.User = httpContext.User != null
                ? httpContext.User.Identity != null
                                            ? httpContext.User.Identity.Name
                                            : null
                : null;
        }
    }

    /// <summary>
    /// 监视器助手类
    /// </summary>
    public static class Monitor
    {
        /// <summary>
        /// 监视错误
        /// </summary>
        public static void Error()
        {
            var context = MonitorContext.Current;
            context.Data.HasError = true;
            var error = HttpContext.Current.Server.GetLastError();
            context.Data.ErrorMessage = error.Message;
            context.Data.StackTrace = error.StackTrace;
        }

        /// <summary>
        /// 监视请起结束
        /// </summary>
        public static void Stop()
        {
            var context = MonitorContext.Current;
            context.Data.EndTime = DateTime.UtcNow;
            context.Stopwatch.Stop();
            context.Data.HttpProcessTime = context.Stopwatch.ElapsedMilliseconds;

            if (PerformanceInfo.Save != null)
                PerformanceInfo.Save(context.Data);
        }

        /// <summary>
        /// 监视请求开始
        /// </summary>
        public static void Start()
        {
            var context = MonitorContext.Current;
            context.Stopwatch.Start();
        }
    }
}

