using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web;
using System.Security.Principal;
using NLite.Security;
using NLite.Reflection;
using System.Threading;

namespace NLite.Web.Security
{

    /// <summary>
    /// 表单认证服务
    /// </summary>
    public sealed class FormsAuthenticationService<TUser> where TUser : class,IPrincipal
    {
        /// <summary>
        /// 从浏览器删除 Forms 身份验证票证,并清空Session
        /// </summary>
        public static void SignOut()
        {
            HttpContext context = HttpContext.Current;
            if (context != null)
                context.Session.Abandon();
            FormsAuthentication.SignOut();
        }
        /// <summary>
        /// 执行用户登录操作
        /// </summary>
        /// <param serviceDispatcherName="loginName">登录名</param>
        /// <param serviceDispatcherName="user">与登录名相关的用户信息</param>
        /// <param serviceDispatcherName="expiration">登录Cookie的过期时间，单位：分钟。</param>
        public static void SignIn(string loginName, TUser user, bool isPersistent, int expiration)
        {
            if (string.IsNullOrEmpty(loginName))
                throw new ArgumentNullException("loginName");
            if (user == null)
                throw new ArgumentNullException("user");
            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();

            // 1. 把需要保存的用户数据转成一个字符串。
            string data = null;
            if (user != null)
                data = NLite.Serialization.JsonSerializer.Current.Serialize(user);

            // 2. 创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1, loginName, DateTime.Now, DateTime.Now.AddMinutes(60), isPersistent, data);


            // 3. 加密Ticket，变成一个加密的字符串。
            string cookieValue = FormsAuthentication.Encrypt(ticket);


            // 4. 根据加密结果创建登录Cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (isPersistent && expiration > 0)
                cookie.Expires = DateTime.Now.AddMinutes(expiration);

            // 5. 写登录Cookie
            context.Response.Cookies.Remove(cookie.Name);
            context.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 根据HttpContext对象设置用户标识对象，在AuthenticateRequest事件中调用
        /// </summary>
        /// <param serviceDispatcherName="context"></param>
        public static void SetPrincipal()
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new ArgumentNullException("context");

            // 1. 读登录Cookie
            HttpCookie cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return;

            try
            {
                TUser userData = null;
                // 2. 解密Cookie值，获取FormsAuthenticationTicket对象
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);

                if (ticket != null && string.IsNullOrEmpty(ticket.UserData) == false)
                    // 3. 还原用户数据
                    userData = NLite.Serialization.JsonSerializer.Current.Deserialize(ticket.UserData,typeof(TUser)) as TUser;


                if (ticket != null && userData != null)
                    // 4. 构造FormsPrincipal实例，重新给context.User赋值。
                    context.User = new FormsPrincipal(ticket, userData);
            }
            catch { /* 有异常也不要抛出，防止攻击者试探。 */ }
        }

        /// <summary>
        /// 得到当前登录用户
        /// </summary>
        public static TUser User
        {
            get
            {
                var user = Thread.CurrentPrincipal as FormsPrincipal;
                return user != null ? (TUser)user.User : null;
            }
        }

        class FormsPrincipal : IPrincipal
        {
            private IIdentity _identity;
            private TUser _user;

            public FormsPrincipal(FormsAuthenticationTicket ticket, TUser user)
            {
                if (ticket == null)
                    throw new ArgumentNullException("ticket");
                if (user == null)
                    throw new ArgumentNullException("user");

                _identity = new FormsIdentity(ticket);
                _user = user;
            }

            public TUser User
            {
                get { return _user; }
            }

            public IIdentity Identity
            {
                get { return _identity; }
            }

            public bool IsInRole(string role)
            {
                // 把判断用户组的操作留给User去实现。

                IPrincipal principal = _user as IPrincipal;
                if (principal == null)
                    throw new NotImplementedException();
                else
                    return principal.IsInRole(role);
            }
        }
    }

   
}
