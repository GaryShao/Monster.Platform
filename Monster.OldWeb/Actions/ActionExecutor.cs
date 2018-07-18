using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Monster.OldWeb.Actions
{
    internal class ActionExecutor
    {
        private static Dictionary<MethodInfo, Func<object, object[], object>> executors
            = new Dictionary<MethodInfo, Func<object, object[], object>>();

        private static object syncObject = new object();        

        public ActionExecutor(MethodInfo methodInfo)
        {
            MethodInfo = methodInfo;
        }

        public MethodInfo MethodInfo { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target">对象</param>
        /// <param name="arguments">参数</param>
        /// <returns></returns>
        public object Execute(object target, object[] arguments)
        {
            Func<object, object[], object> executor;

            if (!executors.TryGetValue(MethodInfo, out executor))
            {
                lock (syncObject)
                {
                    if (!executors.TryGetValue(MethodInfo, out executor))
                    {
                        executor = CreateExecutor(MethodInfo);
                        executors[MethodInfo] = executor;
                    }
                }
            }
            return executor(target, arguments);
        }

        private static Func<object, object[], object> CreateExecutor(MethodInfo methodInfo)
        {
            var target = Expression.Parameter(typeof(object), "target");
            var arguments = Expression.Parameter(typeof(object[]), "arguments");

            var parameters = new List<Expression>();
            var paramInfos = methodInfo.GetParameters();
            for (int i = 0; i < paramInfos.Length; i++)
            {
                var paramInfo = paramInfos[i];
                var getElementByIndex = Expression.ArrayIndex(arguments, Expression.Constant(i));
                var convertToParameterType = Expression.Convert(getElementByIndex, paramInfo.ParameterType);
                parameters.Add(convertToParameterType);
            }

            var instanceCase = Expression.Convert(target, methodInfo.ReflectedType);
            var methodCall = Expression.Call(instanceCase, methodInfo, parameters);
            var convertToObjectType = Expression.Convert(methodCall, typeof(object));
            return Expression.Lambda<Func<object, object[], object>>(convertToObjectType, target, arguments).Compile();
        }
    }
}