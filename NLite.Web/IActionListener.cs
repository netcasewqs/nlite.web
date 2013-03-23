using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NLite.Reflection;
using NLite.Binding;
using System.Web.UI;
using NLite.Domain;
using NLite.Collections;
using System.Collections;

namespace NLite.Web
{
    /// <summary>
    /// Action 元数据
    /// </summary>
    public class ActionDescriptor
    {
        /// <summary>
        /// Action 方法
        /// </summary>
        public readonly MethodInfo Method;
        /// <summary>
        /// Action 委托方法
        /// </summary>
        public readonly Func Action;
        /// <summary>
        /// 参数绑定集合
        /// </summary>
        public readonly BindingInfo[] Bindings;
        /// <summary>
        /// 构造Action元数据
        /// </summary>
        /// <param serviceDispatcherName="method"></param>
        public ActionDescriptor(MethodInfo method)
        {
            Guard.NotNull(method, "method");
            Method = method;
            Action = method.GetFunc();
            Bindings = method.GetParameters().Select(p => new BindingInfo(p)).ToArray();
        }
    }

    /// <summary>
    /// Action 上下文
    /// </summary>
    public class ActionContext
    {
        /// <summary>
        /// 目标对象，可以是用户控件或页面 
        /// </summary>
        public Control Target { get; private set; }
        /// <summary>
        /// Action 元数据
        /// </summary>
        public ActionDescriptor ActionDescriptor { get;internal set; }
        /// <summary>
        /// Action 调用参数
        /// </summary>
        public object[] Args { get; set; }

        /// <summary>
        /// 得到或设置异常
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// 构造Action上下文对象
        /// </summary>
        /// <param serviceDispatcherName="target"></param>
        public ActionContext(Control target)
        {
            if(target == null)
                throw new ArgumentNullException("target");
            Target = target; 
        }
    }

    /// <summary>
    /// 页面监听器接口
    /// </summary>
    public interface IActionListener:IListener
    {
        /// <summary>
        /// 在Action分发前进行监听
        /// </summary>
        /// <param serviceDispatcherName="ctx"></param>
        void OnDispatching(ActionContext ctx);

        /// <summary>
        /// 在Action被发现时进行监听
        /// </summary>
        /// <param serviceDispatcherName="ctx"></param>
        void OnActionDescriptorFound(ActionContext ctx);

        /// <summary>
        /// Called before an operation method executes.
        /// </summary>
        /// <param serviceDispatcherName="ctx"></param>
        void OnActionExecuting(ActionContext ctx);

        /// <summary>
        /// Called after an operation method executes.
        /// </summary>
        /// <param serviceDispatcherName="ctx"></param>
        void OnActionExecuted(ActionContext ctx);

        /// <summary>
        /// 在异常发生时进行监听
        /// </summary>
        void OnExceptionFired(ActionContext ctx);

        /// <summary>
        /// 在Action分发后进行监听
        /// </summary>
        void OnDispatched(ActionContext ctx);
    }

    /// <summary>
    /// Action 监听器
    /// </summary>
    public class ActionListener:IActionListener
    {
        /// <summary>
        /// 在Action分发前进行监听
        /// </summary>
        /// <param serviceDispatcherName="ctx"></param>
        public virtual void OnDispatching(ActionContext ctx)
        {
        }

        /// <summary>
        /// 在Action被发现时进行监听
        /// </summary>
        /// <param serviceDispatcherName="ctx"></param>
        public virtual void OnActionDescriptorFound(ActionContext ctx)
        {
        }

        /// <summary>
        /// Called before an operation method executes.
        /// </summary>
        /// <param serviceDispatcherName="ctx"></param>
        public virtual void OnActionExecuting(ActionContext ctx)
        {
        }

        /// <summary>
        /// Called after an operation method executes.
        /// </summary>
        /// <param serviceDispatcherName="ctx"></param>
        public virtual void OnActionExecuted(ActionContext ctx)
        {
        }

        /// <summary>
        /// 在异常发生时进行监听
        /// </summary>
        /// <param serviceDispatcherName="ctx"></param>
        public virtual void OnExceptionFired(ActionContext ctx)
        {
        }

        /// <summary>
        /// 在Action分发后进行监听
        /// </summary>
        /// <param serviceDispatcherName="ctx"></param>
        public virtual void OnDispatched(ActionContext ctx)
        {
        }
    }

    /// <summary>
    /// 页面监听管理器接口
    /// </summary>
    public interface IActionListenManager : IListenerManager<IActionListener>, IActionListener
    {

    }

    /// <summary>
    /// 页面监听管理器
    /// </summary>
    public sealed class ActionListenManager : ListenerManager<IActionListener>, IActionListenManager
    {
        /// <summary>
        /// 得到页面监听器实例对象
        /// </summary>
        public static readonly IActionListenManager Instance = new ActionListenManager();

        private ActionListenManager() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param serviceDispatcherName="listner"></param>
        protected override void OnAfterRegister(IActionListener listner)
        {
            var methods = listner.GetType().GetMethods();
            var type = listner.GetType();
            foreach (var m in methods)
            {
                if (m.DeclaringType != type)
                    continue;
                switch (m.Name)
                {
                    case "OnDispatching":
                        Dispatching += listner.OnDispatching;
                        break;
                    case "OnDispatched":
                        Dispatched += listner.OnDispatched;
                        break;
                    case "OnActionDescriptorFound":
                        ActionDescriptorFound += listner.OnActionDescriptorFound;
                        break;
                    case "OnActionExecuting":
                        ActionExecuting += listner.OnActionExecuting;
                        break;
                    case "OnActionExecuted":
                        ActionExecuted += listner.OnActionExecuted;
                        break;
                    case "OnExceptionFired":
                        ExceptionFired += listner.OnExceptionFired;
                        break;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param serviceDispatcherName="listner"></param>
        protected override void OnAfterUnRegister(IActionListener listner)
        {
            var methods = listner.GetType().GetMethods();
            var type = listner.GetType();
            foreach (var m in methods)
            {
                if (m.DeclaringType != type)
                    continue;
                switch (m.Name)
                {
                    case "OnDispatching":
                        Dispatching -= listner.OnDispatching;
                        break;
                    case "OnDispatched":
                        Dispatched -= listner.OnDispatched;
                        break;
                    case "OnActionDescriptorFound":
                        ActionDescriptorFound -= listner.OnActionDescriptorFound;
                        break;
                    case "OnActionExecuting":
                        ActionExecuting -= listner.OnActionExecuting;
                        break;
                    case "OnActionExecuted":
                        ActionExecuted -= listner.OnActionExecuted;
                        break;
                    case "OnExceptionFired":
                        ExceptionFired -= listner.OnExceptionFired;
                        break;
                }
            }
        }

        event Action<ActionContext> Dispatching;
        void IActionListener.OnDispatching(ActionContext ctx)
        {
            var handler = Dispatching;
            if (handler != null)
                handler(ctx);
        }

        event Action<ActionContext> ActionDescriptorFound;
        void IActionListener.OnActionDescriptorFound(ActionContext ctx)
        {
            var handler = ActionDescriptorFound;
            if (handler != null)
                handler(ctx);
        }

        event Action<ActionContext> ActionExecuting;
        void IActionListener.OnActionExecuting(ActionContext ctx)
        {
            var handler = ActionExecuting;
            if (handler != null)
                handler(ctx);
        }

        event Action<ActionContext> ActionExecuted;
        void IActionListener.OnActionExecuted(ActionContext ctx)
        {
            var handler = ActionExecuted;
            if (handler != null)
                handler(ctx);
        }

        event Action<ActionContext> ExceptionFired;
        void IActionListener.OnExceptionFired(ActionContext ctx)
        {
            var handler = ExceptionFired;
            if (handler != null)
                handler(ctx);
        }

        event Action<ActionContext> Dispatched;
        void IActionListener.OnDispatched(ActionContext ctx)
        {
            var handler = Dispatched;
            if (handler != null)
                handler(ctx);
        }
    }

    class ActionExecutor
    {
        private static readonly Hashtable s_table = Hashtable.Synchronized(new Hashtable());

        private static ActionDescriptor[] GetMethodInfo(Type type)
        {
            ActionDescriptor[] array = s_table[type.AssemblyQualifiedName] as ActionDescriptor[];
            if (array == null)
            {
                array = (
                    from m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .Where(m => !m.DeclaringType.IsSystemAssemblyOfType())
                        .Where(m => m.ReturnType == Types.Void)
                        .Where(m => m.GetParameters().TrueForAll(p => !(p.IsRetval || p.IsOut)))
                        .Where(m => !m.IsSpecialName && !m.IsGenericMethod)
                    select new ActionDescriptor(m)).ToArray<ActionDescriptor>();
                s_table[type.ToString()] = array;
            }
            return array;
        }

        private static void ExecuteAction(Control target, IDictionary<string, object> valueProvider, ActionDescriptor actionDescriptor)
        {
            object[] args;
            try
            {
                args = actionDescriptor.Bindings.Select(p => p.BindModel(valueProvider)).ToArray();
            }
            catch (Exception ex)
            {
                throw new ServiceDispatcherException(ServiceDispatcherExceptionCode.ParameterBindException, ex);
            }

            try
            {
                object a = args.Length == 1 ? args[0] : args;
                actionDescriptor.Action(target, args);
            }
            catch (Exception ex)
            {
                throw new ServiceDispatcherException(ServiceDispatcherExceptionCode.OperationException, ex);
            }
        }

        public static void Execute(Control target)
        {
            try
            {
                OnExecute(target);
            }
            finally
            {
            }
        }

        private static void OnExecute(Control target)
        {
            ActionDescriptor[] methods = GetMethodInfo(target.GetType());
            if (methods.Length == 0)
                return;

            var valueProvider = HttpRequestContext.Current.ValueProvider;
            for (int i = 0; i < methods.Length; i++)
            {
                ActionDescriptor actionDescriptor = methods[i];
                if (valueProvider.ContainsKey(actionDescriptor.Method.Name))
                {
                    ExecuteAction(target, valueProvider, actionDescriptor);
                    break;
                }
            }
        }
    }
}
